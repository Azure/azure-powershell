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
using Hyak.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public partial class ResourcesClient
    {
        public const string ResourceGroupTypeName = "ResourceGroup";

        public static List<string> KnownLocations = new List<string>
        {
            "East Asia", "South East Asia", "East US", "West US", "North Central US",
            "South Central US", "Central US", "North Europe", "West Europe"
        };

        internal static List<string> KnownLocationsNormalized = KnownLocations
            .Select(loc => loc.ToLower().Replace(" ", "")).ToList();

        /// <summary>
        /// Get an existing resource or resources.
        /// </summary>
        /// <param name="parameters">The get parameters</param>
        /// <returns>List of resources</returns>
        public virtual List<PSResource> FilterPSResources(BasePSResourceParameters parameters)
        {
            List<PSResource> resources = new List<PSResource>();

            if (!string.IsNullOrEmpty(parameters.Name))
            {
                ResourceIdentity resourceIdentity = parameters.ToResourceIdentity();

                ResourceGetResult getResult;

                try
                {
                    getResult = ResourceManagementClient.Resources.Get(parameters.ResourceGroupName, resourceIdentity);
                }
                catch (CloudException)
                {
                    throw new ArgumentException(ProjectResources.ResourceDoesntExists);
                }

                resources.Add(getResult.Resource.ToPSResource(this, false));
            }
            else
            {
                PSTagValuePair tagValuePair = new PSTagValuePair();
                if (parameters.Tag != null && parameters.Tag.Length == 1 && parameters.Tag[0] != null)
                {
                    tagValuePair = TagsConversionHelper.Create(parameters.Tag[0]);
                    if (tagValuePair == null)
                    {
                        throw new ArgumentException(ProjectResources.InvalidTagFormat);
                    }
                }
                ResourceListResult listResult = ResourceManagementClient.Resources.List(new ResourceListParameters
                {
                    ResourceGroupName = parameters.ResourceGroupName,
                    ResourceType = parameters.ResourceType,
                    TagName = tagValuePair.Name,
                    TagValue = tagValuePair.Value
                });

                if (listResult.Resources != null)
                {
                    resources.AddRange(listResult.Resources.Select(r => r.ToPSResource(this, false)));
                }
            }
            return resources;
        }

    }
}
