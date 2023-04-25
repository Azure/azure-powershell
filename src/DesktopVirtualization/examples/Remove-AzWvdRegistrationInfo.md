### Example 1: Remove Registration Info
```powershell
PS C:\> Remove-AzWvdRegistrationInfo -resourceGroupName rgName -hostpoolName hpName

Etag IdentityPrincipalId IdentityTenantId IdentityType Kind Location ManagedBy Name    PlanName PlanProduct PlanPromotionCode PlanPublisher PlanVersion SkuCapacity SkuFamily SkuName SkuSize SkuTier
---- ------------------- ---------------- ------------ ---- -------- --------- ----    -------- ----------- ----------------- ------------- ----------- ----------- --------- ------- ------- -------
                                                            ukwest             hpName
```

Removes a Registration Info from a HostPool