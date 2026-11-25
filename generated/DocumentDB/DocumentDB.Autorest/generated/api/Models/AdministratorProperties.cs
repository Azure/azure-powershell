// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The local administrator login properties.</summary>
    public partial class AdministratorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IAdministratorPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private System.Security.SecureString _password;

        /// <summary>The administrator password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public System.Security.SecureString Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="UserName" /> property.</summary>
        private string _userName;

        /// <summary>The administrator user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string UserName { get => this._userName; set => this._userName = value; }

        /// <summary>Creates an new <see cref="AdministratorProperties" /> instance.</summary>
        public AdministratorProperties()
        {

        }
    }
    /// The local administrator login properties.
    public partial interface IAdministratorProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The administrator password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"The administrator password.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(System.Security.SecureString) })]
        System.Security.SecureString Password { get; set; }
        /// <summary>The administrator user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The administrator user name.",
        SerializedName = @"userName",
        PossibleTypes = new [] { typeof(string) })]
        string UserName { get; set; }

    }
    /// The local administrator login properties.
    internal partial interface IAdministratorPropertiesInternal

    {
        /// <summary>The administrator password.</summary>
        System.Security.SecureString Password { get; set; }
        /// <summary>The administrator user name.</summary>
        string UserName { get; set; }

    }
}