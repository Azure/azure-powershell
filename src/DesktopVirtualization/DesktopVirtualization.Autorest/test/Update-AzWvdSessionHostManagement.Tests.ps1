if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWvdSessionHostManagement'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdSessionHostManagement.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWvdSessionHostManagement' {
    It 'UpdateExpanded'  {
        $management = Update-AzWvdSessionHostManagement -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent `
            -UpdateLogoffMessage "Updating HostpoolUpdate is great!"

        $management.UpdateLogoffMessage | Should -Be "Updating HostpoolUpdate is great!"

    }
}
