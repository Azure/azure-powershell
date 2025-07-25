// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.NetApp.Models
{
    using System.Linq;

    /// <summary>
    /// Backup of a Volume
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class Backup2023_07_01 : ProxyResource
    {
        /// <summary>
        /// Initializes a new instance of the Backup class.
        /// </summary>
        public Backup2023_07_01()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Backup class.
        /// </summary>

        /// <param name="id">Fully qualified resource ID for the resource. Ex -
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </param>

        /// <param name="name">The name of the resource
        /// </param>

        /// <param name="type">The type of the resource. E.g. &#34;Microsoft.Compute/virtualMachines&#34; or
        /// &#34;Microsoft.Storage/storageAccounts&#34;
        /// </param>

        /// <param name="systemData">Azure Resource Manager metadata containing createdBy and modifiedBy
        /// information.
        /// </param>

        /// <param name="location">Resource location
        /// </param>

        /// <param name="backupType">Type of backup Manual or Scheduled
        /// Possible values include: 'Manual', 'Scheduled'</param>

        /// <param name="backupId">UUID v4 used to identify the Backup
        /// </param>

        /// <param name="creationDate">The creation date of the backup
        /// </param>

        /// <param name="provisioningState">Azure lifecycle management
        /// </param>

        /// <param name="size">Size of backup
        /// </param>

        /// <param name="label">Label for backup
        /// </param>

        /// <param name="failureReason">Failure reason
        /// </param>

        /// <param name="volumeName">Volume name
        /// </param>

        /// <param name="useExistingSnapshot">Manual backup an already existing snapshot. This will always be false for
        /// scheduled backups and true/false for manual backups
        /// </param>
        public Backup2023_07_01(string location, string id = default(string), string name = default(string), string type = default(string), SystemData systemData = default(SystemData), string backupType = default(string), string backupId = default(string), System.DateTime? creationDate = default(System.DateTime?), string provisioningState = default(string), long? size = default(long?), string label = default(string), string failureReason = default(string), string volumeName = default(string), bool? useExistingSnapshot = default(bool?))

        : base(id, name, type, systemData)
        {
            this.Location = location;
            this.BackupType = backupType;
            this.BackupId = backupId;
            this.CreationDate = creationDate;
            this.ProvisioningState = provisioningState;
            this.Size = size;
            this.Label = label;
            this.FailureReason = failureReason;
            this.VolumeName = volumeName;
            this.UseExistingSnapshot = useExistingSnapshot;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets resource location
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "location")]
        public string Location {get; set; }

        /// <summary>
        /// Gets type of backup Manual or Scheduled Possible values include: &#39;Manual&#39;, &#39;Scheduled&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.backupType")]
        public string BackupType {get; private set; }

        /// <summary>
        /// Gets uUID v4 used to identify the Backup
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.backupId")]
        public string BackupId {get; private set; }

        /// <summary>
        /// Gets the creation date of the backup
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.creationDate")]
        public System.DateTime? CreationDate {get; private set; }

        /// <summary>
        /// Gets azure lifecycle management
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState {get; private set; }

        /// <summary>
        /// Gets size of backup
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.size")]
        public long? Size {get; private set; }

        /// <summary>
        /// Gets or sets label for backup
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.label")]
        public string Label {get; set; }

        /// <summary>
        /// Gets failure reason
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.failureReason")]
        public string FailureReason {get; private set; }

        /// <summary>
        /// Gets volume name
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.volumeName")]
        public string VolumeName {get; private set; }

        /// <summary>
        /// Gets or sets manual backup an already existing snapshot. This will always
        /// be false for scheduled backups and true/false for manual backups
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.useExistingSnapshot")]
        public bool? UseExistingSnapshot {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.Location == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Location");
            }


            if (this.BackupId != null)
            {
                if (this.BackupId.Length > 36)
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.MaxLength, "BackupId", 36);
                }
                if (this.BackupId.Length < 36)
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.MinLength, "BackupId", 36);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.BackupId, "^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$"))
                {
                    throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.Pattern, "BackupId", "^[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$");
                }
            }




        }
    }
}