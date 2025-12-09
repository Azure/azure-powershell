if(($null -eq $TestName) -or ($TestName -contains 'Sync-AzDeviceRegistryCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Sync-AzDeviceRegistryCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Sync-AzDeviceRegistryCredentials' {
    It 'Sync' {
        Sync-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        # Verify credentials are synced by getting them
        $credentials = Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        $credentials.Name | Should -Be "default"
    }
}
