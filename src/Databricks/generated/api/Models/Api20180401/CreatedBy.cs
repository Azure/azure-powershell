namespace Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Extensions;

    /// <summary>Provides details of the entity that created/updated the workspace.</summary>
    public partial class CreatedBy :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedBy,
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal
    {

        /// <summary>Backing field for <see cref="ApplicationId" /> property.</summary>
        private string _applicationId;

        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string ApplicationId { get => this._applicationId; }

        /// <summary>Internal Acessors for ApplicationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal.ApplicationId { get => this._applicationId; set { {_applicationId = value;} } }

        /// <summary>Internal Acessors for Oid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal.Oid { get => this._oid; set { {_oid = value;} } }

        /// <summary>Internal Acessors for Puid</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Databricks.Models.Api20180401.ICreatedByInternal.Puid { get => this._puid; set { {_puid = value;} } }

        /// <summary>Backing field for <see cref="Oid" /> property.</summary>
        private string _oid;

        /// <summary>The Object ID that created the workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Oid { get => this._oid; }

        /// <summary>Backing field for <see cref="Puid" /> property.</summary>
        private string _puid;

        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Databricks.PropertyOrigin.Owned)]
        public string Puid { get => this._puid; }

        /// <summary>Creates an new <see cref="CreatedBy" /> instance.</summary>
        public CreatedBy()
        {

        }
    }
    /// Provides details of the entity that created/updated the workspace.
    public partial interface ICreatedBy :
        Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.",
        SerializedName = @"applicationId",
        PossibleTypes = new [] { typeof(string) })]
        string ApplicationId { get;  }
        /// <summary>The Object ID that created the workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Object ID that created the workspace.",
        SerializedName = @"oid",
        PossibleTypes = new [] { typeof(string) })]
        string Oid { get;  }
        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Databricks.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Personal Object ID corresponding to the object ID above",
        SerializedName = @"puid",
        PossibleTypes = new [] { typeof(string) })]
        string Puid { get;  }

    }
    /// Provides details of the entity that created/updated the workspace.
    internal partial interface ICreatedByInternal

    {
        /// <summary>
        /// The application ID of the application that initiated the creation of the workspace. For example, Azure Portal.
        /// </summary>
        string ApplicationId { get; set; }
        /// <summary>The Object ID that created the workspace.</summary>
        string Oid { get; set; }
        /// <summary>The Personal Object ID corresponding to the object ID above</summary>
        string Puid { get; set; }

    }
}