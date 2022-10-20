if(($null -eq $TestName) -or ($TestName -contains 'Get-AzUserAssignedIdentityAssociatedResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzUserAssignedIdentityAssociatedResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSystemAssignedIdentity' {
    It 'Get' {
        $resourcesList = Get-AzUserAssignedIdentityAssociatedResource -ResourceGroupName $env.associatedResourceResourceGroup -Name $env.associatedResourceIdentityName
        $resourcesList.Count | Should -Be 1
        $resourcesList[0].Name | Should -Be $env.appServiceName
        $resourcesList[0].ResourceGroup | Should -Be $env.resourceGroup
        $resourcesList[0].SubscriptionId | Should -Be $env.SubscriptionId
        $resourcesList[0].ResourceType | Should -Be "Microsoft.Web/sites"
    }
}
