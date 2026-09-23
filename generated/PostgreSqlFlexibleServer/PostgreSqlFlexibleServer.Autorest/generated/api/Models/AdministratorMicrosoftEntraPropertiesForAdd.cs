// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a server administrator associated to a Microsoft Entra principal.</summary>
    public partial class AdministratorMicrosoftEntraPropertiesForAdd :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAdd,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IAdministratorMicrosoftEntraPropertiesForAddInternal
    {

        /// <summary>Backing field for <see cref="PrincipalName" /> property.</summary>
        private string _principalName;

        /// <summary>Name of the Microsoft Entra principal.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PrincipalName { get => this._principalName; set => this._principalName = value; }

        /// <summary>Backing field for <see cref="PrincipalType" /> property.</summary>
        private string _principalType;

        /// <summary>
        /// Type of Microsoft Entra principal to which the server administrator is associated.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string PrincipalType { get => this._principalType; set => this._principalType = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>Identifier of the tenant in which the Microsoft Entra principal exists.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>
        /// Creates an new <see cref="AdministratorMicrosoftEntraPropertiesForAdd" /> instance.
        /// </summary>
        public AdministratorMicrosoftEntraPropertiesForAdd()
        {

        }
    }
    /// Properties of a server administrator associated to a Microsoft Entra principal.
    public partial interface IAdministratorMicrosoftEntraPropertiesForAdd :
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
    /// Properties of a server administrator associated to a Microsoft Entra principal.
    internal partial interface IAdministratorMicrosoftEntraPropertiesForAddInternal

    {
        /// <summary>Name of the Microsoft Entra principal.</summary>
        string PrincipalName { get; set; }
        /// <summary>
        /// Type of Microsoft Entra principal to which the server administrator is associated.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PSArgumentCompleterAttribute("Unknown", "User", "Group", "ServicePrincipal")]
        string PrincipalType { get; set; }
        /// <summary>Identifier of the tenant in which the Microsoft Entra principal exists.</summary>
        string TenantId { get; set; }

    }
}