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

using Microsoft.Azure.Management.Blueprint.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSPolicyAssignmentArtifact : PSArtifact
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<string> DependsOn { get; set; }
        public string PolicyDefinitionId { get; set; }
        public IDictionary<string, PSParameterValueBase> Parameters { get; set; }
        public string ResourceGroup { get; set; }

        internal static PSPolicyAssignmentArtifact FromArtifactModel(PolicyAssignmentArtifact artifact, string scope)
        {
            var psArtifact = new PSPolicyAssignmentArtifact
            {
                Id = artifact.Id,
                Type = artifact.Type,
                Name = artifact.Name,
                DisplayName = artifact.DisplayName,
                Description = artifact.Description,
                PolicyDefinitionId = artifact.PolicyDefinitionId,
                DependsOn = new List<string>(),
                Parameters = new Dictionary<string, PSParameterValueBase>(),
                ResourceGroup = artifact.ResourceGroup
            };

            foreach (var item in artifact.Parameters)
            {
                PSParameterValueBase parameter = GetArtifactParameters(item);
                psArtifact.Parameters.Add(item.Key, parameter);
            }

            psArtifact.DependsOn = artifact.DependsOn?.ToList();

            return psArtifact;
        }
        private static PSParameterValueBase GetArtifactParameters(KeyValuePair<string, ParameterValueBase> parameterKvp)
        {
            PSParameterValueBase parameter = null;

            if (parameterKvp.Value != null && parameterKvp.Value is ParameterValue)
            {
                // Need to cast as ParameterValue since assignment.Parameters value type is ParameterValueBase. 
                var parameterValue = (ParameterValue)parameterKvp.Value;

                parameter = new PSParameterValue { Description = parameterValue.Description, Value = parameterValue.Value };
            }
            else if (parameterKvp.Value != null && parameterKvp.Value is SecretReferenceParameterValue)
            {
                var parameterValue = (SecretReferenceParameterValue)parameterKvp.Value;

                var secretReference = new PSSecretValueReference
                {
                    KeyVault = new PSKeyVaultReference { Id = parameterValue.Reference.KeyVault.Id },
                    SecretName = parameterValue.Reference.SecretName,
                    SecretVersion = parameterValue.Reference.SecretVersion
                };

                parameter = new PSSecretReferenceParameterValue { Reference = secretReference, Description = parameterValue.Description };
            }

            return parameter;
        }
    }
}
