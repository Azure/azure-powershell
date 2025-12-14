if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDeviceRegistryCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDeviceRegistryCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDeviceRegistryCredentials' {
    It 'Delete' {
        $credentials = Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        $credentials.Name | Should -Be "default"

        Remove-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        { Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup `
            -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' -skip {
        $credentials = Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup
        
        Remove-AzDeviceRegistryCredentials -InputObject $credentials
        
        { Get-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup `
            -ErrorAction Stop } | Should -Throw
    }
}
