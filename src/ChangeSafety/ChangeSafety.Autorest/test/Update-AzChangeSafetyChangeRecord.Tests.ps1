if(($null -eq $TestName) -or ($TestName -contains 'Update-AzChangeSafetyChangeRecord'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzChangeSafetyChangeRecord.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzChangeSafetyChangeRecord' {
    BeforeAll {
        # Ensure a ChangeRecord exists for testing
        # Target must have resourceId OR subscriptionId per API spec
        $targets = @(
            @{
                resourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Compute/virtualMachines/update-test-vm"
            }
        )
        try {
            $existing = Get-AzChangeSafetyChangeRecord -Name $env.ChangeRecordName `
                -ResourceGroupName $env.ResourceGroupName -ErrorAction SilentlyContinue
        } catch {
            $existing = $null
        }
        if (-not $existing) {
            New-AzChangeSafetyChangeRecord -Name $env.ChangeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets $targets -ErrorAction SilentlyContinue
        }
    }

    It 'Update - Modify description' {
        {
            $result = Update-AzChangeSafetyChangeRecord -Name $env.ChangeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Description "Updated description for testing"
            
            $result | Should -Not -Be $null
        } | Should -Not -Throw
    }
}
