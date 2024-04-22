if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSelfHelpWarmSolutionUp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSelfHelpWarmSolutionUp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSelfHelpWarmSolutionUp' -Tag 'LiveOnly'{
    It 'WarmExpanded' {
        { 
            $resourceName = RandomString -allChars $false -len 10
            $parameters = [ordered]@{ 
                "ProductId" = "13491"
            }
            Invoke-AzSelfHelpWarmSolutionUp -Scope $env.scope -SolutionResourceName $resourceName -Parameter $parameters
        } | Should -Not -Throw
    }
}
