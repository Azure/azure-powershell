if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWorkloadsSapCentralInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWorkloadsSapCentralInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWorkloadsSapCentralInstance' {
    It 'List' {
        $csResponseList = Get-AzWorkloadsSapCentralInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $csResponseList.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $csResponse = Get-AzWorkloadsSapCentralInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Name $env.SapCentralInstanceName
        $csResponse.Name | Should -Be $env.SapCentralInstanceName
    }

    It 'GetViaIdentity' {
        $csResponse = Get-AzWorkloadsSapCentralInstance -InputObject $env.CsServerIdSub2
        $csResponse.Count | Should -BeGreaterOrEqual 1
    }
}
