if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFileShareSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFileShareSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFileShareSnapshot' {
    It 'UpdateExpanded' {
        {
            $config = Update-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                                  -ResourceName $env.fileShareName01 `
                                                  -Name $env.snapshotName01 `
                                                  -Tag @{"updated" = "true"; "environment" = "production"}
            $config.Name | Should -Be $env.snapshotName01
            $config.Tag["updated"] | Should -Be "true"
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonString' {
        {
            $jsonString = @{
                tags = @{
                    updated = "jsonstring"
                    method = "jsonstring"
                }
            } | ConvertTo-Json -Depth 10
            
            $config = Update-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                                  -ResourceName $env.fileShareName01 `
                                                  -Name $env.snapshotName01 `
                                                  -JsonString $jsonString
            $config.Name | Should -Be $env.snapshotName01
            $config.Tag["updated"] | Should -Be "jsonstring"
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'test-snapshot-update.json'
            $jsonContent = @{
                tags = @{
                    updated = "jsonfile"
                    method = "jsonfile"
                }
            } | ConvertTo-Json -Depth 10
            Set-Content -Path $jsonFilePath -Value $jsonContent
            
            $config = Update-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                                  -ResourceName $env.fileShareName01 `
                                                  -Name $env.snapshotName01 `
                                                  -JsonFilePath $jsonFilePath
            $config.Name | Should -Be $env.snapshotName01
            $config.Tag["updated"] | Should -Be "jsonfile"
            
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityFileShareExpanded' {
        {
            $fileShare = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01
            $config = Update-AzFileShareSnapshot -FileShareInputObject $fileShare `
                                                  -Name $env.snapshotName01 `
                                                  -Tag @{"updated" = "fileshare-identity"; "method" = "fileshare"}
            $config.Name | Should -Be $env.snapshotName01
            $config.Tag["updated"] | Should -Be "fileshare-identity"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $snapshot = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                                 -ResourceName $env.fileShareName01 `
                                                 -Name $env.snapshotName01
            $config = Update-AzFileShareSnapshot -InputObject $snapshot `
                                                  -Tag @{"updated" = "identity"; "method" = "identity"}
            $config.Name | Should -Be $env.snapshotName01
            $config.Tag["updated"] | Should -Be "identity"
        } | Should -Not -Throw
    }
}
