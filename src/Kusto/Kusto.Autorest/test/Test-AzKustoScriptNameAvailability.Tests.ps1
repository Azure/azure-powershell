Describe 'Test-AzKustoScriptNameAvailability' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoScriptNameAvailability.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CheckExpanded' {
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr4
        $scriptName = "testScript" + $env.rstr4
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"

        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location

        $testNameResult = Test-AzKustoScriptNameAvailability -ClusterName $clusterName -DatabaseName $databaseName -ResourceGroupName $env.resourceGroupName -Name $scriptName
        $testNameResult.NameAvailable | Should -Be $true

        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ScriptContent $scriptContent

        $testNameResult = Test-AzKustoScriptNameAvailability -ClusterName $clusterName -DatabaseName $databaseName -ResourceGroupName $env.resourceGroupName -Name $scriptName
        $testNameResult.NameAvailable | Should -Be $false

        { Remove-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $env.resourceGroupName } | Should -Not -Throw

        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }

    It 'CheckViaIdentityExpanded' {
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr5
        $scriptName = "testScript" + $env.rstr5
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"

        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location
        $database = Get-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName

        $testNameResult = Test-AzKustoScriptNameAvailability -InputObject $database -Name $scriptName
        $testNameResult.NameAvailable | Should -Be $true

        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ScriptContent $scriptContent

        $testNameResult = Test-AzKustoScriptNameAvailability -InputObject $database -Name $scriptName
        $testNameResult.NameAvailable | Should -Be $false

        { Remove-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $env.resourceGroupName } | Should -Not -Throw
        
        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $name } | Should -Not -Throw
    }
}
