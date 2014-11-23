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
using Microsoft.WindowsAzure;

// Copied from ComputeManagementClient.cs
namespace Microsoft.Azure.Commands.Compute.Models
{
    /// <summary>
    /// The API entity reference.
    /// </summary>
    public partial class ApiEntityReference
    {
        private string _referenceUri;

        /// <summary>
        /// Optional. The relative URL in the previous Service Management API's
        /// namespace of the source image.
        /// </summary>
        public string ReferenceUri
        {
            get { return this._referenceUri; }
            set { this._referenceUri = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ApiEntityReference class.
        /// </summary>
        public ApiEntityReference()
        {
        }
    }

    /// <summary>
    /// Api error.
    /// </summary>
    public partial class ApiError : ApiErrorBase
    {
        private IList<ApiErrorBase> _details;

        /// <summary>
        /// Optional. Api error details
        /// </summary>
        public IList<ApiErrorBase> Details
        {
            get
            {
                if (this._details == null)
                {
                    this._details = new List<ApiErrorBase>();
                }
                return this._details;
            }
            set { this._details = value; }
        }

        /// <summary>
        /// Optional. Api error details
        /// </summary>
        public IList<ApiErrorBase> DetailsValue
        {
            get { return this._details; }
            set { this._details = value; }
        }

        private InnerError _innerError;

        /// <summary>
        /// Optional. Api inner error
        /// </summary>
        public InnerError InnerError
        {
            get { return this._innerError; }
            set { this._innerError = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ApiError class.
        /// </summary>
        public ApiError()
        {
        }
    }

    /// <summary>
    /// Api error base.
    /// </summary>
    public partial class ApiErrorBase
    {
        private string _code;

        /// <summary>
        /// Optional. Error code.
        /// </summary>
        public string Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        private string _message;

        /// <summary>
        /// Optional. Error message.
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        private string _target;

        /// <summary>
        /// Optional. The target of the particular error.
        /// </summary>
        public string Target
        {
            get { return this._target; }
            set { this._target = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ApiErrorBase class.
        /// </summary>
        public ApiErrorBase()
        {
        }
    }

    /// <summary>
    /// The caching type of OS or data disk.
    /// </summary>
    public static partial class CachingType
    {
        /// <summary>
        /// No Caching, which is default for data disks.
        /// </summary>
        public const string None = "None";

        /// <summary>
        /// Read Only Caching.
        /// </summary>
        public const string ReadOnly = "ReadOnly";

        /// <summary>
        /// ReadWrite Caching, which is default for OS disks.
        /// </summary>
        public const string ReadWrite = "ReadWrite";
    }

    /// <summary>
    /// The operation status.
    /// </summary>
    public enum ComputeOperationStatus
    {
        /// <summary>
        /// Operation in progress.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// Operation Failed.
        /// </summary>
        Failed = 2,

        /// <summary>
        /// Operation Succeeded.
        /// </summary>
        Succeeded = 3,

        /// <summary>
        /// Operation Preempted.
        /// </summary>
        Preempted = 4,
    }

    /// <summary>
    /// Describes a data disk.
    /// </summary>
    public partial class DataDisk : Disk
    {
        private int? _diskSizeGB;

        /// <summary>
        /// Optional. The disk size in GB for a blank data disk to be created.
        /// </summary>
        public int? DiskSizeGB
        {
            get { return this._diskSizeGB; }
            set { this._diskSizeGB = value; }
        }

        private int _lun;

        /// <summary>
        /// Optional. The logical unit number.
        /// </summary>
        public int Lun
        {
            get { return this._lun; }
            set { this._lun = value; }
        }

        /// <summary>
        /// Initializes a new instance of the DataDisk class.
        /// </summary>
        public DataDisk()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DataDisk class with required
        /// arguments.
        /// </summary>
        public DataDisk(string name, Uri vhdUri)
            : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (vhdUri == null)
            {
                throw new ArgumentNullException("vhdUri");
            }
            this.Name = name;
            this.VhdUri = vhdUri;
        }
    }

    /// <summary>
    /// Describes a disk.
    /// </summary>
    public partial class Disk
    {
        private string _caching;

        /// <summary>
        /// Optional. The caching type.
        /// </summary>
        public string Caching
        {
            get { return this._caching; }
            set { this._caching = value; }
        }

        private string _name;

        /// <summary>
        /// Required. The disk name.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private Uri _vhdUri;

        /// <summary>
        /// Required. The VHD URI.
        /// </summary>
        public Uri VhdUri
        {
            get { return this._vhdUri; }
            set { this._vhdUri = value; }
        }

        /// <summary>
        /// Initializes a new instance of the Disk class.
        /// </summary>
        public Disk()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Disk class with required
        /// arguments.
        /// </summary>
        public Disk(string name, Uri vhdUri)
            : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (vhdUri == null)
            {
                throw new ArgumentNullException("vhdUri");
            }
            this.Name = name;
            this.VhdUri = vhdUri;
        }
    }

    /// <summary>
    /// The instance view of the disk.
    /// </summary>
    public partial class DiskInstanceView : ResourceInstanceView
    {
        private string _name;

        /// <summary>
        /// Optional. The disk name.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// Initializes a new instance of the DiskInstanceView class.
        /// </summary>
        public DiskInstanceView()
        {
        }
    }

    /// <summary>
    /// Describes a hardware profile.
    /// </summary>
    public partial class HardwareProfile
    {
        private string _virtualMachineSize;

        /// <summary>
        /// Optional. The virtual machine size.
        /// </summary>
        public string VirtualMachineSize
        {
            get { return this._virtualMachineSize; }
            set { this._virtualMachineSize = value; }
        }

        /// <summary>
        /// Initializes a new instance of the HardwareProfile class.
        /// </summary>
        public HardwareProfile()
        {
        }
    }

    /// <summary>
    /// Inner error details.
    /// </summary>
    public partial class InnerError
    {
        private string _errorDetail;

        /// <summary>
        /// Optional. Internal error message or exception dump.
        /// </summary>
        public string ErrorDetail
        {
            get { return this._errorDetail; }
            set { this._errorDetail = value; }
        }

        private string _exceptionType;

        /// <summary>
        /// Optional. Exception type.
        /// </summary>
        public string ExceptionType
        {
            get { return this._exceptionType; }
            set { this._exceptionType = value; }
        }

        /// <summary>
        /// Initializes a new instance of the InnerError class.
        /// </summary>
        public InnerError()
        {
        }
    }

    /// <summary>
    /// Instance view status.
    /// </summary>
    public partial class InstanceViewStatus
    {
        private string _code;

        /// <summary>
        /// Optional. Status Code.
        /// </summary>
        public string Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        private string _displayStatus;

        /// <summary>
        /// Optional. Short localizable label for the status.
        /// </summary>
        public string DisplayStatus
        {
            get { return this._displayStatus; }
            set { this._displayStatus = value; }
        }

        private string _level;

        /// <summary>
        /// Optional. Level Code.
        /// </summary>
        public string Level
        {
            get { return this._level; }
            set { this._level = value; }
        }

        private string _message;

        /// <summary>
        /// Optional. Optional detailed Message, including for alerts and error
        /// messages.
        /// </summary>
        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        private System.DateTimeOffset? _time;

        /// <summary>
        /// Optional. Time of the status.
        /// </summary>
        public System.DateTimeOffset? Time
        {
            get { return this._time; }
            set { this._time = value; }
        }

        /// <summary>
        /// Initializes a new instance of the InstanceViewStatus class.
        /// </summary>
        public InstanceViewStatus()
        {
        }
    }

    /// <summary>
    /// The IP configuration.
    /// </summary>
    public partial class IPConfiguration
    {
        private string _name;

        /// <summary>
        /// Optional. The name of IP configuration.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private PublicIPAddress _publicIPAddress;

        /// <summary>
        /// Optional. The public IP address.
        /// </summary>
        public PublicIPAddress PublicIPAddress
        {
            get { return this._publicIPAddress; }
            set { this._publicIPAddress = value; }
        }

        /// <summary>
        /// Initializes a new instance of the IPConfiguration class.
        /// </summary>
        public IPConfiguration()
        {
        }
    }

    /// <summary>
    /// A standard service response for long running operations.
    /// </summary>
    public partial class LongRunningOperationResponse : OperationResponse
    {
        private System.DateTimeOffset? _endTime;

        /// <summary>
        /// Optional. Operation end time
        /// </summary>
        public System.DateTimeOffset? EndTime
        {
            get { return this._endTime; }
            set { this._endTime = value; }
        }

        private ApiError _error;

        /// <summary>
        /// Optional. Operation error if any occurred
        /// </summary>
        public ApiError Error
        {
            get { return this._error; }
            set { this._error = value; }
        }

        private string _id;

        /// <summary>
        /// Optional. Operation identifier.
        /// </summary>
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        private DateTimeOffset _startTime;

        /// <summary>
        /// Optional. Operation start time
        /// </summary>
        public DateTimeOffset StartTime
        {
            get { return this._startTime; }
            set { this._startTime = value; }
        }

        private ComputeOperationStatus _status;

        /// <summary>
        /// Optional. Operation status.
        /// </summary>
        public ComputeOperationStatus Status
        {
            get { return this._status; }
            set { this._status = value; }
        }

        /// <summary>
        /// Initializes a new instance of the LongRunningOperationResponse
        /// class.
        /// </summary>
        public LongRunningOperationResponse()
        {
        }
    }

    /// <summary>
    /// Describes a network interface.
    /// </summary>
    public partial class NetworkInterface
    {
        private string _name;

        /// <summary>
        /// Optional. The network interface name.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private NetworkInterfaceProperties _properties;

        /// <summary>
        /// Optional. The network interface properties.
        /// </summary>
        public NetworkInterfaceProperties Properties
        {
            get { return this._properties; }
            set { this._properties = value; }
        }

        /// <summary>
        /// Initializes a new instance of the NetworkInterface class.
        /// </summary>
        public NetworkInterface()
        {
        }
    }

    /// <summary>
    /// Describes the network interface properties.
    /// </summary>
    public partial class NetworkInterfaceProperties
    {
        private IList<IPConfiguration> _iPConfigurations;

        /// <summary>
        /// Optional. The network interface configurations.
        /// </summary>
        public IList<IPConfiguration> IPConfigurations
        {
            get
            {
                if (this._iPConfigurations == null)
                {
                    this._iPConfigurations = new List<IPConfiguration>();
                }
                return this._iPConfigurations;
            }
            set { this._iPConfigurations = value; }
        }

        /// <summary>
        /// Initializes a new instance of the NetworkInterfaceProperties class.
        /// </summary>
        public NetworkInterfaceProperties()
        {
        }
    }

    /// <summary>
    /// Describes a network profile.
    /// </summary>
    public partial class NetworkProfile
    {
        private IList<NetworkInterface> _networkInterfaces;

        /// <summary>
        /// Optional. The network interfaces.
        /// </summary>
        public IList<NetworkInterface> NetworkInterfaces
        {
            get
            {
                if (this._networkInterfaces == null)
                {
                    this._networkInterfaces = new List<NetworkInterface>();
                }
                return this._networkInterfaces;
            }
            set { this._networkInterfaces = value; }
        }

        /// <summary>
        /// Initializes a new instance of the NetworkProfile class.
        /// </summary>
        public NetworkProfile()
        {
        }
    }

    /// <summary>
    /// Describes an OS disk.
    /// </summary>
    public partial class OSDisk : Disk
    {
        /// <summary>
        /// Initializes a new instance of the OSDisk class.
        /// </summary>
        public OSDisk()
        {
        }

        /// <summary>
        /// Initializes a new instance of the OSDisk class with required
        /// arguments.
        /// </summary>
        public OSDisk(string name, Uri vhdUri)
            : this()
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (vhdUri == null)
            {
                throw new ArgumentNullException("vhdUri");
            }
            this.Name = name;
            this.VhdUri = vhdUri;
        }
    }

    /// <summary>
    /// Describes an OS profile.
    /// </summary>
    public partial class OSProfile
    {
        private SecureString _adminPassword;

        /// <summary>
        /// Optional. The admin user password.
        /// </summary>
        public SecureString AdminPassword
        {
            get { return this._adminPassword; }
            set { this._adminPassword = value; }
        }

        private string _adminUsername;

        /// <summary>
        /// Optional. The admin user name.
        /// </summary>
        public string AdminUsername
        {
            get { return this._adminUsername; }
            set { this._adminUsername = value; }
        }

        private string _computerName;

        /// <summary>
        /// Optional. The computer name.
        /// </summary>
        public string ComputerName
        {
            get { return this._computerName; }
            set { this._computerName = value; }
        }

        /// <summary>
        /// Initializes a new instance of the OSProfile class.
        /// </summary>
        public OSProfile()
        {
        }
    }

    /// <summary>
    /// The provisioning state.
    /// </summary>
    public static partial class ProvisioningState
    {
        /// <summary>
        /// The creating state.
        /// </summary>
        public const string Creating = "Creating";

        /// <summary>
        /// The updating state.
        /// </summary>
        public const string Updating = "Updating";

        /// <summary>
        /// The failed state.
        /// </summary>
        public const string Failed = "Failed";

        /// <summary>
        /// The succeeded state.
        /// </summary>
        public const string Succeeded = "Succeeded";

        /// <summary>
        /// The deleting state.
        /// </summary>
        public const string Deleting = "Deleting";
    }

    /// <summary>
    /// The public IP address. The reference Uri should be a relative Url in
    /// Network resource provider's namespace, e.g.
    /// '/subscriptions/.../resourceGroups/{rgName}/providers/Microsoft.Network/publicIPAddresses/{ipName}'
    /// </summary>
    public partial class PublicIPAddress : ApiEntityReference
    {
        /// <summary>
        /// Initializes a new instance of the PublicIPAddress class.
        /// </summary>
        public PublicIPAddress()
        {
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
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Dictionary<string, string>();
                }
                return this._tags;
            }
            set { this._tags = value; }
        }

        /// <summary>
        /// Optional. Gets or sets the tags attached to the resource.
        /// </summary>
        public IDictionary<string, string> TagsValue
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
        }
    }

