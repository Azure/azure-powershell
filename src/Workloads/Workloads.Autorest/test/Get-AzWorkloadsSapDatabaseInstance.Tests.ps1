if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWorkloadsSapDatabaseInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWorkloadsSapDatabaseInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWorkloadsSapDatabaseInstance' {
    It 'List' {
        $dbResponseList = Get-AzWorkloadsSapDatabaseInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $dbResponseList.Count | Should -BeGreaterOrEqual 1 
    }

    It 'Get' {
        $dbResponse = Get-AzWorkloadsSapDatabaseInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Name $env.SapDatabseInstanceName
        $dbResponse.Name | Should -Be $env.SapDatabseInstanceName
    }

    It 'GetViaIdentity' {
        $dbResponse = Get-AzWorkloadsSapDatabaseInstance -InputObject $env.DbServerIdSub2
        $dbResponse.Count | Should -BeGreaterOrEqual 1
    }
}
