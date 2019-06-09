using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RecordTest
{
    class MessageCommunicate
    {

        /// <summary>  
        /// System defined message  
        /// </summary>  
        private const int WM_COPYDATA = 0x004A;


        // FindWindow method, using Windows API  
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        // IsWindow method, using Windows API  
        [DllImport("User32.dll", EntryPoint = "IsWindow")]
        private static extern bool IsWindow(int hWnd);

        // SendMessage method, using Windows API  
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
            int hWnd,                   // handle to destination window  
            int Msg,                    // message  
            int wParam,                 // first message parameter  
            ref COPYDATASTRUCT lParam   // second message parameter  
        );

        // SendMessage method, using Windows API  
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
            int hWnd,                   // handle to destination window  
            int Msg,                    // message  
            int wParam,                 // first message parameter  
            string lParam               // second message parameter  
        );

        /// <summary>  
        /// CopyDataStruct  
        /// </summary>  
        private struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }

        /// <summary>  
        /// Send message to target window  
        /// </summary>  
        /// <param name="wndName">The window name which we want to found</param>  
        /// <param name="msg">The message to be sent, string</param>  
        /// <returns>success or not</returns>  
        public static bool SendMessageToTargetWindow(string wndName, string msg)
        {
            //MessageBox.Show(string.Format("SendMessageToTargetWindow: Send message to target window {0}: {1}", wndName, msg));

            int iHWnd = FindWindow(null, wndName);
            //MessageBox.Show(iHWnd.ToString());
            if (iHWnd == 0)
            {

                string strError = string.Format("请打开窗口", wndName);
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(strError);
                return false;


            }
            else
            {
                byte[] bytData = null;
                bytData = Encoding.Unicode.GetBytes(msg);

                COPYDATASTRUCT cdsBuffer;
                cdsBuffer.dwData = (IntPtr)100;
                cdsBuffer.cbData = bytData.Length;
                cdsBuffer.lpData = Marshal.AllocHGlobal(bytData.Length);
                Marshal.Copy(bytData, 0, cdsBuffer.lpData, bytData.Length);
                // MessageBox.Show(bytData.ToString());
                // Use system defined message WM_COPYDATA to send message.  
                int iReturn = SendMessage(iHWnd, WM_COPYDATA, 0, ref cdsBuffer);
                if (iReturn < 0)
                {
                    string strError = string.Format("发送数据未成功", wndName);
                    MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine(strError);
                    return false;
                }

                return true;
            }
        }

    }
}