    /// <summary>
    /// The instance view of a resource.
    /// </summary>
    public abstract partial class ResourceInstanceView
    {
        private IList<InstanceViewStatus> _statuses;

        /// <summary>
        /// Optional. The disks information.
        /// </summary>
        public IList<InstanceViewStatus> Statuses
        {
            get
            {
                if (this._statuses == null)
                {
                    this._statuses = new List<InstanceViewStatus>();
                }
                return this._statuses;
            }
            set { this._statuses = value; }
        }

        /// <summary>
        /// Optional. The disks information.
        /// </summary>
        public IList<InstanceViewStatus> StatusesValue
        {
            get { return this._statuses; }
            set { this._statuses = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ResourceInstanceView class.
        /// </summary>
        public ResourceInstanceView()
        {
        }
    }

    /// <summary>
    /// The resource operation response.
    /// </summary>
    public partial class ResourceOperationResponse : OperationResponse
    {
        private string _location;

        /// <summary>
        /// Optional. The resource location.
        /// </summary>
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }

        private string _name;

        /// <summary>
        /// Optional. The resource name.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        private Dictionary<string, string> _tags;

        /// <summary>
        /// Optional. The resource tags.
        /// </summary>
        public Dictionary<string, string> Tags
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Dictionary<string, string>();
                }
                return this._tags;
            }
            set { this._tags = value; }
        }

        /// <summary>
        /// Optional. The resource tags.
        /// </summary>
        public Dictionary<string, string> TagsValue
        {
            get { return this._tags; }
            set { this._tags = value; }
        }

        private string _type;

        /// <summary>
        /// Optional. The resource type.
        /// </summary>
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ResourceOperationResponse class.
        /// </summary>
        public ResourceOperationResponse()
        {
        }
    }

    /// <summary>
    /// The source image reference.
    /// </summary>
    public partial class SourceImageReference : ApiEntityReference
    {
        /// <summary>
        /// Initializes a new instance of the SourceImageReference class.
        /// </summary>
        public SourceImageReference()
        {
        }
    }

    /// <summary>
    /// The Level of the status.
    /// </summary>
    public static partial class StatusLevel
    {
        /// <summary>
        /// Information.
        /// </summary>
        public const string Info = "Info";

        /// <summary>
        /// Warning.
        /// </summary>
        public const string Warning = "Warning";

        /// <summary>
        /// Error.
        /// </summary>
        public const string Error = "Error";
    }

    /// <summary>
    /// Describes a storage profile.
    /// </summary>
    public partial class StorageProfile
    {
        private IList<DataDisk> _dataDisks;

        /// <summary>
        /// Optional. The data disks.
        /// </summary>
        public IList<DataDisk> DataDisks
        {
            get
            {
                if (this._dataDisks == null)
                {
                    this._dataDisks = new List<DataDisk>();
                }
                return this._dataDisks;
            }
            set { this._dataDisks = value; }
        }

        private Uri _destinationVhdsContainer;

        /// <summary>
        /// Optional. The destination container for VHDs.
        /// </summary>
        public Uri DestinationVhdsContainer
        {
            get { return this._destinationVhdsContainer; }
            set { this._destinationVhdsContainer = value; }
        }

        private OSDisk _oSDisk;

        /// <summary>
        /// Optional. The OS disk.
        /// </summary>
        public OSDisk OSDisk
        {
            get { return this._oSDisk; }
            set { this._oSDisk = value; }
        }

        private SourceImageReference _sourceImage;

        /// <summary>
        /// Optional. The source image reference.
        /// </summary>
        public SourceImageReference SourceImage
        {
            get { return this._sourceImage; }
            set { this._sourceImage = value; }
        }

        /// <summary>
        /// Initializes a new instance of the StorageProfile class.
        /// </summary>
        public StorageProfile()
        {
        }
    }

    /// <summary>
    /// Describes a Virtual Machine.
    /// </summary>
    public partial class VirtualMachine : ResourceBase
    {
        private PSVirtualMachineProfile _psVirtualMachineProfile;

        /// <summary>
        /// Optional. Virtual machine properties.
        /// </summary>
        public PSVirtualMachineProfile VMProfile
        {
            get { return this._psVirtualMachineProfile; }
            set { this._psVirtualMachineProfile = value; }
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachine class.
        /// </summary>
        public VirtualMachine()
        {
        }
    }

    /// <summary>
    /// Create or update Virtual Machine parameters.
    /// </summary>
    public partial class VirtualMachineCreateOrUpdateParameters
    {
        private VirtualMachine _virtualMachine;

        /// <summary>
        /// Required. Gets or sets information about a virtual machine being
        /// created of updated.
        /// </summary>
        public VirtualMachine VirtualMachine
        {
            get { return this._virtualMachine; }
            set { this._virtualMachine = value; }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineCreateOrUpdateParameters class.
        /// </summary>
        public VirtualMachineCreateOrUpdateParameters()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineCreateOrUpdateParameters class with required
        /// arguments.
        /// </summary>
        public VirtualMachineCreateOrUpdateParameters(VirtualMachine virtualMachine)
            : this()
        {
            if (virtualMachine == null)
            {
                throw new ArgumentNullException("virtualMachine");
            }
            this.VirtualMachine = virtualMachine;
        }
    }

    /// <summary>
    /// The Create Virtual Machine operation response.
    /// </summary>
    public partial class VirtualMachineCreateOrUpdateResponse : ResourceOperationResponse
    {
        private Uri _azureAsyncOperation;

        /// <summary>
        /// Optional. The Azure Async Operation Uri.
        /// </summary>
        public Uri AzureAsyncOperation
        {
            get { return this._azureAsyncOperation; }
            set { this._azureAsyncOperation = value; }
        }

        private VirtualMachine _virtualMachine;

        /// <summary>
        /// Optional. Details of the Virtual Machine.
        /// </summary>
        public VirtualMachine VirtualMachine
        {
            get { return this._virtualMachine; }
            set { this._virtualMachine = value; }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineCreateOrUpdateResponse class.
        /// </summary>
        public VirtualMachineCreateOrUpdateResponse()
        {
        }
    }

    /// <summary>
    /// The GetVMInstanceView operation response.
    /// </summary>
    public partial class VirtualMachineGetInstanceViewResponse : OperationResponse
    {
        private VirtualMachineInstanceView _virtualMachineInstanceView;

        /// <summary>
        /// Optional. Details of the Virtual Machine Instance.
        /// </summary>
        public VirtualMachineInstanceView VirtualMachineInstanceView
        {
            get { return this._virtualMachineInstanceView; }
            set { this._virtualMachineInstanceView = value; }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// VirtualMachineGetInstanceViewResponse class.
        /// </summary>
        public VirtualMachineGetInstanceViewResponse()
        {
        }
    }

    /// <summary>
    /// The GetVM operation response.
    /// </summary>
    public partial class VirtualMachineGetResponse : OperationResponse
    {
        private VirtualMachine _virtualMachine;

        /// <summary>
        /// Optional. Details of the Virtual Machine.
        /// </summary>
        public VirtualMachine VirtualMachine
        {
            get { return this._virtualMachine; }
            set { this._virtualMachine = value; }
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineGetResponse class.
        /// </summary>
        public VirtualMachineGetResponse()
        {
        }
    }

    /// <summary>
    /// The instance view of a virtual machine.
    /// </summary>
    public partial class VirtualMachineInstanceView : ResourceInstanceView
    {
        private IList<DiskInstanceView> _disks;

        /// <summary>
        /// Optional. The disks information.
        /// </summary>
        public IList<DiskInstanceView> Disks
        {
            get
            {
                if (this._disks == null)
                {
                    this._disks = new List<DiskInstanceView>();
                }
                return this._disks;
            }
            set { this._disks = value; }
        }

        /// <summary>
        /// Optional. The disks information.
        /// </summary>
        public IList<DiskInstanceView> DisksValue
        {
            get { return this._disks; }
            set { this._disks = value; }
        }

        private string _remoteDesktopThumbprint;

        /// <summary>
        /// Optional. Remote desktop certificate thumbprint.
        /// </summary>
        public string RemoteDesktopThumbprint
        {
            get { return this._remoteDesktopThumbprint; }
            set { this._remoteDesktopThumbprint = value; }
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineInstanceView class.
        /// </summary>
        public VirtualMachineInstanceView()
        {
        }
    }

    /// <summary>
    /// The List Virtual Machine operation response.
    /// </summary>
    public partial class VirtualMachineListResponse : OperationResponse, IEnumerable<VirtualMachine>
    {
        private IList<VirtualMachine> _virtualMachines;

        /// <summary>
        /// Optional.
        /// </summary>
        public IList<VirtualMachine> VirtualMachines
        {
            get
            {
                if (this._virtualMachines == null)
                {
                    this._virtualMachines = new List<VirtualMachine>();
                }
                return this._virtualMachines;
            }
            set { this._virtualMachines = value; }
        }

        /// <summary>
        /// Optional.
        /// </summary>
        public IList<VirtualMachine> VirtualMachinesValue
        {
            get { return this._virtualMachines; }
            set { this._virtualMachines = value; }
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineListResponse class.
        /// </summary>
        public VirtualMachineListResponse()
        {
        }

        /// <summary>
        /// Gets the sequence of VirtualMachines.
        /// </summary>
        public IEnumerator<VirtualMachine> GetEnumerator()
        {
            return this.VirtualMachinesValue.GetEnumerator();
        }

        /// <summary>
        /// Gets the sequence of VirtualMachines.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    /// <summary>
    /// The virtual machine long running operation response.
    /// </summary>
    public partial class VirtualMachineOperationResponse : OperationResponse
    {
        private Uri _azureAsyncOperation;

        /// <summary>
        /// Optional. The Azure Async Operation Uri.
        /// </summary>
        public Uri AzureAsyncOperation
        {
            get { return this._azureAsyncOperation; }
            set { this._azureAsyncOperation = value; }
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineOperationResponse
        /// class.
        /// </summary>
        public VirtualMachineOperationResponse()
        {
        }
    }

    /// <summary>
    /// Describes the properties of a Virtual Machine.
    /// </summary>
    public partial class PSVirtualMachineProfile
    {
        private HardwareProfile _hardwareProfile;

        /// <summary>
        /// Optional. The hardware profile.
        /// </summary>
        public HardwareProfile HardwareProfile
        {
            get { return this._hardwareProfile; }
            set { this._hardwareProfile = value; }
        }

        private NetworkProfile _networkProfile;

        /// <summary>
        /// Optional. The network profile.
        /// </summary>
        public NetworkProfile NetworkProfile
        {
            get { return this._networkProfile; }
            set { this._networkProfile = value; }
        }

        private OSProfile _oSProfile;

        /// <summary>
        /// Optional. The OS profile.
        /// </summary>
        public OSProfile OSProfile
        {
            get { return this._oSProfile; }
            set { this._oSProfile = value; }
        }

        private string _provisioningState;

        /// <summary>
        /// Optional. The provisioning state, which only appears in the
        /// response.
        /// </summary>
        public string ProvisioningState
        {
            get { return this._provisioningState; }
            set { this._provisioningState = value; }
        }

        private StorageProfile _storageProfile;

        /// <summary>
        /// Optional. The storage profile.
        /// </summary>
        public StorageProfile StorageProfile
        {
            get { return this._storageProfile; }
            set { this._storageProfile = value; }
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineProperties class.
        /// </summary>
        public PSVirtualMachineProfile()
        {
        }
    }

    /// <summary>
    /// The virtual machine size.
    /// </summary>
    public static partial class VirtualMachineSize
    {
        /// <summary>
        /// The standard A0 size.
        /// </summary>
        public const string StandardA0 = "Standard_A0";

        /// <summary>
        /// The standard A1 size.
        /// </summary>
        public const string StandardA1 = "Standard_A1";

        /// <summary>
        /// The standard A2 size.
        /// </summary>
        public const string StandardA2 = "Standard_A2";

        /// <summary>
        /// The standard A3 size.
        /// </summary>
        public const string StandardA3 = "Standard_A3";

        /// <summary>
        /// The standard A4 size.
        /// </summary>
        public const string StandardA4 = "Standard_A4";
    }
}