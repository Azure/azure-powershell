if(($null -eq $TestName) -or ($TestName -contains 'GetOperationsAzWorkloads'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'GetOperationsAzWorkloads.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'GetOperationsAzWorkloads' {
    It 'GetAzWorkloadsSapVirtualInstance' {
        $GetAzWorkloadsSapVirtualInstanceResponse = Get-AzWorkloadsSapVirtualInstance -SubscriptionId  $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $GetAzWorkloadsSapVirtualInstanceResponse.Name | Should -Be $env.SapVirtualInstanceName
    }

    It 'GetAzWorkloadsSapVirtualInstanceList' {
        $GetAzWorkloadsSapVirtualInstanceListResponse = Get-AzWorkloadsSapVirtualInstance -SubscriptionId  $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName
        $GetAzWorkloadsSapVirtualInstanceListResponse.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetAzWorkloadsSapCentralInstanceList' {
        $GetAzWorkloadsSapCentralInstanceListResponse = Get-AzWorkloadsSapCentralInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $GetAzWorkloadsSapCentralInstanceListResponse.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetAzWorkloadsSapCentralInstance' {
        $GetAzWorkloadsSapCentralInstanceResponse = Get-AzWorkloadsSapCentralInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Name $env.SapCentralInstanceName
        $GetAzWorkloadsSapCentralInstanceResponse.Name | Should -Be $env.SapCentralInstanceName
    }

    It 'GetAzWorkloadsSapApplicationInstanceList' {
        $GetAzWorkloadsSapApplicationInstanceListResponse = Get-AzWorkloadsSapApplicationInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $GetAzWorkloadsSapApplicationInstanceListResponse.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetAzWorkloadsSapApplicationInstance' {
        $GetAzWorkloadsSapApplicationInstanceResponse = Get-AzWorkloadsSapApplicationInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Name $env.SapApplicationInstanceName
        $GetAzWorkloadsSapApplicationInstanceResponse.Name | Should -Be $env.SapApplicationInstanceName
    }

    It 'GetAzWorkloadsSapDatabaseInstanceList' {
        $GetAzWorkloadsSapDatabaseInstanceListResponse = Get-AzWorkloadsSapDatabaseInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $GetAzWorkloadsSapDatabaseInstanceListResponse.Count | Should -BeGreaterOrEqual 1 
    }

    It 'GetAzWorkloadsSapDatabaseInstance' {
        $GetAzWorkloadsSapDatabaseInstanceResponse = Get-AzWorkloadsSapDatabaseInstance -SubscriptionId $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -Name $env.SapDatabseInstanceName
        $GetAzWorkloadsSapDatabaseInstanceResponse.Name | Should -Be $env.SapDatabseInstanceName
    }
}
