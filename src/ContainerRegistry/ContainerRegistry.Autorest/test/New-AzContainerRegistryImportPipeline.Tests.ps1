if(($null -eq $TestName) -or ($TestName -contains 'New-AzContainerRegistryImportPipeline'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerRegistryImportPipeline.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzContainerRegistryImportPipeline' {
    It 'CreateExpanded' {
        $keyVaultUri = "https://lnxtestkeyvault.vault.azure.net/secrets/test/de11705d609e48b6a2faf6facc30a9e0"
        $StorageAccount = "https://acrteststorageaccount.blob.core.windows.net/test"
        {New-AzContainerRegistryImportPipeline -name $env.rstr2 -RegistryName $env.rstr1 -ResourceGroupName $env.ResourceGroup -IdentityType 'SystemAssigned' -SourceType AzureStorageBlobContainer -SourceUri $StorageAccount -SourceKeyVaultUri $keyVaultUri } | Should -Not -Throw
    }
}
