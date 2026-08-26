
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
Updates an existing Redis Enterprise database
.Description
Updates an existing Redis Enterprise database
.Example
PS C:\> Update-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup" -ClientProtocol "Plaintext"

Name    Type
----    ----
default Microsoft.Cache/redisEnterprise/databases

.Example
PS C:\> Update-AzRedisEnterpriseCacheDatabase -Name "MyCache" -ResourceGroupName "MyGroup" -ClientProtocol "Encrypted" -EvictionPolicy "NoEviction" -RdbPersistenceEnabled:$true -RdbPersistenceFrequency "6h"

Name    Type
----    ----
default Microsoft.Cache/redisEnterprise/databases

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IDatabase
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IRedisEnterpriseCacheIdentity>: Identity Parameter
  [ClusterName <String>]: The name of the Redis Enterprise cluster.
  [DatabaseName <String>]: The name of the database (must be "default").
  [Id <String>]: Resource identity path
  [Location <String>]: The region the operation is in.
  [OperationId <String>]: The operation's unique identifier.
  [PrivateEndpointConnectionName <String>]: The name of the private endpoint connection associated with the Azure resource
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.

MODULE <IModule[]>: Optional set of redis modules to enable in this database - modules can only be added at creation time.
  Name <String>: The name of the module, e.g. 'RedisBloom', 'RediSearch', 'RedisTimeSeries'
  [Arg <String>]: Configuration options for the module, e.g. 'ERROR_RATE 0.00 INITIAL_SIZE 400'.

.Link
https://learn.microsoft.com/powershell/module/az.redisenterprisecache/update-azredisenterprisecachedatabase
#>
function Resolve-AzRedisEnterpriseCacheDatabaseIdentity {
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [System.Object]
        ${InputObject}
    )

    $identityValues = @{}
    foreach ($propertyName in @('SubscriptionId', 'ResourceGroupName', 'ClusterName', 'DatabaseName', 'Id')) {
        $propertyValue = $null
        if ($InputObject -is [System.Collections.IDictionary]) {
            foreach ($key in $InputObject.Keys) {
                if ([System.String]::Equals([System.String]$key, $propertyName, [System.StringComparison]::OrdinalIgnoreCase)) {
                    $propertyValue = $InputObject[$key]
                    break
                }
            }
        } else {
            $property = $InputObject.PSObject.Properties[$propertyName]
            if ($null -ne $property) {
                $propertyValue = $property.Value
            }
        }

        if (-not [System.String]::IsNullOrWhiteSpace([System.String]$propertyValue)) {
            $identityValues[$propertyName] = [System.String]$propertyValue
        }
    }

    $requiredFields = @('SubscriptionId', 'ResourceGroupName', 'ClusterName')
    $hasMissingField = $false
    foreach ($fieldName in $requiredFields) {
        if (-not $identityValues.ContainsKey($fieldName)) {
            $hasMissingField = $true
            break
        }
    }

    if (($hasMissingField -or -not $identityValues.ContainsKey('DatabaseName')) -and $identityValues.ContainsKey('Id')) {
        $resourceIdPattern = '^/subscriptions/(?<SubscriptionId>[^/]+)/resourceGroups/(?<ResourceGroupName>[^/]+)/providers/Microsoft[.]Cache/redisEnterprise/(?<ClusterName>[^/]+)(?:/databases/(?<DatabaseName>[^/]+))?$'
        $resourceIdMatch = [System.Text.RegularExpressions.Regex]::Match(
            $identityValues['Id'],
            $resourceIdPattern,
            [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)

        if (-not $resourceIdMatch.Success) {
            throw [System.Management.Automation.PSArgumentException]::new(
                "InputObject.Id must be a Redis Enterprise cluster or database resource ID in the form '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cache/redisEnterprise/{clusterName}[/databases/default]'.")
        }

        foreach ($fieldName in $requiredFields) {
            if (-not $identityValues.ContainsKey($fieldName)) {
                $identityValues[$fieldName] = $resourceIdMatch.Groups[$fieldName].Value
            }
        }
        if (-not $identityValues.ContainsKey('DatabaseName') -and $resourceIdMatch.Groups['DatabaseName'].Success) {
            $identityValues['DatabaseName'] = $resourceIdMatch.Groups['DatabaseName'].Value
        }
    }

    foreach ($fieldName in $requiredFields) {
        if (-not $identityValues.ContainsKey($fieldName)) {
            throw [System.Management.Automation.PSArgumentException]::new(
                "InputObject must specify $fieldName directly or through a valid Redis Enterprise resource Id.")
        }
    }

    if (-not $identityValues.ContainsKey('DatabaseName')) {
        $identityValues['DatabaseName'] = 'default'
    } elseif (-not [System.String]::Equals($identityValues['DatabaseName'], 'default', [System.StringComparison]::OrdinalIgnoreCase)) {
        throw [System.Management.Automation.PSArgumentException]::new(
            "InputObject must identify the Redis Enterprise database named 'default'.")
    }

    return @{
        SubscriptionId = $identityValues['SubscriptionId']
        ResourceGroupName = $identityValues['ResourceGroupName']
        ClusterName = $identityValues['ClusterName']
        DatabaseName = 'default'
    }
}

