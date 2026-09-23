if (($null -eq $TestName) -or ($TestName -contains 'New-AzAksTrustedAccessRoleBinding')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAksTrustedAccessRoleBinding.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAksTrustedAccessRoleBinding' {
    It 'CreateExpanded' {
        $mlworkspaceResourceId = "/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.MachineLearningServices/workspaces/TestAML001" 
        
        $roleBinding = New-AzAksTrustedAccessRoleBinding -Name testBinding -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName -Role 'Microsoft.MachineLearningServices/workspaces/mlworkload' -SourceResourceId $mlworkspaceResourceId 
        $roleBinding.Count | Should -Be 1
        $roleBinding.Name | Should -Be 'testBinding'
        $roleBinding.Role.Count | Should -Be 1
        $roleBinding.Role | Should -Contain 'Microsoft.MachineLearningServices/workspaces/mlworkload'
    }
}
