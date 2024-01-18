if(($null -eq $TestName) -or ($TestName -contains 'AzMobileNetworkSimPolicy'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzMobileNetworkSimPolicy.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzMobileNetworkSimPolicy' {
    It 'CreateExpanded' {
        {
            $ServiceResourceId = New-AzMobileNetworkServiceResourceIdObject -Id "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.MobileNetwork/mobileNetworks/$($env.testNetwork2)/services/$($env.testService)"
            $DataNetworkConfiguration = New-AzMobileNetworkDataNetworkConfigurationObject -AllowedService $ServiceResourceId -DataNetworkId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.MobileNetwork/mobileNetworks/$($env.testNetwork2)/dataNetworks/$($env.testDataNetwork)" -SessionAmbrDownlink "1 Gbps" -SessionAmbrUplink "500 Mbps" -FiveQi 9 -AllocationAndRetentionPriorityLevel 9 -DefaultSessionType 'IPv4' -MaximumNumberOfBufferedPacket 200 -PreemptionCapability 'NotPreempt' -PreemptionVulnerability 'Preemptable'
            $SliceConfiguration = New-AzMobileNetworkSliceConfigurationObject -DataNetworkConfiguration $DataNetworkConfiguration -DefaultDataNetworkId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.MobileNetwork/mobileNetworks/$($env.testNetwork2)/dataNetworks/$($env.testDataNetwork)" -SliceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.MobileNetwork/mobileNetworks/$($env.testNetwork2)/slices/$($env.testSlice)"
            $config = New-AzMobileNetworkSimPolicy -MobileNetworkName $env.testNetwork2 -Name $env.testSimPolicy -ResourceGroupName $env.resourceGroup -Location $env.location -DefaultSliceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.MobileNetwork/mobileNetworks/$($env.testNetwork2)/slices/$($env.testSlice)" -SliceConfiguration $SliceConfiguration -UeAmbrDownlink "1 Gbps" -UeAmbrUplink "500 Mbps" -RegistrationTimer 3240
            $config.Name | Should -Be $env.testSimPolicy
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzMobileNetworkSimPolicy -MobileNetworkName $env.testNetwork2 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzMobileNetworkSimPolicy -MobileNetworkName $env.testNetwork2 -ResourceGroupName $env.resourceGroup -Name $env.testSimPolicy
            $config.Name | Should -Be $env.testSimPolicy
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' -skip {
        {
            $config = Update-AzMobileNetworkSimPolicy -MobileNetworkName $env.testNetwork2 -ResourceGroupName $env.resourceGroup -SimPolicyName $env.testSimPolicy -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.testSimPolicy
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzMobileNetworkSimPolicy -MobileNetworkName $env.testNetwork2 -ResourceGroupName $env.resourceGroup -Name $env.testSimPolicy
        } | Should -Not -Throw
    }
}
