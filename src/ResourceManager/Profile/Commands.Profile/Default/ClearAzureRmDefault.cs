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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Default
{
    /// <summary>
    /// Cmdlet to clear default options. 
    /// </summary>
    [Cmdlet(VerbsCommon.Clear, "AzureRmDefault", DefaultParameterSetName = ResourceGroupParameterSet,
         SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class ClearAzureRMDefaultCommand : AzureContextModificationCmdlet
    {
        private const string ResourceGroupParameterSet = "ResourceGroup";

        [Parameter(ParameterSetName = ResourceGroupParameterSet, Mandatory = false, HelpMessage = "Clear Default Resource Group", ValueFromPipelineByPropertyName = true)]
        public SwitchParameter ResourceGroup { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Remove all defaults if no default is specified")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            IAzureContext context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
            // If no parameters are specified, clear all defaults
            if (!ResourceGroup)
            {
                if (ShouldProcess(string.Format(Resources.DefaultResourceGroupTarget), Resources.DefaultResourceGroupRemovalWarning)) {
                    if (Force.IsPresent || ShouldContinue(Resources.RemoveDefaultsMessage, Resources.RemoveDefaultsCaption))
                    {
                        if (context.IsPropertySet(Resources.DefaultResourceGroupKey))
                        {
                            ModifyContext((profile, client) => RemoveDefaultProperty(profile));
                            if (PassThru.IsPresent)
                            {
                                WriteObject(true);
                            }
                        }
                        else
                        {
                            if (PassThru.IsPresent)
                            {
                                WriteObject(false);
                            }
                        }
                    }
                }
            }

            // If any parameters are specified, clear only defaults with switch parameters set to true
            if (ResourceGroup)
            {
                if (context.IsPropertySet(Resources.DefaultResourceGroupKey))
                {
                    if (ShouldProcess(string.Format(Resources.DefaultResourceGroupTarget), Resources.DefaultResourceGroupRemovalWarning))
                    {
                        ModifyContext((profile, client) => RemoveDefaultProperty(profile));
                        if (PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }
                    }
                }
                else
                {
                    if (PassThru.IsPresent)
                    {
                        WriteObject(false);
                    }
                }
            }
        }

        private void RemoveDefaultProperty(IProfileOperations profile)
        {
            var context = profile.DefaultContext;
            context.ExtendedProperties.Remove(Resources.DefaultResourceGroupKey);
        }
    }
}