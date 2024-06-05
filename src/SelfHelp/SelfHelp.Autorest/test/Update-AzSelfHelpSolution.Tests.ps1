if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSelfHelpSolution'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSelfHelpSolution.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSelfHelpSolution' -Tag 'LiveOnly'{
    It 'UpdateExpanded' {
        { 
            $resourceName = RandomString -allChars $false -len 10
            $criteriaReplacementKey = [ordered]@{ 
                "name" ="ReplacementKey" 
                "value" = "<!--85c7bc9e-4405-4e3a-82b0-8c4edc29a04d-->" 
            } 
            $criteria = [ordered]@{ 
                "name" ="SolutionId" 
                "value" = "apollo-cognitve-search-custom-skill" 
            } 
            $parameters = [ordered]@{ 
            
                "SearchText" = "Can not Search" 
            }
           New-AzSelfHelpSolution -Scope $env.scope -ResourceName $resourceName -TriggerCriterion $criteria -Parameter $parameters 
           Update-AzSelfHelpSolution -Scope $env.scope -ResourceName $resourceName -TriggerCriterion $criteriaReplacementKey -Parameter $parameters
         } | Should -Not -Throw
    }
}
