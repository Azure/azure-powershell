
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
Gets the status of a cloud service.
.Description
Gets the status of a cloud service.
.Example
PS C:\>$cloudServiceInstanceView = Get-AzCloudServiceInstanceView -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"

PS C:\>$cloudServiceInstanceView
RoleInstanceStatusesSummary                                   Statuses
---------------------------                                   --------
{{ProvisioningState/succeeded : 4}, {PowerState/started : 4}} {Provisioning succeeded, Started, Current Upgrade Domain of cloud service is -1., Max Upgrade Domain of cloud service is 1.}

PS C:\>$cloudServiceInstanceView.ToJsonString()
{
  "roleInstance": {
    "statusesSummary": [
      {
        "code": "ProvisioningState/succeeded",
        "count": 4
      },
      {
        "code": "PowerState/started",
        "count": 4
      }
    ]
  },
  "statuses": [
    {
      "code": "ProvisioningState/succeeded",
      "displayStatus": "Provisioning succeeded",
      "level": "Info",
      "time": "2020-10-28T13:26:48.8109686Z"
    },
    {
      "code": "PowerState/started",
      "displayStatus": "Started",
      "level": "Info",
      "time": "2020-10-28T13:26:48.8109686Z"
    },
    {
      "code": "CurrentUpgradeDomain/-1",
      "displayStatus": "Current Upgrade Domain of cloud service is -1.",
      "level": "Info"
    },
    {
      "code": "MaxUpgradeDomain/1",
      "displayStatus": "Max Upgrade Domain of cloud service is 1.",
      "level": "Info"
    }
  ]
}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceView
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudserviceinstanceview
#>
function Get-AzCloudServiceInstanceView {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInstanceView])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${CloudServiceName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.CloudService.private\Get-AzCloudServiceInstanceView_Get';
        }
        if (('Get') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Gets properties of a guest operating system family that can be specified in the XML service configuration (.cscfg) for a cloud service.
.Description
Gets properties of a guest operating system family that can be specified in the XML service configuration (.cscfg) for a cloud service.
.Example
PS C:\> Get-AzCloudServiceOSFamily -location 'westus2'

Name Label
---- -----
5    Windows Server 2016
4    Windows Server 2012 R2
6    Windows Server 2019
3    Windows Server 2012
2    Windows Server 2008 R2
.Example
PS C:\> Get-AzCloudServiceOSFamily -location 'westus2' -OSFamilyName 5

Name Label
---- -----
5    Windows Server 2016

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamily
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudserviceosfamily
#>
function Get-AzCloudServiceOSFamily {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSFamily])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the location that the OS family pertains to.
    ${Location},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the OS family.
    ${OSFamilyName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.CloudService.private\Get-AzCloudServiceOSFamily_Get';
            GetViaIdentity = 'Az.CloudService.private\Get-AzCloudServiceOSFamily_GetViaIdentity';
            List = 'Az.CloudService.private\Get-AzCloudServiceOSFamily_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Gets properties of a guest operating system version that can be specified in the XML service configuration (.cscfg) for a cloud service.
.Description
Gets properties of a guest operating system version that can be specified in the XML service configuration (.cscfg) for a cloud service.
.Example
PS C:\> Get-AzCloudServiceOSVersion -location 'westus2'

Name                        Label                                            IsDefault IsActive Family FamilyLabel
----                        -----                                            --------- -------- ------ -----------
WA-GUEST-OS-6.7_201905-01   Windows Azure Guest OS 6.7 (Release 201905-01)   False     False    6      Windows Server 2019
WA-GUEST-OS-3.21_201411-01  Windows Azure Guest OS 3.21 (Release 201411-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-3.34_201512-01  Windows Azure Guest OS 3.34 (Release 201512-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-3.26_201504-01  Windows Azure Guest OS 3.26 (Release 201504-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-2.46_201512-01  Windows Azure Guest OS 2.46 (Release 201512-01)  False     False    2      Windows Server 2008 R2
.Example
PS C:\> Get-AzCloudServiceOSVersion -location 'westus2' -OSVersionName 'WA-GUEST-OS-6.7_201905-01'

Name                      Label                                          IsDefault IsActive Family FamilyLabel
----                      -----                                          --------- -------- ------ -----------
WA-GUEST-OS-6.7_201905-01 Windows Azure Guest OS 6.7 (Release 201905-01) False     False    6      Windows Server 2019

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersion
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudserviceosversion
#>
function Get-AzCloudServiceOSVersion {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IOSVersion])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the location that the OS version pertains to.
    ${Location},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the OS version.
    ${OSVersionName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.CloudService.private\Get-AzCloudServiceOSVersion_Get';
            GetViaIdentity = 'Az.CloudService.private\Get-AzCloudServiceOSVersion_GetViaIdentity';
            List = 'Az.CloudService.private\Get-AzCloudServiceOSVersion_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Gets a remote desktop file for a role instance in a cloud service.
.Description
Gets a remote desktop file for a role instance in a cloud service.
.Example
PS C:\> Get-AzCloudServiceRoleInstanceRemoteDesktopFile -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0" -OutFile "C:\temp\ContosoFrontEnd_IN_0.rdp"

.Outputs
System.Boolean
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudserviceroleinstanceremotedesktopfile
#>
function Get-AzCloudServiceRoleInstanceRemoteDesktopFile {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${CloudServiceName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the role instance.
    ${RoleInstanceName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Path to write output file to
    ${OutFile},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.CloudService.private\Get-AzCloudServiceRoleInstanceRemoteDesktopFile_Get';
        }
        if (('Get') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Retrieves information about the run-time state of a role instance in a cloud service.
.Description
Retrieves information about the run-time state of a role instance in a cloud service.
.Example
PS C:\> Get-AzCloudServiceRoleInstanceView -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"

Statuses           PlatformFaultDomain PlatformUpdateDomain
--------           ------------------- --------------------
{RoleStateStarted} 0                   0


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceView
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudserviceroleinstanceview
#>
function Get-AzCloudServiceRoleInstanceView {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceView])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${CloudServiceName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the role instance.
    ${RoleInstanceName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.CloudService.private\Get-AzCloudServiceRoleInstanceView_Get';
        }
        if (('Get') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Gets a role instance from a cloud service.
.Description
Gets a role instance from a cloud service.
.Example
PS C:\> Get-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"

Name                    Location    SkuName        SkuTier
----                    --------    -------        -------
ContosoFrontEnd_IN_0    eastus2euap Standard_D1_v2 Standard
ContosoFrontEnd_IN_1    eastus2euap Standard_D1_v2 Standard
ContosoBackEnd_IN_1     eastus2euap Standard_D1_v2 Standard
ContosoBackEnd_IN_1     eastus2euap Standard_D1_v2 Standard

.Example
PS C:\> Get-AzCloudServiceRoleInstance -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"

Name                    Location    SkuName        SkuTier
----                    --------    -------        -------
ContosoFrontEnd_IN_0    eastus2euap Standard_D1_v2 Standard


.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstance
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudserviceroleinstance
#>
function Get-AzCloudServiceRoleInstance {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstance])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${CloudServiceName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the role instance.
    ${RoleInstanceName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.InstanceViewTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Query')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.InstanceViewTypes]
    # The expand expression to apply to the operation.
    ${Expand},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.CloudService.private\Get-AzCloudServiceRoleInstance_Get';
            GetViaIdentity = 'Az.CloudService.private\Get-AzCloudServiceRoleInstance_GetViaIdentity';
            List = 'Az.CloudService.private\Get-AzCloudServiceRoleInstance_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Display information about a cloud service.
.Description
Display information about a cloud service.
.Example
PS C:\> Get-AzCloudService -ResourceGroupName "ContosOrg"

ResourceGroupName Name              Location    ProvisioningState
----------------- ----              --------    -----------------
ContosOrg         ContosoCS         eastus2euap Succeeded
ContosOrg         ContosoCSTest     eastus2euap Failed
.Example
PS C:\> Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"

ResourceGroupName Name              Location    ProvisioningState
----------------- ----              --------    -----------------
ContosOrg         ContosoCS         eastus2euap Succeeded

PS C:\> $cloudService = Get-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"
PS C:\> $cloudService | Format-List
ResourceGroupName : ContosOrg
Configuration     : xxxxxxxx
ConfigurationUrl  :
ExtensionProfile  : xxxxxxxx
Id                : xxxxxxxx
Location          : East US
Name              : ContosoCS
NetworkProfile    : xxxxxxxx
OSProfile         : xxxxxxxx
PackageUrl        : xxxxxxxx
ProvisioningState : Succeeded
RoleProfile       : xxxxxxxx
StartCloudService :
Tag               : {
                      "Owner": "Contos"
                    }
Type              : Microsoft.Compute/cloudServices
UniqueId          : xxxxxxxx
UpgradeMode       : Auto


.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudservice
#>
function Get-AzCloudService {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('CloudServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.CloudService.private\Get-AzCloudService_Get';
            GetViaIdentity = 'Az.CloudService.private\Get-AzCloudService_GetViaIdentity';
            List = 'Az.CloudService.private\Get-AzCloudService_List';
            List1 = 'Az.CloudService.private\Get-AzCloudService_List1';
        }
        if (('Get', 'List', 'List1') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Rebuild Role Instances reinstalls the operating system on instances of web roles or worker roles and initializes the storage resources that are used by them.
If you do not want to initialize storage resources, you can use Reimage Role Instances.
.Description
Rebuild Role Instances reinstalls the operating system on instances of web roles or worker roles and initializes the storage resources that are used by them.
If you do not want to initialize storage resources, you can use Reimage Role Instances.
.Example
PS C:\> $roleInstances = @("ContosoFrontEnd_IN_0", "ContosoBackEnd_IN_1")
PS C:\> Invoke-AzCloudServiceRebuild -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance $roleInstances
.Example
PS C:\> Invoke-AzCloudServiceRebuild -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance "*"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/invoke-azcloudservicerebuild
#>
function Invoke-AzCloudServiceRebuild {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='RebuildExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='RebuildExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${CloudServiceName},

    [Parameter(ParameterSetName='RebuildExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='RebuildExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RebuildViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory)]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # List of cloud service role instance names.
    # Value of '*' will signify all role instances of the cloud service.
    ${RoleInstance},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            RebuildExpanded = 'Az.CloudService.private\Invoke-AzCloudServiceRebuild_RebuildExpanded';
            RebuildViaIdentityExpanded = 'Az.CloudService.private\Invoke-AzCloudServiceRebuild_RebuildViaIdentityExpanded';
        }
        if (('RebuildExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Reimage asynchronous operation reinstalls the operating system on instances of web roles or worker roles.
.Description
Reimage asynchronous operation reinstalls the operating system on instances of web roles or worker roles.
.Example
PS C:\> $roleInstances = @("ContosoFrontEnd_IN_0", "ContosoBackEnd_IN_1")
PS C:\> Invoke-AzCloudServiceReimage -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance $roleInstances
.Example
PS C:\> Invoke-AzCloudServiceReimage -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance "*"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/invoke-azcloudservicereimage
#>
function Invoke-AzCloudServiceReimage {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='ReimageExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ReimageExpanded', Mandatory)]
    [Alias('CloudServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${Name},

    [Parameter(ParameterSetName='ReimageExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ReimageExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ReimageViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory)]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # List of cloud service role instance names.
    # Value of '*' will signify all role instances of the cloud service.
    ${RoleInstance},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            ReimageExpanded = 'Az.CloudService.private\Invoke-AzCloudServiceReimage_ReimageExpanded';
            ReimageViaIdentityExpanded = 'Az.CloudService.private\Invoke-AzCloudServiceReimage_ReimageViaIdentityExpanded';
        }
        if (('ReimageExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
The Rebuild Role Instance asynchronous operation reinstalls the operating system on instances of web roles or worker roles and initializes the storage resources that are used by them.
If you do not want to initialize storage resources, you can use Reimage Role Instance.
.Description
The Rebuild Role Instance asynchronous operation reinstalls the operating system on instances of web roles or worker roles and initializes the storage resources that are used by them.
If you do not want to initialize storage resources, you can use Reimage Role Instance.
.Example
PS C:\> Invoke-AzCloudServiceRoleInstanceRebuild -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/invoke-azcloudserviceroleinstancerebuild
#>
function Invoke-AzCloudServiceRoleInstanceRebuild {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Rebuild', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Rebuild', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${CloudServiceName},

    [Parameter(ParameterSetName='Rebuild', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Rebuild', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the role instance.
    ${RoleInstanceName},

    [Parameter(ParameterSetName='Rebuild')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RebuildViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Rebuild = 'Az.CloudService.private\Invoke-AzCloudServiceRoleInstanceRebuild_Rebuild';
            RebuildViaIdentity = 'Az.CloudService.private\Invoke-AzCloudServiceRoleInstanceRebuild_RebuildViaIdentity';
        }
        if (('Rebuild') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
The Reimage Role Instance asynchronous operation reinstalls the operating system on instances of web roles or worker roles.
.Description
The Reimage Role Instance asynchronous operation reinstalls the operating system on instances of web roles or worker roles.
.Example
PS C:\> Invoke-AzCloudServiceRoleInstanceReimage -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/invoke-azcloudserviceroleinstancereimage
#>
function Invoke-AzCloudServiceRoleInstanceReimage {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Reimage', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Reimage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${CloudServiceName},

    [Parameter(ParameterSetName='Reimage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Reimage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the role instance.
    ${RoleInstanceName},

    [Parameter(ParameterSetName='Reimage')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ReimageViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Reimage = 'Az.CloudService.private\Invoke-AzCloudServiceRoleInstanceReimage_Reimage';
            ReimageViaIdentity = 'Az.CloudService.private\Invoke-AzCloudServiceRoleInstanceReimage_ReimageViaIdentity';
        }
        if (('Reimage') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create or update a cloud service.
Please note some properties can be set only during cloud service creation.
.Description
Create or update a cloud service.
Please note some properties can be set only during cloud service creation.
.Example
# Create role profile object
PS C:\> $role = New-AzCloudServiceRoleProfilePropertiesObject-Name 'ContosoFrontend' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2
PS C:\> $roleProfile = @{role = @($role)}

# Create network profile object
PS C:\> $publicIp = Get-AzPublicIpAddress -ResourceGroupName ContosOrg -Name ContosIp
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIp.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig
PS C:\> $networkProfile = @{loadBalancerConfiguration = $loadBalancerConfig}

# Read Configuration File
PS C:\> $cscfgFile = "<Path to cscfg configuration file>"
PS C:\> $cscfgContent = Get-Content $cscfgFile | Out-String

# Create cloud service
PS C:\> $cloudService = New-AzCloudService                                              `
                          -Name ContosoCS                                               `
                          -ResourceGroupName ContosOrg                                  `
                          -Location EastUS                                              `
                          -PackageUrl "https://xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"    `
                          -Configuration $cscfgContent                                  `
                          -UpgradeMode 'Auto'                                           `
                          -RoleProfile $roleProfile                                     `
                          -NetworkProfile $networkProfile
.Example
# Create role profile object
PS C:\> $role = New-AzCloudServiceRoleProfilePropertiesObject-Name 'ContosoFrontend' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2
PS C:\> $roleProfile = @{role = @($role)}

# Create network profile object
PS C:\> $publicIp = Get-AzPublicIpAddress -ResourceGroupName ContosoOrg -Name ContosIp
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIp.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig
PS C:\> $networkProfile = @{loadBalancerConfiguration = $loadBalancerConfig}

# Create RDP extension object
PS C:\> $credential = Get-Credential
PS C:\> $expiration = (Get-Date).AddYears(1)
PS C:\> $extension = New-AzCloudServiceRemoteDesktopExtensionObject -Name 'RDPExtension' -Credential $credential -Expiration $expiration -TypeHandlerVersion '1.2.1'
PS C:\> $extensionProfile = @{extension = @($extension)}

# Read Configuration File
PS C:\> $cscfgFile = "<Path to cscfg configuration file>"
PS C:\> $cscfgContent = Get-Content $cscfgFile | Out-String

# Create cloud service
PS C:\> $cloudService = New-AzCloudService                                              `
                          -Name ContosoCS                                               `
                          -ResourceGroupName ContosOrg                                  `
                          -Location EastUS                                              `
                          -PackageUrl "https://xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"    `
                          -Configuration $cscfgContent                                  `
                          -UpgradeMode 'Auto'                                           `
                          -RoleProfile $roleProfile                                     `
                          -NetworkProfile $networkProfile                               `
                          -ExtensionProfile $extensionProfile
.Example
# Create role profile object
PS C:\> $role = New-AzCloudServiceRoleProfilePropertiesObject-Name 'ContosoFrontend' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2
PS C:\> $roleProfile = @{role = @($role)}

# Create OS profile object
PS C:\> $keyVault = Get-AzKeyVault -ResourceGroupName ContosOrg -VaultName ContosKeyVault
PS C:\> $certificate=Get-AzKeyVaultCertificate -VaultName ContosKeyVault -Name ContosCert
PS C:\> $secretGroup = New-AzCloudServiceVaultSecretGroupObject -Id $keyVault.ResourceId -CertificateUrl $certificate.SecretId
PS C:\> $osProfile = @{secret = @($secretGroup)}

# Create network profile object
PS C:\> $publicIp = Get-AzPublicIpAddress -ResourceGroupName ContosOrg -Name ContosIp
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIp.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig
PS C:\> $networkProfile = @{loadBalancerConfiguration = $loadBalancerConfig}

# Read Configuration File
PS C:\> $cscfgFile = "<Path to cscfg configuration file>"
PS C:\>  = Get-Content $cscfgFile | Out-String

# Create cloud service
PS C:\> $cloudService = New-AzCloudService                                              `
                          -Name ContosoCS                                               `
                          -ResourceGroupName ContosOrg                                  `
                          -Location EastUS                                              `
                          -PackageUrl "https://xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"    `
                          -Configuration $cscfgContent                                  `
                          -UpgradeMode 'Auto'                                           `
                          -RoleProfile $roleProfile                                     `
                          -NetworkProfile $networkProfile                               `
                          -OSProfile $osProfile
.Example
# Create role profile object
PS C:\> $role1 = New-AzCloudServiceRoleProfilePropertiesObject-Name 'ContosoFrontend' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2
PS C:\> $role2 = New-AzCloudServiceRoleProfilePropertiesObject-Name 'ContosoBackend' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2
PS C:\> $roleProfile = @{role = @($role1, $role2)}

# Create network profile object
PS C:\> $publicIp = Get-AzPublicIpAddress -ResourceGroupName ContosOrg -Name ContosIp
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIp.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig
PS C:\> $networkProfile = @{loadBalancerConfiguration = $loadBalancerConfig}

# Create RDP extension object
PS C:\> $credential = Get-Credential
PS C:\> $expiration = (Get-Date).AddYears(1)
PS C:\> $rdpExtension = New-AzCloudServiceRemoteDesktopExtensionObject -Name 'RDPExtension' -Credential $credential -Expiration $expiration -TypeHandlerVersion '1.2.1'

# Create Geneva extension object
PS C:\> $genevaExtension = New-AzCloudServiceExtensionObject -Name GenevaExtension -Publisher Microsoft.Azure.Geneva -Type GenevaMonitoringPaaS -TypeHandlerVersion "2.14.0.2"
PS C:\> $extensionProfile = @{extension = @($rdpExtension, $genevaExtension)}

# Add tags
PS C:\> $tag=@{"Owner" = "Contoso"}

# Read Configuration File
PS C:\> $cscfgFile = "<Path to cscfg configuration file>"
PS C:\> $cscfgContent = Get-Content $cscfgFile | Out-String

# Create cloud service
PS C:\> $cloudService = New-AzCloudService                                              `
                          -Name ContosoCS                                               `
                          -ResourceGroupName ContosOrg                                  `
                          -Location EastUS                                              `
                          -PackageUrl "https://xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"    `
                          -Configuration $cscfgContent                                  `
                          -UpgradeMode 'Auto'                                           `
                          -RoleProfile $roleProfile                                     `
                          -NetworkProfile $networkProfile                               `
                          -ExtensionProfile $extensionProfile                           `
                          -Tag $tag
.Example
# Set up a storage account if you have not
PS C:\> $storageAccount = New-AzStorageAccount -ResourceGroupName ContosoOrg -Name ContosoStorAcc -Location "East US" -SkuName "Standard_RAGRS" -Kind "StorageV2"

# Create cloud service
PS C:\> $cloudService = New-AzCloudService                                              `
                          -Name ContosoCS                                               `
                          -ResourceGroupName ContosOrg                                  `
                          -Location EastUS                                              `
                          -ConfigurationFile C:\files\CS.cscfg                          `
                          -DefinitionFile C:\files\CS.csdef                             `
                          -PackageFile C:\CS.cspkg                                      `
                          -StorageAccount ContosoStorAcc                                `
                          -KeyVaultName ContosoKV

.Example
# getting Package URL
PS C:\> $tokenStartTime = Get-Date 
PS C:\> $tokenEndTime = $tokenStartTime.AddYears(1) 
PS C:\> $storAcc = Get-AzStorageAccount -ResourceGroupName ContosoOrg -Name ContosoStorAcc
PS C:\> $csPkgBlob = Get-AzStorageBlob -Container Contoso-Container -Blob ContosoBlob.cspkg -Context $storAcc.Context
PS C:\> $csPkgToken = New-AzStorageBlobSASToken -Container Contoso-Container -Blob ContosoBlob.cspkg -Permission rwd -StartTime $tokenStartTime -ExpiryTime $tokenEndTime -Context $storAcc.Context
PS C:\> $cspkgUrl = $csPkgBlob.ICloudBlob.Uri.AbsoluteUri + $csPkgToken 

# Create cloud service
PS C:\> $cloudService = New-AzCloudService                                              `
                          -Name ContosoCS                                               `
                          -ResourceGroupName ContosOrg                                  `
                          -Location EastUS                                              `
                          -ConfigurationFile C:\files\CS.cscfg                          `
                          -DefinitionFile C:\files\CS.csdef                             `
                          -packageUrl $cspkgUrl                                         `


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

EXTENSIONPROFILE <ICloudServiceExtensionProfile>: Describes a cloud service extension profile.
  [Extension <IExtension[]>]: List of extensions for the cloud service.
    [AutoUpgradeMinorVersion <Boolean?>]: Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
    [ForceUpdateTag <String>]: Tag to force apply the provided public and protected settings.         Changing the tag value allows for re-running the extension without changing any of the public or protected settings.         If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.         If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and         it is up to handler implementation whether to re-run it or not
    [Name <String>]: The name of the extension.
    [ProtectedSetting <String>]: Protected settings for the extension which are encrypted before sent to the role instance.
    [ProtectedSettingFromKeyVaultSecretUrl <String>]: 
    [Publisher <String>]: The name of the extension handler publisher.
    [RolesAppliedTo <String[]>]: Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.
    [Setting <String>]: Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension (like RDP), this is the XML setting for the extension.
    [SourceVaultId <String>]: Resource Id
    [Type <String>]: Specifies the type of the extension.
    [TypeHandlerVersion <String>]: Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version is selected. If a version is specified, an auto-upgrade is performed on the role instance.

NETWORKPROFILE <ICloudServiceNetworkProfile>: Network Profile for the cloud service.
  [LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]: List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to a Public Load Balancer and an Internal Load Balancer.
    FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]>: Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer configuration must have exactly one frontend IP configuration.
      Name <String>: The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
      [PrivateIPAddress <String>]: The virtual network private IP address of the IP configuration.
      [PublicIPAddressId <String>]: Resource Id
      [SubnetId <String>]: Resource Id
    Name <String>: The name of the Load balancer
    [Id <String>]: Resource Id
  [SwappableCloudService <ISubResource>]: The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap. This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise an error will be thrown.
    [Id <String>]: Resource Id

OSPROFILE <ICloudServiceOSProfile>: Describes the OS profile for the cloud service.
  [Secret <ICloudServiceVaultSecretGroup[]>]: Specifies set of certificates that should be installed onto the role instances.
    [SourceVaultId <String>]: Resource Id
    [VaultCertificate <ICloudServiceVaultCertificate[]>]: The list of key vault references in SourceVault which contain certificates.
      [CertificateUrl <String>]: This is the URL of a certificate that has been uploaded to Key Vault as a secret.

ROLEPROFILE <ICloudServiceRoleProfile>: Describes the role profile for the cloud service.
  [Role <ICloudServiceRoleProfileProperties[]>]: List of roles for the cloud service.
    [Name <String>]: Resource name.
    [SkuCapacity <Int64?>]: Specifies the number of role instances in the cloud service.
    [SkuName <String>]: The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.
    [SkuTier <String>]: Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudservice
#>
function New-AzCloudService {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('CloudServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Resource location.
    ${Location},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override the role instance count and vm size specified in the .cscfg and .csdef respectively.The default value is `false`.
    ${AllowModelOverride},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Specifies the XML service configuration (.cscfg) for the cloud service.
    ${Configuration},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Specifies a URL that refers to the location of the service configuration in the Blob service.
    # The service package URL can be Shared Access Signature (SAS) URI from any storage account.This is a write-only property and is not returned in GET calls.
    ${ConfigurationUrl},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile]
    # Describes a cloud service extension profile.
    # To construct, see NOTES section for EXTENSIONPROFILE properties and create a hash table.
    ${ExtensionProfile},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile]
    # Network Profile for the cloud service.
    # To construct, see NOTES section for NETWORKPROFILE properties and create a hash table.
    ${NetworkProfile},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile]
    # Describes the OS profile for the cloud service.
    # To construct, see NOTES section for OSPROFILE properties and create a hash table.
    ${OSProfile},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Specifies a URL that refers to the location of the service package in the Blob service.
    # The service package URL can be Shared Access Signature (SAS) URI from any storage account.This is a write-only property and is not returned in GET calls.
    ${PackageUrl},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile]
    # Describes the role profile for the cloud service.
    # To construct, see NOTES section for ROLEPROFILE properties and create a hash table.
    ${RoleProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # (Optional) Indicates whether to start the cloud service immediately after it is created.
    # The default value is `true`.If false, the service model is still deployed, but the code is not run immediately.
    # Instead, the service is PoweredOff until you call Start, at which time the service will be started.
    # A deployed service still incurs charges, even if it is poweredoff.
    ${StartCloudService},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode]
    # Update mode for the cloud service.
    # Role instances are allocated to update domains when the service is deployed.
    # Updates can be initiated manually in each update domain or initiated automatically in all update domains.Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />If not specified, the default value is Auto.
    # If set to Manual, PUT UpdateDomain must be called to apply the update.
    # If set to Auto, the update is automatically applied to each update domain in sequence.
    ${UpgradeMode},

    [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory)]
    [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Specifies the XML service configuration (.cscfg) for the cloud service.
    ${ConfigurationFile},

    [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory)]
    [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Path to .csdef file.
    ${DefinitionFile},

    [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Path to .cspkg file.
    # It will be uploaded to a blob
    ${PackageFile},

    [Parameter(ParameterSetName='quickCreateParameterSetWithStorage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of the storage account that will store the Package file.
    ${StorageAccount},

    [Parameter(ParameterSetName='quickCreateParameterSetWithStorage')]
    [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of Dns to be used for the CloudService resource.
    ${DnsName},

    [Parameter(ParameterSetName='quickCreateParameterSetWithStorage')]
    [Parameter(ParameterSetName='quickCreateParameterSetWithoutStorage')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of the KeyVault to be used for the CloudService resource.
    ${KeyVaultName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(ParameterSetName='CreateExpanded', DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(ParameterSetName='CreateExpanded', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(ParameterSetName='CreateExpanded', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(ParameterSetName='CreateExpanded', DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(ParameterSetName='CreateExpanded', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(ParameterSetName='CreateExpanded', DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
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
            CreateExpanded = 'Az.CloudService.private\New-AzCloudService_CreateExpanded';
            quickCreateParameterSetWithStorage = 'Az.CloudService.custom\New-AzCloudService';
            quickCreateParameterSetWithoutStorage = 'Az.CloudService.custom\New-AzCloudService';
        }
        if (('CreateExpanded', 'quickCreateParameterSetWithStorage', 'quickCreateParameterSetWithoutStorage') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Deletes role instances in a cloud service.
.Description
Deletes role instances in a cloud service.
.Example
PS C:\> Remove-AzCloudServiceInstance -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance "ContosoFrontEnd_IN_0"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/remove-azcloudserviceroleinstance
#>
function Remove-AzCloudServiceRoleInstance {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='DeleteExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='DeleteExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${CloudServiceName},

    [Parameter(ParameterSetName='DeleteExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='DeleteExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory)]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # List of cloud service role instance names.
    # Value of '*' will signify all role instances of the cloud service.
    ${RoleInstance},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            DeleteExpanded = 'Az.CloudService.private\Remove-AzCloudServiceRoleInstance_DeleteExpanded';
            DeleteViaIdentityExpanded = 'Az.CloudService.private\Remove-AzCloudServiceRoleInstance_DeleteViaIdentityExpanded';
        }
        if (('DeleteExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Deletes a cloud service.
.Description
Deletes a cloud service.
.Example
PS C:\> Remove-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/remove-azcloudservice
#>
function Remove-AzCloudService {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Alias('CloudServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${Name},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Delete = 'Az.CloudService.private\Remove-AzCloudService_Delete';
            DeleteViaIdentity = 'Az.CloudService.private\Remove-AzCloudService_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
The Reboot Role Instance asynchronous operation requests a reboot of a role instance in the cloud service.
.Description
The Reboot Role Instance asynchronous operation requests a reboot of a role instance in the cloud service.
.Example
PS C:\> Restart-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstanceName "ContosoFrontEnd_IN_0"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/restart-azcloudserviceroleinstance
#>
function Restart-AzCloudServiceRoleInstance {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Restart', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Restart', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${CloudServiceName},

    [Parameter(ParameterSetName='Restart', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # .
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Restart', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the role instance.
    ${RoleInstanceName},

    [Parameter(ParameterSetName='Restart')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RestartViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Restart = 'Az.CloudService.private\Restart-AzCloudServiceRoleInstance_Restart';
            RestartViaIdentity = 'Az.CloudService.private\Restart-AzCloudServiceRoleInstance_RestartViaIdentity';
        }
        if (('Restart') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Restarts one or more role instances in a cloud service.
.Description
Restarts one or more role instances in a cloud service.
.Example
PS C:\> $roleInstances = @("ContosoFrontEnd_IN_0", "ContosoBackEnd_IN_1")
PS C:\> Restart-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance $roleInstances
.Example
PS C:\> Restart-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS" -RoleInstance "*"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/restart-azcloudservice
#>
function Restart-AzCloudService {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='RestartExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='RestartExpanded', Mandatory)]
    [Alias('CloudServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${Name},

    [Parameter(ParameterSetName='RestartExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='RestartExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RestartViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory)]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # List of cloud service role instance names.
    # Value of '*' will signify all role instances of the cloud service.
    ${RoleInstance},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            RestartExpanded = 'Az.CloudService.private\Restart-AzCloudService_RestartExpanded';
            RestartViaIdentityExpanded = 'Az.CloudService.private\Restart-AzCloudService_RestartViaIdentityExpanded';
        }
        if (('RestartExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Updates the role instances in the specified update domain.
.Description
Updates the role instances in the specified update domain.
.Example
PS C:\> Set-AzCloudServiceUpdateDomain -CloudServiceName "ContosoCS" -ResourceGroupName "ContosOrg" -UpdateDomain 0

.Outputs
System.Boolean
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/set-azcloudserviceupdatedomain
#>
function Set-AzCloudServiceUpdateDomain {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='WalkExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${CloudServiceName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.Int32]
    # Specifies an integer value that identifies the update domain.
    # Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
    ${UpdateDomain},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            WalkExpanded = 'Az.CloudService.private\Set-AzCloudServiceUpdateDomain_WalkExpanded';
        }
        if (('WalkExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Starts the cloud service.
.Description
Starts the cloud service.
.Example
PS C:\> Start-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/start-azcloudservice
#>
function Start-AzCloudService {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Start', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Start', Mandatory)]
    [Alias('CloudServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${Name},

    [Parameter(ParameterSetName='Start', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Start')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='StartViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Start = 'Az.CloudService.private\Start-AzCloudService_Start';
            StartViaIdentity = 'Az.CloudService.private\Start-AzCloudService_StartViaIdentity';
        }
        if (('Start') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Power off the cloud service.
Note that resources are still attached and you are getting charged for the resources.
.Description
Power off the cloud service.
Note that resources are still attached and you are getting charged for the resources.
.Example
PS C:\> Stop-AzCloudService -ResourceGroupName "ContosOrg" -CloudServiceName "ContosoCS"

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/stop-azcloudservice
#>
function Stop-AzCloudService {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='PowerOff', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='PowerOff', Mandatory)]
    [Alias('CloudServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the cloud service.
    ${Name},

    [Parameter(ParameterSetName='PowerOff', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='PowerOff')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='PowerOffViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            PowerOff = 'Az.CloudService.private\Stop-AzCloudService_PowerOff';
            PowerOffViaIdentity = 'Az.CloudService.private\Stop-AzCloudService_PowerOffViaIdentity';
        }
        if (('PowerOff') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create or update a cloud service.
Please note some properties can be set only during cloud service creation.
.Description
Create or update a cloud service.
Please note some properties can be set only during cloud service creation.
.Example
# Create RDP extension object
PS C:\> $rdpExtension = New-AzCloudServiceRemoteDesktopExtensionObject -Name "RDPExtension" -Credential $credential -Expiration $expiration -TypeHandlerVersion "1.2.1"
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"
# Add RDP extension to existing cloud service extension object
PS C:\> $cloudService.ExtensionProfile.Extension = $cloudService.ExtensionProfile.Extension + $rdpExtension
# Update cloud service
PS C:\> $cloudService | Update-AzCloudService
.Example
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"
# Set extension to empty list
PS C:\> $cloudService.ExtensionProfile.Extension = @()
# Update cloud service
PS C:\> $cloudService | Update-AzCloudService
.Example
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"
# Remove extension by name RDPExtension
PS C:\> $cloudService.ExtensionProfile.Extension = $cloudService.ExtensionProfile.Extension | Where-Object { $_.Name -ne "RDPExtension" }
# Update cloud service
PS C:\> $cloudService | Update-AzCloudService
.Example
# Get existing cloud service
PS C:\> $cloudService = Get-AzCloudService -ResourceGroup "ContosOrg" -CloudServiceName "ContosoCS"

# Scale-out all role instance count by 1
PS C:\> $cloudService.RoleProfile.Role | ForEach-Object {$_.SkuCapacity += 1}

# Scale-in ContosoFrontend role instance count by 1
PS C:\> $role = $cloudService.RoleProfile.Role | Where-Object {$_.Name -eq "ContosoFrontend"}
PS C:\> $role.SkuCapacity -= 1

# Update cloud service configuration as per the new role instance count
PS C:\> $cloudService.Configuration = $configuration

# Update cloud service
PS C:\> $cloudService | Update-AzCloudService

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <ICloudServiceIdentity>: Identity Parameter
  [CloudServiceName <String>]: 
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the location that the OS version pertains to.
  [OSFamilyName <String>]: Name of the OS family.
  [OSVersionName <String>]: Name of the OS version.
  [ResourceGroupName <String>]: 
  [RoleInstanceName <String>]: Name of the role instance.
  [RoleName <String>]: Name of the role.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [UpdateDomain <Int32?>]: Specifies an integer value that identifies the update domain. Update domains are identified with a zero-based index: the first update domain has an ID of 0, the second has an ID of 1, and so on.

PARAMETER <ICloudService>: Describes the cloud service.
  Location <String>: Resource location.
  [AllowModelOverride <Boolean?>]: (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override the role instance count and vm size specified in the .cscfg and .csdef respectively.         The default value is `false`.
  [Configuration <String>]: Specifies the XML service configuration (.cscfg) for the cloud service.
  [ConfigurationUrl <String>]: Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL  can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [ExtensionProfile <ICloudServiceExtensionProfile>]: Describes a cloud service extension profile.
    [Extension <IExtension[]>]: List of extensions for the cloud service.
      [AutoUpgradeMinorVersion <Boolean?>]: Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
      [ForceUpdateTag <String>]: Tag to force apply the provided public and protected settings.         Changing the tag value allows for re-running the extension without changing any of the public or protected settings.         If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.         If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and         it is up to handler implementation whether to re-run it or not
      [Name <String>]: The name of the extension.
      [ProtectedSetting <String>]: Protected settings for the extension which are encrypted before sent to the role instance.
      [ProtectedSettingFromKeyVaultSecretUrl <String>]: 
      [Publisher <String>]: The name of the extension handler publisher.
      [RolesAppliedTo <String[]>]: Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.
      [Setting <String>]: Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension (like RDP), this is the XML setting for the extension.
      [SourceVaultId <String>]: Resource Id
      [Type <String>]: Specifies the type of the extension.
      [TypeHandlerVersion <String>]: Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version is selected. If a version is specified, an auto-upgrade is performed on the role instance.
  [NetworkProfile <ICloudServiceNetworkProfile>]: Network Profile for the cloud service.
    [LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]: List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to a Public Load Balancer and an Internal Load Balancer.
      FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]>: Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer configuration must have exactly one frontend IP configuration.
        Name <String>: The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
        [PrivateIPAddress <String>]: The virtual network private IP address of the IP configuration.
        [PublicIPAddressId <String>]: Resource Id
        [SubnetId <String>]: Resource Id
      Name <String>: The name of the Load balancer
      [Id <String>]: Resource Id
    [SwappableCloudService <ISubResource>]: The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap. This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise an error will be thrown.
      [Id <String>]: Resource Id
  [OSProfile <ICloudServiceOSProfile>]: Describes the OS profile for the cloud service.
    [Secret <ICloudServiceVaultSecretGroup[]>]: Specifies set of certificates that should be installed onto the role instances.
      [SourceVaultId <String>]: Resource Id
      [VaultCertificate <ICloudServiceVaultCertificate[]>]: The list of key vault references in SourceVault which contain certificates.
        [CertificateUrl <String>]: This is the URL of a certificate that has been uploaded to Key Vault as a secret.
  [PackageUrl <String>]: Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [RoleProfile <ICloudServiceRoleProfile>]: Describes the role profile for the cloud service.
    [Role <ICloudServiceRoleProfileProperties[]>]: List of roles for the cloud service.
      [Name <String>]: Resource name.
      [SkuCapacity <Int64?>]: Specifies the number of role instances in the cloud service.
      [SkuName <String>]: The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.
      [SkuTier <String>]: Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
  [StartCloudService <Boolean?>]: (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.         If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is poweredoff.
  [Tag <ICloudServiceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [UpgradeMode <CloudServiceUpgradeMode?>]: Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates can be initiated manually in each update domain or initiated automatically in all update domains.         Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />         If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If set to Auto, the update is automatically applied to each update domain in sequence.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/update-azcloudservice
#>
function Update-AzCloudService {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService])]
[CmdletBinding(DefaultParameterSetName='CreateViaIdentity', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ICloudServiceIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService]
    # Describes the cloud service.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CreateViaIdentity = 'Az.CloudService.private\Update-AzCloudService_CreateViaIdentity';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Get the network interfaces of a cloud service.
.Description
Get the network interfaces of a cloud service.
.Example
PS C:\> Get-AzCloudServiceNetworkInterfaces -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca

.Example
PS C:\> $cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
PS C:\> Get-AzCloudServiceNetworkInterfaces -CloudService $cs

.Example
PS C:\> Get-AzCloudServiceNetworkInterfaces -CloudService $cs -RoleInstanceName WebRole1_IN_0


.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CLOUDSERVICE <CloudService>: CloudService instance.
  Location <String>: Resource location.
  [AllowModelOverride <Boolean?>]: (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override the role instance count and vm size specified in the .cscfg and .csdef respectively.         The default value is `false`.
  [Configuration <String>]: Specifies the XML service configuration (.cscfg) for the cloud service.
  [ConfigurationUrl <String>]: Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL  can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [ExtensionProfile <ICloudServiceExtensionProfile>]: Describes a cloud service extension profile.
    [Extension <IExtension[]>]: List of extensions for the cloud service.
      [AutoUpgradeMinorVersion <Boolean?>]: Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
      [ForceUpdateTag <String>]: Tag to force apply the provided public and protected settings.         Changing the tag value allows for re-running the extension without changing any of the public or protected settings.         If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.         If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and         it is up to handler implementation whether to re-run it or not
      [Name <String>]: The name of the extension.
      [ProtectedSetting <String>]: Protected settings for the extension which are encrypted before sent to the role instance.
      [ProtectedSettingFromKeyVaultSecretUrl <String>]: 
      [Publisher <String>]: The name of the extension handler publisher.
      [RolesAppliedTo <String[]>]: Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.
      [Setting <String>]: Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension (like RDP), this is the XML setting for the extension.
      [SourceVaultId <String>]: Resource Id
      [Type <String>]: Specifies the type of the extension.
      [TypeHandlerVersion <String>]: Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version is selected. If a version is specified, an auto-upgrade is performed on the role instance.
  [NetworkProfile <ICloudServiceNetworkProfile>]: Network Profile for the cloud service.
    [LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]: List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to a Public Load Balancer and an Internal Load Balancer.
      FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]>: Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer configuration must have exactly one frontend IP configuration.
        Name <String>: The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
        [PrivateIPAddress <String>]: The virtual network private IP address of the IP configuration.
        [PublicIPAddressId <String>]: Resource Id
        [SubnetId <String>]: Resource Id
      Name <String>: The name of the Load balancer
      [Id <String>]: Resource Id
    [SwappableCloudService <ISubResource>]: The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap. This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise an error will be thrown.
      [Id <String>]: Resource Id
  [OSProfile <ICloudServiceOSProfile>]: Describes the OS profile for the cloud service.
    [Secret <ICloudServiceVaultSecretGroup[]>]: Specifies set of certificates that should be installed onto the role instances.
      [SourceVaultId <String>]: Resource Id
      [VaultCertificate <ICloudServiceVaultCertificate[]>]: The list of key vault references in SourceVault which contain certificates.
        [CertificateUrl <String>]: This is the URL of a certificate that has been uploaded to Key Vault as a secret.
  [PackageUrl <String>]: Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [RoleProfile <ICloudServiceRoleProfile>]: Describes the role profile for the cloud service.
    [Role <ICloudServiceRoleProfileProperties[]>]: List of roles for the cloud service.
      [Name <String>]: Resource name.
      [SkuCapacity <Int64?>]: Specifies the number of role instances in the cloud service.
      [SkuName <String>]: The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.
      [SkuTier <String>]: Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
  [StartCloudService <Boolean?>]: (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.         If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is poweredoff.
  [Tag <ICloudServiceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [UpgradeMode <CloudServiceUpgradeMode?>]: Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates can be initiated manually in each update domain or initiated automatically in all update domains.         Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />         If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If set to Auto, the update is automatically applied to each update domain in sequence.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudservicenetworkinterfaces
#>
function Get-AzCloudServiceNetworkInterfaces {
[CmdletBinding(DefaultParameterSetName='CloudServiceName', PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CloudService', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudService]
    # CloudService instance.
    # To construct, see NOTES section for CLOUDSERVICE properties and create a hash table.
    ${CloudService},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # RoleInstanceName.
    ${RoleInstanceName},

    [Parameter(ParameterSetName='CloudServiceName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # ResourceGroupName.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='CloudServiceName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # CloudServiceName.
    ${CloudServiceName}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CloudService = 'Az.CloudService.custom\Get-AzCloudServiceNetworkInterfaces';
            CloudServiceName = 'Az.CloudService.custom\Get-AzCloudServiceNetworkInterfaces';
        }
        if (('CloudService', 'CloudServiceName') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Get the public IP address of a cloud service.
.Description
Get the public IP address of a cloud service.
.Example
PS C:\> Get-AzCloudServicePublicIPAddress -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca

.Example
PS C:\> $cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
PS C:\> Get-AzCloudServicePublicIPAddress -CloudService $cs


.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CLOUDSERVICE <CloudService>: CloudService instance.
  Location <String>: Resource location.
  [AllowModelOverride <Boolean?>]: (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override the role instance count and vm size specified in the .cscfg and .csdef respectively.         The default value is `false`.
  [Configuration <String>]: Specifies the XML service configuration (.cscfg) for the cloud service.
  [ConfigurationUrl <String>]: Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL  can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [ExtensionProfile <ICloudServiceExtensionProfile>]: Describes a cloud service extension profile.
    [Extension <IExtension[]>]: List of extensions for the cloud service.
      [AutoUpgradeMinorVersion <Boolean?>]: Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
      [ForceUpdateTag <String>]: Tag to force apply the provided public and protected settings.         Changing the tag value allows for re-running the extension without changing any of the public or protected settings.         If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.         If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and         it is up to handler implementation whether to re-run it or not
      [Name <String>]: The name of the extension.
      [ProtectedSetting <String>]: Protected settings for the extension which are encrypted before sent to the role instance.
      [ProtectedSettingFromKeyVaultSecretUrl <String>]: 
      [Publisher <String>]: The name of the extension handler publisher.
      [RolesAppliedTo <String[]>]: Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.
      [Setting <String>]: Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension (like RDP), this is the XML setting for the extension.
      [SourceVaultId <String>]: Resource Id
      [Type <String>]: Specifies the type of the extension.
      [TypeHandlerVersion <String>]: Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version is selected. If a version is specified, an auto-upgrade is performed on the role instance.
  [NetworkProfile <ICloudServiceNetworkProfile>]: Network Profile for the cloud service.
    [LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]: List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to a Public Load Balancer and an Internal Load Balancer.
      FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]>: Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer configuration must have exactly one frontend IP configuration.
        Name <String>: The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
        [PrivateIPAddress <String>]: The virtual network private IP address of the IP configuration.
        [PublicIPAddressId <String>]: Resource Id
        [SubnetId <String>]: Resource Id
      Name <String>: The name of the Load balancer
      [Id <String>]: Resource Id
    [SwappableCloudService <ISubResource>]: The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap. This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise an error will be thrown.
      [Id <String>]: Resource Id
  [OSProfile <ICloudServiceOSProfile>]: Describes the OS profile for the cloud service.
    [Secret <ICloudServiceVaultSecretGroup[]>]: Specifies set of certificates that should be installed onto the role instances.
      [SourceVaultId <String>]: Resource Id
      [VaultCertificate <ICloudServiceVaultCertificate[]>]: The list of key vault references in SourceVault which contain certificates.
        [CertificateUrl <String>]: This is the URL of a certificate that has been uploaded to Key Vault as a secret.
  [PackageUrl <String>]: Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [RoleProfile <ICloudServiceRoleProfile>]: Describes the role profile for the cloud service.
    [Role <ICloudServiceRoleProfileProperties[]>]: List of roles for the cloud service.
      [Name <String>]: Resource name.
      [SkuCapacity <Int64?>]: Specifies the number of role instances in the cloud service.
      [SkuName <String>]: The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.
      [SkuTier <String>]: Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
  [StartCloudService <Boolean?>]: (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.         If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is poweredoff.
  [Tag <ICloudServiceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [UpgradeMode <CloudServiceUpgradeMode?>]: Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates can be initiated manually in each update domain or initiated automatically in all update domains.         Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />         If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If set to Auto, the update is automatically applied to each update domain in sequence.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/get-azcloudservicepublicipaddress
#>
function Get-AzCloudServicePublicIPAddress {
[CmdletBinding(DefaultParameterSetName='CloudServiceName', PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CloudServiceName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # ResourceGroupName.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='CloudServiceName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # CloudServiceName.
    ${CloudServiceName},

    [Parameter(ParameterSetName='CloudService', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudService]
    # CloudService instance.
    # To construct, see NOTES section for CLOUDSERVICE properties and create a hash table.
    ${CloudService}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CloudServiceName = 'Az.CloudService.custom\Get-AzCloudServicePublicIPAddress';
            CloudService = 'Az.CloudService.custom\Get-AzCloudServicePublicIPAddress';
        }
        if (('CloudServiceName', 'CloudService') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create a in-memory object for Diagnostics Extension
.Description
Create a in-memory object for Diagnostics Extension
.Example
PS C:\> $storageAccountKey = Get-AzStorageAccountKey -ResourceGroupName "ContosOrg" -Name "ContosSA"
PS C:\> $configFile = "<WAD configuration file path>"
PS C:\> $extension = New-AzCloudServiceDiagnosticsExtension -Name "WADExtension" -ResourceGroupName "ContosOrg" -CloudServiceName "ContosCS" -StorageAccountName "ContosSA" -StorageAccountKey $storageAccountKey[0].Value -DiagnosticsConfigurationPath $configFile -TypeHandlerVersion "1.5" -AutoUpgradeMinorVersion $true

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.Extension
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudservicediagnosticsextension
#>
function New-AzCloudServiceDiagnosticsExtension {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.Extension])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=1)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription.
    ${Subscription},

    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of Diagnostics Extension.
    ${Name},

    [Parameter(Position=2, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Resource Group name of Cloud Service.
    ${ResourceGroupName},

    [Parameter(Position=3, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of Cloud Service.
    ${CloudServiceName},

    [Parameter(Position=4, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Specifies the configuration for Azure Diagnostics.
    # You can download the schema by using the following command: (Get-AzureServiceAvailableExtension -ExtensionName 'PaaSDiagnostics' -ProviderNamespace 'Microsoft.Azure.Diagnostics').PublicConfigurationSchema | Out-File -Encoding utf8 -FilePath 'WadConfig.xsd'
    ${DiagnosticsConfigurationPath},

    [Parameter(Position=5, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of the Storage Account.
    ${StorageAccountName},

    [Parameter(Position=6, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Storage Account Key.
    ${StorageAccountKey},

    [Parameter(Position=7)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Specifies the version of the extension.
    ${TypeHandlerVersion},

    [Parameter(Position=8)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # Roles applied to.
    ${RolesAppliedTo},

    [Parameter(Position=9)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Boolean]
    # Auto upgrade minor version.
    ${AutoUpgradeMinorVersion}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CloudService.custom\New-AzCloudServiceDiagnosticsExtension';
        }
        if (('__AllParameterSets') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('Subscription')) {
            $PSBoundParameters['Subscription'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create a in-memory object for Extension
.Description
Create a in-memory object for Extension
.Example
PS C:\> $extension = New-AzCloudServiceExtensionObject -Name "GenevaExtension" -Publisher "Microsoft.Azure.Geneva" -Type "GenevaMonitoringPaaS" -TypeHandlerVersion "2.14.0.2"

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.Extension
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudserviceextensionobject
#>
function New-AzCloudServiceExtensionObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.Extension])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Boolean]
    # Explicitly specify whether CRP can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
    ${AutoUpgradeMinorVersion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name.
    ${Name},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Protected settings for the extension which are encrypted before sent to the VM.
    ${ProtectedSetting},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Publisher.
    ${Publisher},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # RolesAppliedTo.
    ${RolesAppliedTo},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Public settings for the extension.
    ${Setting},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Type.
    ${Type},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # TypeHandlerVersion.
    ${TypeHandlerVersion}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CloudService.custom\New-AzCloudServiceExtensionObject';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create a in-memory object for LoadBalancerConfiguration
.Description
Create a in-memory object for LoadBalancerConfiguration
.Example
PS C:\> $publicIP = Get-AzPublicIpAddress -ResourceGroupName 'ContosoOrg' -Name 'ContosoPublicIP'
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIP.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerConfiguration
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

FRONTENDIPCONFIGURATION <ILoadBalancerFrontendIPConfiguration[]>: FrontendIPConfiguration.
  Name <String>: The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
  [PrivateIPAddress <String>]: The virtual network private IP address of the IP configuration.
  [PublicIPAddressId <String>]: Resource Id
  [SubnetId <String>]: Resource Id
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudserviceloadbalancerconfigurationobject
#>
function New-AzCloudServiceLoadBalancerConfigurationObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerConfiguration])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ILoadBalancerFrontendIPConfiguration[]]
    # FrontendIPConfiguration.
    # To construct, see NOTES section for FRONTENDIPCONFIGURATION properties and create a hash table.
    ${FrontendIPConfiguration},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of LoadBalancerConfiguration.
    ${Name}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CloudService.custom\New-AzCloudServiceLoadBalancerConfigurationObject';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create a in-memory object for LoadBalancerFrontendIPConfiguration
.Description
Create a in-memory object for LoadBalancerFrontendIPConfiguration
.Example
PS C:\> $publicIP = Get-AzPublicIpAddress -ResourceGroupName 'ContosoOrg' -Name 'ContosoPublicIP'
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIp.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig
.Example
# Create role profile object
PS C:\> $subnet = New-AzVirtualNetworkSubnetConfig -Name "WebTier" -AddressPrefix "10.0.0.0/24" -WarningAction SilentlyContinue 
PS C:\> $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -privateIPAddress '10.0.0.6' -subnetId $Subnet.Id
PS C:\> $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerFrontendIPConfiguration
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudserviceloadbalancerfrontendipconfigurationobject
#>
function New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.LoadBalancerFrontendIPConfiguration])]
[CmdletBinding(DefaultParameterSetName='DefaultParameterSet', PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of FrontendIpConfigration.
    ${Name},

    [Parameter(ParameterSetName='DefaultParameterSet')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Resource Id.
    ${PublicIPAddressId},

    [Parameter(ParameterSetName='PrivateIP')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Private IP Address
    ${PrivateIPAddress},

    [Parameter(ParameterSetName='PrivateIP')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Subnet ID
    ${SubnetId}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            DefaultParameterSet = 'Az.CloudService.custom\New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject';
            PrivateIP = 'Az.CloudService.custom\New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create a in-memory object for Remote Desktop Extension
.Description
Create a in-memory object for Remote Desktop Extension
.Example
PS C:\> $credential = Get-Credential
PS C:\> $expiration = (Get-Date).AddYears(1)
PS C:\> $extension = New-AzCloudServiceRemoteDesktopExtensionObject -Name 'RDPExtension' -Credential $credential -Expiration $expiration -TypeHandlerVersion '1.2.1'

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.Extension
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudserviceremotedesktopextensionobject
#>
function New-AzCloudServiceRemoteDesktopExtensionObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.Extension])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Position=0, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of Remote Desktop Extension.
    ${Name},

    [Parameter(Position=1, Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Management.Automation.PSCredential]
    # Credential for Remote Desktop Extension.
    ${Credential},

    [Parameter(Position=2)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.DateTime]
    # Expiration for Remote Desktop Extension.
    ${Expiration},

    [Parameter(Position=3)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Remote Desktop Extension version.
    ${TypeHandlerVersion},

    [Parameter(Position=4)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # Roles applied to.
    ${RolesAppliedTo},

    [Parameter(Position=5)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Boolean]
    # Auto upgrade minor version.
    ${AutoUpgradeMinorVersion}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CloudService.custom\New-AzCloudServiceRemoteDesktopExtensionObject';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create a in-memory object for CloudServiceRoleProfileProperties
.Description
Create a in-memory object for CloudServiceRoleProfileProperties
.Example
$role = New-AzCloudServiceRoleProfilePropertiesObject -Name 'WebRole' -SkuName 'Standard_D1_v2' -SkuTier 'Standard' -SkuCapacity 2

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProfileProperties
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudserviceroleprofilepropertiesobject
#>
function New-AzCloudServiceRoleProfilePropertiesObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProfileProperties])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Name of role profile.
    ${Name},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Int64]
    # Specifies the number of role instances in the cloud service.
    ${SkuCapacity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # The sku name.
    ${SkuName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # SkuTier.
    ${SkuTier}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CloudService.custom\New-AzCloudServiceRoleProfilePropertiesObject';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Create a in-memory object for Vault Secret Group
.Description
Create a in-memory object for Secret Group
.Example
$keyVault = Get-AzKeyVault -VaultName 'ContosoKeyVault'
$certificate = Get-AzKeyVaultCertificate -VaultName 'ContosoKeyVault' -Name 'ContosoCert'
$secretGroup = New-AzCloudServiceVaultSecretGroupObject -Id $keyVault.ResourceId -CertificateUrl $certificate.SecretId

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceVaultSecretGroup
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/new-azcloudservicevaultsecretgroupobject
#>
function New-AzCloudServiceVaultSecretGroupObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceVaultSecretGroup])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String]
    # Key Vault Resource Id.
    ${Id},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.String[]]
    # This is the URL of a certificate that has been uploaded to Key Vault as a secret.
    ${CertificateUrl}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.CloudService.custom\New-AzCloudServiceVaultSecretGroupObject';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Swaps VIPs between two cloud service (extended support) load balancers.
.Description
Swaps VIPs between two cloud service (extended support) load balancers.
.Example
PS C:\> Switch-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca

.Example
PS C:\> $cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
PS C:\> Switch-AzCloudService -CloudService $cs


.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CLOUDSERVICE <CloudService>: 
  Location <String>: Resource location.
  [AllowModelOverride <Boolean?>]: (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override the role instance count and vm size specified in the .cscfg and .csdef respectively.         The default value is `false`.
  [Configuration <String>]: Specifies the XML service configuration (.cscfg) for the cloud service.
  [ConfigurationUrl <String>]: Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL  can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [ExtensionProfile <ICloudServiceExtensionProfile>]: Describes a cloud service extension profile.
    [Extension <IExtension[]>]: List of extensions for the cloud service.
      [AutoUpgradeMinorVersion <Boolean?>]: Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
      [ForceUpdateTag <String>]: Tag to force apply the provided public and protected settings.         Changing the tag value allows for re-running the extension without changing any of the public or protected settings.         If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.         If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and         it is up to handler implementation whether to re-run it or not
      [Name <String>]: The name of the extension.
      [ProtectedSetting <String>]: Protected settings for the extension which are encrypted before sent to the role instance.
      [ProtectedSettingFromKeyVaultSecretUrl <String>]: 
      [Publisher <String>]: The name of the extension handler publisher.
      [RolesAppliedTo <String[]>]: Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.
      [Setting <String>]: Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension (like RDP), this is the XML setting for the extension.
      [SourceVaultId <String>]: Resource Id
      [Type <String>]: Specifies the type of the extension.
      [TypeHandlerVersion <String>]: Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version is selected. If a version is specified, an auto-upgrade is performed on the role instance.
  [NetworkProfile <ICloudServiceNetworkProfile>]: Network Profile for the cloud service.
    [LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]: List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to a Public Load Balancer and an Internal Load Balancer.
      FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]>: Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer configuration must have exactly one frontend IP configuration.
        Name <String>: The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
        [PrivateIPAddress <String>]: The virtual network private IP address of the IP configuration.
        [PublicIPAddressId <String>]: Resource Id
        [SubnetId <String>]: Resource Id
      Name <String>: The name of the Load balancer
      [Id <String>]: Resource Id
    [SwappableCloudService <ISubResource>]: The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap. This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise an error will be thrown.
      [Id <String>]: Resource Id
  [OSProfile <ICloudServiceOSProfile>]: Describes the OS profile for the cloud service.
    [Secret <ICloudServiceVaultSecretGroup[]>]: Specifies set of certificates that should be installed onto the role instances.
      [SourceVaultId <String>]: Resource Id
      [VaultCertificate <ICloudServiceVaultCertificate[]>]: The list of key vault references in SourceVault which contain certificates.
        [CertificateUrl <String>]: This is the URL of a certificate that has been uploaded to Key Vault as a secret.
  [PackageUrl <String>]: Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  [RoleProfile <ICloudServiceRoleProfile>]: Describes the role profile for the cloud service.
    [Role <ICloudServiceRoleProfileProperties[]>]: List of roles for the cloud service.
      [Name <String>]: Resource name.
      [SkuCapacity <Int64?>]: Specifies the number of role instances in the cloud service.
      [SkuName <String>]: The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.
      [SkuTier <String>]: Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
  [StartCloudService <Boolean?>]: (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.         If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is poweredoff.
  [Tag <ICloudServiceTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
  [UpgradeMode <CloudServiceUpgradeMode?>]: Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates can be initiated manually in each update domain or initiated automatically in all update domains.         Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />         If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If set to Auto, the update is automatically applied to each update domain in sequence.
.Link
https://docs.microsoft.com/powershell/module/az.cloudservice/Switch-AzCloudService
#>
function Switch-AzCloudService {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='CloudServiceName', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='CloudServiceName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(ParameterSetName='CloudServiceName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [System.String]
    ${CloudServiceName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CloudService', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudService]
    # To construct, see NOTES section for CLOUDSERVICE properties and create a hash table.
    ${CloudService},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    ${Async},

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
    ${Break}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            CloudServiceName = 'Az.CloudService.custom\Switch-AzCloudService';
            CloudService = 'Az.CloudService.custom\Switch-AzCloudService';
        }
        if (('CloudServiceName', 'CloudService') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
