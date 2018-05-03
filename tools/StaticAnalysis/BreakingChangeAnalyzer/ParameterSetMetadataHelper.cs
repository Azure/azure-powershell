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
using Tools.Common.Loggers;
using Tools.Common.Models;

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
            CmdletMetadata cmdlet,
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
                bool foundMatch = false;

                // Find matching parameter set
                foreach (var newParameterSet in newParameterSets)
                {
                    Dictionary<string, Parameter> parameterDictionary = new Dictionary<string, Parameter>();
                    foreach (var parameter in newParameterSet.Parameters)
                    {
                        parameterDictionary.Add(parameter.ParameterMetadata.Name, parameter);
                        foreach (var alias in parameter.ParameterMetadata.AliasList)
                        {
                            parameterDictionary.Add(alias, parameter);
                        }
                    }

                    // Check if set has minimum parameters required to match
                    bool minimumRequired = true;
                    foreach (var parameter in oldParameterSet.Parameters)
                    {
                        if (!parameterDictionary.ContainsKey(parameter.ParameterMetadata.Name))
                        {
                            minimumRequired = false;
                            break;
                        }
                        else
                        {
                            var newParameter = parameterDictionary[parameter.ParameterMetadata.Name];
                            if (!parameter.Mandatory && newParameter.Mandatory ||
                                parameter.Position >= 0 && parameter.Position != newParameter.Position ||
                                parameter.ValueFromPipeline && !newParameter.ValueFromPipeline ||
                                parameter.ValueFromPipelineByPropertyName && !newParameter.ValueFromPipelineByPropertyName)
                            {
                                minimumRequired = false;
                                break;
                            }
                        }
                    }

                    if (!minimumRequired)
                    {
                        continue;
                    }

                    parameterDictionary = new Dictionary<string, Parameter>();
                    foreach (var parameter in oldParameterSet.Parameters)
                    {
                        parameterDictionary.Add(parameter.ParameterMetadata.Name, parameter);
                        foreach (var alias in parameter.ParameterMetadata.AliasList)
                        {
                            parameterDictionary.Add(alias, parameter);
                        }
                    }

                    // Check if set has any additional mandatory parameters
                    bool foundAdditional = false;
                    foreach (var parameter in newParameterSet.Parameters)
                    {
                        if (parameterDictionary.ContainsKey(parameter.ParameterMetadata.Name))
                        {
                            continue;
                        }

                        if (parameter.Mandatory)
                        {
                            foundAdditional = true;
                            break;
                        }
                    }

                    if (!foundAdditional)
                    {
                        foundMatch = true;
                        break;
                    }
                }

                if (!foundMatch)
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
