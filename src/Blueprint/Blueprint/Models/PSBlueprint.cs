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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Blueprint.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSBlueprint : PSBlueprintBase
    {
        public string[] Versions { get; set; }

        /// <summary>
        /// Create a PSBlueprint object from a BlueprintModel.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="scope">Name of the scope the blueprint is under.</param>
        /// <returns>A new PSBlueprint object</returns>
        internal static PSBlueprint FromBlueprintModel(BlueprintModel model, string scope)
        {
            var psBlueprint = new PSBlueprint
            {
                Id = model.Id,
                Name = model.Name,
                Scope = scope,
                DisplayName = model.DisplayName,
                Description = model.Description,
                Status = new PSBlueprintStatus(),
                TargetScope = PSBlueprintTargetScope.Unknown,
                Parameters = new Dictionary<string, PSParameterDefinition>(),
                ResourceGroups = new Dictionary<string, PSResourceGroupDefinition>(),
                Versions = null
            };

            if (model.Versions != null)
            {
                var versionsDict = JObject.FromObject(model.Versions).ToObject<Dictionary<string, object>>();
                psBlueprint.Versions = versionsDict.Keys.ToArray();
            }

            psBlueprint.Status.TimeCreated = model.Status.TimeCreated;

            psBlueprint.Status.LastModified = model.Status.LastModified;


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

            if (psBlueprint.Scope.StartsWith("/subscriptions"))
            {
                psBlueprint.SubscriptionId = Utils.GetDefinitionLocationId(scope);
            }
            else
            {
                psBlueprint.ManagementGroupId = Utils.GetDefinitionLocationId(scope);
            }

            return psBlueprint;
        }
    }
}
