if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppJob'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppJob.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppJob' {
    It 'CreateExpanded' {
        {
            $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv1).Id
            $probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
            $probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
            $temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"

            $config = New-AzContainerAppJob -Name $env.containerAppJob1 -ResourceGroupName $env.resourceGroupManaged -Location $env.location -ConfigurationReplicaRetryLimit 10 -ConfigurationReplicaTimeout 10 -ConfigurationTriggerType Manual -EnvironmentId $EnvId -ManualTriggerConfigParallelism 4 -ManualTriggerConfigReplicaCompletionCount 1 -TemplateContainer $temp
            $config.Name | Should -Be $env.containerAppJob1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzContainerAppJob
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzContainerAppJob -Name $env.containerAppJob1 -ResourceGroupName $env.resourceGroupManaged
            $config.Name | Should -Be $env.containerAppJob1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzContainerAppJob -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName $env.resourceGroupManaged -Name $env.managedEnv1).Id
            $probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
            $probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
            $temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"

            $config = Update-AzContainerAppJob -Name $env.containerAppJob1 -ResourceGroupName $env.resourceGroupManaged -ConfigurationReplicaRetryLimit 10 -ConfigurationReplicaTimeout 10 -ConfigurationTriggerType Manual -EnvironmentId $EnvId -ManualTriggerConfigParallelism 4 -ManualTriggerConfigReplicaCompletionCount 1 -TemplateContainer $temp
            $config.Name | Should -Be $env.containerAppJob1
        } | Should -Not -Throw
    }

    It 'StartExpanded' {
        {
            $initContainer = New-AzContainerAppJobExecutionContainerObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:lates" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"
            $config = Start-AzContainerAppJob -Name $env.containerAppJob1 -ResourceGroupName $env.resourceGroupManaged -InitContainer $initContainer
            $config.Count | Should -BeGreaterThan 0

            $config = Get-AzContainerAppJobExecution -JobName $env.containerAppJob1 -ResourceGroupName $env.resourceGroupManaged -Name $config.Name
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'JobSecretList' -Skip {
        {
            $config = Get-AzContainerAppJobSecret -JobName $env.containerAppJob1 -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzContainerAppJob -Name $env.containerAppJob1 -ResourceGroupName $env.resourceGroupManaged
        } | Should -Not -Throw
    }
}
