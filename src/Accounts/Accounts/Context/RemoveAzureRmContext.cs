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

<<<<<<< HEAD
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models;
// TODO: Remove IfDef
#if NETSTANDARD
using Microsoft.Azure.Commands.Profile.Models.Core;
#endif
using Microsoft.Azure.Commands.Profile.Properties;
using System;
using System.Linq;
using System.Management.Automation;
=======
using System;
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.Profile.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Context", SupportsShouldProcess = true, DefaultParameterSetName = InputObjectParameterSet)]
    [OutputType(typeof(PSAzureContext))]
    public class RemoveAzureRmContext : AzureContextModificationCmdlet, IDynamicParameters
    {
        const string NamedContextParameterSet = "RemoveByName", InputObjectParameterSet = "RemoveByInputObject";
        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "A context object, normally passed through the pipeline.")]
        [ValidateNotNullOrEmpty]
        public PSAzureContext InputObject { get; set; }

<<<<<<< HEAD
        [Parameter(Mandatory = false, HelpMessage = "Remove context even if it is the defualt")]
=======
        [Parameter(Mandatory = false, HelpMessage = "Remove context even if it is the default")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return the removed context")]
        public SwitchParameter PassThru { get; set; }

        public object GetDynamicParameters()
        {
            var parameters = new RuntimeDefinedParameterDictionary();
            RuntimeDefinedParameter namedParameter;
            if (TryGetExistingContextNameParameter("Name", NamedContextParameterSet, out namedParameter))
            {
                parameters.Add(namedParameter.Name, namedParameter);
            }

            return parameters;
        }

        public override void ExecuteCmdlet()
        {
            string name = null;
            if (ParameterSetName == InputObjectParameterSet)
            {
                name = InputObject?.Name;
            }
            else if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                name = MyInvocation.BoundParameters["Name"] as string;
            }

            if (!string.IsNullOrWhiteSpace(name))
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
<<<<<<< HEAD
                                if (client.TryRemoveContext(name) && PassThru.IsPresent)
                                {
                                    var outContext = new PSAzureContext(removedContext);
                                    outContext.Name = name;
                                    WriteObject(outContext);
=======
                                if (client.TryRemoveContext(name))
                                {
                                    if (removedContext.Account.Type == AzureAccount.AccountType.User &&
                                        !profile.Contexts.Any(c => c.Value.Account.Id == removedContext.Account.Id))
                                    {
                                        PowerShellTokenCacheProvider tokenCacheProvider;
                                        if (!AzureSession.Instance.TryGetComponent(PowerShellTokenCacheProvider.PowerShellTokenCacheProviderKey, out tokenCacheProvider))
                                        {
                                            WriteWarning(string.Format(Resources.ClientFactoryNotRegisteredRemoval, removedContext.Account.Id));
                                        }
                                        else
                                        {
                                            if (!tokenCacheProvider.TryRemoveAccount(removedContext.Account.Id))
                                            {
                                                WriteWarning(string.Format(Resources.NoContextsRemain, removedContext.Account.Id));
                                            }
                                        }
                                    }

                                    if (this.PassThru.IsPresent)
                                    {
                                        var outContext = new PSAzureContext(removedContext);
                                        outContext.Name = name;
                                        WriteObject(outContext);
                                    }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                                }
                            }
                        });
                    },
                    () => string.Equals(defaultProfile.DefaultContextKey, name, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
