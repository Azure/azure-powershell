if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSelfHelpSolutionSelfHelp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSelfHelpSolutionSelfHelp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSelfHelpSolutionSelfHelp' -Tag 'LiveOnly'{
    It 'Get' {
        { 
            Get-AzSelfHelpSolutionSelfHelp -SolutionId "apollo-48996ff7-002f-47c1-85b2-df138843d5d5"
         } | Should -Not -Throw
    }
}
