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
    /// This class is responsible for comparing ParameterMetadata and checking
    /// for breaking changes between old (serialized) metadata and new metadata.
    /// </summary>
    public class ParameterMetadataHelper
    {
        private TypeMetadataHelper _typeMetadataHelper;

        public ParameterMetadataHelper()
        {
            _typeMetadataHelper = new TypeMetadataHelper();
        }

        public ParameterMetadataHelper(TypeMetadataHelper typeMetadataHelper)
        {
            _typeMetadataHelper = typeMetadataHelper;
        }

        /// <summary>
        /// Compares the metadata of parameters with the same name (or alias) for any breaking changes.
        /// 
        /// Breaking changes for parameters include
        ///   - Removing a parameter
        ///   - Removing an alias to a parameter
        ///   - Type (or any of its properties) of parameter has changed
        ///   - A value in the validate set of a parameter has been removed
        ///   - ValidateNotNullOrEmpty attribute has been added to a parameter
        /// </summary>
        /// <param name="cmdlet">Reference to the cmdlet whose parameters are being checked.</param>
        /// <param name="oldParameters">The list of parameters from the old cmdlet metadata.</param>
        /// <param name="newParameters">The list of parameters from the new cmdlet metadata.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of the issues found.</param>
        public void CompareParameterMetadata(
            CmdletBreakingChangeMetadata cmdlet,
            List<ParameterMetadata> oldParameters,
            List<ParameterMetadata> newParameters,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // This dictionary will map a parameter name (or alias) to the corresponding metadata
            Dictionary<string, ParameterMetadata> parameterDictionary = new Dictionary<string, ParameterMetadata>();

            // For each parameter, add its name (and aliases) to the dictionary
            foreach (var newParameter in newParameters)
            {
                parameterDictionary.Add(newParameter.Name, newParameter);

                foreach (var alias in newParameter.AliasList)
                {
                    parameterDictionary.Add(alias, newParameter);
                }
            }

            // For each parameter in the old metadata, see if it has been
            // added to the dictionary (exists in the new metadata)
            foreach (var oldParameter in oldParameters)
            {
                if (parameterDictionary.ContainsKey(oldParameter.Name))
                {
                    var newParameter = parameterDictionary[oldParameter.Name];

                    // Go through all of the breaking change checks for parameters
                    CheckForChangedParameterType(cmdlet, oldParameter, newParameter, issueLogger);
                    CheckForRemovedParameterAlias(cmdlet, oldParameter, newParameter, issueLogger);
                    CheckParameterValidationSets(cmdlet, oldParameter, newParameter, issueLogger);
                    CheckForValidateNotNullOrEmpty(cmdlet, oldParameter, newParameter, issueLogger);
                    CheckParameterValidateRange(cmdlet, oldParameter, newParameter, issueLogger);
                }
                // If the parameter cannot be found, log an issue
                else
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedParameter,
                        description: string.Format(Properties.Resources.RemovedParameterDescription,
                            cmdlet.Name, oldParameter.Name),
                        remediation: string.Format(Properties.Resources.RemovedParameterRemediation,
                            oldParameter.Name, cmdlet.Name));
                }
            }
        }

        /// <summary>
        /// Check if the type for a parameter has been changed, or if any of the
        /// type's properties have been removed or changed.
        /// </summary>
        /// <param name="cmdlet">The cmdlet whose parameter metadata is currently being checked.</param>
        /// <param name="oldParameter">The parameter metadata from the old (serialized) assembly.</param>
        /// <param name="newParameter">The parameter metadata from new assembly</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForChangedParameterType(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // Recursively look at the properties of each type and their
            // types to see if there are any breaking changes
            _typeMetadataHelper.CheckParameterType(cmdlet, oldParameter, oldParameter.Type, newParameter.Type, issueLogger);
        }

        /// <summary>
        /// Check if an alias to a parameter has been removed.
        /// </summary>
        /// <param name="cmdlet">The cmdlet whose parameter metadata is currently being checked.</param>
        /// <param name="oldParameter">The parameter metadata from the old (serialized) assembly.</param>
        /// <param name="newParameter">The parameter metadata from new assembly</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForRemovedParameterAlias(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // This set will contain all of the aliases in the new metadata
            HashSet<string> aliasSet = new HashSet<string>();

            // Add each of the aliases from the parameter in the new metadata
            foreach (var newAlias in newParameter.AliasList)
            {
                aliasSet.Add(newAlias);
            }

            // For each alias from the parameter in the old metadata,
            // see if it exists in the new metadata
            foreach (var oldAlias in oldParameter.AliasList)
            {
                // If the alias cannot be found, log an issue
                if (!aliasSet.Contains(oldAlias))
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedParameterAlias,
                        description: string.Format(Properties.Resources.RemovedParameterAliasDescription,
                            cmdlet.Name, oldAlias, oldParameter.Name),
                        remediation: string.Format(Properties.Resources.RemovedParameterAliasRemediation,
                            oldAlias, oldParameter.Name));
                }
            }
        }

        /// <summary>
        /// Check for any values that were removed from a validation set of a parameter.
        /// </summary>
        /// <param name="cmdlet">The cmdlet whose parameter metadata is currently being checked.</param>
        /// <param name="oldParameter">The parameter metadata from the old (serialized) assembly.</param>
        /// <param name="newParameter">The parameter metadata from new assembly</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckParameterValidationSets(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var oldValidateSet = oldParameter.ValidateSet;
            var newValidateSet = newParameter.ValidateSet;

            // If there is no validate set in the new assembly, return
            if (newValidateSet.Count == 0)
            {
                return;
            }

            // If there was no validate set in the old assembly, but there is
            // one in the new assembly, log an issue
            if (oldValidateSet.Count == 0 && newValidateSet.Count > 0)
            {
                issueLogger.LogBreakingChangeIssue(
                    cmdlet: cmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.AddedValidateSet,
                    description: string.Format(Properties.Resources.AddedValidateSetDescription,
                        oldParameter.Name, cmdlet.Name),
                    remediation: string.Format(Properties.Resources.AddedValidateSetRemediation,
                        oldParameter.Name));

                return;
            }

            // This set will contain all of the values in the validate set from the new metadata
            HashSet<string> valueSet = new HashSet<string>();

            // Add each value in the validate set from the new metadata to the set
            foreach (var newValue in newValidateSet)
            {
                valueSet.Add(newValue);
            }

            // For each value in the validate set from the old metadata, check if
            // it exists in the new metadata
            foreach (var oldValue in oldValidateSet)
            {
                // If the value cannot be found, log an issue
                if (!valueSet.Contains(oldValue))
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedValidateSetValue,
                        description: string.Format(Properties.Resources.RemovedValidateSetValueDescription,
                            oldParameter.Name, cmdlet.Name, oldValue),
                        remediation: string.Format(Properties.Resources.RemovedValidateSetValueRemediation,
                            oldValue, oldParameter.Name));
                }
            }            
        }

        /// <summary>
        /// Check if the parameter gained a validation range for values, or if the
        /// existing validation range for values excludes values previously accepted.
        /// </summary>
        /// <param name="cmdlet">The cmdlet whose parameter metadata is currently being checked.</param>
        /// <param name="oldParameter">The parameter metadata from the old (serialized) assembly.</param>
        /// <param name="newParameter">The parameter metadata from new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of the issues found.</param>
        private void CheckParameterValidateRange(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            if (newParameter.ValidateRangeMin != null && newParameter.ValidateRangeMax != null)
            {
                // If the old parameter had no validation range, but the new parameter does, log an issue
                if (oldParameter.ValidateRangeMin == null && oldParameter.ValidateRangeMax == null)
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.AddedValidateRange ,
                        description: string.Format(Properties.Resources.AddedValidateRangeDescription,
                            oldParameter.Name, cmdlet.Name),
                        remediation: string.Format(Properties.Resources.AddedValidateRangeRemediation,
                            oldParameter.Name));
                }
                else
                {
                    // If the minimum value of the range has increased, log an issue
                    if (oldParameter.ValidateRangeMin < newParameter.ValidateRangeMin)
                    {
                        issueLogger.LogBreakingChangeIssue(
                            cmdlet: cmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.ChangedValidateRangeMinimum,
                            description: string.Format(Properties.Resources.ChangedValidateRangeMinimumDescription,
                                oldParameter.Name, oldParameter.ValidateRangeMin, newParameter.ValidateRangeMin),
                            remediation: string.Format(Properties.Resources.ChangedValidateRangeMinimumRemediation,
                                oldParameter.Name, oldParameter.ValidateRangeMin));
                    }

                    // If the maximum value of the range has decreased, log an issue
                    if (oldParameter.ValidateRangeMax > newParameter.ValidateRangeMax)
                    {
                        issueLogger.LogBreakingChangeIssue(
                            cmdlet: cmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.ChangedValidateRangeMaximum,
                            description: string.Format(Properties.Resources.ChangedValidateRangeMaximumDescription,
                                oldParameter.Name, oldParameter.ValidateRangeMax, newParameter.ValidateRangeMax),
                            remediation: string.Format(Properties.Resources.ChangedValidateRangeMaximumRemediation,
                                oldParameter.Name, oldParameter.ValidateRangeMax));
                    }
                }
            }
        }

        /// <summary>
        /// Check if the parameter now supports the ValidateNotNullOrEmpty attribute
        /// </summary>
        /// <param name="cmdlet">The cmdlet whose parameter metadata is currently being checked.</param>
        /// <param name="oldParameter">The parameter metadata from the old (serialized) assembly.</param>
        /// <param name="newParameter">The parameter metadata from new assembly</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private void CheckForValidateNotNullOrEmpty(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata oldParameter,
            ParameterMetadata newParameter,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the parameter didn't have the ValidateNotNullOrEmpty attribute in the
            // old assembly, but has it in the new assembly, log an issue
            if (!oldParameter.ValidateNotNullOrEmpty && newParameter.ValidateNotNullOrEmpty)
            {
                issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.AddedValidateNotNullOrEmpty,
                        description: string.Format(Properties.Resources.AddedValidateNotNullOrEmptyDescription,
                            oldParameter.Name, cmdlet.Name),
                        remediation: string.Format(Properties.Resources.AddedValidateNotNullOrEmptyRemediation,
                            oldParameter.Name));
            }
        }

    }
}
