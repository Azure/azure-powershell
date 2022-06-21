---
external help file:
Module Name: Az.FluidRelay
online version: https://docs.microsoft.com/powershell/module/az.fluidrelay/get-azfluidrelayserverkey
schema: 2.0.0
---

# Get-AzFluidRelayServerKey

## SYNOPSIS
Get primary and secondary key for this server.

## SYNTAX

```
Get-AzFluidRelayServerKey -FluidRelayServerName <String> -ResourceGroup <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get primary and secondary key for this server.

## EXAMPLES

### Example 1: Get primary and secondary key for this server.
```powershell
Get-AzFluidRelayServerKey -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp
```

```output
                        Key1                         Key2
                        ----                         ----
System.Security.SecureString System.Security.SecureString
```

Get primary and secondary key for this server.

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

### -FluidRelayServerName
The Fluid Relay server resource name.

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

### -ResourceGroup
The resource group containing the resource.

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
The subscription id (GUID) for this resource.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.Api20220601.IFluidRelayServerKeys

## NOTES

ALIASES

## RELATED LINKS

