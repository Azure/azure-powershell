if(($null -eq $TestName) -or ($TestName -contains 'Get-AzChangeSafetyChangeRecord'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzChangeSafetyChangeRecord.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzChangeSafetyChangeRecord' {
    It 'Get - By name in resource group' {
        {
            # Use hardcoded deterministic name
            $changeRecordName = "test-changerecord-get-b2h6sc"
            
            # Create a ChangeRecord first to ensure it exists
            # API requires multiple targets based on working New-ChangeRecord test
            $targets = @(
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/test-vm-get-001"
                }
                @{
                    resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/test-vm-get-002"
                }
            )
            New-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets $targets -ErrorAction SilentlyContinue
            
            $result = Get-AzChangeSafetyChangeRecord -Name $changeRecordName `
                -ResourceGroupName $env.ResourceGroupName
            $result | Should -Not -Be $null
            $result.Name | Should -Be $changeRecordName
        } | Should -Not -Throw
    }

    It 'List - All in resource group' {
        {
            $result = Get-AzChangeSafetyChangeRecord -ResourceGroupName $env.ResourceGroupName
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }

    It 'List - All in subscription' {
        {
            $result = Get-AzChangeSafetyChangeRecord
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }
}
