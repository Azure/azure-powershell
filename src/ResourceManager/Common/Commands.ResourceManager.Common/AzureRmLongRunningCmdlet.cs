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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Threading;
using Microsoft.Azure.Management.Internal.Resources.Utilities;

namespace Microsoft.Azure.Commands.ResourceManager.Common
{
    /// <summary>
    /// Cmdlet base class that implements AsJob using an AzureRmLongRunningJob
    /// </summary>
    public class AzureRmLongRunningCmdlet : AzureRMCmdlet
    {
        [Parameter(Mandatory=false, HelpMessage ="Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set;}
    }
}
