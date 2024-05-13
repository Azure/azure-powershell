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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile.Common;
using Microsoft.Azure.Commands.Profile.Models.Core;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Profile
{
    /// <summary>
    /// Cmdlet to get current context.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Context", DefaultParameterSetName = GetSingleParameterSet)]
    [OutputType(typeof(PSAzureContext))]
    public class GetAzureRMContextCommand : AzureRMCmdlet, IDynamicParameters
    {
        public const string ListAllParameterSet = "ListAllContexts", GetSingleParameterSet = "GetSingleContext";

        [Parameter(Position = 0, Mandatory = false, HelpMessage = "The name of the context", ParameterSetName = GetSingleParameterSet)]
        [ContextNameCompleter]
        public string Name { get; set; }

        /// <summary>
        /// Gets the current default context.
        /// </summary>
        protected override IAzureContext DefaultContext
        {
            get
            {
                try
                {
                    if (DefaultProfile == null || DefaultProfile.DefaultContext == null)
                    {
                        return null;
                    }
                }
                catch (InvalidOperationException)
                {
                    return null;
                }

                return DefaultProfile.DefaultContext;
            }
        }

        [Parameter(Mandatory = true, ParameterSetName = ListAllParameterSet, HelpMessage = "List all available contexts in the current session.")]
        public SwitchParameter ListAvailable { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ListAllParameterSet, HelpMessage = "Refresh contexts from token cache")]
        public SwitchParameter RefreshContextFromTokenCache { get; set; }

        protected override bool RequireDefaultContext()
        {
            return false;
        }

        public override void ExecuteCmdlet()
        {
            if (ListAvailable.IsPresent && RefreshContextFromTokenCache.IsPresent)
            {
                try
                {
                    var defaultProfile = DefaultProfile as AzureRmProfile;
                    if (defaultProfile != null && string.Equals(AzureSession.Instance?.ARMContextSaveMode, "CurrentUser"))
                    {
                        defaultProfile.RefreshContextsFromCache();
                    }
                }
                catch (Exception e)
                {
                    WriteWarning(e.ToString());
                }
            }

            // If no context is found, return
            if (DefaultContext == null && !this.ListAvailable.IsPresent)
            {
                return;
            }

            if (this.ListAvailable.IsPresent)
            {
                var profile = DefaultProfile as AzureRmProfile;
                if (profile != null && profile.Contexts != null)
                {
                    WritePSAzureContext(profile.Contexts.Select(context => ToPSAzureContext(context.Value, context.Key))?.Where(context => null != context) // remove null contexts
                        ?.OrderBy(context => context?.Tenant?.Id ?? "").ThenBy(context => context?.Subscription?.Name ?? ""));
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

        /// <summary>
        /// Convert AzureContext to PSAzureContext with given name
        /// Notice that returned context may be null
        /// </summary>
        /// <param name="azureContext"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private PSAzureContext ToPSAzureContext(IAzureContext azureContext, string name)
        {
            var context = new PSAzureContext(azureContext);
            if (null != name && null != context)
            {
                context.Name = name;
            }

            return context;
        }

        private void WritePSAzureContext(IEnumerable<PSAzureContext> psAzureContext) => 
            psAzureContext?.ForEach(context => WritePSAzureContext(context));
        
        private void WritePSAzureContext(PSAzureContext psAzureContext)
        {
            if (psAzureContext == null) return;

            // Don't write the default (empty) context to the output stream
            if (psAzureContext.Account == null &&
                psAzureContext.Environment == null &&
                psAzureContext.Subscription == null &&
                psAzureContext.Tenant == null)
            {
                return;
            }

            WriteObject(psAzureContext);
        }

        void WriteContext(IAzureContext azureContext, string name) =>
            WritePSAzureContext(ToPSAzureContext(azureContext, name));
    }
}
