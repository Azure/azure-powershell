
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
Gets properties of a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Description
Gets properties of a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Example
PS C:\> Get-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01

Name                 Type
----                 ----
ps-sapmonitorins-t01 Microsoft.HanaOnAzure/sapMonitors/providerInstances
ps-sapmonitorins-t02 Microsoft.HanaOnAzure/sapMonitors/providerInstances
.Example
PS C:\> Get-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t02

Name                 Type
----                 ----
ps-sapmonitorins-t02 Microsoft.HanaOnAzure/sapMonitors/providerInstances
.Example
PS C:\> $sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t02
PS C:\> Get-AzSapMonitorProviderInstance -InputObject $sapIns

Name                 Type
----                 ----
ps-sapmonitorins-t02 Microsoft.HanaOnAzure/sapMonitors/providerInstances
.Example
PS C:\> @{Id = "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.HanaOnAzure/sapMonitors/ps-spamonitor-t01/providerInstances/ps-sapmonitorins-t02"} | Get-AzSapMonitorProviderInstance

Name                 Type
----                 ----
ps-sapmonitorins-t02 Microsoft.HanaOnAzure/sapMonitors/providerInstances

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstance
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IHanaOnAzureIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [Location <String>]: The location of the deleted vault.
  [OperationKind <AccessPolicyUpdateKind?>]: Name of the operation
  [ProviderInstanceName <String>]: Name of the provider instance.
  [ResourceGroupName <String>]: Name of the resource group.
  [ResourceName <String>]: The name of the identity resource.
  [SapMonitorName <String>]: Name of the SAP monitor resource.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SubscriptionId <String>]: Subscription ID which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [VaultName <String>]: Name of the vault
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hanaonazure/get-azsapmonitorproviderinstance
#>
function Get-AzSapMonitorProviderInstance {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstance])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('ProviderInstanceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the provider instance.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the SAP monitor resource.
    ${SapMonitorName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription ID which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
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
            Get = 'Az.HanaOnAzure.private\Get-AzSapMonitorProviderInstance_Get';
            GetViaIdentity = 'Az.HanaOnAzure.private\Get-AzSapMonitorProviderInstance_GetViaIdentity';
            List = 'Az.HanaOnAzure.private\Get-AzSapMonitorProviderInstance_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Gets properties of a SAP monitor for the specified subscription, resource group, and resource name.
.Description
Gets properties of a SAP monitor for the specified subscription, resource group, and resource name.
.Example
PS C:\> Get-AzSapMonitor

Location Name              Type
-------- ----              ----
westus2  ps-sapmonitor-t01 Microsoft.HanaOnAzure/sapMonitors
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
.Example
PS C:\> Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01

Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
.Example
PS C:\> $sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01
PS C:\> Get-AzSapMonitor -InputObject $sap

Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
.Example
PS C:\> @{Id='/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.HanaOnAzure/sapMonitors/ps-spamonitor-t01'} | Get-AzSapMonitor

Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IHanaOnAzureIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [Location <String>]: The location of the deleted vault.
  [OperationKind <AccessPolicyUpdateKind?>]: Name of the operation
  [ProviderInstanceName <String>]: Name of the provider instance.
  [ResourceGroupName <String>]: Name of the resource group.
  [ResourceName <String>]: The name of the identity resource.
  [SapMonitorName <String>]: Name of the SAP monitor resource.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SubscriptionId <String>]: Subscription ID which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [VaultName <String>]: Name of the vault
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hanaonazure/get-azsapmonitor
#>
function Get-AzSapMonitor {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('SapMonitorName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the SAP monitor resource.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Subscription ID which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
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
            Get = 'Az.HanaOnAzure.private\Get-AzSapMonitor_Get';
            GetViaIdentity = 'Az.HanaOnAzure.private\Get-AzSapMonitor_GetViaIdentity';
            List = 'Az.HanaOnAzure.private\Get-AzSapMonitor_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Creates a SAP monitor for the specified subscription, resource group, and resource name.
.Description
Creates a SAP monitor for the specified subscription, resource group, and resource name.
.Example
PS C:\> $Workspace = New-AzOperationalInsightsWorkspace -ResourceGroupName nancyc-hn1 -Name sapmonitor-test  -Location westus2 -Sku "Standard"
PS C:\> $WorkspaceKey = Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName nancyc-hn1 -Name sapmonitor-test
PS C:\> New-AzSapMonitor -Name ps-sapmonitor-t01 -ResourceGroupName nancyc-hn1 -Location westus2 -EnableCustomerAnalytic -MonitorSubnet "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/nancyc-hn1/providers/Microsoft.Network/virtualNetworks/vnet-sap/subnets/subnet-admin" -LogAnalyticsWorkspaceSharedKey $WorkspaceKey.PrimarySharedKey -LogAnalyticsWorkspaceId $Workspace.CustomerId -LogAnalyticsWorkspaceResourceId $Workspace.ResourceId

Location Name              Type
-------- ----              ----
westus2  ps-sapmonitor-t01 Microsoft.HanaOnAzure/sapMonitors

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hanaonazure/new-azsapmonitor
#>
function New-AzSapMonitor {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('SapMonitorName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the SAP monitor resource.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription ID which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # The value indicating whether to send analytics to Microsoft
    ${EnableCustomerAnalytic},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The workspace ID of the log analytics workspace to be used for monitoring
    ${LogAnalyticsWorkspaceId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The ARM ID of the Log Analytics Workspace that is used for monitoring
    ${LogAnalyticsWorkspaceResourceId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The shared key of the log analytics workspace that is used for monitoring
    ${LogAnalyticsWorkspaceSharedKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The subnet which the SAP monitor will be deployed in.
    # It should be the same subnet of HANA database.
    ${MonitorSubnetResourceId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
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
            CreateExpanded = 'Az.HanaOnAzure.private\New-AzSapMonitor_CreateExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Deletes a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Description
Deletes a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Example
PS C:\> Remove-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t02

.Example
PS C:\> $sapIns = Get-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName ps-spamonitor-t01 -Name ps-sapmonitorins-t01
PS C:\> Remove-AzSapMonitorProviderInstance -InputObject $sapIns


.Inputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IHanaOnAzureIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [Location <String>]: The location of the deleted vault.
  [OperationKind <AccessPolicyUpdateKind?>]: Name of the operation
  [ProviderInstanceName <String>]: Name of the provider instance.
  [ResourceGroupName <String>]: Name of the resource group.
  [ResourceName <String>]: The name of the identity resource.
  [SapMonitorName <String>]: Name of the SAP monitor resource.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SubscriptionId <String>]: Subscription ID which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [VaultName <String>]: Name of the vault
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hanaonazure/remove-azsapmonitorproviderinstance
#>
function Remove-AzSapMonitorProviderInstance {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Alias('ProviderInstanceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the provider instance.
    ${Name},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the SAP monitor resource.
    ${SapMonitorName},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription ID which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
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
            Delete = 'Az.HanaOnAzure.private\Remove-AzSapMonitorProviderInstance_Delete';
            DeleteViaIdentity = 'Az.HanaOnAzure.private\Remove-AzSapMonitorProviderInstance_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Deletes a SAP monitor with the specified subscription, resource group, and monitor name.
.Description
Deletes a SAP monitor with the specified subscription, resource group, and monitor name.
.Example
PS C:\> Remove-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t02

.Example
PS C:\> $sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t01
PS C:\> Remove-AzSapMonitor -InputObject $sap


.Inputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IHanaOnAzureIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [Location <String>]: The location of the deleted vault.
  [OperationKind <AccessPolicyUpdateKind?>]: Name of the operation
  [ProviderInstanceName <String>]: Name of the provider instance.
  [ResourceGroupName <String>]: Name of the resource group.
  [ResourceName <String>]: The name of the identity resource.
  [SapMonitorName <String>]: Name of the SAP monitor resource.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SubscriptionId <String>]: Subscription ID which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [VaultName <String>]: Name of the vault
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hanaonazure/remove-azsapmonitor
#>
function Remove-AzSapMonitor {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Alias('SapMonitorName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the SAP monitor resource.
    ${Name},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription ID which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
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
            Delete = 'Az.HanaOnAzure.private\Remove-AzSapMonitor_Delete';
            DeleteViaIdentity = 'Az.HanaOnAzure.private\Remove-AzSapMonitor_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Patches the Tags field of a SAP monitor for the specified subscription, resource group, and monitor name.
.Description
Patches the Tags field of a SAP monitor for the specified subscription, resource group, and monitor name.
.Example
PS C:\> Update-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-spamonitor-t01 -Tag @{'key'=1;'key2'=2; 'key3'=3}

Location Name              Type
-------- ----              ----
westus2  ps-spamonitor-t01 Microsoft.HanaOnAzure/sapMonitors
.Example
PS C:\> $sap = Get-AzSapMonitor -ResourceGroupName nancyc-hn1 -Name ps-sapmonitor-t01
PS C:\> Update-AzSapMonitor -InputObject $sap -Tag @{'key'=1;'key2'=2; 'key3'=3}

Location Name              Type
-------- ----              ----
westus2  ps-sapmonitor-t01 Microsoft.HanaOnAzure/sapMonitors

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IHanaOnAzureIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [Location <String>]: The location of the deleted vault.
  [OperationKind <AccessPolicyUpdateKind?>]: Name of the operation
  [ProviderInstanceName <String>]: Name of the provider instance.
  [ResourceGroupName <String>]: Name of the resource group.
  [ResourceName <String>]: The name of the identity resource.
  [SapMonitorName <String>]: Name of the SAP monitor resource.
  [Scope <String>]: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  [SubscriptionId <String>]: Subscription ID which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  [VaultName <String>]: Name of the vault
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hanaonazure/update-azsapmonitor
#>
function Update-AzSapMonitor {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ISapMonitor])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('SapMonitorName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the SAP monitor resource.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription ID which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.IHanaOnAzureIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.ITags1]))]
    [System.Collections.Hashtable]
    # Tags field of the resource.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
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
            UpdateExpanded = 'Az.HanaOnAzure.private\Update-AzSapMonitor_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.HanaOnAzure.private\Update-AzSapMonitor_UpdateViaIdentityExpanded';
        }
        if (('UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
Creates a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Description
Creates a provider instance for the specified subscription, resource group, SapMonitor name, and resource name.
.Example
PS C:\> New-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -Name ps-sapmonitorins-t01 -SapMonitorName yemingmonitor -ProviderType SapHana -HanaHostname 'hdb1-0' -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePassword (ConvertTo-SecureString "Manager1" -AsPlainText -Force)

Name                 Type
----                 ----
ps-sapmonitorins-t01 Microsoft.HanaOnAzure/sapMonitors/providerInstances
.Example
PS C:\> New-AzSapMonitorProviderInstance -ResourceGroupName nancyc-hn1 -SapMonitorName sapMonitor-vayh7q-test -ProviderType SapHana -HanaHostname 'hdb1-0' -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort 30015 -HanaDatabaseUsername SYSTEM -HanaDatabasePasswordSecretId https://kv-9gosjc-test.vault.azure.net/secrets/hanaPassword/bf516d1dfcc144138e5cf55114f3344b -HanaDatabasePasswordKeyVaultResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/costmanagement-rg-8p50xe/providers/Microsoft.KeyVault/vaults/kv-9gosjc-test -Name sapins-kv-test

Name           Type
----           ----
sapins-kv-test Microsoft.HanaOnAzure/sapMonitors/providerInstances

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstance
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hana/new-azsapproviderinstance
#>
function New-AzSapMonitorProviderInstance {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20200207Preview.IProviderInstance])]
[CmdletBinding(DefaultParameterSetName='ByString', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ProviderInstanceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the provider instance.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the SAP monitor resource.
    ${SapMonitorName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription ID which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The type of provider instance.
    # Supported values are: "SapHana".
    ${ProviderType},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The hostname of SAP HANA instance.
    ${HanaHostname},

    [Parameter(Mandatory)]
    [Alias('HanaDbName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The database name of SAP HANA instance.
    ${HanaDatabaseName},

    [Parameter(Mandatory)]
    [Alias('HanaDbSqlPort')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.Int32]
    # The SQL port of the database of SAP HANA instance.
    ${HanaDatabaseSqlPort},

    [Parameter(Mandatory)]
    [Alias('HanaDbUsername')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # The username of the database of SAP HANA instance.
    ${HanaDatabaseUsername},

    [Parameter(ParameterSetName='ByString', Mandatory)]
    [Alias('HanaDbPassword')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.Security.SecureString]
    # The password of the database of SAP HANA instance.
    ${HanaDatabasePassword},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.Collections.Hashtable]
    # A JSON string containing metadata of the provider instance.
    ${Metadata},

    [Parameter(ParameterSetName='ByKeyVault', Mandatory)]
    [Alias('HanaDbPasswordKeyVaultId', 'KeyVaultId')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # Resource ID of the Key Vault that contains the HANA credentials.
    ${HanaDatabasePasswordKeyVaultResourceId},

    [Parameter(ParameterSetName='ByKeyVault', Mandatory)]
    [Alias('HanaDbPasswordSecretId', 'SecretId')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [System.String]
    # Secret identifier to the Key Vault secret that contains the HANA credentials.
    ${HanaDatabasePasswordSecretId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Runtime')]
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
            ByString = 'Az.HanaOnAzure.custom\New-AzSapMonitorProviderInstance';
            ByKeyVault = 'Az.HanaOnAzure.custom\New-AzSapMonitorProviderInstance';
        }
        if (('ByString', 'ByKeyVault') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
