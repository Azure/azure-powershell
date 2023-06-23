if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterAdminPool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterAdminPool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDevCenterAdminPool' {
    It 'UpdateExpanded' {
        $pool = Set-AzDevCenterAdminPool -Name $env.poolSet -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -Location $env.location -DevBoxDefinitionName $env.devBoxDefinitionSet -LocalAdministrator "Disabled" -NetworkConnectionName $env.attachedNetworkName -StopOnDisconnectGracePeriodMinute 80 -StopOnDisconnectStatus "Disabled"
        $pool.Name | Should -Be $env.poolSet
        $pool.DevBoxDefinitionName | Should -Be $env.devBoxDefinitionSet
        $pool.LocalAdministrator | Should -Be "Disabled"
        $pool.NetworkConnectionName | Should -Be $env.attachedNetworkName
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 80
        $pool.StopOnDisconnectStatus | Should -Be "Disabled"
        $pool.LicenseType | Should -Be "Windows_Client"
        }

    It 'Update' {
        $body = @{"Location" = $env.location; "DevBoxDefinitionName" = $env.devBoxDefinitionName; "LocalAdministrator" = "Enabled" ; "NetworkConnectionName" = $env.attachedNetworkName; "StopOnDisconnectGracePeriodMinute" = 60; "StopOnDisconnectStatus" = "Enabled"}
        $pool = Set-AzDevCenterAdminPool -Name $env.poolSet -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup -Body $body  
        $pool.Name | Should -Be $env.poolSet
        $pool.DevBoxDefinitionName | Should -Be $env.devBoxDefinitionName
        $pool.LocalAdministrator | Should -Be "Enabled"
        $pool.NetworkConnectionName | Should -Be $env.attachedNetworkName
        $pool.StopOnDisconnectGracePeriodMinute | Should -Be 60
        $pool.StopOnDisconnectStatus | Should -Be "Enabled"
        $pool.LicenseType | Should -Be "Windows_Client"
    }
}
