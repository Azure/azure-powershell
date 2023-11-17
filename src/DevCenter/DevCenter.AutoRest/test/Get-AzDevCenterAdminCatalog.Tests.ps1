if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminCatalog' {
    It 'List' {
        $listOfCatalogs = Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -ResourceGroupName $env.resourceGroup
        $listOfCatalogs.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $catalog = Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogName -ResourceGroupName $env.resourceGroup
        $catalog.Name | Should -Be $env.catalogName
        $catalog.GitHubBranch | Should -Be $env.gitHubBranch
        $catalog.GitHubPath | Should -Be $env.gitHubPath
        $catalog.GitHubSecretIdentifier | Should -Be $env.gitHubSecretIdentifier
        $catalog.GitHubUri | Should -Be $env.gitHubUri
    }

    It 'GetViaIdentity' {
        $catalog = Get-AzDevCenterAdminCatalog -DevCenterName $env.devCenterName -Name $env.catalogName -ResourceGroupName $env.resourceGroup
        $catalog = Get-AzDevCenterAdminCatalog -InputObject $catalog
        $catalog.Name | Should -Be $env.catalogName
        $catalog.GitHubBranch | Should -Be $env.gitHubBranch
        $catalog.GitHubPath | Should -Be $env.gitHubPath
        $catalog.GitHubSecretIdentifier | Should -Be $env.gitHubSecretIdentifier
        $catalog.GitHubUri | Should -Be $env.gitHubUri
    }
}
