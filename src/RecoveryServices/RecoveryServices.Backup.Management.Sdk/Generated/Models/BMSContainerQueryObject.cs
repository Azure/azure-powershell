// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    using System.Linq;

    /// <summary>
    /// The query filters that can be used with the list containers API.
    /// </summary>
    public partial class BMSContainerQueryObject
    {
        /// <summary>
        /// Initializes a new instance of the BMSContainerQueryObject class.
        /// </summary>
        public BMSContainerQueryObject()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BMSContainerQueryObject class.
        /// </summary>

        /// <param name="backupManagementType">Backup management type for this container.
        /// Possible values include: &#39;Invalid&#39;, &#39;AzureIaasVM&#39;, &#39;MAB&#39;, &#39;DPM&#39;,
        /// &#39;AzureBackupServer&#39;, &#39;AzureSql&#39;, &#39;AzureStorage&#39;, &#39;AzureWorkload&#39;,
        /// &#39;DefaultBackup&#39;</param>

        /// <param name="containerType">Type of container for filter
        /// Possible values include: &#39;Invalid&#39;, &#39;Unknown&#39;, &#39;IaasVMContainer&#39;,
        /// &#39;IaasVMServiceContainer&#39;, &#39;DPMContainer&#39;, &#39;AzureBackupServerContainer&#39;,
        /// &#39;MABContainer&#39;, &#39;Cluster&#39;, &#39;AzureSqlContainer&#39;, &#39;Windows&#39;, &#39;VCenter&#39;,
        /// &#39;VMAppContainer&#39;, &#39;SQLAGWorkLoadContainer&#39;, &#39;StorageContainer&#39;,
        /// &#39;GenericContainer&#39;, &#39;HanaHSRContainer&#39;</param>

        /// <param name="backupEngineName">Backup engine name
        /// </param>

        /// <param name="fabricName">Fabric name for filter
        /// </param>

        /// <param name="status">Status of registration of this container with the Recovery Services Vault.
        /// </param>

        /// <param name="friendlyName">Friendly name of this container.
        /// </param>
        public BMSContainerQueryObject(string backupManagementType, string containerType = default(string), string backupEngineName = default(string), string fabricName = default(string), string status = default(string), string friendlyName = default(string))

        {
            this.BackupManagementType = backupManagementType;
            this.ContainerType = containerType;
            this.BackupEngineName = backupEngineName;
            this.FabricName = fabricName;
            this.Status = status;
            this.FriendlyName = friendlyName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets backup management type for this container. Possible values include: &#39;Invalid&#39;, &#39;AzureIaasVM&#39;, &#39;MAB&#39;, &#39;DPM&#39;, &#39;AzureBackupServer&#39;, &#39;AzureSql&#39;, &#39;AzureStorage&#39;, &#39;AzureWorkload&#39;, &#39;DefaultBackup&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "backupManagementType")]
        public string BackupManagementType {get; set; }

        /// <summary>
        /// Gets or sets type of container for filter Possible values include: &#39;Invalid&#39;, &#39;Unknown&#39;, &#39;IaasVMContainer&#39;, &#39;IaasVMServiceContainer&#39;, &#39;DPMContainer&#39;, &#39;AzureBackupServerContainer&#39;, &#39;MABContainer&#39;, &#39;Cluster&#39;, &#39;AzureSqlContainer&#39;, &#39;Windows&#39;, &#39;VCenter&#39;, &#39;VMAppContainer&#39;, &#39;SQLAGWorkLoadContainer&#39;, &#39;StorageContainer&#39;, &#39;GenericContainer&#39;, &#39;HanaHSRContainer&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "containerType")]
        public string ContainerType {get; set; }

        /// <summary>
        /// Gets or sets backup engine name
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "backupEngineName")]
        public string BackupEngineName {get; set; }

        /// <summary>
        /// Gets or sets fabric name for filter
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "fabricName")]
        public string FabricName {get; set; }

        /// <summary>
        /// Gets or sets status of registration of this container with the Recovery
        /// Services Vault.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "status")]
        public string Status {get; set; }

        /// <summary>
        /// Gets or sets friendly name of this container.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "friendlyName")]
        public string FriendlyName {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.BackupManagementType == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "BackupManagementType");
            }






        }
    }
}