if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDatadogBillingInfo'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDatadogBillingInfo.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDatadogBillingInfo' {
    It 'Get' {
        { Get-AzDatadogBillingInfo -MonitorName $env.monitorName01 -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
   		    $obj = Get-AzDatadogMonitor -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
   	    	Get-AzDatadogBillingInfo -InputObject $obj
    	} | Should -Not -Throw
    }
}
