namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Replica Set Definition</summary>
    public partial class ReplicaSet :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal
    {

        /// <summary>Backing field for <see cref="DomainControllerIPAddress" /> property.</summary>
        private string[] _domainControllerIPAddress;

        /// <summary>List of Domain Controller IP Address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string[] DomainControllerIPAddress { get => this._domainControllerIPAddress; }

        /// <summary>Backing field for <see cref="ExternalAccessIPAddress" /> property.</summary>
        private string _externalAccessIPAddress;

        /// <summary>External access ip address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string ExternalAccessIPAddress { get => this._externalAccessIPAddress; }

        /// <summary>Backing field for <see cref="HealthAlert" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert[] _healthAlert;

        /// <summary>List of Domain Health Alerts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert[] HealthAlert { get => this._healthAlert; }

        /// <summary>Backing field for <see cref="HealthLastEvaluated" /> property.</summary>
        private global::System.DateTime? _healthLastEvaluated;

        /// <summary>Last domain evaluation run DateTime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public global::System.DateTime? HealthLastEvaluated { get => this._healthLastEvaluated; }

        /// <summary>Backing field for <see cref="HealthMonitor" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor[] _healthMonitor;

        /// <summary>List of Domain Health Monitors</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor[] HealthMonitor { get => this._healthMonitor; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>ReplicaSet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Virtual network location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for DomainControllerIPAddress</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal.DomainControllerIPAddress { get => this._domainControllerIPAddress; set { {_domainControllerIPAddress = value;} } }

        /// <summary>Internal Acessors for ExternalAccessIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal.ExternalAccessIPAddress { get => this._externalAccessIPAddress; set { {_externalAccessIPAddress = value;} } }

        /// <summary>Internal Acessors for HealthAlert</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert[] Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal.HealthAlert { get => this._healthAlert; set { {_healthAlert = value;} } }

        /// <summary>Internal Acessors for HealthLastEvaluated</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal.HealthLastEvaluated { get => this._healthLastEvaluated; set { {_healthLastEvaluated = value;} } }

        /// <summary>Internal Acessors for HealthMonitor</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor[] Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal.HealthMonitor { get => this._healthMonitor; set { {_healthMonitor = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for ServiceStatus</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal.ServiceStatus { get => this._serviceStatus; set { {_serviceStatus = value;} } }

        /// <summary>Internal Acessors for VnetSiteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSetInternal.VnetSiteId { get => this._vnetSiteId; set { {_vnetSiteId = value;} } }

        /// <summary>Backing field for <see cref="ServiceStatus" /> property.</summary>
        private string _serviceStatus;

        /// <summary>Status of Domain Service instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string ServiceStatus { get => this._serviceStatus; }

        /// <summary>Backing field for <see cref="SubnetId" /> property.</summary>
        private string _subnetId;

        /// <summary>
        /// The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will
        /// be deployed on. /virtualNetwork/vnetName/subnets/subnetName.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string SubnetId { get => this._subnetId; set => this._subnetId = value; }

        /// <summary>Backing field for <see cref="VnetSiteId" /> property.</summary>
        private string _vnetSiteId;

        /// <summary>Virtual network site id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string VnetSiteId { get => this._vnetSiteId; }

        /// <summary>Creates an new <see cref="ReplicaSet" /> instance.</summary>
        public ReplicaSet()
        {

        }
    }
    /// Replica Set Definition
    public partial interface IReplicaSet :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>List of Domain Controller IP Address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of Domain Controller IP Address",
        SerializedName = @"domainControllerIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string[] DomainControllerIPAddress { get;  }
        /// <summary>External access ip address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"External access ip address.",
        SerializedName = @"externalAccessIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string ExternalAccessIPAddress { get;  }
        /// <summary>List of Domain Health Alerts</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of Domain Health Alerts",
        SerializedName = @"healthAlerts",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert[] HealthAlert { get;  }
        /// <summary>Last domain evaluation run DateTime</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last domain evaluation run DateTime",
        SerializedName = @"healthLastEvaluated",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? HealthLastEvaluated { get;  }
        /// <summary>List of Domain Health Monitors</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of Domain Health Monitors",
        SerializedName = @"healthMonitors",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor[] HealthMonitor { get;  }
        /// <summary>ReplicaSet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ReplicaSet Id",
        SerializedName = @"replicaSetId",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Virtual network location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual network location",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Status of Domain Service instance</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of Domain Service instance",
        SerializedName = @"serviceStatus",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceStatus { get;  }
        /// <summary>
        /// The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will
        /// be deployed on. /virtualNetwork/vnetName/subnets/subnetName.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will be deployed on. /virtualNetwork/vnetName/subnets/subnetName.",
        SerializedName = @"subnetId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }
        /// <summary>Virtual network site id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Virtual network site id",
        SerializedName = @"vnetSiteId",
        PossibleTypes = new [] { typeof(string) })]
        string VnetSiteId { get;  }

    }
    /// Replica Set Definition
    internal partial interface IReplicaSetInternal

    {
        /// <summary>List of Domain Controller IP Address</summary>
        string[] DomainControllerIPAddress { get; set; }
        /// <summary>External access ip address.</summary>
        string ExternalAccessIPAddress { get; set; }
        /// <summary>List of Domain Health Alerts</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthAlert[] HealthAlert { get; set; }
        /// <summary>Last domain evaluation run DateTime</summary>
        global::System.DateTime? HealthLastEvaluated { get; set; }
        /// <summary>List of Domain Health Monitors</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IHealthMonitor[] HealthMonitor { get; set; }
        /// <summary>ReplicaSet Id</summary>
        string Id { get; set; }
        /// <summary>Virtual network location</summary>
        string Location { get; set; }
        /// <summary>Status of Domain Service instance</summary>
        string ServiceStatus { get; set; }
        /// <summary>
        /// The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will
        /// be deployed on. /virtualNetwork/vnetName/subnets/subnetName.
        /// </summary>
        string SubnetId { get; set; }
        /// <summary>Virtual network site id</summary>
        string VnetSiteId { get; set; }

    }
}