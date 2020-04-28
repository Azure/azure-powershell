$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterPrincipalAssignment.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoClusterPrincipalAssignment' {
    It 'List' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $principalAssignmentName = $env.principalAssignmentName
        $principalId = $env.principalId
        $role = $env.principalRole
        $principalType = $env.principalType
        $principalAssignmentFullName = "$clusterName/$principalAssignmentName"

        [array]$principalAssignmentGet = Get-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $principalAssignment = $principalAssignmentGet[0]
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role
    }

    It 'Get' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $principalAssignmentName = $env.principalAssignmentName
        $principalId = $env.principalId
        $role = $env.principalRole
        $principalType = $env.principalType
        $principalAssignmentFullName = "$clusterName/$principalAssignmentName"

        $principalAssignment = Get-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName  $principalAssignmentName
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role
    }
}
