---
external help file: Az.MobileNetwork-help.xml
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/get-azmobilenetworkslice
schema: 2.0.0
---

# Get-AzMobileNetworkSlice

## SYNOPSIS
Gets information about the specified network slice.

## SYNTAX

### List (Default)
```
Get-AzMobileNetworkSlice -MobileNetworkName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMobileNetworkSlice -MobileNetworkName <String> -ResourceGroupName <String> -SliceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMobileNetworkSlice -InputObject <IMobileNetworkIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified network slice.

## EXAMPLES

### Example 1: List information about the specified network slice by MobileNetwork Name.
```powershell
Get-AzMobileNetworkSlice -MobileNetworkName azps-mn -ResourceGroupName azps_test_group
```

```output
Location Name          ResourceGroupName ProvisioningState SnssaiSst SnssaiSd
-------- ----          ----------------- ----------------- --------- --------
eastus   azps-mn-slice azps_test_group   Succeeded         1         1abcde
```

List information about the specified network slice by MobileNetwork Name.

### Example 2: Get information about the specified network slice.
```powershell
Get-AzMobileNetworkSlice -MobileNetworkName azps-mn -ResourceGroupName azps_test_group -SliceName azps-mn-slice
```

```output
Location Name          ResourceGroupName ProvisioningState SnssaiSst SnssaiSd
-------- ----          ----------------- ----------------- --------- --------
eastus   azps-mn-slice azps_test_group   Succeeded         1         1abcde
```

Get information about the specified network slice.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MobileNetworkName
The name of the mobile network.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.IMobileNetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISlice

## NOTES

## RELATED LINKS
