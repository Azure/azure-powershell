if(($null -eq $TestName) -or ($TestName -contains 'New-AzFrontDoorHeaderActionObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFrontDoorHeaderActionObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFrontDoorHeaderActionObject' {
    It '__AllParameterSets' -skip {
        $headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Append" -HeaderName "X-Content-Type-Options" -Value "nosniff"
        $headerActions.HeaderActionType | Should -Be "Append"
        $headerActions.HeaderName | Should -Be "X-Content-Type-Options"
        $headerActions.Value | Should -Be "nosniff"
    }
}
