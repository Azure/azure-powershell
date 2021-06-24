---
external help file:
Module Name: Az.DiskPool
online version: https://docs.microsoft.com/powershell/module/az.diskpool/get-azdiskpoolzone
schema: 2.0.0
---

# Get-AzDiskPoolZone

## SYNOPSIS
Lists available Disk Pool Skus in an Azure location.

## SYNTAX

```
Get-AzDiskPoolZone -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists available Disk Pool Skus in an Azure location.

## EXAMPLES

### Example 1: List availability zones for a location
```powershell
PS C:\> Get-AzDiskPoolZone -Location eastus

SkuName  SkuTier  AvailabilityZone AdditionalCapability
-------  -------  ---------------- --------------------
Basic    Basic    {3, 1, 2}
Standard Standard {3, 1, 2}
Premium  Premium  {3, 1, 2}
```

The command lists all availability zones for a location.

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

### -Location
The location of the resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolZoneInfo

## NOTES

ALIASES

## RELATED LINKS

