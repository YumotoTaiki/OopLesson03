using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendMailApp {
    class Config {
        public string Smtp { get; set; }
        public string MailAddress { get; set; }
        public string PassWord { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }

        public void DefaultSet() {
            Smtp = "smtp.gmail.com";
            MailAddress = "ojsinfosys01@gmail.com";
            PassWord = "ojsInfosys2020";
            Port = 587;
            Ssl = true;
        }
    }
}
