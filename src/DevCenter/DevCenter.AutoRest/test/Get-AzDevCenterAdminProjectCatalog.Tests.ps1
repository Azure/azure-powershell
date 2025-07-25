if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminProjectCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminProjectCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminProjectCatalog' {
    It 'List' {
        $listOfCatalogs = Get-AzDevCenterAdminProjectCatalog -ProjectName $env.projectName20 -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2
        $listOfCatalogs.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $catalog = Get-AzDevCenterAdminProjectCatalog -ProjectName $env.projectName20 -CatalogName $env.catalogName20 -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2
        $catalog.Name | Should -Be $env.catalogName20
        $catalog.GitHubPath | Should -Be $env.gitHubPath20
        $catalog.GitHubUri | Should -Be $env.gitHubUri20
    }
}
