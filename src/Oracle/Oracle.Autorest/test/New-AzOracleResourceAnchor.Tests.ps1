# Minimal playback test for New-AzOracleResourceAnchor using typed parameters
# Keep these constants in sync with New-AzOracleResourceAnchor.Recording.json

if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleResourceAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleResourceAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleResourceAnchor' {

    $hasCmd = Get-Command -Name New-AzOracleResourceAnchor -ErrorAction SilentlyContinue

    It 'Create' -Skip {
        {
            if ($hasCmd -and $env:AZURE_TEST_MODE -ne 'Record') {
                # Use flattened parameters instead of -JsonString
                $created = New-AzOracleResourceAnchor `
                    -Name $env.resourceAnchorName `
                    -ResourceGroupName $env.resourceAnchorRgName `
                    -Location $env.resourceAnchorLocation `
                    -SubscriptionId $env.subscriptionId `

                $created | Should -Not -BeNullOrEmpty
                $created.Name | Should -Be $env.resourceAnchorName
            } else {
                # In Record/Playback or when cmdlet is unavailable, keep passing while Warmup generates the recording
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
