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

using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Management.Automation;
using System;
#if !NETSTANDARD
using System.Diagnostics.Eventing;
#endif
using AutomationManagement = Microsoft.Azure.Management.Automation;

namespace Microsoft.Azure.Commands.Automation
{
    public class RequestSettings : IDisposable
    {
        private readonly AutomationManagement.AutomationClient client;

        public RequestSettings(AutomationManagement.IAutomationClient automationClient)
        {
            client = ((AutomationManagement.AutomationClient)automationClient);
            client.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, Guid.NewGuid().ToString());

            client.HttpClient.DefaultRequestHeaders.Remove(Constants.ActivityIdHeaderName);
            var activityId = Guid.NewGuid();
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ActivityIdHeaderName, activityId.ToString());
#if !NETSTANDARD
            EventProvider.SetActivityId(ref activityId);
#endif
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                client.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
                client.HttpClient.DefaultRequestHeaders.Remove(Constants.ActivityIdHeaderName);
            }
        }
    }
}
