
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
Gets information about a database.
.Description
Gets information about a database.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/get-azmariadbdatabase
#>
function Get-AzMariaDbDatabase {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('DatabaseName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the database.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Get = 'Az.MariaDb.private\Get-AzMariaDbDatabase_Get';
            GetViaIdentity = 'Az.MariaDb.private\Get-AzMariaDbDatabase_GetViaIdentity';
            List = 'Az.MariaDb.private\Get-AzMariaDbDatabase_List';
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
List all the performance tiers at specified location in a given subscription.
.Description
List all the performance tiers at specified location in a given subscription.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierProperties
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/get-azmariadblocationbasedperformancetier
#>
function Get-AzMariaDbLocationBasedPerformanceTier {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IPerformanceTierProperties])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the location.
    ${LocationName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            List = 'Az.MariaDb.private\Get-AzMariaDbLocationBasedPerformanceTier_List';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
List all the log files in a given server.
.Description
List all the log files in a given server.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ILogFile
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/get-azmariadblogfile
#>
function Get-AzMariaDbLogFile {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.ILogFile])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            List = 'Az.MariaDb.private\Get-AzMariaDbLogFile_List';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Lists all of the available REST API operations.
.Description
Lists all of the available REST API operations.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IOperation
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/get-azmariadboperation
#>
function Get-AzMariaDbOperation {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IOperation])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            List = 'Az.MariaDb.private\Get-AzMariaDbOperation_List';
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
Get a server's security alert policy.
.Description
Get a server's security alert policy.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/get-azmariadbserversecurityalertpolicy
#>
function Get-AzMariaDbServerSecurityAlertPolicy {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter(ParameterSetName='Get')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Get = 'Az.MariaDb.private\Get-AzMariaDbServerSecurityAlertPolicy_Get';
            GetViaIdentity = 'Az.MariaDb.private\Get-AzMariaDbServerSecurityAlertPolicy_GetViaIdentity';
        }
        if (('Get') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Check the availability of name for resource
.Description
Check the availability of name for resource
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.INameAvailabilityRequest
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.INameAvailability
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.

NAMEAVAILABILITYREQUEST <INameAvailabilityRequest>: Request from client to check resource name availability.
  Name <String>: Resource name to verify.
  [Type <String>]: Resource type used for verification.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/invoke-azmariadbexecutechecknameavailability
#>
function Invoke-AzMariaDbExecuteCheckNameAvailability {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.INameAvailability])]
[CmdletBinding(DefaultParameterSetName='ExecuteExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Execute')]
    [Parameter(ParameterSetName='ExecuteExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ExecuteViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ExecuteViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Execute', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ExecuteViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.INameAvailabilityRequest]
    # Request from client to check resource name availability.
    # To construct, see NOTES section for NAMEAVAILABILITYREQUEST properties and create a hash table.
    ${NameAvailabilityRequest},

    [Parameter(ParameterSetName='ExecuteExpanded', Mandatory)]
    [Parameter(ParameterSetName='ExecuteViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Resource name to verify.
    ${Name},

    [Parameter(ParameterSetName='ExecuteExpanded')]
    [Parameter(ParameterSetName='ExecuteViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Resource type used for verification.
    ${Type},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Execute = 'Az.MariaDb.private\Invoke-AzMariaDbExecuteCheckNameAvailability_Execute';
            ExecuteExpanded = 'Az.MariaDb.private\Invoke-AzMariaDbExecuteCheckNameAvailability_ExecuteExpanded';
            ExecuteViaIdentity = 'Az.MariaDb.private\Invoke-AzMariaDbExecuteCheckNameAvailability_ExecuteViaIdentity';
            ExecuteViaIdentityExpanded = 'Az.MariaDb.private\Invoke-AzMariaDbExecuteCheckNameAvailability_ExecuteViaIdentityExpanded';
        }
        if (('Execute', 'ExecuteExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Updates a configuration of a server.
.Description
Updates a configuration of a server.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/new-azmariadbconfiguration
#>
function New-AzMariaDbConfiguration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('ConfigurationName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server configuration.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Source of the configuration.
    ${Source},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Value of the configuration.
    ${Value},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            CreateExpanded = 'Az.MariaDb.private\New-AzMariaDbConfiguration_CreateExpanded';
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
Creates a new database or updates an existing database.
.Description
Creates a new database or updates an existing database.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.

PARAMETER <IDatabase>: Represents a Database.
  [Charset <String>]: The charset of the database.
  [Collation <String>]: The collation of the database.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/new-azmariadbdatabase
#>
function New-AzMariaDbDatabase {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Alias('DatabaseName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the database.
    ${Name},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter(ParameterSetName='Create')]
    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase]
    # Represents a Database.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The charset of the database.
    ${Charset},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The collation of the database.
    ${Collation},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Create = 'Az.MariaDb.private\New-AzMariaDbDatabase_Create';
            CreateExpanded = 'Az.MariaDb.private\New-AzMariaDbDatabase_CreateExpanded';
            CreateViaIdentity = 'Az.MariaDb.private\New-AzMariaDbDatabase_CreateViaIdentity';
            CreateViaIdentityExpanded = 'Az.MariaDb.private\New-AzMariaDbDatabase_CreateViaIdentityExpanded';
        }
        if (('Create', 'CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates a new firewall rule or updates an existing firewall rule.
.Description
Creates a new firewall rule or updates an existing firewall rule.
.Example
PS C:\> New-AzMariaDbFirewallRule -Name firewall-101 -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -EndIPAddress 0.0.2.255 -StartIPAddress 0.0.2.1

Name         StartIPAddress EndIPAddress
----         -------------- ------------
firewall-101 0.0.2.1        0.0.2.255
.Example
PS C:\> New-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -ClientIPAddress 0.0.0.1

Name                                StartIPAddress EndIPAddress
----                                -------------- ------------
ClientIPAddress_2020-08-11_18-19-27 0.0.0.1        0.0.0.1
.Example
PS C:\> New-AzMariaDbFirewallRule -ResourceGroupName mariadb-test-qu5ov0 -ServerName mariadb-asd-01 -AllowAll

Name                         StartIPAddress EndIPAddress
----                         -------------- ------------
AllowAll_2020-08-11_18-19-27 0.0.0.0        255.255.255.255

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IFirewallRule
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/new-azmariadbfirewallrule
#>
function New-AzMariaDbFirewallRule {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IFirewallRule])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('FirewallRuleName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server firewall rule.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The end IP address of the server firewall rule.
    # Must be IPv4 format.
    ${EndIPAddress},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The start IP address of the server firewall rule.
    # Must be IPv4 format.
    ${StartIPAddress},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            CreateExpanded = 'Az.MariaDb.private\New-AzMariaDbFirewallRule_CreateExpanded';
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
Creates or updates a threat detection policy.
.Description
Creates or updates a threat detection policy.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.

PARAMETER <IServerSecurityAlertPolicy>: A server security alert policy.
  State <ServerSecurityAlertPolicyState>: Specifies the state of the policy, whether it is enabled or disabled.
  [DisabledAlert <String[]>]: Specifies an array of alerts that are disabled. Allowed values are: Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly
  [EmailAccountAdmin <Boolean?>]: Specifies that the alert is sent to the account administrators.
  [EmailAddress <String[]>]: Specifies an array of e-mail addresses to which the alert is sent.
  [RetentionDay <Int32?>]: Specifies the number of days to keep in the Threat Detection audit logs.
  [StorageAccountAccessKey <String>]: Specifies the identifier key of the Threat Detection audit storage account.
  [StorageEndpoint <String>]: Specifies the blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net). This blob storage will hold all Threat Detection audit logs.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/new-azmariadbserversecurityalertpolicy
#>
function New-AzMariaDbServerSecurityAlertPolicy {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter(ParameterSetName='Create')]
    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy]
    # A server security alert policy.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String[]]
    # Specifies an array of alerts that are disabled.
    # Allowed values are: Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly
    ${DisabledAlert},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specifies that the alert is sent to the account administrators.
    ${EmailAccountAdmin},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String[]]
    # Specifies an array of e-mail addresses to which the alert is sent.
    ${EmailAddress},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Int32]
    # Specifies the number of days to keep in the Threat Detection audit logs.
    ${RetentionDay},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerSecurityAlertPolicyState])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerSecurityAlertPolicyState]
    # Specifies the state of the policy, whether it is enabled or disabled.
    ${State},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Specifies the identifier key of the Threat Detection audit storage account.
    ${StorageAccountAccessKey},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Specifies the blob storage endpoint (e.g.
    # https://MyAccount.blob.core.windows.net).
    # This blob storage will hold all Threat Detection audit logs.
    ${StorageEndpoint},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Create = 'Az.MariaDb.private\New-AzMariaDbServerSecurityAlertPolicy_Create';
            CreateExpanded = 'Az.MariaDb.private\New-AzMariaDbServerSecurityAlertPolicy_CreateExpanded';
            CreateViaIdentity = 'Az.MariaDb.private\New-AzMariaDbServerSecurityAlertPolicy_CreateViaIdentity';
            CreateViaIdentityExpanded = 'Az.MariaDb.private\New-AzMariaDbServerSecurityAlertPolicy_CreateViaIdentityExpanded';
        }
        if (('Create', 'CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates a new server or updates an existing server.
The update action will overwrite the existing server.
.Description
Creates a new server or updates an existing server.
The update action will overwrite the existing server.
.Example
PS C:\> New-AzMariaDbServer -Name mariadb-aassd-01 -ResourceGroupName lucas-manual-test -Sku 'B_Gen5_1' -Location eastus
cmdlet New-AzMariaDbServer at command pipeline position 1
Supply values for the following parameters:
AdministratorUsername: adminuser
AdministratorLoginPassword: ************

Name             Location AdministratorLogin Version StorageProfileStorageMb SkuName  SkuTier SslEnforcement
----             -------- ------------------ ------- ----------------------- -------  ------- --------------
mariadb-aassd-01 eastus   adminuser          10.2    5120                    B_Gen5_1 Basic   Enabled

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreate
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.

PARAMETER <IServerForCreate>: Represents a server to be created.
  CreateMode <CreateMode>: The mode to create a new server.
  Location <String>: The location the resource resides in.
  [SkuCapacity <Int32?>]: The scale up/out capacity, representing server's compute units.
  [SkuFamily <String>]: The family of hardware.
  [SkuName <String>]: The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
  [SkuSize <String>]: The size code, to be interpreted by resource as appropriate.
  [SkuTier <SkuTier?>]: The tier of the particular SKU, e.g. Basic.
  [SslEnforcement <SslEnforcementEnum?>]: Enable ssl enforcement or not when connect to server.
  [StorageProfileBackupRetentionDay <Int32?>]: Backup retention days for the server.
  [StorageProfileGeoRedundantBackup <GeoRedundantBackup?>]: Enable Geo-redundant or not for server backup.
  [StorageProfileStorageAutogrow <StorageAutogrow?>]: Enable Storage Auto Grow.
  [StorageProfileStorageMb <Int32?>]: Max storage allowed for a server.
  [Tag <IServerForCreateTags>]: Application-specific metadata in the form of key-value pairs.
    [(Any) <String>]: This indicates any property can be added to this object.
  [Version <ServerVersion?>]: Server version.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/new-azmariadbserver
#>
function New-AzMariaDbServer {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Alias('ServerName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${Name},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create')]
    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Create', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreate]
    # Represents a server to be created.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.CreateMode]
    # The mode to create a new server.
    ${CreateMode},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The location the resource resides in.
    ${Location},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Int32]
    # The scale up/out capacity, representing server's compute units.
    ${SkuCapacity},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The family of hardware.
    ${SkuFamily},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The name of the sku, typically, tier + family + cores, e.g.
    # B_Gen4_1, GP_Gen5_8.
    ${SkuName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The size code, to be interpreted by resource as appropriate.
    ${SkuSize},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier]
    # The tier of the particular SKU, e.g.
    # Basic.
    ${SkuTier},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum]
    # Enable ssl enforcement or not when connect to server.
    ${SslEnforcement},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Int32]
    # Backup retention days for the server.
    # Day count is between 7 and 35.
    ${StorageProfileBackupRetentionDay},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup]
    # Enable Geo-redundant or not for server backup.
    ${StorageProfileGeoRedundantBackup},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow]
    # Enable Storage Auto Grow.
    ${StorageProfileStorageAutogrow},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Int32]
    # Max storage allowed for a server.
    ${StorageProfileStorageMb},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerForCreateTags]))]
    [System.Collections.Hashtable]
    # Application-specific metadata in the form of key-value pairs.
    ${Tag},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Parameter(ParameterSetName='CreateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion]
    # Server version.
    ${Version},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Create = 'Az.MariaDb.private\New-AzMariaDbServer_Create';
            CreateExpanded = 'Az.MariaDb.private\New-AzMariaDbServer_CreateExpanded';
            CreateViaIdentity = 'Az.MariaDb.private\New-AzMariaDbServer_CreateViaIdentity';
            CreateViaIdentityExpanded = 'Az.MariaDb.private\New-AzMariaDbServer_CreateViaIdentityExpanded';
        }
        if (('Create', 'CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Deletes a database.
.Description
Deletes a database.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/remove-azmariadbdatabase
#>
function Remove-AzMariaDbDatabase {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Alias('DatabaseName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the database.
    ${Name},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Delete = 'Az.MariaDb.private\Remove-AzMariaDbDatabase_Delete';
            DeleteViaIdentity = 'Az.MariaDb.private\Remove-AzMariaDbDatabase_DeleteViaIdentity';
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
Restarts a server.
.Description
Restarts a server.
.Example
PS C:\> Restart-AzMariaDbServer -Name mariadb-test-9pebvn -ResourceGroupName mariadb-test-qu5ov0

.Example
PS C:\> Get-AzMariaDbServer -Name mariadb-test-9pebvn -ResourceGroupName mariadb-test-qu5ov0 | Restart-AzMariaDbServer


.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/restart-azmariadbserver
#>
function Restart-AzMariaDbServer {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Restart', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Restart', Mandatory)]
    [Alias('ServerName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${Name},

    [Parameter(ParameterSetName='Restart', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Restart')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RestartViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Restart = 'Az.MariaDb.private\Restart-AzMariaDbServer_Restart';
            RestartViaIdentity = 'Az.MariaDb.private\Restart-AzMariaDbServer_RestartViaIdentity';
        }
        if (('Restart') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates a new database or updates an existing database.
.Description
Creates a new database or updates an existing database.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PARAMETER <IDatabase>: Represents a Database.
  [Charset <String>]: The charset of the database.
  [Collation <String>]: The collation of the database.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/set-azmariadbdatabase
#>
function Set-AzMariaDbDatabase {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('DatabaseName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the database.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IDatabase]
    # Represents a Database.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The charset of the database.
    ${Charset},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The collation of the database.
    ${Collation},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Update = 'Az.MariaDb.private\Set-AzMariaDbDatabase_Update';
            UpdateExpanded = 'Az.MariaDb.private\Set-AzMariaDbDatabase_UpdateExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Creates or updates a threat detection policy.
.Description
Creates or updates a threat detection policy.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PARAMETER <IServerSecurityAlertPolicy>: A server security alert policy.
  State <ServerSecurityAlertPolicyState>: Specifies the state of the policy, whether it is enabled or disabled.
  [DisabledAlert <String[]>]: Specifies an array of alerts that are disabled. Allowed values are: Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly
  [EmailAccountAdmin <Boolean?>]: Specifies that the alert is sent to the account administrators.
  [EmailAddress <String[]>]: Specifies an array of e-mail addresses to which the alert is sent.
  [RetentionDay <Int32?>]: Specifies the number of days to keep in the Threat Detection audit logs.
  [StorageAccountAccessKey <String>]: Specifies the identifier key of the Threat Detection audit storage account.
  [StorageEndpoint <String>]: Specifies the blob storage endpoint (e.g. https://MyAccount.blob.core.windows.net). This blob storage will hold all Threat Detection audit logs.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/set-azmariadbserversecurityalertpolicy
#>
function Set-AzMariaDbServerSecurityAlertPolicy {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerSecurityAlertPolicy]
    # A server security alert policy.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String[]]
    # Specifies an array of alerts that are disabled.
    # Allowed values are: Sql_Injection, Sql_Injection_Vulnerability, Access_Anomaly
    ${DisabledAlert},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Specifies that the alert is sent to the account administrators.
    ${EmailAccountAdmin},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String[]]
    # Specifies an array of e-mail addresses to which the alert is sent.
    ${EmailAddress},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Int32]
    # Specifies the number of days to keep in the Threat Detection audit logs.
    ${RetentionDay},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerSecurityAlertPolicyState])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerSecurityAlertPolicyState]
    # Specifies the state of the policy, whether it is enabled or disabled.
    ${State},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Specifies the identifier key of the Threat Detection audit storage account.
    ${StorageAccountAccessKey},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Specifies the blob storage endpoint (e.g.
    # https://MyAccount.blob.core.windows.net).
    # This blob storage will hold all Threat Detection audit logs.
    ${StorageEndpoint},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Update = 'Az.MariaDb.private\Set-AzMariaDbServerSecurityAlertPolicy_Update';
            UpdateExpanded = 'Az.MariaDb.private\Set-AzMariaDbServerSecurityAlertPolicy_UpdateExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
Updates a configuration of a server.
.Description
Updates a configuration of a server.
.Example
PS C:\> Update-AzMariaDbConfiguration -Name delayed_insert_timeout -Value 200 -ServerName mariadb-test-h3pame -ResourceGroupName mariadb-test-qu5ov0 

Name                   Type
----                   ----
delayed_insert_timeout Microsoft.DBforMariaDB/servers/configurations

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/update-azmariadbconfiguration
#>
function Update-AzMariaDbConfiguration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('ConfigurationName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server configuration.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Source of the configuration.
    ${Source},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # Value of the configuration.
    ${Value},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            UpdateExpanded = 'Az.MariaDb.private\Update-AzMariaDbConfiguration_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.MariaDb.private\Update-AzMariaDbConfiguration_UpdateViaIdentityExpanded';
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
Creates a new firewall rule or updates an existing firewall rule.
.Description
Creates a new firewall rule or updates an existing firewall rule.
.Example
PS C:\> Update-AzMariaDbFirewallRule -Name fr-cfgl3y -ServerName mariadb-test-4rmtig -ResourceGroupName mariadb-test-qu5ov0 -StartIPAddress 0.0.3.1 -EndIPAddress 0.0.3.255

Name      StartIPAddress EndIPAddress
----      -------------- ------------
fr-cfgl3y 0.0.3.1        0.0.3.255
.Example
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/mariadb-test-qu5ov0/providers/Microsoft.DBforMariaDB/servers/mariadb-test-4rmtig/firewallRules/fr-cfgl3y"
PS C:\> Update-AzMariaDbFirewallRule -InputObject $ID -EndIPAddress 0.0.0.3 -StartIPAddress 0.0.0.2

Name      StartIPAddress EndIPAddress
----      -------------- ------------
fr-cfgl3y 0.0.0.2        0.0.0.3
.Example
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/mariadb-test-qu5ov0/providers/Microsoft.DBforMariaDB/servers/mariadb-test-4rmtig/firewallRules/fr-cfgl3y"
PS C:\> Update-AzMariaDbFirewallRule -InputObject $ID --ClientIPAddress 0.0.0.2

Name      StartIPAddress EndIPAddress
----      -------------- ------------
fr-cfgl3y 0.0.0.2        0.0.0.2

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IFirewallRule
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/update-azmariadbfirewallrule
#>
function Update-AzMariaDbFirewallRule {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IFirewallRule])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('FirewallRuleName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server firewall rule.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${ServerName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The end IP address of the server firewall rule.
    # Must be IPv4 format.
    ${EndIPAddress},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The start IP address of the server firewall rule.
    # Must be IPv4 format.
    ${StartIPAddress},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            UpdateExpanded = 'Az.MariaDb.private\Update-AzMariaDbFirewallRule_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.MariaDb.private\Update-AzMariaDbFirewallRule_UpdateViaIdentityExpanded';
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
Updates an existing server.
The request body can contain one to many of the properties present in the normal server definition.
.Description
Updates an existing server.
The request body can contain one to many of the properties present in the normal server definition.
.Example
PS C:\> Update-AzMariaDbServer -Name mariadb-test-4rmtig -ResourceGroupName mariadb-test-qu5ov0 -StorageInMb 8192

Name                Location AdministratorLogin Version StorageProfileStorageMb SkuName  SkuTier SslEnforcement
----                -------- ------------------ ------- ----------------------- -------  ------- --------------
mariadb-test-4rmtig eastus   xofavpndqj         10.2    8192                    B_Gen5_1 Basic   Enabled
.Example
PS C:\> Get-AzMariaDbServer -Name mariadb-test-4rmtig -ResourceGroupName mariadb-test-qu5ov0 | Update-AzMariaDbServer -StorageInMb (8192+1024)

Name                Location AdministratorLogin Version StorageProfileStorageMb SkuName  SkuTier SslEnforcement
----                -------- ------------------ ------- ----------------------- -------  ------- --------------
mariadb-test-4rmtig eastus   xofavpndqj         10.2    9216                    B_Gen5_1 Basic   Enabled

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParameters
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IMariaDbIdentity>: Identity Parameter
  [ConfigurationName <String>]: The name of the server configuration.
  [DatabaseName <String>]: The name of the database.
  [FirewallRuleName <String>]: The name of the server firewall rule.
  [Id <String>]: Resource identity path
  [LocationName <String>]: The name of the location.
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [SecurityAlertPolicyName <SecurityAlertPolicyName?>]: The name of the security alert policy.
  [ServerName <String>]: The name of the server.
  [SubscriptionId <String>]: The subscription ID that identifies an Azure subscription.
  [VirtualNetworkRuleName <String>]: The name of the virtual network rule.

PARAMETER <IServerUpdateParameters>: Parameters allowed to update for a server.
  [AdministratorLoginPassword <String>]: The password of the administrator login.
  [ReplicationRole <String>]: The replication role of the server.
  [SkuCapacity <Int32?>]: The scale up/out capacity, representing server's compute units.
  [SkuFamily <String>]: The family of hardware.
  [SkuName <String>]: The name of the sku, typically, tier + family + cores, e.g. B_Gen4_1, GP_Gen5_8.
  [SkuSize <String>]: The size code, to be interpreted by resource as appropriate.
  [SkuTier <SkuTier?>]: The tier of the particular SKU, e.g. Basic.
  [SslEnforcement <SslEnforcementEnum?>]: Enable ssl enforcement or not when connect to server.
  [StorageProfileBackupRetentionDay <Int32?>]: Backup retention days for the server.
  [StorageProfileGeoRedundantBackup <GeoRedundantBackup?>]: Enable Geo-redundant or not for server backup.
  [StorageProfileStorageAutogrow <StorageAutogrow?>]: Enable Storage Auto Grow.
  [StorageProfileStorageMb <Int32?>]: Max storage allowed for a server.
  [Tag <IServerUpdateParametersTags>]: Application-specific metadata in the form of key-value pairs.
    [(Any) <String>]: This indicates any property can be added to this object.
  [Version <ServerVersion?>]: The version of a server.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.mariadb/update-azmariadbserver
#>
function Update-AzMariaDbServer {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServer])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('ServerName')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the server.
    ${Name},

    [Parameter(ParameterSetName='Update', Mandatory)]
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Update')]
    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID that identifies an Azure subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='UpdateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParameters]
    # Parameters allowed to update for a server.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The password of the administrator login.
    ${AdministratorLoginPassword},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The replication role of the server.
    ${ReplicationRole},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Int32]
    # The scale up/out capacity, representing server's compute units.
    ${SkuCapacity},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The family of hardware.
    ${SkuFamily},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The name of the sku, typically, tier + family + cores, e.g.
    # B_Gen4_1, GP_Gen5_8.
    ${SkuName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.String]
    # The size code, to be interpreted by resource as appropriate.
    ${SkuSize},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SkuTier]
    # The tier of the particular SKU, e.g.
    # Basic.
    ${SkuTier},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.SslEnforcementEnum]
    # Enable ssl enforcement or not when connect to server.
    ${SslEnforcement},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Int32]
    # Backup retention days for the server.
    # Day count is between 7 and 35.
    ${StorageProfileBackupRetentionDay},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.GeoRedundantBackup]
    # Enable Geo-redundant or not for server backup.
    ${StorageProfileGeoRedundantBackup},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.StorageAutogrow]
    # Enable Storage Auto Grow.
    ${StorageProfileStorageAutogrow},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [System.Int32]
    # Max storage allowed for a server.
    ${StorageProfileStorageMb},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IServerUpdateParametersTags]))]
    [System.Collections.Hashtable]
    # Application-specific metadata in the form of key-value pairs.
    ${Tag},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion])]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Support.ServerVersion]
    # The version of a server.
    ${Version},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
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
            Update = 'Az.MariaDb.private\Update-AzMariaDbServer_Update';
            UpdateExpanded = 'Az.MariaDb.private\Update-AzMariaDbServer_UpdateExpanded';
            UpdateViaIdentity = 'Az.MariaDb.private\Update-AzMariaDbServer_UpdateViaIdentity';
            UpdateViaIdentityExpanded = 'Az.MariaDb.private\Update-AzMariaDbServer_UpdateViaIdentityExpanded';
        }
        if (('Update', 'UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
