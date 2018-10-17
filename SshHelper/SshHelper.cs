using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH
{
    public static class SshHelper
    {
        /// <summary>
        /// 연결된 SshClient 인스턴트를 반환.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public static SshClient ConnectSSH(string ip, int port, string userName, string pw)
        {
            var connInfo = new ConnectionInfo(ip, port, userName, new AuthenticationMethod[] {
                    new PasswordAuthenticationMethod(userName, pw)
                });

            SshClient client = new SshClient(connInfo);

            try
            {
                client.Connect();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"SshHelper.Login(): {e.Message}");
            }

            return client;
        }

        /// <summary>
        /// 해당 Client에서 입력된 명령을 실행.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="cmd"></param>
        public static string ExcuteCommand(SshClient client, string cmd)
        {
            SshCommand sshCmd = null;
            StringBuilder result = new StringBuilder();
            {
                try
                {
                    sshCmd = client.CreateCommand(cmd);
                    sshCmd.Execute();

                    if (string.IsNullOrEmpty(sshCmd.Error))
                        result.Append(sshCmd.Result);
                    else
                    {
                        result.Append(sshCmd.Result);
                        result.Append(sshCmd.Error);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine($"SshHelper.ExcuteCommand(): {e.Message}");
                    result.Append(e.Message);

                    if (result.ToString() == "CommandText property is empty.")
                        result.Append("\n");
                }

                sshCmd?.Dispose();

                return result.ToString();
            }
        }

        public static SftpClient ConnectSFTP(string ip, int port, string userName, string pw)
        {
            var connInfo = new ConnectionInfo(ip, port, userName, new AuthenticationMethod[] {
                    new PasswordAuthenticationMethod(userName, pw)
                });

            SftpClient client = new SftpClient(connInfo);

            try
            {
                client.Connect();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"SshHelper.Login(): {e.Message}");
                return null;
            }

            return client;
        }

        public static string UploadFiles(SftpClient client, string fName)
        {
            string result = string.Empty;

            try
            {
                //using (var ofd = new OpenFileDialog())
                //{
                //    string fileName = string.Empty;
                //    if (ofd.ShowDialog() == DialogResult.OK)
                //    {
                //        fileName = ofd.FileName;
                //    }

                //    using (var fs = new FileStream(fileName, FileMode.Open))
                //    {
                //        client.BufferSize = 4 * 1024;
                //        client.UploadFile(fs, Path.GetFileName(fileName));
                //    }
                //}
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"SshHelper.ExcuteCommand(): {e.Message}");
                result = e.Message;
            }

            //client?.Dispose();
            return result;
        }
    }
}
