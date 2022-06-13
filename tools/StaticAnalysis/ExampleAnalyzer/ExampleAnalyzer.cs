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

//not completed
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text.RegularExpressions;
using Tools.Common.Issues;
using Tools.Common.Loaders;
using Tools.Common.Loggers;
using Tools.Common.Models;

namespace StaticAnalysis.ExampleAnalyzer
{
    /// <summary>
    /// Static analyzer for PowerShell Help
    /// </summary>
    public class ExampleAnalyzer : IStaticAnalyzer
    {
        public ExampleAnalyzer()
        {
            Name = "Example Analyzer";
        }
        public AnalysisLogger Logger { get; set; }
        public string Name { get; private set; }

        public void Analyze(IEnumerable<string> scopes)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddScript("Measure-MarkdownOrScript.ps1 -MarkdownPaths $(RepoArtifacts)/FilesChanged.txt -RulePaths $(RepoTools)/StaticAnalysis/ExampleAnalyzer/AnalyzeRules//*.psm1 -Recurse -AnalyzeScriptsInFile -OutputScriptsInFile -OutputResultsByModule").Invoke();
            var ExampleLogger = Logger.CreateLogger<HelpIssue>("ExampleIssues.csv");
            
        }
    }
}