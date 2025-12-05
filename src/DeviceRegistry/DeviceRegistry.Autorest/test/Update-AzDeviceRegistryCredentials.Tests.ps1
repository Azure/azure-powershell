if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeviceRegistryCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeviceRegistryCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeviceRegistryCredentials' {
    It 'UpdateExpanded' {
        $credentials = Update-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup `
            -Tag @{"environment" = "test"; "purpose" = "validation"; "updated" = "true"}
        
        $credentials.Name | Should -Be "default"
        $credentials.ResourceGroupName | Should -Be $env.credentialsTests.resourceGroup
    }

    It 'UpdateViaIdentity' {
        $credentials = Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        $updatedCredentials = Update-AzDeviceRegistryCredentials `
            -InputObject $credentials `
            -Tag @{"environment" = "test"; "purpose" = "validation"; "updated" = "true"}
        
        $updatedCredentials.Name | Should -Be "default"
        $updatedCredentials.ResourceGroupName | Should -Be $env.credentialsTests.resourceGroup
    }
}
