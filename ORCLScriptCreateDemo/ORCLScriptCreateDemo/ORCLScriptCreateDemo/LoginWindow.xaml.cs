// 名称： LoginWindow

// 描述： LoginWindow.xaml 的交互逻辑

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
using System.Windows.Shapes;
using Oracle.DataAccess.Client;
using System.Net;
using System.Net.Sockets;

namespace ORCLScriptCreateDemo
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            _init();
        }

       private String _DbInfo;
       
        //判断用户是否登录成功
        private bool ConectOralce()
        {

            //数据库连接字符串
            _DbInfo = "Data Source=" + this.tb_server.Text + ";"
            + "User ID=" + this.tb_userid.Text + ";"
            + "password=" + this.tb_pass.Password + ";";

           OracleConnection myConnection = new OracleConnection(_DbInfo);
            try
            {
                //打开数据库连接
                myConnection.Open();

                return true;
            }
            catch (Exception ex)
            {
                
               System.Windows.MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                myConnection.Close();
                
            }
        }

        //设置登录框居中
        public void _init()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }



        private void login_Click(object sender, RoutedEventArgs e)
        {
            //用户ID、密码和主机不能为空
            if (this.tb_userid.Text.Equals("") || this.tb_server.Text.Equals("") || this.tb_pass.Password.Equals(""))
            {
                MessageBox.Show("用户ID、密码和主机不为空！");
                return;
            }
            if (ConectOralce())
            {
                //登录成功，打开主窗口
                MessageBox.Show("登录成功");
                Window main = new MainWindow(_DbInfo);
                this.Close();
                main.Show();
            }
            else
                MessageBox.Show("登录失败");
        }

        //设置鼠标移到登录按钮的样式
        private void btn_login_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn_login = (Button)sender;
            Label lb1 = (Label)btn_login.Template.FindName("tips_for_login", btn_login);
            lb1.Foreground = new SolidColorBrush(Colors.Red);

        }
        //设置鼠标移出登录按钮的样式
        private void btn_login_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn_login = (Button)sender;
            Label lb1 = (Label)btn_login.Template.FindName("tips_for_login", btn_login);
            lb1.Foreground = new SolidColorBrush(Colors.White);

        }
    }
}
