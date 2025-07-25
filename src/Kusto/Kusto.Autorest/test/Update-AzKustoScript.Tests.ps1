Describe 'Update-AzKustoScript' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzKustoScript.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Update' {
        $continueOnErrors = $false
        $clusterName = $env.kustoClusterName
        $databaseName = "testdatabase" + $env.rstr4
        $scriptContent = ".create table table3 (Level:string, Timestamp:datetime, UserId:string, TraceId:string, Message:string, ProcessId:int32)"
        $scriptName = "testScript2"
        New-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $clusterName -Name $databaseName -Kind ReadWrite -Location $env.location
        New-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag1" -ScriptContent $scriptContent -PrincipalPermissionsAction "RetainPermissionOnScriptCompletion" -ScriptLevel "Database"  # this must be set to 'Retain'

        $Script = Update-AzKustoScript -ClusterName $clusterName -DatabaseName $databaseName -Name $scriptName -ResourceGroupName $env.resourceGroupName -SubscriptionId $env.SubscriptionId -ContinueOnError -ForceUpdateTag "tag2" -ScriptContent $scriptContent -PrincipalPermissionsAction "RemovePermissionOnScriptCompletion" -ScriptLevel "Database"

        Validate_Inline_Script $Script "tag2" $continueOnErrors $clusterName $databaseName $scriptName -PrincipalPermissionsAction "RemovePermissionOnScriptCompletion" -ScriptLevel "Database"

        { Remove-AzKustoDatabase -ResourceGroupName $env.resourceGroupName -ClusterName $env.kustoClusterName -Name $databaseName } | Should -Not -Throw
    }
}
