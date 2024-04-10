if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSelfHelpSolution'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSelfHelpSolution.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSelfHelpSolution' -Tag 'LiveOnly'{
    It 'Get' {
        $resourceName = RandomString -allChars $false -len 10
        $criteria = [ordered]@{ 
            "name" ="SolutionId" 
            "value" = "apollo-cognitve-search-custom-skill" 
        } 
        $parameters = [ordered]@{ 
        
            "SearchText" = "Can not Search" 
        } 
        
        New-AzSelfHelpSolution -Scope $env.scope -ResourceName $resourceName -TriggerCriterion  $criteria -Parameter $parameters
        Get-AzSelfHelpSolution -Scope $env.scope -ResourceName $resourceName
    }
}
