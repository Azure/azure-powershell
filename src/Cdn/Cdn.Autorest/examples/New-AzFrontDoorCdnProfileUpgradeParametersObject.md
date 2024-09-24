### Example 1: Create an in-memory object for ProfileUpgradeParameters.
```powershell
$waf1 = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName policyName -ChangeToWafPolicyId toWafPolicyId
New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList $waf1  
```

```output
WafMappingList
--------------
{{…
```

Create an in-memory object for ProfileUpgradeParameters.

### Example 2: Create an in-memory object for ProfileUpgradeParameters, show the details of the object.
```powershell
$waf1 = New-AzFrontDoorCdnProfileChangeSkuWafMappingObject -SecurityPolicyName policyName -ChangeToWafPolicyId toWafPolicyId
$upgrade = New-AzFrontDoorCdnProfileUpgradeParametersObject -WafMappingList $waf1  
$upgrade.ToString()
```

```output
{
  "wafMappingList": [
    {
      "changeToWafPolicy": {
        "id": "toWafPolicyId"
      },
      "securityPolicyName": "policyName"
    }
  ]
}
```

Create an in-memory object for ProfileUpgradeParameters, show the details of the object.