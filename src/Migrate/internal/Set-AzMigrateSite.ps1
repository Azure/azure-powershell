
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
Method to create or update a site.
.Description
Method to create or update a site.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

BODY <IVMwareSite>: Site REST Resource.
  [AgentDetailKeyVaultId <String>]: Key vault ARM Id.
  [AgentDetailKeyVaultUri <String>]: Key vault URI.
  [ApplianceName <String>]: Appliance Name.
  [DiscoverySolutionId <String>]: ARM ID of migration hub solution for SDS.
  [ETag <String>]: eTag for concurrency control.
  [Location <String>]: Azure location in which Sites is created.
  [Name <String>]: Name of the VMware site.
  [ServicePrincipalIdentityDetailAadAuthority <String>]: AAD Authority URL which was used to request the token for the service principal.
  [ServicePrincipalIdentityDetailApplicationId <String>]: Application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  [ServicePrincipalIdentityDetailAudience <String>]: Intended audience for the service principal.
  [ServicePrincipalIdentityDetailObjectId <String>]: Object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  [ServicePrincipalIdentityDetailRawCertData <String>]: Raw certificate data for building certificate expiry flows.
  [ServicePrincipalIdentityDetailTenantId <String>]: Tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
  [Tag <IVMwareSiteTags>]: Dictionary of <string>
    [(Any) <String>]: This indicates any property can be added to this object.
.Link
https://docs.microsoft.com/powershell/module/az.migrate/set-azmigratesite
#>
function Set-AzMigrateSite {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Site name.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Path')]
    [System.String]
    # Site name.
    ${SiteName},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSite]
    # Site REST Resource.
    # To construct, see NOTES section for BODY properties and create a hash table.
    ${Body},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Key vault ARM Id.
    ${AgentDetailKeyVaultId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Key vault URI.
    ${AgentDetailKeyVaultUri},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Appliance Name.
    ${ApplianceName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # ARM ID of migration hub solution for SDS.
    ${DiscoverySolutionId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # eTag for concurrency control.
    ${ETag},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Azure location in which Sites is created.
    ${Location},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # AAD Authority URL which was used to request the token for the service principal.
    ${ServicePrincipalIdentityDetailAadAuthority},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Application/client Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
    ${ServicePrincipalIdentityDetailApplicationId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Intended audience for the service principal.
    ${ServicePrincipalIdentityDetailAudience},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Object Id of the service principal with which the on-premise management/data plane components would communicate with our Azure services.
    ${ServicePrincipalIdentityDetailObjectId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Raw certificate data for building certificate expiry flows.
    ${ServicePrincipalIdentityDetailRawCertData},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [System.String]
    # Tenant Id for the service principal with which the on-premise management/data plane components would communicate with our Azure services.
    ${ServicePrincipalIdentityDetailTenantId},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareSiteTags]))]
    [System.Collections.Hashtable]
    # Dictionary of <string>
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Category('Runtime')]
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
            Update = 'Az.Migrate.private\Set-AzMigrateSite_Update';
            UpdateExpanded = 'Az.Migrate.private\Set-AzMigrateSite_UpdateExpanded';
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
