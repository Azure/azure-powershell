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

namespace Microsoft.Azure.Commands.LogicApp.Utilities
{
    /// <summary>
    /// Constant class
    /// </summary>
    public class Constants
    {
        public const string StatusEnabled = "Enabled";
        public const string StatusDisabled = "Disabled";

        public const string KeyTypeNotSpecified = "NotSpecified";
        public const string KeyTypePrimary = "Primary";
        public const string KeyTypeSecondary = "Secondary";

        public const string ApplicationServicePlanIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Web/serverfarms/{2}";

        /// <summary>
        /// String format for received control number session Id
        /// </summary>
        /// <remarks>Position 0 is protocol, position 1 is agreement name and position 2 is control number value.</remarks>
        public const string ReceivedControlNumberSessionIdFormat = "{0}-ICN-{1}-{2}";

        /// <summary>
        /// String format for generated control number session Id
        /// </summary>
        /// <remarks>Position 0 is agreement name, position 1 is control number type and position 2 is optional acknowledgement suffix.</remarks>
        public const string GeneratedControlNumberSessionIdFormat = "{0}-{1}{2}";

        /// <summary>
        /// Suffix in session id to represent is acknowledgement message
        /// </summary>
        public const string IsAcknowledgementSessionIdSuffix = "-ACK";

        public const string NoAgreementTypeParameterWarningMessage = "By default, you are using the X12 agreement type. Please provide a value for AgreementType if you would like to specify the agreement type. Possible values are X12 and Edifact.";

        public const string DeprecatedContentTypeMessage = "ContentType is being deprecated without being replaced. It will be inferred from MapType";

        #region Help Messages

        #region General

        public const string ResourceGroupHelpMessage = "The resource group name.";
        public const string IntegrationAccountNameHelpMessage = "The integration account name.";
        public const string IntegrationAccountObjectHelpMessage = "An integration account object.";
        public const string IntegrationAccountResourceIdHelpMessage = "The integration account resource id.";

        #endregion

        #region Assemblies

        public const string AssemblyResourceIdHelpMessage = "The integration account assembly resource id.";
        public const string AssemblyInputObjectHelpMessage = "An integration account assembly.";
        public const string AssemblyMetadataHelpMessage = "The integration account assembly metadata.";
        public const string AssemblyContentLinkHelpMessage = "A publicly accessible link to the integration account assembly data.";
        public const string AssemblyFileDataHelpMessage = "The integration account assembly byte data.";
        public const string AssemblyNameHelpMessage = "The integration account assembly name.";
        public const string AssemblyFilePathHelpMessage = "The integration account assembly file path.";

        #endregion

        #region Batch Configurations

        public const string BatchConfigurationResourceIdHelpMessage = "The integration account batch configuration resource id.";
        public const string BatchConfigurationInputObjectHelpMessage = "An integration account batch configuration.";
        public const string BatchConfigurationMetadataHelpMessage = "The integration account batch configuration metadata.";
        public const string BatchConfigurationScheduleStartTimeHelpMessage = "The integration account batch configuration schedule start time.";
        public const string BatchConfigurationScheduleTimeZoneHelpMessage = "The integration account batch configuration schedule time zone.";
        public const string BatchConfigurationScheduleFrequencyHelpMessage = "The integration account batch configuration schedule frequency.";
        public const string BatchConfigurationScheduleIntervalHelpMessage = "The integration account batch configuration schedule interval.";
        public const string BatchConfigurationBatchSizeHelpMessage = "The integration account batch configuration batch size.";
        public const string BatchConfigurationMessageCountHelpMessage = "The integration account batch configuration message count.";
        public const string BatchConfigurationBatchGroupNameHelpMessage = "The integration account batch configuration group name.";
        public const string BatchConfigurationDefinitionHelpMessage = "The integration account batch configuration definition.";
        public const string BatchConfigurationFilePathHelpMessage = "The integration account batch configuration file path.";
        public const string BatchConfigurationNameHelpMessage = "The integration account batch configuration name.";

        #endregion

        #endregion
    }
}