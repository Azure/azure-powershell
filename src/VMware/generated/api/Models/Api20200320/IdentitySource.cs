namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>vCenter Single Sign On Identity Source</summary>
    public partial class IdentitySource :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySource,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IIdentitySourceInternal
    {

        /// <summary>Backing field for <see cref="Alias" /> property.</summary>
        private string _alias;

        /// <summary>The domain's NetBIOS name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Alias { get => this._alias; set => this._alias = value; }

        /// <summary>Backing field for <see cref="BaseGroupDn" /> property.</summary>
        private string _baseGroupDn;

        /// <summary>The base distinguished name for groups</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string BaseGroupDn { get => this._baseGroupDn; set => this._baseGroupDn = value; }

        /// <summary>Backing field for <see cref="BaseUserDn" /> property.</summary>
        private string _baseUserDn;

        /// <summary>The base distinguished name for users</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string BaseUserDn { get => this._baseUserDn; set => this._baseUserDn = value; }

        /// <summary>Backing field for <see cref="Domain" /> property.</summary>
        private string _domain;

        /// <summary>The domain's dns name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Domain { get => this._domain; set => this._domain = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the identity source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>
        /// The password of the Active Directory user with a minimum of read-only access to Base DN for users and groups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="PrimaryServer" /> property.</summary>
        private string _primaryServer;

        /// <summary>Primary server URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string PrimaryServer { get => this._primaryServer; set => this._primaryServer = value; }

        /// <summary>Backing field for <see cref="SecondaryServer" /> property.</summary>
        private string _secondaryServer;

        /// <summary>Secondary server URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string SecondaryServer { get => this._secondaryServer; set => this._secondaryServer = value; }

        /// <summary>Backing field for <see cref="Ssl" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.SslEnum? _ssl;

        /// <summary>Protect LDAP communication using SSL certificate (LDAPS)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.SslEnum? Ssl { get => this._ssl; set => this._ssl = value; }

        /// <summary>Backing field for <see cref="Username" /> property.</summary>
        private string _username;

        /// <summary>
        /// The ID of an Active Directory user with a minimum of read-only access to Base DN for users and group
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string Username { get => this._username; set => this._username = value; }

        /// <summary>Creates an new <see cref="IdentitySource" /> instance.</summary>
        public IdentitySource()
        {

        }
    }
    /// vCenter Single Sign On Identity Source
    public partial interface IIdentitySource :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>The domain's NetBIOS name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The domain's NetBIOS name",
        SerializedName = @"alias",
        PossibleTypes = new [] { typeof(string) })]
        string Alias { get; set; }
        /// <summary>The base distinguished name for groups</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The base distinguished name for groups",
        SerializedName = @"baseGroupDN",
        PossibleTypes = new [] { typeof(string) })]
        string BaseGroupDn { get; set; }
        /// <summary>The base distinguished name for users</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The base distinguished name for users",
        SerializedName = @"baseUserDN",
        PossibleTypes = new [] { typeof(string) })]
        string BaseUserDn { get; set; }
        /// <summary>The domain's dns name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The domain's dns name",
        SerializedName = @"domain",
        PossibleTypes = new [] { typeof(string) })]
        string Domain { get; set; }
        /// <summary>The name of the identity source</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the identity source",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// The password of the Active Directory user with a minimum of read-only access to Base DN for users and groups.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password of the Active Directory user with a minimum of read-only access to Base DN for users and groups.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>Primary server URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Primary server URL",
        SerializedName = @"primaryServer",
        PossibleTypes = new [] { typeof(string) })]
        string PrimaryServer { get; set; }
        /// <summary>Secondary server URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Secondary server URL",
        SerializedName = @"secondaryServer",
        PossibleTypes = new [] { typeof(string) })]
        string SecondaryServer { get; set; }
        /// <summary>Protect LDAP communication using SSL certificate (LDAPS)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Protect LDAP communication using SSL certificate (LDAPS)",
        SerializedName = @"ssl",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.SslEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.SslEnum? Ssl { get; set; }
        /// <summary>
        /// The ID of an Active Directory user with a minimum of read-only access to Base DN for users and group
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of an Active Directory user with a minimum of read-only access to Base DN for users and group",
        SerializedName = @"username",
        PossibleTypes = new [] { typeof(string) })]
        string Username { get; set; }

    }
    /// vCenter Single Sign On Identity Source
    internal partial interface IIdentitySourceInternal

    {
        /// <summary>The domain's NetBIOS name</summary>
        string Alias { get; set; }
        /// <summary>The base distinguished name for groups</summary>
        string BaseGroupDn { get; set; }
        /// <summary>The base distinguished name for users</summary>
        string BaseUserDn { get; set; }
        /// <summary>The domain's dns name</summary>
        string Domain { get; set; }
        /// <summary>The name of the identity source</summary>
        string Name { get; set; }
        /// <summary>
        /// The password of the Active Directory user with a minimum of read-only access to Base DN for users and groups.
        /// </summary>
        string Password { get; set; }
        /// <summary>Primary server URL</summary>
        string PrimaryServer { get; set; }
        /// <summary>Secondary server URL</summary>
        string SecondaryServer { get; set; }
        /// <summary>Protect LDAP communication using SSL certificate (LDAPS)</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.SslEnum? Ssl { get; set; }
        /// <summary>
        /// The ID of an Active Directory user with a minimum of read-only access to Base DN for users and group
        /// </summary>
        string Username { get; set; }

    }
}