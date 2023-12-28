if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWorkloadsSapApplicationInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWorkloadsSapApplicationInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}


Describe 'Get-AzWorkloadsSapApplicationInstance' {
    It 'List' {
        $appResponseList = Get-AzWorkloadsSapApplicationInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $appResponseList.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $appResponse = Get-AzWorkloadsSapApplicationInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Name $env.SapApplicationInstanceName
        $appResponse.Name | Should -Be $env.SapApplicationInstanceName
    }

    It 'GetViaIdentity' {
        $appResponse = Get-AzWorkloadsSapApplicationInstance -InputObject $env.AppServerIdSub2
        $appResponse.Count | Should -BeGreaterOrEqual 1
    }
}
