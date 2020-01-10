namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>
    /// The serviceName of an AvailableDelegation indicates a possible delegation for a subnet.
    /// </summary>
    public partial class AvailableDelegation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegation,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAvailableDelegationInternal
    {

        /// <summary>Backing field for <see cref="Action" /> property.</summary>
        private string[] _action;

        /// <summary>Describes the actions permitted to the service upon delegation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] Action { get => this._action; set => this._action = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>A unique identifier of the AvailableDelegation resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the AvailableDelegation resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ServiceName" /> property.</summary>
        private string _serviceName;

        /// <summary>The name of the service and resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceName { get => this._serviceName; set => this._serviceName = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="AvailableDelegation" /> instance.</summary>
        public AvailableDelegation()
        {

        }
    }
    /// The serviceName of an AvailableDelegation indicates a possible delegation for a subnet.
    public partial interface IAvailableDelegation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Describes the actions permitted to the service upon delegation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes the actions permitted to the service upon delegation",
        SerializedName = @"actions",
        PossibleTypes = new [] { typeof(string) })]
        string[] Action { get; set; }
        /// <summary>A unique identifier of the AvailableDelegation resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique identifier of the AvailableDelegation resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The name of the AvailableDelegation resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the AvailableDelegation resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The name of the service and resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the service and resource ",
        SerializedName = @"serviceName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceName { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// The serviceName of an AvailableDelegation indicates a possible delegation for a subnet.
    internal partial interface IAvailableDelegationInternal

    {
        /// <summary>Describes the actions permitted to the service upon delegation</summary>
        string[] Action { get; set; }
        /// <summary>A unique identifier of the AvailableDelegation resource.</summary>
        string Id { get; set; }
        /// <summary>The name of the AvailableDelegation resource.</summary>
        string Name { get; set; }
        /// <summary>The name of the service and resource</summary>
        string ServiceName { get; set; }
        /// <summary>Resource type.</summary>
        string Type { get; set; }

    }
}