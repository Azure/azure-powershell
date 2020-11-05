namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Job details based on specific job type.</summary>
    public partial class JobDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal
    {

        /// <summary>Backing field for <see cref="AffectedObjectDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails _affectedObjectDetail;

        /// <summary>
        /// The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow
        /// object details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails AffectedObjectDetail { get => (this._affectedObjectDetail = this._affectedObjectDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsAffectedObjectDetails()); set => this._affectedObjectDetail = value; }

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets the type of job details (see JobDetailsTypes enum for possible values).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal.InstanceType { get => this._instanceType; set { {_instanceType = value;} } }

        /// <summary>Creates an new <see cref="JobDetails" /> instance.</summary>
        public JobDetails()
        {

        }
    }
    /// Job details based on specific job type.
    public partial interface IJobDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow
        /// object details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow object details.",
        SerializedName = @"affectedObjectDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails AffectedObjectDetail { get; set; }
        /// <summary>Gets the type of job details (see JobDetailsTypes enum for possible values).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the type of job details (see JobDetailsTypes enum for possible values).",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get;  }

    }
    /// Job details based on specific job type.
    internal partial interface IJobDetailsInternal

    {
        /// <summary>
        /// The affected object properties like source server, source cloud, target server, target cloud etc. based on the workflow
        /// object details.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails AffectedObjectDetail { get; set; }
        /// <summary>Gets the type of job details (see JobDetailsTypes enum for possible values).</summary>
        string InstanceType { get; set; }

    }
}