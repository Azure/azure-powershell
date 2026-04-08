---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/invoke-azpublicipaddressdisassociatecloudservicereservedip
schema: 2.0.0
---

# Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp

## SYNOPSIS
Disassociates a standalone reserved public IP from a cloud service public IP address.

## SYNTAX

### ByName (Default)
```
Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp -Name <String> -ResourceGroupName <String>
 -PublicIpArmId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp -InputObject <PSPublicIpAddress>
 -PublicIpArmId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp -ResourceId <String> -PublicIpArmId <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp** cmdlet invokes the **DisassociateCloudServiceReservedPublicIp** operation. Use **PublicIpArmId** to specify the ARM resource ID of the standalone public IP to disassociate from the cloud service public IP identified by **Name** and **ResourceGroupName**, **ResourceId**, or **InputObject**.

This cmdlet supports **WhatIf** and **Confirm** (see [about_CommonParameters](https://learn.microsoft.com/powershell/module/microsoft.powershell.core/about/about_commonparameters)).

## EXAMPLES

### Example 1: Disassociate using names and standalone IP resource ID
```powershell
$standaloneId = '/subscriptions/{subId}/resourceGroups/myRg/providers/Microsoft.Network/publicIPAddresses/standalonePip'
Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp `
    -ResourceGroupName 'myResourceGroup' `
    -Name 'myCloudServicePublicIp' `
    -PublicIpArmId $standaloneId
```

Disassociates the standalone public IP **standalonePip** from the cloud service public IP **myCloudServicePublicIp**.

### Example 2: Pipe the cloud service public IP
```powershell
$cloudPip = Get-AzPublicIpAddress -ResourceGroupName 'myResourceGroup' -Name 'myCloudServicePublicIp'
Invoke-AzPublicIpAddressDisassociateCloudServiceReservedIp -InputObject $cloudPip -PublicIpArmId $standaloneId
```

Uses a **PSPublicIpAddress** from the pipeline context; **PublicIpArmId** is still required.

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
The cloud service public IP address object.

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

### -Name
The cloud service public IP address name.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIpArmId
ARM resource ID of the standalone public IP address to disassociate.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
The cloud service public IP address resource ID.

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

[Invoke-AzPublicIpAddressCloudServiceReservation](./Invoke-AzPublicIpAddressCloudServiceReservation.md)

[Set-AzPublicIpAddress](./Set-AzPublicIpAddress.md)
