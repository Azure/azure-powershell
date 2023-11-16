if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzUserAssignedIdentity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzUserAssignedIdentity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzUserAssignedIdentity' {
    It 'Delete' {
        Remove-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userIdentityName02
        $ideList = Get-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup
        $ideList.Name | Should -Not -Contain $env.userIdentityName02
    }

    It 'DeleteViaIdentity' {
        $ide = New-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup -Name $env.userIdentityName03 -Location $env.location
        Remove-AzUserAssignedIdentity -InputObject $ide
        $ideList = Get-AzUserAssignedIdentity -ResourceGroupName $env.resourceGroup
        $ideList.Name | Should -Not -Contain $env.userIdentityName02
    }
}
