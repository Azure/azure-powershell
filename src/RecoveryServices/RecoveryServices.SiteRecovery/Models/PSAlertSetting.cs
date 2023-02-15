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
using System.Collections.Generic;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Azure Site Recovery Notification/Alert settings.
    /// </summary>
    public class ASRAlertSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRAlertSetting" /> class.
        /// </summary>
        public ASRAlertSetting()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRAlertSetting" /> class with required
        ///     parameters.
        /// </summary>
        /// <param name="alertSettings">AlertSetting Object</param>
        public ASRAlertSetting(Alert alertSettings)
        {
            this.CustomEmailAddress = alertSettings.Properties.CustomEmailAddresses;
            this.EmailSubscriptionOwner = alertSettings.Properties.SendToOwners;
            this.Locale = alertSettings.Properties.Locale;
        }

        /// <summary>
        ///     Gets or sets the custom email address for sending emails.
        /// </summary>
        public IList<string> CustomEmailAddress { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating whether to send email to subscription owners.
        /// </summary>
        public string EmailSubscriptionOwner
        {
            get { return this._emailSubscriptionOwner; }
            set
            {
                this._emailSubscriptionOwner = value.Equals(
               SendToOwners.Send,
               StringComparison.InvariantCultureIgnoreCase)
               ? SendToOwners.On
               : SendToOwners.Off;
            }
        }
        /// <summary>
        ///     Gets or sets the locale for the email notification.
        /// </summary>
        public string Locale { get; set; }

        #region private variable
        /// <summary>
        ///     private property to convert subscription owners to on/off.
        /// </summary>
        private string _emailSubscriptionOwner;
        #endregion private variable
    }
}