if (($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminCatalog')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminCatalog.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminCatalog' {
    It 'CreateExpanded' {
        $catalog = New-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogNew -ResourceGroupName $env.resourceGroup -GitHubBranch $env.gitHubBranch -GitHubPath $env.gitHubPath -GitHubSecretIdentifier $env.gitHubSecretIdentifier -GitHubUri $env.gitHubUri
        $catalog.Name | Should -Be $env.catalogNew
        $catalog.GitHubBranch | Should -Be $env.gitHubBranch
        $catalog.GitHubPath | Should -Be $env.gitHubPath
        $catalog.GitHubSecretIdentifier | Should -Be $env.gitHubSecretIdentifier
        $catalog.GitHubUri | Should -Be $env.gitHubUri

    }
}
