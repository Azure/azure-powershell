if(($null -eq $TestName) -or ($TestName -contains 'New-AzMarketplacePrivateStoreCollection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMarketplacePrivateStoreCollection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMarketplacePrivateStoreCollection' {
    It 'CreateExpanded'  {
        $res = New-AzMarketplacePrivateStoreCollection -CollectionName pwshNewCollTest -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa01f1 -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -SubscriptionsList 1052ff5a-aa43-4ca1-bd18-010399494ce5 -Enabled
	    $res.CollectionId | Should -Be "fdb889a1-cf3e-49f0-95b8-2bb012fa01f1"
        $res.CollectionName | Should -Be "pwshNewCollTest"
        $res.enabled | Should -Be "true"
    }
}
