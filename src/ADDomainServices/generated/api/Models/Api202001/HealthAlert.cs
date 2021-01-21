namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Health Alert Description</summary>
    public partial class HealthAlert :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlertInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Health Alert Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Issue" /> property.</summary>
        private string _issue;

        /// <summary>Health Alert Issue</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string Issue { get => this._issue; }

        /// <summary>Backing field for <see cref="LastDetected" /> property.</summary>
        private global::System.DateTime? _lastDetected;

        /// <summary>Health Alert Last Detected DateTime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public global::System.DateTime? LastDetected { get => this._lastDetected; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlertInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Issue</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlertInternal.Issue { get => this._issue; set { {_issue = value;} } }

        /// <summary>Internal Acessors for LastDetected</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlertInternal.LastDetected { get => this._lastDetected; set { {_lastDetected = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlertInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Raised</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlertInternal.Raised { get => this._raised; set { {_raised = value;} } }

        /// <summary>Internal Acessors for ResolutionUri</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlertInternal.ResolutionUri { get => this._resolutionUri; set { {_resolutionUri = value;} } }

        /// <summary>Internal Acessors for Severity</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlertInternal.Severity { get => this._severity; set { {_severity = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Health Alert Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Raised" /> property.</summary>
        private global::System.DateTime? _raised;

        /// <summary>Health Alert Raised DateTime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public global::System.DateTime? Raised { get => this._raised; }

        /// <summary>Backing field for <see cref="ResolutionUri" /> property.</summary>
        private string _resolutionUri;

        /// <summary>Health Alert TSG Link</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string ResolutionUri { get => this._resolutionUri; }

        /// <summary>Backing field for <see cref="Severity" /> property.</summary>
        private string _severity;

        /// <summary>Health Alert Severity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string Severity { get => this._severity; }

        /// <summary>Creates an new <see cref="HealthAlert" /> instance.</summary>
        public HealthAlert()
        {

        }
    }
    /// Health Alert Description
    public partial interface IHealthAlert :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>Health Alert Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Health Alert Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Health Alert Issue</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Health Alert Issue",
        SerializedName = @"issue",
        PossibleTypes = new [] { typeof(string) })]
        string Issue { get;  }
        /// <summary>Health Alert Last Detected DateTime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Health Alert Last Detected DateTime",
        SerializedName = @"lastDetected",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastDetected { get;  }
        /// <summary>Health Alert Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Health Alert Name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Health Alert Raised DateTime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Health Alert Raised DateTime",
        SerializedName = @"raised",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? Raised { get;  }
        /// <summary>Health Alert TSG Link</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Health Alert TSG Link",
        SerializedName = @"resolutionUri",
        PossibleTypes = new [] { typeof(string) })]
        string ResolutionUri { get;  }
        /// <summary>Health Alert Severity</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Health Alert Severity",
        SerializedName = @"severity",
        PossibleTypes = new [] { typeof(string) })]
        string Severity { get;  }

    }
    /// Health Alert Description
    internal partial interface IHealthAlertInternal

    {
        /// <summary>Health Alert Id</summary>
        string Id { get; set; }
        /// <summary>Health Alert Issue</summary>
        string Issue { get; set; }
        /// <summary>Health Alert Last Detected DateTime</summary>
        global::System.DateTime? LastDetected { get; set; }
        /// <summary>Health Alert Name</summary>
        string Name { get; set; }
        /// <summary>Health Alert Raised DateTime</summary>
        global::System.DateTime? Raised { get; set; }
        /// <summary>Health Alert TSG Link</summary>
        string ResolutionUri { get; set; }
        /// <summary>Health Alert Severity</summary>
        string Severity { get; set; }

    }
}