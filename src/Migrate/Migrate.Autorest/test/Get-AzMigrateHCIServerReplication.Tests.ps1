if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateHCIServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateHCIServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMigrateHCIServerReplication' {
    It 'ListByName' {
        $output = Get-AzMigrateHCIServerReplication -ProjectName $env.hciProjectName -ResourceGroupName $env.hciMigResourceGroup -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByItemID' {
        $output = Get-AzMigrateHCIServerReplication -TargetObjectID $env.hciProtectedItem1 -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetBySDSID' {
        $output = Get-AzMigrateHCIServerReplication -DiscoveredMachineId $env.hciSDSMachineID1 -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByInputObject' {
        $output = Get-AzMigrateHCIServerReplication -TargetObjectID $env.hciProtectedItem1 -SubscriptionId $env.hciSubscriptionId
        $output = Get-AzMigrateHCIServerReplication -InputObject $output -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
