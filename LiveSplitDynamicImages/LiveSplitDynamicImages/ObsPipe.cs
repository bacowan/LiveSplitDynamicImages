using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiveSplitDynamicImages
{
    public class ObsPipe
    {
        private readonly static string[] stringSeperators = new string[] { "\n" };

        private Thread serverThread;
        private NamedPipeServerStream pipeServer;

        public ObsPipe()
        {
            newServer();
        }

        ~ObsPipe()
        {
            pipeServer.Close();
        }

        private void newServer()
        {
            serverThread = new Thread(serverStartThread);
            serverThread.Start();
        }

        private void serverStartThread()
        {
            NamedPipeServerStream tempPipeServer = new NamedPipeServerStream(Constants.PIPE_NAME, PipeDirection.InOut);
            tempPipeServer.WaitForConnection();
            pipeServer = tempPipeServer;
        }

        public void changeImageFile(String newImageFilePath)
        {
            writeToPipe(WriteToken.CHANGE_IMAGE_FILE, newImageFilePath);
        }

        public void requestGlobalImageSources(StringListCallback callback)
        {
            Thread thread = new Thread(() => requestResponseThread(WriteToken.REQUEST_GLOBAL_IMAGE_SOURCES, "", callback));
            thread.Start();
        }

        private void requestResponseThread(WriteToken token, String str, StringListCallback callback)
        {
            writeToPipe(token, str);
            String response = waitForResponse();
            List<String> formattedResponse = formatResponse(response);
            callback(formattedResponse);
        }

        private void writeToPipe(WriteToken token, String str)
        {
            byte[] stringBytes = Encoding.Unicode.GetBytes(str);
            byte[] sendBytes = new byte[stringBytes.Length + 3];
            sendBytes[0] = (byte)token;
            Array.Copy(stringBytes, 0, sendBytes, 1, stringBytes.Length);
            sendBytes[sendBytes.Length - 1] = 0;
            sendBytes[sendBytes.Length - 2] = 0; // end with a null terminator
            if (pipeServer != null)
                pipeServer.Write(sendBytes, 0, sendBytes.Length);
        }

        private List<String> formatResponse(String str)
        {
            List<String> ret = str.Split(stringSeperators, StringSplitOptions.RemoveEmptyEntries).ToList<String>();
            ret.RemoveAt(ret.Count - 1);
            return ret;
        }

        private String waitForResponse()
        {
            //pipeServer.WaitForPipeDrain();
            byte[] sizeBuffer = new byte[4];
            pipeServer.Read(sizeBuffer, 0, 4);
            int length = BitConverter.ToInt32(sizeBuffer, 0); // first 4 bytes is the length of the data
            byte[] inBuffer = new byte[length];
            pipeServer.Read(inBuffer, 0, length);
            return System.Text.Encoding.Unicode.GetString(inBuffer);
        }
    }
}
