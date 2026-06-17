// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Server administrator associated to a Microsoft Entra principal.</summary>
    public partial class AdministratorMicrosoftEntraAdd :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraAdd,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraAddInternal
    {

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAdd Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraAddInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdministratorMicrosoftEntraPropertiesForAdd()); set { {_property = value;} } }

        /// <summary>Name of the Microsoft Entra principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string PrincipalName { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAddInternal)Property).PrincipalName; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAddInternal)Property).PrincipalName = value ?? null; }

        /// <summary>
        /// Type of Microsoft Entra principal to which the server administrator is associated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string PrincipalType { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAddInternal)Property).PrincipalType; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAddInternal)Property).PrincipalType = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAdd _property;

        /// <summary>
        /// Properties of the server administrator associated to a Microsoft Entra principal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAdd Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.AdministratorMicrosoftEntraPropertiesForAdd()); set => this._property = value; }

        /// <summary>Identifier of the tenant in which the Microsoft Entra principal exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAddInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAddInternal)Property).TenantId = value ?? null; }

        /// <summary>Creates an new <see cref="AdministratorMicrosoftEntraAdd" /> instance.</summary>
        public AdministratorMicrosoftEntraAdd()
        {

        }
    }
    /// Server administrator associated to a Microsoft Entra principal.
    public partial interface IAdministratorMicrosoftEntraAdd :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>Name of the Microsoft Entra principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Name of the Microsoft Entra principal.",
        SerializedName = @"principalName",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalName { get; set; }
        /// <summary>
        /// Type of Microsoft Entra principal to which the server administrator is associated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Type of Microsoft Entra principal to which the server administrator is associated.",
        SerializedName = @"principalType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Unknown", "User", "Group", "ServicePrincipal")]
        string PrincipalType { get; set; }
        /// <summary>Identifier of the tenant in which the Microsoft Entra principal exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = false,
        Create = true,
        Update = true,
        Description = @"Identifier of the tenant in which the Microsoft Entra principal exists.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    /// Server administrator associated to a Microsoft Entra principal.
    internal partial interface IAdministratorMicrosoftEntraAddInternal

    {
        /// <summary>Name of the Microsoft Entra principal.</summary>
        string PrincipalName { get; set; }
        /// <summary>
        /// Type of Microsoft Entra principal to which the server administrator is associated.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Unknown", "User", "Group", "ServicePrincipal")]
        string PrincipalType { get; set; }
        /// <summary>
        /// Properties of the server administrator associated to a Microsoft Entra principal.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAdd Property { get; set; }
        /// <summary>Identifier of the tenant in which the Microsoft Entra principal exists.</summary>
        string TenantId { get; set; }

    }
}