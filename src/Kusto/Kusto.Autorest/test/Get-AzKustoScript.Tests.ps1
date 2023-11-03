Describe 'Get-AzKustoScript' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoScript.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }

    It 'List' {
        $continueOnErrors = $false
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr4
        $databaseFullName = $clusterName + "/" + $databaseName
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"

        # { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
        
        $databaseCreated = New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location -SubscriptionId $env.SubscriptionId
        
        { New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent } | Should -Not -Throw
        $ScriptList = Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId
        
        Validate_Script $ScriptList "tag1" $continueOnErrors $clusterName $databaseName "testScript"

        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }

    It 'Get' {
        $continueOnErrors = $false
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr4
        $databaseFullName = $clusterName + "/" + $databaseName
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"

        $databaseCreated = New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location -SubscriptionId $env.SubscriptionId

        { New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent } | Should -Not -Throw
        $Script = Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId
               
        Validate_Script $Script "tag1" $continueOnErrors $clusterName $databaseName "testScript"

        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
