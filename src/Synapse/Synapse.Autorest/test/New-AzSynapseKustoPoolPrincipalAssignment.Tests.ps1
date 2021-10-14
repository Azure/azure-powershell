Describe 'New-AzSynapseKustoPoolPrincipalAssignment' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }  
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSynapseKustoPoolPrincipalAssignment.Recording.json'
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
        $principalAssignmentName = $env.principalAssignmentName1
        $principalId = $env.principalId1
        $role = $env.principalRole
        $principalType = $env.principalType
        $principalAssignmentFullName = "$workspaceName/$kustoPoolName/$principalAssignmentName"

        $principalAssignment = New-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -PrincipalAssignmentName $principalAssignmentName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        Validate_PrincipalAssignment $principalAssignment $principalAssignmentFullName $principalId $principalType $role
        { Remove-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -PrincipalAssignmentName $principalAssignmentName } | Should -Not -Throw
    }
}
