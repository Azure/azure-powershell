### Example 1: Get Solution Metadata by resource id

```powershell
 Get-AzSelfHelpDiscoverySolution -Scope "subscriptions/6bded6d5-a6df-44e1-96d3-bf71f6f5f8ba/resourceGroups/test-rgName/providers/Microsoft.KeyVault/vaults/testKeyVault" -Filter "problemClassificationId eq '1ddda5b4-cf6c-4d4f-91ad-bc38ab0e811e'"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType 

----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- 

a5db90c3-f147-bce6-83b0-ab5e0aeca1f0 
```

Get Solution Metadata by resource id
