if(($null -eq $TestName) -or ($TestName -contains 'Test-AzServiceBusName'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzServiceBusName.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzServiceBusName' {
    It 'NamespaceAvailability' {
        $checkName = Test-AzServiceBusName -NamespaceName $env.standardNamespace
        $checkName.NameAvailable | Should -Be $false
    }

    It 'AliasAvailability'{
        $checkName = Test-AzServiceBusName -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -AliasName $env.alias
        $checkName.NameAvailable | Should -Be $true
    }
}
