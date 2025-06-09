### Example 1: Get Neon Organization Details
```powershell
Get-AzNeonPostgresOrganization -SubscriptionId 5d9a6cc3-4e60-4b41-be79-d28f0a01074e
```

```output
Location      Name                       SystemDataCreatedAt   SystemDataCreatedBy           SystemDataCreatedByType Sy
                                                                                                                     st
                                                                                                                     em
                                                                                                                     Da
                                                                                                                     ta
                                                                                                                     La
                                                                                                                     st
                                                                                                                     Mo
                                                                                                                     di
                                                                                                                     fi
                                                                                                                     ed
                                                                                                                     At
--------      ----                       -------------------   -------------------           ----------------------- --
eastus2       org123                     25-Oct-24 5:59:50 AM  deepkan@contoso.com        User                    25
eastus2       Sr-Neon-Org-Prod           25-Oct-24 10:04:14 AM john.dev@contoso.com       User                    25
eastus2       Sr-Neon-Org-Prod-2         25-Oct-24 10:16:08 AM neondevuser@company.com    User                    25
eastus2       ProdNeonOrg-1              29-Oct-24 5:02:55 AM  alluri@testneon.com        User                    29

```

This command will get all organization details for a subscription id
