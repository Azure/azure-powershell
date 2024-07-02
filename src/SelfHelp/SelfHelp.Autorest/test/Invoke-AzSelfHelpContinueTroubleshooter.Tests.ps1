if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzSelfHelpContinueTroubleshooter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzSelfHelpContinueTroubleshooter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzSelfHelpContinueTroubleshooter' -Tag 'LiveOnly'{
    It 'ContinueExpanded' {
        {   $resourceName = New-Guid
            $parameters = [ordered]@{
                "ResourceUri"= "/subscriptions/02d59989-f8a9-4b69-9919-1ef51df4eff6"
            }
            New-AzSelfHelpTroubleshooter -Scope $env.scope -SolutionId "e104dbdf-9e14-4c9f-bc78-21ac90382231" -Name $resourceName -Parameter $parameters
            $response = Get-AzSelfHelpTroubleshooter -Scope $env.scope -Name $resourceName 
            $jsonResponse = $response | ConvertFrom-Json -Depth 100
            $stepId = $jsonResponse.properties.steps[0].id
            $continueRequest = [ordered]@{ 

                "StepId" = $stepId 
            
            } 
            Invoke-AzSelfHelpContinueTroubleshooter  -Scope $env.scope -TroubleshooterName $resourceName -ContinueRequestBody $continueRequest
        } | Should -Not -Throw
    }
}
