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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System.Management.Automation;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.Azure.Commands.Profile.Properties;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to get current context. 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmContext", DefaultParameterSetName = GetSingleParameterSet)]
    [OutputType(typeof(PSAzureContext))]
    public class GetAzureRMContextCommand : AzureRMCmdlet, IDynamicParameters
    {
        public const string ListAllParameterSet = "ListAllContexts", GetSingleParameterSet = "GetSingleContext";
        /// <summary>
        /// Gets the current default context.
        /// </summary>
        protected override IAzureContext DefaultContext
        {
            get
            {
                if (DefaultProfile == null || DefaultProfile.DefaultContext == null)
                {
                    return null;
                }

                return DefaultProfile.DefaultContext;
            }
        }

        [Parameter(Mandatory =true, ParameterSetName = ListAllParameterSet, HelpMessage ="List all available contexts in the current session.")]
        public SwitchParameter ListAvailable { get; set; }

        public override void ExecuteCmdlet()
        {
            if (DefaultContext == null)
            {
                WriteError(new ErrorRecord(
                        new PSInvalidOperationException(Resources.RunLoginCmdlet),
                        string.Empty,
                        ErrorCategory.AuthenticationError,
                        null));
            }

            if (ListAvailable.IsPresent)
            {
                var profile = DefaultProfile as AzureRmProfile;
                if (profile != null && profile.Contexts != null)
                {
                    foreach( var context in profile.Contexts)
                    {
                        WriteContext(context.Value, context.Key);
                    }
                }

            }
            else
            {
                var profile = DefaultProfile as AzureRmProfile;
                var context = DefaultContext;
                if (profile != null && MyInvocation.BoundParameters.ContainsKey("Name"))
                {
                    var key = MyInvocation.BoundParameters["Name"] as string;
                    if (profile.Contexts != null && profile.Contexts.ContainsKey(key))
                    {
                        context = profile.Contexts[key];
                        WriteContext(context, key);
                    }
                }
                else
                {
                    WriteContext(context, (profile)?.DefaultContextKey);
                }
            }
        }

        void WriteContext(IAzureContext azureContext, string name)
        {
            var context = new PSAzureContext(azureContext);
            if (name != null)
            {
                context.Name = name;
            }

            WriteObject(context);
        }

        public object GetDynamicParameters()
        {
            var parameters = new RuntimeDefinedParameterDictionary();
            AzureRmProfile localProfile = DefaultProfile as AzureRmProfile;
            if (localProfile != null && localProfile.Contexts != null && localProfile.Contexts.Count > 0)
            {
                var nameParameter = new RuntimeDefinedParameter(
                "Name", typeof(string),
                    new Collection<Attribute>()
                    {
                        new ParameterAttribute { Position =0, Mandatory=false, HelpMessage="The name of the context", ParameterSetName=GetSingleParameterSet },
                        new ValidateSetAttribute((DefaultProfile as AzureRmProfile).Contexts.Keys.ToArray())
                    }
                );
                parameters.Add(nameParameter.Name, nameParameter);
            }

            return parameters;
        }
    }
}
