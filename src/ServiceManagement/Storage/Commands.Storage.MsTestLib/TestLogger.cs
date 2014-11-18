// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace MS.Test.Common.MsTestLib
{
    /// <summary>
    /// the wrapper for the loggers
    /// </summary>
    public class TestLogger
    {
        public List<ILogger> Loggers;

        public TestLogger()
        {
            Loggers = new List<ILogger>();

        }

        public TestLogger(TestConfig testConfig)
        {
            Loggers = new List<ILogger>();
            Init(testConfig);
        }

        public bool LogVerbose = false;
        public bool LogInfo = true;
        public bool LogWarning = false;
        public bool LogError = true;

        public void Init(TestConfig testConfig)
        {
            bool consoleLogger = false;
            bool fileLogger = true;
            bool.TryParse(testConfig.TestParams["consolelogger"], out consoleLogger);
            bool.TryParse(testConfig.TestParams["filelogger"], out fileLogger);

            string logfilePrefix =testConfig.TestParams["logfilename"];

            if (consoleLogger)
            {
                Loggers.Add(new ConsoleLogger());
            }
            if (fileLogger)
            {
                string fileNameString = logfilePrefix + Environment.UserName + "_" + Environment.MachineName + " " + DateTime.Now.ToString().Replace('/', '-').Replace(':', '_') + ".txt";
                Loggers.Add(new FileLogger(fileNameString));
                
            }


            bool.TryParse(testConfig.TestParams["loginfo"], out LogInfo);
            bool.TryParse(testConfig.TestParams["logverbose"], out LogVerbose);
            bool.TryParse(testConfig.TestParams["logerror"], out LogError);
            bool.TryParse(testConfig.TestParams["logwarning"], out LogWarning);


        }

        public void Error(
            string msg,
            params object[] objToLog)
        {
            foreach (ILogger logger in Loggers)
            {
                if (LogError)
                {
                    logger.WriteError(msg, objToLog);
                }
            }
        }


        public void Info(
            string msg,
            params object[] objToLog)
        {
            foreach (ILogger logger in Loggers)
            {
                if (LogInfo)
                {
                    logger.WriteInfo(msg, objToLog);
                }
            }
        }


        public void Warning(
            string msg,
            params object[] objToLog)
        {
            foreach (ILogger logger in Loggers)
            {
                if (LogWarning)
                {
                    logger.WriteWarning(msg, objToLog);
                }
            }
        }


        public void Verbose(
            string msg,
            params object[] objToLog)
        {
            foreach (ILogger logger in Loggers)
            {
                if (LogVerbose)
                {
                    logger.WriteVerbose(msg, objToLog);
                }
            }
        }


        public void StartTest(string testId)
        {
            foreach (ILogger logger in Loggers)
            {
                logger.StartTest(testId);
            }

        }

        public void EndTest(string testId, TestResult testResult)
        {
            foreach (ILogger logger in Loggers)
            {
                logger.EndTest(testId, testResult);
            }

        }

        public void Close()
        {
            foreach (ILogger logger in Loggers)
            {
                logger.Close();
            }  
        }


    }
}
