if(($null -eq $TestName) -or ($TestName -contains 'AzMonitorWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMonitorWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMonitorWorkspace' {
    It 'CreateExpanded' {
        {
            $config = New-AzMonitorWorkspace -Name $env.monitorWorkspace1 -ResourceGroupName $env.resourceGroup -Location $env.location
            $config.Name | Should -Be $env.monitorWorkspace1
            $config = New-AzMonitorWorkspace -Name $env.monitorWorkspace2 -ResourceGroupName $env.resourceGroup -Location $env.location
            $config.Name | Should -Be $env.monitorWorkspace2
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzMonitorWorkspace
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMonitorWorkspace -ResourceGroupName $env.resourceGroup -Name $env.monitorWorkspace1
            $config.Name | Should -Be $env.monitorWorkspace1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMonitorWorkspace -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzMonitorWorkspace -ResourceGroupName $env.resourceGroup -Name $env.monitorWorkspace1 -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.monitorWorkspace1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzMonitorWorkspace -ResourceGroupName $env.resourceGroup -Name $env.monitorWorkspace2
            $config = Update-AzMonitorWorkspace -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.monitorWorkspace2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMonitorWorkspace -ResourceGroupName $env.resourceGroup -Name $env.monitorWorkspace1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzMonitorWorkspace -ResourceGroupName $env.resourceGroup -Name $env.monitorWorkspace2
            Remove-AzMonitorWorkspace -InputObject $config
        } | Should -Not -Throw
    }
}
