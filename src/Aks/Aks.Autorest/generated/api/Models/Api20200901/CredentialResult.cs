namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>The credential result response.</summary>
    public partial class CredentialResult :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResult,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResultInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResultInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        byte[] Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.ICredentialResultInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the credential.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private byte[] _value;

        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        public byte[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="CredentialResult" /> instance.</summary>
        public CredentialResult()
        {

        }
    }
    /// The credential result response.
    public partial interface ICredentialResult :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable
    {
        /// <summary>The name of the credential.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the credential.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Base64-encoded Kubernetes configuration file.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] Value { get;  }

    }
    /// The credential result response.
    internal partial interface ICredentialResultInternal

    {
        /// <summary>The name of the credential.</summary>
        string Name { get; set; }
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        byte[] Value { get; set; }

    }
}