if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMonitorHealthModelEntitySignalRecommendation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMonitorHealthModelEntitySignalRecommendation.Recording.json'
  $currentPath = $PSScriptRoot
  $mockingPath = $null
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMonitorHealthModelEntitySignalRecommendation' {
    It 'Get' {

        # The shared entity is not backed by an Azure resource, so the service rejects the
        # recommendation request. Assert that documented error rather than swallowing it.
        $recommendationError = $null
        try {
            Get-AzMonitorHealthModelEntitySignalRecommendation -HealthModelName $env.HealthModelName -ResourceGroupName $env.ResourceGroupName -EntityName $env.EntityName -ErrorAction Stop
        } catch {
            $recommendationError = $_
        }
        $recommendationError | Should -Not -BeNullOrEmpty
        $recommendationError.Exception.Message | Should -Match '^\[EntityHasNoAzureResource\]'
        $recommendationError.Exception.Message | Should -Match 'does not have an Azure resource assigned'
    }

    It 'GetViaIdentityHealthmodel' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

}
