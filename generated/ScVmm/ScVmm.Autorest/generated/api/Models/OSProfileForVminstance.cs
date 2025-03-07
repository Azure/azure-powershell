// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Extensions;

    /// <summary>Defines the resource properties.</summary>
    public partial class OSProfileForVminstance :
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IOSProfileForVminstance,
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IOSProfileForVminstanceInternal
    {

        /// <summary>Backing field for <see cref="AdminPassword" /> property.</summary>
        private System.Security.SecureString _adminPassword;

        /// <summary>Admin password of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public System.Security.SecureString AdminPassword { get => this._adminPassword; set => this._adminPassword = value; }

        /// <summary>Backing field for <see cref="ComputerName" /> property.</summary>
        private string _computerName;

        /// <summary>Gets or sets computer name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string ComputerName { get => this._computerName; set => this._computerName = value; }

        /// <summary>Backing field for <see cref="DomainName" /> property.</summary>
        private string _domainName;

        /// <summary>Gets or sets the domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string DomainName { get => this._domainName; set => this._domainName = value; }

        /// <summary>Backing field for <see cref="DomainPassword" /> property.</summary>
        private System.Security.SecureString _domainPassword;

        /// <summary>Password of the domain the VM has to join.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public System.Security.SecureString DomainPassword { get => this._domainPassword; set => this._domainPassword = value; }

        /// <summary>Backing field for <see cref="DomainUsername" /> property.</summary>
        private string _domainUsername;

        /// <summary>Gets or sets the domain username.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string DomainUsername { get => this._domainUsername; set => this._domainUsername = value; }

        /// <summary>Internal Acessors for OSSku</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IOSProfileForVminstanceInternal.OSSku { get => this._oSSku; set { {_oSSku = value;} } }

        /// <summary>Internal Acessors for OSType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IOSProfileForVminstanceInternal.OSType { get => this._oSType; set { {_oSType = value;} } }

        /// <summary>Internal Acessors for OSVersion</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IOSProfileForVminstanceInternal.OSVersion { get => this._oSVersion; set { {_oSVersion = value;} } }

        /// <summary>Backing field for <see cref="OSSku" /> property.</summary>
        private string _oSSku;

        /// <summary>Gets os sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string OSSku { get => this._oSSku; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private string _oSType;

        /// <summary>Gets the type of the os.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string OSType { get => this._oSType; }

        /// <summary>Backing field for <see cref="OSVersion" /> property.</summary>
        private string _oSVersion;

        /// <summary>Gets os version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string OSVersion { get => this._oSVersion; }

        /// <summary>Backing field for <see cref="ProductKey" /> property.</summary>
        private System.Security.SecureString _productKey;

        /// <summary>Gets or sets the product key.Input format xxxxx-xxxxx-xxxxx-xxxxx-xxxxx</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public System.Security.SecureString ProductKey { get => this._productKey; set => this._productKey = value; }

        /// <summary>Backing field for <see cref="RunOnceCommand" /> property.</summary>
        private string _runOnceCommand;

        /// <summary>
        /// Get or sets the commands to be run once at the time of creation separated by semicolons.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string RunOnceCommand { get => this._runOnceCommand; set => this._runOnceCommand = value; }

        /// <summary>Backing field for <see cref="Timezone" /> property.</summary>
        private int? _timezone;

        /// <summary>Gets or sets the index value of the timezone.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public int? Timezone { get => this._timezone; set => this._timezone = value; }

        /// <summary>Backing field for <see cref="Workgroup" /> property.</summary>
        private string _workgroup;

        /// <summary>Gets or sets the workgroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Origin(Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PropertyOrigin.Owned)]
        public string Workgroup { get => this._workgroup; set => this._workgroup = value; }

        /// <summary>Creates an new <see cref="OSProfileForVminstance" /> instance.</summary>
        public OSProfileForVminstance()
        {

        }
    }
    /// Defines the resource properties.
    public partial interface IOSProfileForVminstance :
        Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.IJsonSerializable
    {
        /// <summary>Admin password of the virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Admin password of the virtual machine.",
        SerializedName = @"adminPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString AdminPassword { get; set; }
        /// <summary>Gets or sets computer name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets computer name.",
        SerializedName = @"computerName",
        PossibleTypes = new [] { typeof(string) })]
        string ComputerName { get; set; }
        /// <summary>Gets or sets the domain name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets the domain name.",
        SerializedName = @"domainName",
        PossibleTypes = new [] { typeof(string) })]
        string DomainName { get; set; }
        /// <summary>Password of the domain the VM has to join.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Password of the domain the VM has to join.",
        SerializedName = @"domainPassword",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString DomainPassword { get; set; }
        /// <summary>Gets or sets the domain username.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets the domain username.",
        SerializedName = @"domainUsername",
        PossibleTypes = new [] { typeof(string) })]
        string DomainUsername { get; set; }
        /// <summary>Gets os sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets os sku.",
        SerializedName = @"osSku",
        PossibleTypes = new [] { typeof(string) })]
        string OSSku { get;  }
        /// <summary>Gets the type of the os.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets the type of the os.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PSArgumentCompleterAttribute("Windows", "Linux", "Other")]
        string OSType { get;  }
        /// <summary>Gets os version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Gets os version.",
        SerializedName = @"osVersion",
        PossibleTypes = new [] { typeof(string) })]
        string OSVersion { get;  }
        /// <summary>Gets or sets the product key.Input format xxxxx-xxxxx-xxxxx-xxxxx-xxxxx</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = false,
        Description = @"Gets or sets the product key.Input format xxxxx-xxxxx-xxxxx-xxxxx-xxxxx",
        SerializedName = @"productKey",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString ProductKey { get; set; }
        /// <summary>
        /// Get or sets the commands to be run once at the time of creation separated by semicolons.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Get or sets the commands to be run once at the time of creation separated by semicolons.",
        SerializedName = @"runOnceCommands",
        PossibleTypes = new [] { typeof(string) })]
        string RunOnceCommand { get; set; }
        /// <summary>Gets or sets the index value of the timezone.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets the index value of the timezone.",
        SerializedName = @"timezone",
        PossibleTypes = new [] { typeof(int) })]
        int? Timezone { get; set; }
        /// <summary>Gets or sets the workgroup.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Gets or sets the workgroup.",
        SerializedName = @"workgroup",
        PossibleTypes = new [] { typeof(string) })]
        string Workgroup { get; set; }

    }
    /// Defines the resource properties.
    internal partial interface IOSProfileForVminstanceInternal

    {
        /// <summary>Admin password of the virtual machine.</summary>
        System.Security.SecureString AdminPassword { get; set; }
        /// <summary>Gets or sets computer name.</summary>
        string ComputerName { get; set; }
        /// <summary>Gets or sets the domain name.</summary>
        string DomainName { get; set; }
        /// <summary>Password of the domain the VM has to join.</summary>
        System.Security.SecureString DomainPassword { get; set; }
        /// <summary>Gets or sets the domain username.</summary>
        string DomainUsername { get; set; }
        /// <summary>Gets os sku.</summary>
        string OSSku { get; set; }
        /// <summary>Gets the type of the os.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PSArgumentCompleterAttribute("Windows", "Linux", "Other")]
        string OSType { get; set; }
        /// <summary>Gets os version.</summary>
        string OSVersion { get; set; }
        /// <summary>Gets or sets the product key.Input format xxxxx-xxxxx-xxxxx-xxxxx-xxxxx</summary>
        System.Security.SecureString ProductKey { get; set; }
        /// <summary>
        /// Get or sets the commands to be run once at the time of creation separated by semicolons.
        /// </summary>
        string RunOnceCommand { get; set; }
        /// <summary>Gets or sets the index value of the timezone.</summary>
        int? Timezone { get; set; }
        /// <summary>Gets or sets the workgroup.</summary>
        string Workgroup { get; set; }

    }
}