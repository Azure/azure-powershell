if(($null -eq $TestName) -or ($TestName -contains 'Set-AzIoTOperationsServiceDataflowProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzIoTOperationsServiceDataflowProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzIoTOperationsServiceDataflowProfile' {
    It 'UpdateExpanded' {
        $dataflowProfile = Set-AzIoTOperationsServiceDataflowProfile `
            -InstanceName  $env.InstanceName `
            -Name $env.newDataflowProfileName `
            -ResourceGroupName $env.ResourceGroup `
            -ExtendedLocationName $env.ExtendedLocation
        
        $dataflowProfile | Should -Not -BeNullOrEmpty
    }

    It 'UpdateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
