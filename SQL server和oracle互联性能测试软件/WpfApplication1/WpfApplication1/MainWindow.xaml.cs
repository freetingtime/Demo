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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;

namespace WpfApplication1
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

        private void ToOracle()
        {
            this.testResult.AppendText("\n连接ORACLE\n");
            String oConnectionString = "Provider=MSDAORA;Data Source=ORCL;Persist Security Info=True;User ID=scott;password=guo;";
            Stopwatch sw1 = new Stopwatch();
            String sql = "";
            OleDbConnection myConnection = new OleDbConnection(oConnectionString);
            OleDbCommand myCommand = myConnection.CreateCommand();
            double[] oseconds = new double[3] { 0, 0, 0 };
            OleDbDataReader myReader=null;
            try
            {
                myConnection.Open();
                
                for (int count = 1; count < 6; count++)
                {
                    this.testResult.AppendText("第" + count + "次执行\n");
                   
                    for (int i = 3; i < 6; i++)
                    {
                        sql = "Select 1 from dual connect by rownum<" + Math.Pow(10, i);
                        myCommand.CommandText = sql;
                        myCommand.Connection = myConnection;
                        myReader = myCommand.ExecuteReader();

                        sw1.Start();

                        while (myReader.Read())
                        {
                            myReader.GetValue(0);

                        }
                        sw1.Stop();
                        this.testResult.AppendText("ORACLE-执行" + Math.Pow(10, i) + "条sql语句共花" + sw1.Elapsed.TotalMilliseconds + "毫秒\n");
                        oseconds[i - 3] = oseconds[i - 3] + sw1.Elapsed.TotalMilliseconds;
                        sw1.Reset();
                        myReader.Close();
                       
                    }
                }
                this.testResult.AppendText("\n");
                for (int i = 3; i < 6; i++)
                {
                    this.testResult.AppendText("ORACLE执行" + Math.Pow(10, i) + "条sql语句平均花" + oseconds[i - 3] / 5 + "毫秒\n");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                myConnection.Close();
             
            }
        }

        private void ToSQLSERVER()
        {
            this.testResult2.AppendText("\n连接SQLSERVER\n");
            this.testResult.AppendText("\n连接SQLSERVER\n");
            String ConnectionString = "Server=GUO-PC;Integrated Security=SSPI;database=viki";
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            Stopwatch sw1 = new Stopwatch();
            String sql = "";
            SqlCommand myCommand = myConnection.CreateCommand();
            double[] oseconds = new double[3] { 0, 0, 0 };
            SqlDataReader myReader = null;
            try
            {
                myConnection.Open();
                //PrepareData(myConnection);
                for (int count = 1; count < 6; count++)
                {
                    this.testResult.AppendText("第" + count + "次执行\n");
                    this.testResult2.AppendText("第" + count + "次执行\n");
                    for (int i = 3; i < 6; i++)
                    {
                        //sql = "select top(" + Math.Pow(10, i) + ") 1 from fortest";
                        sql = "select 1 from fortest where id<" + Math.Pow(10, i);
                        myCommand.CommandText = sql;
                        myCommand.Connection = myConnection;
                        myReader = myCommand.ExecuteReader();

                        sw1.Start();

                        while (myReader.Read())
                        {
                            myReader.GetValue(0);

                        }
                        sw1.Stop();
                        this.testResult.AppendText("SQLSERVER-执行" + Math.Pow(10, i) + "条sql语句共花" + sw1.Elapsed.TotalMilliseconds + "毫秒\n");
                        this.testResult2.AppendText("SQLSERVER-执行" + Math.Pow(10, i) + "条sql语句共花" + sw1.Elapsed.TotalMilliseconds + "毫秒\n");
                        
                        oseconds[i - 3] = oseconds[i - 3] + sw1.Elapsed.TotalMilliseconds;
                        sw1.Reset();
                        myReader.Close();
                        
                    }
                }
                this.testResult.AppendText("\n");
                this.testResult2.AppendText("\n");
                for (int i = 3; i < 6; i++)
                {
                    this.testResult.AppendText("SQLSERVER-执行" + Math.Pow(10, i) + "条sql语句平均花" + oseconds[i - 3] / 5 + "毫秒\n");
                    this.testResult2.AppendText("SQLSERVER-执行" + Math.Pow(10, i) + "条sql语句共花" + oseconds[i - 3] / 5 + "毫秒\n");
                        
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                myConnection.Close();

            }
        }
        private void ConnectSSToOracle()
        {
            this.testResult2.AppendText("\nSQLSERVER中连接ORACLE\n");
            String ConnectionString = "Server=GUO-PC;Integrated Security=SSPI;database=viki";
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            Stopwatch sw1 = new Stopwatch();
            String sql = "";
            SqlCommand myCommand = myConnection.CreateCommand();
            double[] oseconds = new double[3] { 0, 0, 0 };
            SqlDataReader myReader = null;
            try
            {
                myConnection.Open();
                
                for (int count = 1; count < 6; count++)
                {
                    this.testResult2.AppendText("第" + count + "次执行\n");

                    for (int i = 3; i < 6; i++)
                    {
                        sql = "SELECT * FROM OPENQUERY(OraclePolice,'Select 1 from dual connect by rownum<" + Math.Pow(10, i) + "');";
                        //this.testResult2.AppendText("\n"+sql);
                        myCommand.CommandText = sql;
                        myCommand.Connection = myConnection;
                        myReader = myCommand.ExecuteReader();

                        sw1.Start();

                        while (myReader.Read())
                        {
                            myReader.GetValue(0);

                        }
                        sw1.Stop();
                        this.testResult2.AppendText("SQLSERVER中连接ORACLE-执行" + Math.Pow(10, i) + "条sql语句共花" + sw1.Elapsed.TotalMilliseconds + "毫秒\n");
                        oseconds[i - 3] = oseconds[i - 3] + sw1.Elapsed.TotalMilliseconds;
                        sw1.Reset();
                        myReader.Close();
                       
                    }
                }
                this.testResult2.AppendText("\n");
                for (int i = 3; i < 6; i++)
                    this.testResult2.AppendText("SQLSERVER中连接ORACLE-执行" + Math.Pow(10, i) + "条sql语句平均花" + oseconds[i - 3] / 5 + "毫秒\n");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            finally
            {
                myConnection.Close();

            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.testResult2.Text = "开始测试" + "\n";
            this.testResult.Text = "开始测试" + "\n";
            ToOracle();
            ConnectSSToOracle();
            ToSQLSERVER();
           
           
        }
        private void PrepareData(SqlConnection myConnection)
        {
            String sql =// "drop table fortest;" +
                "create table fortest([id] int);" +
                "declare @num int " +
                "set @num=0 " +
                "while @num<100000" +
                "begin " +
                "insert into fortest values(@num);" +
                "set @num=@num+1 " +
                "end";

            SqlCommand myCommand = new SqlCommand(sql, myConnection);
            try
            {
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }


        }
    }
}
