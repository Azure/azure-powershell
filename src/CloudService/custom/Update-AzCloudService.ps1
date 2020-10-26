
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
Reimages one or more role instances in a cloud service.
.Description
Reimages one or more role instances in a cloud service.

.Link
https://docs.microsoft.com/en-us/powershell/module/az.cloudservice/update-azcloudservice
#>
function Update-AzCloudService {
[OutputType([System.Boolean], [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudService])]
[CmdletBinding(DefaultParameterSetName='Update', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Update', Mandatory)]
    [Alias('CloudServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service
    ${Name},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the Resource Group
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Update')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudService]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceUpdateTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # .
    ${Configuration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # .
    ${ConfigurationUrl},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.IExtension[]]
    # .
    # To construct, see NOTES section for EXTENSIONPROFILEEXTENSION properties and create a hash table.
    ${ExtensionProfileExtension},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ILoadBalancerConfiguration[]]
    # .
    # To construct, see NOTES section for NETWORKPROFILELOADBALANCERCONFIGURATION properties and create a hash table.
    ${NetworkProfileLoadBalancerConfiguration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceVaultSecretGroup[]]
    # .
    # To construct, see NOTES section for OSPROFILESECRET properties and create a hash table.
    ${OSProfileSecret},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # .
    ${PackageUrl},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.ICloudServiceRoleProfileProperties[]]
    # .
    # To construct, see NOTES section for ROLEPROFILEROLE properties and create a hash table.
    ${RoleProfileRole},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${StartCloudService},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Resource Id
    ${SwappableCloudServiceId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode]
    # .
    ${UpgradeMode},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)
  process {
    if (!$PSBoundParameters.ContainsKey('InputObject')) {
      $GetPSBoundParameters = @{}
      if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
          $GetPSBoundParameters['HttpPipelineAppend'] = $HttpPipelineAppend
      }
      if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) {
          $GetPSBoundParameters['HttpPipelinePrepend'] = $HttpPipelinePrepend
      }
      $GetPSBoundParameters['SubscriptionId'] = $SubscriptionId
      $InputObject = Az.CloudService.internal\Get-AzCloudService -ResourceGroupName $ResourceGroupName -Name $Name @GetPSBoundParameters
      
    } else {
      $PSBoundParameters.Add('Name', $InputObject.Name)
      $PSBoundParameters.Add('ResourceGroupName', $InputObject.ResourceGroupName)
      $Null = $PSBoundParameters.Remove('InputObject')
    }
    if (!$PSBoundParameters.ContainsKey('Tag')) {
      $Tag = @{}
      foreach ($key in $InputObject.Tag.Keys) {
        $Tag.Add($key, $InputObject.Tag[$key])
      }
      $PSBoundParameters.Add('Tag', $Tag)
    }
    if (!$PSBoundParameters.ContainsKey('Configuration')) {
      $PSBoundParameters.Add('Configuration', $InputObject.Configuration)
    }
    if (!$PSBoundParameters.ContainsKey('ConfigurationUrl')) {
      $PSBoundParameters.Add('ConfigurationUrl', $InputObject.ConfigurationUrl)
    }
    if (!$PSBoundParameters.ContainsKey('ExtensionProfileExtension')) {
      $PSBoundParameters.Add('ExtensionProfileExtension', $InputObject.ExtensionProfileExtension)
    }
    if (!$PSBoundParameters.ContainsKey('NetworkProfileLoadBalancerConfiguration')) {
      $PSBoundParameters.Add('NetworkProfileLoadBalancerConfiguration', $InputObject.NetworkProfileLoadBalancerConfiguration)
    }
    if (!$PSBoundParameters.ContainsKey('OSProfileSecret')) {
      $PSBoundParameters.Add('OSProfileSecret', $InputObject.OSProfileSecret)
    }
    if (!$PSBoundParameters.ContainsKey('PackageUrl')) {
      $PSBoundParameters.Add('PackageUrl', $InputObject.PackageUrl)
    }
    if (!$PSBoundParameters.ContainsKey('RoleProfileRole')) {
      $PSBoundParameters.Add('RoleProfileRole', $InputObject.RoleProfileRole)
    }
    if (!$PSBoundParameters.ContainsKey('StartCloudService')) {
      $PSBoundParameters.Add('StartCloudService', $InputObject.StartCloudService)
    }
    if (!$PSBoundParameters.ContainsKey('SwappableCloudServiceId') -and $SwappableCloudServiceId -ne '') {
      $PSBoundParameters.Add('SwappableCloudServiceId', $InputObject.SwappableCloudServiceId)
    }
    if (!$PSBoundParameters.ContainsKey('UpgradeMode')) {
      $PSBoundParameters.Add('UpgradeMode', $InputObject.UpgradeMode)
    }
    $PSBoundParameters.Add('Location', $InputObject.Location)
    # if (!$PSBoundParameters.ContainsKey('Location')) {
    # }
    Az.CloudService.internal\New-AzCloudService @PSBoundParameters

  }
}
