if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterAdminDevCenter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterAdminDevCenter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterAdminDevCenter' {
    It 'Delete' {
        Remove-AzDevCenterAdminDevCenter -Name $env.devCenterNameDelete -ResourceGroupName $env.resourceGroup
        { Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup -Name $env.devCenterNameDelete } | Should -Throw
    }

    It 'DeleteViaIdentity' {
        $devCenter = Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup -Name $env.devCenterNameDelete2

        Remove-AzDevCenterAdminDevCenter -InputObject $devCenter
        { Get-AzDevCenterAdminDevCenter -ResourceGroupName $env.resourceGroup -Name $env.devCenterNameDelete2 } | Should -Throw

    }
}
