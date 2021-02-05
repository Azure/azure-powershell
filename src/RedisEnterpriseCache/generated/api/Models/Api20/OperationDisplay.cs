namespace Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20
{
    using static Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Extensions;

    /// <summary>Localized display information for this particular operation.</summary>
    public partial class OperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>
        /// The short, localized friendly description of the operation; suitable for tool tips and detailed views.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for Operation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal.Operation { get => this._operation; set { {_operation = value;} } }

        /// <summary>Internal Acessors for Provider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal.Provider { get => this._provider; set { {_provider = value;} } }

        /// <summary>Internal Acessors for Resource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api20.IOperationDisplayInternal.Resource { get => this._resource; set { {_resource = value;} } }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>
        /// The concise, localized friendly name for the operation; suitable for dropdowns. E.g. "Create or Update Virtual Machine",
        /// "Restart Virtual Machine".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>
        /// The localized friendly form of the resource provider name, e.g. "Microsoft Monitoring Insights" or "Microsoft Compute".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>
        /// The localized friendly name of the resource type related to this operation. E.g. "Virtual Machines" or "Job Schedule Collections".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Origin(Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; }

        /// <summary>Creates an new <see cref="OperationDisplay" /> instance.</summary>
        public OperationDisplay()
        {

        }
    }
    /// Localized display information for this particular operation.
    public partial interface IOperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The short, localized friendly description of the operation; suitable for tool tips and detailed views.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The short, localized friendly description of the operation; suitable for tool tips and detailed views.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>
        /// The concise, localized friendly name for the operation; suitable for dropdowns. E.g. "Create or Update Virtual Machine",
        /// "Restart Virtual Machine".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The concise, localized friendly name for the operation; suitable for dropdowns. E.g. ""Create or Update Virtual Machine"", ""Restart Virtual Machine"".",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get;  }
        /// <summary>
        /// The localized friendly form of the resource provider name, e.g. "Microsoft Monitoring Insights" or "Microsoft Compute".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized friendly form of the resource provider name, e.g. ""Microsoft Monitoring Insights"" or ""Microsoft Compute"".",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get;  }
        /// <summary>
        /// The localized friendly name of the resource type related to this operation. E.g. "Virtual Machines" or "Job Schedule Collections".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The localized friendly name of the resource type related to this operation. E.g. ""Virtual Machines"" or ""Job Schedule Collections"".",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get;  }

    }
    /// Localized display information for this particular operation.
    internal partial interface IOperationDisplayInternal

    {
        /// <summary>
        /// The short, localized friendly description of the operation; suitable for tool tips and detailed views.
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// The concise, localized friendly name for the operation; suitable for dropdowns. E.g. "Create or Update Virtual Machine",
        /// "Restart Virtual Machine".
        /// </summary>
        string Operation { get; set; }
        /// <summary>
        /// The localized friendly form of the resource provider name, e.g. "Microsoft Monitoring Insights" or "Microsoft Compute".
        /// </summary>
        string Provider { get; set; }
        /// <summary>
        /// The localized friendly name of the resource type related to this operation. E.g. "Virtual Machines" or "Job Schedule Collections".
        /// </summary>
        string Resource { get; set; }

    }
}