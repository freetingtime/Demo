using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Xml;
using System.Runtime.Versioning;

namespace TCSearch
{
    class Program
    {
        static System.Collections.ArrayList alst;
        static FileStream fs;
        static StreamWriter sw;
        static void Main(string[] args)
        {
            Console.WriteLine("TypeConverters已写入c:\\TypeConverters.cvs");
            FrameworkName frameworkName = new FrameworkName(".NETFramework", new Version("4.0"));
            IList<string> referenceAssemblies = Microsoft.Build.Utilities.ToolLocationHelper.GetPathToReferenceAssemblies(frameworkName);//返回.Net Framework的引用程序集位置的路径
            String bathPath = referenceAssemblies[0];
            fs = new FileStream("c:\\TypeConverters.cvs", FileMode.Create);
            sw = new StreamWriter(fs);
            foreach (string f in readlist(bathPath))
            {
                ReadXml(f);
            }
            sw.Close();
            fs.Close();
            Console.WriteLine("按任意键结束");
            Console.Read();
            
           
        }

        public static void ReadXml(String xmlPath)
        {
            String summary="";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(xmlPath);
            XmlNodeList topM = xmldoc.DocumentElement.ChildNodes;
            try
            {
                foreach (XmlElement element in topM)
                {
                    if (element.Name.ToLower() == "members")
                    {
                        XmlNodeList nodelist = element.ChildNodes;
                        foreach (XmlElement el in nodelist)
                        {
                            String TmemberName = el.Attributes["name"].InnerText;
                            if (!TmemberName.StartsWith("T"))//以T开头代表为类
                                continue;
                            String memberName = TmemberName.Substring(2, TmemberName.Length - 2);
                            if (el.SelectSingleNode("summary") != null)
                                summary = el.SelectSingleNode("summary").InnerText;
                            WriteElementInFile(memberName, summary);


                        }
                    }
                }
            }
            catch
            {
            }
                   
        }
        public static void WriteElementInFile(String memberName, String su)
        {
            try
            {
                //if (Type.GetType(memberName).IsSubclassOf(typeof(System.ComponentModel.TypeConverter))) 
                //本应该判断是否为TypeConverter的子类,但是由于涉及到的命名空间太多，无法全部引用
                if (memberName.Contains("Converter"))                
                    sw.WriteLine(memberName + "," + su);//写入文件
            }
            catch 
            { }
        }

        public static void SearchTypeConverter()
        {
            Type baseType = typeof(System.ComponentModel.TypeConverter);
            //返回所有程序集
            Assembly[] allAssemblys = AppDomain.CurrentDomain.GetAssemblies();
            int num = 0;
       

            foreach (Assembly TempAssemblys in allAssemblys)
            {
                //返回指定程序集下所有类
                Type[] ts = TempAssemblys.GetTypes();
                foreach (Type temp in ts)
                {
                    //判断是否为TypeConverter的子类
                    if (temp.IsSubclassOf(baseType))
                    {
                        num++;
                        Console.WriteLine(num + " " + temp.FullName);
                    }
                }
            }
        }

        public static void GetFiles(string dir)
        {
            try
            {
                string[] files = Directory.GetFiles(dir);//得到文件
                foreach (string file in files)//循环文件
                {
                    string exname = file.Substring(file.LastIndexOf(".") + 1);//得到后缀名
                    if (".xml".IndexOf(file.Substring(file.LastIndexOf(".") + 1)) > -1)//如果后缀名为.xml文件
                    {
                        FileInfo fi = new FileInfo(file);//建立FileInfo对象
                        alst.Add(fi.FullName);//把.txt文件全名加人到FileInfo对象
                    }
                }
            }
            catch
            {

            }
        }

        public static string[] readlist(string path)
        {
            alst = new System.Collections.ArrayList();//建立ArrayList对象
            GetDirs(path);//得到文件夹
            return (string[])alst.ToArray(typeof(string));//把ArrayList转化为string[]
        }

        public static void GetDirs(string d)//得到所有文件夹
        {
            GetFiles(d);//得到所有文件夹里面的文件
            try
            {
                string[] dirs = Directory.GetDirectories(d);
                foreach (string dir in dirs)
                {
                    GetDirs(dir);//递归
                }
            }
            catch
            {
            }
        }


    }
}
