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

using System.Linq;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions
{
    public class VirtualMachineExtensionImageFactory
    {
        private IComputeManagementClient computeClient;

        public VirtualMachineExtensionImageFactory(IComputeManagementClient computeClient)
        {
            this.computeClient = computeClient;
        }

        private static ResourceExtensionReference MakeItem(
            string publisherName,
            string extensionName,
            string referenceName,
            string version)
        {
            return new ResourceExtensionReference
            {
                Publisher     = publisherName,
                Name          = extensionName,
                ReferenceName = referenceName,
                Version       = version
            };
        }

        private ResourceExtensionReference MakeItem(
            string publisherName,
            string extensionName,
            string version)
        {
            ResourceExtensionReference extension = null;

            if (this.computeClient != null)
            {
                var reference = this.computeClient.VirtualMachineExtensions.ListVersions(
                    publisherName,
                    extensionName).FirstOrDefault();

                if (reference != null)
                {
                    extension = MakeItem(
                        reference.Publisher,
                        reference.Name,
                        reference.Name,
                        version);
                }
            }

            return extension;
        }

        public ResourceExtensionReferenceList MakeList(
            string publisherName,
            string extensionName,
            string version)
        {
            var item = MakeItem(
                publisherName,
                extensionName,
                version);

            var list = Enumerable.Repeat(item, item == null ? 0 : 1);

            return new ResourceExtensionReferenceList(list);
        }
    }
}
