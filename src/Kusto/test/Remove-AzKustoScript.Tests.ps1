Describe 'Remove-AzKustoScript' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoScript.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Delete' {
        $continueOnErrors = $false
        $clusterName = $env.clusterName
        $databaseName = "testdatabase" + $env.rstr4
        $databaseFullName = $clusterName + "/" + $databaseName

        $databaseCreated = New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location
        
        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $env.scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag $env.forceUpdateTag -ScriptUrl $env.scriptUrl -ScriptUrlSasToken $env.scriptUrlSasToken
        
        Remove-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $env.scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId

        { Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $env.scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId } | Should -Throw
        
        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.clusterName -Name $name } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
