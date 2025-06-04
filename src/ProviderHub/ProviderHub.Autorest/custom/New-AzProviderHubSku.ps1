
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
Create the resource type skus in the given resource type.
.Description
Create the resource type skus in the given resource type.
.Example
$skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}
$skuSetting2 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku2"; Tier = "Tier1"; Kind = "Standard"}

New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default" -SkuSetting $skuSetting1, $skuSetting2
.Example
$skuSetting1 = New-Object -TypeName "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.SkuSetting" -Property @{Name = "freeSku"; Tier = "Tier1"; Kind = "Standard"}

New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType/nestedResourceType" -Sku "default" -SkuSetting $skuSetting1

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PROVIDERREGISTRATIONINPUTOBJECT <IProviderHubIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [NestedResourceTypeFirst <String>]: The first child resource type.
  [NestedResourceTypeSecond <String>]: The second child resource type.
  [NestedResourceTypeThird <String>]: The third child resource type.
  [NotificationRegistrationName <String>]: The notification registration.
  [ProviderNamespace <String>]: The name of the resource provider hosted within ProviderHub.
  [ResourceType <String>]: The resource type.
  [RolloutName <String>]: The rollout name.
  [Sku <String>]: The SKU.
  [SubscriptionId <String>]: The ID of the target subscription.

RESOURCETYPEREGISTRATIONINPUTOBJECT <IProviderHubIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [NestedResourceTypeFirst <String>]: The first child resource type.
  [NestedResourceTypeSecond <String>]: The second child resource type.
  [NestedResourceTypeThird <String>]: The third child resource type.
  [NotificationRegistrationName <String>]: The notification registration.
  [ProviderNamespace <String>]: The name of the resource provider hosted within ProviderHub.
  [ResourceType <String>]: The resource type.
  [RolloutName <String>]: The rollout name.
  [Sku <String>]: The SKU.
  [SubscriptionId <String>]: The ID of the target subscription.

SKUSETTING <ISkuSetting[]>: .
  Name <String>:
  [Capability <List<ISkuCapability>>]: 
    Name <String>:
    Value <String>:
  [CapacityDefault <Int32?>]:
  [CapacityMaximum <Int32?>]:
  [CapacityMinimum <Int32?>]:
  [CapacityScaleType <String>]: 
  [Cost <List<ISkuCost>>]: 
    MeterId <String>:
    [ExtendedUnit <String>]:
    [Quantity <Int32?>]:
  [Family <String>]:
  [Kind <String>]:
  [Location <List<String>>]: 
  [LocationInfo <List<ISkuLocationInfo>>]: 
    Location <String>:
    [ExtendedLocation <List<String>>]: 
    [Type <String>]:
    [Zone <List<String>>]: 
    [ZoneDetail <List<ISkuZoneDetail>>]: 
      [Capability <List<ISkuCapability>>]: 
      [Name <List<String>>]: 
  [RequiredFeature <List<String>>]: 
  [RequiredQuotaId <List<String>>]: 
  [Size <String>]:
  [Tier <String>]:
.Link
https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubsku
#>
function New-AzProviderHubSku {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuResource])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The name of the resource provider hosted within ProviderHub.
    ${ProviderNamespace},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded', Mandatory)]
    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The resource type.
    ${ResourceType},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [System.String]
    # The SKU.
    ${Sku},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaJsonFilePath')]
    [Parameter(ParameterSetName='CreateViaJsonString')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity]
    # Identity Parameter
    ${ProviderRegistrationInputObject},

    [Parameter(ParameterSetName='CreateViaIdentityResourcetypeRegistrationExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity]
    # Identity Parameter
    ${ResourcetypeRegistrationInputObject},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityResourcetypeRegistrationExpanded')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ISkuSetting[]]
    # .
    # To construct, see NOTES section for SKUSETTING properties and create a hash table.
    ${SkuSetting},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityProviderRegistrationExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityResourcetypeRegistrationExpanded')]
    
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # .
    ${ProvisioningState},

    [Parameter(ParameterSetName='CreateViaJsonFilePath', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # Path of Json file supplied to the Create operation
    ${JsonFilePath},

    [Parameter(ParameterSetName='CreateViaJsonString', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Body')]
    [System.String]
    # Json string supplied to the Create operation
    ${JsonString},
    
    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The DefaultProfile parameter is not functional.
    # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Category('Runtime')]
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
        
        $testPlayback = $false
        $PSBoundParameters['HttpPipelinePrepend'] | Foreach-Object { if ($_) { $testPlayback = $testPlayback -or ('Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.PipelineMock' -eq $_.Target.GetType().FullName -and 'Playback' -eq $_.Target.Mode) } }

        $mapping = @{
            CreateExpanded = 'Az.ProviderHub.private\New-AzProviderHubSku_CreateExpanded';
            CreateViaIdentityProviderRegistrationExpanded = 'Az.ProviderHub.private\New-AzProviderHubSku_CreateViaIdentityProviderRegistrationExpanded';
            CreateViaIdentityResourcetypeRegistrationExpanded = 'Az.ProviderHub.private\New-AzProviderHubSku_CreateViaIdentityResourcetypeRegistrationExpanded';
            CreateViaJsonFilePath = 'Az.ProviderHub.private\New-AzProviderHubSku_CreateViaJsonFilePath';
            CreateViaJsonString = 'Az.ProviderHub.private\New-AzProviderHubSku_CreateViaJsonString';
        }
        if (('CreateExpanded', 'CreateViaJsonFilePath', 'CreateViaJsonString') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId') ) {
            if ($testPlayback) {
                $PSBoundParameters['SubscriptionId'] = . (Join-Path $PSScriptRoot '..' 'utils' 'Get-SubscriptionIdTestSafe.ps1')
            } else {
                $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
            }
        }
        if ($PSBoundParameters.ContainsKey('ResourceType')) {
            $resourceTypePath = $PSBoundParameters['ResourceType'] -Split "/" -Join "/resourcetyperegistrations/"
            $PSBoundParameters['ResourceType'] = $resourceTypePath
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        if ($wrappedCmd -eq $null) {
            $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Function)
        }
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
