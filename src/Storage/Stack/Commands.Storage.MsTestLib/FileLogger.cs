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
using System.Text;

namespace MS.Test.Common.MsTestLib
{
    public class FileLogger : ILogger
    {

        private System.IO.StreamWriter m_file;

        /// 
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <exception cref="System.IO.IOException" />
        /// 
        public FileLogger()
        {
            string fileName = Environment.UserName + "_" + Environment.MachineName + " " + DateTime.Now.ToString().Replace('/', '-').Replace(':', '_') + ".txt";
            m_file = new System.IO.StreamWriter(fileName.ToString(), true);
        }

        /// 
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <exception cref="System.IO.IOException" />
        /// <param name="fileName">File to which logs should be appended</param>
        /// 
        public FileLogger(string fileName)
            : this(fileName, true)
        {

        }

        /// 
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <exception cref="System.IO.IOException" />
        /// <param name="fileName">File to which logs should be written/appended</param>
        /// <param name="append">denotes whether the file is to be appended or over-written</param>
        /// 
        public FileLogger(string fileName, bool append)
        {
            // Open the file and assign to member variable
            m_file = new System.IO.StreamWriter(fileName, append);
        }

        /// 
        /// <summary>
        /// Writes an error log
        /// </summary>
        /// <param name="msg">Format message string</param>
        /// <param name="exp">exception object</param>
        /// <param name="objToLog">Objects that need to be serialized in the message</param>
        /// 
        public void WriteError(
            string msg,
            params object[] objToLog)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sBuilder = new StringBuilder("[ERROR][" + dt.ToLongTimeString() + "." + dt.Millisecond + "]");
            sBuilder.Append(MessageBuilder.FormatString(msg, objToLog));
            m_file.WriteLine(sBuilder.ToString());
            m_file.Flush();
        }

        /// 
        /// <summary>
        /// Writes a warn log
        /// </summary>
        /// <param name="msg">Format message string</param>
        /// <param name="objToLog">Objects that need to be serialized in the message</param>
        /// 
        public void WriteWarning(
            string msg,
            params object[] objToLog)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sBuilder = new StringBuilder("[WARN][" + dt.ToLongTimeString() + "." + dt.Millisecond + "]");
            sBuilder.Append(MessageBuilder.FormatString(msg, objToLog));
            m_file.WriteLine(sBuilder.ToString());
            m_file.Flush();
        }

        /// 
        /// <summary>
        /// Writes an info log
        /// </summary>
        /// <param name="msg">Format message string</param>
        /// <param name="objToLog">Objects that need to be serialized in the message</param>
        /// 
        public void WriteInfo(
            string msg,
            params object[] objToLog)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sBuilder = new StringBuilder("[INFO][" + dt.ToLongTimeString() + "." + dt.Millisecond + "]");
            sBuilder.Append(MessageBuilder.FormatString(msg, objToLog));
            m_file.WriteLine(sBuilder.ToString());
            m_file.Flush();
        }

        /// 
        /// <summary>
        /// Writes a verbose log
        /// </summary>
        /// <param name="msg">Format message string</param>
        /// <param name="objToLog">Objects that need to be serialized in the message</param>
        /// 
        public void WriteVerbose(
            string msg,
            params object[] objToLog)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sBuilder = new StringBuilder("[VERB][" + dt.ToLongTimeString() + "." + dt.Millisecond + "]");
            sBuilder.Append(MessageBuilder.FormatString(msg, objToLog));
            m_file.WriteLine(sBuilder.ToString());
            m_file.Flush();
        }


        /// 
        /// <summary>
        /// Starts a test (as a child of the current context)
        /// </summary>
        /// <param name="testId">Test id</param>
        ///         
        public void StartTest(
            string testId)
        {
            StringBuilder sBuilder = new StringBuilder("[START] Test: ");
            sBuilder.Append(testId);
            m_file.WriteLine(sBuilder.ToString());
            m_file.Flush();
        }

        /// 
        /// <summary>
        /// Ends the specified test with the specified test result
        /// </summary>
        /// <param name="testId">Test id</param>
        /// <param name="result">Result of the Test</param>
        /// 
        public void EndTest(
            string testId,
            TestResult result)
        {
            StringBuilder sBuilder = new StringBuilder("[END] Test: ");
            sBuilder.Append(testId);
            sBuilder.Append(" RESULT: ");
            sBuilder.Append(result.ToString());
            m_file.WriteLine(sBuilder.ToString());
            m_file.Flush();
            return;
        }

        
        /// 
        /// <summary>
        /// Returns "this" object
        /// </summary>
        /// <returns>SimpleFileLogger object</returns>
        /// 
        public object GetLogger()
        {
            return this;
        }

        /// 
        /// <summary>
        /// Closes the log file
        /// </summary>
        /// 
        public void Close()
        {
            if (m_file != null)
            {
                m_file.Flush();
                m_file.Close();
            }
        }
    }
}
