### Example 1: Returns private store offer regardless of collections
```powershell
PS C:\> Get-AzMarketplaceQueryPrivateStoreOffer -PrivateStoreId 3ac32d8c-e888-4dc6-b4ff-be4d755af13a

CreatedAt ETag                                   ModifiedAt OfferDisplayName PrivateStoreId                       PublisherDisplayName SpecificPlanIdLimitation                                                     UniqueOfferId
--------- ----                                   ---------- ---------------- --------------                       -------------------- -------------------------                                                     -------------
          "ed0093ae-0000-0100-0000-61a4dab30000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {d3-azure-health-check, data3-azure-optimiser-plan, data3-managed-azure-plan} data3-limite…
          "750547d8-0000-0100-0000-61b752010000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {mgmt-limited-free, mgmt-assessment}                                          viacode_cons…
          "ef00ab05-0000-0100-0000-61a5f12f0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {RedHatEnterpriseLinux72-ARM}                                                 RedHat.RHEL_7
          "f300276b-0000-0100-0000-61a7e1af0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {128technology_conductor_hourly_427, 128technology_conductor_hourly_452}      128technolog…
          "f300296b-0000-0100-0000-61a7e1af0000"                             3ac32d8c-e888-4dc6-b4ff-be4d755af13a                      {128technology_router_100_hourly_427, 128technology_router_100_hourly_452}    128technolog…

```

This command returns private store offer regardless of collections

