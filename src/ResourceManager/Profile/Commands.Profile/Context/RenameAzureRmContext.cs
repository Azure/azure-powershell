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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.Profile.Properties;
using System;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet(VerbsCommon.Rename, "AzureRmContext", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureContext))]
    public class RenameAzureRmContext : AzureContextModificationCmdlet, IDynamicParameters
    {
        const string SourceParameterName = "SourceName", TargetParameterName = "TargetName";
        [Parameter( Mandatory=false, HelpMessage="Rename the context even if the target context already exists")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory=false, HelpMessage="Return the renamed context")]
        public SwitchParameter PassThrough { get; set; }

        public object GetDynamicParameters()
        {
            var parameters = new RuntimeDefinedParameterDictionary();
            AzureRmProfile localProfile = DefaultProfile as AzureRmProfile;
            if (localProfile != null)
            {
                var sourceNameParameter = GetExistingContextNameParameter(SourceParameterName);
                parameters.Add(sourceNameParameter.Name, sourceNameParameter);
                var attributes = new Collection<Attribute>()
                {
                    new ParameterAttribute { Position=1, Mandatory=true, HelpMessage="The new name of the context" },
                    new ValidateNotNullOrEmptyAttribute()
                };
                var targetNameParameter = new RuntimeDefinedParameter(TargetParameterName, typeof(string), attributes);
                parameters.Add(targetNameParameter.Name, targetNameParameter);
            }

            return parameters;
        }

        public override void ExecuteCmdlet()
        {
            if (MyInvocation.BoundParameters.ContainsKey(SourceParameterName) && MyInvocation.BoundParameters.ContainsKey(TargetParameterName))
            {
                var sourceName = MyInvocation.BoundParameters[SourceParameterName] as string;
                var targetName = MyInvocation.BoundParameters[TargetParameterName] as string;
                var defaultProfile = DefaultProfile as AzureRmProfile;
                if (!string.IsNullOrWhiteSpace(sourceName) && !string.IsNullOrWhiteSpace(targetName) && defaultProfile != null)
                {
                    ConfirmAction(
                        Force.IsPresent, 
                        string.Format(Resources.OverwriteContextWarning, targetName, sourceName), 
                        string.Format(Resources.RenameContextMessage, sourceName, targetName),
                        "Context",
                        () =>
                        {

                            ModifyContext((profile, client) =>
                            {
                                if (profile.Contexts.ContainsKey(sourceName))
                                {
                                    var sourceContext = profile.Contexts[sourceName];
                                    if (client.TryRenameContext(sourceName, targetName) && PassThrough.IsPresent)
                                    {
                                        WriteObject(new PSAzureContext(profile.DefaultContext));
                                    }
                                }
                            });
                        },
                        () => defaultProfile.Contexts.ContainsKey(targetName));
                }
            }
        }
    }
}
