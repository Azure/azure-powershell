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
        Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail -EnvironmentDefinition "Sandbox" -DevCenterName $env.devCenterName10 -CatalogName $env.catalogName -ResourceGroupName $env.resourceGroupName10 -SubscriptionId $env.SubscriptionId2
        }

    It 'GetViaIdentity' -skip {
        Get-AzDevCenterAdminEnvironmentDefinitionErrorDetail -InputObject @{"EnvironmentDefinition" = "Sandbox"; "-DevCenterName" = $env.devCenterName10; "ResourceGroupName" = $env.resourceGroupName10; "CatalogName" = $env.catalogName; "SubscriptionId" = $env.SubscriptionId2}
        
    }
}
