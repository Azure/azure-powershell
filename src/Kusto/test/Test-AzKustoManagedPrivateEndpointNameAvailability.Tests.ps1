Describe 'Test-AzKustoManagedPrivateEndpointNameAvailability' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoManagedPrivateEndpointNameAvailability.Recording.json'
        $currentPath = $PSScriptRoot
        while(-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }

    It 'CheckExpanded' {
        $managedPrivateEndpointName = "test-name-avilability"
        $testResult = Test-AzKustoManagedPrivateEndpointNameAvailability -ClusterName $env.kustoClusterName -ResourceGroupName $env.resourceGroupName -Name $managedPrivateEndpointName -SubscriptionId $env.subscriptionId
        $testResult.NameAvailable | Should -Be $true
    }

    It 'CheckViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
