
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
Update access policies in a key vault in the specified subscription.
.Description
Update access policies in a key vault in the specified subscription.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParameters
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

ACCESSPOLICY <IAccessPolicyEntry[]>: An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID.
  ObjectId <String>: The object ID of a user, service principal or security group in the Azure Active Directory tenant for the vault. The object ID must be unique for the list of access policies.
  TenantId <String>: The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
  [ApplicationId <String>]:  Application ID of the client making request on behalf of a principal
  [PermissionCertificate <CertificatePermissions[]>]: Permissions to certificates
  [PermissionKey <KeyPermissions[]>]: Permissions to keys
  [PermissionSecret <SecretPermissions[]>]: Permissions to secrets
  [PermissionStorage <StoragePermissions[]>]: Permissions to storage accounts
.Link
https://docs.microsoft.com/en-us/powershell/module/az.hanaonazure/set-azvaultaccesspolicy
#>
function Set-AzVaultAccessPolicy {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultAccessPolicyParameters])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.AccessPolicyUpdateKind])]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.AccessPolicyUpdateKind]
    # Name of the operation
    ${OperationKind},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # The name of the Resource Group to which the vault belongs.
    ${ResourceGroupName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [System.String]
    # Name of the vault
    ${VaultName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription ID which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[]]
    # An array of 0 to 16 identities that have access to the key vault.
    # All identities in the array must use the same tenant ID as the key vault's tenant ID.
    # To construct, see NOTES section for ACCESSPOLICY properties and create a hash table.
    ${AccessPolicy},

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
            UpdateExpanded = 'Az.HanaOnAzure.private\Set-AzVaultAccessPolicy_UpdateExpanded';
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
