if(($null -eq $TestName) -or ($TestName -contains 'Set-AzIoTOperationsServiceDataflowEndpoint'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzIoTOperationsServiceDataflowEndpoint.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzIoTOperationsServiceDataflowEndpoint' {
    It 'UpdateExpanded' {
        $dataflowEndpoint = Set-AzIoTOperationsServiceDataflowEndpoint `
           -InstanceName $env.InstanceName `
           -Name $env.newDataflowEndpointName `
           -ResourceGroupName $env.ResourceGroup `
           -ExtendedLocationName $env.ExtendedLocation `
           -EndpointType "LocalStorage" `
           -LocalStorageSettingPersistentVolumeClaimRef "myPersistentVolumeClaim" 

        $dataflowEndpoint | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
