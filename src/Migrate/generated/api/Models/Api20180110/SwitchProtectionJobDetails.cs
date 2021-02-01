namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>This class represents details for switch protection job.</summary>
    public partial class SwitchProtectionJobDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionJobDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionJobDetailsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetails"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetails __jobDetails = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetails();

        /// <summary>
        /// The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow
        /// object details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails AffectedObjectDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).AffectedObjectDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).AffectedObjectDetail = value; }

        /// <summary>Gets the type of job details (see JobDetailsTypes enum for possible values).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="NewReplicationProtectedItemId" /> property.</summary>
        private string _newReplicationProtectedItemId;

        /// <summary>ARM Id of the new replication protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NewReplicationProtectedItemId { get => this._newReplicationProtectedItemId; set => this._newReplicationProtectedItemId = value; }

        /// <summary>Creates an new <see cref="SwitchProtectionJobDetails" /> instance.</summary>
        public SwitchProtectionJobDetails()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__jobDetails), __jobDetails);
            await eventListener.AssertObjectIsValid(nameof(__jobDetails), __jobDetails);
        }
    }
    /// This class represents details for switch protection job.
    public partial interface ISwitchProtectionJobDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetails
    {
        /// <summary>ARM Id of the new replication protected item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM Id of the new replication protected item.",
        SerializedName = @"newReplicationProtectedItemId",
        PossibleTypes = new [] { typeof(string) })]
        string NewReplicationProtectedItemId { get; set; }

    }
    /// This class represents details for switch protection job.
    internal partial interface ISwitchProtectionJobDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal
    {
        /// <summary>ARM Id of the new replication protected item.</summary>
        string NewReplicationProtectedItemId { get; set; }

    }
}