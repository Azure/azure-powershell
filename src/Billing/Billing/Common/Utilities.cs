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

using System.Management.Automation;
using Microsoft.Azure.Commands.Billing.Models;
using Microsoft.Azure.Management.Billing.Models;

namespace Microsoft.Azure.Commands.Billing.Common
{
    using System.Linq;

    public class Utilities
    {
        public static string GetResourceNameFromId(string resourceId)
        {
            if(string.IsNullOrWhiteSpace(resourceId))
            {
                return null;
            }

            var parts = resourceId.Split('/');
            return parts.LastOrDefault();            
        }
    }

    public static class InvoiceExtensions
    {
        public static PSAmount ToPSAmount(this Amount amount) =>
            new PSAmount
            {
                Value = amount.Value,
                Currency = amount.Currency
            };

        public static PSInvoiceDocument ToPSInvoiceDocument(this Document invoiceDocument) =>
        new PSInvoiceDocument
        {
            Kind = invoiceDocument.Kind,
            Source = invoiceDocument.Source,
            Url = invoiceDocument.Url
        };
    }
}
