Describe 'Remove-AzSynapseKustoPoolPrincipalAssignment' {
    BeforeAll {
        $kustoCommonPath = Join-Path $PSScriptRoot 'common.ps1'
        . ($kustoCommonPath)
        $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
        if (-Not (Test-Path -Path $loadEnvPath)) {
            $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
        }  
        . ($loadEnvPath)
        $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSynapseKustoPoolPrincipalAssignment.Recording.json'
        $currentPath = $PSScriptRoot
        while (-not $mockingPath) {
            $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
            $currentPath = Split-Path -Path $currentPath -Parent
        }
        . ($mockingPath | Select-Object -First 1).FullName
    }
    It 'Delete' {
        $resourceGroupName = $env.resourceGroupName
        $workspaceName = $env.workspaceName
        $kustoPoolName = $env.kustoPoolName
        $principalAssignmentName = $env.principalAssignmentName1
        $principalId = $env.principalId1
        $role = $env.principalRole
        $principalType = $env.principalType

        New-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -PrincipalAssignmentName $principalAssignmentName -PrincipalId $principalId -PrincipalType $principalType -Role $role
        { Remove-AzSynapseKustoPoolPrincipalAssignment -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -KustoPoolName $kustoPoolName -PrincipalAssignmentName $principalAssignmentName } | Should -Not -Throw
    }
}
