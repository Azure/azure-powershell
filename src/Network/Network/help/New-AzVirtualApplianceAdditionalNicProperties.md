---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualapplianceadditionalnicproperties
schema: 2.0.0
---

# New-AzVirtualApplianceAdditionalNicProperties

## SYNOPSIS
Define a Network Virtual Appliance Additional Nic Property for the resource.

## SYNTAX

```
New-AzVirtualApplianceAdditionalNicProperties -NicName <String> -HasPublicIp <Boolean>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualApplianceAdditionalNicProperties command defines an Additional Nic Property for Network Virtual Appliance resource.

## EXAMPLES

### Example 1
```powershell
$var=New-AzVirtualApplianceAdditionalNicProperties -NicName "sdwan" -HasPublicIp true
```

Create an Additional Nic Property object to be used with New-AzNetworkVirtualAppliance command.

## PARAMETERS

### -NicName
The Name of Interface.

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
### -HasPublicIp
Additional Interface to have public IP or not.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceAdditionalNicProperties

## NOTES

## RELATED LINKS
