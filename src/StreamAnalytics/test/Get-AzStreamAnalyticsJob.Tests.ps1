$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStreamAnalyticsJob.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzStreamAnalyticsJob' {
    It 'List1' {
        $result = Get-AzStreamAnalyticsJob
        $result.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01
        $result.Name | Should -Be $env.job01
    }

    It 'List' {
        $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup
        $result.Count | Should -Be 2
    }

    It 'GetViaIdentity' {
        $result = Get-AzStreamAnalyticsJob -ResourceGroupName $env.resourceGroup -Name $env.job01
        $result = Get-AzStreamAnalyticsJob -InputObject $result
        $result.Name | Should -Be $env.job01
    }
}
