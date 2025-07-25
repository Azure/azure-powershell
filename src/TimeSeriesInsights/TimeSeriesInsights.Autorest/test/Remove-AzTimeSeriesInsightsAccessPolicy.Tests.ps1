$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzTimeSeriesInsightsAccessPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzTimeSeriesInsightsAccessPolicy' {
    It 'Delete' {
        $environmentName = $env.rstrenv01
        $accessPolicyName = $env.rstrap01
        Remove-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -Name $accessPolicyName -ResourceGroupName $env.resourceGroup
        $policyList = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup
        $policyList.Name | Should -Not -Contain $accessPolicyName
    }

    It 'DeleteViaIdentity' {
        $environmentName = $env.rstrenv02
        $accessPolicyName = $env.rstrap02
        $role = 'Reader'
        $policy = New-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup -PrincipalObjectId $env.principalObjectId -Role $role -Name $accessPolicyName
        Remove-AzTimeSeriesInsightsAccessPolicy -InputObject $policy
        $policyList = Get-AzTimeSeriesInsightsAccessPolicy -EnvironmentName $environmentName -ResourceGroupName $env.resourceGroup
        $policyList.Name | Should -Not -Contain $accessPolicyName

    }
}
