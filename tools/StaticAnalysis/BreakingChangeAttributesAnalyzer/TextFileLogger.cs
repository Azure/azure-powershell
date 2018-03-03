using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysis.BreakingChangeAttributesAnalyzer
{
    //A text file log utility that maintians a map of log files (by name), this is thread safe
    //USers need to call "GetTextFileLogger" to get a logget and must call "CloseLogger" to close
    //the logger isntance
    //They can call "LogMessage" to log a mesage to the file.
    class TextFileLogger
    {
        class TextLoggerData
        {
            public TextFileLogger LoggerInstance { get; set; } = null;

            public int NumberOfReferences { get; set; } = 0;
        }

        public String LogFileName { get; protected set; }

        private FileStream file = null;

        //Hash table of the various loggers open at the time
        //this maintains a logger for each file that we open for logginng to
        private static Hashtable loggerTable = new Hashtable();

        //This object is used to log, this makes sure that when a log operation is hapening 
        //another thread can not write to the file stream at the same time
        private Object lockObjectForLogging = new object();

        //Private so that no one can create an instance
        private TextFileLogger()
        {
        }

        //Get an instance of a logger for a file name
        public static TextFileLogger GetTextFileLogger(String fileName, bool overriteExisting)
        {
            TextFileLogger loggerToReturn = null;
            lock (loggerTable)
            {
                if (loggerTable.ContainsKey(fileName))
                {
                    TextLoggerData data = (TextLoggerData)loggerTable[fileName];
                    data.NumberOfReferences += 1;
                    loggerToReturn = data.LoggerInstance;
                }
                else
                {
                    TextFileLogger logger = new TextFileLogger();
                    logger.LogFileName = fileName;
                    logger.init(overriteExisting);

                    TextLoggerData loggerData = new TextLoggerData();
                    loggerData.NumberOfReferences = 1;
                    loggerData.LoggerInstance = logger;
                    loggerToReturn = logger;

                    loggerTable.Add(fileName, logger);
                }
            }
            return loggerToReturn;
        }

        //Close the instance of the logger, make sure to call this otherwise we leak an instance
        public static void CloseLogger(String fileName)
        {
            lock (loggerTable)
            {
                if (loggerTable.ContainsKey(fileName))
                {
                    TextLoggerData data = (TextLoggerData)loggerTable[fileName];
                    data.NumberOfReferences -= 1;
                    if (data.NumberOfReferences == 0)
                    {
                        data.LoggerInstance.closeLog();
                        //remove references
                        data.LoggerInstance = null;
                        data = null;

                        //cleanup the entry form the table
                        loggerTable.Remove(fileName);
                    }
                }
            }
        }

        public void LogError(String message)
        {
            String messageToLog = "Error : " + message;
            LogMessage(messageToLog);
        }

        public void LogWarning(String message)
        {
            String messageToLog = "Warning : " + message;
            LogMessage(messageToLog);
        }

        public void LogInfo(String message)
        {
            String messageToLog = "Info : " + message;
            LogMessage(messageToLog);
        }

        public void LogDebug(String message)
        {
            String messageToLog = "Debug : " + message;
            LogMessage(messageToLog);
        }

        public void LogMessage(String message)
        {
            if (file != null)
            {
                //Make sure that two threads do not write to the file at the same time
                lock (lockObjectForLogging)
                {
                    using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                    {
                        writer.Write(message);
                    }
                }
            }
        }

        private void init(bool overriteExisting)
        {
            FileMode fMode = FileMode.Append;
            if (overriteExisting)
            {
                fMode = FileMode.CreateNew;
            }

            file = File.Open(LogFileName, fMode);
        }

        private void closeLog()
        {
            if (file != null)
            {
                file.Close();
                file = null;
            }
        }
    }
}
