if(($null -eq $TestName) -or ($TestName -contains 'Get-AzPurviewAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzPurviewAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzPurviewAccount' {
    It 'List1' {
        { Get-AzPurviewAccount } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzPurviewAccount -Name $env.accountName -ResourceGroupName $env.resourceGroupName } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzPurviewAccount -ResourceGroupName $env.resourceGroupName } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        $get = Update-AzPurviewAccount -Name $env.accountName -ResourceGroupName $env.resourceGroupName -Tag @{"key"="value"}
        { Get-AzPurviewAccount -InputObject $get } | Should -Not -Throw
    }
}
