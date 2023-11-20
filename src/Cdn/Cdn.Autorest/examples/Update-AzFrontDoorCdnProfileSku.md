### Example 1: When a profile not associated with WAF policy.
```powershell
$nullUpgradePara = @{}
Update-AzFrontDoorCdnProfileSku -ProfileName profileName -ResourceGroupName rgName -ProfileUpgradeParameter $nullUpgradePara
```

```output
Location Name              Kind      ResourceGroupName
-------- ----              ----      -----------------
Global   profileName       frontdoor rgName
```
When a profile not associated with WAF policy.
Upgrade a profile from Standard_AzureFrontDoor to Premium_AzureFrontDoor.

### Example 2: When a CDN profile associated with WAF and copy to a new waf policy...
```powershell
$waf = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName waf -ChangeToWafPolicyId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/newWAFName
$upgrade = New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList $waf

Update-AzFrontDoorCdnProfileSku -ProfileName profileName -ResourceGroupName rgName -ProfileUpgradeParameter $upgrade
```

```output
Location Name              Kind      ResourceGroupName
-------- ----              ----      -----------------
Global   profileName       frontdoor rgName
```

When a CDN profile associated with WAF and copy to a new WAF policy, the subscription and resource group of the new WAF policy should be same with the profile's.
Upgrade a profile from Standard_AzureFrontDoor to Premium_AzureFrontDoor.

### Example 2: When the CDN profile associated with WAF and select an exsting WAF policy...
```powershell
$waf1 = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName waf1 -ChangeToWafPolicyId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgtest01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/existingWAFName1
$waf2 = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName waf2 -ChangeToWafPolicyId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgtest02/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/existingWAFName2
$upgrade = New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList @($waf1, $waf2)

Update-AzFrontDoorCdnProfileSku -ProfileName profileName -ResourceGroupName rgName -ProfileUpgradeParameter $upgrade
```

```output
Location Name              Kind      ResourceGroupName
-------- ----              ----      -----------------
Global   profileName       frontdoor rgName
```

When the CDN profile associated with WAF and select an exsting WAF policy, you could only select the WAF policy located in the same subscription with the profile's.
Upgrade a profile from Standard_AzureFrontDoor to Premium_AzureFrontDoor.

### Example 4: A CDN profile associated with WAF, when the subscription of the profile is different from the local subscrition
```powershell
$waf = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName waf -ChangeToWafPolicyId /subscriptions/testSubId01/resourcegroups/rgtest01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/ExistingPremiumWAFName
$upgrade = New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList $waf

Update-AzFrontDoorCdnProfileSku -ProfileName profileName -ResourceGroupName rgName -ProfileUpgradeParameter $upgrade -SubscriptionId testSubId01
```

```output
Location Name              Kind      ResourceGroupName
-------- ----              ----      -----------------
Global   profileName       frontdoor rgName
```

A CDN profile associated with WAF, when the subscription of the profile is different from the local subscrition.