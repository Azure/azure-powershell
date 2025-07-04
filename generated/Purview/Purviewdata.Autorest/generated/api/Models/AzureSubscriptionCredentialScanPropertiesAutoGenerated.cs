// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.Extensions;

    public partial class AzureSubscriptionCredentialScanPropertiesAutoGenerated :
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IAzureSubscriptionCredentialScanPropertiesAutoGenerated,
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IAzureSubscriptionCredentialScanPropertiesAutoGeneratedInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IAzureSubscriptionCredentialScanProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IAzureSubscriptionCredentialScanProperties __azureSubscriptionCredentialScanProperties = new Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AzureSubscriptionCredentialScanProperties();

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesCollection Collection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Collection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Collection = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public global::System.DateTime? CollectionLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CollectionLastModifiedAt; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string CollectionReferenceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CollectionReferenceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CollectionReferenceName = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string CollectionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CollectionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CollectionType = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesConnectedVia ConnectedVia { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ConnectedVia; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ConnectedVia = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string ConnectedViaReferenceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ConnectedViaReferenceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ConnectedViaReferenceName = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public global::System.DateTime? CreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CreatedAt; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesCredential Credential { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Credential; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Credential = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string CredentialReferenceName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CredentialReferenceName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CredentialReferenceName = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string CredentialType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CredentialType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CredentialType = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public global::System.DateTime? LastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).LastModifiedAt; }

        /// <summary>Internal Acessors for Credential</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesCredential Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal.Credential { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Credential; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Credential = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Collection</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesCollection Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal.Collection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Collection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Collection = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CollectionLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal.CollectionLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CollectionLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CollectionLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for ConnectedVia</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesConnectedVia Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal.ConnectedVia { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ConnectedVia; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ConnectedVia = value ?? null /* model class */; }

        /// <summary>Internal Acessors for CreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal.CreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).CreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>Internal Acessors for LastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal.LastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).LastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).LastModifiedAt = value ?? default(global::System.DateTime); }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesResourceTypes ResourceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ResourceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IExpandingResourceScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ResourceType = value ?? null /* model class */; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string ScanRulesetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ScanRulesetName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ScanRulesetName = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public string ScanRulesetType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ScanRulesetType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).ScanRulesetType = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Origin(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.PropertyOrigin.Inherited)]
        public int? Worker { get => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Worker; set => ((Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IScanPropertiesInternal)__azureSubscriptionCredentialScanProperties).Worker = value ?? default(int); }

        /// <summary>
        /// Creates an new <see cref="AzureSubscriptionCredentialScanPropertiesAutoGenerated" /> instance.
        /// </summary>
        public AzureSubscriptionCredentialScanPropertiesAutoGenerated()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__azureSubscriptionCredentialScanProperties), __azureSubscriptionCredentialScanProperties);
            await eventListener.AssertObjectIsValid(nameof(__azureSubscriptionCredentialScanProperties), __azureSubscriptionCredentialScanProperties);
        }
    }
    public partial interface IAzureSubscriptionCredentialScanPropertiesAutoGenerated :
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IAzureSubscriptionCredentialScanProperties
    {

    }
    internal partial interface IAzureSubscriptionCredentialScanPropertiesAutoGeneratedInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IAzureSubscriptionCredentialScanPropertiesInternal
    {

    }
}