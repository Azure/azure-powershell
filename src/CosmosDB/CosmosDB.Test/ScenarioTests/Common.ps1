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
.SYNOPSIS
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($provider)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
    {
        $namespace = $provider.Split("/")[0]  
        if($provider.Contains("/"))  
        {  
            $type = $provider.Substring($namespace.Length + 1)  
            $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}  
  
            if ($location -eq $null) 
            {  
                return "West US"  
            } else 
            {  
                return $location.Locations[0]  
            }  
        }
        
        return "West US"
    }

    return "WestUS"
}

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-CreateResourceGroup
{
    $resourceGroupName = getAssetName
    $rglocation = Get-ProviderLocation "North Europe"
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -location $rglocation -Force
    return $resourceGroup
}

<#
.SYNOPSIS
Asserts if two tags are equal
#>
function Assert-Tags($tags1, $tags2)
{
    if($tags1.count -ne $tags2.count)
    {
        throw "Tag size not equal. Tag1: $tags1.count Tag2: $tags2.count"
    }

    foreach($key in $tags1.Keys)
    {
        if($tags1[$key] -ne $tags2[$key])
        {
            throw "Tag content not equal. Key:$key Tags1:" +  $tags1[$key] + "Tags2:" + $tags2[$key]
        }
    }
}

<#
.SYNOPSIS
Asserts if two compression types are equal
#>
function Assert-CompressionTypes($types1, $types2)
{
    if($types1.Count -ne $types1.Count)
    {
        throw "Array size not equal. Types1: $types1.count Types2: $types2.count"
    }

    foreach($value1 in $types1)
    {
        $found = $false
        foreach($value2 in $types2)
        {
            if($value1.CompareTo($value2) -eq 0)
            {
                $found = $true
                break
            }
        }
        if(-Not($found))
        {
            throw "Compression content not equal. " + $value1 + " cannot be found in second array"
        }
    }
}

<#
.SYNOPSIS
Sleep in record mode only
#>
function SleepInRecordMode ([int]$SleepIntervalInSec)
{
    $mode = $env:AZURE_TEST_MODE
    if ( $mode -ne $null -and $mode.ToUpperInvariant() -eq "RECORD")
    {
        Wait-Seconds $SleepIntervalInSec 
    }
}

<#
.SYNOPSIS
Generates a unique, per-test account/resource name that is recorded during Record mode
and replayed identically during Playback (via HttpMockServer), instead of hardcoding a
static name. This avoids "DNS record ... already taken" collisions against globally-unique
CosmosDB account names left over from prior runs.
#>
function Get-CosmosDBUniqueName([string]$prefix)
{
    return getAssetName $prefix
}

<#
.SYNOPSIS
Polls until a Cosmos DB account reaches ProvisioningState=Succeeded, instead of a blind
Start-Sleep/Start-TestSleep. Throws if the timeout elapses first.
#>
function Wait-CosmosAccountProvisioned
{
    param(
        [Parameter(Mandatory = $true)][string]$ResourceGroupName,
        [Parameter(Mandatory = $true)][string]$AccountName,
        [int]$TimeoutSeconds = 600,
        [int]$PollIntervalSeconds = 10
    )
    $start = Get-Date
    while ($true) {
        try {
            $acct = Get-AzCosmosDBAccount -ResourceGroupName $ResourceGroupName -Name $AccountName -ErrorAction Stop
            if ($acct -and $acct.ProvisioningState -eq 'Succeeded') { return $acct }
        } catch {
            # swallow transient errors while the resource propagates
        }
        if ((Get-Date) -gt $start.AddSeconds($TimeoutSeconds)) {
            throw "Cosmos DB account '$AccountName' in resource group '$ResourceGroupName' did not reach ProvisioningState=Succeeded within $TimeoutSeconds seconds."
        }
        Start-TestSleep -s $PollIntervalSeconds
    }
}

<#
.SYNOPSIS
Generic poller: repeatedly evaluates a scriptblock until it returns a truthy value,
instead of a blind Start-Sleep. Use for "wait until resource is visible/gone" scenarios
(e.g. Gremlin database/graph create, delete, or restore visibility).
#>
function Wait-CosmosDBCondition
{
    param(
        [Parameter(Mandatory = $true)][scriptblock]$Condition,
        [string]$Message = "condition to be met",
        [int]$TimeoutSeconds = 300,
        [int]$PollIntervalSeconds = 10
    )
    $start = Get-Date
    while ($true) {
        $result = $false
        try { $result = & $Condition } catch { $result = $false }
        if ($result) { return }
        if ((Get-Date) -gt $start.AddSeconds($TimeoutSeconds)) {
            throw "Timed out after $TimeoutSeconds seconds waiting for $Message."
        }
        Start-TestSleep -s $PollIntervalSeconds
    }
}

<#
.SYNOPSIS
Polls a Cosmos DB account's backup-policy migration until it reaches a terminal state
(Completed/Failed), instead of a fixed blind sleep followed by a single unconditional check.
#>
function Wait-CosmosDBBackupPolicyMigration
{
    param(
        [Parameter(Mandatory = $true)][string]$ResourceGroupName,
        [Parameter(Mandatory = $true)][string]$AccountName,
        [int]$TimeoutSeconds = 900,
        [int]$PollIntervalSeconds = 30
    )
    $start = Get-Date
    $account = Get-AzCosmosDBAccount -ResourceGroupName $ResourceGroupName -Name $AccountName
    while (
        $account.BackupPolicy.BackupPolicyMigrationState.Status -ne "Completed" -and
        $account.BackupPolicy.BackupPolicyMigrationState.Status -ne "Failed" -and
        $account.BackupPolicy.BackupType -ne "Continuous"
    ) {
        if ((Get-Date) -gt $start.AddSeconds($TimeoutSeconds)) {
            throw "Backup policy migration for account '$AccountName' did not complete within $TimeoutSeconds seconds."
        }
        Start-TestSleep -s $PollIntervalSeconds
        $account = Get-AzCosmosDBAccount -ResourceGroupName $ResourceGroupName -Name $AccountName
    }
    return $account
}