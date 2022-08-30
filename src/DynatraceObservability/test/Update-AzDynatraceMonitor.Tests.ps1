if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDynatraceMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDynatraceMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDynatraceMonitor' {
    It 'UpdateExpanded' {
        { Update-AzDynatraceMonitor -ResourceGroupName $env.resourceGroup -Name $env.dynatraceName01 -Tag @{'key' = 'test'} } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded'  {
        {
            $obj = Get-AzDynatraceMonitor -ResourceGroupName $env.resourceGroup -Name $env.dynatraceName01 
            Update-AzDynatraceMonitor -InputObject $obj -Tag @{'key' = 'test'}
        } | Should -Not -Throw
    }
}
