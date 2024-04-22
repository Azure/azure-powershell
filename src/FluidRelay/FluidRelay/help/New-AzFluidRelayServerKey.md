---
external help file: Az.FluidRelay-help.xml
Module Name: Az.FluidRelay
online version: https://learn.microsoft.com/powershell/module/az.fluidrelay/new-azfluidrelayserverkey
schema: 2.0.0
---

# New-AzFluidRelayServerKey

## SYNOPSIS
Regenerate the primary or secondary key for this server.

## SYNTAX

### RegenerateExpanded (Default)
```
New-AzFluidRelayServerKey -FluidRelayServerName <String> -ResourceGroup <String> [-SubscriptionId <String>]
 -KeyName <KeyName> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RegenerateViaIdentityExpanded
```
New-AzFluidRelayServerKey -InputObject <IFluidRelayIdentity> -KeyName <KeyName> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Regenerate the primary or secondary key for this server.

## EXAMPLES

### Example 1: Regenerate the primary or secondary key for this server.
```powershell
New-AzFluidRelayServerKey -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp -KeyName 'key2'
```

```output
Key1                         Key2
                        ----                         ----
System.Security.SecureString System.Security.SecureString
```

Regenerate the primary or secondary key for this server.

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

### -FluidRelayServerName
The Fluid Relay server resource name.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayIdentity
Parameter Sets: RegenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyName
The key to regenerate.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Support.KeyName
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
The resource group containing the resource.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded
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
Type: System.String
Parameter Sets: RegenerateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.Api20220601.IFluidRelayServerKeys

## NOTES

## RELATED LINKS
