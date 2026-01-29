// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Extensions;

    /// <summary>The disconnected operation manifest</summary>
    public partial class DisconnectedOperationDeploymentManifest :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifest,
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal
    {

        /// <summary>Backing field for <see cref="BillingModel" /> property.</summary>
        private string _billingModel= @"Capacity";

        /// <summary>The billing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string BillingModel { get => this._billingModel; }

        /// <summary>Backing field for <see cref="Cloud" /> property.</summary>
        private string _cloud;

        /// <summary>The cloud in which the resource is registered</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string Cloud { get => this._cloud; }

        /// <summary>Backing field for <see cref="ConnectionIntent" /> property.</summary>
        private string _connectionIntent;

        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ConnectionIntent { get => this._connectionIntent; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string Location { get => this._location; }

        /// <summary>Internal Acessors for BillingModel</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.BillingModel { get => this._billingModel; set { {_billingModel = value;} } }

        /// <summary>Internal Acessors for Cloud</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.Cloud { get => this._cloud; set { {_cloud = value;} } }

        /// <summary>Internal Acessors for ConnectionIntent</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.ConnectionIntent { get => this._connectionIntent; set { {_connectionIntent = value;} } }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for ResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.ResourceId { get => this._resourceId; set { {_resourceId = value;} } }

        /// <summary>Internal Acessors for ResourceName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.ResourceName { get => this._resourceName; set { {_resourceName = value;} } }

        /// <summary>Internal Acessors for StampId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Models.IDisconnectedOperationDeploymentManifestInternal.StampId { get => this._stampId; set { {_stampId = value;} } }

        /// <summary>Backing field for <see cref="ResourceId" /> property.</summary>
        private string _resourceId;

        /// <summary>The resource identifier of the disconnected operations resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ResourceId { get => this._resourceId; }

        /// <summary>Backing field for <see cref="ResourceName" /> property.</summary>
        private string _resourceName;

        /// <summary>The resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string ResourceName { get => this._resourceName; }

        /// <summary>Backing field for <see cref="StampId" /> property.</summary>
        private string _stampId;

        /// <summary>The unique GUID of the stamp</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Origin(Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PropertyOrigin.Owned)]
        public string StampId { get => this._stampId; }

        /// <summary>Creates an new <see cref="DisconnectedOperationDeploymentManifest" /> instance.</summary>
        public DisconnectedOperationDeploymentManifest()
        {

        }
    }
    /// The disconnected operation manifest
    public partial interface IDisconnectedOperationDeploymentManifest :
        Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.IJsonSerializable
    {
        /// <summary>The billing model</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The billing model",
        SerializedName = @"billingModel",
        PossibleTypes = new [] { typeof(string) })]
        string BillingModel { get;  }
        /// <summary>The cloud in which the resource is registered</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The cloud in which the resource is registered",
        SerializedName = @"cloud",
        PossibleTypes = new [] { typeof(string) })]
        string Cloud { get;  }
        /// <summary>The connection intent</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The connection intent",
        SerializedName = @"connectionIntent",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get;  }
        /// <summary>The resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource location",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
        /// <summary>The resource identifier of the disconnected operations resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource identifier of the disconnected operations resource",
        SerializedName = @"resourceId",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceId { get;  }
        /// <summary>The resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The resource name",
        SerializedName = @"resourceName",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceName { get;  }
        /// <summary>The unique GUID of the stamp</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The unique GUID of the stamp",
        SerializedName = @"stampId",
        PossibleTypes = new [] { typeof(string) })]
        string StampId { get;  }

    }
    /// The disconnected operation manifest
    internal partial interface IDisconnectedOperationDeploymentManifestInternal

    {
        /// <summary>The billing model</summary>
        string BillingModel { get; set; }
        /// <summary>The cloud in which the resource is registered</summary>
        string Cloud { get; set; }
        /// <summary>The connection intent</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DisconnectedOperations.PSArgumentCompleterAttribute("Connected", "Disconnected")]
        string ConnectionIntent { get; set; }
        /// <summary>The resource location</summary>
        string Location { get; set; }
        /// <summary>The resource identifier of the disconnected operations resource</summary>
        string ResourceId { get; set; }
        /// <summary>The resource name</summary>
        string ResourceName { get; set; }
        /// <summary>The unique GUID of the stamp</summary>
        string StampId { get; set; }

    }
}