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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Tools.Common.Issues;

namespace Tools.Common.Loggers
{
    /// <summary>
    /// Abstract class to implement the report logging structure
    /// </summary>
    public class AnalysisLogger
    {
        private readonly string _baseDirectory;
        private readonly string _exceptionsDirectory;
        private static string _defaultLogName;
        private static Dictionary<string, AnalysisLogger> _logDictionary;
        private static Dictionary<string, AnalysisLogger> LogDictionary
        {
            get { return _logDictionary ?? (_logDictionary = new Dictionary<string, AnalysisLogger>()); }
        }

        /// <summary>
        /// Factory to get logger
        /// </summary>
        /// <param name="loggerName">Name of logger that was either created earlier or needs to be created</param>
        /// <returns>AnalysisLogger</returns>
        private static AnalysisLogger GetLogger(string loggerName)
        {
            //TODO: Once logger is simplified throughout application, factory method can be enabled
            AnalysisLogger log;
            if (!string.IsNullOrEmpty(loggerName))
            {
                if (LogDictionary.TryGetValue(loggerName, out log)) return log;

                _defaultLogName = loggerName;
                log = new AnalysisLogger(Assembly.GetEntryAssembly().Location);
                LogDictionary.Add(loggerName, log);
            }
            else
            {
                LogDictionary.TryGetValue(_defaultLogName, out log);
            }

            return log;
        }


        /// <summary>
        /// Create an analysis logger that will write reports to the given directory
        /// </summary>
        /// <param name="baseDirectory">The base directory for reports</param>
        /// <param name="exceptionsDirectory">The directory containing exceptions form static analysis rules.</param>
        public AnalysisLogger(string baseDirectory, string exceptionsDirectory)
        {
            _baseDirectory = baseDirectory;
            _exceptionsDirectory = exceptionsDirectory;
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyType = assembly.GetType();
            _defaultLogName = assembly.GetName().Name;
        }

        /// <summary>
        /// Create an analysis logger without exceptions
        /// </summary>
        /// <param name="baseDirectory">The base directory for reports</param>
        public AnalysisLogger(string baseDirectory) : this(baseDirectory, null)
        { }

        private readonly IList<ReportLogger> _loggers = new List<ReportLogger>();
        protected virtual IList<ReportLogger> Loggers { get { return _loggers; } }


        /// <summary>
        /// Write a report file to the given file, using the given file contents.
        /// </summary>
        /// <param name="name">The path to the file</param>
        /// <param name="contents">The contents of the report</param>
        public virtual void WriteReport(string name, string contents)
        {
            File.WriteAllText(name, contents);
        }

        /// <summary>
        /// Create a logger for a particular report
        /// </summary>
        /// <typeparam name="T">The type of records written to the log</typeparam>
        /// <param name="fileName">The filename (without file path) where the report will be written</param>
        /// <returns>The given logger.  Analyzer may write records to this logger and they will be written to
        /// the report file.</returns>
        public virtual ReportLogger<T> CreateLogger<T>(string fileName) where T : class, IReportRecord, new()
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("fileName");
            }

            var filePath = Path.Combine(_baseDirectory, fileName);
            ReportLogger<T> logger;
            if (_exceptionsDirectory != null && Directory.Exists(_exceptionsDirectory))
            {
                var exceptionsPath = Path.Combine(_exceptionsDirectory, fileName);
                logger = new ReportLogger<T>(filePath, exceptionsPath, this);
            }
            else
            {
                logger = new ReportLogger<T>(filePath, this);
            }

            Loggers.Add(logger);
            return logger;
        }

        public ReportLogger GetReportLogger(string loggerFileName)
        {
            return Loggers.SingleOrDefault(log => Path.GetFileName(log.FileName).Equals(loggerFileName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Write out the report files for each of the added report loggers.
        /// </summary>
        public void WriteReports()
        {
            foreach (var logger in Loggers.Where(l => l.Records.Any()))
            {
                var reportText = new StringBuilder();
                reportText.AppendLine(logger.Records.First().PrintHeaders());
                foreach (var reportRecord in logger.Records)
                {
                    reportText.AppendLine(reportRecord.FormatRecord());
                }

                WriteReport(logger.FileName, reportText.ToString());
            }
        }

        public void CheckForIssues(int maxSeverity)
        {
            var hasErrors = false;
            foreach (var logger in Loggers.Where(l => l.Records.Any(r => r.Severity < maxSeverity)))
            {
                hasErrors = true;
                var errorText = new StringBuilder();
                errorText.AppendLine(logger.Records.First().PrintHeaders());
                foreach (var reportRecord in logger.Records)
                {
                    errorText.AppendLine(reportRecord.FormatRecord());
                }

                WriteError("{0} Errors", logger.FileName);
                WriteError(errorText.ToString());
                WriteError("");
                Console.WriteLine("{0}:\n{1}", logger.FileName, errorText);
            }

            if (hasErrors)
            {
                throw new InvalidOperationException(string.Format("One or more errors occurred in validation. " +
                                                                  "See the analysis reports at {0} for details",
                    _baseDirectory));
            }
        }

        #region Write Methods
        /// <summary>
        /// Write an error report.
        /// </summary>
        /// <param name="error">The message to write</param>
        public virtual void WriteError(string error)
        {
            Error(error);
        }

        public virtual void WriteError(string format, params object[] args)
        {
            WriteError(string.Format(format, args));
        }

        /// <summary>
        /// Write an informational message.
        /// </summary>
        /// <param name="message">The message to write</param>
        public virtual void WriteMessage(string message)
        {
            Info(message);
        }

        public virtual void WriteMessage(string format, params object[] args)
        {
            WriteMessage(string.Format(format, args));
        }

        /// <summary>
        /// Write a warning.
        /// </summary>
        /// <param name="message">The warning text</param>
        public virtual void WriteWarning(string message)
        {
            Warning(message);
        }

        public virtual void WriteWarning(string format, params object[] args)
        {
            WriteWarning(string.Format(format, args));
        }


        #region Info methods
        public void Info(string info)
        {
            Console.WriteLine(info);
        }

        public void Info<T>(string info, IEnumerable<T> infoCollection)
        {
            Info(info, infoCollection, t => t.ToString());
        }

        public void Info<T>(string info, IEnumerable<T> infoCollection, Func<T, string> infoItemPrintDelegate)
        {
            Info(info, "{0},", infoCollection, infoItemPrintDelegate);
        }

        public void Info<T>(string info, string infoFormat, IEnumerable<T> infoCollection)
        {
            Info(info, infoFormat, infoCollection, t => t.ToString());
        }

        public void Info<T>(string info, string infoFormat, IEnumerable<T> infoCollection, Func<T, string> infoItemPrintDelegate)
        {
            Info(info);
            var sb = new StringBuilder();
            foreach (var t in infoCollection)
            {
                sb.AppendLine(string.Format(infoFormat, infoItemPrintDelegate(t)));
            }

            Info(sb.ToString());
        }
        #endregion

        private void Error(string errorInfo)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorInfo);
            Console.ForegroundColor = previousColor;
        }

        public void DebugInfo(string debugInfo)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(debugInfo);
            Console.ForegroundColor = previousColor;
        }

        private void Warning(string warningInfo)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(warningInfo);
            Console.ForegroundColor = previousColor;
        }

        #endregion
    }
}