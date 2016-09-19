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
namespace StaticAnalysis
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the public object model for a static analysis tool
    /// </summary>
    public interface IStaticAnalyzer
    {
        /// <summary>
        /// The logger where validation records should be written
        /// </summary>
        AnalysisLogger Logger { get; set; }

        /// <summary>
        /// The display name of the Analyzer
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Validate the given assembly in the given directory
        /// </summary>
        /// <param name="scopes">The analysis targets</param>
        void Analyze(IEnumerable<string> scopes);

        /// <summary>
        /// Validate the given assembly in the given directory
        /// </summary>
        /// <param name="cmdletProbingDirs">Root directory on which analysis needs to be performed</param>
        /// <param name="directoryFilter">Directory filter delegate to skip directories from performing static analysis</param>
        /// <param name="cmdletFilter">cmdlet name filter allowing you to skip cmdlets from being analyzed</param>
        void Analyze(IEnumerable<string> cmdletProbingDirs,
                            Func<IEnumerable<string>, IEnumerable<string>> directoryFilter,
                            Func<string, bool> cmdletFilter);

        /// <summary>
        /// Get analysis report post analysis
        /// </summary>
        /// <returns></returns>
        AnalysisReport GetAnalysisReport();
    }
}
