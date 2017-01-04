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
using System.Text;
using System.Threading.Tasks;

namespace StaticAnalysis.BreakingChangeAnalyzer
{
    /// <summary>
    /// This class is responsible for comparing ParameterSetMetadata and checking
    /// for breaking changes between old (serialized) metadata and new metadata.
    /// </summary>
    public class ParameterSetMetadataHelper
    {
        /// <summary>
        /// Compares the metadata of parameter sets with the same name for any breaking changes.
        /// 
        /// Breaking changes for parameter sets include
        ///   - Removing a parameter set
        ///   - Making an optional parameter mandatory
        ///   - Changing the position of a parameter
        ///   - A parameter that previously could get its value from the pipeline no longer does
        ///   - A parameter that previously could get its value from the pipeline by property name no longer does
        ///   - A parameter has been removed from the parameter set
        /// </summary>
        /// <param name="cmdlet">Reference to the cmdlet whose parameter sets are being checked.</param>
        /// <param name="oldParameterSets">The list of parameter sets from the old (serialized) metadata.</param>
        /// <param name="newParameterSets">The list of parameter sets from the new metadata</param>
        /// <param name="issueLogger">ReportLogger that will keep track of the issues found.</param>
        public void CompareParameterSetMetadata(
            CmdletBreakingChangeMetadata cmdlet,
            List<ParameterSetMetadata> oldParameterSets,
            List<ParameterSetMetadata> newParameterSets,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // This dictionary will map a parameter set name to the corresponding metadata
            Dictionary<string, ParameterSetMetadata> parameterSetDictionary = new Dictionary<string, ParameterSetMetadata>();

            // Add each parameter set to the dictionary
            foreach (var newParameterSet in newParameterSets)
            {
                parameterSetDictionary.Add(newParameterSet.Name, newParameterSet);
            }

            // For each parameter set in the old metadata, see if it has been
            // added to the dictionary (exists in the new metadata)
            foreach (var oldParameterSet in oldParameterSets)
            {
                if (parameterSetDictionary.ContainsKey(oldParameterSet.Name))
                {
                    var newParameterSet = parameterSetDictionary[oldParameterSet.Name];

                    // This dictionary will map a parameter to the corresponding Parameter object
                    Dictionary<string, Parameter> parameterDictionary = new Dictionary<string, Parameter>();

                    // For each parameter in the parameter set, add its name and alias to the dictionary
                    foreach (var newParameter in newParameterSet.Parameters)
                    {
                        if (!parameterDictionary.ContainsKey(newParameter.ParameterMetadata.Name))
                        {
                            parameterDictionary.Add(newParameter.ParameterMetadata.Name, newParameter);
                        }

                        foreach (var alias in newParameter.ParameterMetadata.AliasList)
                        {
                            parameterDictionary.Add(alias, newParameter);
                        }
                    }

                    // For each parameter in the old metadata, see if it has been
                    // added to the dictionary (exists in the new metadata)
                    foreach (var oldParameter in oldParameterSet.Parameters)
                    {
                        if (parameterDictionary.ContainsKey(oldParameter.ParameterMetadata.Name))
                        {
                            var newParameter = parameterDictionary[oldParameter.ParameterMetadata.Name];

                            // If the parameter was optional in the old assembly and
                            // mandatory in the new assembly, log an issue
                            if (!oldParameter.Mandatory && newParameter.Mandatory)
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: cmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.MandatoryParameter,
                                    description: string.Format(Properties.Resources.MandatoryParameterDescription,
                                        oldParameter.ParameterMetadata.Name, oldParameterSet.Name, cmdlet.Name),
                                    remediation: string.Format(Properties.Resources.MandatoryParameterRemediation,
                                        oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                            }

                            // If the parameter had a position and it has changed in the
                            // new assembly, log an issue
                            if (oldParameter.Position >= 0 && oldParameter.Position != newParameter.Position)
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: cmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.PositionChange,
                                    description: string.Format(Properties.Resources.PositionChangeDescription,
                                        oldParameter.ParameterMetadata.Name, oldParameterSet.Name, cmdlet.Name),
                                    remediation: string.Format(Properties.Resources.PositionChangeRemediation,
                                        oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                            }

                            // If the parameter can no longer get its value from
                            // the pipeline, log an issue
                            if (oldParameter.ValueFromPipeline && !newParameter.ValueFromPipeline)
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: cmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.ValueFromPipeline,
                                    description: string.Format(Properties.Resources.RemovedValueFromPipelineDescription,
                                        oldParameter.ParameterMetadata.Name, oldParameterSet.Name, cmdlet.Name),
                                    remediation: string.Format(Properties.Resources.RemovedValueFromPipelineRemediation,
                                        oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                            }

                            // If the parameter can no longer get its value from
                            // the pipeline by property name, log an issue
                            if (oldParameter.ValueFromPipelineByPropertyName && !newParameter.ValueFromPipelineByPropertyName)
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: cmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.ValueFromPipelineByPropertyName,
                                    description: string.Format(Properties.Resources.RemovedValueFromPipelineByPropertyNameDescription,
                                        oldParameter.ParameterMetadata.Name, oldParameterSet.Name, cmdlet.Name),
                                    remediation: string.Format(Properties.Resources.RemovedValueFromPipelineByPropertyNameRemediation,
                                        oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                            }
                        }
                        // If the parameter cannot be found, log an issue
                        else
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.RemovedParameterFromParameterSet,
                                description: string.Format(Properties.Resources.RemovedParameterFromParameterSetDescription,
                                    oldParameter.ParameterMetadata.Name, cmdlet.Name, oldParameterSet.Name),
                                remediation: string.Format(Properties.Resources.RemovedParameterFromParameterSetRemediation,
                                    oldParameter.ParameterMetadata.Name, oldParameterSet.Name));
                        }
                    }
                }
                // If the parameter set cannot be found, and the parameter set
                // was not the default (no parameter set) name, log an issue
                else if (!parameterSetDictionary.ContainsKey(oldParameterSet.Name) &&
                            !oldParameterSet.Name.Equals("__AllParameterSets"))
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedParameterSet,
                        description: string.Format(Properties.Resources.RemovedParameterSetDescription,
                            oldParameterSet.Name, cmdlet.Name),
                        remediation: string.Format(Properties.Resources.RemovedParameterSetRemediation,
                            oldParameterSet.Name, cmdlet.Name));
                }
            }
        }
    }
}
