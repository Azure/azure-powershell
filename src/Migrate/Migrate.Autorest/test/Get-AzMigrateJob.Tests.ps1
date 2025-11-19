$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

$JobName = "c79dc2d7-374f-4ec1-affe-1bcb12328125"
$JobId = "/Subscriptions/6b72781d-4550-419b-a56e-44055341a88e/resourceGroups/cbtgqlsrcrg/providers/Microsoft.RecoveryServices/vaults/ecygqlapp4055vault/replicationJobs/c79dc2d7-374f-4ec1-affe-1bcb12328125"

Describe 'Get-AzMigrateJob' {
    It 'ListByName' {
       $output = Get-AzMigrateJob -ProjectName $env.migProjectName -ResourceGroupName $env.migResourceGroup -SubscriptionId $env.migSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByName' {
       $output = Get-AzMigrateJob -ProjectName $env.migProjectName -ResourceGroupName $env.migResourceGroup -JobName $JobName -SubscriptionId $env.migSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByID' {
       $output = Get-AzMigrateJob -JobID $JobId -SubscriptionId $env.migSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByInputObject' {
        $output = Get-AzMigrateJob -JobID $JobId -SubscriptionId $env.migSubscriptionId
        $output = Get-AzMigrateJob -InputObject $output -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ListById' {
        $output = Get-AzMigrateJob -ProjectID $env.migProjectId -ResourceGroupID $env.migResourceGroupId -SubscriptionId $env.migSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
