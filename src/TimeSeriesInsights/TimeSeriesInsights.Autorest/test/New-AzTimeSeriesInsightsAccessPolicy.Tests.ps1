$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzTimeSeriesInsightsAccessPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzTimeSeriesInsightsAccessPolicy' {
    It 'CreateExpanded' {
        $kind = 'Gen1'
        $sku01 = 'S1'
        $timeSpan = New-TimeSpan -Days 1 -Hours 1 -Minutes 25
        $capacity = 2
        $environmentName = $env.rstrenv01
        New-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName -Kind $kind -Location $env.location -Sku $sku01 -DataRetentionTime $timeSpan -Capacity $capacity
        
        $role = 'Reader'
        $accessPolicyName = $env.rstrap01
        New-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup -PrincipalObjectId $env.principalObjectId -Role $role -Name $env.rstrap01
        $policy = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup -Name $accessPolicyName
        $policy.Name | Should -Be $accessPolicyName
    }
}
