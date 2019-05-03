---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azsupportedsecurityprovider
schema: 2.0.0
---

# Invoke-AzSupportedSecurityProvider

## SYNOPSIS
Gives the supported security providers for the virtual wan.

## SYNTAX

### SupportedSubscriptionIdViaHost (Default)
```
Invoke-AzSupportedSecurityProvider -ResourceGroupName <String> -VirtualWanName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Supported
```
Invoke-AzSupportedSecurityProvider -ResourceGroupName <String> -SubscriptionId <String>
 -VirtualWanName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gives the supported security providers for the virtual wan.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -ResourceGroupName
The resource group name.

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
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Supported
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualWanName
The name of the VirtualWAN for which supported security providers are needed.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualWanSecurityProvider
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azsupportedsecurityprovider](https://docs.microsoft.com/en-us/powershell/module/az.network/invoke-azsupportedsecurityprovider)

