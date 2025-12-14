if(($null -eq $TestName) -or ($TestName -contains 'New-AzDeviceRegistryCredentials'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDeviceRegistryCredentials.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDeviceRegistryCredentials' {
    It 'CreateExpanded' {
        $credentialsTestParams = $env.credentialsTests.createTests.CreateExpanded
        
        $credentials = New-AzDeviceRegistryCredentials `
            -NamespaceName $env.credentialsTests.namespaceName `
            -ResourceGroupName $env.credentialsTests.resourceGroup `
            -Location $env.credentialsTests.location
        
        $credentials.Name | Should -Be "default"
        $credentials.ResourceGroupName | Should -Be $env.credentialsTests.resourceGroup
    }
}
