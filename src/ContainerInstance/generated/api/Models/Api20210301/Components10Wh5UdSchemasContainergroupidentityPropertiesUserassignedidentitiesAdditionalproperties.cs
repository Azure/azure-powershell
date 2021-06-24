namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    public partial class Components10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalproperties :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IComponents10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalproperties,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IComponents10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalpropertiesInternal
    {

        /// <summary>Backing field for <see cref="ClientId" /> property.</summary>
        private string _clientId;

        /// <summary>The client id of user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string ClientId { get => this._clientId; }

        /// <summary>Internal Acessors for ClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IComponents10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalpropertiesInternal.ClientId { get => this._clientId; set { {_clientId = value;} } }

        /// <summary>Internal Acessors for PrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IComponents10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalpropertiesInternal.PrincipalId { get => this._principalId; set { {_principalId = value;} } }

        /// <summary>Backing field for <see cref="PrincipalId" /> property.</summary>
        private string _principalId;

        /// <summary>The principal id of user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string PrincipalId { get => this._principalId; }

        /// <summary>
        /// Creates an new <see cref="Components10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalproperties"
        /// /> instance.
        /// </summary>
        public Components10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalproperties()
        {

        }
    }
    public partial interface IComponents10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalproperties :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The client id of user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The client id of user assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClientId { get;  }
        /// <summary>The principal id of user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal id of user assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string PrincipalId { get;  }

    }
    internal partial interface IComponents10Wh5UdSchemasContainergroupidentityPropertiesUserassignedidentitiesAdditionalpropertiesInternal

    {
        /// <summary>The client id of user assigned identity.</summary>
        string ClientId { get; set; }
        /// <summary>The principal id of user assigned identity.</summary>
        string PrincipalId { get; set; }

    }
}