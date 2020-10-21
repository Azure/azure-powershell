namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Deployment instance payload</summary>
    public partial class DeploymentInstance :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstance,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstanceInternal
    {

        /// <summary>Backing field for <see cref="DiscoveryStatus" /> property.</summary>
        private string _discoveryStatus;

        /// <summary>Discovery status of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string DiscoveryStatus { get => this._discoveryStatus; }

        /// <summary>Internal Acessors for DiscoveryStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstanceInternal.DiscoveryStatus { get => this._discoveryStatus; set { {_discoveryStatus = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstanceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Reason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstanceInternal.Reason { get => this._reason; set { {_reason = value;} } }

        /// <summary>Internal Acessors for StartTime</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstanceInternal.StartTime { get => this._startTime; set { {_startTime = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IDeploymentInstanceInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Reason" /> property.</summary>
        private string _reason;

        /// <summary>Failed reason of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Reason { get => this._reason; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private string _startTime;

        /// <summary>Start time of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string StartTime { get => this._startTime; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private string _status;

        /// <summary>Status of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Status { get => this._status; }

        /// <summary>Creates an new <see cref="DeploymentInstance" /> instance.</summary>
        public DeploymentInstance()
        {

        }
    }
    /// Deployment instance payload
    public partial interface IDeploymentInstance :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Discovery status of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Discovery status of the deployment instance",
        SerializedName = @"discoveryStatus",
        PossibleTypes = new [] { typeof(string) })]
        string DiscoveryStatus { get;  }
        /// <summary>Name of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the deployment instance",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Failed reason of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Failed reason of the deployment instance",
        SerializedName = @"reason",
        PossibleTypes = new [] { typeof(string) })]
        string Reason { get;  }
        /// <summary>Start time of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Start time of the deployment instance",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(string) })]
        string StartTime { get;  }
        /// <summary>Status of the deployment instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the deployment instance",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(string) })]
        string Status { get;  }

    }
    /// Deployment instance payload
    public partial interface IDeploymentInstanceInternal

    {
        /// <summary>Discovery status of the deployment instance</summary>
        string DiscoveryStatus { get; set; }
        /// <summary>Name of the deployment instance</summary>
        string Name { get; set; }
        /// <summary>Failed reason of the deployment instance</summary>
        string Reason { get; set; }
        /// <summary>Start time of the deployment instance</summary>
        string StartTime { get; set; }
        /// <summary>Status of the deployment instance</summary>
        string Status { get; set; }

    }
}