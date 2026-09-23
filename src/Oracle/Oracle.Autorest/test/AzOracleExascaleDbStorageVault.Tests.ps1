if(($null -eq $TestName) -or ($TestName -contains 'AzOracleExascaleDbStorageVault'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  Write-Host "--- DEBUG: INSIDE THE PESTER TEST SCRIPT ---" -ForegroundColor Yellow
  Write-Host "Checking the content of the loaded `$env` variable:"
  # This will print the entire contents of the $env object that was loaded from env.json
  $env | Format-List | Out-String | Write-Host
  Write-Host "--- END OF PESTER SCRIPT DEBUG ---" -ForegroundColor Yellow

  $TestRecordingFile = Join-Path $PSScriptRoot 'AzOracleExascaleDbStorageVault.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzOracleExascaleDbStorageVault' {
    It 'CreateOracleExascaleDbStorageVault' {
        {        
            $oracleExascaleDbStorageVault = New-AzOracleExascaleDbStorageVault -Name $env.oracleExascaleDbStorageVaultName -ResourceGroupName $env.resourceGroup -Location $env.location -Zone $env.zone -Description $env.description -DisplayName $env.oracleExascaleDbStorageVaultName -HighCapacityDatabaseStorageInput $env.highCapacityDatabaseStorageInput 
            $oracleExascaleDbStorageVault.Name | Should -Be $env.oracleExascaleDbStorageVaultName
        } | Should -Not -Throw
    }
    It 'GetOracleExascaleDbStorageVault' {
        {
            $oracleExascaleDbStorageVault = Get-AzOracleExascaleDbStorageVault -Name $env.oracleExascaleDbStorageVaultName -ResourceGroupName $env.resourceGroup
            $oracleExascaleDbStorageVault.Name | Should -Be $env.oracleExascaleDbStorageVaultName
        } | Should -Not -Throw
    }
    It 'ListOracleExascaleDbStorageVault' {
        {
            $oracleExascaleDbStorageVaultList = Get-AzOracleExascaleDbStorageVault
            $oracleExascaleDbStorageVaultList.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
    It 'UpdateOracleExascaleDbStorageVault' {
        {
            $tagHashTable = @{'tagName'="tagValue"}
            Update-AzOracleExascaleDbStorageVault -Name $env.oracleExascaleDbStorageVaultName -ResourceGroupName $env.resourceGroup -Tag $tagHashTable
            $dbStorageVault = Get-AzOracleExascaleDbStorageVault -Name $env.oracleExascaleDbStorageVaultName -ResourceGroupName $env.resourceGroup
            $dbStorageVault.Tag.Get_Item("tagName") | Should -Be "tagValue"
        } | Should -Not -Throw
    }
    # It 'DeleteOracleExascaleDbStorageVault' {
    #     {
    #         Remove-AzOracleExascaleDbStorageVault -NoWait -Name $env.oracleExascaleDbStorageVaultName -ResourceGroupName $env.resourceGroup
    #     } | Should -Not -Throw
    # }
}
