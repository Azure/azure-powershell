if(($null -eq $TestName) -or ($TestName -contains 'Get-AzLogzSubAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzLogzSubAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzLogzSubAccount' {
    It 'List' {
        $subAccountList = Get-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01
        $subAccountList.Count | Should -Be 2
    }

    It 'Get' {
        $subAccount = Get-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name $env.subAccountName01
        $subAccount.Name | Should -Be $env.subAccountName01
    }

    It 'GetViaIdentity' {
        $subAccount = Get-AzLogzSubAccount -ResourceGroupName $env.resourceGroup -MonitorName $env.monitorName01 -Name $env.subAccountName01
        $subAccount = Get-AzLogzSubAccount -InputObject $subAccount
        $subAccount.Name | Should -Be $env.subAccountName01
    }
}
