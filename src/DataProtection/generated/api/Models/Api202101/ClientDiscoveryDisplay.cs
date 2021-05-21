namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Localized display information of an operation.</summary>
    public partial class ClientDiscoveryDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IClientDiscoveryDisplayInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the operation having details of what operation is about.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>Operations Name itself.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; set => this._operation = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>Name of the provider for display purposes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>ResourceType for which this Operation can be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; set => this._resource = value; }

        /// <summary>Creates an new <see cref="ClientDiscoveryDisplay" /> instance.</summary>
        public ClientDiscoveryDisplay()
        {

        }
    }
    /// Localized display information of an operation.
    public partial interface IClientDiscoveryDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Description of the operation having details of what operation is about.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the operation having details of what operation is about.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Operations Name itself.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operations Name itself.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get; set; }
        /// <summary>Name of the provider for display purposes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the provider for display purposes",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }
        /// <summary>ResourceType for which this Operation can be performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ResourceType for which this Operation can be performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get; set; }

    }
    /// Localized display information of an operation.
    internal partial interface IClientDiscoveryDisplayInternal

    {
        /// <summary>Description of the operation having details of what operation is about.</summary>
        string Description { get; set; }
        /// <summary>Operations Name itself.</summary>
        string Operation { get; set; }
        /// <summary>Name of the provider for display purposes</summary>
        string Provider { get; set; }
        /// <summary>ResourceType for which this Operation can be performed.</summary>
        string Resource { get; set; }

    }
}