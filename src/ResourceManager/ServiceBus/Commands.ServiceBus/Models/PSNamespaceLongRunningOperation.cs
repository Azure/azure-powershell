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

using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{

    public class PSNamespaceLongRunningOperation
    {
        public const string DeleteOperation = "Remove-AzureRmServiceBusNamespace";


        internal static PSNamespaceLongRunningOperation CreateLongRunningOperation(
            string operationName,
            PSNamespaceLongRunningOperation longRunningResponse)
        {
            if (string.IsNullOrWhiteSpace(operationName))
            {
                throw new ArgumentNullException("operationName");
            }

            if (longRunningResponse == null)
            {
                throw new ArgumentNullException("longRunningResponse");
            }

            var result = new PSNamespaceLongRunningOperation
            {
                OperationName = operationName,
                OperationLink = longRunningResponse.OperationLink,
                RetryAfter =  longRunningResponse.RetryAfter,
                Status = longRunningResponse.Status,
                Error = (longRunningResponse.Error != null) ? longRunningResponse.Error : null
            };

            return result;
        }

        public string OperationName { get; private set; }

        public OperationStatus Status { get; private set; }

        public TimeSpan? RetryAfter { get; private set; }

        public string OperationLink { get; private set; }

        public PSNamespaceAttributes NamespaceAttributes { get; private set; }

        public string Error { get; private set; }
    }
}
