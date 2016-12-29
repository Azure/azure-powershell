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
    /// This class is responsible for comparing TypeMetadata and checking
    /// for breaking changes between old (serialized) metadata and new metadata.
    /// </summary>
    public class TypeMetadataHelper
    {
        private Dictionary<string, TypeMetadata> _oldTypeDictionary;
        private Dictionary<string, TypeMetadata> _newTypeDictionary;
        private HashSet<string> _typeSet;

        public TypeMetadataHelper()
        {
            _oldTypeDictionary = new Dictionary<string, TypeMetadata>();
            _newTypeDictionary = new Dictionary<string, TypeMetadata>();
            _typeSet = new HashSet<string>();
        }

        public TypeMetadataHelper(
            Dictionary<string, TypeMetadata> oldTypeDictionary,
            Dictionary<string, TypeMetadata> newTypeDictionary)
        {
            _oldTypeDictionary = oldTypeDictionary;
            _newTypeDictionary = newTypeDictionary;
            _typeSet = new HashSet<string>();
        }

        /// <summary>
        /// Compare two types by recursively checking their properties and property
        /// types, making sure that nothing has been removed or changed.
        /// </summary>
        /// <param name="cmdlet">The cmdlet metadata currently being checked.</param>
        /// <param name="oldType">The type metadata from the old (serialized) assembly.</param>
        /// <param name="newType">The type metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        public void CompareTypeMetadata(
            CmdletBreakingChangeMetadata cmdlet,
            TypeMetadata oldType,
            TypeMetadata newType,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // For each property in the old assembly type, find the corresponding
            // property in the new assembly type
            foreach (var oldProperty in oldType.Properties.Keys)
            {
                if (newType.Properties.ContainsKey(oldProperty))
                {
                    var oldPropertyType = oldType.Properties[oldProperty];
                    var newPropertyType = newType.Properties[oldProperty];

                    var oldTypeMetadata = _oldTypeDictionary[oldPropertyType];
                    var newTypeMetadata = _newTypeDictionary[newPropertyType];

                    // Check if the type is an array
                    if (oldTypeMetadata.ElementType != null && newTypeMetadata.ElementType != null)
                    {
                        // Check if the element of the array is the same in the old and new metadata
                        if (oldTypeMetadata.ElementType.Equals(newTypeMetadata.ElementType, StringComparison.OrdinalIgnoreCase))
                        {
                            // If we have not previously seen this element type,
                            // run this method on the type
                            if (!_typeSet.Contains(oldTypeMetadata.ElementType))
                            {
                                _typeSet.Add(oldTypeMetadata.ElementType);

                                var oldElementType = _oldTypeDictionary[oldTypeMetadata.ElementType];
                                var newElementType = _newTypeDictionary[newTypeMetadata.ElementType];

                                CompareTypeMetadata(cmdlet, oldElementType, newElementType, issueLogger);
                            }
                        }
                        // If the element type has changed, log an issue
                        else
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.ChangedElementType,
                                description: string.Format(Properties.Resources.ChangedElementTypeDescription,
                                    oldProperty, oldTypeMetadata.ElementType, newTypeMetadata.ElementType),
                                remediation: string.Format(Properties.Resources.ChangedElementTypeRemediation,
                                    oldProperty, oldTypeMetadata.ElementType));
                        }

                        continue;
                    }

                    // Check if the type is a generic
                    if (oldTypeMetadata.GenericTypeArguments.Count > 0 && newTypeMetadata.GenericTypeArguments.Count > 0)
                    {
                        // Check if the generic type has changed
                        if (oldTypeMetadata.Name.Equals(newTypeMetadata.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            // Check if the number of generic type arguments is the same
                            if (oldTypeMetadata.GenericTypeArguments.Count == newTypeMetadata.GenericTypeArguments.Count)
                            {
                                // For each element in the generic type arguments list, make sure that the types
                                // are the same
                                for (int idx = 0; idx < oldTypeMetadata.GenericTypeArguments.Count; idx++)
                                {
                                    if (oldTypeMetadata.GenericTypeArguments[idx].Equals(newTypeMetadata.GenericTypeArguments[idx], StringComparison.OrdinalIgnoreCase))
                                    {
                                        // If we have not previously seen this generic type argument,
                                        // run this method on the type
                                        if (!_typeSet.Contains(oldTypeMetadata.GenericTypeArguments[idx]))
                                        {
                                            _typeSet.Add(oldTypeMetadata.GenericTypeArguments[idx]);

                                            var oldElementType = _oldTypeDictionary[oldTypeMetadata.GenericTypeArguments[idx]];
                                            var newElementType = _newTypeDictionary[newTypeMetadata.GenericTypeArguments[idx]];

                                            CompareTypeMetadata(cmdlet, oldElementType, newElementType, issueLogger);
                                        }
                                    }
                                    // If the generic type arguments aren't the same, log an issue
                                    else
                                    {
                                        issueLogger.LogBreakingChangeIssue(
                                            cmdlet: cmdlet,
                                            severity: 0,
                                            problemId: ProblemIds.BreakingChangeProblemId.ChangedGenericTypeArgument,
                                            description: string.Format(Properties.Resources.ChangedGenericTypeArgumentDescription,
                                                oldProperty,oldTypeMetadata.GenericTypeArguments[idx], newTypeMetadata.GenericTypeArguments[idx]),
                                            remediation: string.Format(Properties.Resources.ChangedGenericTypeArgumentRemediation,
                                                oldProperty, oldTypeMetadata.GenericTypeArguments[idx]));
                                    }
                                }
                            }
                            // If the number of generic type arguments is different, log an issue
                            else
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: cmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.DifferentGenericTypeArgumentSize,
                                    description: string.Format(Properties.Resources.DifferentGenericTypeArgumentSizeDescription,
                                        oldTypeMetadata.Name, oldProperty,
                                        oldTypeMetadata.GenericTypeArguments.Count, newTypeMetadata.GenericTypeArguments.Count),
                                    remediation: string.Format(Properties.Resources.DifferentGenericTypeArgumentSizeRemediation,
                                        oldTypeMetadata.Name, oldTypeMetadata.GenericTypeArguments.Count));
                            }
                        }
                        // If the generic type has changed, log an issue
                        else
                        {
                            issueLogger.LogBreakingChangeIssue(
                                cmdlet: cmdlet,
                                severity: 0,
                                problemId: ProblemIds.BreakingChangeProblemId.ChangedGenericType,
                                description: string.Format(Properties.Resources.ChangedGenericTypeDescription,
                                    oldProperty, oldTypeMetadata.Name, newTypeMetadata.Name),
                                remediation: string.Format(Properties.Resources.ChangedGenericTypeRemediation,
                                    oldProperty, oldTypeMetadata.Name));
                        }

                        continue;
                    }

                    // If the types are the same, compare their properties
                    if (oldPropertyType.Equals(newPropertyType, StringComparison.OrdinalIgnoreCase))
                    {
                        // If we have not previously seen this type, run this
                        // method on the type
                        if (!_typeSet.Contains(oldPropertyType))
                        {
                            _typeSet.Add(oldPropertyType);

                            CompareTypeMetadata(cmdlet, oldTypeMetadata, newTypeMetadata, issueLogger);
                        }
                    }
                    else
                    {
                        // If the type of the property has been changed, log an issue
                        issueLogger.LogBreakingChangeIssue(
                            cmdlet: cmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.ChangedPropertyType,
                            description: string.Format(Properties.Resources.ChangedPropertyTypeDescription,
                                oldProperty, oldType.Name, oldPropertyType, newPropertyType),
                            remediation: string.Format(Properties.Resources.ChangedPropertyTypeRemediation,
                                oldProperty, oldPropertyType));
                    }
                }
                else
                {
                    // If the property has been removed, log an issue
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedProperty,
                        description: string.Format(Properties.Resources.RemovedPropertyDescription,
                            oldProperty, oldType.Name),
                        remediation: string.Format(Properties.Resources.RemovedPropertyRemediation,
                            oldProperty, oldType.Name));
                }
            }
        }

        /// <summary>
        /// Checks if the type of the parameter is an array or a generic, and makes sure there are no breaking changes.
        /// If the type is not an array or a generic, it proceeds with the normal type checking with CompareTypeMetadata.
        /// </summary>
        /// <param name="cmdlet">The cmdlet whose parameter metadata is being checked for breaking changes.</param>
        /// <param name="parameter">The parameter whose type metadata is being checked for breaking changes.</param>
        /// <param name="oldTypeMetadata">The type metadata from the old (serialized) assembly.</param>
        /// <param name="newTypeMetadata">The type metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        public void CheckParameterType(
            CmdletBreakingChangeMetadata cmdlet,
            ParameterMetadata parameter,
            TypeMetadata oldTypeMetadata,
            TypeMetadata newTypeMetadata,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // Check if the type is an array
            if (oldTypeMetadata.ElementType != null && newTypeMetadata.ElementType != null)
            {
                // Check if the element of the array is the same in the old and new metadata
                if (oldTypeMetadata.ElementType.Equals(newTypeMetadata.ElementType, StringComparison.OrdinalIgnoreCase))
                {
                    // If we have not previously seen this element type,
                    // run this method on the type
                    if (!_typeSet.Contains(oldTypeMetadata.ElementType))
                    {
                        _typeSet.Add(oldTypeMetadata.ElementType);

                        var oldElementType = _oldTypeDictionary[oldTypeMetadata.ElementType];
                        var newElementType = _newTypeDictionary[newTypeMetadata.ElementType];

                        CompareTypeMetadata(cmdlet, oldElementType, newElementType, issueLogger);
                    }
                }
                // If the element type has changed, log an issue
                else
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.ChangedParameterElementType,
                        description: string.Format(Properties.Resources.ChangedParameterElementTypeDescription,
                            parameter.Name, oldTypeMetadata.ElementType, newTypeMetadata.ElementType),
                        remediation: string.Format(Properties.Resources.ChangedParameterElementTypeRemediation,
                            parameter.Name, oldTypeMetadata.ElementType));
                }

                return;
            }

            // Check if the type is a generic
            if (oldTypeMetadata.GenericTypeArguments.Count > 0 && newTypeMetadata.GenericTypeArguments.Count > 0)
            {
                // Check if the generic type has changed
                if (oldTypeMetadata.Name.Equals(newTypeMetadata.Name, StringComparison.OrdinalIgnoreCase))
                {
                    // Check if the number of generic type arguments is the same
                    if (oldTypeMetadata.GenericTypeArguments.Count == newTypeMetadata.GenericTypeArguments.Count)
                    {
                        // For each element in the generic type arguments list, make sure that the types
                        // are the same
                        for (int idx = 0; idx < oldTypeMetadata.GenericTypeArguments.Count; idx++)
                        {
                            if (oldTypeMetadata.GenericTypeArguments[idx].Equals(newTypeMetadata.GenericTypeArguments[idx], StringComparison.OrdinalIgnoreCase))
                            {
                                // If we have not previously seen this generic type argument,
                                // run this method on the type
                                if (!_typeSet.Contains(oldTypeMetadata.GenericTypeArguments[idx]))
                                {
                                    _typeSet.Add(oldTypeMetadata.GenericTypeArguments[idx]);

                                    var oldElementType = _oldTypeDictionary[oldTypeMetadata.GenericTypeArguments[idx]];
                                    var newElementType = _newTypeDictionary[newTypeMetadata.GenericTypeArguments[idx]];

                                    CompareTypeMetadata(cmdlet, oldElementType, newElementType, issueLogger);
                                }
                            }
                            // If the generic type arguments aren't the same, log an issue
                            else
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: cmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.ChangedParameterGenericTypeArgument,
                                    description: string.Format(Properties.Resources.ChangedParameterGenericTypeArgumentDescription,
                                        parameter.Name, oldTypeMetadata.GenericTypeArguments[idx], newTypeMetadata.GenericTypeArguments[idx]),
                                    remediation: string.Format(Properties.Resources.ChangedParameterGenericTypeArgumentRemediation,
                                        parameter.Name, oldTypeMetadata.GenericTypeArguments[idx]));
                            }
                        }
                    }
                    // If the number of generic type arguments is different, log an issue
                    else
                    {
                        issueLogger.LogBreakingChangeIssue(
                            cmdlet: cmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.DifferentParameterGenericTypeArgumentSize,
                            description: string.Format(Properties.Resources.DifferentParameterGenericTypeArgumentSizeDescription,
                                oldTypeMetadata.Name, parameter.Name,
                                oldTypeMetadata.GenericTypeArguments.Count, newTypeMetadata.GenericTypeArguments.Count),
                            remediation: string.Format(Properties.Resources.DifferentParameterGenericTypeArgumentSizeRemediation,
                                oldTypeMetadata.Name, oldTypeMetadata.GenericTypeArguments.Count));
                    }
                }
                // If the generic type has changed, log an issue
                else
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.ChangedParameterGenericType,
                        description: string.Format(Properties.Resources.ChangedParameterGenericTypeDescription,
                            parameter.Name, oldTypeMetadata.Name, newTypeMetadata.Name),
                        remediation: string.Format(Properties.Resources.ChangedParameterGenericTypeRemediation,
                            parameter.Name, oldTypeMetadata.Name));
                }

                return;
            }

            // If the types are different, log an issue
            if (!oldTypeMetadata.Name.Equals(newTypeMetadata.Name, StringComparison.OrdinalIgnoreCase))
            {
                issueLogger.LogBreakingChangeIssue(
                    cmdlet: cmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.ChangedParameterType,
                    description: string.Format(Properties.Resources.ChangedParameterTypeDescription,
                        cmdlet.Name, oldTypeMetadata.Name, parameter.Name),
                    remediation: string.Format(Properties.Resources.ChangedParameterTypeRemediation,
                        parameter.Name, oldTypeMetadata.Name));
            }
            else
            {
                CompareTypeMetadata(cmdlet, oldTypeMetadata, newTypeMetadata, issueLogger);
            }            
        }

        /// <summary>
        /// Checks if the type of the output is an array or a generic, and makes sure there are no breaking changes.
        /// If the type is not an array or a generic, it proceeds with the normal type checking with CompareTypeMetadata.
        /// </summary>
        /// <param name="cmdlet">The cmdlet whose output metadata is being checked for breaking changes.</param>
        /// <param name="oldTypeMetadata">The type metadata from the old (serialized) assembly.</param>
        /// <param name="newTypeMetadata">The type metadata from the new assembly.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        public void CheckOutputType(
            CmdletBreakingChangeMetadata cmdlet,
            TypeMetadata oldTypeMetadata,
            TypeMetadata newTypeMetadata,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // Check if the type is an array
            if (oldTypeMetadata.ElementType != null && newTypeMetadata.ElementType != null)
            {
                // Check if the element of the array is the same in the old and new metadata
                if (oldTypeMetadata.ElementType.Equals(newTypeMetadata.ElementType, StringComparison.OrdinalIgnoreCase))
                {
                    // If we have not previously seen this element type,
                    // run this method on the type
                    if (!_typeSet.Contains(oldTypeMetadata.ElementType))
                    {
                        _typeSet.Add(oldTypeMetadata.ElementType);

                        var oldElementType = _oldTypeDictionary[oldTypeMetadata.ElementType];
                        var newElementType = _newTypeDictionary[newTypeMetadata.ElementType];

                        CompareTypeMetadata(cmdlet, oldElementType, newElementType, issueLogger);
                    }
                }
                // If the element type has changed, log an issue
                else
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.ChangedOutputElementType,
                        description: string.Format(Properties.Resources.ChangedOutputElementTypeDescription,
                            oldTypeMetadata.ElementType, newTypeMetadata.ElementType),
                        remediation: string.Format(Properties.Resources.ChangedOutputElementTypeRemediation,
                            oldTypeMetadata.ElementType));
                }

                return;
            }

            // Check if the type is a generic
            if (oldTypeMetadata.GenericTypeArguments.Count > 0 && newTypeMetadata.GenericTypeArguments.Count > 0)
            {
                // Check if the generic type has changed
                if (oldTypeMetadata.Name.Equals(newTypeMetadata.Name, StringComparison.OrdinalIgnoreCase))
                {
                    // Check if the number of generic type arguments is the same
                    if (oldTypeMetadata.GenericTypeArguments.Count == newTypeMetadata.GenericTypeArguments.Count)
                    {
                        // For each element in the generic type arguments list, make sure that the types
                        // are the same
                        for (int idx = 0; idx < oldTypeMetadata.GenericTypeArguments.Count; idx++)
                        {
                            if (oldTypeMetadata.GenericTypeArguments[idx].Equals(newTypeMetadata.GenericTypeArguments[idx], StringComparison.OrdinalIgnoreCase))
                            {
                                // If we have not previously seen this generic type argument,
                                // run this method on the type
                                if (!_typeSet.Contains(oldTypeMetadata.GenericTypeArguments[idx]))
                                {
                                    _typeSet.Add(oldTypeMetadata.GenericTypeArguments[idx]);

                                    var oldElementType = _oldTypeDictionary[oldTypeMetadata.GenericTypeArguments[idx]];
                                    var newElementType = _newTypeDictionary[newTypeMetadata.GenericTypeArguments[idx]];

                                    CompareTypeMetadata(cmdlet, oldElementType, newElementType, issueLogger);
                                }
                            }
                            // If the generic type arguments aren't the same, log an issue
                            else
                            {
                                issueLogger.LogBreakingChangeIssue(
                                    cmdlet: cmdlet,
                                    severity: 0,
                                    problemId: ProblemIds.BreakingChangeProblemId.ChangedOutputGenericTypeArgument,
                                    description: string.Format(Properties.Resources.ChangedOutputGenericTypeArgumentDescription,
                                        oldTypeMetadata.GenericTypeArguments[idx], newTypeMetadata.GenericTypeArguments[idx]),
                                    remediation: string.Format(Properties.Resources.ChangedOutputGenericTypeArgumentRemediation,
                                        oldTypeMetadata.GenericTypeArguments[idx]));
                            }
                        }
                    }
                    // If the number of generic type arguments is different, log an issue
                    else
                    {
                        issueLogger.LogBreakingChangeIssue(
                            cmdlet: cmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.DifferentOutputGenericTypeArgumentSize,
                            description: string.Format(Properties.Resources.DifferentOutputGenericTypeArgumentSizeDescription,
                                oldTypeMetadata.Name,
                                oldTypeMetadata.GenericTypeArguments.Count, newTypeMetadata.GenericTypeArguments.Count),
                            remediation: string.Format(Properties.Resources.DifferentOutputGenericTypeArgumentSizeRemediation,
                                oldTypeMetadata.Name, oldTypeMetadata.GenericTypeArguments.Count));
                    }
                }
                // If the generic type has changed, log an issue
                else
                {
                    issueLogger.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.ChangedOutputGenericType,
                        description: string.Format(Properties.Resources.ChangedOutputGenericTypeDescription,
                            oldTypeMetadata.Name, newTypeMetadata.Name),
                        remediation: string.Format(Properties.Resources.ChangedOutputGenericTypeRemediation,
                            oldTypeMetadata.Name));
                }

                return;
            }

            CompareTypeMetadata(cmdlet, oldTypeMetadata, newTypeMetadata, issueLogger);
        }
    }
}
