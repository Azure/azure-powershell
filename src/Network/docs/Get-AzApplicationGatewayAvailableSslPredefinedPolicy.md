---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailablesslpredefinedpolicy
schema: 2.0.0
---

# Get-AzApplicationGatewayAvailableSslPredefinedPolicy

## SYNOPSIS
Lists all SSL predefined policies for configuring Ssl policy.

## SYNTAX

### ListSubscriptionIdViaHost (Default)
```
Get-AzApplicationGatewayAvailableSslPredefinedPolicy [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzApplicationGatewayAvailableSslPredefinedPolicy -SubscriptionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists all SSL predefined policies for configuring Ssl policy.

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

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewaySslPredefinedPolicy
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailablesslpredefinedpolicy](https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailablesslpredefinedpolicy)

