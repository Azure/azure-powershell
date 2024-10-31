if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDeidService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDeidService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDeidService' {
    It 'UpdateExpanded' {
        { 
            $config = Update-AzDeidService -ResourceGroupName $env.resourceGroupName -Name $env.deidServiceName -EnableSystemAssignedIdentity:$true -PublicNetworkAccess "Disabled"
            $config.Name | Should -Be $env.deidServiceName
            $config.PublicNetworkAccess | Should -Be "Disabled"
            $config.IdentityType | Should -Be "SystemAssigned"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        { 
            $config = Get-AzDeidService -Name $env.deidServiceName2 -ResourceGroupName $env.resourceGroupName
            $config2 = Update-AzDeidService -InputObject $config -EnableSystemAssignedIdentity $true -PublicNetworkAccess "Disabled" -Tag @{
                AzPwshTestKey = "AzPwshTestValue"
            }
            $config2.Name | Should -Be $env.deidServiceName2
            $config2.PublicNetworkAccess | Should -Be "Disabled"
            $config2.IdentityType | Should -Be "SystemAssigned"
        } | Should -Not -Throw
    }
}
