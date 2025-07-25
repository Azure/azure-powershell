### Example 1: Get a list of machine extension metadata
```powershell
Get-AzConnectedExtensionMetadata -ExtensionType 'CustomScriptExtension' -Location 'eastus2euap' -Publisher 'Microsoft.HybridCompute'
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifi
                                                                                              edBy
---- ------------------- ------------------- ----------------------- ------------------------ --------------------
```

Get a list of machine extension metadata

### Example 2: Get a specific machine extension metadata
```powershell
Get-AzConnectedExtensionMetadata -ExtensionType 'CustomScriptExtension' -Location 'eastus2euap' -Publisher 'Microsoft.HybridCompute' -Version '1.10.10'
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifi
                                                                                              edBy
---- ------------------- ------------------- ----------------------- ------------------------ --------------------

```

Get a specific machine extension metadata
