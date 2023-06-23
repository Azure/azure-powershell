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

    It 'Update' {
        $identityHashTable = @{$env.identityId = @{} }
        $body = @{"IdentityType" = "UserAssigned"; "IdentityUserAssignedIdentity" = $identityHashTable }

        $devCenter = Update-AzDevCenterAdminDevCenter -Name $env.devCenterUpdate -ResourceGroupName $env.resourceGroup -Body $body
        $devCenter.Name | Should -Be $env.devCenterUpdate
        $devCenter.IdentityUserAssignedIdentity.Keys[0] | Should -Be $env.identityId
        $identityHash = $devCenter.IdentityUserAssignedIdentity | ConvertTo-Json | ConvertFrom-Json
        $identityHash.Keys[0] | Should -Be $env.identityId
        $devcenter.IdentityType | Should -Be "UserAssigned"
        }

    It 'UpdateViaIdentityExpanded' {
        $devCenterInput = Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup -Name $env.devCenterUpdate

        $devCenter = Update-AzDevCenterAdminDevCenter -InputObject $devCenterInput -IdentityType "SystemAssigned"
        $devCenter.Name | Should -Be $env.devCenterUpdate
        $devcenter.IdentityType | Should -Be "SystemAssigned" 
    }

    It 'UpdateViaIdentity' {
        $devCenterInput = Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup -Name $env.devCenterUpdate

        $identityHashTable = @{$env.identityId = @{} }
        $body = @{"IdentityType" = "UserAssigned"; "IdentityUserAssignedIdentity" = $identityHashTable }

        $devCenter = Update-AzDevCenterAdminDevCenter -InputObject $devCenterInput -Body $body
        $devCenter.Name | Should -Be $env.devCenterUpdate
        $devCenter.IdentityUserAssignedIdentity.Keys[0] | Should -Be $env.identityId
        $identityHash = $devCenter.IdentityUserAssignedIdentity | ConvertTo-Json | ConvertFrom-Json
        $identityHash.Keys[0] | Should -Be $env.identityId
        $devcenter.IdentityType | Should -Be "UserAssigned"
    }
}
