if(($null -eq $TestName) -or ($TestName -contains 'Get-AzFileShareUsageData'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzFileShareUsageData.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzFileShareUsageData' {
    It 'Get' {
        {
            $config = Get-AzFileShareUsageData -Location $env.location
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $inputObj = @{
                Location = $env.location
                SubscriptionId = $env.SubscriptionId
            }
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.FileShare.Models.FileShareIdentity]$inputObj
            $config = Get-AzFileShareUsageData -InputObject $identity
            $config | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
