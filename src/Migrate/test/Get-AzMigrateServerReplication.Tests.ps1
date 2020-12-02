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
        $output = Get-AzMigrateServerReplication -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetBySRSID' {
        $output = Get-AzMigrateServerReplication -TargetObjectID $env.srsMachineId -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetBySDSID' {
        $output = Get-AzMigrateServerReplication -DiscoveredMachineId $env.srsGetSDSMachineID -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByInputObject' {
        $output = Get-AzMigrateServerReplication -TargetObjectID $env.srsMachineId -SubscriptionId $env.srsSubscriptionId
        $output = Get-AzMigrateServerReplication -InputObject $output -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ListById' {
        $output = Get-AzMigrateServerReplication -ProjectID $env.srsProjectId -ResourceGroupID $env.srsResourceGroupId -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
