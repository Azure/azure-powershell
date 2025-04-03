---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/get-azstoragemover
schema: 2.0.0
---

# Get-AzStorageMover

## SYNOPSIS
Gets a Storage Mover resource.

## SYNTAX

### List (Default)
```
Get-AzStorageMover [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorageMover -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorageMover -InputObject <IStorageMoverIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzStorageMover -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a Storage Mover resource.

## EXAMPLES

### Example 1: Get all Storage movers in a subcription
```powershell
 Get-AzStorageMover
```

```output
Description                  : StorageMover description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover1
Location                     : eastus
Name                         : myStorageMover1
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:00 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:00 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "tag2": "value2",
                                 "tag1": "value1"
                               }
Type                         : microsoft.storagemover/storagemovers

Description                  : StorageMover description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup2/providers/Microsoft.StorageMover/storageMovers/myStorageMover2
Location                     : eastus
Name                         : myStorageMover2
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:00 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:00 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "tag2": "value2",
                                 "tag1": "value1"
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command gets all the Storage movers in a subscription.

### Example 2: Get all Storage movers in a resource group
```powershell
Get-AzStorageMover -ResourceGroupName myResourceGroup
```

```output
Description                  : StorageMover description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover1
Location                     : eastus
Name                         : myStorageMover1
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:00 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:00 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "tag2": "value2",
                                 "tag1": "value1"
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command gets all the Storage movers in a resource group.

### Example 2: Get a specific Storage mover
```powershell
Get-AzStorageMover -ResourceGroupName myResourceGroup -Name myStorageMover1
```

```output
Description                  : StorageMover description
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover1
Location                     : eastus
Name                         : myStorageMover1
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 5:35:00 AM
SystemDataCreatedBy          : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 8/2/2022 5:35:00 AM
SystemDataLastModifiedBy     : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
SystemDataLastModifiedByType : Application
Tag                          : {
                                 "tag2": "value2",
                                 "tag1": "value1"
                               }
Type                         : microsoft.storagemover/storagemovers
```

This command gets a specific Storage mover.

## PARAMETERS

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: StorageMoverName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.Api20240701.IStorageMover

## NOTES

## RELATED LINKS

