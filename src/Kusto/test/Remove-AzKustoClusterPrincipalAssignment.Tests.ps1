$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoClusterPrincipalAssignment.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzKustoClusterPrincipalAssignment' {
    It 'Delete' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $principalAssignmentName = $env.principalAssignmentName1
        $principalId = $env.principalId1
        $role = $env.principalRole
        $principalType = $env.principalType

        New-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $principalAssignmentName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        { Remove-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $principalAssignmentName } | Should -Not -Throw
    }
}
