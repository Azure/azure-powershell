if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMigrateLocalServerReplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMigrateLocalServerReplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMigrateLocalServerReplication' {
    It 'ListByName' -Skip {
        $output = Get-AzMigrateLocalServerReplication -ProjectName $env.hciProjectName -ResourceGroupName $env.hciMigResourceGroup -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByItemID' {
        $output = Get-AzMigrateLocalServerReplication -TargetObjectID $env.hciProtectedItem1 -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetBySDSID' {
        $output = Get-AzMigrateLocalServerReplication -DiscoveredMachineId $env.hciSDSMachineId1 -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetByInputObject' {
        $output = Get-AzMigrateLocalServerReplication -TargetObjectID $env.hciProtectedItem1 -SubscriptionId $env.hciSubscriptionId
        $output = Get-AzMigrateLocalServerReplication -InputObject $output -SubscriptionId $env.hciSubscriptionId
        $output.Count | Should -BeGreaterOrEqual 1 
    }
}
