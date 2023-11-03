Describe 'Test-AzKustoClusterPrincipalAssignmentNameAvailability' {
    BeforeAll{
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
    }
    It 'CheckExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $principalAssignmentName = "testPrincipalAssignmentName"
       
        $availability = Test-AzKustoClusterPrincipalAssignmentNameAvailability -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $principalAssignmentName 
        $availability.NameAvailable | Should -Be $false
        $availability.Name | Should -Be $principalAssignmentName
    }

    It 'CheckViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $principalAssignmentName = "testPrincipalAssignmentNameSecondary"
        
        $cluster = Get-AzKustoCluster -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $availability = Test-AzKustoClusterPrincipalAssignmentNameAvailability -InputObject $cluster -Name $principalAssignmentName
        $availability.NameAvailable | Should -Be $true
        $availability.Name | Should -Be $principalAssignmentName
    }
}
