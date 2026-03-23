if(($null -eq $TestName) -or ($TestName -contains 'New-AzWvdSessionHost'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdSessionHost.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWvdSessionHost' {
    It 'Create' {
        $sessionHostPath = $env.StandardHostPoolPersistent + '/' + $env.SHMSessionHostNameRemove
        try {
            $sessionHost = New-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -HostPoolName $env.StandardHostPoolPersistent `
                -Name $env.SHMSessionHostNameRemove
            $sessionHost | Should -Not -BeNullOrEmpty
            $sessionHost.Name | Should -Be $sessionHostPath
        } finally {
            Remove-AzWvdSessionHost -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroupPersistent `
                -HostPoolName $env.StandardHostPoolPersistent `
                -Name $env.SHMSessionHostNameRemove `
                -Force
        }
    }
}
