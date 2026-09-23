if(($null -eq $TestName) -or ($TestName -contains 'Update-AzIoTOperationsServiceDataflowEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzIoTOperationsServiceDataflowEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzIoTOperationsServiceDataflowEndpoint' {
    It 'UpdateExpanded' {
        $dataflowEndpoint = Update-AzIoTOperationsServiceDataflowEndpoint `
            -InstanceName $env.InstanceName `
            -Name $env.newDataflowEndpointName `
            -ResourceGroupName $env.ResourceGroup `
            -EndpointType "LocalStorage" `
            -LocalStorageSettingPersistentVolumeClaimRef "myPersistentVolumeClaim" 

     $dataflowEndpoint | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaIdentityInstanceExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
