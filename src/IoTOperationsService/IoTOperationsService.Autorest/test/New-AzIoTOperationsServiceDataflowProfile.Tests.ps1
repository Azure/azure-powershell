if(($null -eq $TestName) -or ($TestName -contains 'New-AzIoTOperationsServiceDataflowProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzIoTOperationsServiceDataflowProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzIoTOperationsServiceDataflowProfile' {
    It 'CreateExpanded' {
        $dataflowProfile = New-AzIoTOperationsServiceDataflowProfile `
            -InstanceName  $env.InstanceName `
            -Name $env.newDataflowProfileName `
            -ResourceGroupName $env.ResourceGroup `
            -ExtendedLocationName $env.ExtendedLocation
        $dataflowProfile | Should -Not -BeNullOrEmpty
        
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
