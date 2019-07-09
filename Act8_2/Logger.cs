using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Act8_2
{
    class Logger
    {   
        //This will write log info into a txt file
        public static string LogWrite(string logPath, string logInfo)
        {
            try
            {
                FileStream fileStream = new FileStream(logPath, FileMode.Open, FileAccess.Write);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                fileStream.Seek(0, SeekOrigin.End);
                streamWriter.WriteLine(DateTime.Now);
                streamWriter.WriteLine(logInfo);
                streamWriter.WriteLine();
                streamWriter.Close();
                return "Info Logged";
            }
            catch (FileNotFoundException exc)
            {
                return exc.Message;
            }
            catch (IOException exc)
            {
                return exc.Message;
            }
            catch
            {
                return "Logging Failed";
            }
        }
        //This will read log info from txt file
        public static string LogRead(string filePath)
        {
        StreamReader streamReader;
        string fileText;

           try
           {
                 streamReader = File.OpenText(filePath); //Load file into stream reader
                  fileText = streamReader.ReadToEnd(); // read the file into string variable
                 streamReader.Close(); //Close the stream reader
                 Thread.Sleep(5000); //Simulate slow network connection
                    return fileText;
           }
           catch(FileNotFoundException exc)
           {
                return exc.Message;
           }
            catch(IOException exc)
            {
                return exc.Message;
            }
            catch
            {
                return "Logging Failed";
            }
        }
        
    }
}
