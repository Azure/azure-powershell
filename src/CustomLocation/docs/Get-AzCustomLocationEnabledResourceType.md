---
external help file:
Module Name: Az.CustomLocation
online version: https://docs.microsoft.com/powershell/module/az.customlocation/get-azcustomlocationenabledresourcetype
schema: 2.0.0
---

# Get-AzCustomLocationEnabledResourceType

## SYNOPSIS
Gets the list of the Enabled Resource Types.

## SYNTAX

```
Get-AzCustomLocationEnabledResourceType -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of the Enabled Resource Types.

## EXAMPLES

### Example 1: Gets the list of the Enabled Resource Types.
```powershell
Get-AzCustomLocationEnabledResourceType -ResourceGroupName azps_test_group -Name azps_test_cluster
```

```output
Name                                                             Type
----                                                             ----
017e563408cfcbaad0604875fef1f0e5a36d5fefa5e81a4c1c212c5a77fbcbde Microsoft.ExtendedLocation/customLocations/enabledResourceTypes
```

Gets the list of the Enabled Resource Types.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Name
Custom Locations name.

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

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.Api20210815.IEnabledResourceType

## NOTES

ALIASES

## RELATED LINKS

