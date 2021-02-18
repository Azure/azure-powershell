$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzTimeSeriesInsightsAccessPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzTimeSeriesInsightsAccessPolicy' {
    It 'UpdateExpanded' {
        $newRole = 'Contributor'
        $environmentName = $env.tsiEnvName
        $accessPolicy = $env.accessPolicy
        Update-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -Name $accessPolicy -ResourceGroupName $env.ResourceGroup -Role $newRole
        $policy = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -ResourceGroupName $env.ResourceGroup
        $policy.Role | Should -Be $newRole
    }

    It 'UpdateViaIdentityExpanded' {
        $newRole = 'Reader'
        $environmentName = $env.tsiEnvName
        $accessPolicy = $env.accessPolicy
        $policy = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $env.tsiEnvName -ResourceGroupName $env.resourceGroup -Name $env.accessPolicy
        Update-AzTimeSeriesInsightsAccessPolicy -InputObject $policy -Role $newRole
        $policy = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -ResourceGroupName $env.ResourceGroup
        $policy.Role | Should -Be $newRole
    }
}
