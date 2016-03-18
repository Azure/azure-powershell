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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace StaticAnalysis
{
    /// <summary>
    /// Abstract report logger - used as an abstraction over typed loggers.
    /// </summary>
    public abstract class ReportLogger
    {
        private AnalysisLogger _parent;
        private string _outputFile;
        private string _exceptionsFilename;

        public ReportLogger(string fileName, AnalysisLogger parent)
            : this(fileName, null, parent)
        {
        }

        public ReportLogger(string fileName, string exceptionsFilename, AnalysisLogger parent)
        {
            _parent = parent;
            _outputFile = fileName;
            _exceptionsFilename = exceptionsFilename;
        }

        protected AnalysisLogger ParentLogger { get { return _parent; } }
        public string FileName { get { return _outputFile; } }
        public abstract IList<IReportRecord> Records { get; }

        public virtual void WriteError(string error)
        {
            ParentLogger.WriteError(error);
        }

        public virtual void WriteMessage(string message)
        {
            ParentLogger.WriteMessage(message);
        }

        public virtual void WriteWarning(string message)
        {
            ParentLogger.WriteWarning(message);
        }
    }

    /// <summary>
    /// A typed report logger
    /// </summary>
    /// <typeparam name="T">The type of the report this logger will log.</typeparam>
    public class ReportLogger<T> : ReportLogger where T : class, IReportRecord, new()
    {
        public ReportLogger(string fileName, AnalysisLogger logger)
            : this(fileName, null, logger)
        {
            Decorator = Decorator<T>.Create();
        }

        public ReportLogger(string fileName, string exceptionsFileName, AnalysisLogger logger)
            : base(fileName, logger)
        {
            Decorator = Decorator<T>.Create();
            if (exceptionsFileName != null && File.Exists(exceptionsFileName))
            {
                var records = File.ReadAllLines(exceptionsFileName);
                for (int i = 1; i < records.Length; ++i)
                {
                    var record = new T();
                    _exceptionRecords.Add(record.Parse(records[i]) as T);
                }
            }
        }

        private IList<T> _records = new List<T>();
        private IList<T> _exceptionRecords = new List<T>();
        public Decorator<T> Decorator { get; protected set; }

        /// <summary>
        /// Log a record to the report
        /// </summary>
        /// <param name="record"></param>
        public void LogRecord(T record)
        {
            Decorator.Apply(record);
            if (!_exceptionRecords.Any(r => r.Match(record)))
            {
                _records.Add(record);
            }
        }

        public override IList<IReportRecord> Records
        {
            get { return _records.Select(r => r as IReportRecord).ToList(); }
        }
    }
}
