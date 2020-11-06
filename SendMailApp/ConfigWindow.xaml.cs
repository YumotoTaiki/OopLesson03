using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMailApp {
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window {
        public ConfigWindow() {
            InitializeComponent();
        }

        private void btDefault_Click(object sender, RoutedEventArgs e) {
            Config cf = (Config.GetInstance()).getDefaultStatus();
            //Config defaultDate = cf.getDefaultStatus();

            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
        }

        //適用(更新)
        private void btApply_Click(object sender, RoutedEventArgs e) {
            (Config.GetInstance()).UpdateSatus(tbSmtp.Text,tbUserName.Text,
                tbPassWord.Password,int.Parse(tbPort.Text),cbSsl.IsChecked ?? false); //更新処理を呼び出す
        }
    }
}
