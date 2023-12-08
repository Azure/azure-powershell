namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    public partial class ResourceSku :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSku,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IResourceSkuInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="ResourceSku" /> instance.</summary>
        public ResourceSku()
        {

        }
    }
    public partial interface IResourceSku :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Name of the SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name of the SKU.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    internal partial interface IResourceSkuInternal

    {
        /// <summary>Name of the SKU.</summary>
        string Name { get; set; }

    }
}