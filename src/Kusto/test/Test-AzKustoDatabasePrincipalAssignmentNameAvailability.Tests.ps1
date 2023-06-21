Describe 'Test-AzKustoDatabasePrincipalAssignmentNameAvailability' {
    BeforeAll{
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzKustoDatabasePrincipalAssignmentNameAvailability.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CheckExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $principalAssignmentName = "testPrincipalAssignmentNameSecondary"
        $principalId = $env.principalAppIdSecondary
        $role = "Viewer"
        $principalType = "App"

        New-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $principalAssignmentName -DatabaseName $databaseName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        $availability = Test-AzKustoDatabasePrincipalAssignmentNameAvailability -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -Name $principalAssignmentName
        $availability.NameAvailable | Should -Be $false
        $availability.Name | Should -Be $principalAssignmentName
        { Remove-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName  -PrincipalAssignmentName $principalAssignmentName } | Should -Not -Throw
    }

    It 'CheckViaIdentityExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $principalAssignmentName = "testPrincipalAssignmentNameSecondary"
        $principalAssignmentResourceType = "Microsoft.Kusto/Clusters/Databases/principalAssignments"

        $cluster = Get-AzKustoDatabase -ResourceGroupName $resourceGroupName -ClusterName $clusterName -Name $databaseName
        $availability = Test-AzKustoDatabasePrincipalAssignmentNameAvailability -InputObject $cluster -Name $principalAssignmentName
        $availability.NameAvailable | Should -Be $true
        $availability.Name | Should -Be $principalAssignmentName
    }
}
