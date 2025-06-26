### Example 1: Get all Cloud HSMs in your current subscription
```powershell
Get-AzCloudHsm
```

```output
IdentityPrincipalId IdentityTenantId IdentityType Location      Name                 SkuCapacity SkuFamily SkuName
------------------- ---------------- ------------ --------      ----                 ----------- --------- -------
                                     UserAssigned ukwest        chsm1                      B         Standard_B1
                                     UserAssigned ukwest        chsm2                      B         Standard_B1
```

This command gets all the Cloud HSMs in your current subscription

### Example 2:  Get a Cloud HSM in a resource group 
```powershell
Get-AzCloudHsm -ResourceGroupName 'group'
```

```output
IdentityPrincipalId IdentityTenantId IdentityType Location      Name                 SkuCapacity SkuFamily SkuName
------------------- ---------------- ------------ --------      ----                 ----------- --------- -------
                                     UserAssigned ukwest        chsm1                      B         Standard_B1
                                     UserAssigned ukwest        chsm2                      B         Standard_B1
```

This command gets all the Cloud HSMs in the resource group named group.