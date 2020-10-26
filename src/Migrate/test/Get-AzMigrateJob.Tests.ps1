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

Describe 'Get-AzMigrateJob' {
    It 'ListByName' {
       $output = Get-AzMigrateJob -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup -SubscriptionId $env.srsSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByName' {
       $output = Get-AzMigrateJob -ProjectName $env.srsProjectName -ResourceGroupName $env.srsResourceGroup -JobName $env.srsJobName -SubscriptionId $env.srsSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByID' {
       $output = Get-AzMigrateJob -JobID $env.srsJobId -SubscriptionId $env.srsSubscriptionId
       $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByInputObject' {
	$output = Get-AzMigrateJob -JobID $env.srsJobId -SubscriptionId $env.srsSubscriptionId
        $output = Get-AzMigrateJob -InputObject $output -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'ListById' {
        $output = Get-AzMigrateJob -ProjectID $env.srsProjectId -ResourceGroupID $env.srsResourceGroupId -SubscriptionId $env.srsSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
