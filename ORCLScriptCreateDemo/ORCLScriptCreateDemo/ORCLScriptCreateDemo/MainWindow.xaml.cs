// 名称： MainWindow

// 描述： MainWindow.xaml 的交互逻辑

// 创建人：郭倩

// 创建时间：2015-02-05

// 最后修改人：郭倩

// 最后修改时间：2015-02-09

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Forms;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.DataAccess.Client;
using System.Collections;
using System.IO;

namespace ORCLScriptCreateDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private List<DBObject> _FailObjects;
        private bool _IsChooseAll;
        public string DbOwner;
        private string _DbInfo;
      
        private OracleConnection _Conn = null;
        private DBObjectsListViewModel _Dbolvm = new DBObjectsListViewModel();

        public MainWindow(String dbinfo)
        {
          
            this._DbInfo = dbinfo;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.wd_main.DataContext = this._Dbolvm;
        }

        
        /// <summary>
        ///按依赖顺序导出用户所选的非物理表对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hl_ImportSelOb_Click(object sender, RoutedEventArgs e)
        {
            //若指定用户的非物理表对象为空
            if (this._Dbolvm.DbObjects == null)
            {
                System.Windows.MessageBox.Show("请先选择用户！");
                return;
            }

            //获取用户所选的非物理表对象及其依赖的非物理表对象
            _Dbolvm.IsChooseAll = false;
            _Dbolvm.GetResult();
            _IsChooseAll = false;

            //将获取到的对象的创建脚本写入文件
            if (!WriteScirptToFile())
                return;

            
            if (System.Windows.MessageBox.Show("创建脚本写入完毕！失败" + _FailObjects.Count + "个！\n是否导出依赖的物理表？", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //将依赖的物理表写入文件
                if (!WriteTableListToFile())
                    return;

            }
        }

        /// <summary>
        ///按依赖顺序导出所有非物理表对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hl_ImportAllOb_Click(object sender, RoutedEventArgs e)
        {

            if (this._Dbolvm.DbObjects == null)
            {
                System.Windows.MessageBox.Show("请先选择用户！");
                return;
            }
            //获取指定用户下所有非物理表对象及其依赖的非物理表对象
            _Dbolvm.IsChooseAll = true;
            _Dbolvm.GetResult();
            _IsChooseAll = true;

            //将获取到的对象的创建脚本写入文件
            if (!WriteScirptToFile())
                return;

           
            if (System.Windows.MessageBox.Show("创建脚本写入完毕！失败" + _FailObjects.Count + "个！\n是否导出依赖的物理表？","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //将依赖的物理表写入文件
                if (!WriteTableListToFile())
                    return;

            }
            
        }

        /// <summary>
        /// 获取指定用户下所有对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_begin_Click(object sender, RoutedEventArgs e)
        {
           
            DbOwner = this.tb_user.Text;
           

            if (DbOwner.Equals(""))
            {
                System.Windows.MessageBox.Show("用户不能为空！");
                return;
            }
            _Dbolvm.DbInfo = this._DbInfo;
            _Dbolvm.DbOwner = this.DbOwner;

            //返回指定用户下所有对象
           if(!_Dbolvm.GetAllUserByOwner())
               System.Windows.MessageBox.Show("该用户下没有非物理表对象");
          
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbSelectedAll_Checked(object sender, RoutedEventArgs e)
        {
            if (this._Dbolvm.DbObjects != null)
            {
                foreach (DBObject db in this._Dbolvm.DbObjects)
                {
                    db.IsSelected = true;
                }
            }
            this._IsChooseAll = true;
           
        }

        /// <summary>
        /// 全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbSelectedAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (this._Dbolvm.DbObjects != null)
            {
                foreach (DBObject db in this._Dbolvm.DbObjects)
                {
                    db.IsSelected = false;
                }
            }
            this._IsChooseAll = false;
        }
       

       
        /// <summary>
        ///获取oracle连接 
        /// </summary>
        /// <returns></returns>
        public OracleConnection GetConnection()
        {
            if (_Conn == null)
                _Conn = new OracleConnection(_DbInfo);

            return _Conn;
        }



       
        /// <summary>
        ///将获取到的对象的创建脚本写入文件 
        /// </summary>
        /// <returns>用户取消写入文件返回false，否则返回true</returns>
        public bool WriteScirptToFile()
        {
            String sql = "";
            GetConnection();
            OracleCommand obCommand = _Conn.CreateCommand();
            OracleDataReader myReader = null;
            //设置保存文件弹框
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存脚本文件";
            kk.Filter = "SQL文件(*.sql)|*.sql|所有文件(*.*)|*.*";
            kk.FilterIndex = 1;
            _FailObjects = new List<DBObject>();
            //若选择文件保存地址成功
            if (kk.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //初始化写文件的流
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.UTF8);

                try
                {
                    //打开数据库连接
                    _Conn.Open();
                    int i = 0;
                    while (i < this._Dbolvm.Result.Count)
                    {
                        DBObject temp = this._Dbolvm.Result[i];
                        //从oracle获取指定对象的创建脚本
                        sql = "select dbms_metadata.get_ddl('" + temp.Type + "','" + temp.Name + "','" + temp.Owner + "') from dual";
                        obCommand.CommandText = sql;
                        obCommand.Connection = _Conn;
                        try
                        {
                            myReader = obCommand.ExecuteReader();

                            //将返回结果写入文件
                            while (myReader.Read())
                            {
                               //this.test.AppendText(temp.Name + "（Type: " + temp.Type + " Owner: " + temp.Owner + "） 的创建脚本已写入：\n");
                                objStreamWriter.WriteLine("--" + temp.Name + "（Type: " + temp.Type + " Owner: " + temp.Owner + "）");
                                objStreamWriter.WriteLine(myReader.GetValue(0)+";");
                            }

                            myReader.Close();
                            i++;
                        }
                        catch (Exception e)
                        {
                            objStreamWriter.WriteLine("--对象" + temp.Name + "（Type: " + temp.Type + " Owner: " + temp.Owner + "）的创建脚本写入失败：\n");
                            objStreamWriter.WriteLine("--" + e.Message + "\n");
                            
                            //已经达到一个进程打开的最大游标数 重启连接
                            if (e.Message.Equals("ORA-01000: maximum open cursors exceeded"))
                            {
                                _Conn.Close();
                                _Conn.Open();
                                i--;
                            }
                            //找不到指定对象，可能是登录用户权限不够
                            if (e.Message.Contains("not found in schema"))
                                objStreamWriter.WriteLine("请确定当前登录用户对" + temp.Owner + "有访问权限\n");
                            i++;
                        }

                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());

                }
                finally
                {
                    //关闭流，关闭连接
                    objStreamWriter.Close();
                    objFileStream.Close();
                    _Conn.Close();
                    
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        ///将依赖的物理表写入文件
        /// </summary>
        /// <returns>用户取消写入文件返回false，否则返回true</returns>
        private bool WriteTableListToFile()
        {
            FileStream objFileStream = null;
            StreamWriter objStreamWriter = null;
            //设置保存文件弹框
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存脚本文件";
            kk.Filter = "SQL文件(*.sql)|*.sql|所有文件(*.*)|*.*";
            kk.FilterIndex = 1;
            //若选择文件保存地址成功
            if (kk.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //初始化写文件的流
                string FileName = kk.FileName;//+ ".xls";
                if (File.Exists(FileName))
                    File.Delete(FileName);
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.UTF8);
                try
                {
                    //如果用户选择导出部分对象，将用户选择的对象写入文件
                    if (_IsChooseAll == false)
                    {
                        objStreamWriter.WriteLine("--" + this.DbOwner + "下的非物理表对象:");
                       
                        foreach (DBObject temp in this._Dbolvm.DbObjects)
                        {
                            if (temp.IsSelected == true)
                            {
                                objStreamWriter.WriteLine("--" + temp.Name + "（Type: " + temp.Type + " Owner: " + temp.Owner + "）");
                                
                            }
                        }
                        objStreamWriter.WriteLine("--所依赖的物理表对象：");
                        
                    }
                    //如果用户选择导出所有对象
                    else
                    
                        objStreamWriter.WriteLine("--" + this.DbOwner + "下的所有的非物理表对象所依赖的物理表对象:");
                        

                    objStreamWriter.WriteLine("--用户名.表名");
                   
                    //将物理表对象循环写入
                    foreach (DBObject temp in this._Dbolvm.Tables)
                    {
                       
                        objStreamWriter.WriteLine(temp.Owner + "." + temp.Name);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());

                }
                finally
                {
                    objStreamWriter.Close();
                    objFileStream.Close();
                    System.Windows.MessageBox.Show("依赖的物理表对象列表写入完毕！");
                }
                return true;
            }
            else
                return false;
        }
         
    }

}
