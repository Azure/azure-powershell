Describe 'Get-AzKustoDatabasePrincipalAssignment' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzKustoDatabasePrincipalAssignment.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'List' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $principalAssignmentName = $env.principalAssignmentName
        $principalId = $env.principalId
        $role = $env.databasePrincipalRole
        $principalType = $env.principalType
        $principalAssignmentFullName = "$clusterName/$databaseName/$principalAssignmentName"

        [array]$principalAssignmentGet = Get-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName
        foreach ($principalAssignmentItem in $principalAssignmentGet) {
            if ($principalAssignmentItem.Name -eq $principalAssignmentFullName) {
                $principalAssignment = $principalAssignmentItem
            }
        }
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role $env.principalAadObjectId
    }

    It 'Get' {
        $resourceGroupName = $env.resourceGroupName
        $clusterName = $env.clusterName
        $databaseName = $env.databaseName
        $principalAssignmentName = $env.principalAssignmentName
        $principalId = $env.principalId
        $role = $env.databasePrincipalRole
        $principalType = $env.principalType
        $principalAssignmentFullName = "$clusterName/$databaseName/$principalAssignmentName"

        $principalAssignment = Get-AzKustoDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -ClusterName $clusterName -DatabaseName $databaseName -PrincipalAssignmentName  $principalAssignmentName
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role $env.principalAadObjectId
    }
}
