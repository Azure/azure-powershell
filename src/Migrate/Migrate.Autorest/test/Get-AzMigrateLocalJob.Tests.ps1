if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateLocalJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateLocalJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMigrateLocalJob' {
    It 'ListByName' {
        $output = Get-AzMigrateLocalJob `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetByName' {
        $output = Get-AzMigrateLocalJob `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId `
            -Name $env.hciJobName
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetById' {
        $output = Get-AzMigrateLocalJob `
            -SubscriptionId $env.hciSubscriptionId `
            -ID $env.hciJobId
        $output.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetByInputObject' {
        $output = Get-AzMigrateLocalJob `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $env.hciMigResourceGroup `
            -SubscriptionId $env.hciSubscriptionId `
            -Name $env.hciJobName
        
        $output1 = Get-AzMigrateLocalJob `
            -InputObject $output `
            -SubscriptionId $env.hciSubscriptionId
        $output1.Count | Should -BeGreaterOrEqual 1
    }

    It 'ListById' {
        $output = Get-AzMigrateLocalJob `
            -ProjectID $env.hciProjectId `
            -ResourceGroupID $env.hciMigResourceGroupId `
            -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1
    }
}
