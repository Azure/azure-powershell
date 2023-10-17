if(($null -eq $TestName) -or ($TestName -contains 'New-AzLogAnalyticsDestinationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzLogAnalyticsDestinationObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzLogAnalyticsDestinationObject' {
    It '__AllParameterSets' -skip {
        {
            New-AzLogAnalyticsDestinationObject -Name centralWorkspace -WorkspaceResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/sipstestcx9d03/providers/microsoft.operationalinsights/workspaces/asptest4k37qz
        } | Should -Not -Throw
    }
}
