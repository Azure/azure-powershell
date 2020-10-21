namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Assessment properties that can be shared by various publishers.</summary>
    public partial class AssessmentDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsInternal
    {

        /// <summary>Backing field for <see cref="AssessmentId" /> property.</summary>
        private string _assessmentId;

        /// <summary>Gets or sets the id of the assessment done on the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string AssessmentId { get => this._assessmentId; set => this._assessmentId = value; }

        /// <summary>Backing field for <see cref="BiosId" /> property.</summary>
        private string _biosId;

        /// <summary>Gets or sets the BIOS ID of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string BiosId { get => this._biosId; set => this._biosId = value; }

        /// <summary>Backing field for <see cref="EnqueueTime" /> property.</summary>
        private string _enqueueTime;

        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string EnqueueTime { get => this._enqueueTime; set => this._enqueueTime = value; }

        /// <summary>Backing field for <see cref="ExtendedInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsExtendedInfo _extendedInfo;

        /// <summary>Gets or sets the ISV specific extended information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsExtendedInfo ExtendedInfo { get => (this._extendedInfo = this._extendedInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.AssessmentDetailsExtendedInfo()); set => this._extendedInfo = value; }

        /// <summary>Backing field for <see cref="FabricType" /> property.</summary>
        private string _fabricType;

        /// <summary>Gets or sets the fabric type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FabricType { get => this._fabricType; set => this._fabricType = value; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>Gets or sets the FQDN of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; set => this._fqdn = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string[] _iPAddress;

        /// <summary>
        /// Gets or sets the list of IP addresses of the machine. IP addresses could be IP V4 or IP V6.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="LastUpdatedTime" /> property.</summary>
        private global::System.DateTime? _lastUpdatedTime;

        /// <summary>Gets or sets the time of the last modification of the machine details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public global::System.DateTime? LastUpdatedTime { get => this._lastUpdatedTime; set => this._lastUpdatedTime = value; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string[] _macAddress;

        /// <summary>Gets or sets the list of MAC addresses of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string[] MacAddress { get => this._macAddress; set => this._macAddress = value; }

        /// <summary>Backing field for <see cref="MachineId" /> property.</summary>
        private string _machineId;

        /// <summary>Gets or sets the unique identifier of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MachineId { get => this._machineId; set => this._machineId = value; }

        /// <summary>Backing field for <see cref="MachineManagerId" /> property.</summary>
        private string _machineManagerId;

        /// <summary>Gets or sets the unique identifier of the virtual machine manager(vCenter/VMM).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MachineManagerId { get => this._machineManagerId; set => this._machineManagerId = value; }

        /// <summary>Backing field for <see cref="MachineName" /> property.</summary>
        private string _machineName;

        /// <summary>Gets or sets the name of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string MachineName { get => this._machineName; set => this._machineName = value; }

        /// <summary>Backing field for <see cref="SolutionName" /> property.</summary>
        private string _solutionName;

        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string SolutionName { get => this._solutionName; set => this._solutionName = value; }

        /// <summary>Backing field for <see cref="TargetStorageType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsTargetStorageType _targetStorageType;

        /// <summary>Gets or sets the target storage type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsTargetStorageType TargetStorageType { get => (this._targetStorageType = this._targetStorageType ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.AssessmentDetailsTargetStorageType()); set => this._targetStorageType = value; }

        /// <summary>Backing field for <see cref="TargetVMLocation" /> property.</summary>
        private string _targetVMLocation;

        /// <summary>Gets or sets the target VM location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetVMLocation { get => this._targetVMLocation; set => this._targetVMLocation = value; }

        /// <summary>Backing field for <see cref="TargetVMSize" /> property.</summary>
        private string _targetVMSize;

        /// <summary>Gets or sets the target VM size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string TargetVMSize { get => this._targetVMSize; set => this._targetVMSize = value; }

        /// <summary>Creates an new <see cref="AssessmentDetails" /> instance.</summary>
        public AssessmentDetails()
        {

        }
    }
    /// Assessment properties that can be shared by various publishers.
    public partial interface IAssessmentDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the id of the assessment done on the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the id of the assessment done on the machine.",
        SerializedName = @"assessmentId",
        PossibleTypes = new [] { typeof(string) })]
        string AssessmentId { get; set; }
        /// <summary>Gets or sets the BIOS ID of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the BIOS ID of the machine.",
        SerializedName = @"biosId",
        PossibleTypes = new [] { typeof(string) })]
        string BiosId { get; set; }
        /// <summary>Gets or sets the time the message was enqueued.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time the message was enqueued.",
        SerializedName = @"enqueueTime",
        PossibleTypes = new [] { typeof(string) })]
        string EnqueueTime { get; set; }
        /// <summary>Gets or sets the ISV specific extended information.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the ISV specific extended information.",
        SerializedName = @"extendedInfo",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsExtendedInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Gets or sets the fabric type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the fabric type.",
        SerializedName = @"fabricType",
        PossibleTypes = new [] { typeof(string) })]
        string FabricType { get; set; }
        /// <summary>Gets or sets the FQDN of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the FQDN of the machine.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>
        /// Gets or sets the list of IP addresses of the machine. IP addresses could be IP V4 or IP V6.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of IP addresses of the machine. IP addresses could be IP V4 or IP V6.",
        SerializedName = @"ipAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] IPAddress { get; set; }
        /// <summary>Gets or sets the time of the last modification of the machine details.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the time of the last modification of the machine details.",
        SerializedName = @"lastUpdatedTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the list of MAC addresses of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of MAC addresses of the machine.",
        SerializedName = @"macAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string[] MacAddress { get; set; }
        /// <summary>Gets or sets the unique identifier of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the unique identifier of the machine.",
        SerializedName = @"machineId",
        PossibleTypes = new [] { typeof(string) })]
        string MachineId { get; set; }
        /// <summary>Gets or sets the unique identifier of the virtual machine manager(vCenter/VMM).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the unique identifier of the virtual machine manager(vCenter/VMM).",
        SerializedName = @"machineManagerId",
        PossibleTypes = new [] { typeof(string) })]
        string MachineManagerId { get; set; }
        /// <summary>Gets or sets the name of the machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the machine.",
        SerializedName = @"machineName",
        PossibleTypes = new [] { typeof(string) })]
        string MachineName { get; set; }
        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the name of the solution that sent the data.",
        SerializedName = @"solutionName",
        PossibleTypes = new [] { typeof(string) })]
        string SolutionName { get; set; }
        /// <summary>Gets or sets the target storage type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the target storage type.",
        SerializedName = @"targetStorageType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsTargetStorageType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsTargetStorageType TargetStorageType { get; set; }
        /// <summary>Gets or sets the target VM location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the target VM location.",
        SerializedName = @"targetVMLocation",
        PossibleTypes = new [] { typeof(string) })]
        string TargetVMLocation { get; set; }
        /// <summary>Gets or sets the target VM size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the target VM size.",
        SerializedName = @"targetVMSize",
        PossibleTypes = new [] { typeof(string) })]
        string TargetVMSize { get; set; }

    }
    /// Assessment properties that can be shared by various publishers.
    internal partial interface IAssessmentDetailsInternal

    {
        /// <summary>Gets or sets the id of the assessment done on the machine.</summary>
        string AssessmentId { get; set; }
        /// <summary>Gets or sets the BIOS ID of the machine.</summary>
        string BiosId { get; set; }
        /// <summary>Gets or sets the time the message was enqueued.</summary>
        string EnqueueTime { get; set; }
        /// <summary>Gets or sets the ISV specific extended information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsExtendedInfo ExtendedInfo { get; set; }
        /// <summary>Gets or sets the fabric type.</summary>
        string FabricType { get; set; }
        /// <summary>Gets or sets the FQDN of the machine.</summary>
        string Fqdn { get; set; }
        /// <summary>
        /// Gets or sets the list of IP addresses of the machine. IP addresses could be IP V4 or IP V6.
        /// </summary>
        string[] IPAddress { get; set; }
        /// <summary>Gets or sets the time of the last modification of the machine details.</summary>
        global::System.DateTime? LastUpdatedTime { get; set; }
        /// <summary>Gets or sets the list of MAC addresses of the machine.</summary>
        string[] MacAddress { get; set; }
        /// <summary>Gets or sets the unique identifier of the machine.</summary>
        string MachineId { get; set; }
        /// <summary>Gets or sets the unique identifier of the virtual machine manager(vCenter/VMM).</summary>
        string MachineManagerId { get; set; }
        /// <summary>Gets or sets the name of the machine.</summary>
        string MachineName { get; set; }
        /// <summary>Gets or sets the name of the solution that sent the data.</summary>
        string SolutionName { get; set; }
        /// <summary>Gets or sets the target storage type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IAssessmentDetailsTargetStorageType TargetStorageType { get; set; }
        /// <summary>Gets or sets the target VM location.</summary>
        string TargetVMLocation { get; set; }
        /// <summary>Gets or sets the target VM size.</summary>
        string TargetVMSize { get; set; }

    }
}