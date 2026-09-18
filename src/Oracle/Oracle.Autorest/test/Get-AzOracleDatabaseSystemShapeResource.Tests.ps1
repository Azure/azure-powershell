if(($null -eq $TestName) -or ($TestName -contains 'Get-AzOracleDatabaseSystemShapeResource'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzOracleDatabaseSystemShapeResource.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzOracleDatabaseSystemShapeResource' {
    # Playback requires this file's recording; use test-module.ps1 -Record to create it.
    $canRun = ((Test-Path $TestRecordingFile) -and $TestMode -eq 'playback') -or ($TestMode -ne 'playback' -and -not [string]::IsNullOrWhiteSpace($env.location) -and -not [string]::IsNullOrWhiteSpace($env.SubscriptionId))
    It 'Lists database system shapes for the configured location' -Skip:(-not $canRun) {
        {
            $shapes = @(Get-AzOracleDatabaseSystemShapeResource -Location $env.location -SubscriptionId $env.SubscriptionId)
            $shapes | Should -Not -BeNullOrEmpty
            $shapes[0].Name | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }
}
