if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelEntityQuery'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelEntityQuery.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelEntityQuery' -Tag 'LiveOnly' {
    It 'UpdateExpanded' {
        $entityQuery = Update-AzSentinelEntityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -EntityQueryId $env.UpdateentityQueryActivityId -Title "UpdateEntityQueryPSTest"
        $entityQuery.Title | Should -Be "UpdateEntityQueryPSTest"
    }
    It 'UpdateViaIdentityExpanded' {
        $entityQuery = Get-AzSentinelEntityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -EntityQueryId $env.UpdateViaIdentityQueryActivityId 
        $entityQueryUpdate = Update-AzSentinelEntityQuery -InputObject $entityQuery -Title "UpdateEntityQueryPSTest"
        $entityQueryUpdate.Title | Should -Be "UpdateEntityQueryPSTest"
    }
}
