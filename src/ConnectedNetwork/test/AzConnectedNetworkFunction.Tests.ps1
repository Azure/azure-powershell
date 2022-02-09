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
            $customData = "I2Nsb3VkLWNvbmZpZwp3cml0ZV9maWxlczoKLSBwYXRoOiAvdmFyL2xpYi9jbG91ZC9paHNzY29uZmlnLmpzb24KICBwZXJtaXNzaW9uczogJzA2NDQnCiAgb3duZXI6IHJvb3Q6cm9vdAogIGNvbnRlbnQ6IHwKICAgIHsKICAgICAgICAgICAiRGlhbWV0ZXJHVyI6ewogICAgICAgICAgICAgICAgICAiSE9TVElQQUREUkVTUyI6IjEyOC4wLjAuMSIsCiAgICAgICAgICAgICAgICAgICJGUUROIjoiaHNzLmF5VmVuZG9yLmNvbSIsCiAgICAgICAgICAgICAgICAgICJSRUFMTSI6Imhzcy5lcGMubXlWZW5kb3I5OS5teVZlbmRvci4zZ3BwbmV0d29yay5vcmciCiAgICAgICAgICAgfSwKICAgICAgICAgICAiREdXQmluZEFkZHIiOnsKICAgICAgICAgICAgICAgICAgIkFERFJFU1MiOiIxMjguMC4wLjIiLAogICAgICAgICAgICAgICAgICAiVFJBTlNQT1JUIjoiU0NUUCIsCiAgICAgICAgICAgICAgICAgICJQT1JUIjozODY4CiAgICAgICAgICAgfSwKICAgICAgICAgICAiU05NUFRhcmdldCI6ewogICAgICAgICAgICAgICAgICAiSE9TVCI6IjEyOC4wLjAuMyIsCiAgICAgICAgICAgICAgICAgICJQT1JUIjoiMTYyIiwKICAgICAgICAgICAgICAgICAgIlRSSUdHRVJfTEVWRUwiOiIzIgogICAgICAgICAgIH0sCiAgICAgICAgICAgIk1hbmFnZW1lbnQiOnsKICAgICAgICAgICAgICAgICAgImlwQWRkcmVzcyI6IjEyOC4wLjAuNCIsCiAgICAgICAgICAgICAgICAgICJzdWJuZXQiOiIxMjguMC4wLjEvMjQiLAogICAgICAgICAgICAgICAgICAiZ2F0ZXdheSI6IjEyOC4wLjAuMCIKICAgICAgICAgICB9LAogICAgICAgICAgICJMYW4iOnsKICAgICAgICAgICAgICAgICAgImlwQWRkcmVzcyI6IjEyOC4wLjAuNSIsCiAgICAgICAgICAgICAgICAgICJzdWJuZXQiOiIxMjguMC4wLjAvMjQiLAogICAgICAgICAgICAgICAgICAiZ2F0ZXdheSI6IjEyOC4wLjAuMCIKICAgICAgICAgICB9LAoKICAgIH0JCSAgCg=="
            $userconf = New-AzConnectedNetworkFunctionUserConfigurationObject -NetworkInterface $ip1,$ip2 -OSProfileCustomData $customData -RoleName "hpehss"
            $config = New-AzConnectedNetworkFunction -Name "vnf_Test1" -ResourceGroupName $env.ResourceGroupName3 -Location $env.Location -DeviceId "/subscriptions/${env.SubscriptionId}/resourceGroups/${env.ResourceGroupName3}/providers/Microsoft.HybridNetwork/devices/${env.DeviceName3}" -SkuName "Affirmed-HSS-0527" -UserConfiguration $userconf -VendorName "AffirmedVendor"
            $config.Name | Should -Be "vnf_Test1"

            $ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
            $ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
            $ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
            $userconfig2 = New-AzConnectedNetworkFunctionUserConfigurationObject -NetworkInterface $ip1,$ip2 -RoleName "hpehss"
            $config = New-AzConnectedNetworkFunction -Name "vnftest11" -DeviceId "/subscriptions/${env.SubscriptionId}/resourceGroups/${env.ResourceGroupName3}/providers/Microsoft.HybridNetwork/devices/${env.DeviceName3}" -ResourceGroupName $env.ResourceGroupName3 -SubscriptionId $env.SubscriptionId -Location "eastus2euap" -SkuName "staticSku" -VendorName "hssvendor01" -UserConfiguration $userconfig2 -verbose
            $config.Name | Should -Be "vnftest11"
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
            $config = Get-AzConnectedNetworkFunction -Name "vnf_Test1" -ResourceGroupName $env.ResourceGroupName3 
            $config.Name | Should -Be "vnf_Test1"
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzConnectedNetworkFunction -ResourceGroupName $env.ResourceGroupName3
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzConnectedNetworkFunctionTag -NetworkFunctionName "vnftest11" -ResourceGroupName $env.ResourceGroupName3 -Tag @{"abc"="123"}
            $config.Name | Should -Be "vnftest11"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzConnectedNetworkFunction -Name "vnf_Test1" -ResourceGroupName $env.ResourceGroupName3 
            $config = Update-AzConnectedNetworkFunctionTag -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be "vnf_Test1"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzConnectedNetworkFunction -Name "vnf_Test1" -ResourceGroupName $env.ResourceGroupName3
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzConnectedNetworkFunction -Name "vnftest11" -ResourceGroupName $env.ResourceGroupName3 
            Remove-AzConnectedNetworkFunction -InputObject $config
        } | Should -Not -Throw
    }
}
