using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysis
{
    /// <summary>
    /// Abstract class to implement the logging structure
    /// </summary>
    public abstract class AnalysisLogger
    {
        string _baseDirectory;

        /// <summary>
        /// Create an analysis logger that will write reports to the given directory
        /// </summary>
        /// <param name="baseDirectory"></param>
        public AnalysisLogger(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
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
        /// <returns>The given logger.  Analyzer may write records to this logger and they will be written to the report file.</returns>
        public virtual ReportLogger<T> CreateLogger<T>(string fileName) where T: IReportRecord, new()
        {
            var filePath = Path.Combine(_baseDirectory, fileName);
            var logger = new ReportLogger<T>(filePath, this);
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
    }
}
