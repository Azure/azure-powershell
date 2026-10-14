if(($null -eq $TestName) -or ($TestName -contains 'New-AzFileShareSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFileShareSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFileShareSnapshot' {
    It 'CreateExpanded' {
        {
            $config = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $env.snapshotName01 `
                                               -Metadata @{"environment" = "test"; "purpose" = "testing"}
            $config.Name | Should -Be $env.snapshotName01
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' {
        {
            $jsonString = @{
                properties = @{}
                tags = @{
                    environment = "test"
                    method = "jsonstring"
                }
            } | ConvertTo-Json -Depth 10
            
            $snapshotName = "snapshot-jsonstring"
            $config = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $snapshotName `
                                               -JsonString $jsonString
            $config.Name | Should -Be $snapshotName
        } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'test-snapshot.json'
            $jsonContent = @{
                properties = @{}
                tags = @{
                    environment = "test"
                    method = "jsonfile"
                }
            } | ConvertTo-Json -Depth 10
            Set-Content -Path $jsonFilePath -Value $jsonContent
            
            $snapshotName = "snapshot-jsonfile"
            $config = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $snapshotName `
                                               -JsonFilePath $jsonFilePath
            $config.Name | Should -Be $snapshotName
            
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'CreateWithAllParameters' {
        {            
            $config = New-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $env.snapshotName02 `
                                               -Metadata @{meta1="value1";meta2="value2"} `
                                               -InitiatorId "backup-vault-001"
            $config.Name | Should -Be $env.snapshotName02
            $config.Metadata.Count | should -be 2
            $config.Metadata["meta1"] | should -Be "value1"
            $config.Metadata["meta2"] | should -Be "value2"
            $config.InitiatorId | should -be "backup-vault-001"

            $config = Get-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                               -ResourceName $env.fileShareName01 `
                                               -Name $env.snapshotName02
            $config.Name | Should -Be $env.snapshotName02
            $config.Metadata.Count | should -be 2
            $config.Metadata["meta1"] | should -Be "value1"
            $config.Metadata["meta2"] | should -Be "value2"
            $config.InitiatorId | should -be "backup-vault-001"

            Remove-AzFileShareSnapshot -ResourceGroupName $env.resourceGroup `
                                        -ResourceName $env.fileShareName01 `
                                        -Name $env.snapshotName02
        } | Should -Not -Throw
    }
}
