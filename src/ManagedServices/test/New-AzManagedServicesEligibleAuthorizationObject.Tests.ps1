if(($null -eq $TestName) -or ($TestName -contains 'New-AzManagedServicesEligibleAuthorizationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzManagedServicesEligibleAuthorizationObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzManagedServicesEligibleAuthorizationObject' {
    It '__AllParameterSets' -skip {
        { New-AzManagedServicesEligibleAuthorizationObject -PrincipalId $env.PrincipalId -PrincipalId $env.PrincipalIdDisplayName -RoleDefinitionId $env.RoleDefinitionId } | Should -Not -Throw
    }
}
