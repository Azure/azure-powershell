if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateHCIJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateHCIJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMigrateHCIJob' {
    It 'ListByName' -skip {
        $output = Get-AzMigrateHCIJob `
            -ProjectName $env.asrv2ProjectName `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -SubscriptionId $env.asrv2SubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetByName' -skip {
        $output = Get-AzMigrateHCIJob `
            -ProjectName $env.asrv2ProjectName `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -SubscriptionId $env.asrv2SubscriptionId `
            -JobName $env.asrv2JobName
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetById' -skip {
        $output = Get-AzMigrateHCIJob `
            -SubscriptionId $env.asrv2SubscriptionId `
            -JobID $env.asrv2JobId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetByInputObject' -skip {
        $output = Get-AzMigrateHCIJob `
            -ProjectName $env.asrv2ProjectName `
            -ResourceGroupName $env.asrv2ResourceGroupName `
            -SubscriptionId $env.asrv2SubscriptionId `
            -JobName $env.asrv2JobName
        
        $output1 = Get-AzMigrateHCIJob -InputObject $output
        $output1.Count | Should -BeGreaterOrEqual 1
    }

    It 'ListById' -skip {
        $output = Get-AzMigrateHCIJob `
            -ProjectID $env.asrv2ProjectId `
            -ResourceGroupID $env.asrv2ResourceGroupId `
            -SubscriptionId $env.asrv2SubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }
}
