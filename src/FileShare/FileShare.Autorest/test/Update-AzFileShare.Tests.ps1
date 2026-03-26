if(($null -eq $TestName) -or ($TestName -contains 'Update-AzFileShare'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzFileShare.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzFileShare' {
    It 'UpdateExpanded' {
        {
            $config = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                                          -ResourceName $env.fileShareName01 `
                                          -Tag @{"updated" = "true"; "environment" = "production"}
            $config.Name | Should -Be $env.fileShareName01
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
            
            $config = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                                          -ResourceName $env.fileShareName01 `
                                          -JsonString $jsonString
            $config.Name | Should -Be $env.fileShareName01
            $config.Tag["updated"] | Should -Be "jsonstring"
        } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' {
        {
            $jsonFilePath = Join-Path $PSScriptRoot 'test-update.json'
            $jsonContent = @{
                tags = @{
                    updated = "jsonfile"
                    method = "jsonfile"
                }
            } | ConvertTo-Json -Depth 10
            Set-Content -Path $jsonFilePath -Value $jsonContent
            
            $config = Update-AzFileShare -ResourceGroupName $env.resourceGroup `
                                          -ResourceName $env.fileShareName01 `
                                          -JsonFilePath $jsonFilePath
            $config.Name | Should -Be $env.fileShareName01
            $config.Tag["updated"] | Should -Be "jsonfile"
            
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $fileShare = Get-AzFileShare -ResourceGroupName $env.resourceGroup -ResourceName $env.fileShareName01
            $config = Update-AzFileShare -InputObject $fileShare `
                                          -Tag @{"updated" = "identity"; "method" = "identity"}
            $config.Name | Should -Be $env.fileShareName01
            $config.Tag["updated"] | Should -Be "identity"
        } | Should -Not -Throw
    }
}
