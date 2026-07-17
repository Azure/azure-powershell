
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
Validates if a source Azure Cache for Redis resource can be migrated to a target Azure Managed Redis resource.
.Description
Validates if a source Azure Cache for Redis resource can be migrated to a target Azure Managed Redis resource.
This custom wrapper fixes a serialization issue where the request body must nest properties under a
"properties" envelope for the ARM API, but the generated Expanded variant serializes them flat.
.Example
Test-AzRedisEnterpriseCacheMigration -ClusterName "cache1" -ResourceGroupName "rg1" -SourceResourceId "/subscriptions/e7b5a9d2-6b6a-4d2f-9143-20d9a10f5b8f/resourceGroups/rg1/providers/Microsoft.Cache/redis/cache1" -SkipDataMigration

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IMigrationValidationResponse
.Link
https://learn.microsoft.com/powershell/module/az.redisenterprisecache/test-azredisenterprisecachemigration
#>
function Test-AzRedisEnterpriseCacheMigration {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IMigrationValidationResponse])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the Redis Enterprise cluster.
        ${ClusterName},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # The source resource ID to validate migration from.
        # This is the resource ID of the Azure Cache for Redis.
        ${SourceResourceId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Sets whether to ignore warnings when validating if the source cache can be migrated to the target cache.
        ${ForceMigrate},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Sets whether the data is migrated from source to target or not.
        ${SkipDataMigration},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        # Build the request body with proper ARM "properties" envelope.
        # The generated Expanded variant incorrectly serializes fields flat (without the properties wrapper),
        # which causes the control plane to reject the request with "requestBody.properties invalid".
        $properties = @{
            sourceResourceId = $SourceResourceId
        }
        if ($PSBoundParameters.ContainsKey('SkipDataMigration')) {
            $properties['skipDataMigration'] = $SkipDataMigration.IsPresent
        }
        if ($PSBoundParameters.ContainsKey('ForceMigrate')) {
            $properties['forceMigrate'] = $ForceMigrate.IsPresent
        }

        $body = @{ properties = $properties }
        $jsonString = $body | ConvertTo-Json -Depth 10 -Compress

        # Remove body parameters and add JsonString instead
        $null = $PSBoundParameters.Remove('SourceResourceId')
        $null = $PSBoundParameters.Remove('SkipDataMigration')
        $null = $PSBoundParameters.Remove('ForceMigrate')
        $null = $PSBoundParameters.Add('JsonString', $jsonString)

        Az.RedisEnterpriseCache.private\Test-AzRedisEnterpriseCacheMigration_ValidateViaJsonString @PSBoundParameters
    }
}
