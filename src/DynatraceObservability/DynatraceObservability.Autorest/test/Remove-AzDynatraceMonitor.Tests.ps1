if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDynatraceMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDynatraceMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDynatraceMonitor' {
    It 'Delete' {
        { Remove-AzDynatraceMonitor -ResourceGroupName $env.resourceGroup -Name $env.dynatraceName02 } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        { 
            $obj = New-AzDynatraceMonitor -ResourceGroupName $env.resourceGroup -Name $env.dynatraceName03 -Location $env.location -UserFirstName 'Lucas' -UserLastName 'Yao' -UserEmailAddress 'agarwalshiv@microsoft.com' -PlanUsageType "COMMITTED" -PlanBillingCycle "Monthly" -PlanDetail "azureportalintegration_privatepreview@TIDgmz7xq9ge3py" -SingleSignOnAadDomain "mpliftrlogz20210811outlook.onmicrosoft.com" 
            Remove-AzDynatraceMonitor -InputObject $obj
        } | Should -Not -Throw
    }
}
