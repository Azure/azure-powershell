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
using System.Collections.Generic;
using Microsoft.Azure.Commands.DevSpaces.Models;
using Microsoft.Azure.Management.DevSpaces;
using Microsoft.Azure.Management.DevSpaces.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DevSpaces.Utils
{
    public static class ControllerOperationPSExtension
    {
        private static IPage<Controller> List(this IControllersOperations operations, string resourceGroupName)
        {
            if(string.IsNullOrEmpty(resourceGroupName))
            {
                return operations.List();
            }

            return operations.ListByResourceGroup(resourceGroupName);
        }

        private static IPage<Controller> ListByNextLink(this IControllersOperations operations, string nextLink, string resourceGroupName)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                return operations.ListNext(nextLink);
            }

            return operations.ListByResourceGroupNext(nextLink);
        }


        public static IList<PSController> ListAllPSController(this IControllersOperations operations, string resourceGroupName)
        {
            List<PSController> list = new List<PSController>();
            var controllers = operations.List(resourceGroupName);

            foreach (Controller controller in controllers)
            {
                list.Add(new PSController(controller));
            }

            while (!string.IsNullOrEmpty(controllers.NextPageLink))
            {
                controllers = operations.ListByNextLink(resourceGroupName, controllers.NextPageLink);

                foreach (Controller controller in controllers)
                {
                    list.Add(new PSController(controller));
                }
            }

            return list;
        }

        public static PSController GetPSController(this IControllersOperations operations, string resourceGroupName, string name)
        {
            var controller = operations.Get(resourceGroupName, name);

            return new PSController(controller);
        }
    }
}
