if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterAdminDevCenter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterAdminDevCenter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDevCenterAdminDevCenter' {
    It 'UpdateExpanded' {
        $devCenter = Set-AzDevCenterAdminDevCenter -Name $env.devCenterSet -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType "SystemAssigned"
        $devCenter.Name | Should -Be $env.devCenterSet
        $devcenter.IdentityType | Should -Be "SystemAssigned"
    }

    It 'Update' {
        $identityHashTable = @{$env.identityId = @{} }
        $body = @{"Location" = $env.location; "IdentityType" = "UserAssigned"; "IdentityUserAssignedIdentity" = $identityHashTable }

        $devCenter = Set-AzDevCenterAdminDevCenter -Name $env.devCenterSet -ResourceGroupName $env.resourceGroup -Body $body
        $devCenter.Name | Should -Be $env.devCenterSet
        $devCenter.IdentityUserAssignedIdentity.Keys[0] | Should -Be $env.identityId
        $identityHash = $devCenter.IdentityUserAssignedIdentity | ConvertTo-Json | ConvertFrom-Json
        $identityHash.Keys[0] | Should -Be $env.identityId
        $devcenter.IdentityType | Should -Be "UserAssigned"
    }
}
