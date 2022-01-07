if(($null -eq $TestName) -or ($TestName -contains 'New-AzLogzSubAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzLogzSubAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzLogzSubAccount' {
    It 'CRUCase' {
        # New case
        $subAccount = New-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -Name $env.subAccountName05 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) `
                    -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
        $subAccount.Name | Should -Be $env.subAccountName05

        # Update case
        $subAccount = Update-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -Name $env.subAccountName05 -Tag @{'key01'=1;'key02'=2;'key03'=3}
        $subAccount.Tag.Count | Should -Be 3

        # Remove case
        Remove-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -Name $env.subAccountName05

        $subAccountList = Get-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
        $subAccountList.Name | Should -Not -Contain $env.subAccountName05
    }

    It 'CRUViaIdentityCase' {
        # New case
        $subAccount = New-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02 -Name $env.subAccountName06 -Location $env.location -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) `
        -UserInfoEmailAddress $env.userEmail -UserInfoPhoneNumber $env.userPhone -UserInfoFirstName  $env.userLastName -UserInfoLastName $env.userFirstName
        $subAccount.Name | Should -Be $env.subAccountName06

        # Update case
        $subAccount = Update-AzLogzSubAccount -InputObject $subAccount -Tag @{'key01'=1;'key02'=2;'key03'=3}
        $subAccount.Tag.Count | Should -Be 3

        # Remove case
        Remove-AzLogzSubAccount -InputObject $subAccount

        $subAccountList = Get-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName02
        $subAccountList.Name | Should -Not -Contain $env.subAccountName06
    }
}
