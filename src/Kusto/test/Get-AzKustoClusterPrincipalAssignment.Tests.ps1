$kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
. ($kustoCommonPath)
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterPrincipalAssignment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzKustoClusterPrincipalAssignment' {
    It 'List' {
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $principalAssignmentName = Get-Cluster-PrincipalAssignment-Name
        $principalId = Get-Cluster-PrincipalAssignment-PrincipalId
        $role = Get-Cluster-PrincipalAssignment-Role
        $principalType = Get-Cluster-PrincipalAssignment-PrincipalType
        $principalAssignmentFullName = "$clusterName/$principalAssignmentName"

        [array]$principalAssignmentGet = Get-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $principalAssignment = $principalAssignmentGet[0]
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role
    }

    It 'Get' {
        $resourceGroupName = Get-RG-Name
        $clusterName = Get-Cluster-Name
        $principalAssignmentName = Get-Cluster-PrincipalAssignment-Name
        $principalId = Get-Cluster-PrincipalAssignment-PrincipalId
        $role = Get-Cluster-PrincipalAssignment-Role
        $principalType = Get-Cluster-PrincipalAssignment-PrincipalType
        $principalAssignmentFullName = "$clusterName/$principalAssignmentName"

        $principalAssignment = Get-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName  $principalAssignmentName
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role
    }
}
