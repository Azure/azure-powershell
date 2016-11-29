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

                    // If the types are the same, compare their properties
                    if (oldPropertyType.Equals(newPropertyType, StringComparison.OrdinalIgnoreCase))
                    {
                        // If we have not previously seen this type, run this
                        // method on the type
                        if (!_typeSet.Contains(oldPropertyType))
                        {
                            _typeSet.Add(oldPropertyType);

                            var oldTypeMetadata = _oldTypeDictionary[oldPropertyType];
                            var newTypeMetadata = _newTypeDictionary[newPropertyType];

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
    }
}
