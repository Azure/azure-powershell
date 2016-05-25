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
using System.Diagnostics.Eventing;

namespace Microsoft.Azure.Commands.Automation
{
    public class RequestSettings : IDisposable
    {
        private readonly AutomationManagementClient client;

        public RequestSettings(IAutomationManagementClient automationClient)
        {
            client = ((AutomationManagementClient)automationClient);
            client.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, Guid.NewGuid().ToString());

            client.HttpClient.DefaultRequestHeaders.Remove(Constants.ActivityIdHeaderName);
            var activityId = Guid.NewGuid();
            EventProvider.SetActivityId(ref activityId);
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ActivityIdHeaderName, activityId.ToString());
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
