using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        SmtpClient sc = new SmtpClient();

        public MainWindow() {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        //送信完了イベント
        private void Sc_SendCompleted(object sender, AsyncCompletedEventArgs e) {
            if (e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました");
            } else {
                MessageBox.Show( e.Error?.Message ?? "送信完了!");
            }
        }

        //メール送信処理
        private void btOk_Click(object sender, RoutedEventArgs e) {
            try {
                MailMessage msg = new MailMessage("ojsinfosys01@gmail.com", tbTo.Text);
                if (tbCc.Text != "") {
                    msg.CC.Add(tbCc.Text);
                }
                if (tbBcc.Text != "") {
                    msg.Bcc.Add(tbCc.Text);
                }

                msg.Subject = tbTitle.Text;//件名
                msg.Body = tbBody.Text;//本文

                sc.Host = "smtp.gmail.com";//SMTPサーバーの設定
                sc.Port = 587;
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("ojsinfosys01@gmail.com", "ojsInfosys2020");

                sc.Send(msg);
                sc.SendMailAsync(msg);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //メールキャンセル処理
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            sc.SendAsyncCancel();
        }

        //設定ボタンイベントハンドラ
        private void btConfig_Click(object sender, RoutedEventArgs e) {
            ConfigWindowShow();
        }

        //設定画面表示
        private static void ConfigWindowShow() {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.Show();
        }

        //メインウィンドウが表示されるタイミングで呼び出される
        public void Window_Loaded(object sender, RoutedEventArgs e) {
            try {
                Config.GetInstance().DeSerialise(); //逆シリアル化　XML→オブジェクト
                Config ctf = Config.GetInstance();
                tbTo.Text = ctf.MailAddress;
            } catch (FileNotFoundException){
                ConfigWindowShow();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            if (tbTo.Text == "") {
                ConfigWindowShow();
                this.Close();
            }
        }

        private void Window_Closed(object sender, RoutedEventArgs e) {
            try {
                Config.GetInstance().Serialise(); //シリアル化　オブジェクト→XML
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //設定データ更新
        public bool UpdateStatus(Config cf) {
            return true;
        }
    }
}
