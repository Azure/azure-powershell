Describe 'Get-AzKustoDatabasePrincipalAssignment' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not(Test-Path -Path $loadEnvPath))
        {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoDatabasePrincipalAssignment.Recording.json'
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
        $databaseName = $env.kustoDatabaseName
        $principalAssignmentName = "testViewerAssignmentName"
        $principalId = $env.principalAppId
        $role = "Viewer"
        $principalType = "App"
        $principalAssignmentFullName = "$clusterName/$databaseName/$principalAssignmentName"

        New-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $principalAssignmentName -DatabaseName $databaseName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        
        [array]$principalAssignmentGet = Get-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName
        foreach ($principalAssignmentItem in $principalAssignmentGet)
        {
            if ($principalAssignmentItem.Name -eq $principalAssignmentFullName)
            {
                $principalAssignment = $principalAssignmentItem
            }
        }
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role $env.principalAadObjectId
    }

    It 'Get' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.kustoClusterName
        $databaseName = $env.kustoDatabaseName
        $principalAssignmentName = "testViewerAssignmentName"
        $principalId = $env.principalAppId
        $role = "Viewer"
        $principalType = "App"
        $principalAssignmentFullName = "$clusterName/$databaseName/$principalAssignmentName"

        New-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -PrincipalAssignmentName $principalAssignmentName -DatabaseName $databaseName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        
        $principalAssignment = Get-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -PrincipalAssignmentName  $principalAssignmentName
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role $env.principalAadObjectId
    }
}
