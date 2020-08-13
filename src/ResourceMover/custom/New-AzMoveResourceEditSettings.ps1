
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

.Description

.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResource
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.IRegionMoveIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

BODY <IMoveResource>: Defines the move resource.
  ResourceSettingResourceType <String>: The resource type. For example, the value can be Microsoft.Compute/virtualMachines.
  [DependsOnOverride <IMoveResourceDependencyOverride[]>]: Gets or sets the move resource dependencies overrides.
    [Id <String>]: Gets or sets the ARM ID of the dependent resource.
    [TargetId <String>]: Gets or sets the resource ARM id of either the MoveResource or the resource ARM ID of         the dependent resource.
  [ExistingTargetId <String>]: Gets or sets the existing target ARM Id of the resource.
  [MoveStatusCode <String>]: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
  [MoveStatusDetail <ICloudErrorBody[]>]: A list of additional details about the error.
    [Code <String>]: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
    [Detail <ICloudErrorBody[]>]: A list of additional details about the error.
    [Message <String>]: A message describing the error, intended to be suitable for display in a user interface.
    [Target <String>]: The target of the particular error. For example, the name of the property in error.
  [MoveStatusJobName <String>]: Defines the job names.
  [MoveStatusJobProgress <String>]: Gets or sets the monitoring job percentage.
  [MoveStatusMessage <String>]: A message describing the error, intended to be suitable for display in a user interface.
  [MoveStatusMoveState <String>]: Defines the MoveResource states.
  [MoveStatusTarget <String>]: The target of the particular error. For example, the name of the property in error.
  [MoveStatusTargetId <String>]: Gets the Target ARM Id of the resource.
  [ProvisioningState <String>]: Defines the provisioning states.
  [ResourceSettingTargetResourceName <String>]: Gets or sets the target Resource name.
  [SourceId <String>]: Gets or sets the Source ARM Id of the resource.

DEPENDSONOVERRIDE <IMoveResourceDependencyOverride[]>: Gets or sets the move resource dependencies overrides.
  [Id <String>]: Gets or sets the ARM ID of the dependent resource.
  [TargetId <String>]: Gets or sets the resource ARM id of either the MoveResource or the resource ARM ID of         the dependent resource.

INPUTOBJECT <IRegionMoveIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [MoveCollectionName <String>]: 
  [MoveResourceName <String>]: 
  [ResourceGroupName <String>]: 
  [SubscriptionId <String>]: The Subscription ID.

MOVESTATUSDETAIL <ICloudErrorBody[]>: A list of additional details about the error.
  [Code <String>]: An identifier for the error. Codes are invariant and are intended to be consumed programmatically.
  [Detail <ICloudErrorBody[]>]: A list of additional details about the error.
  [Message <String>]: A message describing the error, intended to be suitable for display in a user interface.
  [Target <String>]: The target of the particular error. For example, the name of the property in error.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.regionmove/new-azmoveresource
#>
function Update-AzMoveResourceEditSettings {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Path')]
    [System.String]
    # .Gets or sets the MoveCollectionName
    ${MoveCollectionName},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded')]   
    [Parameter(ParameterSetName='VirtualMachines', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
     # Gets or sets the target availability zone.
     ${TargetAvailabilityZone},

     [Parameter(ParameterSetName='Create', Mandatory)]
     [Parameter(ParameterSetName='CreateExpanded')]     
     [Parameter(ParameterSetName='AvailabilitySet', Mandatory)]
     [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
     # Gets or sets the target UpdateDomain.
      ${UpdateDomain},
 

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Alias('MoveResourceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Path')]
    [System.String]
    # .
    ${Name},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Path')]
    [System.String]
    # .
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Path')]
    [System.String]
    # The Subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.IRegionMoveIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]    
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResource]
    # Defines the move resource.
    # To construct, see NOTES section for BODY properties and create a hash table.
    ${Body},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResourceDependencyOverride[]]
    # Gets or sets the move resource dependencies overrides.
    # To construct, see NOTES section for DEPENDSONOVERRIDE properties and create a hash table.
    ${DependsOnOverride},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # Gets or sets the existing target ARM Id of the resource.
    ${ExistingTargetId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # An identifier for the error.
    # Codes are invariant and are intended to be consumed programmatically.
    ${MoveStatusCode},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.ICloudErrorBody[]]
    # A list of additional details about the error.
    # To construct, see NOTES section for MOVESTATUSDETAIL properties and create a hash table.
    ${MoveStatusDetail},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # Defines the job names.
    ${MoveStatusJobName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # Gets or sets the monitoring job percentage.
    ${MoveStatusJobProgress},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # A message describing the error, intended to be suitable for display in a user interface.
    ${MoveStatusMessage},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # Defines the MoveResource states.
    ${MoveStatusMoveState},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # The target of the particular error.
    # For example, the name of the property in error.
    ${MoveStatusTarget},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # Gets the Target ARM Id of the resource.
    ${MoveStatusTargetId},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # Defines the provisioning states.
    ${ProvisioningState},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # The resource type.
    # For example, the value can be Microsoft.Compute/virtualMachines.
    ${ResourceSettingResourceType},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # Gets or sets the target Resource name.
    ${ResourceSettingTargetResourceName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Body')]
    [System.String]
    # Gets or sets the Source ARM Id of the resource.
    ${SourceId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
      
      # Write-Host 'vm';
      # Write-Output 'data';
      # Write-Output $ResourceSettingResourceType
      # Write-Output $PSBoundParameters['ResourceSettingResourceType']
      $moveResourcePropeties = [ Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.MoveResourceProperties]::new() 
      if ($ResourceSettingResourceType -eq 'Microsoft.Compute/virtualMachines') {   
        Write-Host "virtual machines"             
        Write-Output 'data2';
        $virtualsettings = [ Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.VirtualMachineResourceSettings]::new()         
        $virtualsettings.TargetAvailabilityZone = $TargetAvailabilityZone;   
        $moveResourcePropeties.ResourceSetting = $virtualsettings;   
      }
      elseif ($ResourceSettingResourceType -eq 'AvailabilitySet'){
        $availabilitySetSettings = [ Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.AvailabilitySetResourceSettings]::new()         
        $availabilitySetSettings.UpdateDomain = $UpdateDomain; 
        $moveResourcePropeties.ResourceSetting = $availabilitySetSettings;
      }            
      $moveResourcePropeties.SourceId =$SourceId ;   
      $moveResourcePropeties.ResourceSettingResourceType  = $ResourceSettingResourceType;
      $moveResourcePropeties.ResourceSettingTargetResourceName  = $ResourceSettingTargetResourceName; 
      $moveResource = [ Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.MoveResource]::new() 
      $moveResource.Property = $moveResourcePropeties;                   
      $PSBoundParameters["Body"] =   $moveResource;
      $null = $PSBoundParameters.Remove('TargetAvailabilityZone');
      $null = $PSBoundParameters.Remove('SourceId');
      $null = $PSBoundParameters.Remove('ResourceSettingResourceType');
      $null = $PSBoundParameters.Remove('ResourceSettingTargetResourceName');
      $null = $PSBoundParameters.Remove('UpdateDomain');


        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $parameterSet = "Create"
        $mapping = @{
            Create = 'Az.RegionMove.private\New-AzMoveResource_Create';
            CreateExpanded = 'Az.RegionMove.private\New-AzMoveResource_CreateExpanded';
            CreateViaIdentity = 'Az.RegionMove.private\New-AzMoveResource_CreateViaIdentity';
            CreateViaIdentityExpanded = 'Az.RegionMove.private\New-AzMoveResource_CreateViaIdentityExpanded';
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
