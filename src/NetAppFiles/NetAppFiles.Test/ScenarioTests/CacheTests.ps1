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

# ---------------------------------------------------------------------------
# ANF Cache (FlexCache) tests
#
# PREREQUISITE: ON-PREM ONTAP or CVO
# -------------------------------
# Every scenario in this file creates a real ANF Cache (FlexCache) resource
# whose origin lives on an external on-prem ONTAP cluster (typically a Cloud
# Volumes ONTAP / CVO instance). That cluster must be running and reachable
# from the cache's peering subnet BEFORE the test runs:
#
#   $originPeerClusterName  - ONTAP cluster name of the external cluster
#   $originPeerAddresses    - Intercluster LIF IP addresses (one per node)
#   $originPeerVserverName  - External Vserver (SVM) hosting the origin volume
#   $originPeerVolumeName   - External origin volume name
#
# Update Get-CacheOriginPlaceholder below with the real values for your CVO,
# and make sure you can SSH into the CVO from the workstation running the
# test (you will be asked to paste two commands during the run).
#
# WHY THIS TEST IS INTERACTIVE
# ---------------------------
# FlexCache provisioning is a multi-stage handshake between Azure and the
# on-prem ONTAP cluster:
#
#   Creating -> ClusterPeeringOfferSent -> VserverPeeringOfferSent -> Succeeded
#
# At each '*OfferSent' state the service is waiting for the on-prem operator
# to accept the offer on the CVO via SSH. There is no public API to perform
# this acceptance from Azure; it MUST be done on the CVO CLI. The test
# therefore polls cacheState (the unambiguous service-side signal that the
# previous on-prem step completed), prints the exact CVO commands the
# engineer needs to paste, and resumes automatically once the state advances.
# No sentinel files, no Read-Host prompts -- the state machine is the sync.
#
# HOW TO RUN LIVE
# ---------------
# All tests are decorated with [Fact(Skip = LiveOnlySkip)] in CacheTests.cs.
# To run a single test live against real Azure + your CVO:
#
#   1. Edit Get-CacheOriginPlaceholder (below) with your CVO coordinates.
#   2. Remove the Skip argument from the desired [Fact] in CacheTests.cs
#      (e.g. just '[Fact]' instead of '[Fact(Skip = LiveOnlySkip)]').
#   3. Sign in: 'Connect-AzAccount' and 'Set-AzContext -Subscription <id>'.
#   4. From the repo root run (pwsh):
#
#        $env:TEST_HTTPMOCK_MODE = 'Record'
#        $env:AZURE_TEST_MODE    = 'Record'
#        dotnet test src\NetAppFiles\NetAppFiles.Test\NetAppFiles.Test.csproj `
#            --filter "FullyQualifiedName~TestCacheCrud" `
#            --logger "console;verbosity=detailed"
#
#   5. When the console prints '=== ON-PREM ONTAP ACTION REQUIRED ===',
#      SSH into the CVO and paste the literal command block shown.
#      The test resumes automatically; do NOT press any key in the test host.
#
# Re-add the Skip after recording so CI does not attempt live execution.
# ---------------------------------------------------------------------------

# ---------------------------------------------------------------------------
# Live-test tunables for the interactive on-prem ONTAP peering flow.
# Override per environment by editing these before running the test.
# ---------------------------------------------------------------------------
$script:CachePollSec                 = 30
$script:CacheClusterOfferTimeoutMin  = 15
$script:CacheVserverOfferTimeoutMin  = 30
$script:CacheTerminalTimeoutMin      = 30

<#
.SYNOPSIS
Returns $true when the test runner is in HTTP playback mode (replaying recorded
SessionRecords). In that mode all polling/waiting helpers must short-circuit so
recorded test runs do not sleep or write banners to the test output.
#>
function Test-AnfPlaybackMode
{
    try
    {
        return ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -eq 'Playback')
    }
    catch
    {
        # If the type is not loaded we are not running under the test recorder; treat as live.
        return $false
    }
}

