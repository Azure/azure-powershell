// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Capabilities in terms of compute tier.</summary>
    public partial class ServerEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapability,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase __capabilityBase = new Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.CapabilityBase();

        /// <summary>Backing field for <see cref="DefaultSkuName" /> property.</summary>
        private string _defaultSkuName;

        /// <summary>Default compute name (SKU) for this computer tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string DefaultSkuName { get => this._defaultSkuName; }

        /// <summary>Internal Acessors for Reason</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal.Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason = value ?? null; }

        /// <summary>Internal Acessors for Status</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status = value ?? null; }

        /// <summary>Internal Acessors for DefaultSkuName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal.DefaultSkuName { get => this._defaultSkuName; set { {_defaultSkuName = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for SupportedServerSku</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal.SupportedServerSku { get => this._supportedServerSku; set { {_supportedServerSku = value;} } }

        /// <summary>Internal Acessors for SupportedStorageEdition</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability> Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerEditionCapabilityInternal.SupportedStorageEdition { get => this._supportedStorageEdition; set { {_supportedStorageEdition = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of compute tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Reason for the capability not being available.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Reason { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Reason; }

        /// <summary>Status of the capability.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Inherited)]
        public string Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal)__capabilityBase).Status; }

        /// <summary>Backing field for <see cref="SupportedServerSku" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability> _supportedServerSku;

        /// <summary>List of supported compute names (SKUs).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability> SupportedServerSku { get => this._supportedServerSku; }

        /// <summary>Backing field for <see cref="SupportedStorageEdition" /> property.</summary>
        private System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability> _supportedStorageEdition;

        /// <summary>List of storage editions supported by this compute tier and compute name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability> SupportedStorageEdition { get => this._supportedStorageEdition; }

        /// <summary>Creates an new <see cref="ServerEditionCapability" /> instance.</summary>
        public ServerEditionCapability()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__capabilityBase), __capabilityBase);
            await eventListener.AssertObjectIsValid(nameof(__capabilityBase), __capabilityBase);
        }
    }
    /// Capabilities in terms of compute tier.
    public partial interface IServerEditionCapability :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBase
    {
        /// <summary>Default compute name (SKU) for this computer tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Default compute name (SKU) for this computer tier.",
        SerializedName = @"defaultSkuName",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultSkuName { get;  }
        /// <summary>Name of compute tier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"Name of compute tier.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>List of supported compute names (SKUs).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of supported compute names (SKUs).",
        SerializedName = @"supportedServerSkus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability> SupportedServerSku { get;  }
        /// <summary>List of storage editions supported by this compute tier and compute name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"List of storage editions supported by this compute tier and compute name.",
        SerializedName = @"supportedStorageEditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability> SupportedStorageEdition { get;  }

    }
    /// Capabilities in terms of compute tier.
    internal partial interface IServerEditionCapabilityInternal :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapabilityBaseInternal
    {
        /// <summary>Default compute name (SKU) for this computer tier.</summary>
        string DefaultSkuName { get; set; }
        /// <summary>Name of compute tier.</summary>
        string Name { get; set; }
        /// <summary>List of supported compute names (SKUs).</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IServerSkuCapability> SupportedServerSku { get; set; }
        /// <summary>List of storage editions supported by this compute tier and compute name.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IStorageEditionCapability> SupportedStorageEdition { get; set; }

    }
}