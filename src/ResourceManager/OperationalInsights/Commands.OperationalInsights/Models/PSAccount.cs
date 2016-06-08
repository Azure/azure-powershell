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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSAccount
    {
        public PSAccount()
        {
        }

        public PSAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("account");
            }

            this.AccountName = account.AccountName;
            this.Name = account.WorkspaceName;
            this.CustomerId = account.CustomerId;
            this.Location = account.Location;
        }

        public string AccountName { get; set; }

        public string Name { get; set; }

        public Guid? CustomerId { get; set; }

        public string Location { get; set; }
    }
}