<#
.SYNOPSIS
Polls Get-AzNetAppFilesCache until CacheState matches one of $ExpectedStates,
or the timeout elapses. In Playback mode returns immediately without waiting.
Returns the final cache object. Throws on timeout.
#>
function Wait-AnfCacheState
{
    param(
        [Parameter(Mandatory=$true)] [string]   $ResourceGroup,
        [Parameter(Mandatory=$true)] [string]   $AccountName,
        [Parameter(Mandatory=$true)] [string]   $PoolName,
        [Parameter(Mandatory=$true)] [string]   $Name,
        [Parameter(Mandatory=$true)] [string[]] $ExpectedStates,
        [int] $TimeoutMin = 30,
        [int] $PollSec    = $script:CachePollSec
    )

    $cache = Get-AzNetAppFilesCache -ResourceGroupName $ResourceGroup -AccountName $AccountName -PoolName $PoolName -Name $Name

    if (Test-AnfPlaybackMode)
    {
        return $cache
    }

    $expected = ($ExpectedStates -join ',')
    Write-Host "[Wait-AnfCacheState] Waiting for cacheState in [$expected] (timeout ${TimeoutMin}m, poll ${PollSec}s)..."

    $deadline = (Get-Date).AddMinutes($TimeoutMin)
    while ($true)
    {
        $cache = Get-AzNetAppFilesCache -ResourceGroupName $ResourceGroup -AccountName $AccountName -PoolName $PoolName -Name $Name
        $state = $cache.CacheState
        $stamp = (Get-Date).ToString('HH:mm:ss')
        Write-Host "[$stamp] cacheState=$state (waiting for [$expected])"

        if ($ExpectedStates -contains $state)
        {
            return $cache
        }

        if ((Get-Date) -ge $deadline)
        {
            throw "Wait-AnfCacheState: timed out after ${TimeoutMin} minute(s) waiting for cacheState in [$expected]. Last observed: '$state'."
        }

        Start-Sleep -Seconds $PollSec
    }
}

<#
.SYNOPSIS
Emits the on-prem ONTAP peering instructions for the engineer to execute on the
CVO via SSH. Output includes BOTH a labeled JSON block (for programmatic copy)
AND a literal copy-paste block (for paste-under-pressure into the CVO CLI).
In Playback mode this is a no-op so recorded runs stay quiet.
#>
function Write-CacheManualPeeringInstructions
{
    param(
        [Parameter(Mandatory=$true)] [object] $Passphrases,
        [Parameter(Mandatory=$true)] [ValidateSet('Cluster','Vserver')] [string] $Stage
    )

    if (Test-AnfPlaybackMode) { return }

    $bar = ('=' * 78)
    Write-Host ""
    Write-Host $bar
    Write-Host "=== ON-PREM ONTAP ACTION REQUIRED: $Stage Peering"
    Write-Host "=== SSH into the on-prem CVO, then perform the steps below."
    Write-Host "=== Test will resume automatically when cacheState advances."
    Write-Host $bar

    Write-Host "--- BEGIN passphrasesObject (JSON) ---"
    Write-Host ($Passphrases | ConvertTo-Json -Depth 5)
    Write-Host "--- END passphrasesObject (JSON) ---"

    Write-Host ""
    Write-Host "--- BEGIN COPY-PASTE (CVO CLI) ---"
    if ($Stage -eq 'Cluster')
    {
        Write-Host $Passphrases.ClusterPeeringCommand
        Write-Host ""
        Write-Host "# When prompted for the passphrase, paste:"
        Write-Host $Passphrases.ClusterPeeringPassphrase
    }
    else
    {
        Write-Host $Passphrases.VserverPeeringCommand
    }
    Write-Host "--- END COPY-PASTE ---"

    if ($Passphrases.CriticalWarning)
    {
        Write-Host ""
        Write-Host "WARNING: $($Passphrases.CriticalWarning)"
    }
    Write-Host $bar
    Write-Host ""
}

