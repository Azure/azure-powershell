if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelEntityQuery'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelEntityQuery.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelEntityQuery' {
    It 'List' {
        $entityQueryies = Get-AzSentinelentityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $entityQueryies.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $entityQuery = Get-AzSentinelentityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetentityQueryActivityId
        $entityQuery.Name | Should -Be $env.GetentityQueryActivityId
    }

    It 'GetViaIdentity' {
        $entityQuery = Get-AzSentinelentityQuery -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $env.GetentityQueryActivityId
        $entityQueryViaId = Get-AzSentinelentityQuery -InputObject $entityQuery
        $entityQueryViaId.Name | Should -Be $env.GetentityQueryActivityId
    }
}
