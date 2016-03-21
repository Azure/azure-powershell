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
    public class ConsoleLogger : ILogger
    {

        private const ConsoleColor ERROR_FG_COLOR = ConsoleColor.Red;
        private const ConsoleColor INFO_FG_COLOR = ConsoleColor.White;
        private const ConsoleColor WARN_FG_COLOR = ConsoleColor.Green;
        private const ConsoleColor NOTE_FG_COLOR = ConsoleColor.DarkYellow;

        private ConsoleColor m_prevFGColor;

        public ConsoleLogger()
        {
            m_prevFGColor = Console.ForegroundColor;
        }

        /// 
        /// <summary>
        /// Writes an error log
        /// </summary>
        /// <param name="msg">Format message string</param>
        /// <param name="exp">exception object</param>
        /// <param name="objToLog">Objects that need to be serialized in the message</param>
        /// 
        public void WriteError(string msg, params object[] objToLog)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sBuilder = new StringBuilder("[ERROR][" + dt.ToLongTimeString() + "." + dt.Millisecond + "]");
            sBuilder.Append( MessageBuilder.FormatString( msg, objToLog ) );
            Console.ForegroundColor = ERROR_FG_COLOR;
            Console.WriteLine( sBuilder.ToString() );
            Console.ForegroundColor = m_prevFGColor;
        }

        /// 
        /// <summary>
        /// Writes a warn log
        /// </summary>
        /// <param name="msg">Format message string</param>
        /// <param name="objToLog">Objects that need to be serialized in the message</param>
        /// 
        public void WriteWarning(string msg, params object[] objToLog)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sBuilder = new StringBuilder("[WARN][" + dt.ToLongTimeString() + "." + dt.Millisecond + "]");
            sBuilder.Append( MessageBuilder.FormatString( msg, objToLog ) );
            Console.ForegroundColor = WARN_FG_COLOR;
            Console.WriteLine( sBuilder.ToString() );
            Console.ForegroundColor = m_prevFGColor;
        }

        /// 
        /// <summary>
        /// Writes an info log
        /// </summary>
        /// <param name="msg">Format message string</param>
        /// <param name="objToLog">Objects that need to be serialized in the message</param>
        /// 
        public void WriteInfo(string msg, params object[] objToLog)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sBuilder = new StringBuilder( "[INFO][" + dt.ToLongTimeString()+"."+ dt.Millisecond+ "]" );
            sBuilder.Append( MessageBuilder.FormatString( msg, objToLog) );
            Console.ForegroundColor = INFO_FG_COLOR;
            Console.WriteLine( sBuilder.ToString() );
            Console.ForegroundColor = m_prevFGColor;
        }

        /// 
        /// <summary>
        /// Writes a verbose log
        /// </summary>
        /// <param name="msg">Format message string</param>
        /// <param name="objToLog">Objects that need to be serialized in the message</param>
        /// 
        public void WriteVerbose(string msg, params object[] objToLog)
        {
            DateTime dt = DateTime.Now;
            StringBuilder sBuilder = new StringBuilder("[VERB][" + dt.ToLongTimeString() + "." + dt.Millisecond + "]");
            sBuilder.Append( MessageBuilder.FormatString( msg, objToLog) );
            Console.ForegroundColor = INFO_FG_COLOR;
            Console.WriteLine( sBuilder.ToString() );
            Console.ForegroundColor = m_prevFGColor;
        }


        /// 
        /// <summary>
        /// Starts a test (as a child of the current context)
        /// </summary>
        /// <param name="testId">Test id</param>
        ///         
        public void StartTest(string testId)
        {
            StringBuilder sBuilder = new StringBuilder("[START] Test: ");
            sBuilder.Append( testId );

            Console.ForegroundColor = NOTE_FG_COLOR;
            Console.WriteLine( sBuilder.ToString() );
            Console.ForegroundColor = m_prevFGColor;
        }

        /// 
        /// <summary>
        /// Ends the specified test with the specified test result.
        /// </summary>
        /// <param name="testId">Test id</param>
        /// <param name="result">Result of the Test</param>
        /// 
        public void EndTest(string testId, TestResult result )
        {
            Console.ForegroundColor = NOTE_FG_COLOR;

            if (result == TestResult.FAIL)
            {
                Console.ForegroundColor = ERROR_FG_COLOR;
            }

            StringBuilder sBuilder = new StringBuilder("[END] Test: ");
            sBuilder.Append( testId );
            sBuilder.Append( " RESULT: " );
            sBuilder.Append( result.ToString() );
            
            Console.WriteLine( sBuilder.ToString() );

            Console.ForegroundColor = m_prevFGColor;
            return;
        }

        /// 
        /// <summary>
        /// Returns "this" object
        /// </summary>
        /// <returns>SimpleConsoleLogger object</returns>
        /// 
        public object GetLogger()
        {
            return this;
        }

        /// 
        /// <summary>
        /// Releases any resource held
        /// </summary>
        /// 
        public void Close()
        {
            //Do nothing
        }
    }
}

