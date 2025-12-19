---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstoragenetworksecurityperimeterconfiguration
schema: 2.0.0
---

# Get-AzStorageNetworkSecurityPerimeterConfiguration

## SYNOPSIS
Gets effective NetworkSecurityPerimeterConfiguration for association

## SYNTAX

### List (Default)
```
Get-AzStorageNetworkSecurityPerimeterConfiguration -AccountName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageNetworkSecurityPerimeterConfiguration -AccountName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageNetworkSecurityPerimeterConfiguration -InputObject <IStorageIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityStorageAccount
```
Get-AzStorageNetworkSecurityPerimeterConfiguration -Name <String>
 -StorageAccountInputObject <IStorageIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets effective NetworkSecurityPerimeterConfiguration for association

## EXAMPLES

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

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name for Network Security Perimeter configuration

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityStorageAccount
Aliases: NetworkSecurityPerimeterConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: GetViaIdentityStorageAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.INetworkSecurityPerimeterConfiguration

## NOTES

## RELATED LINKS