function Update-AzRedisEnterpriseCacheDatabase {
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.PreviewMessage("**********************************************************************************************`n
    * This cmdlet will undergo a breaking change in Az v16.0.0, to be released in May 2026. *`n
    * At least one change applies to this cmdlet.                                                     *`n
    * See all possible breaking changes at https://go.microsoft.com/fwlink/?linkid=2333486            *`n
    ***************************************************************************************************")]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IDatabase])]
    [CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
        [Alias('Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the Redis Enterprise cluster.
        ${ClusterName},

        [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='UpdateExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PSArgumentCompleterAttribute("Disabled", "Enabled")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # This property can be Enabled/Disabled to allow or deny access with the current access keys.
        # Can be updated even after database is created.
        ${AccessKeysAuthentication},

        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PSArgumentCompleterAttribute("Encrypted", "Plaintext")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # Specifies whether redis clients can connect using TLS-encrypted or plaintext redis protocols.
        # Allowed values: Encrypted, Plaintext
        ${ClientProtocol},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PSArgumentCompleterAttribute("AllKeysLFU", "AllKeysLRU", "AllKeysRandom", "VolatileLRU", "VolatileLFU", "VolatileTTL", "VolatileRandom", "NoEviction")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # Redis eviction policy.
        # Allowed values: AllKeysLFU, AllKeysLRU, AllKeysRandom, VolatileLRU, VolatileLFU, VolatileTTL, VolatileRandom, NoEviction
        ${EvictionPolicy},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # [Preview] Sets whether AOF persistence is enabled.
        # After enabling AOF persistence, you will be unable to disable it.
        # Support for disabling AOF persistence after enabling will be added at a later date.
        ${AofPersistenceEnabled},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PSArgumentCompleterAttribute("1s")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # [Preview] Sets the frequency at which data is written to disk if AOF persistence is enabled.
        # Allowed values: 1s, always
        ${AofPersistenceFrequency},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # [Preview] Sets whether RDB persistence is enabled.
        # After enabling RDB persistence, you will be unable to disable it.
        # Support for disabling RDB persistence after enabling will be added at a later date.
        ${RdbPersistenceEnabled},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.PSArgumentCompleterAttribute("1h", "6h", "12h")]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
        [System.String]
        # [Preview] Sets the frequency at which a snapshot of the database is created if RDB persistence is enabled.
        # Allowed values: 1h, 6h, 12h
        ${RdbPersistenceFrequency},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

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

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

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
        $getParameters = @{}
        $putParameters = @{}
        $runtimeParameterNames = @(
            'DefaultProfile',
            'Break',
            'HttpPipelineAppend',
            'HttpPipelinePrepend',
            'Proxy',
            'ProxyCredential',
            'ProxyUseDefaultCredentials'
        )

        foreach ($parameterName in $runtimeParameterNames) {
            if ($PSBoundParameters.ContainsKey($parameterName)) {
                $getParameters[$parameterName] = $PSBoundParameters[$parameterName]
                $putParameters[$parameterName] = $PSBoundParameters[$parameterName]
            }
        }

        foreach ($parameterName in @('AsJob', 'NoWait')) {
            if ($PSBoundParameters.ContainsKey($parameterName)) {
                $putParameters[$parameterName] = $PSBoundParameters[$parameterName]
            }
        }

        foreach ($parameterName in @('WhatIf', 'Confirm')) {
            if ($PSBoundParameters.ContainsKey($parameterName)) {
                $putParameters[$parameterName] = $PSBoundParameters[$parameterName]
            }
        }

        if ($PSCmdlet.ParameterSetName -eq 'UpdateViaIdentityExpanded') {
            $identityParameters = Resolve-AzRedisEnterpriseCacheDatabaseIdentity -InputObject $InputObject
            foreach ($parameterName in @('SubscriptionId', 'ResourceGroupName', 'ClusterName', 'DatabaseName')) {
                $getParameters[$parameterName] = $identityParameters[$parameterName]
                $putParameters[$parameterName] = $identityParameters[$parameterName]
            }
        } else {
            $getParameters['ClusterName'] = $ClusterName
            $getParameters['ResourceGroupName'] = $ResourceGroupName
            $getParameters['DatabaseName'] = 'default'
            $putParameters['ClusterName'] = $ClusterName
            $putParameters['ResourceGroupName'] = $ResourceGroupName
            $putParameters['DatabaseName'] = 'default'
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $getParameters['SubscriptionId'] = $SubscriptionId
                $putParameters['SubscriptionId'] = $SubscriptionId
            }
        }

        $currentDatabase = Az.RedisEnterpriseCache.internal\Get-AzRedisEnterpriseCacheDatabase @getParameters

        $propertyMappings = @{
            AccessKeysAuthentication = 'AccessKeysAuthentication'
            ClientProtocol = 'ClientProtocol'
            EvictionPolicy = 'EvictionPolicy'
            AofPersistenceEnabled = 'PersistenceAofEnabled'
            AofPersistenceFrequency = 'PersistenceAofFrequency'
            RdbPersistenceEnabled = 'PersistenceRdbEnabled'
            RdbPersistenceFrequency = 'PersistenceRdbFrequency'
            ClusteringPolicy = 'ClusteringPolicy'
            DeferUpgrade = 'DeferUpgrade'
            GroupNickname = 'GeoReplicationGroupNickname'
            LinkedDatabase = 'GeoReplicationLinkedDatabase'
            Module = 'Module'
            Port = 'Port'
        }

        foreach ($parameterName in $propertyMappings.Keys) {
            $propertyName = $propertyMappings[$parameterName]
            if ($null -ne $currentDatabase.$propertyName) {
                $putParameters[$parameterName] = $currentDatabase.$propertyName
            }
        }

        foreach ($parameterName in @(
            'AccessKeysAuthentication',
            'ClientProtocol',
            'EvictionPolicy',
            'AofPersistenceEnabled',
            'AofPersistenceFrequency',
            'RdbPersistenceEnabled',
            'RdbPersistenceFrequency')) {
            if ($PSBoundParameters.ContainsKey($parameterName)) {
                $putParameters[$parameterName] = $PSBoundParameters[$parameterName]
            }
        }

        Az.RedisEnterpriseCache.internal\New-AzRedisEnterpriseCacheDatabase @putParameters
    }
}
