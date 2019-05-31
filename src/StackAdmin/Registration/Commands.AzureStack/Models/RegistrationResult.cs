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

namespace Microsoft.Azure.Commands.AzureStack.Models
{
    using Microsoft.Azure.Management.AzureStack.Models;

    public class RegistrationResult
    {
        public RegistrationResult(Registration registration)
        {
            this.Name = registration.Name;
            this.Id = registration.Id;
            this.ObjectId = registration.ObjectId;
            this.CloudId = registration.CloudId;
            this.BillingModel = registration.BillingModel;
        }

        public RegistrationResult() { }

        public string Name { get; protected set; }

        public string Id { get; protected set; }

        public string ObjectId { get; protected set; }

        public string CloudId { get; protected set; }

        public string BillingModel { get; protected set; }
    }
}