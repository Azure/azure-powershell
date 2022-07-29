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
using System.Diagnostics.Tracing;

using Azure.Core.Diagnostics;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Common.Authentication
{
    public class AzureEventListener : IAzureEventListener
    {
        private AzureEventSourceListener AzureEventSourceListener { get; set; }

        public AzureEventListener(Action<string> action)
        {
            AzureEventSourceListener = new AzureEventSourceListener(
                (args, message) =>
                {
                    if (!args.EventSource.Name.StartsWith("Azure-Core"))
                    {
                        action(message);
                    }
                },
                EventLevel.Informational);
        }

        public void Dispose()
        {
            AzureEventSourceListener.Dispose();
            AzureEventSourceListener = null;
        }
    }
}
