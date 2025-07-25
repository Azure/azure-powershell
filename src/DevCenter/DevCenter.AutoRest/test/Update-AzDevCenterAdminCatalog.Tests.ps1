if (($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminCatalog')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminCatalog.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminCatalog' {
    It 'UpdateExpanded' {
        $catalog = Update-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogUpdate -ResourceGroupName $env.resourceGroup -GitHubPath "testpath" -GitHubSecretIdentifier $env.gitHubSecretIdentifier2
        $catalog.Name | Should -Be $env.catalogUpdate
        $catalog.GitHubBranch | Should -Be $env.gitHubBranch
        $catalog.GitHubPath | Should -Be "testpath"
        $catalog.GitHubSecretIdentifier | Should -Be $env.gitHubSecretIdentifier2
        $catalog.GitHubUri | Should -Be $env.gitHubUri
    }
    It 'UpdateViaIdentityExpanded' {
        $catalogInput = Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogUpdate -ResourceGroupName $env.resourceGroup

        $catalog = Update-AzDevCenterAdminCatalog -InputObject $catalogInput -GitHubPath "testpath" -GitHubSecretIdentifier $env.gitHubSecretIdentifier2
        $catalog.Name | Should -Be $env.catalogUpdate
        $catalog.GitHubBranch | Should -Be $env.gitHubBranch
        $catalog.GitHubPath | Should -Be "testpath"
        $catalog.GitHubSecretIdentifier | Should -Be $env.gitHubSecretIdentifier2
        $catalog.GitHubUri | Should -Be $env.gitHubUri }

}
