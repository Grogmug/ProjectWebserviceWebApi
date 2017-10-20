using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using ProjectWebServiceWebApi.Models;
using System.IO;

namespace ProjectWebServiceWebApi.DAL
{
    public class LogRepository
    {
        public List<Log> listOfLogs;
        public List<Log> listOfNewLogs;
        object lockObj = new object();
        //object lockObjTwo = new object();
        string line;
        public LogRepository()
        {
            listOfLogs = ReadFile();
            new Thread(() => UpdateLogList()).Start();
        }

        public string[] SeperateString(string input)
        {
            return input.Split('\t');
        }

        public void UpdateLogList()
        {
            
            while (true)
            {
                lock (lockObj)
                {
                    listOfNewLogs = ReadFile();

                    for (int i = 0; i < listOfNewLogs.Count - listOfLogs.Count; i++)
                    {
                        listOfLogs.Add(listOfNewLogs[i + 1]);
                    }
                    Thread.Sleep(5000);
                }

            }
        }

        public List<Log> FindLogByName(string nameToFind)
        {
            //UpdateLogList();
            return listOfLogs.FindAll(x => x.Name == nameToFind);
        }

        public List<Log> FindLogById(string idToFind)
        {
            //UpdateLogList();
            return listOfLogs.FindAll(x => x.Id == idToFind);
        }

        public List<Log> GetFullList()
        {
            //UpdateLogList();
            return listOfLogs;
        }

        //public Log AddNewLines()
        //{
        //    string[] ss = new string[8] { "20:20:20", "101010", "alert", "name", "department", "resident", "", "registered" };
        //    return new Log(ss);
        //}

        public List<Log> ReadFile()
        {
            List<Log> output = new List<Log>();
            string fileSource = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/logfil.txt";
            string target = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/logfil_kopi.txt";
            File.Copy(fileSource, target);

            System.IO.StreamReader fileKopi = new System.IO.StreamReader(target);

            while ((line = fileKopi.ReadLine()) != null)
            {
                string[] dataSeperated = SeperateString(line);
                output.Add(new Log(dataSeperated));
            }
            fileKopi.Close();
            File.Delete(target);
            return output;
        }
    }
}