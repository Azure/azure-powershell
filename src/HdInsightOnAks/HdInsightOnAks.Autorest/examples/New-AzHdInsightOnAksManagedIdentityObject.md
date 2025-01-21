### Example 1: Create a Managed Identity object
```powershell
New-AzHdInsightOnAksManagedIdentityObject -ClientId 00000000-0000-0000-0000-000000000000 -ObjectId 00000000-0000-0000-0000-000000000000 -ResourceId /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/msi -Type cluster
```

```output
ClientId                             ObjectId                             ResourceId                                                                                                                              Type
--------                             --------                             ----------                                                                                                                              ----
00000000-0000-0000-0000-000000000000 00000000-0000-0000-0000-000000000000 /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Group/providers/Microsoft.ManagedIdentity/userAssignedIdentities/msi cluster
```

Create a Managed Identity object

