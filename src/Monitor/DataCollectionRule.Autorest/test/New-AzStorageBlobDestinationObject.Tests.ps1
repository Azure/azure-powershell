if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageBlobDestinationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageBlobDestinationObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageBlobDestinationObject' {
    It '__AllParameterSets' {
        {
            New-AzStorageBlobDestinationObject -ContainerName "my-logs" -StorageAccountResourceId /subscriptions/da58aca0-2082-4f5a-85ba-27344286c17c/resourceGroups/sa-rg/providers/Microsoft.Storage/storageAccounts/rightregion:westus:sa-name1 -Name storageAccountDestination1
        } | Should -Not -Throw
    }
}
