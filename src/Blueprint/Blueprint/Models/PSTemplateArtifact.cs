﻿// ----------------------------------------------------------------------------------
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
    public class PSTemplateArtifact : PSArtifact
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<string> DependsOn { get; set; }
        public object Template { get; set; }
        public IDictionary<string, PSParameterValue> Parameters { get; set; }
        public string ResourceGroup { get; set; }

        internal static PSTemplateArtifact FromArtifactModel(TemplateArtifact artifact, string scope)
        {
            var psArtifact = new PSTemplateArtifact
            {
                Id = artifact.Id,
                Type = artifact.Type,
                Name = artifact.Name,
                DisplayName = artifact.DisplayName,
                Description = artifact.Description,
                DependsOn = new List<string>(),
                Template = artifact.Template,
                Parameters = new Dictionary<string, PSParameterValue>(),
                ResourceGroup = artifact.ResourceGroup
            };

            foreach (var item in artifact.Parameters)
            {
                PSParameterValue parameter = GetArtifactParameters(item);
                psArtifact.Parameters.Add(item.Key, parameter);
            }

            psArtifact.DependsOn = artifact.DependsOn?.ToList();

            return psArtifact;
        }

        private static PSParameterValue GetArtifactParameters(KeyValuePair<string, ParameterValue> parameterKvp)
        {
            PSParameterValue parameter = null;

            if (parameterKvp.Value != null)
            {
                var parameterValue = parameterKvp.Value;

                parameter = new PSParameterValue { Value = parameterValue.Value };
            }
          
            return parameter;
        }
    }
}
