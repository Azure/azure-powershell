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

namespace Microsoft.Azure.Commands.Security.Common
{
    public static class ParameterHelpMessages
    {
        #region General

        public const string SubscriptionId = "Subscription ID.";
        public const string ResourceGroupName = "Resource group name.";
        public const string ResourceName = "Resource name.";
        public const string ResourceId = "ID of the security resource that you want to invoke the command on.";
        public const string Scope = "Scope.";
        public const string Kind = "Kind.";
        public const string InputObject = "Input Object.";
        public const string Location = "Location.";
        public const string PassThru = "Return whether the operation was successful.";

        #endregion

        #region Workspace Settings

        public const string WorkspaceId = "Workspace ID.";

        #endregion

        #region Alerts

        public const string ActionType = "Action Type.";

        #endregion

        #region Security Contacts

        public const string Email = "E-Mail.";
        public const string Phone = "Phone.";
        public const string AlertsToAdmins = "Alerts To Administrators.";
        public const string AlertNotifications = "Alert Notifications.";

        #endregion

        #region Pricings

        public const string PricingTier = "Pricing Tier.";

        #endregion

        #region Auto Provisioning Settings

        public const string AutoProvision = "Automatic Provisioning.";

        #endregion

        #region JIT Network Access Policies

        public const string VirutalMachines = "Virtual Machines.";

        #endregion

        #region Threat Detection Settings

        public const string Disable = "Disables Threat Protection Policy";
        public const string Enable = "Enables Threat Protection Policy";

        #endregion
    }
}
