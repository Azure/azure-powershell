// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Security;

// Copied from NetworkResourceProviderClient.cs
namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class DhcpOptions
    {
        private IList<string> _dnsServers;

        /// <summary>
        /// Optional.
        /// </summary>
        public IList<string> DnsServers
        {
            get { return this._dnsServers; }
            set { this._dnsServers = value; }
        }

        /// <summary>
        /// Initializes a new instance of the DhcpOptions class.
        /// </summary>
        public DhcpOptions()
        {
            this.DnsServers = new List<string>();
        }
    }

    /// <summary>
    /// Contains FQDN of the DNS record associated with the public IP address
    /// </summary>
    public partial class DnsRecord
    {
        private string _fqdn;

        /// <summary>
        /// Optional.
        /// </summary>
        public string Fqdn
        {
            get { return this._fqdn; }
            set { this._fqdn = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the DnsRecord class.
        /// </summary>
        public DnsRecord()
        {
        }
    }
    
    public partial class Error
    {
        private string _code;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Code
        {
            get { return this._code; }
            set { this._code = value; }
        }
        
        private IList<ErrorDetails> _details;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public IList<ErrorDetails> Details
        {
            get { return this._details; }
            set { this._details = value; }
        }
        
        private string _innerError;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string InnerError
        {
            get { return this._innerError; }
            set { this._innerError = value; }
        }
        
        private string _message;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }
        
        private string _target;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Target
        {
            get { return this._target; }
            set { this._target = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Error class.
        /// </summary>
        public Error()
        {
            this.Details = new List<ErrorDetails>();
        }
    }
    
    public partial class ErrorDetails
    {
        private string _code;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Code
        {
            get { return this._code; }
            set { this._code = value; }
        }
        
        private string _message;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }
        
        private string _target;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Target
        {
            get { return this._target; }
            set { this._target = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ErrorDetails class.
        /// </summary>
        public ErrorDetails()
        {
        }
    }
    
    
    /// <summary>
    /// IP address allocation method
    /// </summary>
    public static partial class IpAllocationMethod
    {
        public const string Static = "Static";
        
        public const string Dynamic = "Dynamic";
    }
    
    /// <summary>
    /// The status of the asynchronous request.
    /// </summary>
    public static partial class OperationStatusTypes
    {
        public const string InProgress = "InProgress";
        
        public const string Succeeded = "Succeeded";
        
        public const string Failed = "Failed";
    }
    
    /// <summary>
    /// Provisioning state of the resource
    /// </summary>
    public static partial class ProvisioningStateTypes
    {
        public const string Updating = "Updating";
        
        public const string Deleting = "Deleting";
        
        public const string Failed = "Failed";
    }
    
    /// <summary>
    /// A publicIPAddress that exists in a resource group
    /// </summary>
    public partial class PublicIpAddress : ResourceBase
    {
        private string _id;
        
        /// <summary>
        /// Optional. Id of the PublicIPAddress resource
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private PublicIpAddressProperties _properties;
        
        /// <summary>
        /// Optional. Properties of the PublicIpAddress resource
        /// </summary>
        public PublicIpAddressProperties Properties
        {
            get { return this._properties; }
            set { this._properties = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the PublicIpAddress class.
        /// </summary>
        public PublicIpAddress()
        {
        }        
    }
    
    
    /// <summary>
    /// PublicIpAddress properties required for theCreatePublicIpAddress
    /// operation
    /// </summary>
    public partial class PublicIpAddressProperties : CreatePublicIpAddressProperties
    {
        private string _etag;
        
        /// <summary>
        /// Optional. A unique read-only string that changes whenever the
        /// resource is updated
        /// </summary>
        public string Etag
        {
            get { return this._etag; }
            set { this._etag = value; }
        }
        
        private string _provisioningState;
        
        /// <summary>
        /// Optional. Provisioning state of the PublicIP resource
        /// Updating/Deleting/Failed
        /// </summary>
        public string ProvisioningState
        {
            get { return this._provisioningState; }
            set { this._provisioningState = value; }
        }

        /// <summary>
        /// Initializes a new instance of the PublicIpAddressProperties class.
        /// </summary>
        public PublicIpAddressProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PublicIpAddressProperties class
        /// with required arguments.
        /// </summary>
        public PublicIpAddressProperties(string publicIpAllocationMethod)
            : this()
        {
            if (publicIpAllocationMethod == null)
            {
                throw new ArgumentNullException("publicIpAllocationMethod");
            }
            this.PublicIpAllocationMethod = publicIpAllocationMethod;
        }

        public override string ToString()
        {
            return string.Format("\nEtag: {0}\nProvisioningState: {1}\nIpAddress: {2}\nPublicIpAllocationMethod: {3}",
                this.Etag, this.ProvisioningState, this.IpAddress, this.PublicIpAllocationMethod);
        }
    }
    
    
    /// <summary>
    /// Id of the resource
    /// </summary>
    public partial class ResourceId
    {
        private string _id;
        
        /// <summary>
        /// Required. Id of the resource
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ResourceId class.
        /// </summary>
        public ResourceId()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the ResourceId class with required
        /// arguments.
        /// </summary>
        public ResourceId(string id)
            : this()
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            this.Id = id;
        }
    }

    /// <summary>
    /// Describes a resource.
    /// </summary>
    public partial class ResourceBase
    {
        private string _location;

        /// <summary>
        /// Optional. Gets or sets the location of the resource.
        /// </summary>
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }

        private string _name;

        /// <summary>
        /// Optional. The name of the resource.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private IDictionary<string, string> _tags;

        /// <summary>
        /// Optional. Gets or sets the tags attached to the resource.
        /// </summary>
        public IDictionary<string, string> Tags
        {
            get { return this._tags; }
            set { this._tags = value; }
        }

        private string _type;

        /// <summary>
        /// Optional. Gets or sets the type of the resource, such as
        /// 'Microsoft.Compute/virtualMachines'.
        /// </summary>
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ResourceBase class.
        /// </summary>
        public ResourceBase()
        {
            this._tags = new Dictionary<string, string>();
        }
    }

    /// <summary>
    /// PublicIpAddress properties required for theCreatePublicIpAddress
    /// operation
    /// </summary>
    public partial class CreatePublicIpAddressProperties
    {
        private DnsRecord _dnsRecord;

        /// <summary>
        /// Optional. Contains FQDN of the DNS record associated with the
        /// public IP address
        /// </summary>
        public DnsRecord DnsRecord
        {
            get { return this._dnsRecord; }
            set { this._dnsRecord = value; }
        }

        private string _ipAddress;

        /// <summary>
        /// Optional. The assigned public IP address
        /// </summary>
        public string IpAddress
        {
            get { return this._ipAddress; }
            set { this._ipAddress = value; }
        }

        private ResourceId _ipConfiguration;

        /// <summary>
        /// Optional. a read-only reference to the network interface IP
        /// configurations using this public IP address
        /// </summary>
        public ResourceId IpConfiguration
        {
            get { return this._ipConfiguration; }
            set { this._ipConfiguration = value; }
        }

        private string _publicIpAllocationMethod;

        /// <summary>
        /// Required. PublicIP allocation method (Static/Dynamic)
        /// </summary>
        public string PublicIpAllocationMethod
        {
            get { return this._publicIpAllocationMethod; }
            set { this._publicIpAllocationMethod = value; }
        }

        /// <summary>
        /// Initializes a new instance of the CreatePublicIpAddressProperties
        /// class.
        /// </summary>
        public CreatePublicIpAddressProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CreatePublicIpAddressProperties
        /// class with required arguments.
        /// </summary>
        public CreatePublicIpAddressProperties(string publicIpAllocationMethod)
            : this()
        {
            if (publicIpAllocationMethod == null)
            {
                throw new ArgumentNullException("publicIpAllocationMethod");
            }
            this.PublicIpAllocationMethod = publicIpAllocationMethod;
        }
    }
}
