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
        string line;
        object lockObj = new object();
        object lockObjTwo = new object();
        public LogRepository()
        {
            listOfLogs = ReadFile();

            //new Thread(() => UpdateLogList()).Start();
        }

        public string[] SeperateString(string input)
        {
            return input.Split('\t');
        }

        public void UpdateLogList()
        {
            bool running = true;
            
            while (running)
            {
                int oldListCount = listOfLogs.Count;

                listOfNewLogs = ReadFile();
                
                listOfNewLogs.Add(AddNewLines());

                if (listOfNewLogs.Count > listOfLogs.Count)
                {
                    lock (lockObj)
                    {
                        try
                        {
                            for (int i = oldListCount; i < listOfNewLogs.Count; i++)
                            {
                                listOfLogs.Add(listOfNewLogs[i]);
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                }
                Thread.Sleep(5000);
            }
        }

        public List<Log> FindLogByName(string nameToFind)
        {
            return listOfLogs.FindAll(x => x.Name == nameToFind);
        }

        public List<Log> FindLogById(string idToFind)
        {
            return listOfLogs.FindAll(x => x.Id == idToFind);
        }

        public List<Log> GetFullList()
        {
            return listOfLogs;
        }

        public Log AddNewLines()
        {
            string[] ss = new string[8] {"20:20:20", "101010", "alert", "name", "department", "resident", "", "registered" };
            return new Log(ss);
        }

        public List<Log> ReadFile()
        {
            lock (lockObjTwo)
            {
                List<Log> output = new List<Log>();
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Søren\Source\Repos\ProjectWebServiceApi\ProjectWebServiceApi\DAL\logfil.txt");
                file.ReadLine();

                while ((line = file.ReadLine()) != null)
                {
                    string[] dataSeperated = SeperateString(line);
                    output.Add(new Log(dataSeperated));
                }
                file.Close();

                return output;
            }

        }
    }
}