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
$waf = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName waf -ChangeToWafPolicyId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgtest01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/newWAFName
$upgrade = New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList $waf

Update-AzFrontDoorCdnProfileSku -ProfileName profileName -ResourceGroupName rgName -ProfileUpgradeParameter $upgrade
```

```output
Location Name              Kind      ResourceGroupName
-------- ----              ----      -----------------
Global   profileName       frontdoor rgName
```

When a CDN profile associated with WAF and copy to a new waf policy...
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

When the CDN profile associated with WAF and select an exsting WAF policy...
Upgrade a profile from Standard_AzureFrontDoor to Premium_AzureFrontDoor.
