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

namespace Microsoft.Azure.Commands.Automation.Model.UpdateManagement
{
    using System;
    using System.Collections.Generic;

    public class UpdateConfiguration
    {
        public OperatingSystemType OperatingSystem { get; set; }

        public WindowsConfiguration Windows { get; set; }

        public LinuxConfiguration Linux { get; set; }

        public TimeSpan? Duration { get; set; }

        public IList<string> AzureVirtualMachines { get; set; }

        public IList<string> NonAzureComputers { get; set; }

        public UpdateTargets Targets { get; set; }
    }
}
