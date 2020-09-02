$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoClusterPrincipalAssignmentNameAvailability.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Test-AzKustoClusterPrincipalAssignmentNameAvailability' {
    It 'CheckExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $principalAssignmentName = $env.principalAssignmentName
        $principalAssignmentResourceType = $env.clusterPrincipalAssignmentResourceType

        $availability = Test-AzKustoClusterPrincipalAssignmentNameAvailability -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $principalAssignmentName -Type $principalAssignmentResourceType
        $availability.NameAvailable | Should Be $false
        $availability.Name | Should Be $principalAssignmentName
    }

    It 'CheckViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $principalAssignmentName = $env.principalAssignmentName1
        $principalAssignmentResourceType = $env.clusterPrincipalAssignmentResourceType

        $cluster = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $availability = Test-AzKustoClusterPrincipalAssignmentNameAvailability -InputObject $cluster -Name $principalAssignmentName -Type $principalAssignmentResourceType
        $availability.NameAvailable | Should Be $true
        $availability.Name | Should Be $principalAssignmentName
    }
}
