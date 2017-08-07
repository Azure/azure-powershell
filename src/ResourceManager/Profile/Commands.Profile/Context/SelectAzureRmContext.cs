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
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet(VerbsCommon.Select, "AzureRmContext", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureContext))]
    public class SelectAzureRmContext : AzureContextModificationCmdlet, IDynamicParameters
    {
        object _lockObject = new object();
        RuntimeDefinedParameterDictionary _parameters;
        public object GetDynamicParameters()
        {
            lock (_lockObject)
            {
                if (_parameters == null)
                {
                    _parameters = new RuntimeDefinedParameterDictionary();
                    AzureRmProfile localProfile = DefaultProfile as AzureRmProfile;
                    if (localProfile != null)
                    {
                        var nameParameter = new RuntimeDefinedParameter("Name", typeof(string),
                            new Collection<Attribute>()
                            {
                        new ParameterAttribute { Position =0, Mandatory=true, HelpMessage="The name of the context to select as the current focus for Azure cmdlets" },
                        new ValidateSetAttribute((DefaultProfile as AzureRmProfile).Contexts.Keys.ToArray())
                            });
                        _parameters.Add(nameParameter.Name, nameParameter);
                    }
                }
            }

            return _parameters;
        }

        public override void ExecuteCmdlet()
        {
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                ConfirmAction("Change the current context", "Context",
                    () =>
                    {
                        string name = MyInvocation.BoundParameters["Name"] as string;
                        if (name != null)
                        {
                            ModifyContext((profile, client) =>
                            {
                                profile.TrySetDefaultContext(name);
                                WriteObject(new PSAzureContext(profile.DefaultContext));
                            });
                        }
                    });
            }
        }
    }
}
