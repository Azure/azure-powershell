if (($null -eq $TestName) -or ($TestName -contains 'Update-AzAksTrustedAccessRoleBinding')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAksTrustedAccessRoleBinding.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAksTrustedAccessRoleBinding' {
    It 'UpdateExpanded' {
        $roleBinding = Update-AzAksTrustedAccessRoleBinding -Name testBinding -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Role 'Microsoft.MachineLearningServices/workspaces/inference-v1'
        $roleBinding.Count | Should -Be 1
        $roleBinding.Name | Should -Be 'testBinding'
        $roleBinding.Role.Count | Should -Be 1
        $roleBinding.Role | Should -Contain  'Microsoft.MachineLearningServices/workspaces/inference-v1'
    }

    It 'UpdateViaIdentityExpanded' {
        $roleBinding = Get-AzAksTrustedAccessRoleBinding -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Name 'testBinding'
        $roleBinding.Role | Should -Contain  'Microsoft.MachineLearningServices/workspaces/inference-v1'
        $roleBinding = $roleBinding | Update-AzAksTrustedAccessRoleBinding -Role 'Microsoft.MachineLearningServices/workspaces/mlworkload'
        $roleBinding.Count | Should -Be 1
        $roleBinding.Name | Should -Be 'testBinding'
        $roleBinding.Role.Count | Should -Be 1
        $roleBinding.Role | Should -Contain  'Microsoft.MachineLearningServices/workspaces/mlworkload'
    }
}
