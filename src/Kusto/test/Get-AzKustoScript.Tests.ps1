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
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"
        
        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location -SubscriptionId $env.SubscriptionId

        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent
        $ScriptList = Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId

        Validate_Script $ScriptList "tag1" $continueOnErrors $clusterName $databaseName "testScript"

        Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name
    }

    It 'Get' {
        $continueOnErrors = $false
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"
        
        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent
        $script = Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId
               
        Validate_Script $script "tag1" $continueOnErrors $clusterName $databaseName "testScript"

        Remove-AzKustoScript -InputObject $script
    }

    It 'GetViaIdentity' {
        $continueOnErrors = $false
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"

        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent
        $script = Get-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name "testScript" -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId
        
        $script = Get-AzKustoScript -InputObject $script

        Validate_Script $script "tag1" $continueOnErrors $clusterName $databaseName "testScript"

        Remove-AzKustoScript -InputObject $script
    }
}
