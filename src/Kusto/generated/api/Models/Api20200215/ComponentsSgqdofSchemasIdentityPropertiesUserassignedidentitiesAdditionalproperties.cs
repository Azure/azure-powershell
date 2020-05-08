namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    public partial class ComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalpropertiesInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>The client id of user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; }

        /// <summary>Internal Acessors for ClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalpropertiesInternal.ClientId { get => this._clientId; set { {_clientId = value;} } }

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalpropertiesInternal.PrincipalId { get => this._principalId; set { {_principalId = value;} } }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>The principal id of user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; }

        /// <summary>
        /// Creates an new <see cref="ComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties" /> instance.
        /// </summary>
        public ComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties()
        {

        }
    }
    public partial interface IComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalproperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The client id of user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The client id of user assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get;  }
        /// <summary>The principal id of user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal id of user assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }

    }
    internal partial interface IComponentsSgqdofSchemasIdentityPropertiesUserassignedidentitiesAdditionalpropertiesInternal

    {
        /// <summary>The client id of user assigned identity.</summary>
        string ClientId { get; set; }
        /// <summary>The principal id of user assigned identity.</summary>
        string PrincipalId { get; set; }

    }
}