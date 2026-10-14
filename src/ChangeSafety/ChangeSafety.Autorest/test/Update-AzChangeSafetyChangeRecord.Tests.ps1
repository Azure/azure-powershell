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
    It 'Update - Target is singular and retains the Targets alias' {
        $command = Get-Command Update-AzChangeSafetyChangeRecord
        $command.Parameters['Target'] | Should -Not -BeNullOrEmpty
        $command.Parameters['Target'].Aliases | Should -Contain 'Targets'
    }

    BeforeAll {
        # Ensure a ChangeRecord exists for testing
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
                -Targets $targets `
                -ChangeType "AppDeployment" `
                -RolloutType "Normal" -ErrorAction SilentlyContinue
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

    It 'Update - Rejects RolloutType changes for targets' {
        $message = try {
            Update-AzChangeSafetyChangeRecord -Name $env.ChangeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets @{ subscriptionId = $env.SubscriptionId } `
                -RolloutType "Hotfix" `
                -WhatIf
        } catch {
            $_.Exception.Message
        }

        $message | Should -Match "RolloutType"
        $message | Should -Match "cannot be updated"
    }

    It 'Update - Requires Name with ResourceGroupName' {
        $message = try {
            Update-AzChangeSafetyChangeRecord -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop
            $null
        } catch {
            $_.Exception.Message
        }

        $message | Should -Match "requires -Name"
        $message | Should -Match "-ResourceGroupName"
    }

    It 'Update - Keeps a single target serialized as an array' {
        {
            Update-AzChangeSafetyChangeRecord -Name $env.ChangeRecordName `
                -ResourceGroupName $env.ResourceGroupName `
                -Targets @{ subscriptionId = $env.SubscriptionId } `
                -ChangeType "AppDeployment" `
                -WhatIf
        } | Should -Not -Throw
    }
}
