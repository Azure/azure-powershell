if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFileShareSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFileShareSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFileShareSnapshot' {
    It 'List' {
        {
            $config = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01
            $config.Count | Should -BeGreaterOrEqual 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            # First create a snapshot to retrieve
            $snapshotName = "snapshot-get-test"
            $snapshot = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $snapshotName `
                                               -Metadata @{"purpose" = "testing"; "environment" = "test"}
            $snapshot | Should -Not -BeNullOrEmpty
            
            # Get the specific snapshot by name
            $retrieved = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                                 -ResourceName $env.fileShareName01 `
                                                 -Name $snapshotName
            $retrieved | Should -Not -BeNullOrEmpty
            $retrieved.Name | Should -Be $snapshotName
            
            # Clean up
            Remove-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                      -ResourceName $env.fileShareName01 `
                                      -Name $snapshotName
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            # First create a snapshot
            $snapshotName = "snapshot-identity-test"
            $snapshot = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $snapshotName `
                                               -Metadata @{"purpose" = "testing"; "environment" = "test"}
            $snapshot | Should -Not -BeNullOrEmpty
            
            # Get via identity
            $inputObj = @{
                SubscriptionId = $env.SubscriptionId
                ResourceGroupName = $env.resourceGroup
                ResourceName = $env.fileShareName01
                Name = $snapshotName
            }
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareIdentity]$inputObj
            $retrieved = Get-AzFileShareSnapshot -InputObject $identity
            $retrieved | Should -Not -BeNullOrEmpty
            $retrieved.Name | Should -Be $snapshotName
            
            # Clean up
            Remove-AzFileShareSnapshot -InputObject $identity
        } | Should -Not -Throw
    }

    It 'GetViaIdentityFileShare' {
        {
            # First create a snapshot
            $snapshotName = "snapshot-fileshare-test"
            $snapshot = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $snapshotName `
                                               -Metadata @{"purpose" = "testing"; "environment" = "test"}
            $snapshot | Should -Not -BeNullOrEmpty
            
            # Get via file share identity (provides file share, then specify snapshot name)
            $fileShareInputObj = @{
                SubscriptionId = $env.SubscriptionId
                ResourceGroupName = $env.resourceGroup
                ResourceName = $env.fileShareName01
            }
            $fileShareIdentity = [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareIdentity]$fileShareInputObj
            $retrieved = Get-AzFileShareSnapshot -FileShareInputObject $fileShareIdentity -Name $snapshotName
            $retrieved | Should -Not -BeNullOrEmpty
            $retrieved.Name | Should -Be $snapshotName
            
            # Clean up
            Remove-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                      -ResourceName $env.fileShareName01 `
                                      -Name $snapshotName
        } | Should -Not -Throw
    }
}
