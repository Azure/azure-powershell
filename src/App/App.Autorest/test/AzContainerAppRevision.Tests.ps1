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
    $revisionName = (Get-AzContainerAppRevision -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged).Name

    It 'Get' {
        {
            $config = Get-AzContainerAppRevision -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged -RevisionName $revisionName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Disable' {
        {
            $config = Disable-AzContainerAppRevision -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged -RevisionName $revisionName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'Enable' {
        {
            $config = Enable-AzContainerAppRevision -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged -RevisionName $revisionName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppRevision -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Restart' {
        {
            $config = Restart-AzContainerAppRevision -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged -Name $revisionName -PassThru
            $config | Should -Be True
        } | Should -Not -Throw
    }

    It 'RevisionReplica-Get' {
        {
            $config = Get-AzContainerAppRevisionReplica -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged -RevisionName $revisionName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
