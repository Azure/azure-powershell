if(($null -eq $TestName) -or ($TestName -contains 'AzConnectedNetworkFunction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzConnectedNetworkFunction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzConnectedNetworkFunction' {
    It 'CreateExpanded' {
        {
            $ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
            $ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
            $customData = "I2Nsb3VkLWNvbmZpZwp3cml0ZV9maWxlczoKLSBwYXRoOiAvdmFyL2xpYi9jbG91ZC9pZXh0Y29uZmlnLmpzb24KICBwZXJtaXNzaW9uczogJzA2NDQnCiAgb3duZXI6IHJvb3Q6cm9vdAogIGNvbnRlbnQ6IHwKICAgIHsKICAgICAgICAgICAiRGlhbWV0ZXJHVyI6ewogICAgICAgICAgICAgICAgICAiSE9TVElQQUREUkVTUyI6IjEyOC4wLjAuMSIsCiAgICAgICAgICAgICAgICAgICJGUUROIjoiZXh0Lm15VmVuZG9yLmNvbSIsCiAgICAgICAgICAgICAgICAgICJSRUFMTSI6ImV4dC5teVZlbmRvcjk5Lm15VmVuZG9yLjNncHBuZXR3b3JrLm9yZyIKICAgICAgICAgICB9LAogICAgICAgICAgICJER1dCaW5kQWRkciI6ewogICAgICAgICAgICAgICAgICAiQUREUkVTUyI6IjEyOC4wLjAuMiIsCiAgICAgICAgICAgICAgICAgICJUUkFOU1BPUlQiOiJTQ1RQIiwKICAgICAgICAgICAgICAgICAgIlBPUlQiOjM4NjgKICAgICAgICAgICB9LAogICAgICAgICAgICJTTk1QVGFyZ2V0Ijp7CiAgICAgICAgICAgICAgICAgICJIT1NUIjoiMTI4LjAuMC4zIiwKICAgICAgICAgICAgICAgICAgIlBPUlQiOiIxNjIiLAogICAgICAgICAgICAgICAgICAiVFJJR0dFUl9MRVZFTCI6IjMiCiAgICAgICAgICAgfSwKICAgICAgICAgICAiTWFuYWdlbWVudCI6ewogICAgICAgICAgICAgICAgICAiaXBBZGRyZXNzIjoiMTI4LjAuMC40IiwKICAgICAgICAgICAgICAgICAgInN1Ym5ldCI6IjEyOC4wLjAuMS8yNCIsCiAgICAgICAgICAgICAgICAgICJnYXRld2F5IjoiMTI4LjAuMC4wIgogICAgICAgICAgIH0sCiAgICAgICAgICAgIkxhbiI6ewogICAgICAgICAgICAgICAgICAiaXBBZGRyZXNzIjoiMTI4LjAuMC41IiwKICAgICAgICAgICAgICAgICAgInN1Ym5ldCI6IjEyOC4wLjAuMC8yNCIsCiAgICAgICAgICAgICAgICAgICJnYXRld2F5IjoiMTI4LjAuMC4wIgogICAgICAgICAgIH0sCgogICAgfQkJICAK"
            $userconf = New-AzConnectedNetworkFunctionUserConfigurationObject -NetworkInterface $ip1,$ip2 -OSProfileCustomData $customData -RoleName "myRole"
            $config = New-AzConnectedNetworkFunction -Name $env.Vnf3 -ResourceGroupName $env.existingResourceGroup -Location $env.Location -DeviceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.existingResourceGroup)/providers/Microsoft.HybridNetwork/devices/$($env.existingDevice)" -SkuName "sku123" -UserConfiguration $userconf -VendorName $env.existingVendor -SubscriptionId $env.SubscriptionId
            $config.Name | Should -Be $env.Vnf3

            $config = New-AzConnectedNetworkFunction -Name $env.Vnf2 -ResourceGroupName $env.existingResourceGroup -Location $env.Location -DeviceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.existingResourceGroup)/providers/Microsoft.HybridNetwork/devices/$($env.existingDevice)" -SkuName "sku123" -UserConfiguration $userconf -VendorName $env.existingVendor -SubscriptionId $env.SubscriptionId
            $config.Name | Should -Be $env.Vnf2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzConnectedNetworkFunction
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzConnectedNetworkFunction -Name $env.Vnf3 -ResourceGroupName $env.existingResourceGroup 
            $config.Name | Should -Be $env.Vnf3
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzConnectedNetworkFunction -ResourceGroupName $env.existingResourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzConnectedNetworkFunctionTag -NetworkFunctionName $env.Vnf3 -ResourceGroupName $env.existingResourceGroup -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.Vnf3
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzConnectedNetworkFunction -Name $env.Vnf2 -ResourceGroupName $env.existingResourceGroup 
            $config = Update-AzConnectedNetworkFunctionTag -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.Vnf2
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzConnectedNetworkFunction -Name $env.Vnf3 -ResourceGroupName $env.existingResourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzConnectedNetworkFunction -Name $env.Vnf2 -ResourceGroupName $env.existingResourceGroup 
            Remove-AzConnectedNetworkFunction -InputObject $config
        } | Should -Not -Throw
    }
}
