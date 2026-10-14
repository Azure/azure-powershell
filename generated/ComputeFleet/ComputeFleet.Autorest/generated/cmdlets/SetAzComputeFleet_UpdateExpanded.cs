// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Cmdlets
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Extensions;
    using Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.PowerShell;
    using Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Cmdlets;
    using System;

    /// <summary>update a Fleet</summary>
    /// <remarks>
    /// [OpenAPI] CreateOrUpdate=>PUT:"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{fleetName}"
    /// [DETAILS]
    /// verb: Set
    /// subjectPrefix: Compute
    /// subject: Fleet
    /// variant: UpdateExpanded
    /// </remarks>
    [global::System.Management.Automation.Cmdlet(global::System.Management.Automation.VerbsCommon.Set, @"AzComputeFleet_UpdateExpanded", SupportsShouldProcess = true)]
    [global::System.Management.Automation.OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet))]
    [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Description(@"update a Fleet")]
    [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Generated]
    [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.HttpPath(Path = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureFleet/fleets/{fleetName}", ApiVersion = "2026-04-01-preview")]
    public partial class SetAzComputeFleet_UpdateExpanded : global::System.Management.Automation.PSCmdlet,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener,
        Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IContext
    {
        /// <summary>A unique id generatd for the this cmdlet when it is instantiated.</summary>
        private string __correlationId = System.Guid.NewGuid().ToString();

        /// <summary>A copy of the Invocation Info (necessary to allow asJob to clone this cmdlet)</summary>
        private global::System.Management.Automation.InvocationInfo __invocationInfo;

        /// <summary>A unique id generatd for the this cmdlet when ProcessRecord() is called.</summary>
        private string __processRecordId;

        /// <summary>
        /// The <see cref="global::System.Threading.CancellationTokenSource" /> for this operation.
        /// </summary>
        private global::System.Threading.CancellationTokenSource _cancellationTokenSource = new global::System.Threading.CancellationTokenSource();

        /// <summary>A dictionary to carry over additional data for pipeline.</summary>
        private global::System.Collections.Generic.Dictionary<global::System.String,global::System.Object> _extensibleParameters = new System.Collections.Generic.Dictionary<string, object>();

        /// <summary>An Compute Fleet resource</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet _resourceBody = new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.Fleet();

        /// <summary>The list of location profiles.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The list of location profiles.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of location profiles.",
        SerializedName = @"locationProfiles",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile) })]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile[] AdditionalLocationProfile { get => _resourceBody.AdditionalLocationProfile?.ToArray() ?? null /* fixedArrayOf */; set => _resourceBody.AdditionalLocationProfile = (value != null ? new System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ILocationProfile>(value) : null); }

        /// <summary>The flag that enables or disables hibernation capability on the VM.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The flag that enables or disables hibernation capability on the VM.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The flag that enables or disables hibernation capability on the VM.",
        SerializedName = @"hibernationEnabled",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter AdditionalVirtualMachineCapabilityHibernationEnabled { get => _resourceBody.AdditionalVirtualMachineCapabilityHibernationEnabled ?? default(global::System.Management.Automation.SwitchParameter); set => _resourceBody.AdditionalVirtualMachineCapabilityHibernationEnabled = value; }

        /// <summary>
        /// The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account
        /// type on the VM or VMSS.Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual
        /// machine scale set only if this property is enabled.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS.Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The flag that enables or disables a capability to have one or more managed data disks with UltraSSD_LRS storage account type on the VM or VMSS.Managed disks with storage account type UltraSSD_LRS can be added to a virtual machine or virtual machine scale set only if this property is enabled.",
        SerializedName = @"ultraSSDEnabled",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter AdditionalVirtualMachineCapabilityUltraSsdEnabled { get => _resourceBody.AdditionalVirtualMachineCapabilityUltraSsdEnabled ?? default(global::System.Management.Automation.SwitchParameter); set => _resourceBody.AdditionalVirtualMachineCapabilityUltraSsdEnabled = value; }

        /// <summary>when specified, runs this cmdlet as a PowerShell job</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command as a job")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter AsJob { get; set; }

        /// <summary>Wait for .NET debugger to attach</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Wait for .NET debugger to attach")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter Break { get; set; }

        /// <summary>Accessor for cancellationTokenSource.</summary>
        public global::System.Threading.CancellationTokenSource CancellationTokenSource { get => _cancellationTokenSource ; set { _cancellationTokenSource = value; } }

        /// <summary>
        /// Specifies capacity type for Fleet Regular and Spot priority profiles.capacityType is an immutable property. Once set during
        /// Fleet creation, it cannot be updated.Specifying different capacity type for Fleet Regular and Spot priority profiles is
        /// not allowed.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Specifies capacity type for Fleet Regular and Spot priority profiles.capacityType is an immutable property. Once set during Fleet creation, it cannot be updated.Specifying different capacity type for Fleet Regular and Spot priority profiles is not allowed.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies capacity type for Fleet Regular and Spot priority profiles.capacityType is an immutable property. Once set during Fleet creation, it cannot be updated.Specifying different capacity type for Fleet Regular and Spot priority profiles is not allowed.",
        SerializedName = @"capacityType",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("VM", "VCpu")]
        public string CapacityType { get => _resourceBody.CapacityType ?? null; set => _resourceBody.CapacityType = value; }

        /// <summary>The reference to the client API class.</summary>
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.MicrosoftAzureFleet Client => Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Module.Instance.ClientAPI;

        /// <summary>
        /// Base Virtual Machine Profile Properties to be specified according to "specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile"
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Base Virtual Machine Profile Properties to be specified according to \"specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile\"")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base Virtual Machine Profile Properties to be specified according to ""specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/{computeApiVersion}/virtualMachineScaleSet.json#/definitions/VirtualMachineScaleSetVMProfile""",
        SerializedName = @"baseVirtualMachineProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile) })]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IBaseVirtualMachineProfile ComputeProfileBaseVirtualMachineProfile { get => _resourceBody.ComputeProfileBaseVirtualMachineProfile ?? null /* object */; set => _resourceBody.ComputeProfileBaseVirtualMachineProfile = value; }

        /// <summary>
        /// Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.The
        /// default value will be the latest supported computeApiVersion by Compute Fleet.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.The default value will be the latest supported computeApiVersion by Compute Fleet.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the Microsoft.Compute API version to use when creating underlying Virtual Machine scale sets and Virtual Machines.The default value will be the latest supported computeApiVersion by Compute Fleet.",
        SerializedName = @"computeApiVersion",
        PossibleTypes = new [] { typeof(string) })]
        public string ComputeProfileComputeApiVersion { get => _resourceBody.ComputeProfileComputeApiVersion ?? null; set => _resourceBody.ComputeProfileComputeApiVersion = value; }

        /// <summary>
        /// Specifies the number of fault domains to use when creating the underlying VMSS.A fault domain is a logical group of hardware
        /// within an Azure datacenter.VMs in the same fault domain share a common power source and network switch.If not specified,
        /// defaults to 1, which represents "Max Spreading" (using as many fault domains as possible).This property cannot be updated.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Specifies the number of fault domains to use when creating the underlying VMSS.A fault domain is a logical group of hardware within an Azure datacenter.VMs in the same fault domain share a common power source and network switch.If not specified, defaults to 1, which represents \"Max Spreading\" (using as many fault domains as possible).This property cannot be updated.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the number of fault domains to use when creating the underlying VMSS.A fault domain is a logical group of hardware within an Azure datacenter.VMs in the same fault domain share a common power source and network switch.If not specified, defaults to 1, which represents ""Max Spreading"" (using as many fault domains as possible).This property cannot be updated.",
        SerializedName = @"platformFaultDomainCount",
        PossibleTypes = new [] { typeof(int) })]
        public int ComputeProfilePlatformFaultDomainCount { get => _resourceBody.ComputeProfilePlatformFaultDomainCount ?? default(int); set => _resourceBody.ComputeProfilePlatformFaultDomainCount = value; }

        /// <summary>
        /// The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet
        /// against a different subscription
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::System.Management.Automation.Alias("AzureRMContext", "AzureCredential")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Azure)]
        public global::System.Management.Automation.PSObject DefaultProfile { get; set; }

        /// <summary>Determines whether to enable a system-assigned identity for the resource.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Determines whether to enable a system-assigned identity for the resource.")]
        public System.Boolean? EnableSystemAssignedIdentity { get; set; }

        /// <summary>Accessor for extensibleParameters.</summary>
        public global::System.Collections.Generic.IDictionary<global::System.String,global::System.Object> ExtensibleParameters { get => _extensibleParameters ; }

        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.SendAsyncStep[] HttpPipelineAppend { get; set; }

        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Runtime)]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.SendAsyncStep[] HttpPipelinePrepend { get; set; }

        /// <summary>Accessor for our copy of the InvocationInfo.</summary>
        public global::System.Management.Automation.InvocationInfo InvocationInformation { get => __invocationInfo = __invocationInfo ?? this.MyInvocation ; set { __invocationInfo = value; } }

        /// <summary>The geo-location where the resource lives</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The geo-location where the resource lives")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The geo-location where the resource lives",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        public string Location { get => _resourceBody.Location ?? null; set => _resourceBody.Location = value; }

        /// <summary>
        /// <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        global::System.Action Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener.Cancel => _cancellationTokenSource.Cancel;

        /// <summary><see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener" /> cancellation token.</summary>
        global::System.Threading.CancellationToken Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener.Token => _cancellationTokenSource.Token;

        /// <summary>Mode of the Fleet.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Mode of the Fleet.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Mode of the Fleet.",
        SerializedName = @"mode",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Managed", "Launch")]
        public string Mode { get => _resourceBody.Mode ?? null; set => _resourceBody.Mode = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the Compute Fleet</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the Compute Fleet")]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the Compute Fleet",
        SerializedName = @"fleetName",
        PossibleTypes = new [] { typeof(string) })]
        [global::System.Management.Automation.Alias("FleetName")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Path)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>
        /// when specified, will make the remote call, and return an AsyncOperationResponse, letting the remote operation continue
        /// asynchronously.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Run the command asynchronously")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter NoWait { get; set; }

        /// <summary>
        /// The instance of the <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.HttpPipeline Pipeline { get; set; }

        /// <summary>A user defined name of the 3rd Party Artifact that is being procured.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A user defined name of the 3rd Party Artifact that is being procured.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A user defined name of the 3rd Party Artifact that is being procured.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        public string PlanName { get => _resourceBody.PlanName ?? null; set => _resourceBody.PlanName = value; }

        /// <summary>
        /// The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at
        /// the time of Data Market onboarding.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The 3rd Party artifact that is being procured. E.g. NewRelic. Product maps to the OfferID specified for the artifact at the time of Data Market onboarding.",
        SerializedName = @"product",
        PossibleTypes = new [] { typeof(string) })]
        public string PlanProduct { get => _resourceBody.PlanProduct ?? null; set => _resourceBody.PlanProduct = value; }

        /// <summary>
        /// A publisher provided promotion code as provisioned in Data Market for the said product/artifact.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "A publisher provided promotion code as provisioned in Data Market for the said product/artifact.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A publisher provided promotion code as provisioned in Data Market for the said product/artifact.",
        SerializedName = @"promotionCode",
        PossibleTypes = new [] { typeof(string) })]
        public string PlanPromotionCode { get => _resourceBody.PlanPromotionCode ?? null; set => _resourceBody.PlanPromotionCode = value; }

        /// <summary>The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The publisher of the 3rd Party Artifact that is being bought. E.g. NewRelic",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        public string PlanPublisher { get => _resourceBody.PlanPublisher ?? null; set => _resourceBody.PlanPublisher = value; }

        /// <summary>The version of the desired product/artifact.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The version of the desired product/artifact.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version of the desired product/artifact.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(string) })]
        public string PlanVersion { get => _resourceBody.PlanVersion ?? null; set => _resourceBody.PlanVersion = value; }

        /// <summary>The URI for the proxy server to use</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Runtime)]
        public global::System.Uri Proxy { get; set; }

        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [global::System.Management.Automation.ValidateNotNull]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Runtime)]
        public global::System.Management.Automation.PSCredential ProxyCredential { get; set; }

        /// <summary>Use the default credentials for the proxy</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Runtime)]
        public global::System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allocation strategy to follow when determining the VM sizes distribution for Regular VMs.",
        SerializedName = @"allocationStrategy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("LowestPrice", "Prioritized")]
        public string RegularPriorityProfileAllocationStrategy { get => _resourceBody.RegularPriorityProfileAllocationStrategy ?? null; set => _resourceBody.RegularPriorityProfileAllocationStrategy = value; }

        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Total capacity to achieve. It is currently in terms of number of VMs.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Total capacity to achieve. It is currently in terms of number of VMs.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        public int RegularPriorityProfileCapacity { get => _resourceBody.RegularPriorityProfileCapacity ?? default(int); set => _resourceBody.RegularPriorityProfileCapacity = value; }

        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Minimum capacity to achieve which cannot be updated. If we will not be able to \"guarantee\" minimum capacity, we will reject the request in the sync path itself.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum capacity to achieve which cannot be updated. If we will not be able to ""guarantee"" minimum capacity, we will reject the request in the sync path itself.",
        SerializedName = @"minCapacity",
        PossibleTypes = new [] { typeof(int) })]
        public int RegularPriorityProfileMinCapacity { get => _resourceBody.RegularPriorityProfileMinCapacity ?? default(int); set => _resourceBody.RegularPriorityProfileMinCapacity = value; }

        /// <summary>Backing field for <see cref="ResourceGroupName" /> property.</summary>
        private string _resourceGroupName;

        /// <summary>The name of the resource group. The name is case insensitive.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the resource group. The name is case insensitive.",
        SerializedName = @"resourceGroupName",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Path)]
        public string ResourceGroupName { get => this._resourceGroupName; set => this._resourceGroupName = value; }

        /// <summary>
        /// Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allocation strategy to follow when determining the VM sizes distribution for Spot VMs.",
        SerializedName = @"allocationStrategy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("PriceCapacityOptimized", "LowestPrice", "CapacityOptimized")]
        public string SpotPriorityProfileAllocationStrategy { get => _resourceBody.SpotPriorityProfileAllocationStrategy ?? null; set => _resourceBody.SpotPriorityProfileAllocationStrategy = value; }

        /// <summary>Total capacity to achieve. It is currently in terms of number of VMs.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Total capacity to achieve. It is currently in terms of number of VMs.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Total capacity to achieve. It is currently in terms of number of VMs.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(int) })]
        public int SpotPriorityProfileCapacity { get => _resourceBody.SpotPriorityProfileCapacity ?? default(int); set => _resourceBody.SpotPriorityProfileCapacity = value; }

        /// <summary>Eviction Policy to follow when evicting Spot VMs.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Eviction Policy to follow when evicting Spot VMs.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Eviction Policy to follow when evicting Spot VMs.",
        SerializedName = @"evictionPolicy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("Delete", "Deallocate")]
        public string SpotPriorityProfileEvictionPolicy { get => _resourceBody.SpotPriorityProfileEvictionPolicy ?? null; set => _resourceBody.SpotPriorityProfileEvictionPolicy = value; }

        /// <summary>
        /// Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.If maintain
        /// is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)or update
        /// existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint) in order
        /// to achieve the desired capacity.Maintain is enabled by default.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.If maintain is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)or update existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint) in order to achieve the desired capacity.Maintain is enabled by default.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag to enable/disable continuous goal seeking for the desired capacity and restoration of evicted Spot VMs.If maintain is enabled, AzureFleetRP will use all VM sizes in vmSizesProfile to create new VMs (if VMs are evicted deleted)or update existing VMs with new VM sizes (if VMs are evicted deallocated or failed to allocate due to capacity constraint) in order to achieve the desired capacity.Maintain is enabled by default.",
        SerializedName = @"maintain",
        PossibleTypes = new [] { typeof(global::System.Management.Automation.SwitchParameter) })]
        public global::System.Management.Automation.SwitchParameter SpotPriorityProfileMaintain { get => _resourceBody.SpotPriorityProfileMaintain ?? default(global::System.Management.Automation.SwitchParameter); set => _resourceBody.SpotPriorityProfileMaintain = value; }

        /// <summary>Price per hour of each Spot VM will never exceed this.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Price per hour of each Spot VM will never exceed this.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Price per hour of each Spot VM will never exceed this.",
        SerializedName = @"maxPricePerVM",
        PossibleTypes = new [] { typeof(float) })]
        public float SpotPriorityProfileMaxPricePerVM { get => _resourceBody.SpotPriorityProfileMaxPricePerVM ?? default(float); set => _resourceBody.SpotPriorityProfileMaxPricePerVM = value; }

        /// <summary>
        /// Minimum capacity to achieve which cannot be updated. If we will not be able to "guarantee" minimum capacity, we will reject
        /// the request in the sync path itself.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Minimum capacity to achieve which cannot be updated. If we will not be able to \"guarantee\" minimum capacity, we will reject the request in the sync path itself.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum capacity to achieve which cannot be updated. If we will not be able to ""guarantee"" minimum capacity, we will reject the request in the sync path itself.",
        SerializedName = @"minCapacity",
        PossibleTypes = new [] { typeof(int) })]
        public int SpotPriorityProfileMinCapacity { get => _resourceBody.SpotPriorityProfileMinCapacity ?? default(int); set => _resourceBody.SpotPriorityProfileMinCapacity = value; }

        /// <summary>Backing field for <see cref="SubscriptionId" /> property.</summary>
        private string _subscriptionId;

        /// <summary>The ID of the target subscription. The value must be an UUID.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The ID of the target subscription. The value must be an UUID.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the target subscription. The value must be an UUID.",
        SerializedName = @"subscriptionId",
        PossibleTypes = new [] { typeof(string) })]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.DefaultInfo(
        Name = @"",
        Description =@"",
        Script = @"(Get-AzContext).Subscription.Id",
        SetCondition = @"")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Path)]
        public string SubscriptionId { get => this._subscriptionId; set => this._subscriptionId = value; }

        /// <summary>Resource tags.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ExportAs(typeof(global::System.Collections.Hashtable))]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Resource tags.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResourceTags) })]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.ITrackedResourceTags Tag { get => _resourceBody.Tag ?? null /* object */; set => _resourceBody.Tag = value; }

        /// <summary>
        /// The array of user assigned identities associated with the resource. The elements in array will be ARM resource ids in
        /// the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "The array of user assigned identities associated with the resource. The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'")]
        [global::System.Management.Automation.AllowEmptyCollection]
        public string[] UserAssignedIdentity { get; set; }

        /// <summary>Attribute based Fleet.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Attribute based Fleet.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Attribute based Fleet.",
        SerializedName = @"vmAttributes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes) })]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMAttributes VMAttribute { get => _resourceBody.VMAttribute ?? null /* object */; set => _resourceBody.VMAttribute = value; }

        /// <summary>
        /// VirtualMachine prefix to be used for the virtual machines launched by Fleet. Can be used only with Launch mode.
        /// </summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "VirtualMachine prefix to be used for the virtual machines launched by Fleet. Can be used only with Launch mode.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"VirtualMachine prefix to be used for the virtual machines launched by Fleet. Can be used only with Launch mode.",
        SerializedName = @"vmNamePrefix",
        PossibleTypes = new [] { typeof(string) })]
        public string VMNamePrefix { get => _resourceBody.VMNamePrefix ?? null; set => _resourceBody.VMNamePrefix = value; }

        /// <summary>List of VM sizes supported for Compute Fleet</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "List of VM sizes supported for Compute Fleet")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of VM sizes supported for Compute Fleet",
        SerializedName = @"vmSizesProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile) })]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile[] VMSizesProfile { get => _resourceBody.VMSizesProfile?.ToArray() ?? null /* fixedArrayOf */; set => _resourceBody.VMSizesProfile = (value != null ? new System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IVMSizeProfile>(value) : null); }

        /// <summary>Zones in which the Compute Fleet is available</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Zones in which the Compute Fleet is available")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Zones in which the Compute Fleet is available",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        public string[] Zone { get => _resourceBody.Zone?.ToArray() ?? null /* fixedArrayOf */; set => _resourceBody.Zone = (value != null ? new System.Collections.Generic.List<string>(value) : null); }

        /// <summary>Distribution strategy used for zone allocation policy.</summary>
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Distribution strategy used for zone allocation policy.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Distribution strategy used for zone allocation policy.",
        SerializedName = @"distributionStrategy",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.PSArgumentCompleterAttribute("BestEffortSingleZone", "Prioritized")]
        public string ZoneAllocationPolicyDistributionStrategy { get => _resourceBody.ZoneAllocationPolicyDistributionStrategy ?? null; set => _resourceBody.ZoneAllocationPolicyDistributionStrategy = value; }

        /// <summary>Zone preferences, required when zone distribution strategy is Prioritized.</summary>
        [global::System.Management.Automation.AllowEmptyCollection]
        [global::System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Zone preferences, required when zone distribution strategy is Prioritized.")]
        [global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category(global::Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.ParameterCategory.Body)]
        [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Zone preferences, required when zone distribution strategy is Prioritized.",
        SerializedName = @"zonePreferences",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference) })]
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference[] ZoneAllocationPolicyZonePreference { get => _resourceBody.ZoneAllocationPolicyZonePreference?.ToArray() ?? null /* fixedArrayOf */; set => _resourceBody.ZoneAllocationPolicyZonePreference = (value != null ? new System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IZonePreference>(value) : null); }

        /// <summary>
        /// <c>overrideOnDefault</c> will be called before the regular onDefault has been processed, allowing customization of what
        /// happens on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onDefault method should be processed, or if the method should
        /// return immediately (set to true to skip further processing )</param>

        partial void overrideOnDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IErrorResponse> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// <c>overrideOnOk</c> will be called before the regular onOk has been processed, allowing customization of what happens
        /// on that response. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet">Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet</see>
        /// from the remote call</param>
        /// <param name="returnNow">/// Determines if the rest of the onOk method should be processed, or if the method should return
        /// immediately (set to true to skip further processing )</param>

        partial void overrideOnOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet> response, ref global::System.Threading.Tasks.Task<bool> returnNow);

        /// <summary>
        /// (overrides the default BeginProcessing method in global::System.Management.Automation.PSCmdlet)
        /// </summary>
        protected override void BeginProcessing()
        {
            var telemetryId = Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Module.Instance.GetTelemetryId.Invoke();
            if (telemetryId != "" && telemetryId != "internal")
            {
                __correlationId = telemetryId;
            }
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
            if (Break)
            {
                Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.AttachDebugger.Break();
            }
            ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletBeginProcessing).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
        }

        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>a duplicate instance of SetAzComputeFleet_UpdateExpanded</returns>
        public Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Cmdlets.SetAzComputeFleet_UpdateExpanded Clone()
        {
            var clone = new SetAzComputeFleet_UpdateExpanded();
            clone.__correlationId = this.__correlationId;
            clone.__processRecordId = this.__processRecordId;
            clone.DefaultProfile = this.DefaultProfile;
            clone.InvocationInformation = this.InvocationInformation;
            clone.Proxy = this.Proxy;
            clone.Pipeline = this.Pipeline;
            clone.AsJob = this.AsJob;
            clone.Break = this.Break;
            clone.ProxyCredential = this.ProxyCredential;
            clone.ProxyUseDefaultCredentials = this.ProxyUseDefaultCredentials;
            clone.HttpPipelinePrepend = this.HttpPipelinePrepend;
            clone.HttpPipelineAppend = this.HttpPipelineAppend;
            clone._resourceBody = this._resourceBody;
            clone.SubscriptionId = this.SubscriptionId;
            clone.ResourceGroupName = this.ResourceGroupName;
            clone.Name = this.Name;
            return clone;
        }

        /// <summary>Performs clean-up after the command execution</summary>
        protected override void EndProcessing()
        {
            var telemetryInfo = Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Module.Instance.GetTelemetryInfo?.Invoke(__correlationId);
            if (telemetryInfo != null)
            {
                telemetryInfo.TryGetValue("ShowSecretsWarning", out var showSecretsWarning);
                telemetryInfo.TryGetValue("SanitizedProperties", out var sanitizedProperties);
                telemetryInfo.TryGetValue("InvocationName", out var invocationName);
                if (showSecretsWarning == "true")
                {
                    if (string.IsNullOrEmpty(sanitizedProperties))
                    {
                        WriteWarning($"The output of cmdlet {invocationName} may compromise security by showing secrets. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844");
                    }
                    else
                    {
                        WriteWarning($"The output of cmdlet {invocationName} may compromise security by showing the following secrets: {sanitizedProperties}. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844");
                    }
                }
            }
        }

        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the message is completed.
        /// </returns>
         async global::System.Threading.Tasks.Task Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener.Signal(string id, global::System.Threading.CancellationToken token, global::System.Func<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.EventData> messageData)
        {
            using( NoSynchronizationContext )
            {
                if (token.IsCancellationRequested)
                {
                    return ;
                }

                switch ( id )
                {
                    case Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.Verbose:
                    {
                        WriteVerbose($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.Warning:
                    {
                        WriteWarning($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.Information:
                    {
                        // When an operation supports asjob, Information messages must go thru verbose.
                        WriteVerbose($"INFORMATION: {(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.Debug:
                    {
                        WriteDebug($"{(messageData().Message ?? global::System.String.Empty)}");
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.Error:
                    {
                        WriteError(new global::System.Management.Automation.ErrorRecord( new global::System.Exception(messageData().Message), string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null ) );
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.Progress:
                    {
                        var data = messageData();
                        int progress = (int)data.Value;
                        string activityMessage, statusDescription;
                        global::System.Management.Automation.ProgressRecordType recordType;
                        if (progress < 100)
                        {
                            activityMessage = "In progress";
                            statusDescription = "Checking operation status";
                            recordType = System.Management.Automation.ProgressRecordType.Processing;
                        }
                        else
                        {
                            activityMessage = "Completed";
                            statusDescription = "Completed";
                            recordType = System.Management.Automation.ProgressRecordType.Completed;
                        }
                        WriteProgress(new global::System.Management.Automation.ProgressRecord(1, activityMessage, statusDescription)
                        {
                            PercentComplete = progress,
                        RecordType = recordType
                        });
                        return ;
                    }
                    case Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.DelayBeforePolling:
                    {
                        var data = messageData();
                        if (true == MyInvocation?.BoundParameters?.ContainsKey("NoWait"))
                        {
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                var asyncOperation = response.GetFirstHeader(@"Azure-AsyncOperation");
                                var location = response.GetFirstHeader(@"Location");
                                var uri = global::System.String.IsNullOrEmpty(asyncOperation) ? global::System.String.IsNullOrEmpty(location) ? response.RequestMessage.RequestUri.AbsoluteUri : location : asyncOperation;
                                WriteObject(new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.PowerShell.AsyncOperationResponse { Target = uri });
                                // do nothing more.
                                data.Cancel();
                                return;
                            }
                        }
                        else
                        {
                            if (data.ResponseMessage is System.Net.Http.HttpResponseMessage response)
                            {
                                int delay = (int)(response.Headers.RetryAfter?.Delta?.TotalSeconds ?? 30);
                                WriteDebug($"Delaying {delay} seconds before polling.");
                                for (var now = 0; now < delay; ++now)
                                {
                                    WriteProgress(new global::System.Management.Automation.ProgressRecord(1, "In progress", "Checking operation status")
                                    {
                                        PercentComplete = now * 100 / delay
                                    });
                                    await global::System.Threading.Tasks.Task.Delay(1000, token);
                                }
                            }
                        }
                        break;
                    }
                }
                await Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Module.Instance.Signal(id, token, messageData, (i, t, m) => ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(i, t, () => Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.EventDataConverter.ConvertFrom(m()) as Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.EventData), InvocationInformation, this.ParameterSetName, __correlationId, __processRecordId, null );
                if (token.IsCancellationRequested)
                {
                    return ;
                }
                WriteDebug($"{id}: {(messageData().Message ?? global::System.String.Empty)}");
            }
        }

        private void PreProcessManagedIdentityParameters()
        {
            if (this.UserAssignedIdentity?.Length > 0)
            {
                // calculate UserAssignedIdentity
                _resourceBody.IdentityUserAssignedIdentity.Clear();
                foreach( var id in this.UserAssignedIdentity )
                {
                    _resourceBody.IdentityUserAssignedIdentity.Add(id, new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.UserAssignedIdentity());
                }
            }
            // calculate IdentityType
            if (this.UserAssignedIdentity?.Length > 0)
            {
                if ("SystemAssigned".Equals(_resourceBody.IdentityType, StringComparison.InvariantCultureIgnoreCase))
                {
                    _resourceBody.IdentityType = "SystemAssigned,UserAssigned";
                }
                else
                {
                    _resourceBody.IdentityType = "UserAssigned";
                }
            }
        }

        /// <summary>Performs execution of the command.</summary>
        protected override void ProcessRecord()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletProcessRecordStart).Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
            __processRecordId = System.Guid.NewGuid().ToString();
            try
            {
                // work
                if (ShouldProcess($"Call remote 'FleetsCreateOrUpdate' operation"))
                {
                    if (true == MyInvocation?.BoundParameters?.ContainsKey("AsJob"))
                    {
                        var instance = this.Clone();
                        var job = new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.PowerShell.AsyncJob(instance, this.MyInvocation.Line, this.MyInvocation.MyCommand.Name, this._cancellationTokenSource.Token, this._cancellationTokenSource.Cancel);
                        JobRepository.Add(job);
                        var task = instance.ProcessRecordAsync();
                        job.Monitor(task);
                        WriteObject(job);
                    }
                    else
                    {
                        using( var asyncCommandRuntime = new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token) )
                        {
                            asyncCommandRuntime.Wait( ProcessRecordAsync(),((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token);
                        }
                    }
                }
            }
            catch (global::System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach( var innerException in aggregateException.Flatten().InnerExceptions )
                {
                    ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    // Write exception out to error channel.
                    WriteError( new global::System.Management.Automation.ErrorRecord(innerException,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
                }
            }
            catch (global::System.Exception exception) when ((exception as System.Management.Automation.PipelineStoppedException)== null || (exception as System.Management.Automation.PipelineStoppedException).InnerException != null)
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if( ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                // Write exception out to error channel.
                WriteError( new global::System.Management.Automation.ErrorRecord(exception,string.Empty, global::System.Management.Automation.ErrorCategory.NotSpecified, null) );
            }
            finally
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletProcessRecordEnd).Wait();
            }
        }

        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async global::System.Threading.Tasks.Task ProcessRecordAsync()
        {
            using( NoSynchronizationContext )
            {
                await ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletGetPipeline); if( ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                Pipeline = Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Module.Instance.CreatePipeline(InvocationInformation, __correlationId, __processRecordId, this.ParameterSetName, this.ExtensibleParameters);
                if (null != HttpPipelinePrepend)
                {
                    Pipeline.Prepend((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelinePrepend) ?? HttpPipelinePrepend);
                }
                if (null != HttpPipelineAppend)
                {
                    Pipeline.Append((this.CommandRuntime as Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.PowerShell.IAsyncCommandRuntimeExtensions)?.Wrap(HttpPipelineAppend) ?? HttpPipelineAppend);
                }
                // get the client instance
                try
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletBeforeAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                    this.PreProcessManagedIdentityParameters();
                    await this.Client.FleetsCreateOrUpdate(SubscriptionId, ResourceGroupName, Name, _resourceBody, onOk, onDefault, this, Pipeline, Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.SerializationMode.IncludeCreate);
                    await ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletAfterAPICall); if( ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Token.IsCancellationRequested ) { return; }
                }
                catch (Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.UndeclaredResponseException urexception)
                {
                    WriteError(new global::System.Management.Automation.ErrorRecord(urexception, urexception.StatusCode.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new { SubscriptionId=SubscriptionId,ResourceGroupName=ResourceGroupName,Name=Name})
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(urexception.Message) { RecommendedAction = urexception.Action }
                    });
                }
                finally
                {
                    await ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Signal(Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.Events.CmdletProcessRecordAsyncEnd);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetAzComputeFleet_UpdateExpanded" /> cmdlet class.
        /// </summary>
        public SetAzComputeFleet_UpdateExpanded()
        {

        }

        /// <summary>Interrupts currently running code within the command.</summary>
        protected override void StopProcessing()
        {
            ((Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.IEventListener)this).Cancel();
            base.StopProcessing();
        }

        /// <param name="sendToPipeline"></param>
        new protected void WriteObject(object sendToPipeline)
        {
            Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline);
        }

        /// <param name="sendToPipeline"></param>
        /// <param name="enumerateCollection"></param>
        new protected void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Module.Instance.SanitizeOutput?.Invoke(sendToPipeline, __correlationId);
            base.WriteObject(sendToPipeline, enumerateCollection);
        }

        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IErrorResponse">Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IErrorResponse</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onDefault(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IErrorResponse> response)
        {
            using( NoSynchronizationContext )
            {
                var _returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(false);
                overrideOnDefault(responseMessage, response, ref _returnNow);
                // if overrideOnDefault has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return ;
                }
                // Error Response : default
                var code = (await response)?.Code;
                var message = (await response)?.Message;
                if ((null == code || null == message))
                {
                    // Unrecognized Response. Create an error record based on what we have.
                    var ex = new Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.RestException<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IErrorResponse>(responseMessage, await response);
                    WriteError( new global::System.Management.Automation.ErrorRecord(ex, ex.Code, global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  })
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(ex.Message) { RecommendedAction = ex.Action }
                    });
                }
                else
                {
                    WriteError( new global::System.Management.Automation.ErrorRecord(new global::System.Exception($"[{code}] : {message}"), code?.ToString(), global::System.Management.Automation.ErrorCategory.InvalidOperation, new {  })
                    {
                      ErrorDetails = new global::System.Management.Automation.ErrorDetails(message) { RecommendedAction = global::System.String.Empty }
                    });
                }
            }
        }

        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an global::System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet">Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet</see>
        /// from the remote call</param>
        /// <returns>
        /// A <see cref="global::System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async global::System.Threading.Tasks.Task onOk(global::System.Net.Http.HttpResponseMessage responseMessage, global::System.Threading.Tasks.Task<Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet> response)
        {
            using( NoSynchronizationContext )
            {
                var _returnNow = global::System.Threading.Tasks.Task<bool>.FromResult(false);
                overrideOnOk(responseMessage, response, ref _returnNow);
                // if overrideOnOk has returned true, then return right away.
                if ((null != _returnNow && await _returnNow))
                {
                    return ;
                }
                // onOk - response for 200 / application/json
                // (await response) // should be Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IFleet
                var result = (await response);
                WriteObject(result, false);
            }
        }
    }
}