if(($null -eq $TestName) -or ($TestName -contains 'FileShare-CRUD'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'FileShare-CRUD.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'FileShare-CRUD' {
    
    BeforeAll {
        $script:crudShareName = "crud-share-fixed01"
        $script:crudSnapshotName = "crud-snapshot-fixed01"
    }

    Context 'Complete CRUD Lifecycle - NFS Protocol' {
        
        It 'CREATE: Should create a new NFS file share with all properties' {
            {
                $share = New-AzFileShare -ResourceName $script:crudShareName `
                    -ResourceGroupName $env.resourceGroup `
                    -Location $env.location `
                    -MediaTier "SSD" `
                    -Protocol "NFS" `
                    -ProvisionedStorageGiB 1024 `
                    -ProvisionedIoPerSec 4024 `
                    -ProvisionedThroughputMiBPerSec 228 `
                    -Redundancy "Local" `
                    -PublicNetworkAccess "Enabled" `
                    -NfProtocolPropertyRootSquash "NoRootSquash" `
                    -Tag @{"lifecycle" = "crud"; "test" = "nfs"; "created" = (Get-Date -Format "yyyy-MM-dd")}
                
                $share.Name | Should -Be $script:crudShareName
                $share.ProvisioningState | Should -Be "Succeeded"
                $share.Protocol | Should -Be "NFS"
                $share.MediaTier | Should -Be "SSD"
                $share.ProvisionedStorageGiB | Should -Be 1024
                $share.Tag.ContainsKey("lifecycle") | Should -Be $true
            } | Should -Not -Throw
        }

        It 'READ: Should retrieve the created file share by name' {
            {
                $share = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $script:crudShareName
                
                $share | Should -Not -BeNullOrEmpty
                $share.Name | Should -Be $script:crudShareName
                $share.Protocol | Should -Be "NFS"
                $share.Tag["lifecycle"] | Should -Be "crud"
            } | Should -Not -Throw
        }

        It 'READ: Should list file shares in resource group and find our share' {
            {
                $shares = Get-AzFileShare -ResourceGroupName $env.resourceGroup
                
                $shares | Should -Not -BeNullOrEmpty
                $shares.Count | Should -BeGreaterThan 0
                $ourShare = $shares | Where-Object { $_.Name -eq $script:crudShareName }
                $ourShare | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }

        It 'READ: Should retrieve file share via identity' {
            {
                $share = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $script:crudShareName
                $shareViaIdentity = Get-AzFileShare -InputObject $share
                
                $shareViaIdentity.Name | Should -Be $script:crudShareName
                $shareViaIdentity.Id | Should -Be $share.Id
            } | Should -Not -Throw
        }

        It 'UPDATE: Should update tags using expanded parameters' {
            {
                Start-TestSleep -Seconds 5
                
                $updated = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:crudShareName `
                    -Tag @{"lifecycle" = "crud"; "test" = "nfs"; "updated" = "true"; "version" = "2"}
                
                $updated.Tag["updated"] | Should -Be "true"
                $updated.Tag["version"] | Should -Be "2"
                $updated.Tag["lifecycle"] | Should -Be "crud"
            } | Should -Not -Throw
        }

        It 'UPDATE: Should update via identity' {
            {
                Start-TestSleep -Seconds 5
                
                $share = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $script:crudShareName
                $updated = Update-AzFileShare -InputObject $share `
                    -Tag @{"lifecycle" = "crud"; "test" = "nfs"; "method" = "identity"; "version" = "3"}
                
                $updated.Tag["method"] | Should -Be "identity"
                $updated.Tag["version"] | Should -Be "3"
            } | Should -Not -Throw
        }

        It 'SNAPSHOT CREATE: Should create a snapshot of the file share' {
            {
                Start-TestSleep -Seconds 5
                
                $snapshot = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:crudShareName `
                    -Name $script:crudSnapshotName `
                    -Metadata @{"purpose" = "testing"; "environment" = "test"}
                
                $snapshot.Name | Should -Be $script:crudSnapshotName
                $snapshot.SnapshotTime | Should -Not -BeNullOrEmpty
                $snapshot.Metadata["purpose"] | Should -Be "testing"
            } | Should -Not -Throw
        }

        It 'SNAPSHOT READ: Should retrieve snapshot' {
            {
                $snapshot = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:crudShareName `
                    -Name $script:crudSnapshotName
                
                $snapshot | Should -Not -BeNullOrEmpty
                $snapshot.Name | Should -Be $script:crudSnapshotName
            } | Should -Not -Throw
        }

        It 'SNAPSHOT UPDATE: Should update snapshot' {
            {
                Start-TestSleep -Seconds 5
                
                $updated = Update-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:crudShareName `
                    -Name $script:crudSnapshotName
                
                $updated | Should -Not -BeNullOrEmpty
            } | Should -Not -Throw
        }

        It 'SNAPSHOT DELETE: Should delete snapshot' {
            {
                Start-TestSleep -Seconds 5
                
                Remove-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:crudShareName `
                    -Name $script:crudSnapshotName `
                    -PassThru | Should -Be $true
                
                Start-TestSleep -Seconds 3
                
                $deleted = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:crudShareName `
                    -Name $script:crudSnapshotName `
                    -ErrorAction SilentlyContinue
                
                $deleted | Should -BeNullOrEmpty
            } | Should -Not -Throw
        }

        It 'DELETE: Should delete file share via identity' {
            {
                Start-TestSleep -Seconds 5
                
                $share = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $script:crudShareName
                Remove-AzFileShare -InputObject $share -PassThru | Should -Be $true
                
                Start-TestSleep -Seconds 3
                
                $deleted = Get-AzFileShare -ResourceGroupName $env.resourceGroup `
                    -ResourceName $script:crudShareName `
                    -ErrorAction SilentlyContinue
                
                $deleted | Should -BeNullOrEmpty
            } | Should -Not -Throw
        }
    }


}
