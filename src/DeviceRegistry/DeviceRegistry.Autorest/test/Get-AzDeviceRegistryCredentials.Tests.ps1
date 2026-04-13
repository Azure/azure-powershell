if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDeviceRegistryCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDeviceRegistryCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDeviceRegistryCredentials' {
    It 'Get' {
        $credentials = Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        $credentials.Name | Should -Be "default"
        $credentials.ResourceGroupName | Should -Be $env.credentialsTests.resourceGroup
    }

    It 'List' {
        $credentialsList = Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        $credentialsList.Count | Should -BeGreaterThan 0
    }

    It 'GetViaIdentity' {
        $credentials = Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        $credentialsViaIdentity = Get-AzDeviceRegistryCredentials -InputObject $credentials
        
        $credentialsViaIdentity.Name | Should -Be "default"
        $credentialsViaIdentity.ResourceGroupName | Should -Be $env.credentialsTests.resourceGroup
    }
}
