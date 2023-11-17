if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelEntity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelEntity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelEntity' {
    It 'List' {
        $entities = Get-AzSentinelentity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $entities.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $entities = Get-AzSentinelentity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $entity = Get-AzSentinelentity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $entities[0].Name
        $entity.Name | Should -Be $entities[0].Name
    }

    It 'GetViaIdentity' {
        $entities = Get-AzSentinelentity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $entity = Get-AzSentinelentity -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Id $entities[0].Name
        $entityViaId = Get-AzSentinelentity -InputObject $entity
        $entityViaId.Name | Should -Be $entities[0].Name
    }
}
