if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDynatraceMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDynatraceMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDynatraceMonitor' {
    It 'List' {
        { Get-AzDynatraceMonitor} | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzDynatraceMonitor -ResourceGroupName $env.resourceGroup -Name $env.dynatraceName01 } | Should -Not -Throw
    }

    It 'List1' {
        { Get-AzDynatraceMonitor -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { 
            $obj = Get-AzDynatraceMonitor -ResourceGroupName $env.resourceGroup -Name $env.dynatraceName01
            Get-AzDynatraceMonitor -InputObject $obj
        } | Should -Not -Throw
    }
}
