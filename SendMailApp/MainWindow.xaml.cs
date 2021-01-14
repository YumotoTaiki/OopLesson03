using Microsoft.Win32;
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
        public System.Net.Mail.MailAddressCollection CC { get; }
        public System.Net.Mail.MailAddressCollection Bcc { get; }

        public MainWindow() {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        //メインウィンドウが表示されるタイミングで呼び出される
        public void Window_Loaded(object sender, RoutedEventArgs e) {
            try {
                Config.GetInstance().DeSerialise(); //逆シリアル化　XML→オブジェクト
            } catch (FileNotFoundException) {
                ConfigWindowShow();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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
                Config ctf = Config.GetInstance();
                MailMessage msg = new MailMessage(ctf.MailAddress, tbTo.Text);

                if (tbCc.Text != "") {
                    msg.CC.Add(tbCc.Text);

                } else if (tbBcc.Text != "") {
                    msg.Bcc.Add(tbBcc.Text);
                }

                msg.Subject = tbTitle.Text;//件名
                msg.Body = tbBody.Text;//本文
                try {
                    foreach (var item in LbAttach.Items) {
                        msg.Attachments.Add(new Attachment(item.ToString())); ;
                    }
                } catch (Exception ex) {

                    MessageBox.Show(ex.Message);
                }


                sc.Host = ctf.Smtp;//SMTPサーバの設定
                sc.Port = ctf.Port;
                sc.EnableSsl = ctf.Ssl;
                sc.Credentials = new NetworkCredential(ctf.MailAddress, ctf.PassWord);

                //sc.Send(msg);//送信
                sc.SendMailAsync(msg);//送信

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
            configWindow.ShowDialog();
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

        private void btAddDate_Click(object sender, RoutedEventArgs e) {

            // ダイアログのインスタンスを生成
            var dialog = new OpenFileDialog();

            // ファイルの種類を設定
            dialog.Filter = "全てのファイル (*.*)|*.*";

            // ダイアログを表示する
            if (dialog.ShowDialog() == true) {
                LbAttach.Items.Add(dialog.FileName);

                // 選択されたファイル名 (ファイルパス) をメッセージボックスに表示
                //MessageBox.Show(dialog.FileName);
            }
        }

        //削除ボタン
        private void btErase_Click(object sender, RoutedEventArgs e) {
            if (LbAttach.SelectedItems.Count == 0) {
                MessageBox.Show("削除する項目を選択してください。");
            } else {
                LbAttach.Items.RemoveAt(LbAttach.SelectedIndex);
            }
        }
    }
}
