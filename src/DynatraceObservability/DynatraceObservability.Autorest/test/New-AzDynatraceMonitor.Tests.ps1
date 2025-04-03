if(($null -eq $TestName) -or ($TestName -contains 'New-AzDynatraceMonitor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDynatraceMonitor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDynatraceMonitor' {
    It 'CreateExpanded' {
        {    
            New-AzDynatraceMonitor -ResourceGroupName $env.resourceGroup -Name $env.dynatraceName02 -Location $env.location -UserFirstName 'Lucas' -UserLastName 'Yao' -UserEmailAddress 'agarwalshiv@microsoft.com' -PlanUsageType "COMMITTED" -PlanBillingCycle "Monthly" -PlanDetail "azureportalintegration_privatepreview@TIDgmz7xq9ge3py" -SingleSignOnAadDomain "mpliftrlogz20210811outlook.onmicrosoft.com"
        } | Should -Not -Throw
    }
}
