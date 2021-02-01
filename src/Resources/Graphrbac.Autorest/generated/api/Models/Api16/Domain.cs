namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Extensions;

    /// <summary>Active Directory Domain information.</summary>
    public partial class Domain :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomain,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomainInternal
    {

        /// <summary>Backing field for <see cref="AuthenticationType" /> property.</summary>
        private string _authenticationType;

        /// <summary>the type of the authentication into the domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string AuthenticationType { get => this._authenticationType; }

        /// <summary>Backing field for <see cref="IsDefault" /> property.</summary>
        private bool? _isDefault;

        /// <summary>if this is the default domain in the tenant.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? IsDefault { get => this._isDefault; }

        /// <summary>Backing field for <see cref="IsVerified" /> property.</summary>
        private bool? _isVerified;

        /// <summary>if this domain's ownership is verified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public bool? IsVerified { get => this._isVerified; }

        /// <summary>Internal Acessors for AuthenticationType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomainInternal.AuthenticationType { get => this._authenticationType; set { {_authenticationType = value;} } }

        /// <summary>Internal Acessors for IsDefault</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomainInternal.IsDefault { get => this._isDefault; set { {_isDefault = value;} } }

        /// <summary>Internal Acessors for IsVerified</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDomainInternal.IsVerified { get => this._isVerified; set { {_isVerified = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>the domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Origin(Microsoft.Azure.PowerShell.Cmdlets.AD.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="Domain" /> instance.</summary>
        public Domain()
        {

        }
    }
    /// Active Directory Domain information.
    public partial interface IDomain :
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.IAssociativeArray<global::System.Object>
    {
        /// <summary>the type of the authentication into the domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"the type of the authentication into the domain.",
        SerializedName = @"authenticationType",
        PossibleTypes = new [] { typeof(string) })]
        string AuthenticationType { get;  }
        /// <summary>if this is the default domain in the tenant.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"if this is the default domain in the tenant.",
        SerializedName = @"isDefault",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDefault { get;  }
        /// <summary>if this domain's ownership is verified.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"if this domain's ownership is verified.",
        SerializedName = @"isVerified",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsVerified { get;  }
        /// <summary>the domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"the domain name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Active Directory Domain information.
    internal partial interface IDomainInternal

    {
        /// <summary>the type of the authentication into the domain.</summary>
        string AuthenticationType { get; set; }
        /// <summary>if this is the default domain in the tenant.</summary>
        bool? IsDefault { get; set; }
        /// <summary>if this domain's ownership is verified.</summary>
        bool? IsVerified { get; set; }
        /// <summary>the domain name.</summary>
        string Name { get; set; }

    }
}