# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

if (($null -ne $TestName) -and ($TestName -notcontains 'Switch-AzDocumentDBMongoCluster Planned')) {
    return
}

. (Join-Path $PSScriptRoot 'loadEnv.ps1')
if ($TestMode -notin @('playback', 'record', 'live')) {
    throw 'Select an explicit test mode before running the Planned promotion scenario.'
}

$script:TestRecordingFile = Join-Path $PSScriptRoot 'Switch-AzDocumentDBMongoCluster.Planned.Recording.json'
$mockingPath = [System.IO.Path]::Combine(
    (Split-Path -Parent $PSScriptRoot), 'generated', 'runtime', 'HttpPipelineMocking.ps1')
if (-not (Test-Path -LiteralPath $mockingPath)) {
    throw 'Build the DocumentDB module before running the Planned promotion scenario.'
}
. $mockingPath

Describe 'Switch-AzDocumentDBMongoCluster Planned' {
    BeforeAll {
        $script:plannedResourceGroupCreated = $false
        foreach ($setting in @('SubscriptionId', 'plannedRg', 'plannedCluster', 'plannedReplica', 'location', 'replicaLocation')) {
            if ([string]::IsNullOrWhiteSpace($env.$setting)) {
                throw "The Planned promotion scenario requires the '$setting' test setting."
            }
        }

        $rg = $env.plannedRg
        $cluster = $env.plannedCluster
        $replica = $env.plannedReplica
        $loc = $env.location
        $replicaLoc = $env.replicaLocation
        if (($cluster -eq $replica) -or ($loc -eq $replicaLoc)) {
            throw 'The Planned promotion scenario requires distinct source and replica names and regions.'
        }
        if ($rg -in @($env.promoteRg, $env.replicaRg)) {
            throw 'The Planned promotion scenario requires its own resource group and topology.'
        }

        $resourceBase = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$rg/providers/Microsoft.DocumentDB/mongoClusters"
        $sourceId = "$resourceBase/$cluster"
        $replicaId = "$resourceBase/$replica"
        if ($TestMode -ne 'playback') {
            New-AzResourceGroup -Name $rg -Location $loc -ErrorAction Stop | Out-Null
            $script:plannedResourceGroupCreated = $true
        }

        New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc | Out-Null
        $createdReplica = New-AzDocumentDBReplica -Name $replica -ResourceGroupName $rg `
            -Location $replicaLoc -SourceCluster $cluster
        $createdReplica.Id | Should -Be $replicaId
        $createdReplica.ProvisioningState | Should -Be 'Succeeded'
        $createdReplica.ReplicaRole | Should -Be 'GeoAsyncReplica'
        $createdReplica.ReplicaSourceResourceId | Should -Be $sourceId
    }

    AfterAll {
        if (($TestMode -ne 'playback') -and $script:plannedResourceGroupCreated) {
            Remove-AzResourceGroup -Name $rg -Force -ErrorAction Stop | Out-Null
        }
    }

    It 'promotes a replica with Planned and preserves the replication link' {
        Switch-AzDocumentDBMongoCluster -Name $replica -ResourceGroupName $rg `
            -SourceCluster $cluster -Mode Switchover -PromoteOption Planned -Confirm:$false

        # Both endpoints may take time to expose the new roles after the operation completes.
        foreach ($attempt in 1..40) {
            $promoted = Get-AzDocumentDBMongoCluster -Name $replica -ResourceGroupName $rg
            $formerPrimary = Get-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg
            if (($promoted.ProvisioningState -in @('Failed', 'Canceled')) -or
                ($formerPrimary.ProvisioningState -in @('Failed', 'Canceled'))) {
                throw 'The Planned switchover ended in a failed provisioning state.'
            }
            if (($promoted.ProvisioningState -eq 'Succeeded') -and
                ($promoted.ReplicaRole -eq 'Primary') -and
                ($formerPrimary.ProvisioningState -eq 'Succeeded') -and
                ($formerPrimary.ReplicaRole -eq 'GeoAsyncReplica') -and
                ($formerPrimary.ReplicaSourceResourceId -eq $replicaId)) {
                break
            }
            if ($attempt -lt 40) {
                Start-TestSleep -Seconds 20
            }
        }

        $promoted.Id | Should -Be $replicaId
        $promoted.ProvisioningState | Should -Be 'Succeeded'
        $promoted.ReplicaRole | Should -Be 'Primary'
        $formerPrimary.Id | Should -Be $sourceId
        $formerPrimary.ProvisioningState | Should -Be 'Succeeded'
        $formerPrimary.ReplicaRole | Should -Be 'GeoAsyncReplica'
        $formerPrimary.ReplicaSourceResourceId | Should -Be $replicaId
    }
}
