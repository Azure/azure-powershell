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
    It 'ListByName' {
        $output = Get-AzMigrateHCIJob `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetByName' {
        $output = Get-AzMigrateHCIJob `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId `
            -Name $env.hciJobName
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetById' {
        $output = Get-AzMigrateHCIJob `
            -SubscriptionId $env.hciSubscriptionId `
            -ID $env.hciJobId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetByInputObject' {
        $output = Get-AzMigrateHCIJob `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId `
            -Name $env.hciJobName
        
        $output1 = Get-AzMigrateHCIJob `
            -InputObject $output `
            -SubscriptionId $env.hciSubscriptionId
        $output1.Count | Should -BeGreaterOrEqual 1
    }

    It 'ListById' {
        $output = Get-AzMigrateHCIJob `
            -ProjectID $env.hciProjectId `
            -ResourceGroupID $env.hciMigResourceGroupId `
            -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }
}
