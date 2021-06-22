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
using System.Linq;
using System.Text.RegularExpressions;
using Tools.Common.Loggers;
using Tools.Common.Models;
#if NETSTANDARD
using StaticAnalysis.Netcore.Properties;
#else
using StaticAnalysis.Properties;
#endif

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    /// <summary>
    /// This class is responsible for comparing CmdletMetadata and
    /// checking for breaking changes between old (serialized) metadata and new metadata.
    /// </summary>
    public class CmdletMetadataHelper
    {
        private TypeMetadataHelper _typeMetadataHelper;
        private ParameterMetadataHelper _parameterMetadataHelper;
        private ParameterSetMetadataHelper _parameterSetMetadataHelper;

        public CmdletMetadataHelper()
        {
            _typeMetadataHelper = new TypeMetadataHelper();
            _parameterMetadataHelper = new ParameterMetadataHelper(_typeMetadataHelper);
            _parameterSetMetadataHelper = new ParameterSetMetadataHelper();
        }

        public CmdletMetadataHelper(TypeMetadataHelper typeMetadataHelper)
        {
            _typeMetadataHelper = typeMetadataHelper;
            _parameterMetadataHelper = new ParameterMetadataHelper(_typeMetadataHelper);
            _parameterSetMetadataHelper = new ParameterSetMetadataHelper();
        }

        /// <summary>
        /// Compares the metadata of cmdlets with the same name (or alias) for any breaking changes.
        ///
        /// Breaking changes for cmdlets include
        ///   - Removing a cmdlet
        ///   - Removing an alias to a cmdlet
        ///   - Removing SupportsShouldProcess
        ///   - Removing SupportsPaging
        ///   - Output type (or any of its properties) of cmdlet has changed
        ///   - Default parameter set has changed
        ///
        /// This method will also check for breaking changes in the cmdlets' parameters and
        /// parameter sets using the appropriate helpers.
        /// </summary>
        /// <param name="oldCmdlets">The list of cmdlets from the old (serialized) metadata.</param>
        /// <param name="newCmdlets">The list of cmdlets from the new metadata.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        public void CompareCmdletMetadata(
            List<CmdletMetadata> oldCmdlets,
            List<CmdletMetadata> newCmdlets,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // This dictionary will map a cmdlet name (or alias) to the corresponding metadata
            Dictionary<string, CmdletMetadata> cmdletDictionary =
                new Dictionary<string, CmdletMetadata>();

            // Add each cmdlet and its aliases to the dictionary
            foreach (var newCmdlet in newCmdlets)
            {
                cmdletDictionary.Add(newCmdlet.Name, newCmdlet);

                foreach (var alias in newCmdlet.AliasList)
                {
                    if (!cmdletDictionary.ContainsKey(alias))
                    {
                        cmdletDictionary.Add(alias, newCmdlet);
                    }
                }
            }

            // For each cmdlet in the old metadata, see if it has been
            // added to the dictionary (exists in the new metadata)
            foreach (var oldCmdlet in oldCmdlets)
            {
                if (cmdletDictionary.ContainsKey(oldCmdlet.Name))
                {
                    var newCmdlet = cmdletDictionary[oldCmdlet.Name];

                    // Go through all of the breaking change checks for cmdlets
                    CheckForRemovedCmdletAlias(oldCmdlet, newCmdlet, issueLogger);
                    CheckForRemovedSupportsShouldProcess(oldCmdlet, newCmdlet, issueLogger);
                    CheckForRemovedSupportsPaging(oldCmdlet, newCmdlet, issueLogger);
                    CheckForChangedOutputType(oldCmdlet, newCmdlet, issueLogger);
                    CheckDefaultParameterName(oldCmdlet, newCmdlet, issueLogger);

                    // Go through all of the breaking change checks for parameters using the ParameterMetadataHelper
                    _parameterMetadataHelper.CompareParameterMetadata(oldCmdlet, oldCmdlet.Parameters, newCmdlet.Parameters, issueLogger);
                    // Go through all of the breaking change checks for parameter sets using the ParmaterSetMetadataHelper
                    _parameterSetMetadataHelper.CompareParameterSetMetadata(oldCmdlet, oldCmdlet.ParameterSets, newCmdlet.ParameterSets, issueLogger);
                }
                // If the cmdlet cannot be found, log an issue
                else
                {
                    issueLogger?.LogBreakingChangeIssue(
                        cmdlet: oldCmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedCmdlet,
                        description: string.Format(Resources.RemovedCmdletDescription, oldCmdlet.Name),
                        remediation: string.Format(Resources.RemovedCmdletRemediation, oldCmdlet.Name));
                }
            }
        }

        /// <summary>
        /// Checks if an alias to a cmdlet has been removed.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForRemovedCmdletAlias(
            CmdletMetadata oldCmdlet,
            CmdletMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // This set will contain all of the aliases in the new metadata
            HashSet<string> aliasSet = new HashSet<string>();

            // Add each alias to the set
            foreach (var newAlias in newCmdlet.AliasList)
            {
                aliasSet.Add(newAlias);
            }

            // For each alias in the old metadata, check to see
            // if it exists in the new metadata
            foreach (var oldAlias in oldCmdlet.AliasList)
            {
                // If the alias cannot be found, log an issue
                if (!aliasSet.Contains(oldAlias))
                {
                    issueLogger?.LogBreakingChangeIssue(
                        cmdlet: oldCmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedCmdletAlias,
                        description: string.Format(Resources.RemovedCmdletAliasDescription,
                            oldCmdlet.Name, oldAlias),
                        remediation: string.Format(Resources.RemovedCmdletAliasRemediation,
                            oldAlias, oldCmdlet.Name));
                }
            }
        }

        /// <summary>
        /// Check if a cmdlet no longer implements SupportsShouldProcess.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForRemovedSupportsShouldProcess(
            CmdletMetadata oldCmdlet,
            CmdletMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the old cmdlet implements SupportsShouldProcess and the new cmdlet does not, log an issue
            if (oldCmdlet.SupportsShouldProcess && !newCmdlet.SupportsShouldProcess)
            {
                issueLogger?.LogBreakingChangeIssue(
                    cmdlet: oldCmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.RemovedShouldProcess,
                    description: string.Format(Resources.RemovedShouldProcessDescription, oldCmdlet.Name),
                    remediation: string.Format(Resources.RemovedShouldProcessRemediation, oldCmdlet.Name));
            }
        }

        /// <summary>
        /// Check if a cmdlet no longer implements SupportsPaging.
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForRemovedSupportsPaging(
            CmdletMetadata oldCmdlet,
            CmdletMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the old cmdlet implements SupportsPaging and the new cmdlet does not, log an issue
            if (oldCmdlet.SupportsPaging && !newCmdlet.SupportsPaging)
            {
                issueLogger?.LogBreakingChangeIssue(
                    cmdlet: oldCmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.RemovedPaging,
                    description: string.Format(Resources.RemovedPagingDescription, oldCmdlet.Name),
                    remediation: string.Format(Resources.RemovedPagingRemediation, oldCmdlet.Name));
            }
        }

        /// <summary>
        /// Check if the OutputType of the cmdlet has been removed, or if any property
        /// of the OutputType has been removed or changed
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForChangedOutputType(
            CmdletMetadata oldCmdlet,
            CmdletMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // This dictionary will map an output type name to the corresponding type metadata
            Dictionary<string, TypeMetadata> outputDictionary = new Dictionary<string, TypeMetadata>(new TypeNameComparer());

            // Add each output in the new metadata to the dictionary
            if (newCmdlet != null && newCmdlet.OutputTypes != null)
            {
                foreach (var newOutput in newCmdlet.OutputTypes)
                {
                    if (!outputDictionary.ContainsKey(newOutput.Type.Name))
                    {
                        outputDictionary.Add(newOutput.Type.Name, newOutput.Type);
                    }
                }
            }

            // For each output in the old metadata, see if it
            // exists in the new metadata
            foreach (var oldOutput in oldCmdlet.OutputTypes)
            {
                // If the output can be found, use the TypeMetadataHelper to
                // check the type for any breaking changes
                if (outputDictionary.ContainsKey(oldOutput.Type.Name))
                {
                    var newOutputType = outputDictionary[oldOutput.Type.Name];

                    _typeMetadataHelper.CheckOutputType(oldCmdlet, oldOutput.Type, newOutputType, issueLogger);
                }
                // If the output cannot be found by name, check if the old output can be mapped
                // to any of the new output types
                else
                {
                    var foundOutput = outputDictionary.Values.Any(o => _typeMetadataHelper.CompareTypeMetadata(oldCmdlet, oldOutput.Type, o, null));
                    if (!foundOutput)
                    {
                        issueLogger?.LogBreakingChangeIssue(
                            cmdlet: oldCmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.ChangedOutputType,
                            description: string.Format(Resources.ChangedOutputTypeDescription,
                                oldCmdlet.Name, oldOutput.Type.Name),
                            remediation: string.Format(Resources.ChangedOutputTypeRemediation,
                                oldCmdlet.Name, oldOutput.Type.Name));
                    }
                }
            }
        }

        /// <summary>
        /// Check if the default parameter set has changed, and if so, make sure
        /// that the parameters are the same
        /// </summary>
        /// <param name="oldCmdlet">The cmdlet metadata from the old (serialized) assembly.</param>
        /// <param name="newCmdlet">The cmdlet metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckDefaultParameterName(
            CmdletMetadata oldCmdlet,
            CmdletMetadata newCmdlet,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the default parameter name hasn't changed, or if there wasn't a
            // default parameter set defined before, return
            if (oldCmdlet.DefaultParameterSetName.Equals(newCmdlet.DefaultParameterSetName) ||
                oldCmdlet.DefaultParameterSetName.Equals("__AllParameterSets"))
            {
                return;
            }

            // Get the metadata for the old default parameter set
            ParameterSetMetadata oldDefaultParameterSet = oldCmdlet.ParameterSets
                .FirstOrDefault(p => p.Name.Equals(oldCmdlet.DefaultParameterSetName, StringComparison.OrdinalIgnoreCase));
            // Get the metadata for the new default parameter set
            ParameterSetMetadata newDefaultParameterSet = newCmdlet.ParameterSets
                .FirstOrDefault(p => p.Name.Equals(newCmdlet.DefaultParameterSetName, StringComparison.OrdinalIgnoreCase));
            if (oldDefaultParameterSet == null || newDefaultParameterSet == null)
            {
                return;
            }
            // This dictionary will map a parameter name and aliases to the corresponding Parameter object
            Dictionary<string, Parameter> parameterDictionary = new Dictionary<string, Parameter>();

            // Add each parameter name and aliases to the dictionary
            foreach (var newParameter in newDefaultParameterSet.Parameters)
            {
                parameterDictionary.Add(newParameter.ParameterMetadata.Name, newParameter);

                foreach (var alias in newParameter.ParameterMetadata.AliasList)
                {
                    parameterDictionary.Add(alias, newParameter);
                }
            }

            // For each parameter in the old default parameter set, check if it
            // exists in the new default parameter set
            foreach (var oldParameter in oldDefaultParameterSet.Parameters)
            {
                // If the parameter cannot be found, log an issue
                if (!parameterDictionary.ContainsKey(oldParameter.ParameterMetadata.Name))
                {
                    issueLogger?.LogBreakingChangeIssue(
                        cmdlet: oldCmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.ChangeDefaultParameter,
                        description: string.Format(Resources.ChangeDefaultParameterDescription,
                            oldCmdlet.DefaultParameterSetName, oldCmdlet.Name),
                        remediation: string.Format(Resources.ChangeDefaultParameterRemediation,
                            oldCmdlet.Name, oldCmdlet.DefaultParameterSetName));
                }
            }
        }

        /// <summary>
        /// Comparer for assebly qualified names.  Parses of the PublicKeyToken, so that types from signed and unsigned assemblies match
        /// </summary>
        class TypeNameComparer : IEqualityComparer<string>
        {
            Regex keyToken = new Regex(@", PublicKeyToken=\w+");
            public bool Equals(string x, string y)
            {
                var newX = keyToken.Replace(x, "");
                var newY = keyToken.Replace(y, "");
                return StringComparer.OrdinalIgnoreCase.Equals(newX, newY);
            }

            public int GetHashCode(string obj)
            {
                var newObj = keyToken.Replace(obj, "");
                return StringComparer.OrdinalIgnoreCase.GetHashCode(newObj);
            }
        }
    }
}
