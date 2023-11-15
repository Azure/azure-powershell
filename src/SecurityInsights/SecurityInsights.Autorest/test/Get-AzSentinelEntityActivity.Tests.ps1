if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelEntityActivity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelEntityActivity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelEntityActivity' {
    It 'Queries' {
        $entities = Get-AzSentinelentity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $queries = Get-AzSentinelEntityActivity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -EntityId $entities[0].Name
        $queries.Count | Should -BeGreaterorEqual 1
    }
}
