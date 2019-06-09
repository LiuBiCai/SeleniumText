using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void startProcess(string arg)
        {
            Process process = new Process();
            process.StartInfo.FileName = "SeleniumText.exe";
            process.StartInfo.Arguments = arg;
            process.Start();
        }
        /// <summary>  
        /// System defined message  
        /// </summary>  
        private const int WM_COPYDATA = 0x004A;

        /// <summary>  
        /// CopyDataStruct  
        /// </summary>  
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                // Here, we use WM_COPYDATA message to receive the COPYDATASTRUCT  
                case WM_COPYDATA:
                    COPYDATASTRUCT cds = new COPYDATASTRUCT();
                    cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                    byte[] bytData = new byte[cds.cbData];
                    Marshal.Copy(cds.lpData, bytData, 0, bytData.Length);
                    this.ProcessIncomingData(bytData);
                    break;



                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }






        /// <summary>  
        /// Process the incoming data  
        /// </summary>  
        /// <param name="data">incoming data</param>  
        private void ProcessIncomingData(byte[] bytesData)
        {
            string str = BitConverter.ToString(bytesData);

            string msg = Encoding.Unicode.GetString(bytesData);
            Console.WriteLine(msg);
            string[] arg = msg.Split(':');
            string strRevMsg = arg[1];
            mutex.WaitOne();
            accounts.Where(m => m.email == arg[0]).First().statu = arg[1];
            mutex.ReleaseMutex();
            accountSave();
        }


        List<Account> accounts = new List<Account>();
        private void button1_Click(object sender, EventArgs e)
        {
            accounts.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string currentDirectory = Directory.GetCurrentDirectory();
            openFileDialog.InitialDirectory = currentDirectory;
            openFileDialog.Filter = "CSV files (*.csv|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.Default);
            int num = 0;
            string str;
            while ((str = streamReader.ReadLine()) != null)
            {
                if (num++ != 0)
                {
                    string[] strArray = str.Split(',');
                    try
                    {
                        this.accounts.Add(new Account()
                        {
                            name = strArray[0],
                            lastname = strArray[1],
                            email = strArray[2],
                            statu= strArray[3],
                        });
                    }
                    catch
                    {
                    }
                }
            }
            streamReader.Close();
        }
        private Mutex mutex = new Mutex();
        private void accountSave()
        {
            mutex.WaitOne();
            FileStream fileStream = new FileStream("账号.csv", FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter((Stream)fileStream);
           // streamWriter.WriteLine("ID,账号,账号密码,网页密码,密保,谷歌验证Key,金币,时间");
            foreach (var account in accounts)
                streamWriter.WriteLine(account.name+ "," + account.lastname + "," + account.email + "," + account.statu );
            streamWriter.Flush();
            streamWriter.Close();
            fileStream.Close();
            mutex.ReleaseMutex();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(run);
            thread.Start();
        }
        private void run()
        {
            foreach (var account in accounts)
            {
                if (account.statu == "Success")
                    continue;
              
                startProcess(account.GetArgs());
                Thread.Sleep(30000);
               // accountSave();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


    public class Account
    {
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string statu { get; set; }
        public string GetArgs()
        {
            return name.Replace(' ',',') + " " + lastname.Replace(' ', ',') + " " + email;
        }
    }
}
