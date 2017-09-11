﻿// ----------------------------------------------------------------------------------
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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Profile.Context
{
    [Cmdlet(VerbsCommon.Select, "AzureRmContext", SupportsShouldProcess = true)]
    [OutputType(typeof(PSAzureContext))]
    public class SelectAzureRmContext : AzureContextModificationCmdlet, IDynamicParameters
    {
        public object GetDynamicParameters()
        {
            var parameters = new RuntimeDefinedParameterDictionary();
            RuntimeDefinedParameter nameParameter;
            if (TryGetExistingContextNameParameter("Name", out nameParameter))
            {
                parameters.Add(nameParameter.Name, nameParameter);
            }

            return parameters;
        }

        public override void ExecuteCmdlet()
        {
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                ConfirmAction(Resources.SelectContextPrompt, "Context",
                    () =>
                    {
                        string name = MyInvocation.BoundParameters["Name"] as string;
                        if (name != null)
                        {
                            ModifyContext((profile, client) =>
                            {
                                client.TrySetDefaultContext(name);
                                var context = new PSAzureContext(profile.DefaultContext);
                                context.Name = profile.DefaultContextKey;
                                WriteObject(context);
                            });
                        }
                    });
            }
        }
    }
}
