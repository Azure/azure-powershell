if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkDeviceRegistrationKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkDeviceRegistrationKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkDeviceRegistrationKey' {
    It 'List' {
        {
            $ase = New-AzConnectedNetworkAzureStackEdgeObject -AzureStackEdgeId $env.AzureStackEdgeId
            $config = Get-AzConnectedNetworkDeviceRegistrationKey -DeviceName $env.existingDevice -ResourceGroupName $env.existingResourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
