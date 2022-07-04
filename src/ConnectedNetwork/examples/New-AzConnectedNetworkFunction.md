### Example 1: 1-step VNF deployment
```powershell
$ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
$ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
$customData = "I2Nsb3VkLWNvbmZpZwp3cml0ZV9maWxlczoKLSBwYXRoOiAvdmFyL2xpYi9jbG91ZC9paHNzY29uZmlnLmpzb24KICBwZXJtaXNzaW9uczogJzA2NDQnCiAgb3duZXI6IHJvb3Q6cm9vdAogIGNvbnRlbnQ6IHwKICAgIHsKICAgICAgICAgICAiRGlhbWV0ZXJHVyI6ewogICAgICAgICAgICAgICAgICAiSE9TVElQQUREUkVTUyI6IjEyOC4wLjAuMSIsCiAgICAgICAgICAgICAgICAgICJGUUROIjoiaHNzLmF5VmVuZG9yLmNvbSIsCiAgICAgICAgICAgICAgICAgICJSRUFMTSI6Imhzcy5lcGMubXlWZW5kb3I5OS5teVZlbmRvci4zZ3BwbmV0d29yay5vcmciCiAgICAgICAgICAgfSwKICAgICAgICAgICAiREdXQmluZEFkZHIiOnsKICAgICAgICAgICAgICAgICAgIkFERFJFU1MiOiIxMjguMC4wLjIiLAogICAgICAgICAgICAgICAgICAiVFJBTlNQT1JUIjoiU0NUUCIsCiAgICAgICAgICAgICAgICAgICJQT1JUIjozODY4CiAgICAgICAgICAgfSwKICAgICAgICAgICAiU05NUFRhcmdldCI6ewogICAgICAgICAgICAgICAgICAiSE9TVCI6IjEyOC4wLjAuMyIsCiAgICAgICAgICAgICAgICAgICJQT1JUIjoiMTYyIiwKICAgICAgICAgICAgICAgICAgIlRSSUdHRVJfTEVWRUwiOiIzIgogICAgICAgICAgIH0sCiAgICAgICAgICAgIk1hbmFnZW1lbnQiOnsKICAgICAgICAgICAgICAgICAgImlwQWRkcmVzcyI6IjEyOC4wLjAuNCIsCiAgICAgICAgICAgICAgICAgICJzdWJuZXQiOiIxMjguMC4wLjEvMjQiLAogICAgICAgICAgICAgICAgICAiZ2F0ZXdheSI6IjEyOC4wLjAuMCIKICAgICAgICAgICB9LAogICAgICAgICAgICJMYW4iOnsKICAgICAgICAgICAgICAgICAgImlwQWRkcmVzcyI6IjEyOC4wLjAuNSIsCiAgICAgICAgICAgICAgICAgICJzdWJuZXQiOiIxMjguMC4wLjAvMjQiLAogICAgICAgICAgICAgICAgICAiZ2F0ZXdheSI6IjEyOC4wLjAuMCIKICAgICAgICAgICB9LAoKICAgIH0JCSAgCg=="
$userconf = New-AzConnectedNetworkFunctionUserConfigurationObject -NetworkInterface $ip1,$ip2 -OSProfileCustomData $customData -RoleName "hpehss"
New-AzConnectedNetworkFunction -Name vnf_Test1 -ResourceGroupName myResources -Location "eastus" -DeviceId /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/mec_2111_020 -SkuName Affirmed-HSS-0527 -UserConfiguration $userconf -VendorName "AffirmedVendor"
```

```output
Location Name      Etag                 ResourceGroupName
-------- ----      ----                 -----------------
eastus   vnf_Test1 "SampleEtagvalue"    myResources
```

Creating network interfaces with dynamic method allocation and ip version to IPv4. And using these to create two network configuration objects with vm switch type. Then using that to create user configuration object with role name hpehss, custom data and network interface array. Then creating NF using userconfiguration, vendor name, sku name, device name etc.

### Example 2: 2-step VNF deployment
```powershell
$ipconf1 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ipconf2 = New-AzConnectedNetworkInterfaceIPConfigurationObject -IPAllocationMethod "Dynamic" -IPVersion "IPv4"
$ip1 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf1 -Name "mrmmanagementnic1" -VMSwitchType "Management"
$ip2 = New-AzConnectedNetworkInterfaceObject -IPConfiguration $ipconf2 -Name "mrmlannic1" -VMSwitchType "Lan"
$userconfig2 = New-AzConnectedNetworkFunctionUserConfigurationObject -NetworkInterface $ip1,$ip2 -RoleName "hpehss"
$vnf1 = New-AzConnectedNetworkFunction -Name vnftest11 -DeviceId /subscriptions/xxxxx-00000-xxxxx-00000/resourceGroups/myResources/providers/Microsoft.HybridNetwork/devices/mec_autotest_01 -ResourceGroupName myResources -SubscriptionId xxxxx-00000-xxxxx-00000 -Location eastus2euap -SkuName staticSku -VendorName hssvendor01 -UserConfiguration $userconfig2 -verbose
$v2.ServiceKey
```

```output
abcd-sample-service-key-val-1234
```

Same as 1 step workflow other than no custom data field in User Configuration object. Creating a NF and will be using the service key obtained here to deploy vendor NF.