if(($null -eq $TestName) -or ($TestName -contains 'Add-AzLabServicesUserQuota'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzLabServicesUserQuota.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'Add-AzLabServicesUserQuota' {
    It 'Add User Quota Email' {
        #$addTime = New-TimeSpan -Hours 12
        Add-AzLabServicesUserQuota -SubscriptionId $($ENV:SubscriptionId) -ResourceGroupName $($ENV:ResourceGroupName) -LabName $($ENV:LabName) -Email $($ENV:UserEmail) -UsageQuotaToAddToExisting "12:00:00" | Should -Not -BeNullOrEmpty
        Get-AzLabServicesUser -SubscriptionId $($ENV:SubscriptionId) -LabName $($ENV:LabName) -ResourceGroupName $($ENV:ResourceGroupName) -UserName $($ENV:UserName) | Select -ExpandProperty additionalUsageQuota | Should -BeExactly "12:00:00"
    }

    It 'Add User Quota Object' {
        #$addTime = New-TimeSpan -Hours 13
        $user = Get-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -UserName $ENV:UserName
        Add-AzLabServicesUserQuota -User $user -UsageQuotaToAddToExisting "13:00:00" | Should -Not -BeNullOrEmpty
        Get-AzLabServicesUser -LabName $ENV:LabName -ResourceGroupName $ENV:ResourceGroupName -UserName $ENV:UserName | Select -ExpandProperty additionalUsageQuota | Should -BeExactly "1.01:00:00"
    }
}
