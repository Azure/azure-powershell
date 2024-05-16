if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzSelfHelpTroubleshooter'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzSelfHelpTroubleshooter.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzSelfHelpTroubleshooter' -Tag 'LiveOnly'{
    It 'End' {
        {   $resourceName = New-Guid
            $parameters = [ordered]@{
                "ResourceUri"= "/subscriptions/02d59989-f8a9-4b69-9919-1ef51df4eff6"
            }
            New-AzSelfHelpTroubleshooter -Scope $env.scope -SolutionId "e104dbdf-9e14-4c9f-bc78-21ac90382231" -Name $resourceName -Parameter $parameters
            Stop-AzSelfHelpTroubleshooter -Scope $env.scope -Name $resourceName
        } | Should -Not -Throw
    }
}