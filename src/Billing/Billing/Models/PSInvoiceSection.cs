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

using System.Collections.Generic;
using ApiInvoiceSection = Microsoft.Azure.Management.Billing.Models.InvoiceSection;

namespace Microsoft.Azure.Commands.Billing.Models
{
    public class PSInvoiceSection
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Type { get; private set; }

        public string DisplayName { get; private set; }

        public IDictionary<string, string> Labels { get; set; }

        public string SystemId { get; private set; }

        public PSInvoiceSection()
        {
        }

        public PSInvoiceSection(ApiInvoiceSection invoiceSection)
        {
            if (invoiceSection != null)
            {
                this.Id = invoiceSection.Id;
                this.Type = invoiceSection.Type;
                this.Name = invoiceSection.Name;
                this.DisplayName = invoiceSection.DisplayName;
                this.Labels = invoiceSection.Labels;
                this.SystemId = invoiceSection.SystemId;
            }
        }
    }
}
