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
using StaticAnalysis.CmdlineArgParsing;
using System.Reflection;
using System.Linq;

namespace StaticAnalysis
{
    /// <summary>
    /// Runner for all static analysis tools.
    /// </summary>
    public class Program
    {
        static IList<IStaticAnalyzer> Analyzers = new List<IStaticAnalyzer>()
        {
            new HelpAnalyzer.HelpAnalyzer(),
            new DependencyAnalyzer.DependencyAnalyzer(),
            new SignatureVerifier.SignatureVerifier(),
            new BreakingChangeAnalyzer.BreakingChangeAnalyzer()
        };

        public static void Main(string[] args)
        {
            AnalysisLogger analysisLogger = null;
            try
            {
                if (args == null || args.Length < 1)
                {
                    throw new InvalidOperationException("Please pass a valid directory name as the first parameter");
                }

                var installDir = args[0];
                if (!Directory.Exists(installDir))
                {
                    throw new InvalidOperationException("You must pass a valid directory as the first parameter");
                }

                var directories = new List<string>
            {
                Path.Combine(installDir, @"ResourceManager\AzureResourceManager\"),
                Path.Combine(installDir, @"ServiceManagement\Azure\"),
                Path.Combine(installDir, @"Storage\")
           }.Where((d) => Directory.Exists(d)).ToList<string>();

                var reportsDirectory = Directory.GetCurrentDirectory();
                bool logReportsDirectoryWarning = true;
                if (args.Length > 1 && Directory.Exists(args[1]))
                {
                    reportsDirectory = args[1];
                    logReportsDirectoryWarning = false;
                }

                var exceptionsDirectory = Path.Combine(reportsDirectory, "Exceptions");
                bool useExceptions = true;
                if (args.Length > 2)
                {
                    bool.TryParse(args[2], out useExceptions);
                }

                bool skipHelp = true;
                if (args.Length > 3)
                {
                    bool.TryParse(args[3], out skipHelp);
                }

                if (skipHelp)
                {
                    Analyzers = Analyzers.Where((a) => !(a is HelpAnalyzer.HelpAnalyzer)).ToList();
                }
                
                analysisLogger = useExceptions ? new AnalysisLogger(reportsDirectory, exceptionsDirectory) :
                    new AnalysisLogger(reportsDirectory);
                if (logReportsDirectoryWarning)
                {
                    analysisLogger.WriteWarning("No logger specified in the second parameter, writing reports to {0}",
                        reportsDirectory);
                }

                foreach (var analyzer in Analyzers)
                {
                    analyzer.Logger = analysisLogger;
                    analysisLogger.WriteMessage("Executing analyzer: {0}", analyzer.Name);
                    analyzer.Analyze(directories);
                    analysisLogger.WriteMessage("Processing complete for analyzer: {0}", analyzer.Name);
                }

                analysisLogger.WriteReports();
                analysisLogger.CheckForIssues(2);
            }
            catch(Exception ex)
            {
                analysisLogger.WriteError(ex.ToString());
                throw ex;
            }
        }
    }
}
