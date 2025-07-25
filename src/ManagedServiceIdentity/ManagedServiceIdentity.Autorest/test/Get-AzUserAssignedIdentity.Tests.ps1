if(($null -eq $TestName) -or ($TestName -contains 'Get-AzUserAssignedIdentity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzUserAssignedIdentity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzUserAssignedIdentity' {
    It 'List' {
        $ideList = Get-AzUserAssignedIdentity
        $ideList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $ide = Get-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userIdentityName01
        $ide.Name | Should -Be $env.userIdentityName01
    }

    It 'List1' {
        $ideList = Get-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup
        $ideList.Count | Should -Be 1
    }

    It 'GetViaIdentity' {
        $ide = Get-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userIdentityName01
        $ide = Get-AzUserAssignedIdentity -InputObject $ide
        $ide.Name | Should -Be $env.userIdentityName01
    }
}
