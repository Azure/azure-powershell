namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>This class represents the details for a test failover job.</summary>
    public partial class TestFailoverJobDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverJobDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ITestFailoverJobDetailsInternal,
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
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsAffectedObjectDetails AffectedObjectDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).AffectedObjectDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).AffectedObjectDetail = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="Comment" /> property.</summary>
        private string _comment;

        /// <summary>The test failover comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Comment { get => this._comment; set => this._comment = value; }

        /// <summary>Gets the type of job details (see JobDetailsTypes enum for possible values).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).InstanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal.InstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal)__jobDetails).InstanceType = value; }

        /// <summary>Backing field for <see cref="NetworkFriendlyName" /> property.</summary>
        private string _networkFriendlyName;

        /// <summary>The test network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkFriendlyName { get => this._networkFriendlyName; set => this._networkFriendlyName = value; }

        /// <summary>Backing field for <see cref="NetworkName" /> property.</summary>
        private string _networkName;

        /// <summary>The test network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkName { get => this._networkName; set => this._networkName = value; }

        /// <summary>Backing field for <see cref="NetworkType" /> property.</summary>
        private string _networkType;

        /// <summary>The test network type (see TestFailoverInput enum for possible values).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string NetworkType { get => this._networkType; set => this._networkType = value; }

        /// <summary>Backing field for <see cref="ProtectedItemDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails[] _protectedItemDetail;

        /// <summary>The test VM details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails[] ProtectedItemDetail { get => this._protectedItemDetail; set => this._protectedItemDetail = value; }

        /// <summary>Backing field for <see cref="TestFailoverStatus" /> property.</summary>
        private string _testFailoverStatus;

        /// <summary>The test failover status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TestFailoverStatus { get => this._testFailoverStatus; set => this._testFailoverStatus = value; }

        /// <summary>Creates an new <see cref="TestFailoverJobDetails" /> instance.</summary>
        public TestFailoverJobDetails()
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
    /// This class represents the details for a test failover job.
    public partial interface ITestFailoverJobDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetails
    {
        /// <summary>The test failover comments.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test failover comments.",
        SerializedName = @"comments",
        PossibleTypes = new [] { typeof(string) })]
        string Comment { get; set; }
        /// <summary>The test network friendly name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test network friendly name.",
        SerializedName = @"networkFriendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkFriendlyName { get; set; }
        /// <summary>The test network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test network name.",
        SerializedName = @"networkName",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkName { get; set; }
        /// <summary>The test network type (see TestFailoverInput enum for possible values).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test network type (see TestFailoverInput enum for possible values).",
        SerializedName = @"networkType",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkType { get; set; }
        /// <summary>The test VM details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test VM details.",
        SerializedName = @"protectedItemDetails",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails[] ProtectedItemDetail { get; set; }
        /// <summary>The test failover status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The test failover status.",
        SerializedName = @"testFailoverStatus",
        PossibleTypes = new [] { typeof(string) })]
        string TestFailoverStatus { get; set; }

    }
    /// This class represents the details for a test failover job.
    internal partial interface ITestFailoverJobDetailsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IJobDetailsInternal
    {
        /// <summary>The test failover comments.</summary>
        string Comment { get; set; }
        /// <summary>The test network friendly name.</summary>
        string NetworkFriendlyName { get; set; }
        /// <summary>The test network name.</summary>
        string NetworkName { get; set; }
        /// <summary>The test network type (see TestFailoverInput enum for possible values).</summary>
        string NetworkType { get; set; }
        /// <summary>The test VM details.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IFailoverReplicationProtectedItemDetails[] ProtectedItemDetail { get; set; }
        /// <summary>The test failover status.</summary>
        string TestFailoverStatus { get; set; }

    }
}