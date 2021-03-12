namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines load balancer backend address pool properties.</summary>
    public partial class LbBackendAddressPoolResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbBackendAddressPoolResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ILbBackendAddressPoolResourceSettingsInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Gets or sets the backend address pool name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="LbBackendAddressPoolResourceSettings" /> instance.</summary>
        public LbBackendAddressPoolResourceSettings()
        {

        }
    }
    /// Defines load balancer backend address pool properties.
    public partial interface ILbBackendAddressPoolResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the backend address pool name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the backend address pool name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Defines load balancer backend address pool properties.
    internal partial interface ILbBackendAddressPoolResourceSettingsInternal

    {
        /// <summary>Gets or sets the backend address pool name.</summary>
        string Name { get; set; }

    }
}