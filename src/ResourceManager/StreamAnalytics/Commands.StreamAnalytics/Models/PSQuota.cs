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

using Microsoft.Azure.Management.StreamAnalytics.Models;
using System;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public class PSQuota
    {
        private SubscriptionQuotas subscriptionQuotas;

        public PSQuota()
        {
            subscriptionQuotas = new SubscriptionQuotas();
        }

        public PSQuota(SubscriptionQuotas subscriptionQuotas)
        {
            if (subscriptionQuotas == null)
            {
                throw new ArgumentNullException("subscriptionQuotas");
            }

            this.subscriptionQuotas = subscriptionQuotas;
        }

        public string Name
        {
            get
            {
                return subscriptionQuotas.Name;
            }
            internal set
            {
                subscriptionQuotas.Name = value;
            }
        }

        public string Location { get; set; }

        public int CurrentCount
        {
            get
            {
                return subscriptionQuotas.Properties.CurrentCount;
            }
            internal set
            {
                subscriptionQuotas.Properties.CurrentCount = value;
            }
        }

        public int MaxCount
        {
            get
            {
                return subscriptionQuotas.Properties.MaxCount;
            }
            internal set
            {
                subscriptionQuotas.Properties.MaxCount = value;
            }
        }

        public SubscriptionQuotasProperties Properties
        {
            get
            {
                return subscriptionQuotas.Properties;
            }
            internal set
            {
                subscriptionQuotas.Properties = value;
            }
        }
    }
}