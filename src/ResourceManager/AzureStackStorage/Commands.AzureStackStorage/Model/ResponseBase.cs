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

using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;
using System.Reflection;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    internal class ResponseBase : ResourceBase
    {
        public ResponseBase(ResourceBase resource) : this(resource, "Properties")
        {

        }

        public ResponseBase(ResourceBase resource, string propertyNameToExpand)
        {
            Id = resource.Id;
            Location = resource.Location;
            Tags = resource.Tags;
            Type = resource.Type;
            Name = resource.Name;

            // Id is in the following format:
            // /subscriptions/{subid}/resourceGroups/{resourceGroupName}/providers/{providerName}/farms/{farmId}/nodes/{nodeId}
            string[] ids = resource.Id.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            ResourceGroupName = ids[3];
            FarmName = ids[7];

            Type inputType = resource.GetType();
            Type outPutType = this.GetType();

            PropertyInfo propertiesPropertyInfo = inputType.GetProperty(propertyNameToExpand);

            if (propertiesPropertyInfo != null)
            {
                var propertiesValue = propertiesPropertyInfo.GetValue(resource);
                PropertyInfo[] properties = propertiesValue.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var property in properties)
                {
                    object propertyValue = property.GetValue(propertiesValue);
                    if (propertyValue != null)
                    {
                        PropertyInfo propertyInfoInResponse = outPutType.GetProperty(property.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        if (propertyInfoInResponse != null)
                        {
                            propertyInfoInResponse.SetValue(this, propertyValue);
                        }
                    }
                }
            }
        }

        public string ResourceGroupName { get; set; }
        public string FarmName { get; set; }
    }
}
