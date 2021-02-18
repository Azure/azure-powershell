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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Compute.Version_2018_04;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.SignalR.Cmdlets
{
    public abstract class SignalRCmdletBottom : AzureRMCmdlet
    {
        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string ListSignalRServiceParameterSet = "ListSignalRServiceParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        private ISignalRManagementClient _client;

        protected ISignalRManagementClient Client => _client ?? (_client = BuildClient<SignalRManagementClient>());

        /// <summary>
        /// Run Cmdlet with Error Handling (report error correctly)
        /// </summary>
        /// <param name="action">The actual Cmdlet action to be wrapped.</param>
        protected void RunCmdlet(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Rest.Azure.CloudException ex)
            {
                throw new PSInvalidOperationException(ex.Body.Message, ex);
            }
        }

        protected T BuildClient<T>(string endpoint = null, Func<T, T> postBuild = null) where T : ServiceClient<T>
        {
            var instance = AzureSession.Instance.ClientFactory.CreateArmClient<T>(
                DefaultProfile.DefaultContext, endpoint ?? AzureEnvironment.Endpoint.ResourceManager);
            return postBuild == null ? instance : postBuild(instance);
        }

        private string ToPowerShellString(object value)
        {
            if (value == null)
            {
                return "$null";
            }
            if (value is string s)
            {
                return "\"" + s + "\"";
            }
            if (value is IEnumerable e)
            {
                return string.Join(",", e.Cast<object>().Select(ToPowerShellString));
            }
            return value.ToString();
        }

        protected void PromptParameter(string name, object value, bool check = false, object defaultValue = null, string prompt = "(by default)")
        {
            if (check && value == null)
            {
                WriteVerbose($"{name} = {ToPowerShellString(defaultValue)} {prompt}");
            }
            else
            {
                WriteVerbose($"{name} = {ToPowerShellString(value)}");
            }
        }

        protected IList<string> ParseAndCheckAllowedOrigins(string[] parameter)
        {
            if (parameter == null)
            {
                return null;
            }
            IList<string> origins = parameter.ToList();
            Regex regex = new Regex(@"^(http|https)://[^ *\\/""]+$");
            foreach (var url in origins)
            {
                if (url != "*" && !regex.IsMatch(url))
                {
                    string message = $"Invalid origin: \"{url}\"";
                    throw new PSInvalidOperationException(message);
                }
            }
            return origins;
        }
    }
}
