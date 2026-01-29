if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPostgreSqlFlexibleServer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPostgreSqlFlexibleServer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPostgreSqlFlexibleServer' {
    It 'UpdateExpanded' {
        # Get current server details
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $originalStorageSizeGB = $server.StorageSizeGB
        
        # Update with increased storage (cannot decrease)
        $newStorageSize = $originalStorageSizeGB + 32
        $updatedServer = Update-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName -StorageSizeGB $newStorageSize
        
        $updatedServer | Should -Not -BeNullOrEmpty
        $updatedServer.Name | Should -Be $env.flexibleServerName
        $updatedServer.StorageSizeGB | Should -Be $newStorageSize
    }

    It 'UpdateViaIdentityExpanded' {
        $server = Get-AzPostgreSqlFlexibleServer -ResourceGroupName $env.resourceGroup -Name $env.flexibleServerName
        $originalTags = $server.Tag
        
        # Update tags via identity
        $newTags = @{ 'TestKey' = 'TestValue'; 'Environment' = 'Testing' }
        $updatedServer = Update-AzPostgreSqlFlexibleServer -InputObject $server -Tag $newTags
        
        $updatedServer | Should -Not -BeNullOrEmpty
        $updatedServer.Tag['TestKey'] | Should -Be 'TestValue'
        $updatedServer.Tag['Environment'] | Should -Be 'Testing'
        
        # Reset tags
        Update-AzPostgreSqlFlexibleServer -InputObject $server -Tag $originalTags
    }
}
