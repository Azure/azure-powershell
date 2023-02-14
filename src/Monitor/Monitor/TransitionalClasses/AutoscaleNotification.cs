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
using System.Linq;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the AutoscaleNotification, but in the old namespace
    /// </summary>
    public class AutoscaleNotification : Monitor.Models.AutoscaleNotification
    {
        /// <summary>
        /// Gets the Operation name. It is a fix value "Scale".
        /// </summary>
        public new static string Operation
        {
            get { return Monitor.Models.AutoscaleNotification.Operation; }
        }

        /// <summary>
        /// Gets or sets the Webhooks property of the AutoscaleNotification object
        /// </summary>
        public new IList<WebhookNotification> Webhooks { get; set; }

        /// <summary>
        /// Gets or sets the Email property of the AutoscaleNotification object
        /// </summary>
        public new EmailNotification Email { get; set; }

        /// <summary>
        /// Initializes a new instance of the AutoscaleNotification class.
        /// </summary>
        public AutoscaleNotification()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AutoscaleNotification class.
        /// </summary>
        /// <param name="autoscaleNotification">The autoscale notification</param>
        public AutoscaleNotification(Monitor.Models.AutoscaleNotification autoscaleNotification)
            : base(email: autoscaleNotification?.Email, webhooks: autoscaleNotification?.Webhooks)
        {
            this.Webhooks = autoscaleNotification?.Webhooks != null
                ? autoscaleNotification.Webhooks.Select(e => new Monitor.Management.Models.WebhookNotification(e)).ToList()
                : null;

            this.Email = autoscaleNotification?.Email != null
                ? new EmailNotification(autoscaleNotification.Email)
                : null;
        }
    }
}
