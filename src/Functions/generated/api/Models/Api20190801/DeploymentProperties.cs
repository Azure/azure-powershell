namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Deployment resource specific properties</summary>
    public partial class DeploymentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeploymentProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IDeploymentPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Active" /> property.</summary>
        private bool? _active;

        /// <summary>
        /// True if deployment is currently active, false if completed and null if not started.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Active { get => this._active; set => this._active = value; }

        /// <summary>Backing field for <see cref="Author" /> property.</summary>
        private string _author;

        /// <summary>Who authored the deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Author { get => this._author; set => this._author = value; }

        /// <summary>Backing field for <see cref="AuthorEmail" /> property.</summary>
        private string _authorEmail;

        /// <summary>Author email.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AuthorEmail { get => this._authorEmail; set => this._authorEmail = value; }

        /// <summary>Backing field for <see cref="Deployer" /> property.</summary>
        private string _deployer;

        /// <summary>Who performed the deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Deployer { get => this._deployer; set => this._deployer = value; }

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private string _detail;

        /// <summary>Details on deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; set => this._endTime = value; }

        /// <summary>Backing field for <see cref="Message" /> property.</summary>
        private string _message;

        /// <summary>Details about deployment status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Message { get => this._message; set => this._message = value; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; set => this._startTime = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private int? _status;

        /// <summary>Deployment status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? Status { get => this._status; set => this._status = value; }

        /// <summary>Creates an new <see cref="DeploymentProperties" /> instance.</summary>
        public DeploymentProperties()
        {

        }
    }
    /// Deployment resource specific properties
    public partial interface IDeploymentProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// True if deployment is currently active, false if completed and null if not started.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"True if deployment is currently active, false if completed and null if not started.",
        SerializedName = @"active",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Active { get; set; }
        /// <summary>Who authored the deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Who authored the deployment.",
        SerializedName = @"author",
        PossibleTypes = new [] { typeof(string) })]
        string Author { get; set; }
        /// <summary>Author email.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Author email.",
        SerializedName = @"author_email",
        PossibleTypes = new [] { typeof(string) })]
        string AuthorEmail { get; set; }
        /// <summary>Who performed the deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Who performed the deployment.",
        SerializedName = @"deployer",
        PossibleTypes = new [] { typeof(string) })]
        string Deployer { get; set; }
        /// <summary>Details on deployment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Details on deployment.",
        SerializedName = @"details",
        PossibleTypes = new [] { typeof(string) })]
        string Detail { get; set; }
        /// <summary>End time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"End time.",
        SerializedName = @"end_time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Details about deployment status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Details about deployment status.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string Message { get; set; }
        /// <summary>Start time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Start time.",
        SerializedName = @"start_time",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Deployment status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Deployment status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(int) })]
        int? Status { get; set; }

    }
    /// Deployment resource specific properties
    internal partial interface IDeploymentPropertiesInternal

    {
        /// <summary>
        /// True if deployment is currently active, false if completed and null if not started.
        /// </summary>
        bool? Active { get; set; }
        /// <summary>Who authored the deployment.</summary>
        string Author { get; set; }
        /// <summary>Author email.</summary>
        string AuthorEmail { get; set; }
        /// <summary>Who performed the deployment.</summary>
        string Deployer { get; set; }
        /// <summary>Details on deployment.</summary>
        string Detail { get; set; }
        /// <summary>End time.</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Details about deployment status.</summary>
        string Message { get; set; }
        /// <summary>Start time.</summary>
        global::System.DateTime? StartTime { get; set; }
        /// <summary>Deployment status.</summary>
        int? Status { get; set; }

    }
}