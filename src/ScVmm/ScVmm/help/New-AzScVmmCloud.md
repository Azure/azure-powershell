---
external help file: Az.ScVmm-help.xml
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/new-azscvmmcloud
schema: 2.0.0
---

# New-AzScVmmCloud

## SYNOPSIS
Onboards the ScVmm fabric cloud as an Azure cloud resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzScVmmCloud -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-VmmServerName <String>] [-InventoryUuid <String>] [-InventoryItemId <String>] [-VmmServerId <String>]
 [-CustomLocationId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzScVmmCloud -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzScVmmCloud -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Onboards the ScVmm fabric cloud as an Azure cloud resource.

`InventoryUuid` can be obtained using `Get-AzScVmmInventoryItem -VmmServerName \<\> -ResourceGroupName \<\>` (check Name(UUID format) for required InventoryItemName and InventoryType).
`InventoryItemId` can be obtained using `Get-AzScVmmInventoryItem -VmmServerName \<\> -ResourceGroupName \<\> -Name \<uuid\>` (check for Id property in the response).

To enable resource in the same Resource Group as VMM Sever resource resides execute the command with `-VmmServerName`.

To enable resource in a different Resource Group than the one where VMM Server resource resides execute the command with `-VmmServerId` and `-CustomLocationId` in place of `-VmmServerName`.
`VmmServerId` can be retrieved using `Get-AzScVmmServer` (check for `Id` property in the response).
`CustomLocationId` can be retrieved using `Get-AzScVmmServer` (check for `ExtendedLocationName` property in the response).

## EXAMPLES

### Example 1: Create SCVMM Cloud resource
```powershell
New-AzScVmmCloud -Name "test-cloud" -ResourceGroupName "test-rg-01" -SubscriptionId "00000000-abcd-0000-abcd-000000000000" -Location "eastus" -VmmServerName "test-vmmserver-01" -InventoryUuid "00000000-1111-0000-0002-000000000000"
```

```output
CapacityCpuCount             : 10
CapacityMemoryMb             : 10240
CapacityVMCount              : 10
CloudName                    : test-cloud
ExtendedLocationName         : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ExtendedLocation/customLocations/test-cl
ExtendedLocationType         : customLocation
Id                           : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/clouds/test-cloud
InventoryItemId              : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01/InventoryItems/00000000-1111-0000-0002-000000000000
Location                     : eastus
Name                         : test-cloud
ProvisioningState            : Succeeded
ResourceGroupName            : test-rg-01
StorageQoSPolicy             : {}
SystemDataCreatedAt          : 08-01-2024 15:05:41
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 08-01-2024 18:14:34
SystemDataLastModifiedBy     : 11111111-aaaa-2222-bbbb-333333333333
SystemDataLastModifiedByType : Application
Tag                          : {
                               }
Type                         : microsoft.scvmm/clouds
Uuid                         : 00000000-1111-0000-0002-000000000000
VmmServerId                  : /subscriptions/00000000-abcd-0000-abcd-000000000000/resourceGroups/test-rg-01/providers/Microsoft.ScVmm/vmmServers/test-vmmserver-01
```

This command creates a Cloud named `test-cloud` in the resource group named `test-rg-01`.

`InventoryUuid` can be obtained using `Get-AzScVmmInventoryItem -VmmServerName \<\> -ResourceGroupName \<\>` (check Name(UUID format) for required InventoryItemName and InventoryType).
`InventoryItemId` can be obtained using `Get-AzScVmmInventoryItem -VmmServerName \<\> -ResourceGroupName \<\> -Name \<uuid\>` (check for Id property in the response).

To enable resource in the same Resource Group as VMM Sever resource resides execute the command with `-VmmServerName`.

To enable resource in a different Resource Group than the one where VMM Server resource resides execute the command with `-VmmServerId` and `-CustomLocationId` in place of `-VmmServerName`.
`VmmServerId` can be retrieved using `Get-AzScVmmServer` (check for `Id` property in the response).
`CustomLocationId` can be retrieved using `Get-AzScVmmServer` (check for `ExtendedLocationName` property in the response).

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomLocationId
The ARM Id of the custom location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### -InventoryItemId
ARM Id of the inventory Item for the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InventoryUuid
Unique ID of the cloud.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Cloud.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CloudResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmmServerId
ARM Id of the vmmServer resource in which this resource resides.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VmmServerName
Name of the vmmServer resource in which this resource resides.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.ICloud

## NOTES

## RELATED LINKS
