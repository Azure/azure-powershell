// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.Extensions;

    /// <summary>
    /// The access key directly from target resource properties, which target service is Azure Resource, such as Microsoft.Storage
    /// </summary>
    public partial class AccessKeyInfoBase :
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IAccessKeyInfoBase,
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IAccessKeyInfoBaseInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IAuthInfoBase" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IAuthInfoBase __authInfoBase = new Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.AuthInfoBase();

        /// <summary>The authentication type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Constant]
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.PropertyOrigin.Inherited)]
        public string AuthType { get => "accessKey"; set => ((Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IAuthInfoBaseInternal)__authInfoBase).AuthType = "accessKey"; }

        /// <summary>Backing field for <see cref="Permission" /> property.</summary>
        private System.Collections.Generic.List<string> _permission;

        /// <summary>
        /// Permissions of the accessKey. `Read` and `Write` are for Azure Cosmos DB and Azure App Configuration, `Listen`, `Send`
        /// and `Manage` are for Azure Event Hub and Azure Service Bus.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Origin(Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.PropertyOrigin.Owned)]
        public System.Collections.Generic.List<string> Permission { get => this._permission; set => this._permission = value; }

        /// <summary>Creates an new <see cref="AccessKeyInfoBase" /> instance.</summary>
        public AccessKeyInfoBase()
        {
            this.__authInfoBase.AuthType = "accessKey";
        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__authInfoBase), __authInfoBase);
            await eventListener.AssertObjectIsValid(nameof(__authInfoBase), __authInfoBase);
        }
    }
    /// The access key directly from target resource properties, which target service is Azure Resource, such as Microsoft.Storage
    public partial interface IAccessKeyInfoBase :
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IAuthInfoBase
    {
        /// <summary>
        /// Permissions of the accessKey. `Read` and `Write` are for Azure Cosmos DB and Azure App Configuration, `Listen`, `Send`
        /// and `Manage` are for Azure Event Hub and Azure Service Bus.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Permissions of the accessKey. `Read` and `Write` are for Azure Cosmos DB and Azure App Configuration, `Listen`, `Send` and `Manage` are for Azure Event Hub and Azure Service Bus.",
        SerializedName = @"permissions",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.PSArgumentCompleterAttribute("Read", "Write", "Listen", "Send", "Manage")]
        System.Collections.Generic.List<string> Permission { get; set; }

    }
    /// The access key directly from target resource properties, which target service is Azure Resource, such as Microsoft.Storage
    internal partial interface IAccessKeyInfoBaseInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IAuthInfoBaseInternal
    {
        /// <summary>
        /// Permissions of the accessKey. `Read` and `Write` are for Azure Cosmos DB and Azure App Configuration, `Listen`, `Send`
        /// and `Manage` are for Azure Event Hub and Azure Service Bus.
        /// </summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.PSArgumentCompleterAttribute("Read", "Write", "Listen", "Send", "Manage")]
        System.Collections.Generic.List<string> Permission { get; set; }

    }
}