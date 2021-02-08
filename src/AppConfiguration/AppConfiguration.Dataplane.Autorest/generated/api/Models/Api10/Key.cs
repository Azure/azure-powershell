namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    public partial class Key :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKey,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Creates an new <see cref="Key" /> instance.</summary>
        public Key()
        {

        }
    }
    public partial interface IKey :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

    }
    internal partial interface IKeyInternal

    {
        string Name { get; set; }

    }
}