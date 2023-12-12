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
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr4
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"
        
        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location
        
        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent
        
        Remove-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId

        { Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId } | Should -Throw
        
        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr4
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"

        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location

        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent

        $kustoScript = Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId 
        
        Remove-AzKustoScript -InputObject $kustoScript

        { Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId } | Should -Throw

        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }
}
