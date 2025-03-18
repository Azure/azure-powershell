if(($null -eq $TestName) -or ($TestName -contains 'Get-AzIoTOperationsServiceInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzIoTOperationsServiceInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzIoTOperationsServiceInstance' {
    It 'List' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        $Instance = Get-AzIoTOperationsServiceInstance -Name $env.InstanceName -ResourceGroupName $env.ResourceGroup
        $Instance.Name | should -be $env.InstanceName
    }

    It 'List1'  {
        $Instances = Get-AzIoTOperationsServiceInstance -ResourceGroupName $env.ResourceGroup
        $Instances | Should -Not -BeNullOrEmpty
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
