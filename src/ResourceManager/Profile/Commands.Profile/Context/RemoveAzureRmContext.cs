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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmContext", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureContext))]
    public class RemoveAzureRmContext : AzureContextModificationCmdlet, IDynamicParameters
    {
        [Parameter(Mandatory = false, HelpMessage = "Remove context even if it is the defualt")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return the removed context")]
        public SwitchParameter PassThrough { get; set; }

        public object GetDynamicParameters()
        {
            var parameters = new RuntimeDefinedParameterDictionary();
            RuntimeDefinedParameter namedParameter;
            if (TryGetExistingContextNameParameter("Name", out namedParameter))
            {
                parameters.Add(namedParameter.Name, namedParameter);
            }

            return parameters;
        }

        public override void ExecuteCmdlet()
        {
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                string name = MyInvocation.BoundParameters["Name"] as string;
                if (name != null)
                {
                    var defaultProfile = DefaultProfile as AzureRmProfile;
                    ConfirmAction(Force.IsPresent,
                        string.Format(Resources.RemoveDefaultContextQuery, name),
                        string.Format(Resources.RemoveContextMessage, name),
                        Resources.RemoveContextTarget,
                        () =>
                        {
                            ModifyContext((profile, client) =>
                            {
                                if (profile.Contexts.ContainsKey(name))
                                {
                                    var removedContext = profile.Contexts[name];
                                    if (client.TryRemoveContext(name) && PassThrough.IsPresent)
                                    {
                                        var outContext = new PSAzureContext(removedContext);
                                        outContext.Name = name;
                                        WriteObject(outContext);
                                    }
                                }
                            });
                        },
                        () => string.Equals(defaultProfile.DefaultContextKey, name, StringComparison.OrdinalIgnoreCase));
                }
            }
        }
    }
}
