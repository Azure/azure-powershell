if(($null -eq $TestName) -or ($TestName -contains 'Update-AzIoTOperationsServiceInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzIoTOperationsServiceInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzIoTOperationsServiceInstance' {
    It 'UpdateExpanded' -skip {
        $instance = Update-AzIoTOperationsServiceInstance `
            -Name $env.InstanceName `
            -SchemaRegistryRefResourceId "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/aio-validation-117832708/providers/Microsoft.DeviceRegistry/schemaRegistries/aio-sr-d71574b00a" `
            -ResourceGroupName $env.ResourceGroup `
        $instance | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
