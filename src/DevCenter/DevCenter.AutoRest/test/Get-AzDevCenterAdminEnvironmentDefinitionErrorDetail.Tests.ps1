if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail' {
    It 'Get' -skip {
        Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail -EnvironmentDefinition "Sandbox" -DevCenterName $env.devCenterName -CatalogName $env.catalogName -ResourceGroupName $env.resourceGroup
        }

    It 'GetViaIdentity' -skip {
        Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail -InputObject @{"EnvironmentDefinition" = "Sandbox"; "-DevCenterName" = $env.devCenterName; "ResourceGroupName" = $env.resourceGroupCheck; "CatalogName" = $env.catalogName; "SubscriptionId" = $env.SubscriptionId2}
        
    }
}
