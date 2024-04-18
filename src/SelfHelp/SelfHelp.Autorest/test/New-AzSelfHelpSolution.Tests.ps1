if(($null -eq $TestName) -or ($TestName -contains 'New-AzSelfHelpSolution'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSelfHelpSolution.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSelfHelpSolution' -Tag 'LiveOnly'{
    It 'CreateExpanded' {
        { 
            $resourceName = RandomString -allChars $false -len 10
            $criteria = [ordered]@{ 
                "name" ="SolutionId" 
                "value" = "apollo-cognitve-search-custom-skill" 
            } 
            $parameters = [ordered]@{ 
            
                "SearchText" = "Can not Search" 
            } 
            
            New-AzSelfHelpSolution -Scope $env.scope -ResourceName $resourceName -TriggerCriterion $criteria -Parameter $parameters
        } | Should -Not -Throw
    }
}
