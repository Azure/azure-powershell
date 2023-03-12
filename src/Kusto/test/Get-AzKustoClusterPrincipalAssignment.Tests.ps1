Describe 'Get-AzKustoClusterPrincipalAssignment' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoClusterPrincipalAssignment.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not$mockingPath)
        {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $principalAssignmentName = "testPrincipalAssignmentName"
        $principalId = $env.principalAppId
        $role = "AllDatabasesViewer"
        $principalType = "App"
        $principalAssignmentFullName = "$clusterName/$principalAssignmentName"

        New-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $principalAssignmentName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        
        [array]$principalAssignmentGet = Get-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName
        $principalAssignment = $principalAssignmentGet[0]
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role $env.principalAadObjectId
    }

    It 'Get' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $principalAssignmentName = "testPrincipalAssignmentName"
        $principalId = $env.principalAppId
        $role = "AllDatabasesViewer"
        $principalType = "App"
        $principalAssignmentFullName = "$clusterName/$principalAssignmentName"

        New-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $principalAssignmentName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        
        $principalAssignment = Get-AzKustoClusterPrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName  $principalAssignmentName
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role $env.principalAadObjectId
    }
}
