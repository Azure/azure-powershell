if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateServerMigrationStatus'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateServerMigrationStatus.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$appName = "ecygqlapp"
$machineName = "GQLVM-DoNotDelete"

Describe 'Get-AzMigrateServerMigrationStatus' -Tag 'LiveOnly' {
    It 'ListByName' {
        $output = Get-AzMigrateServerMigrationStatus -ProjectName $env.migProjectName -ResourceGroupName $env.migResourceGroup
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByApplianceName' {
        $output = Get-AzMigrateServerMigrationStatus -ProjectName $env.migProjectName -ResourceGroupName $env.migResourceGroup -ApplianceName $appName
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByMachineName' {
        $output = Get-AzMigrateServerMigrationStatus -ProjectName $env.migProjectName -ResourceGroupName $env.migResourceGroup -MachineName $machineName
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetHealthByMachineName' {
        $output = Get-AzMigrateServerMigrationStatus -ProjectName $env.migProjectName -ResourceGroupName $env.migResourceGroup -MachineName $machineName -Health
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByPrioritiseServer' {
        $output = Get-AzMigrateServerMigrationStatus -ProjectName $env.migProjectName -ResourceGroupName $env.migResourceGroup -MachineName $machineName -Expedite
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}