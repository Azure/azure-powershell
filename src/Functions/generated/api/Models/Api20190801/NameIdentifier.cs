namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Identifies an object.</summary>
    public partial class NameIdentifier :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameIdentifier,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameIdentifierInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="NameIdentifier" /> instance.</summary>
        public NameIdentifier()
        {

        }
    }
    /// Identifies an object.
    public partial interface INameIdentifier :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Name of the object.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the object.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Identifies an object.
    internal partial interface INameIdentifierInternal

    {
        /// <summary>Name of the object.</summary>
        string Name { get; set; }

    }
}