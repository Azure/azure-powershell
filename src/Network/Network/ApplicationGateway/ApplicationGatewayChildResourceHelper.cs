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

using Microsoft.Azure.Commands.Network.Models;
using System;
using System.Collections;

namespace Microsoft.Azure.Commands.Network
{
    public static class ApplicationGatewayChildResourceHelper
    {
        public static string GetResourceNotSetId(string subscriptionId, string resource, string resourceName)
        {
            return string.Format(
                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayChildResourceId,
                subscriptionId,
                Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayNameNotSet,
                resource,
                resourceName);
        }

        private static string NormalizeApplicationGatewayNameChildResourceIds(string id, string resourceGroupName, string applicationGatewayName)
        {
            id = NormalizeId(id, "resourceGroups", resourceGroupName);
            id = NormalizeId(id, "applicationGateways", applicationGatewayName);

            return id;
        }

        private static string NormalizeId(string id, string resourceName, string resourceValue)
        {
            int startIndex = id.IndexOf(resourceName, StringComparison.OrdinalIgnoreCase) + resourceName.Length + 1;
            int endIndex = id.IndexOf("/", startIndex, StringComparison.OrdinalIgnoreCase);

            // Replace the following string '/{value}/'
            startIndex--;
            string orignalString = id.Substring(startIndex, endIndex - startIndex + 1);

            return id.Replace(orignalString, string.Format("/{0}/", resourceValue));
        }

        private static bool IsResourceReference(Type t)
        {
            return t.Equals(typeof(PSResourceId)) || t.IsSubclassOf(typeof(PSResourceId));
        }

        public static void NormalizeChildIds(object inputItem, string rgname, string name)
        {
            foreach (var item in inputItem.GetType().GetProperties())
            {
                var value = item.GetValue(inputItem);
                if (value != null && value.ToString() != "null")
                {
                    var valueType = value.GetType();
                    if (item.Name == "Id")
                    {
                        string outValue = value.ToString().Replace(
                            "/resourceGroups/" + Microsoft.Azure.Commands.Network.Properties.Resources.ResourceGroupNotSet,
                            "/resourceGroups/" + rgname);

                        outValue = outValue.Replace(
                            "/applicationGateways/" + Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayNameNotSet,
                            "/applicationGateways/" + name);

                        item.SetValue(inputItem, outValue);
                    }
                    else if (value is IList)
                    {
                        if (IsResourceReference(valueType.GetGenericArguments()[0]))
                        {
                            foreach (var listItem in (IList)value)
                            {
                                NormalizeChildIds(listItem, rgname, name);
                            }
                        }
                    }
                    else if (IsResourceReference(valueType))
                    {
                        NormalizeChildIds(value, rgname, name);
                    }
                }
            }
        }

    }
}
