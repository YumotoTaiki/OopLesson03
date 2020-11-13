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
            Config defaultDate = cf.getDefaultStatus();

            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
        }

        //適用(更新)
        private void btApply_Click(object sender, RoutedEventArgs e) {
            if (tbSmtp.Text != "" && tbPort.Text != "" && tbUserName.Text != "" && tbPassWord.Password != "" && tbSender.Text != "") {
                (Config.GetInstance()).UpdateSatus(
                tbSmtp.Text,
                tbUserName.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false); //更新処理を呼び出す
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            } else {
                MessageBox.Show("入力されていない項目があります。", "エラー");
            }
        }

        private void Window_Closed(object sender, EventArgs f) {
            try {
                Config.GetInstance().Serialise();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //OKボタン
        private void btOK_Click(object sender, RoutedEventArgs e) {
            btApply_Click(sender, e); //更新処理を呼び出す
        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            var str = MessageBox.Show("変更は保存されませんが戻りますか?",
                "タイトル",
                MessageBoxButton.OKCancel);
            if (str == MessageBoxResult.OK) {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        //ロード時に一度だけ呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Config ctf = Config.GetInstance();
            tbSmtp.Text = ctf.Smtp;
            tbPort.Text = ctf.Port.ToString();
            tbUserName.Text = ctf.MailAddress;
            tbPassWord.Password = ctf.PassWord;
            tbSender.Text = ctf.MailAddress;
            cbSsl.IsChecked = ctf.Ssl;
            //Config.GetInstance().DeSerialise();
        }

        private void TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void PasswordChanged(object sender, RoutedEventArgs e) {

        }
    }
}
