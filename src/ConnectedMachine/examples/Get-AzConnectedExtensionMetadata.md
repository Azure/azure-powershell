### Example 1: {{ Get metadata of all machines }}
```powershell
Get-AzConnectedExtensionMetadata -ExtensionType 'CustomScriptExtension' -Location 'eastus2euap' -Publisher 'Microsoft.Compute'
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ---
```
Get metadata of all machines.

### Example 2: {{ Get metadata of a specific machine }}
```powershell
Get-AzConnectedExtensionMetadata -ExtensionType 'CustomScriptExtension' -Location 'eastus2euap' -Publisher 'Microsoft.Compute' -Version 1.10.10
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Type
---- ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ---
```
Get metadata of a specific machine.
