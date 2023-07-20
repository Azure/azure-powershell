if(($null -eq $TestName) -or ($TestName -contains 'AzElasticVMCollection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzElasticVMCollection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzElasticVMCollection' {
    It 'UpdateExpanded' {
        {
            Update-AzElasticVMCollection -ResourceGroupName $env.resourceGroup -Name $env.monitorName01 -OperationName Add -VMResourceId $env.VMResourceId
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $vmColl = Get-AzElasticVMHost -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
            $vmColl.VMResourceId | Should -Contain $env.VMResourceId
        }
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $elastic = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
            Update-AzElasticVMCollection -InputObject $elastic -OperationName Delete -VMResourceId $env.VMResourceId
        } | Should -Not -Throw
    }

    It 'ListViaIdentityMonitor' {
        {
            $monitor = Get-AzElasticMonitor -ResourceGroupName $env.resourceGroup -Name $env.monitorName01
            $vmColl = Get-AzElasticVMHost -MonitorInputObject $monitor
            $vmColl.Count | Should -Be 0
        }
    }
}
