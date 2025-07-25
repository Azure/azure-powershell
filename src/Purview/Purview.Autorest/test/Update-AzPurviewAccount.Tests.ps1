if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPurviewAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPurviewAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPurviewAccount' {
    It 'UpdateExpanded' {
        { Update-AzPurviewAccount -Name $env.accountName -ResourceGroupName $env.resourceGroupName -Tag @{"key"="value"} } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        $get = Get-AzPurviewAccount -Name $env.accountName -ResourceGroupName $env.resourceGroupName 
        { Update-AzPurviewAccount -InputObject $get -Tag @{"key"="value"} } | Should -Not -Throw
    }
}
