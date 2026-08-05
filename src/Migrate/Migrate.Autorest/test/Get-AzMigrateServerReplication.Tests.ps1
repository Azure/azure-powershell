$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateServerReplication.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMigrateServerReplication' {
    It 'ListByName' {
        $output = Get-AzMigrateServerReplication -ProjectName $env.migProjectName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetBySRSID' {
        $output = Get-AzMigrateServerReplication -TargetObjectID $env.migMachineId -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetBySDSID' {
        $output = Get-AzMigrateServerReplication -DiscoveredMachineId $env.migGetSDSMachineID -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByInputObject' {
        $output = Get-AzMigrateServerReplication -TargetObjectID $env.migMachineId -SubscriptionId $env.migSubscriptionId
        $output = Get-AzMigrateServerReplication -InputObject $output -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ListById' {
        $output = Get-AzMigrateServerReplication -ProjectID $env.migProjectId -ResourceGroupID $env.migResourceGroupId -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
