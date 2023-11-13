if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageTableDestinationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageTableDestinationObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageTableDestinationObject' {
    It '__AllParameterSets' {
        {
            New-AzStorageTableDestinationObject -TableName table1 -StorageAccountResourceId /subscriptions/ee63c5dc-9b88-42e3-8070-944a5226aea3/resourceGroups/rightregion/providers/Microsoft.Storage/storageAccounts/bar1 -Name storageAccountDestination2
        } | Should -Not -Throw
    }
}
