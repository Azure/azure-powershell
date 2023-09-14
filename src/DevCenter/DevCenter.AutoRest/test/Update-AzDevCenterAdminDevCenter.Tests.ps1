if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminDevCenter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminDevCenter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminDevCenter' {
    It 'UpdateExpanded' {
        $devCenter = Update-AzDevCenterAdminDevCenter -Name $env.devCenterUpdate -ResourceGroupName $env.resourceGroup -IdentityType "SystemAssigned"
        $devCenter.Name | Should -Be $env.devCenterUpdate
        $devcenter.IdentityType | Should -Be "SystemAssigned"   
     }

    It 'UpdateViaIdentityExpanded' {
        $devCenterInput = Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup -Name $env.devCenterUpdate

        $devCenter = Update-AzDevCenterAdminDevCenter -InputObject $devCenterInput -IdentityType "SystemAssigned"
        $devCenter.Name | Should -Be $env.devCenterUpdate
        $devcenter.IdentityType | Should -Be "SystemAssigned" 
    }
}
