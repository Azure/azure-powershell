if(($null -eq $TestName) -or ($TestName -contains 'New-AzSecurityGitLabScopeEnvironmentObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSecurityGitLabScopeEnvironmentObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSecurityGitLabScopeEnvironmentObject' {
    It '__AllParameterSets' {
        $scope = New-AzSecurityGitLabScopeEnvironmentObject
        $scope.EnvironmentType | Should -Be "GitlabScope"
    }
}
