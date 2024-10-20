if(($null -eq $TestName) -or ($TestName -contains 'Update-AzHealthDeidService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzHealthDeidService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzHealthDeidService' {
    It 'UpdateExpanded' {
        { 
            $config = Update-AzHealthDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceName -EnableSystemAssignedIdentity $true -PublicNetworkAccess "Disabled"
            $config.Name | Should -Be $env.deidServiceName
            $config.PublicNetworkAccess | Should -Be "Disabled"
            $config.Identity.Type | Should -Be "SystemAssigned"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
            $config = Get-AzHealthDeidService -Name $env.deidServiceNameWithPL -ResourceGroupName $env.resourceGroupName
            $config2 = Update-AzHealthDeidService -InputObject $config -EnableSystemAssignedIdentity $true -PublicNetworkAccess "Disabled" -Tag @{
                AzPwshTestKey = "AzPwshTestValue"
            }
            $config2.Name | Should -Be $env.deidServiceName
            $config2.PublicNetworkAccess | Should -Be "Disabled"
            $config2.Identity.Type | Should -Be "SystemAssigned"
            $config2.Tags.AzPwshTestKey | Should -Be "AzPwshTestValue"
        } | Should -Not -Throw
    }
}
