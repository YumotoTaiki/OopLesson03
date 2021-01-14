using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SendMailApp {
    public class Config {

        //単一のインスタンス
        private static Config instance;

        //インスタンスの取得
        public static Config GetInstance() {
            if (instance == null) {
                instance = new Config();
            }
            return instance;
        }

        public string Smtp { get; set; }
        public string MailAddress { get; set; }
        public string PassWord { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }

        //コンストラクタ(外部からnewできないようにする)
        private Config() {}

        //初期設定用
        public void DefaultSet() {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }

        //初期値設定用
        public Config getDefaultStatus() {
            Config obj = new Config {
                Smtp = "smtp.gmail.com",
                MailAddress = "ojsinfosys01@gmail.com",
                PassWord = "ojsInfosys2020",
                Port = 587,
                Ssl = true,
            };
            return obj;
        }

        //設定データ更新
        public bool UpdateStatus(string Smtp, string MailAddress, string PassWord, int Port, bool Ssl) {
            this.Smtp = Smtp;
            this.MailAddress = MailAddress;
            this.PassWord = PassWord;
            this.Port = Port;
            this.Ssl = Ssl;
            return true;
        }

        public void Serialise() { //シリアル化
            using (var writer = XmlWriter.Create("config.xml")) {
                var serializer = new XmlSerializer(instance.GetType());
                serializer.Serialize(writer, instance);
            }
        }

        public void DeSerialise() { //デシリアライズ
            using (var reader = XmlReader.Create("config.xml")) {
                var serializer = new XmlSerializer(typeof(Config));
                instance = serializer.Deserialize(reader) as Config;
            }
        }
    }
}
