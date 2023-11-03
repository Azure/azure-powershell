if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzSentinelEntityQuery'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSentinelEntityQuery.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSentinelEntityQuery' {
    It 'Delete' {
        { Remove-AzSentinelEntityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.RemoveentityQueryActivityId } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        $entityQuery = Get-AzSentinelEntityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName `
            -Id $env.RemoveViaIdentityQueryActivityId
        { Remove-AzSentinelEntityQuery -InputObject $entityQuery } | Should -Not -Throw
    }
}
