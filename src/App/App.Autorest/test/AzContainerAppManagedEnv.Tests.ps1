if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppManagedEnv'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppManagedEnv.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppManagedEnv' {

    # Contains confidential information, please run it locally

    It 'CreateExpanded' -Skip {
        {
            $CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName $env.resourceGroupManaged -Name $env.managedWorkSpace).CustomerId
            $SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $env.resourceGroupManaged -Name $env.managedWorkSpace).PrimarySharedKey
            $workloadProfile = New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"

            $config = New-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv2 -Location $env.location -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false -WorkloadProfile $workloadProfile
            $config.Name | Should -Be $env.managedEnv2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppManagedEnv
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv2
            $config.Name | Should -Be $env.managedEnv2
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -Skip {
        {
            Update-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv2 -Tag @{"123"="abc"}
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv2
        } | Should -Not -Throw
    }
}
