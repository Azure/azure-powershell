
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
The operation to create or update a virtual machine.
Please note some properties can be set only during virtual machine creation.
.Description
The operation to create or update a virtual machine.
Please note some properties can be set only during virtual machine creation.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachines
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

LINUXCONFIGURATIONSSHPUBLICKEY <IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[]>: PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
  [KeyData <String>]: KeyData - SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Li      nux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
  [Path <String>]: Path - Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys

NETWORKPROFILENETWORKINTERFACE <IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[]>: NetworkInterfaces - list of network interfaces to be attached to the virtual machine
  [Id <String>]: ID - Resource Id of the network interface

STORAGEPROFILEDATADISK <IVirtualMachinePropertiesStorageProfileDataDisksItem[]>: adds data disks to the virtual machine
  [Id <String>]: Resource ID of the data disk

WINDOWSCONFIGURATIONSSHPUBLICKEY <IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[]>: PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
  [KeyData <String>]: KeyData - SSH public key certificate used to authenticate with the VM through ssh. The key needs to be at least 2048-bit and in ssh-rsa format.    For creating ssh keys, see [Create SSH keys on Linux and Mac for Li      nux VMs in Azure](https://docs.microsoft.com/azure/virtual-machines/virtual-machines-linux-mac-create-ssh-keys?toc=%2fazure%2fvirtual-machines%2flinux%2ftoc.json).
  [Path <String>]: Path - Specifies the full path on the created VM where ssh public key is stored. If the file already exists, the specified key is appended to the file. Example: /home/user/.ssh/authorized_keys
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmvirtualmachine
#>
function New-AzStackHciVMVirtualMachine {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachines])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('VirtualMachineName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [System.String]
    # Name of the virtual machine
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # AdminPassword - admin password
    ${AdminPassword},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # AdminUsername - admin username
    ${AdminUsername},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # ComputerName - name of the compute
    ${ComputerName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # The name of the extended location.
    ${CustomLocationId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # DisablePasswordAuthentication - whether password authentication should be disabled
    ${DisablePasswordAuthentication},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Int64]
    # .
    ${DynamicMemoryMaximumMemory},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Int64]
    # .
    ${DynamicMemoryMinimumMemory},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Int32]
    # Defines the amount of extra memory that should be reserved for a virtual machine at runtime, as a percentage of the total memory that the virtual machine is thought to need.
    # This only applies to virtual systems with dynamic memory enabled.
    # This property can be in the range of 5 to 2000.
    ${DynamicMemoryTargetBuffer},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Whether to EnableAutomaticUpdates on the machine
    ${EnableAutomaticUpdate},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${EnableTpm},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='"CustomLocation"')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes]
    # The type of the extended location.
    ${ExtendedLocationType},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType]
    # The identity type.
    ${IdentityType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # Resource ID of the image
    ${ImageId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
    ${LinuxConfigurationProvisionVMAgent},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileLinuxConfigurationSshPublicKeysItem[]]
    # PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
    # To construct, see NOTES section for LINUXCONFIGURATIONSSHPUBLICKEY properties and create a hash table.
    ${LinuxConfigurationSshPublicKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesNetworkProfileNetworkInterfacesItem[]]
    # NetworkInterfaces - list of network interfaces to be attached to the virtual machine
    # To construct, see NOTES section for NETWORKPROFILENETWORKINTERFACE properties and create a hash table.
    ${NetworkProfileNetworkInterface},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # Resource ID of the OS disk
    ${OSDiskId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.OSTypeEnum]
    # OsType - string specifying whether the OS is Linux or Windows
    ${OsType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specifies whether secure boot should be enabled on the virtual machine.
    ${SecureBootEnabled},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # Id of the storage container that hosts the VM configuration file
    ${StoragePathId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesStorageProfileDataDisksItem[]]
    # adds data disks to the virtual machine
    # To construct, see NOTES section for STORAGEPROFILEDATADISK properties and create a hash table.
    ${StorageProfileDataDisk},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.DateTime]
    # The timestamp of resource creation (UTC).
    ${SystemDataCreatedAt},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # The identity that created the resource.
    ${SystemDataCreatedBy},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType]
    # The type of identity that created the resource.
    ${SystemDataCreatedByType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.DateTime]
    # The timestamp of resource last modification (UTC)
    ${SystemDataLastModifiedAt},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # The identity that last modified the resource.
    ${SystemDataLastModifiedBy},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType]
    # The type of identity that last modified the resource.
    ${SystemDataLastModifiedByType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tags},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.String]
    # TimeZone for the virtual machine
    ${TimeZone},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Int64]
    # RAM in MB for the virtual machine
    ${VmMemory},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Int32]
    # number of processors for the virtual machine
    ${VmProcessors},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum]
    # .
    ${VmSize},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Used to indicate whether Arc for Servers agent onboarding should be triggered during the virtual machine creation process.
    ${WindowConfigurationProvisionVMAgent},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IVirtualMachinePropertiesOSProfileWindowsConfigurationSshPublicKeysItem[]]
    # PublicKeys - The list of SSH public keys used to authenticate with linux based VMs.
    # To construct, see NOTES section for WINDOWSCONFIGURATIONSSHPUBLICKEY properties and create a hash table.
    ${WindowsConfigurationSshPublicKey},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CreateExpanded = 'Az.StackHCIVm.private\New-AzStackHciVMVirtualMachine_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('ExtendedLocationType')) {
            $PSBoundParameters['ExtendedLocationType'] = "CustomLocation"
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
