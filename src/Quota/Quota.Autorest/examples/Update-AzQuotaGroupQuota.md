##TODO##: Cannot update GroupQuota if subscriptions are added. Error: "GroupQuota properties cannot be changed, if subscriptions are added or Quotais allocated."

### Example 1: Update GroupQuota display name
```powershell
Update-AzQuotaGroupQuota -ManagementGroupId "mgId" -Name "groupquota1" -DisplayName "Updated Quota Group Name"
```

```output
Name         DisplayName              ProvisioningState GroupType
----         -----------              ----------------- ---------
groupquota1  Updated Quota Group Name Succeeded         AllocationGroup
```

Update the display name of an existing GroupQuota.

