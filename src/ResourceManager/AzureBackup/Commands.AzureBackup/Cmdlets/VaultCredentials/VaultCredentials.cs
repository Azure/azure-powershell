using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.AzureBackup.Cmdlets
{
    /// <summary>
    /// Class to define vault credentials
    /// </summary>
    [DataContract]
    public class VaultCreds
    {
        #region Properties

        /// <summary>
        /// Gets or sets the key name for SubscriptionId entry
        /// </summary>
        [DataMember(Order = 0)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the key name for ResourceType entry
        /// </summary>
        [DataMember(Order = 1)]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the key name for ResourceName entry
        /// </summary>
        [DataMember(Order = 2)]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the key name for ManagementCert entry
        /// </summary>
        [DataMember(Order = 3)]
        public string ManagementCert { get; set; }

        /// <summary>
        /// Gets or sets the key name for AcsNamespace entry
        /// </summary>
        [DataMember(Order = 4)]
        public AcsNamespace AcsNamespace { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the VaultCreds class
        /// </summary>
        public VaultCreds() { }

        /// <summary>
        /// Initializes a new instance of the VaultCreds class
        /// </summary>
        /// <param name="subscriptionId">subscription id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">acs namespace</param>
        public VaultCreds(string subscriptionId, string resourceType, string resourceName, string managementCert, AcsNamespace acsNamespace)
        {
            SubscriptionId = subscriptionId;
            ResourceType = resourceType;
            ResourceName = resourceName;
            ManagementCert = managementCert;
            AcsNamespace = acsNamespace;
        }

        #endregion
    }

    /// <summary>
    /// Class to define backup vault credentials
    /// </summary>
    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Grouping classes based on entity")]
    public class BackupVaultCreds : VaultCreds
    {
        /// <summary>
        /// Gets or sets the agent links
        /// </summary>
        [DataMember(Order = 0)]
        public string AgentLinks { get; set; }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BackupVaultCreds class
        /// </summary>
        public BackupVaultCreds()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BackupVaultCreds class
        /// </summary>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">acs namespace</param>
        public BackupVaultCreds(string subscriptionId, string resourceType, string resourceName, string managementCert, AcsNamespace acsNamespace)
            : base(subscriptionId, resourceType, resourceName, managementCert, acsNamespace) { }

        /// <summary>
        /// Initializes a new instance of the BackupVaultCreds class
        /// </summary>
        /// <param name="subscriptionId">subscription Id</param>
        /// <param name="resourceType">resource type</param>
        /// <param name="resourceName">resource name</param>
        /// <param name="managementCert">management cert</param>
        /// <param name="acsNamespace">acs namespace</param>
        /// <param name="agentLinks">agent links</param>
        public BackupVaultCreds(string subscriptionId, string resourceType, string resourceName, string managementCert, AcsNamespace acsNamespace, string agentLinks)
            : this(subscriptionId, resourceType, resourceName, managementCert, acsNamespace)
        {
            AgentLinks = agentLinks;
        }

        #endregion
    }
}
