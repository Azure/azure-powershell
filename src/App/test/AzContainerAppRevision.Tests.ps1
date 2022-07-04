if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppRevision'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppRevision.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppRevision' {
    $revisionName = (Get-AzContainerAppRevision -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup).Name

    It 'Get' {
        {
            $config = Get-AzContainerAppRevision -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup -RevisionName $revisionName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Disable' {
        {
            $config = Disable-AzContainerAppRevision -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup -RevisionName $revisionName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Enable' {
        {
            $config = Enable-AzContainerAppRevision -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup -RevisionName $revisionName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppRevision -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Restart' {
        {
            $config = Restart-AzContainerAppRevision -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup -RevisionName $revisionName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'RevisionReplica-Get' -skip {
        {
            $config = Get-AzContainerAppRevisionReplica -ContainerAppName $env.containerAppName -ResourceGroupName $env.resourceGroup -RevisionName $revisionName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
