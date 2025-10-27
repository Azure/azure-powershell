### Example 1: Get a NetworkSecurityPerimeterConfiguration associated with a storage account
```powershell
Get-AzStorageNetworkSecurityPerimeterConfiguration -ResourceGroupName "nsprg" -AccountName "nspaccount" -Name "00000000-0000-0000-0000-000000000000.associationame"
```

```output
Id                               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/nsprg/providers/Microsoft.Storage/storageAccounts/nspaccount/networkSecurityPerimeterConfigurations/00000000-0000-0000-0000-000000000000.associationame
Name                             : 00000000-0000-0000-0000-000000000000.associationame
NetworkSecurityPerimeterGuid     : 00000000-0000-0000-0000-000000000000
NetworkSecurityPerimeterId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/nsprg/providers/Microsoft.Network/networkSecurityPerimeters/nspname
NetworkSecurityPerimeterLocation : eastus
ProfileAccessRule                : {}
ProfileAccessRulesVersion        : 0
ProfileDiagnosticSettingsVersion : 0
ProfileEnabledLogCategory        : {}
ProfileName                      : nsptest
ProvisioningIssue                :
ProvisioningState                : Succeeded
ResourceAssociationAccessMode    : Learning
ResourceAssociationName          : associationame
ResourceGroupName                : nsprg
SystemDataCreatedAt              :
SystemDataCreatedBy              :
SystemDataCreatedByType          :
SystemDataLastModifiedAt         :
SystemDataLastModifiedBy         :
SystemDataLastModifiedByType     :
Type                             : Microsoft.Storage/storageAccounts/networkSecurityPerimeterConfigurations
```

This command gets a NetworkSecurityPerimeterConfiguration associated with a storage account "nspaccount" with the nspConfig Name.

### Example 2: List NetworkSecurityPerimeterConfiguration associated with a storage account
```powershell
Get-AzStorageNetworkSecurityPerimeterConfiguration -ResourceGroupName "nsprg" -AccountName "nspaccount"
```

```output
Id                               : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/nsprg/providers/Microsoft.Storage/storageAccounts/nspaccount/networkSecurityPerimeterConfigurations/00000000-0000-0000-0000-000000000000.associationame
Name                             : 00000000-0000-0000-0000-000000000000.associationame
NetworkSecurityPerimeterGuid     : 00000000-0000-0000-0000-000000000000
NetworkSecurityPerimeterId       : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/nsprg/providers/Microsoft.Network/networkSecurityPerimeters/nspname
NetworkSecurityPerimeterLocation : eastus
ProfileAccessRule                : {}
ProfileAccessRulesVersion        : 0
ProfileDiagnosticSettingsVersion : 0
ProfileEnabledLogCategory        : {}
ProfileName                      : nsptest
ProvisioningIssue                :
ProvisioningState                : Succeeded
ResourceAssociationAccessMode    : Learning
ResourceAssociationName          : associationame
ResourceGroupName                : nsprg
SystemDataCreatedAt              :
SystemDataCreatedBy              :
SystemDataCreatedByType          :
SystemDataLastModifiedAt         :
SystemDataLastModifiedBy         :
SystemDataLastModifiedByType     :
Type                             : Microsoft.Storage/storageAccounts/networkSecurityPerimeterConfigurations
```

This command lists all NetworkSecurityPerimeterConfiguration associated with a storage account "nspaccount".

