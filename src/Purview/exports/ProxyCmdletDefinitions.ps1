
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
List the authorization keys associated with this account.
.Description
List the authorization keys associated with this account.
.Example
PS C:\> Get-AzPurviewAccountKey -AccountName test-pa -ResourceGroupName test-rg

AtlasKafkaPrimaryEndpoint
-------------------------
Endpoint=sb://atlas-xxxxxxxx-5348-4811-a336-759242a25d37.servicebus.windows.net/;SharedAccessKeyName=AlternateSharedAccessKey;SharedAcces… 

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccessKeys
.Link
https://docs.microsoft.com/powershell/module/az.purview/get-azpurviewaccountkey
#>
function Get-AzPurviewAccountKey {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccessKeys])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The name of the account.
    ${AccountName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The resource group name.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription identifier
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            List = 'Az.Purview.private\Get-AzPurviewAccountKey_List';
        }
        if (('List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Get an account
.Description
Get an account
.Example
PS C:\> Get-AzPurviewAccount

IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name          SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType 
-------------------                  ----------------                     ------------   -------- ----          -------------------  -------------------      -------- 
xxxxxxxx-a087-43aa-8a7f-c17a4bbd4d36 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   pvac          8/4/2021 8:34:28 AM  xxx@microsoft.com        User     
xxxxxxxx-bbe7-4506-a9c4-4d602d8e4e1c xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   purview-test  8/9/2021 9:38:47 AM  xxxxxxxxx@microsoft.com  User     
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa       8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User 
.Example
PS C:\> Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg

IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5… 
.Example
PS C:\> Get-AzPurviewAccount -ResourceGroupName test-rg

IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5… 
.Example
PS C:\>  $got = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
PS C:\>  Get-AzADDomainService -InputObject $got


IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name   SystemDataCreatedAt  SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt
-------------------                  ----------------                     ------------   -------- ----   -------------------  -------------------      ----------------------- ----------------- 
xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7 xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus   test-pa 8/17/2021 6:18:57 AM xxxxxxxxxx@microsoft.com User                    8/17/2021 6:18:5… 

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IPurviewIdentity>: Identity Parameter
  [AccountName <String>]: The name of the account.
  [GroupId <String>]: The group identifier.
  [Id <String>]: Resource identity path
  [PrivateEndpointConnectionName <String>]: Name of the private endpoint connection.
  [ResourceGroupName <String>]: The resource group name.
  [SubscriptionId <String>]: The subscription identifier
.Link
https://docs.microsoft.com/powershell/module/az.purview/get-azpurviewaccount
#>
function Get-AzPurviewAccount {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount])]
[CmdletBinding(DefaultParameterSetName='List1', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('AccountName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The name of the account.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The resource group name.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription identifier
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Query')]
    [System.String]
    # The skip token.
    ${SkipToken},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            Get = 'Az.Purview.private\Get-AzPurviewAccount_Get';
            GetViaIdentity = 'Az.Purview.private\Get-AzPurviewAccount_GetViaIdentity';
            List = 'Az.Purview.private\Get-AzPurviewAccount_List';
            List1 = 'Az.Purview.private\Get-AzPurviewAccount_List1';
        }
        if (('Get', 'List', 'List1') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Get the default account for the scope.
.Description
Get the default account for the scope.
.Example
PS C:\> Get-AzPurviewDefaultAccount -ScopeTenantId xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a -ScopeType Tenant

AccountName ResourceGroupName Scope                                ScopeTenantId                        ScopeType SubscriptionId
----------- ----------------- -----                                -------------                        --------- --------------
test-pa      test-rg            xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a Tenant    xxxxxxxx-1bf0-4dda-aec3

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IDefaultAccountPayload
.Link
https://docs.microsoft.com/powershell/module/az.purview/get-azpurviewdefaultaccount
#>
function Get-AzPurviewDefaultAccount {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IDefaultAccountPayload])]
[CmdletBinding(DefaultParameterSetName='Get', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Query')]
    [System.String]
    # The tenant ID.
    ${ScopeTenantId},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScopeType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Query')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScopeType]
    # The scope for the default account.
    ${ScopeType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Query')]
    [System.String]
    # The Id of the scope object, for example if the scope is "Subscription" then it is the ID of that subscription.
    ${Scope},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            Get = 'Az.Purview.private\Get-AzPurviewDefaultAccount_Get';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Deletes an account resource
.Description
Deletes an account resource
.Example
PS C:\> Remove-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg

.Example
PS C:\> $get = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
PS C:\> Remove-AzPurviewAccount -InputObject $get


.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IPurviewIdentity>: Identity Parameter
  [AccountName <String>]: The name of the account.
  [GroupId <String>]: The group identifier.
  [Id <String>]: Resource identity path
  [PrivateEndpointConnectionName <String>]: Name of the private endpoint connection.
  [ResourceGroupName <String>]: The resource group name.
  [SubscriptionId <String>]: The subscription identifier
.Link
https://docs.microsoft.com/powershell/module/az.purview/remove-azpurviewaccount
#>
function Remove-AzPurviewAccount {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Alias('AccountName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The name of the account.
    ${Name},

    [Parameter(ParameterSetName='Delete', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The resource group name.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Delete')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription identifier
    ${SubscriptionId},

    [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            Delete = 'Az.Purview.private\Remove-AzPurviewAccount_Delete';
            DeleteViaIdentity = 'Az.Purview.private\Remove-AzPurviewAccount_DeleteViaIdentity';
        }
        if (('Delete') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Removes the default account from the scope.
.Description
Removes the default account from the scope.
.Example
PS C:\> Remove-AzPurviewDefaultAccount -ScopeTenantId xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a -ScopeType Tenant

.Outputs
System.Boolean
.Link
https://docs.microsoft.com/powershell/module/az.purview/remove-azpurviewdefaultaccount
#>
function Remove-AzPurviewDefaultAccount {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='Remove', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Query')]
    [System.String]
    # The tenant ID.
    ${ScopeTenantId},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScopeType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Query')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScopeType]
    # The scope for the default account.
    ${ScopeType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Query')]
    [System.String]
    # The Id of the scope object, for example if the scope is "Subscription" then it is the ID of that subscription.
    ${Scope},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            Remove = 'Az.Purview.private\Remove-AzPurviewDefaultAccount_Remove';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Updates an account
.Description
Updates an account
.Example
PS C:\>  Update-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg -Tag @{"k"="v"} | fl 

CloudConnectorAwsExternalId      : xxxxxxxxxx-d074-4f8f-9d7f-10811b250738
CreatedAt                        : 8/17/2021 6:18:57 AM
CreatedBy                        : xxxxx.Zhou@microsoft.com
CreatedByObjectId                : xxxxxxx-5be9-4f43-abd2-04561777c8b0
EndpointCatalog                  : https://test-pa.catalog.purview.azure.com
EndpointGuardian                 : https://test-pa.guardian.purview.azure.com
EndpointScan                     : https://test-pa.scan.purview.azure.com
FriendlyName                     : test-pa
Id                               : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/bez-rg/providers/Microsoft.Purview/a 
                                   ccounts/bez-pa
Identity                         : {
                                     "principalId": "xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7",
                                     "tenantId": "xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a",
                                     "type": "SystemAssigned"
                                   }
IdentityPrincipalId              : xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7
IdentityTenantId                 : xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a
IdentityType                     : SystemAssigned
Location                         : eastus
ManagedResourceEventHubNamespace : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.EventHub/namespaces/Atlas-2bb7cf0b-5348-4811-a336-759242a25d37
ManagedResourceGroup             : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj
ManagedResourceGroupName         : managed-rg-bbcpgdj
ManagedResourceStorageAccount    : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.Storage/storageAccounts/scaneastusnkcccgc
Name                             : test-pa
PrivateEndpointConnection        : {}
ProvisioningState                : Succeeded
PublicNetworkAccess              : Enabled
ResourceGroupName                : test-rg
SkuCapacity                      : 1
SkuName                          : Standard
SystemData                       : {
                                     "createdAt": "2021-08-17T06:18:57.7274115Z",
                                     "createdBy": "xxxxx.Zhou@microsoft.com",
                                     "createdByType": "User",
                                     "lastModifiedAt": "xxxxxx-08-17T06:18:57.7274115Z",
                                     "lastModifiedBy": "Beisi.Zhou@microsoft.com",
                                     "lastModifiedByType": "User"
                                   }
SystemDataCreatedAt              : 8/17/2021 6:18:57 AM
SystemDataCreatedBy              : xxxxx.Zhou@microsoft.com
SystemDataCreatedByType          : User
SystemDataLastModifiedAt         : 8/17/2021 6:18:57 AM
SystemDataLastModifiedBy         : xxxxxx.Zhou@microsoft.com
SystemDataLastModifiedByType     : User
Tag                              : {
                                     "k": "v"
                                   }
Type                             : Microsoft.Purview/account
.Example
PS C:\>  $get = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg 
PS C:\> Update-AzPurviewAccount -InputObject $get -Tag @{"k"="v"}

CloudConnectorAwsExternalId      : xxxxxxxxxx-d074-4f8f-9d7f-10811b250738
CreatedAt                        : 8/17/2021 6:18:57 AM
CreatedBy                        : xxxxx.Zhou@microsoft.com
CreatedByObjectId                : xxxxxxx-5be9-4f43-abd2-04561777c8b0
EndpointCatalog                  : https://test-pa.catalog.purview.azure.com
EndpointGuardian                 : https://test-pa.guardian.purview.azure.com
EndpointScan                     : https://test-pa.scan.purview.azure.com
FriendlyName                     : test-pa
Id                               : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/bez-rg/providers/Microsoft.Purview/a 
                                   ccounts/bez-pa
Identity                         : {
                                     "principalId": "xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7",
                                     "tenantId": "xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a",
                                     "type": "SystemAssigned"
                                   }
IdentityPrincipalId              : xxxxxxxx-7956-4978-87e8-9ddd82cfe2b7
IdentityTenantId                 : xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a
IdentityType                     : SystemAssigned
Location                         : eastus
ManagedResourceEventHubNamespace : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.EventHub/namespaces/Atlas-2bb7cf0b-5348-4811-a336-759242a25d37
ManagedResourceGroup             : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj
ManagedResourceGroupName         : managed-rg-bbcpgdj
ManagedResourceStorageAccount    : /subscriptions/xxxxxxxx-1bf0-4dda-aec3-cb9272f09590/resourceGroups/managed-rg-bbcpgdj/providers/Microso 
                                   ft.Storage/storageAccounts/scaneastusnkcccgc
Name                             : test-pa
PrivateEndpointConnection        : {}
ProvisioningState                : Succeeded
PublicNetworkAccess              : Enabled
ResourceGroupName                : test-rg
SkuCapacity                      : 1
SkuName                          : Standard
SystemData                       : {
                                     "createdAt": "2021-08-17T06:18:57.7274115Z",
                                     "createdBy": "xxxxx.Zhou@microsoft.com",
                                     "createdByType": "User",
                                     "lastModifiedAt": "xxxxxx-08-17T06:18:57.7274115Z",
                                     "lastModifiedBy": "Beisi.Zhou@microsoft.com",
                                     "lastModifiedByType": "User"
                                   }
SystemDataCreatedAt              : 8/17/2021 6:18:57 AM
SystemDataCreatedBy              : xxxxx.Zhou@microsoft.com
SystemDataCreatedByType          : User
SystemDataLastModifiedAt         : 8/17/2021 6:18:57 AM
SystemDataLastModifiedBy         : xxxxxx.Zhou@microsoft.com
SystemDataLastModifiedByType     : User
Tag                              : {
                                     "k": "v"
                                   }
Type                             : Microsoft.Purview/account

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IPurviewIdentity>: Identity Parameter
  [AccountName <String>]: The name of the account.
  [GroupId <String>]: The group identifier.
  [Id <String>]: Resource identity path
  [PrivateEndpointConnectionName <String>]: Name of the private endpoint connection.
  [ResourceGroupName <String>]: The resource group name.
  [SubscriptionId <String>]: The subscription identifier
.Link
https://docs.microsoft.com/powershell/module/az.purview/update-azpurviewaccount
#>
function Update-AzPurviewAccount {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('AccountName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The name of the account.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The resource group name.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription identifier
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # Gets or sets the managed resource group name
    ${ManagedResourceGroupName},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess])]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess]
    # Gets or sets the public network access.
    ${PublicNetworkAccess},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccountUpdateParametersTags]))]
    [System.Collections.Hashtable]
    # Tags on the azure resource.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            UpdateExpanded = 'Az.Purview.private\Update-AzPurviewAccount_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.Purview.private\Update-AzPurviewAccount_UpdateViaIdentityExpanded';
        }
        if (('UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Add the administrator for root collection associated with this account.
.Description
Add the administrator for root collection associated with this account.
.Example
PS C:\> Add-AzPurviewAccountRootCollectionAdmin -AccountName test-pa -ResourceGroupName test-rg -ObjectId xxxxxxxx-5be9-4f43-abd2-04561777c8b0

.Example
PS C:\>  $got = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
PS C:\>  Add-AzPurviewAccountRootCollectionAdmin -InputObject $got -ObjectId xxxxxxxx-5be9-4f43-abd2-04561777c8b0

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IPurviewIdentity>: Identity Parameter
  [AccountName <String>]: The name of the account.
  [GroupId <String>]: The group identifier.
  [Id <String>]: Resource identity path
  [PrivateEndpointConnectionName <String>]: Name of the private endpoint connection.
  [ResourceGroupName <String>]: The resource group name.
  [SubscriptionId <String>]: The subscription identifier
.Link
https://docs.microsoft.com/powershell/module/az.purview/add-azpurviewaccountrootcollectionadmin
#>
function Add-AzPurviewAccountRootCollectionAdmin {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='AddExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='AddExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The name of the account.
    ${AccountName},

    [Parameter(ParameterSetName='AddExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The resource group name.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='AddExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription identifier
    ${SubscriptionId},

    [Parameter(ParameterSetName='AddViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.IPurviewIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # Gets or sets the object identifier of the admin.
    ${ObjectId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            AddExpanded = 'Az.Purview.custom\Add-AzPurviewAccountRootCollectionAdmin';
            AddViaIdentityExpanded = 'Az.Purview.custom\Add-AzPurviewAccountRootCollectionAdmin';
        }
        if (('AddExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Creates or updates an account
.Description
Creates or updates an account
.Example
PS C:\> New-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg -Location eastus -IdentityType SystemAssigned -SkuCapacity 4 -SkuName Standard

IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location Name    SystemDataCreatedAt  SystemDataCreatedBy    
-------------------                  ----------------                     ------------   -------- ----    -------------------  ----------- 
xxxxxxxx-9e08-4873-8b0d-1442be9e5b14 54826b22-38d6-4fb2-bad9-b7b93a3e9c5a SystemAssigned eastus  test-pa 8/17/2021 7:47:10 AM xxx.xxx…

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount
.Link
https://docs.microsoft.com/powershell/module/az.purview/new-azpurviewaccount
#>
function New-AzPurviewAccount {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IAccount])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('AccountName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The name of the account.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [System.String]
    # The resource group name.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription identifier
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Type])]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Type]
    # Identity Type
    ${IdentityType},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # Gets or sets the location.
    ${Location},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.Int32]
    # Gets or sets the sku capacity.
    # Possible values include: 4, 16
    ${SkuCapacity},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Name])]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.Name]
    # Gets or sets the sku name.
    ${SkuName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # Gets or sets the managed resource group name
    ${ManagedResourceGroupName},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess])]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.PublicNetworkAccess]
    # Gets or sets the public network access.
    ${PublicNetworkAccess},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Tags on the azure resource.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            CreateExpanded = 'Az.Purview.custom\New-AzPurviewAccount';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Sets the default account for the scope.
.Description
Sets the default account for the scope.
.Example
PS C:\> Set-AzPurviewDefaultAccount -AccountName test-pa -ResourceGroupName test-rg -ScopeTenantId xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a

AccountName ResourceGroupName Scope                                ScopeTenantId                        ScopeType SubscriptionId
----------- ----------------- -----                                -------------                        --------- --------------
test-pa      test-rg            xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a xxxxxxxx-38d6-4fb2-bad9-b7b93a3e9c5a Tenant    xxxxxxxx-1bf0-4dda-aec3

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IDefaultAccountPayload
.Link
https://docs.microsoft.com/powershell/module/az.purview/set-azpurviewdefaultaccount
#>
function Set-AzPurviewDefaultAccount {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.IDefaultAccountPayload])]
[CmdletBinding(DefaultParameterSetName='SetExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # The name of the account that is set as the default.
    ${AccountName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # The resource group name of the account that is set as the default.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # The scope tenant in which the default account is set.
    ${ScopeTenantId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # The scope object ID.
    # For example, sub ID or tenant ID.
    ${Scope},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScopeType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Support.ScopeType]
    # The scope where the default account is set.
    ${ScopeType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription ID of the account that is set as the default.
    ${SubscriptionId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            SetExpanded = 'Az.Purview.custom\Set-AzPurviewDefaultAccount';
        }
        if (('SetExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
Checks if account name is available.
.Description
Checks if account name is available.
.Example
PS C:\> Test-AzPurviewAccountNameAvailability -Name test-pa -Type Tenant

Message                                                 NameAvailable Reason
-------                                                 ------------- ------
The name test-pa is invalid, please use another name. False         Invalid

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ICheckNameAvailabilityResult
.Link
https://docs.microsoft.com/powershell/module/az.purview/test-azpurviewaccountnameavailability
#>
function Test-AzPurviewAccountNameAvailability {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Purview.Models.Api20210701.ICheckNameAvailabilityResult])]
[CmdletBinding(DefaultParameterSetName='CheckExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription identifier
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # Resource name to verify for availability
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Body')]
    [System.String]
    # Fully qualified resource type which includes provider namespace
    ${Type},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Purview.Category('Runtime')]
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
            CheckExpanded = 'Az.Purview.custom\Test-AzPurviewAccountNameAvailability';
        }
        if (('CheckExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.Purview.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
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
