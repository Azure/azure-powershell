namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>MSDeployStatus resource specific properties</summary>
    public partial class MSDeployStatusProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployStatusProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployStatusPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Complete" /> property.</summary>
        private bool? _complete;

        /// <summary>Whether the deployment operation has completed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Complete { get => this._complete; }

        /// <summary>Backing field for <see cref="Deployer" /> property.</summary>
        private string _deployer;

        /// <summary>Username of deployer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Deployer { get => this._deployer; }

        /// <summary>Backing field for <see cref="EndTime" /> property.</summary>
        private global::System.DateTime? _endTime;

        /// <summary>End time of deploy operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? EndTime { get => this._endTime; }

        /// <summary>Internal Acessors for Complete</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployStatusPropertiesInternal.Complete { get => this._complete; set { {_complete = value;} } }

        /// <summary>Internal Acessors for Deployer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployStatusPropertiesInternal.Deployer { get => this._deployer; set { {_deployer = value;} } }

        /// <summary>Internal Acessors for EndTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployStatusPropertiesInternal.EndTime { get => this._endTime; set { {_endTime = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployStatusPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for StartTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IMSDeployStatusPropertiesInternal.StartTime { get => this._startTime; set { {_startTime = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployProvisioningState? _provisioningState;

        /// <summary>Provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="StartTime" /> property.</summary>
        private global::System.DateTime? _startTime;

        /// <summary>Start time of deploy operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? StartTime { get => this._startTime; }

        /// <summary>Creates an new <see cref="MSDeployStatusProperties" /> instance.</summary>
        public MSDeployStatusProperties()
        {

        }
    }
    /// MSDeployStatus resource specific properties
    public partial interface IMSDeployStatusProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Whether the deployment operation has completed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Whether the deployment operation has completed",
        SerializedName = @"complete",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Complete { get;  }
        /// <summary>Username of deployer</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Username of deployer",
        SerializedName = @"deployer",
        PossibleTypes = new [] { typeof(string) })]
        string Deployer { get;  }
        /// <summary>End time of deploy operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"End time of deploy operation",
        SerializedName = @"endTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? EndTime { get;  }
        /// <summary>Provisioning state</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployProvisioningState? ProvisioningState { get;  }
        /// <summary>Start time of deploy operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Start time of deploy operation",
        SerializedName = @"startTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? StartTime { get;  }

    }
    /// MSDeployStatus resource specific properties
    internal partial interface IMSDeployStatusPropertiesInternal

    {
        /// <summary>Whether the deployment operation has completed</summary>
        bool? Complete { get; set; }
        /// <summary>Username of deployer</summary>
        string Deployer { get; set; }
        /// <summary>End time of deploy operation</summary>
        global::System.DateTime? EndTime { get; set; }
        /// <summary>Provisioning state</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.MSDeployProvisioningState? ProvisioningState { get; set; }
        /// <summary>Start time of deploy operation</summary>
        global::System.DateTime? StartTime { get; set; }

    }
}