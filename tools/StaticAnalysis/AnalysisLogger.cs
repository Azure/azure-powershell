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
using System.Text;

namespace StaticAnalysis
{
    /// <summary>
    /// Abstract class to implement the report logging structure
    /// </summary>
    public abstract class AnalysisLogger
    {
        string _baseDirectory;
        string _exceptionsDirectory;

        /// <summary>
        /// Create an analysis logger that will write reports to the given directory
        /// </summary>
        /// <param name="baseDirectory">The base directory for reports</param>
        /// <param name="exceptionsDirectory">The directory containing exceptions form static analysis rules.</param>
        public AnalysisLogger(string baseDirectory, string exceptionsDirectory)
        {
            _baseDirectory = baseDirectory;
            _exceptionsDirectory = exceptionsDirectory;
        }

        /// <summary>
        /// Create an analysis logger without exceptions
        /// </summary>
        /// <param name="baseDirectory">The base directory for reports</param>
        public AnalysisLogger(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
            _exceptionsDirectory = null;
        }

        IList<ReportLogger> _loggers = new List<ReportLogger>();
        protected virtual IList<ReportLogger> Loggers { get { return _loggers; } }

        /// <summary>
        /// Write an error report.
        /// </summary>
        /// <param name="error">The message to write</param>
        public abstract void WriteError(string error);

        public virtual void WriteError(string format, params object[] args)
        {
            WriteError(string.Format(format, args));
        }

        /// <summary>
        /// Write an informational message.
        /// </summary>
        /// <param name="message">The message to write</param>
        public abstract void WriteMessage(string message);

        public virtual void WriteMessage(string format, params object[] args)
        {
            WriteMessage(string.Format(format, args));
        }

        /// <summary>
        /// Write a warning.
        /// </summary>
        /// <param name="message">The warning text</param>
        public abstract void WriteWarning(string message);

        public virtual void WriteWarning(string format, params object[] args)
        {
            WriteWarning(string.Format(format, args));
        }

        /// <summary>
        /// Write a report file to the given file, using the given file contents.
        /// </summary>
        /// <param name="name">The path to the file</param>
        /// <param name="contents">The contents of the report</param>
        public abstract void WriteReport(string name, string contents);

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
                WriteWarning("Using exceptions file {0}", exceptionsPath);
                logger = new ReportLogger<T>(filePath, exceptionsPath, this);
            }
            else
            {
                WriteWarning("Using no exceptions file.");
                logger = new ReportLogger<T>(filePath, this);
            }

            Loggers.Add(logger);
            return logger;
        }

        /// <summary>
        /// Write out the report files for each of the added report loggers.
        /// </summary>
        public void WriteReports()
        {
            foreach (var logger in Loggers.Where(l => l.Records.Any()))
            {
                StringBuilder reportText = new StringBuilder();
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
                StringBuilder errorText = new StringBuilder();
                errorText.AppendLine(logger.Records.First().PrintHeaders());
                foreach (var reportRecord in logger.Records)
                {
                    errorText.AppendLine(reportRecord.FormatRecord());
                }

                WriteError("{0} Errors", logger.FileName);
                WriteError(errorText.ToString());
                WriteError("");
            }

            if (hasErrors)
            {
                throw new InvalidOperationException(string.Format("One or more errors occurred in validation. " +
                                                                  "See the analysis repots at {0} for details",
                    _baseDirectory));
            }
        }
    }
}
