$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzImportExport.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzImportExport' {
    It 'List' {
        $job = Get-AzImportExport 
        $job.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $job = Get-AzImportExport -Name $env.jobName -ResourceGroupName $env.resourceGroup
        $job.Name | Should -Be $env.jobName
    }

    It 'List1' {
        $job = Get-AzImportExport -ResourceGroupName $env.resourceGroup
        $job.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.ImportExport/jobs/$($env.jobName)"
        $job = Get-AzImportExport -InputObject $Id
        $job.Name | Should -Be $env.jobName
    }
}
