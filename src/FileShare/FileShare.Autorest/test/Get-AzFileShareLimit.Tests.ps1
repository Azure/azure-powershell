if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFileShareLimit'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFileShareLimit.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFileShareLimit' {
    It 'Get' {
        {
            $config = Get-AzFileShareLimit -Location $env.location
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $inputObj = @{ Location = $env.location }
            $config = Get-AzFileShareLimit -InputObject $inputObj
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
