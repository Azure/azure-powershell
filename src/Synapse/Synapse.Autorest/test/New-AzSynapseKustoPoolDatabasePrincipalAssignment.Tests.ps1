Describe 'New-AzSynapseKustoPoolDatabasePrincipalAssignment' {
    BeforeAll{
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSynapseKustoPoolDatabasePrincipalAssignment.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'CreateExpanded' {
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $databaseName = $env.databaseName
        $principalAssignmentName = $env.principalAssignmentName1
        $principalId = $env.principalId1
        $role = $env.databasePrincipalRole
        $principalType = $env.principalType
        $principalAssignmentFullName = "$workspaceName/$kustoPoolName/$databaseName/$principalAssignmentName"

        $principalAssignment = New-AzSynapseKustoPoolDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -PrincipalAssignmentName $principalAssignmentName -DatabaseName $databaseName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role
        { Remove-AzSynapseKustoPoolDatabasePrincipalAssignment -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -DatabaseName $databaseName -PrincipalAssignmentName $principalAssignmentName } | Should -Not -Throw
    }
}
