if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterAdminCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterAdminCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDevCenterAdminCatalog' {
    It 'UpdateExpanded' {
        $catalog = Set-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogSet -ResourceGroupName $env.resourceGroup -GitHubBranch $env.gitHubBranch -GitHubPath "testpath" -GitHubSecretIdentifier $env.gitHubSecretIdentifier2 -GitHubUri $env.gitHubUri
        $catalog.Name | Should -Be $env.catalogSet
        $catalog.GitHubBranch | Should -Be $env.gitHubBranch
        $catalog.GitHubPath | Should -Be "testpath"
        $catalog.GitHubSecretIdentifier | Should -Be $env.gitHubSecretIdentifier2
        $catalog.GitHubUri | Should -Be $env.gitHubUri
    }

    It 'Update' {
        $body = @{"GitHubBranch" = $env.gitHubBranch; "GitHubPath" = $env.gitHubPath; "GitHubSecretIdentifier" = $env.gitHubSecretIdentifier; "GitHubUri" = $env.gitHubUri}
        $catalog = Set-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogSet -ResourceGroupName $env.resourceGroup -Body $body
        $catalog.Name | Should -Be $env.catalogSet
        $catalog.GitHubBranch | Should -Be $env.gitHubBranch
        $catalog.GitHubPath | Should -Be $env.gitHubPath
        $catalog.GitHubSecretIdentifier | Should -Be $env.gitHubSecretIdentifier
        $catalog.GitHubUri | Should -Be $env.gitHubUri
    }
}
