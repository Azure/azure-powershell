---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azpublicipaddresscloudservicereservation
schema: 2.0.0
---

# Invoke-AzPublicIpAddressCloudServiceReservation

## SYNOPSIS
Reserves or rolls back allocation for a cloud service public IP address.

## SYNTAX

### ByName (Default)
```
Invoke-AzPublicIpAddressCloudServiceReservation -Name <String> -ResourceGroupName <String> [-IsRollback]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByInputObject
```
Invoke-AzPublicIpAddressCloudServiceReservation -InputObject <PSPublicIpAddress> [-IsRollback] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceId
```
Invoke-AzPublicIpAddressCloudServiceReservation -ResourceId <String> [-IsRollback] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Invoke-AzPublicIpAddressCloudServiceReservation** cmdlet invokes the **ReserveCloudServicePublicIpAddress** operation on the target public IP. By default it reserves the cloud service public IP (static allocation). When **IsRollback** is specified, the operation reverts from static to dynamic allocation (undo reservation).

This cmdlet supports **WhatIf** and **Confirm** (see [about_CommonParameters](https://learn.microsoft.com/powershell/module/microsoft.powershell.core/about/about_commonparameters)).

## EXAMPLES

### Example 1: Reserve using resource group and name
```powershell
Invoke-AzPublicIpAddressCloudServiceReservation -ResourceGroupName 'myResourceGroup' -Name 'myCloudServicePublicIp'
```

Reserves the cloud service public IP named **myCloudServicePublicIp** in **myResourceGroup**.

### Example 2: Roll back reservation (dynamic allocation)
```powershell
Invoke-AzPublicIpAddressCloudServiceReservation -ResourceGroupName 'myResourceGroup' -Name 'myCloudServicePublicIp' -IsRollback
```

Reverts the public IP from static to dynamic allocation for the same resource.

### Example 3: Pipe a public IP object
```powershell
$pip = Get-AzPublicIpAddress -ResourceGroupName 'myResourceGroup' -Name 'myCloudServicePublicIp'
Invoke-AzPublicIpAddressCloudServiceReservation -InputObject $pip
```

Runs the reservation operation using a **PSPublicIpAddress** from **Get-AzPublicIpAddress**.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The public IP address object.

```yaml
Type: PSPublicIpAddress
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsRollback
When true, reverts from static to dynamic allocation (undo reservation).

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The public IP address name.

```yaml
Type: String
Parameter Sets: ByName
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The public IP address resource ID.

```yaml
Type: String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.String

### Microsoft.Azure.Commands.Network.Models.PSPublicIpAddress

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPublicIpAddress

## NOTES

## RELATED LINKS

[Get-AzPublicIpAddress](./Get-AzPublicIpAddress.md)

[Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp](./Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp.md)

[Set-AzPublicIpAddress](./Set-AzPublicIpAddress.md)
