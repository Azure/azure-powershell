Describe 'Remove-AzKustoDatabasePrincipalAssignment' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzKustoDatabasePrincipalAssignment.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Delete' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $principalAssignmentName = "testPrincipalAssignmentNameSecondary"
        $principalId = $env.principalAppIdSecondary
        $role = "Viewer"
        $principalType = "App"

        New-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $principalAssignmentName -DatabaseName $databaseName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        { Remove-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName  -PrincipalAssignmentName $principalAssignmentName } | Should -Not -Throw
    }
}
