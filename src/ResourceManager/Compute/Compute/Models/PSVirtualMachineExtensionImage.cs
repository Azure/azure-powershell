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

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSVirtualMachineExtensionImageType : PSVirtualMachineImageResource
    {
        public string PublisherName { get; set; }

        public string Type { get; set; }
    }

    public class PSVirtualMachineExtensionImage : PSVirtualMachineExtensionImageType
    {
        public string Version { get; set; }

        public string FilterExpression { get; set; }
    }

    public class PSVirtualMachineExtensionImageDetails : PSVirtualMachineExtensionImage
    {
        public string HandlerSchema { get; set; }

        public string OperatingSystem { get; set; }

        public string ComputeRole { get; set; }

        public bool? SupportsMultipleExtensions { get; set; }

        public bool? VMScaleSetEnabled { get; set; }
    }
}
