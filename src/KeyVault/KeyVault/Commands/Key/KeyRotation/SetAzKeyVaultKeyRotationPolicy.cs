using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

using Newtonsoft.Json;

using System;
using System.Management.Automation;
using Track2Sdk = Azure.Security.KeyVault.Keys;
using System.IO;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.KeyVault.Properties;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Key
{
    /// <summary>
    /// Updates the KeyRotationPolicy for the specified key in Key Vault.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultKeyRotationPolicy", SupportsShouldProcess = true, DefaultParameterSetName = SetByExpandedPropertiesViaVaultName)]
    [OutputType(typeof(PSKeyRotationPolicy))]
    public class SetAzKeyVaultKeyRotationPolicy: KeyVaultCmdletBase
    {
        #region Parameter Set Names

        private const string SetByExpandedPropertiesViaVaultName = "ByVaultName";
        private const string SetByRotationPolicyFileViaVaultName = "SetByRotationPolicyFileViaVaultName";

        private const string SetByExpandedPropertiesViaKeyInputObject = "ByKeyInputObject";
        private const string SetByRotationPolicyFileViaKeyInputObject = "SetByRotationPolicyFileViaKeyInputObject";

        private const string ByKeyRotationPolicyInputObjectParameterSet = "ByKeyRotationPolicyInputObject";

        #endregion

        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SetByExpandedPropertiesViaVaultName, HelpMessage = "Vault name.")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SetByRotationPolicyFileViaVaultName)]
        [ResourceNameCompleter("Microsoft.KeyVault/vaults", "FakeResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Key name.
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SetByExpandedPropertiesViaVaultName, HelpMessage = "Key name.")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = SetByRotationPolicyFileViaVaultName)]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        /// <summary>
        /// Key object
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SetByExpandedPropertiesViaKeyInputObject,
            ValueFromPipeline = true, HelpMessage = "Key object")]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = SetByRotationPolicyFileViaKeyInputObject,
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("Key")]
        public PSKeyVaultKeyIdentityItem InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByKeyRotationPolicyInputObjectParameterSet,
                 ValueFromPipeline = true, HelpMessage = "PSKeyRotationPolicy object.")]
        public PSKeyRotationPolicy KeyRotationPolicy { get; set; }

        [Parameter(ParameterSetName = SetByExpandedPropertiesViaVaultName, 
            HelpMessage = "The expiryTime will be applied on the new key version. It should be at least 28 days. It will be in ISO 8601 Format. Examples: 90 days: P90D, 3 months: P3M, 48 hours: PT48H, 1 year and 10 days: P1Y10D")]
        [Parameter(ParameterSetName = SetByExpandedPropertiesViaKeyInputObject)]
        public string ExpiresIn { get; set; }


        [Parameter(ParameterSetName = SetByExpandedPropertiesViaVaultName,
            HelpMessage = "PSKeyRotationLifetimeAction object.")]
        [Parameter(ParameterSetName = SetByExpandedPropertiesViaKeyInputObject)]
        public PSKeyRotationLifetimeAction[] KeyRotationLifetimeAction { get; set; }

        [Parameter(Mandatory = true,  ParameterSetName = SetByRotationPolicyFileViaVaultName,
            HelpMessage = "A path to the rotation policy file that contains JSON policy definition.")]
        [Parameter(Mandatory = true,  ParameterSetName = SetByRotationPolicyFileViaKeyInputObject)]
        public string PolicyPath { get; set; }
        #endregion

        protected override void BeginProcessing()
        {
            PolicyPath = this.TryResolvePath(PolicyPath);
            base.BeginProcessing();
        }

        internal void ValidateParameters()
        {
            if((this.ParameterSetName.Equals(SetByExpandedPropertiesViaVaultName) || 
                this.ParameterSetName.Equals(SetByExpandedPropertiesViaKeyInputObject)) && 
                null == ExpiresIn && null == KeyRotationLifetimeAction)
            {
                throw new ArgumentException(string.Format("Must specify ExpiresIn or KeyRotationLifetimeAction."));
            }

            if(this.IsParameterBound(c => c.PolicyPath) && !File.Exists(PolicyPath))
            {
                throw new AzPSFileNotFoundException(string.Format(Resources.FileNotFound, PolicyPath), nameof(PolicyPath));
            }
        }

        internal void NormalizeParameterSets()
        {
            if (null != InputObject)
            {
                Name = InputObject.Name;

                if (InputObject.IsHsm)
                {
                    throw new NotImplementedException("Updating key rotation policy on managed HSM is not supported yet");
                }
                else
                {
                    VaultName = InputObject.VaultName;
                }
            }

            switch (this.ParameterSetName)
            {
                case SetByRotationPolicyFileViaVaultName:
                case SetByRotationPolicyFileViaKeyInputObject:
                    KeyRotationPolicy = ConstructKeyRotationPolicyFromFile(PolicyPath);
                    break;
                case SetByExpandedPropertiesViaVaultName:
                case SetByExpandedPropertiesViaKeyInputObject:
                    KeyRotationPolicy = new PSKeyRotationPolicy()
                    {
                        VaultName = VaultName,
                        KeyName = Name,
                        ExpiresIn = ExpiresIn ?? Track2DataClient.GetKeyRotationPolicy(VaultName, Name).ExpiresIn,
                        LifetimeActions = KeyRotationLifetimeAction ?? Track2DataClient.GetKeyRotationPolicy(VaultName, Name).LifetimeActions
                    };
                    break;
                default:
                    // do nothing
                    break;
            }

        }

        private PSKeyRotationPolicy ConstructKeyRotationPolicyFromFile(string policyPath)
        {
            try
            {
                string content = File.ReadAllText(policyPath);
                // first-level dictionary
                var dict = JsonUtilities.DeserializeJson(content, true);

                // second-level dictionary
                var attributes = JsonUtilities.DeserializeJson(JsonConvert.SerializeObject(dict["attributes"]), true);
                var lifetimeActionsArray = JsonConvert.DeserializeObject<object[]>(JsonConvert.SerializeObject(dict["lifetimeActions"]));

                // third-level dictionary
                string expiresIn = attributes["expiryTime"].ToString();

                var lifetimeActions = new List<PSKeyRotationLifetimeAction>();
                lifetimeActionsArray?.ForEach((lifetimeAction) =>
                {
                    var lifetimeActionDict = JsonUtilities.DeserializeJson(JsonConvert.SerializeObject(lifetimeAction), true);
                    var action = JsonUtilities.DeserializeJson(JsonConvert.SerializeObject(lifetimeActionDict["action"]), true);
                    var trigger = JsonUtilities.DeserializeJson(JsonConvert.SerializeObject(lifetimeActionDict["trigger"]), true);

                    // 4th-level dictionary
                    string actionType = action["type"].ToString();

                    // timeAfterCreate or timeBeforeExpiry may absent
                    string timeAfterCreate = trigger.ContainsKey("timeAfterCreate") ? trigger["timeAfterCreate"]?.ToString() : null;
                    string timeBeforeExpiry = trigger.ContainsKey("timeBeforeExpiry") ? trigger["timeBeforeExpiry"]?.ToString() : null;

                    lifetimeActions.Add(new PSKeyRotationLifetimeAction() 
                    {
                        Action = actionType,
                        TimeAfterCreate = timeAfterCreate,
                        TimeBeforeExpiry = timeBeforeExpiry
                    });
                });
                
                return new PSKeyRotationPolicy()
                {
                    VaultName = this.VaultName,
                    KeyName = this.Name,
                    ExpiresIn = expiresIn,
                    LifetimeActions = lifetimeActions
                };
            }
            catch
            {
                throw new AzPSArgumentException(string.Format("Deserialize {0} failed", policyPath), nameof(PolicyPath));
            }

        }

        public override void ExecuteCmdlet()
        {
            ValidateParameters();
            NormalizeParameterSets();

            ConfirmAction(KeyRotationPolicy.KeyName, Properties.Resources.SetKeyRotationPolicy, () => 
            {
                WriteObject(this.Track2DataClient.SetKeyRotationPolicy(KeyRotationPolicy));
            });
        }
    }
}
