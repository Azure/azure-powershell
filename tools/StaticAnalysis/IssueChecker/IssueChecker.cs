using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Tools.Common.Issues;
using Tools.Common.Loggers;
using StaticAnalysis.BreakingChangeAnalyzer;
using StaticAnalysis.DependencyAnalyzer;

namespace StaticAnalysis.IssueChecker
{
    public class IssueChecker : IStaticAnalyzer
    {
        private readonly List<(string, string)> exceptionLogInfoList = new List<(string, string)>()
        {
            ("BreakingChangeIssues.csv", "BreakingChangeIssues"),
            ("AssemblyVersionConflict.csv", "AssemblyVersionConflict"),
            ("SharedAssemblyConflict.csv", "SharedAssemblyConflict"),
            ("MissingAssemblies.csv", "MissingAssembly"),
            ("ExtraAssemblies.csv", "ExtraAssembly"),
        };
        public AnalysisLogger Logger { get; set; }

        public string Name { get; private set; }

        public IssueChecker()
        {
            Name = "Issue Checker";
        }

        public void Analyze(IEnumerable<string> scopes)
        {
            Analyze(scopes, null);
        }

        public void Analyze(IEnumerable<string> scopes, IEnumerable<string> modulesToAnalyze)
        {
            foreach (string scope in scopes)
            {
                Console.WriteLine(scope);
            }
            if (scopes.ToList().Count != 1)
            {
                throw new InvalidOperationException(string.Format("scopes for IssueChecker should be a array contains only reportsDirectory, but here is [{0}]", string.Join(", ", scopes.ToList())));
            }
            string reportsDirectory = scopes.First();

            bool hasCriticalIssue = false;
            foreach ((string, string) item in exceptionLogInfoList)
            {
                string exceptionFileName = item.Item1;
                string recordTypeName = item.Item2;

                string exceptionFilePath = Path.Combine(reportsDirectory, exceptionFileName);
                if (!File.Exists(exceptionFilePath))
                {
                    continue;
                }
                if (IsSingleExceptionFileHasCriticalIssue(exceptionFilePath, recordTypeName))
                {
                    hasCriticalIssue = true;
                }
            }
            if (hasCriticalIssue)
            {
                throw new InvalidOperationException(string.Format("One or more errors occurred in validation. " +
                                                                  "See the analysis reports at {0} for details",
                    reportsDirectory));
            }
        }

        private bool IsSingleExceptionFileHasCriticalIssue(string exceptionFilePath, string reportRecordTypeName) 
        {
            bool hasError = false;
            using (var reader = new StreamReader(exceptionFilePath))
            {
                List<IReportRecord> recordList = new List<IReportRecord>();
                string header = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    IReportRecord newRecord = ReportRecordFactory.Create(reportRecordTypeName);
                    recordList.Add(newRecord.Parse(line));
                }
                var errorText = new StringBuilder();
                errorText.AppendLine(recordList.First().PrintHeaders());
                foreach (IReportRecord record in recordList)
                {
                    if (record.Severity < 2)
                    {
                        hasError = true;
                        errorText.AppendLine(record.FormatRecord());
                    }
                }
                if (hasError)
                {
                    Console.WriteLine("{0} Errors", exceptionFilePath);
                    Console.WriteLine(errorText.ToString());
                }
            }
            return hasError;
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter)
        {
            throw new NotImplementedException();
        }

        public void Analyze(IEnumerable<string> cmdletProbingDirs, Func<IEnumerable<string>, IEnumerable<string>> directoryFilter, Func<string, bool> cmdletFilter, IEnumerable<string> modulesToAnalyze)
        {
            throw new NotImplementedException();
        }

        public AnalysisReport GetAnalysisReport()
        {
            throw new NotImplementedException();
        }
    }
}
