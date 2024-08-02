if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminProjectCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminProjectCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminProjectCatalog' {
    It 'Delete' {
        Remove-AzDevCenterAdminProjectCatalog -ProjectName $env.projectName20 -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2 -CatalogName $env.catalogNew20
        { Get-AzDevCenterAdminProjectCatalog -ProjectName $env.projectName20 -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2 -CatalogName $env.catalogNew20 } | Should -Throw    
    }
}
