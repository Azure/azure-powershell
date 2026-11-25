# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

Describe 'Switch-AzDocumentDBMongoCluster offline requests' {
    BeforeAll {
        if (-not (Get-Module Az.DocumentDB)) {
            throw 'Import the built Az.DocumentDB module in the guarded offline runner before running request tests.'
        }

        . (Join-Path $PSScriptRoot 'DocumentDB.RequestTestHelpers.ps1')
        $script:promotionRequestTestState = Initialize-DocumentDBRequestTest
    }

    AfterAll {
        if ($script:promotionRequestTestState) {
            Restore-DocumentDBRequestTest -State $script:promotionRequestTestState
        }
    }

    BeforeEach {
        $subscriptionId = '00000000-0000-0000-0000-000000000001'
        $clusterPath = "/subscriptions/$subscriptionId/resourceGroups/offline-rg/providers/Microsoft.DocumentDB/mongoClusters"
        $replicaPath = "$clusterPath/offline-replica"
        $script:promotionParameters = @{
            Name              = 'offline-replica'
            ResourceGroupName = 'offline-rg'
            SubscriptionId    = $subscriptionId
            SourceCluster     = 'offline-source'
            Confirm           = $false
            ErrorAction       = 'Stop'
        }
        $script:promotionReplicaBody = @{
            id         = $replicaPath
            name       = 'offline-replica'
            type       = 'Microsoft.DocumentDB/mongoClusters'
            location   = 'eastus'
            properties = @{
                provisioningState = 'Succeeded'
                replica           = @{
                    sourceResourceId = "$clusterPath/offline-source"
                }
            }
        }
    }

    It 'serializes <Option> with explicit mode <ExplicitMode> using the stable API' -TestCases @(
        @{ Option = 'Planned'; ExplicitMode = $false }
        @{ Option = 'Forced'; ExplicitMode = $false }
        @{ Option = 'Planned'; ExplicitMode = $true }
        @{ Option = 'Forced'; ExplicitMode = $true }
    ) {
        param($Option, $ExplicitMode)

        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = ($script:promotionReplicaBody | ConvertTo-Json -Depth 10) }
            @{ Method = 'POST'; StatusCode = 200 }
        )
        if ($ExplicitMode) {
            $script:promotionParameters['Mode'] = 'Switchover'
        }

        $result = Switch-AzDocumentDBMongoCluster @script:promotionParameters -PromoteOption $Option `
            -HttpPipelinePrepend $capture.Pipeline

        @($result).Count | Should -Be 0
        $capture.Requests.Count | Should -Be 2
        $capture.Requests[0].Method | Should -Be 'GET'
        ([uri]$capture.Requests[0].RequestUri).AbsolutePath | Should -Be $replicaPath
        $capture.Requests[1].Method | Should -Be 'POST'
        ([uri]$capture.Requests[1].RequestUri).AbsolutePath | Should -Be "$replicaPath/promote"
        foreach ($request in $capture.Requests) {
            ([uri]$request.RequestUri).Query | Should -Be '?api-version=2026-09-01'
        }
        $capture.Requests[1].ContentType | Should -Match '^application/json'
        $body = $capture.Requests[1].Content | ConvertFrom-Json
        $body.promoteOption | Should -BeExactly $Option
        @($body.PSObject.Properties.Name) | Should -Not -Contain 'sourceCluster'
        if ($ExplicitMode) {
            $body.mode | Should -BeExactly 'Switchover'
        } else {
            @($body.PSObject.Properties.Name) | Should -Not -Contain 'mode'
        }
    }

    It 'accepts a case-insensitive full source ID and preserves PassThru without an extra GET' {
        $sourceId = '/subscriptions/00000000-0000-0000-0000-000000000002/resourceGroups/source-rg/providers/Microsoft.DocumentDB/mongoClusters/source'
        $script:promotionReplicaBody.properties.replica.sourceResourceId = $sourceId
        $script:promotionParameters['SourceCluster'] = $sourceId.ToUpperInvariant()
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = ($script:promotionReplicaBody | ConvertTo-Json -Depth 10) }
            @{ Method = 'POST'; StatusCode = 200 }
        )

        $result = Switch-AzDocumentDBMongoCluster @script:promotionParameters -PromoteOption Planned -PassThru `
            -HttpPipelinePrepend $capture.Pipeline

        @($result).Count | Should -Be 1
        $result | Should -BeOfType ([bool])
        $result | Should -Be $true
        $capture.Requests.Count | Should -Be 2
        ($capture.Requests[1].Content | ConvertFrom-Json).promoteOption | Should -BeExactly 'Planned'
    }

    It 'rejects replica source "<ActualSource>" before sending a write' -TestCases @(
        @{ ActualSource = 'another-source' }
        @{ ActualSource = $null }
    ) {
        param($ActualSource)

        $script:promotionReplicaBody.properties.replica.sourceResourceId = $ActualSource
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = ($script:promotionReplicaBody | ConvertTo-Json -Depth 10) }
        )

        {
            Switch-AzDocumentDBMongoCluster @script:promotionParameters -PromoteOption Planned `
                -HttpPipelinePrepend $capture.Pipeline
        } | Should -Throw 'does not match the provided -SourceCluster'

        $capture.Requests.Count | Should -Be 1
        $capture.Requests[0].Method | Should -Be 'GET'
        ([uri]$capture.Requests[0].RequestUri).Query | Should -Be '?api-version=2026-09-01'
    }

    It 'validates the source but sends no write under WhatIf' {
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'GET'; Body = ($script:promotionReplicaBody | ConvertTo-Json -Depth 10) }
        )

        $result = Switch-AzDocumentDBMongoCluster @script:promotionParameters -PromoteOption Planned -WhatIf `
            -HttpPipelinePrepend $capture.Pipeline

        @($result).Count | Should -Be 0
        $capture.Requests.Count | Should -Be 1
        $capture.Requests[0].Method | Should -Be 'GET'
        ([uri]$capture.Requests[0].RequestUri).Query | Should -Be '?api-version=2026-09-01'
    }
}
