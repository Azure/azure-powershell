if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminProjectEnvironmentDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminProjectEnvironmentDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminProjectEnvironmentDefinition' {
    It 'List' {
        $listOfEnvironmentDefinitions = Get-AzDevCenterAdminProjectEnvironmentDefinition -ProjectName $env.projectName20 -CatalogName $env.catalogName20 -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2
        $listOfEnvironmentDefinitions.Count | Should -BeGreaterOrEqual 1    
    }

    It 'Get' {
        $envDef = Get-AzDevCenterAdminProjectEnvironmentDefinition -EnvironmentDefinitionName "Sandbox" -ProjectName $env.projectName20 -CatalogName $env.catalogName20 -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2
        $envDef.Name | Should -Be "Sandbox"
    }

}
