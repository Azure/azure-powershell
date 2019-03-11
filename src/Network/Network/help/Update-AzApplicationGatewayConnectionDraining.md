---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/update-azapplicationgatewayconnectiondraining
schema: 2.0.0
---

# Update-AzApplicationGatewayConnectionDraining

## SYNOPSIS
Incrementally updates connection draining of an application gateway.

## SYNTAX

```
Update-AzApplicationGatewayConnectionDraining -BackendHttpSettings <PSApplicationGatewayBackendHttpSettings>
 [-Enabled <Boolean>] [-DrainTimeoutInSec <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzApplicationGatewayConnectionDraining** incrementally updates connection draining of an application gateway. I.e. only the specified parameters values are changed and values of the unspecified properties are kept unlike of Set-AzApplicationGatewayConnectionDraining cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:> Update-AzApplicationGatewayConnectionDraining -BackendHttpSettings $poolSetting02 -DrainTimeoutInSec 3650
```

This updates drain timeout in seconds of connection draining keeping other properties unchanged.

## PARAMETERS

### -BackendHttpSettings
The backend http settings

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendHttpSettings
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DrainTimeoutInSec
The number of seconds connection draining is active.
Acceptable values are from 1 second to 3600 seconds.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
Whether connection draining is enabled or not.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendHttpSettings

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSApplicationGatewayBackendHttpSettings

## NOTES

## RELATED LINKS
