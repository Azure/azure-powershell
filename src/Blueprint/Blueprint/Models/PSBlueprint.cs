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
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Collections;
using Microsoft.Azure.Commands.Blueprint.Common;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSBlueprint : PSBlueprintBase
    {
        public string DefinitionLocationId { get; set; }
        public string Scope { get; set; }
        public object Versions { get; set; }

        /// <summary>
        /// Create a PSBlueprint object from a BlueprintModel.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="managementGroupName">Name of the management group the blueprint belongs to.</param>
        /// <returns>A new PSBlueprint object</returns>
        internal static PSBlueprint FromBlueprintModel(BlueprintModel model, string scope)
        {
            var psBlueprint = new PSBlueprint
            {
                Id = model.Id,
                Name = model.Name,
                DefinitionLocationId = Utils.GetDefinitionLocationId(scope),
                Scope = scope,
                DisplayName = model.DisplayName,
                Description = model.Description,
                Status = new PSBlueprintStatus(),
                TargetScope = PSBlueprintTargetScope.Unknown,
                Parameters = new Dictionary<string, PSParameterDefinition>(),
                ResourceGroups = new Dictionary<string, PSResourceGroupDefinition>(),
                Versions = model.Versions
            };

            if (DateTime.TryParse(model.Status.TimeCreated, out DateTime timeCreated))
            {
                psBlueprint.Status.TimeCreated = timeCreated;
            }
            else
            {
                psBlueprint.Status.TimeCreated = null;
            }

            if (DateTime.TryParse(model.Status.LastModified, out DateTime lastModified))
            {
                psBlueprint.Status.LastModified = lastModified;
            }
            else
            {
                psBlueprint.Status.LastModified = null;
            }

            if (Enum.TryParse(model.TargetScope, true, out PSBlueprintTargetScope targetScope))
            {
                psBlueprint.TargetScope = targetScope;
            }
            else
            {
                psBlueprint.TargetScope = PSBlueprintTargetScope.Unknown;
            }

            foreach (var item in model.Parameters)
            {
                var definition = new PSParameterDefinition
                {
                    Type = item.Value.Type,
                    DisplayName = item.Value.DisplayName,
                    Description = item.Value.Description,
                    StrongType = item.Value.StrongType,
                    DefaultValue = item.Value.DefaultValue,
                    AllowedValues = (item.Value.AllowedValues != null) ? item.Value.AllowedValues.ToList() : null
                };
                psBlueprint.Parameters.Add(item.Key, definition);
            }

            foreach (var item in model.ResourceGroups)
            {
                psBlueprint.ResourceGroups.Add(item.Key,
                    new PSResourceGroupDefinition
                    {
                        Name = item.Value.Name,
                        Location = item.Value.Location,
                        DisplayName = item.Value.DisplayName,
                        Description = item.Value.Description,
                        StrongType = item.Value.StrongType,
                        DependsOn = item.Value.DependsOn.ToList()
                    });
            }
            
            return psBlueprint;
        }
    }
}
