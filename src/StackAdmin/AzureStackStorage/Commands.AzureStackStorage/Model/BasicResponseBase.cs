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
using System.Reflection;
using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    class BasicResponseBase : ResourceBase
    {
        public BasicResponseBase(ResourceBase resource) : this(resource, "Properties")
        {
        }

        public BasicResponseBase(ResourceBase resource, string propertyNameToExpand)
        {
            Id = resource.Id;
            Location = resource.Location;
            Tags = resource.Tags;
            Type = resource.Type;
            Name = resource.Name;

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
    }
}
