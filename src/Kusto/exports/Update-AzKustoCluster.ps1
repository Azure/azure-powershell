
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
Update a Kusto cluster.
.Description
Update a Kusto cluster.
.Example
PS C:\> Update-AzKustoCluster -ResourceGroupName testrg -Name testnewkustocluster -SkuName Standard_D12_v2 -SkuTier Standard -EngineType 'V2'

Location Name                Type                     Zone
-------- ----                ----                     ----
East US  testnewkustocluster Microsoft.Kusto/Clusters
.Example
PS C:\> Update-AzKustoCluster -ResourceGroupName testrg -Name testnewkustocluster -KeyVaultPropertyKeyName "TestKey" -KeyVaultPropertyKeyVaultUri "https://testpskeyvault.vault.azure.net" -KeyVaultPropertyKeyVersion "4bd66f0e0d7c403fac80305e0355d982"

Location Name                Type                     Zone
-------- ----                ----                     ----
East US  testnewkustocluster Microsoft.Kusto/Clusters

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.ICluster
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IKustoIdentity>: Identity Parameter
  [AttachedDatabaseConfigurationName <String>]: The name of the attached database configuration.
  [ClusterName <String>]: The name of the Kusto cluster.
  [DataConnectionName <String>]: The name of the data connection.
  [DatabaseName <String>]: The name of the database in the Kusto cluster.
  [Id <String>]: Resource identity path
  [Location <String>]: Azure location.
  [PrincipalAssignmentName <String>]: The name of the Kusto principalAssignment.
  [ResourceGroupName <String>]: The name of the resource group containing the Kusto cluster.
  [SubscriptionId <String>]: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

LANGUAGEEXTENSIONVALUE <ILanguageExtension[]>: The list of language extensions.
  [Name <LanguageExtensionName?>]: The language extension name.

TRUSTEDEXTERNALTENANT <ITrustedExternalTenant[]>: The cluster's external tenants.
  [Value <String>]: GUID representing an external tenant.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.kusto/update-azkustocluster
#>
function Update-AzKustoCluster {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.ICluster])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('ClusterName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
    [System.String]
    # The name of the Kusto cluster.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
    [System.String]
    # The name of the resource group containing the Kusto cluster.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # A boolean value that indicates if the cluster's disks are encrypted.
    ${EnableDiskEncryption},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # A boolean value that indicates if double encryption is enabled.
    ${EnableDoubleEncryption},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # A boolean value that indicates if the purge operations are enabled.
    ${EnablePurge},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # A boolean value that indicates if the streaming ingest is enabled.
    ${EnableStreamingIngest},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EngineType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.EngineType]
    # The engine type
    ${EngineType},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.IdentityType]
    # The type of managed identity used.
    # The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities.
    # The type 'None' will remove all identities.
    ${IdentityType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IIdentityUserAssignedIdentities]))]
    [System.Collections.Hashtable]
    # The list of user identities associated with the Kusto cluster.
    # The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    ${IdentityUserAssignedIdentity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.String]
    # The name of the key vault key.
    ${KeyVaultPropertyKeyName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.String]
    # The Uri of the key vault.
    ${KeyVaultPropertyKeyVaultUri},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.String]
    # The version of the key vault key.
    ${KeyVaultPropertyKeyVersion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.String]
    # The user assigned identity (ARM resource id) that has access to the key.
    ${KeyVaultPropertyUserIdentity},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.ILanguageExtension[]]
    # The list of language extensions.
    # To construct, see NOTES section for LANGUAGEEXTENSIONVALUE properties and create a hash table.
    ${LanguageExtensionValue},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.String]
    # Resource location.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # A boolean value that indicate if the optimized autoscale feature is enabled or not.
    ${OptimizedAutoscaleIsEnabled},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Int32]
    # Maximum allowed instances count.
    ${OptimizedAutoscaleMaximum},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Int32]
    # Minimum allowed instances count.
    ${OptimizedAutoscaleMinimum},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Int32]
    # The version of the template defined, for instance 1.
    ${OptimizedAutoscaleVersion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.Int32]
    # The number of instances of the cluster.
    ${SkuCapacity},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName])]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuName]
    # SKU name.
    ${SkuName},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier])]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.AzureSkuTier]
    # SKU tier.
    ${SkuTier},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.IClusterUpdateTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200918.ITrustedExternalTenant[]]
    # The cluster's external tenants.
    # To construct, see NOTES section for TRUSTEDEXTERNALTENANT properties and create a hash table.
    ${TrustedExternalTenant},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.String]
    # Data management's service public IP address resource id.
    ${VirtualNetworkConfigurationDataManagementPublicIPId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.String]
    # Engine service's public IP address resource id.
    ${VirtualNetworkConfigurationEnginePublicIPId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Body')]
    [System.String]
    # The subnet resource id.
    ${VirtualNetworkConfigurationSubnetId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Category('Runtime')]
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
            UpdateExpanded = 'Az.Kusto.private\Update-AzKustoCluster_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.Kusto.private\Update-AzKustoCluster_UpdateViaIdentityExpanded';
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
