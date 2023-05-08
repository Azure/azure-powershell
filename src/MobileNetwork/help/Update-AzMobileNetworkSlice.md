---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/update-azmobilenetworkslice
schema: 2.0.0
---

# Update-AzMobileNetworkSlice

## SYNOPSIS
Updates slice.

## SYNTAX

```
Update-AzMobileNetworkSlice -MobileNetworkName <String> -ResourceGroupName <String> -SliceName <String>
 -SnssaiSst <Int32> [-SubscriptionId <String>] [-Description <String>] [-SnssaiSd <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates slice.

## EXAMPLES

### Example 1: Updates slice.
```powershell
Update-AzMobileNetworkSlice -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -SliceName azps-mn-slice -Tag @{"abc"="123"} -SnssaiSst 1
```

```output
Location Name          ResourceGroupName ProvisioningState SnssaiSst SnssaiSd
-------- ----          ----------------- ----------------- --------- --------
eastus   azps-mn-slice azps_test_group   Succeeded         1         1abcde
```

Updates slice.

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

### -Description
An optional description for this network slice.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MobileNetworkName
The name of the mobile network.

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

### -SliceName
The name of the network slice.

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

### -SnssaiSd
Slice differentiator (SD).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SnssaiSst
Slice/service type (SST).

```yaml
Type: System.Int32
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISlice

## NOTES

ALIASES

## RELATED LINKS