<#
.SYNOPSIS
Drives the full interactive on-prem ONTAP peering flow for a freshly-created
cache. Polls CacheState through ClusterPeeringOfferSent and VserverPeeringOfferSent,
emitting peering instructions for the engineer at each stage, and waits for the
final terminal state. Returns the final cache object (asserted to be Succeeded).
In Playback mode every wait short-circuits and no instructions are emitted.
#>
function Invoke-CacheInteractivePeering
{
    param(
        [Parameter(Mandatory=$true)] [string] $ResourceGroup,
        [Parameter(Mandatory=$true)] [string] $AccountName,
        [Parameter(Mandatory=$true)] [string] $PoolName,
        [Parameter(Mandatory=$true)] [string] $Name
    )

    Wait-AnfCacheState -ResourceGroup $ResourceGroup -AccountName $AccountName -PoolName $PoolName -Name $Name `
        -ExpectedStates @('ClusterPeeringOfferSent') -TimeoutMin $script:CacheClusterOfferTimeoutMin | Out-Null

    $passphrasesObject = Get-AzNetAppFilesCachePeeringPassphrase -ResourceGroupName $ResourceGroup -AccountName $AccountName -PoolName $PoolName -Name $Name
    Write-CacheManualPeeringInstructions -Passphrases $passphrasesObject -Stage Cluster

    Wait-AnfCacheState -ResourceGroup $ResourceGroup -AccountName $AccountName -PoolName $PoolName -Name $Name `
        -ExpectedStates @('VserverPeeringOfferSent') -TimeoutMin $script:CacheVserverOfferTimeoutMin | Out-Null

    Write-CacheManualPeeringInstructions -Passphrases $passphrasesObject -Stage Vserver

    $final = Wait-AnfCacheState -ResourceGroup $ResourceGroup -AccountName $AccountName -PoolName $PoolName -Name $Name `
        -ExpectedStates @('Succeeded','Failed') -TimeoutMin $script:CacheTerminalTimeoutMin

    if (-not (Test-AnfPlaybackMode))
    {
        Assert-AreEqual 'Succeeded' $final.CacheState
    }

    return $final
}

<#
.SYNOPSIS
Returns the placeholder origin-cluster information used by the Cache scenario
tests. Replace these values with real on-prem ONTAP coordinates when re-enabling
the tests.
#>
function Get-CacheOriginPlaceholder
{
    return [pscustomobject]@{
        ClusterName  = "onprem-ontap-cluster"
        Addresses    = @("10.10.0.10", "10.10.0.11")
        VserverName  = "onprem-svm"
        VolumeName   = "onprem-origin-vol"
    }
}

<#
.SYNOPSIS
Provisions a resource group, VNet with a 'caches' subnet and a 'peering'
subnet, an ANF account, and a capacity pool suitable for a Cache. Returns
the provisioning context used by the test bodies.
#>
function New-CacheTestEnvironment
{
    param(
        [string] $ResourceGroup,
        [string] $Location,
        [string] $AccountName,
        [string] $PoolName,
        [long]   $PoolSize     = 4398046511104,
        [string] $ServiceLevel = "Premium"
    )

    $subsId            = (Get-AzureRmContext).Subscription.SubscriptionId
    $vnetName          = "$ResourceGroup-vnet"
    $cacheSubnetName   = "cache-subnet"
    $peeringSubnetName = "peering-subnet"

    New-AzResourceGroup -Name $ResourceGroup -Location $Location -Tags @{Owner = 'b-aubald'}

    $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $ResourceGroup -Location $Location -Name $vnetName -AddressPrefix 10.0.0.0/16

    $cacheDelegation = New-AzDelegation -Name "netAppCaches" -ServiceName "Microsoft.Netapp/volumes"
    Add-AzVirtualNetworkSubnetConfig -Name $cacheSubnetName   -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.1.0/24" -Delegation $cacheDelegation | Set-AzVirtualNetwork | Out-Null
    $virtualNetwork = Get-AzVirtualNetwork -ResourceGroupName $ResourceGroup -Name $vnetName
    Add-AzVirtualNetworkSubnetConfig -Name $peeringSubnetName -VirtualNetwork $virtualNetwork -AddressPrefix "10.0.2.0/24" | Set-AzVirtualNetwork | Out-Null

    $cacheSubnetId   = "/subscriptions/$subsId/resourceGroups/$ResourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$cacheSubnetName"
    $peeringSubnetId = "/subscriptions/$subsId/resourceGroups/$ResourceGroup/providers/Microsoft.Network/virtualNetworks/$vnetName/subnets/$peeringSubnetName"

    $account = New-AzNetAppFilesAccount -ResourceGroupName $ResourceGroup -Location $Location -AccountName $AccountName
    $pool    = New-AzNetAppFilesPool    -ResourceGroupName $ResourceGroup -Location $Location -AccountName $AccountName -PoolName $PoolName -PoolSize $PoolSize -ServiceLevel $ServiceLevel

    return [pscustomobject]@{
        SubscriptionId  = $subsId
        VnetName        = $vnetName
        CacheSubnetId   = $cacheSubnetId
        PeeringSubnetId = $peeringSubnetId
        Account         = $account
        Pool            = $pool
    }
}

<#
.SYNOPSIS
Test Cache CRUD: New / Get / List / Update / Remove.
#>
function Test-CacheCrud
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $gibibyte         = 1024 * 1024 * 1024
    $cacheSize        = 100 * $gibibyte

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName
        $origin = Get-CacheOriginPlaceholder

        # Create cache
        $newCache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("NFSv3")

        # Drive the interactive on-prem ONTAP peering flow to bring the cache to Succeeded.
        Invoke-CacheInteractivePeering -ResourceGroup $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName | Out-Null

        Assert-AreEqual "$accName/$poolName/$cacheName" $newCache.Name
        Assert-AreEqual $cacheSize  $newCache.Size
        Assert-AreEqual $cacheName  $newCache.FilePath
        Assert-NotNull  $newCache.OriginClusterInformation
        Assert-AreEqual $origin.ClusterName $newCache.OriginClusterInformation.PeerClusterName

        # Get by name
        $getCache = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        Assert-AreEqual "$accName/$poolName/$cacheName" $getCache.Name

        # Get by ResourceId
        $getById = Get-AzNetAppFilesCache -ResourceId $getCache.Id
        Assert-AreEqual $getCache.Id $getById.Id

        # List
        $listCaches = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName
        Assert-AreEqual 1 $listCaches.Length

        # Update: change throughput, enable CIFS change notifications, add tag
        $updateTagName  = "Owner"
        $updateTagValue = "b-aubald"
        $updated = Update-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName `
            -ThroughputMibps 64 `
            -CifsChangeNotification "Enabled" `
            -Tag @{$updateTagName = $updateTagValue}

        Assert-AreEqual 64 $updated.ThroughputMibps
        Assert-AreEqual "Enabled" $updated.CifsChangeNotifications
        Assert-True { $updated.Tags.ContainsKey($updateTagName) }

        # WhatIf should not delete
        Remove-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName -WhatIf
        $stillThere = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        Assert-NotNull $stillThere

        # Remove
        Remove-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName

        $deleted = $null
        try
        {
            $deleted = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        }
        catch
        {
            $deleted = $null
        }
        Assert-Null $deleted
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Pipeline binding: pool -> Get caches; cache -> Update / Remove.
#>
function Test-CachePipeline
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $cacheSize        = 100 * 1024 * 1024 * 1024

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName
        $origin = Get-CacheOriginPlaceholder

        $cache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("NFSv3")

        # Drive the interactive on-prem ONTAP peering flow to bring the cache to Succeeded.
        Invoke-CacheInteractivePeering -ResourceGroup $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName | Out-Null

        # Pipe pool to Get-AzNetAppFilesCache
        $listFromPool = $env.Pool | Get-AzNetAppFilesCache
        Assert-AreEqual 1 $listFromPool.Length
        Assert-AreEqual "$accName/$poolName/$cacheName" $listFromPool[0].Name

        # Pipe cache to Update
        $cache | Update-AzNetAppFilesCache -ThroughputMibps 32 | Out-Null
        $updated = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName
        Assert-AreEqual 32 $updated.ThroughputMibps

        # Pipe cache to Remove
        $updated | Remove-AzNetAppFilesCache -PassThru | Out-Null
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Set-AzNetAppFilesCachePool moves a cache to a different capacity pool.
#>
function Test-CachePoolChange
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName1     = Get-ResourceName
    $poolName2     = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $cacheSize        = 100 * 1024 * 1024 * 1024
    $poolSize         = 4398046511104
    $serviceLevel     = "Premium"

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName1
        $origin = Get-CacheOriginPlaceholder

        # Second pool to move into
        $pool2 = New-AzNetAppFilesPool -ResourceGroupName $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName2 -PoolSize $poolSize -ServiceLevel $serviceLevel

        $cache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName1 -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("NFSv3")

        # Drive the interactive on-prem ONTAP peering flow to bring the cache to Succeeded.
        Invoke-CacheInteractivePeering -ResourceGroup $resourceGroup -AccountName $accName -PoolName $poolName1 -Name $cacheName | Out-Null

        # Move to second pool
        $moved = Set-AzNetAppFilesCachePool `
            -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName1 -Name $cacheName `
            -NewPoolResourceId $pool2.Id

        Assert-AreEqual "$accName/$poolName2/$cacheName" $moved.Name

        # Confirm it disappeared from the original pool
        $listInOldPool = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName1
        Assert-AreEqual 0 $listInOldPool.Length

        # Confirm it appears in the new pool
        $listInNewPool = Get-AzNetAppFilesCache -ResourceGroupName $resourceGroup -AccountName $accName -PoolName $poolName2
        Assert-AreEqual 1 $listInNewPool.Length
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Reset-AzNetAppFilesCacheSmbPassword resets the SMB machine account password
for the cache (only meaningful for SMB-enabled caches).
#>
function Test-CacheResetSmbPassword
{
    $resourceGroup = Get-ResourceGroupName
    $accName       = Get-ResourceName
    $poolName      = Get-ResourceName
    $cacheName     = Get-ResourceName

    $resourceLocation = "eastus"
    $cacheSize        = 100 * 1024 * 1024 * 1024

    try
    {
        $env    = New-CacheTestEnvironment -ResourceGroup $resourceGroup -Location $resourceLocation -AccountName $accName -PoolName $poolName
        $origin = Get-CacheOriginPlaceholder

        # Create an SMB-capable cache. NOTE: a real SMB cache typically also requires an
        # Active Directory configured on the parent NetApp account. The AD provisioning is
        # outside the scope of this scenario test - it is part of the prerequisite fixture.
        $cache = New-AzNetAppFilesCache `
            -ResourceGroupName $resourceGroup -Location $resourceLocation `
            -AccountName $accName -PoolName $poolName -Name $cacheName `
            -FilePath $cacheName -Size $cacheSize `
            -CacheSubnetResourceId $env.CacheSubnetId `
            -PeeringSubnetResourceId $env.PeeringSubnetId `
            -EncryptionKeySource "Microsoft.NetApp" `
            -OriginPeerClusterName $origin.ClusterName `
            -OriginPeerAddress     $origin.Addresses `
            -OriginPeerVserverName $origin.VserverName `
            -OriginPeerVolumeName  $origin.VolumeName `
            -ProtocolType @("CIFS") `
            -SmbEncryption "Enabled"

        # Drive the interactive on-prem ONTAP peering flow to bring the cache to Succeeded.
        Invoke-CacheInteractivePeering -ResourceGroup $resourceGroup -AccountName $accName -PoolName $poolName -Name $cacheName | Out-Null

        $reset = Reset-AzNetAppFilesCacheSmbPassword
        Assert-NotNull $reset
        Assert-AreEqual "$accName/$poolName/$cacheName" $reset.Name
    }
    finally
    {
        Clean-ResourceGroup $resourceGroup
    }
}
