# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

Describe 'Get-AzDocumentDBMongoClusterConnectionString offline output' {
    BeforeAll {
        if (-not (Get-Module Az.DocumentDB)) {
            throw 'Import the built Az.DocumentDB module in the guarded offline runner before running request tests.'
        }

        . (Join-Path $PSScriptRoot 'DocumentDB.RequestTestHelpers.ps1')
        $script:connectionRequestTestState = Initialize-DocumentDBRequestTest
    }

    AfterAll {
        if ($script:connectionRequestTestState) {
            Restore-DocumentDBRequestTest -State $script:connectionRequestTestState
        }
    }

    It 'returns both connection-string values through ConnectionString1 under strict mode' {
        Set-StrictMode -Version Latest
        $expectedValues = @('mongodb://first.invalid', 'mongodb://second.invalid')
        $response = @{
            connectionStrings = @(
                @{ name = 'First'; connectionString = $expectedValues[0] }
                @{ name = 'Second'; connectionString = $expectedValues[1] }
            )
        } | ConvertTo-Json -Depth 4
        $capture = New-DocumentDBRequestCapture -Responses @(
            @{ Method = 'POST'; Body = $response }
        )

        $results = @(Get-AzDocumentDBMongoClusterConnectionString -MongoClusterName 'offline-cluster' `
            -ResourceGroupName 'offline-rg' -SubscriptionId '00000000-0000-0000-0000-000000000000' `
            -HttpPipelinePrepend $capture.Pipeline -Confirm:$false -ErrorAction Stop)

        $capture.Requests.Count | Should -Be 1
        ([uri]$capture.Requests[0].RequestUri).Query | Should -Be '?api-version=2026-09-01'
        $results.Count | Should -Be 2
        for ($index = 0; $index -lt $results.Count; $index++) {
            # Assert booleans so failure output never includes a connection-string value.
            [string]::IsNullOrEmpty($results[$index].ConnectionString1) | Should -Be $false
            ($results[$index].ConnectionString1 -ceq $expectedValues[$index]) | Should -Be $true
        }
    }
}
