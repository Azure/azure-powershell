if(($null -eq $TestName) -or ($TestName -contains 'New-AzSelfHelpSimplifiedSolution'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSelfHelpSimplifiedSolution.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSelfHelpSimplifiedSolution' -Tag 'LiveOnly'{
    It 'Create' {
        { 
            $resourceName = RandomString -allChars $false -len 10
            $solutionId = "9004345-7759"
            $parameters = [ordered]@{ 
            
                "SearchText" = "Billing" 
            } 
            New-AzSelfHelpSimplifiedSolution -Scope $env.scope -SResourceName $resourceName -SolutionId $solutionId -Parameter $parameters
        } | Should -Not -Throw
    }
}
