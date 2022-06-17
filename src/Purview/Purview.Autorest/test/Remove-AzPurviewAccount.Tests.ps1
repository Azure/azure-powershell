if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzPurviewAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzPurviewAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzPurviewAccount' {
    It 'Delete' {
        { Remove-AzPurviewAccount -Name $env.accountName1 -ResourceGroupName $env.resourceGroupName } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $get = Get-AzPurviewAccount -Name $env.accountName2 -ResourceGroupName $env.resourceGroupName 
        { Remove-AzPurviewAccount -InputObject $get } | Should -Not -Throw
    }
}
