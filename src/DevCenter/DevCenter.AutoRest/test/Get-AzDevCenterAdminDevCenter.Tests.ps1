if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminDevCenter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminDevCenter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminDevCenter' {
    It 'List' {
        $listOfDevCenters = Get-AzDevCenterAdminDevCenter
        $listOfDevCenters.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $devCenter = Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup -Name $env.devCenterName
        $devCenter.Name | Should -Be $env.devCenterName
        $identityHash = $devCenter.IdentityUserAssignedIdentity | ConvertTo-Json | ConvertFrom-Json
        $identityHash.Keys[0] | Should -Be $env.identityId
        $devcenter.IdentityType | Should -Be "UserAssigned"

    }

    It 'List1' {
        $listOfDevCenters = Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup
        $listOfDevCenters.Count | Should -BeGreaterOrEqual 2
    }

    It 'GetViaIdentity' {
        $devCenter = Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup -Name $env.devCenterName
        $devCenter = Get-AzDevCenterAdminDevCenter -InputObject $devCenter
        $devCenter.Name | Should -Be $env.devCenterName
        $identityHash = $devCenter.IdentityUserAssignedIdentity | ConvertTo-Json | ConvertFrom-Json
        $identityHash.Keys[0] | Should -Be $env.identityId
        $devcenter.IdentityType | Should -Be "UserAssigned"
    }
}
