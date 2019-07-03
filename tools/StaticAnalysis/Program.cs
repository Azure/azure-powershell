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
using System.Reflection;
using System.Linq;
using Tools.Common.Loggers;

namespace StaticAnalysis
{
    /// <summary>
    /// Runner for all static analysis tools.
    /// </summary>
    public class Program
    {
        static IList<IStaticAnalyzer> Analyzers = new List<IStaticAnalyzer>()
        {
            new DependencyAnalyzer.DependencyAnalyzer()
        };

        static IList<string> ExceptionFileNames = new List<string>()
        {
            "AssemblyVersionConflict.csv",
            "BreakingChangeIssues.csv",
            "ExtraAssemblies.csv",
            "HelpIssues.csv",
            "MissingAssemblies.csv",
            "SignatureIssues.csv"
        };

        private static string ExceptionsDirectory { get; set; }

        public static void Main(string[] args)
        {
            AnalysisLogger analysisLogger = null;
            try
            {
                string installDir = null;
                if (args.Any(a => a == "--package-directory" || a == "-p"))
                {
                    int idx = Array.FindIndex(args, a => a == "--package-directory" || a == "-p");
                    if (idx + 1 == args.Length)
                    {
                        throw new ArgumentException("No value provided for the --package-directory parameter.");
                    }

                    installDir = args[idx + 1];
                }

                if (args == null)
                {
                    throw new InvalidOperationException("No installation directory was provided; please use the --package-directory parameter to provide the value.");
                }
                else if (!Directory.Exists(installDir))
                {
                    throw new InvalidOperationException(string.Format("Please provide a valid installation directory; the provided directory '{0}' could not be found.", installDir));
                }

                var directories = new List<string>{ installDir }.Where((d) => Directory.Exists(d)).ToList<string>();

                var reportsDirectory = Directory.GetCurrentDirectory();
                bool logReportsDirectoryWarning = true;
                if (args.Any(a => a == "--reports-directory" || a == "-r"))
                {
                    int idx = Array.FindIndex(args, a => a == "--reports-directory" || a == "-r");
                    if (idx + 1 == args.Length)
                    {
                        throw new ArgumentException("No value provided for the --reports-directory parameter.");
                    }

                    reportsDirectory = args[idx + 1];
                    logReportsDirectoryWarning = false;
                }

                if (!Directory.Exists(reportsDirectory))
                {
                    Directory.CreateDirectory(reportsDirectory);
                }

                var modulesToAnalyze = new List<string>();
                if (args.Any(a => a == "--modules-to-analyze" || a == "-m"))
                {
                    int idx = Array.FindIndex(args, a => a == "--modules-to-analyze" || a == "-m");
                    if (idx + 1 == args.Length)
                    {
                        Console.WriteLine("No value provided for the --modules-to-analyze parameter. Filtering over all built modules.");
                    }
                    else
                    {
                        modulesToAnalyze = args[idx + 1].Split(';').ToList();
                    }
                }

                Analyzers.Add(new SignatureVerifier.SignatureVerifier());
                Analyzers.Add(new BreakingChangeAnalyzer.BreakingChangeAnalyzer());

                var helpOnly = args.Any(a => a == "--help-only" || a == "-h");
                var skipHelp = !helpOnly && args.Any(a => a == "--skip-help" || a == "-s");
                if(helpOnly)
                {
                    Analyzers.Clear();
                }
                if (!skipHelp)
                {
                    Analyzers.Add(new HelpAnalyzer.HelpAnalyzer());
                }

                // https://stackoverflow.com/a/9737418/294804
                var assemblyDirectory = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
                ExceptionsDirectory = Path.Combine(assemblyDirectory, "Exceptions");
                bool useExceptions = !args.Any(a => a == "--dont-use-exceptions" || a == "-d");
                var useNetcore = args.Any(a => a == "--use-netcore" || a == "-u");
                ConsolidateExceptionFiles(ExceptionsDirectory, useNetcore);

                analysisLogger = useExceptions ? new AnalysisLogger(reportsDirectory, ExceptionsDirectory) : new AnalysisLogger(reportsDirectory);
                if (logReportsDirectoryWarning)
                {
                    analysisLogger.WriteWarning("No logger specified in the second parameter, writing reports to {0}", reportsDirectory);
                }

                foreach (var analyzer in Analyzers)
                {
                    analyzer.Logger = analysisLogger;
                    analysisLogger.WriteMessage("Executing analyzer: {0}", analyzer.Name);
                    analyzer.Analyze(directories, modulesToAnalyze);
                    analysisLogger.WriteMessage("Processing complete for analyzer: {0}", analyzer.Name);
                }

                analysisLogger.WriteReports();
                analysisLogger.CheckForIssues(2);
            }
            catch(Exception ex)
            {
                analysisLogger?.WriteError(ex.ToString());
                throw ex;
            }
            finally
            {
                foreach (var exceptionFileName in ExceptionFileNames)
                {
                    var exceptionFilePath = Path.Combine(ExceptionsDirectory, exceptionFileName);
                    if (File.Exists(exceptionFilePath))
                    {
                        File.Delete(exceptionFilePath);
                    }
                }
            }
        }

        private static void ConsolidateExceptionFiles(string exceptionsDirectory, bool useNetcore)
        {
            foreach (var exceptionFileName in ExceptionFileNames)
            {
                var moduleExceptionFilePaths = Directory.EnumerateFiles(exceptionsDirectory, exceptionFileName, SearchOption.AllDirectories)
                                                        .Where(f => useNetcore ? Directory.GetParent(f).Name.StartsWith("Az.") : Directory.GetParent(f).Name.StartsWith("Azure"))
                                                        .ToList();
                var exceptionFilePath = Path.Combine(exceptionsDirectory, exceptionFileName);
                if (File.Exists(exceptionFilePath))
                {
                    File.Delete(exceptionFilePath);
                }

                File.Create(exceptionFilePath).Close();
                var fileEmpty = true;
                foreach (var moduleExceptionFilePath in moduleExceptionFilePaths)
                {
                    var content = File.ReadAllLines(moduleExceptionFilePath);
                    if (content.Length > 1)
                    {
                        if (fileEmpty)
                        {
                            // Write the header
                            File.WriteAllLines(exceptionFilePath, new string[] { content.FirstOrDefault() });
                            fileEmpty = false;
                        }

                        // Write everything but the header
                        content = content.Skip(1).ToArray();
                        File.AppendAllLines(exceptionFilePath, content);
                    }
                }
            }
        }
    }
}
