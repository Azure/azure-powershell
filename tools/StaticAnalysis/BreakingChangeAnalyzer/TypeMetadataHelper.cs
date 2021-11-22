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

using StaticAnalysis.BreakingChangeAnalyzer;
#if NETSTANDARD
using StaticAnalysis.Netcore.Properties;
#else
using StaticAnalysis.Properties;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Common.Loggers;
using Tools.Common.Models;

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
        public bool CompareTypeMetadata(
            CmdletMetadata cmdlet,
            TypeMetadata oldType,
            TypeMetadata newType,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            var result = true;

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

                    // Define variables for logging
                    int problemId = ProblemIds.BreakingChangeProblemId.ChangedElementType;
                    string description = string.Format(Resources.ChangedElementTypeDescription,
                                            oldProperty, oldTypeMetadata.ElementType, newTypeMetadata.ElementType);
                    string remediation = string.Format(Resources.ChangedElementTypeRemediation,
                                            oldProperty, oldTypeMetadata.ElementType);

                    // If the type is an array, check for any breaking changes
                    if (IsElementType(cmdlet, oldTypeMetadata, newTypeMetadata, problemId, description, remediation, issueLogger))
                    {
                        continue;
                    }

                    string target = string.Format("property {0}", oldProperty);

                    // If the type is a generic, check for any breaking changes
                    if (IsGenericType(cmdlet, oldTypeMetadata, newTypeMetadata, target, issueLogger))
                    {
                        continue;
                    }

                    oldPropertyType = oldTypeMetadata.GetClassNameWithoutApiVersion(oldPropertyType);
                    newPropertyType = newTypeMetadata.GetClassNameWithoutApiVersion(newPropertyType);
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
                        issueLogger?.LogBreakingChangeIssue(
                            cmdlet: cmdlet,
                            severity: 0,
                            problemId: ProblemIds.BreakingChangeProblemId.ChangedPropertyType,
                            description: string.Format(Resources.ChangedPropertyTypeDescription,
                                oldProperty, oldType.Name, oldPropertyType, newPropertyType),
                            remediation: string.Format(Resources.ChangedPropertyTypeRemediation,
                                oldProperty, oldPropertyType));
                        result = false;
                    }
                }
                else
                {
                    // If the property has been removed, log an issue
                    issueLogger?.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: ProblemIds.BreakingChangeProblemId.RemovedProperty,
                        description: string.Format(Resources.RemovedPropertyDescription,
                            oldProperty, oldType.Name),
                        remediation: string.Format(Resources.RemovedPropertyRemediation,
                            oldProperty, oldType.Name));
                    result = false;
                }
            }

            return result;
        }

        public void CompareMethodSignatures(
            CmdletMetadata cmdlet,
            List<TypeMetadata.MethodSignature> oldMethods,
            List<TypeMetadata.MethodSignature> newMethods,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            foreach (var oldMethod in oldMethods)
            {
                bool found = false;
                var candidateMethods = newMethods.Where(m => string.Equals(m.Name, oldMethod.Name)).ToList();
                foreach (var newMethod in candidateMethods)
                {
                    var oldParameters = oldMethod.Parameters;
                    var newParameters = newMethod.Parameters;
                    if (oldParameters.Count != newParameters.Count)
                    {
                        continue;
                    }

                    bool match = true;
                    for (int idx = 0; idx < oldParameters.Count; idx++)
                    {
                        var oldParameter = oldParameters[idx];
                        var newParameter = newParameters[idx];
                        if (oldParameter.Name != newParameter.Name || oldParameter.Type != newParameter.Type)
                        {
                            match = false;
                            break;
                        }
                    }

                    if (oldMethod.ReturnType != null && newMethod.ReturnType != null && !string.Equals(oldMethod.ReturnType, newMethod.ReturnType))
                    {
                        match = false;
                    }

                    if (match)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    issueLogger?.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: 0,
                        description: string.Empty,
                        remediation: string.Empty);
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
            CmdletMetadata cmdlet,
            ParameterMetadata parameter,
            TypeMetadata oldTypeMetadata,
            TypeMetadata newTypeMetadata,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            int problemId = ProblemIds.BreakingChangeProblemId.ChangedParameterElementType;
            string description = string.Format(Resources.ChangedParameterElementTypeDescription,
                                    parameter.Name, oldTypeMetadata.ElementType, newTypeMetadata.ElementType);
            string remediation = string.Format(Resources.ChangedParameterElementTypeRemediation,
                                    parameter.Name, oldTypeMetadata.ElementType);

            // If the type is an array, check for any breaking changes
            if (IsElementType(cmdlet, oldTypeMetadata, newTypeMetadata, problemId, description, remediation, issueLogger))
            {
                return;
            }

            string target = string.Format("parameter {0}", parameter.Name);

            // If the type is a generic, check for any breaking changes
            if (IsGenericType(cmdlet, oldTypeMetadata, newTypeMetadata, target, issueLogger))
            {
                return;
            }

            // If the types are different, log an issue
            string oldTypeName = oldTypeMetadata.GetClassNameWithoutApiVersion(oldTypeMetadata.Name);
            string newTypeName = newTypeMetadata.GetClassNameWithoutApiVersion(newTypeMetadata.Name);
            if (!oldTypeName.Equals(newTypeName, StringComparison.OrdinalIgnoreCase))
            {
                issueLogger?.LogBreakingChangeIssue(
                    cmdlet: cmdlet,
                    severity: 0,
                    problemId: ProblemIds.BreakingChangeProblemId.ChangedParameterType,
                    description: string.Format(Resources.ChangedParameterTypeDescription,
                        cmdlet.Name, oldTypeMetadata.Name, parameter.Name),
                    remediation: string.Format(Resources.ChangedParameterTypeRemediation,
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
            CmdletMetadata cmdlet,
            TypeMetadata oldTypeMetadata,
            TypeMetadata newTypeMetadata,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            int problemId = ProblemIds.BreakingChangeProblemId.ChangedOutputElementType;
            string description = string.Format(Resources.ChangedOutputElementTypeDescription,
                                    oldTypeMetadata.ElementType, newTypeMetadata.ElementType);
            string remediation = string.Format(Resources.ChangedOutputElementTypeRemediation,
                                    oldTypeMetadata.ElementType);

            // If the type is an array, check for any breaking changes
            if (IsElementType(cmdlet, oldTypeMetadata, newTypeMetadata, problemId, description, remediation, issueLogger))
            {
                return;
            }

            string target = "output type";

            if (IsGenericType(cmdlet, oldTypeMetadata, newTypeMetadata, target, issueLogger))
            {
                return;
            }

            CompareTypeMetadata(cmdlet, oldTypeMetadata, newTypeMetadata, issueLogger);
        }


        /// <summary>
        /// Check if the given types are arrays, and if so, see if their element types are the same. If not, log an issue.
        /// </summary>
        /// <param name="cmdlet">The cmdlet metadata currently being checked.</param>
        /// <param name="oldTypeMetadata">The type metadata from the old (serialized) assembly.</param>
        /// <param name="newTypeMetadata">The type metadata from the new assembly.</param>
        /// <param name="problemId">The problemId used for logging if there is an issue.</param>
        /// <param name="description">The description used for logging if there is an issue.</param>
        /// <param name="remediation">The remediation used for logging if there is an issue.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private bool IsElementType(
            CmdletMetadata cmdlet,
            TypeMetadata oldTypeMetadata,
            TypeMetadata newTypeMetadata,
            int problemId,
            string description,
            string remediation,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // Check if the type is an array
            if (oldTypeMetadata.ElementType != null && newTypeMetadata.ElementType != null)
            {
                string oldTypeName = oldTypeMetadata.GetClassNameWithoutApiVersion(oldTypeMetadata.ElementType);
                string newTypeName = newTypeMetadata.GetClassNameWithoutApiVersion(newTypeMetadata.ElementType);
                // Check if the element of the array is the same in the old and new metadata
                if (oldTypeName.Equals(newTypeName, StringComparison.OrdinalIgnoreCase))
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
                    issueLogger?.LogBreakingChangeIssue(
                        cmdlet: cmdlet,
                        severity: 0,
                        problemId: problemId,
                        description: description,
                        remediation: remediation);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the given types are generics, and if so, see if their generic properties are the same. If not, log an issue.
        /// </summary>
        /// <param name="cmdlet">The cmdlet metadata currently being checked.</param>
        /// <param name="oldTypeMetadata">The type metadata from the old (serialized) assembly.</param>
        /// <param name="newTypeMetadata">The type metadata from the new assembly.</param>
        /// <param name="target">Target of the generic type breaking change.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        /// <returns></returns>
        private bool IsGenericType(
            CmdletMetadata cmdlet,
            TypeMetadata oldTypeMetadata,
            TypeMetadata newTypeMetadata,
            string target,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the type is a generic, check for any breaking changes
            if (oldTypeMetadata.GenericTypeArguments.Count > 0 && newTypeMetadata.GenericTypeArguments.Count > 0)
            {
                // Check if the generic type has changed
                if (HasSameGenericType(cmdlet, oldTypeMetadata, newTypeMetadata, target, issueLogger))
                {
                    // Check if the number of generic type arguments is the same
                    if (HasSameGenericArgumentSize(cmdlet, oldTypeMetadata, newTypeMetadata, target, issueLogger))
                    {
                        // For each element in the generic type arguments list,
                        // make sure that the types are the same
                        for (int idx = 0; idx < oldTypeMetadata.GenericTypeArguments.Count; idx++)
                        {
                            var oldArgument = oldTypeMetadata.GenericTypeArguments[idx];
                            var newArgument = newTypeMetadata.GenericTypeArguments[idx];

                            var oldElementType = _oldTypeDictionary[oldArgument];
                            var newElementType = _newTypeDictionary[newArgument];
                            if (string.Equals(oldArgument, newArgument, StringComparison.OrdinalIgnoreCase))
                            {
                                // If we have not previously seen this generic type argument,
                                // run this method on the type
                                if (!_typeSet.Contains(oldArgument))
                                {
                                    _typeSet.Add(oldArgument);
                                    CompareTypeMetadata(cmdlet, oldElementType, newElementType, issueLogger);
                                }
                            }
                            else
                            {
                                // If the generic type arguments have changed, throw a specific exception for generics
                                if (!CompareTypeMetadata(cmdlet, oldElementType, newElementType, issueLogger))
                                {
                                    // If the generic type arguments aren't the same, log an issue
                                    issueLogger?.LogBreakingChangeIssue(
                                        cmdlet: cmdlet,
                                        severity: 0,
                                        problemId: ProblemIds.BreakingChangeProblemId.ChangedGenericTypeArgument,
                                        description: string.Format(Resources.ChangedGenericTypeArgumentDescription,
                                            target, oldArgument, newArgument),
                                        remediation: string.Format(Resources.ChangedGenericTypeArgumentRemediation,
                                            target, oldArgument));
                                }
                            }
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the type of the generic is the same for two generics. If not, log an issue.
        /// </summary>
        /// <param name="cmdlet">The cmdlet metadata currently being checked.</param>
        /// <param name="oldTypeMetadata">The type metadata from the old (serialized) assembly.</param>
        /// <param name="newTypeMetadata">The type metadata from the new assembly.</param>
        /// <param name="target">Target of the generic type breaking change..</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        private bool HasSameGenericType(
            CmdletMetadata cmdlet,
            TypeMetadata oldTypeMetadata,
            TypeMetadata newTypeMetadata,
            string target,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the type of the generics are the same, return true
            string oldTypeName = oldTypeMetadata.GetClassNameWithoutApiVersion(oldTypeMetadata.Name);
            string newTypeName = newTypeMetadata.GetClassNameWithoutApiVersion(newTypeMetadata.Name);
            if (oldTypeName.Equals(newTypeName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // Otherwise, log an issue and return false
            issueLogger?.LogBreakingChangeIssue(
                cmdlet: cmdlet,
                severity: 0,
                problemId: ProblemIds.BreakingChangeProblemId.ChangedGenericType,
                description: string.Format(Resources.ChangedGenericTypeDescription,
                    target, oldTypeMetadata.Name, newTypeMetadata.Name),
                remediation: string.Format(Resources.ChangedGenericTypeRemediation,
                    target, oldTypeMetadata.Name));

            return false;
        }

        /// <summary>
        /// Check if the argument size for the generics are the same. If they are not, log an issue.
        /// </summary>
        /// <param name="cmdlet">The cmdlet metadata currently being checked.</param>
        /// <param name="oldTypeMetadata">The type metadata from the old (serialized) assembly.</param>
        /// <param name="newTypeMetadata">The type metadata from the new assembly.</param>
        /// <param name="target">Target of the generic type breaking change.</param>
        /// <param name="issueLogger">ReportLogger that will keep track of issues found.</param>
        /// <returns></returns>
        private bool HasSameGenericArgumentSize(
            CmdletMetadata cmdlet,
            TypeMetadata oldTypeMetadata,
            TypeMetadata newTypeMetadata,
            string target,
            ReportLogger<BreakingChangeIssue> issueLogger)
        {
            // If the arguments are the same size, return true
            if (oldTypeMetadata.GenericTypeArguments.Count == newTypeMetadata.GenericTypeArguments.Count)
            {
                return true;
            }

            // Otherwise, log an issue and return false
            issueLogger?.LogBreakingChangeIssue(
                cmdlet: cmdlet,
                severity: 0,
                problemId: ProblemIds.BreakingChangeProblemId.DifferentGenericTypeArgumentSize,
                description: string.Format(Resources.DifferentGenericTypeArgumentSizeDescription,
                    oldTypeMetadata.Name, target, oldTypeMetadata.GenericTypeArguments.Count,
                    newTypeMetadata.GenericTypeArguments.Count),
                remediation: string.Format(Resources.DifferentGenericTypeArgumentSizeRemediation,
                    oldTypeMetadata.Name, oldTypeMetadata.GenericTypeArguments.Count));

            return false;
        }
    }
}
