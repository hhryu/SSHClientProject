using MainProject.UI;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Models
{
    public class Client
    {
        public SshClient SshClient { get; set; }
        public SftpClient SftpClient { get; set; }
        public TabButton TabHeader { get; set; }
        public MyRichTextBox Console { get; set; }
        public string IP => this.SshClient.ConnectionInfo.Host;
        public string UserName => this.SshClient.ConnectionInfo.Username;

        public string ID { get; set; }

        public override string ToString()
        {
            return this.IP;
        }
    }
}
