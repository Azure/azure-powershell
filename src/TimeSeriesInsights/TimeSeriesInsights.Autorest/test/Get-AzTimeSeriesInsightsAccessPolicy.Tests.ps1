$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzTimeSeriesInsightsAccessPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzTimeSeriesInsightsAccessPolicy' {
    It 'List' {
        $policyList = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup
        $policyList.Count | Should -Be 1
    }

    It 'Get' {
        $policy = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup -Name $env.accessPolicy
        $policy.Name | Should -Be $env.accessPolicy
    }

    It 'GetViaIdentity' {
        $policy01 = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup -Name $env.accessPolicy
        $policy = Get-AzTimeSeriesInsightsAccessPolicy -InputObject $policy01
        $policy.Name | Should -Be $env.accessPolicy
    }
}
