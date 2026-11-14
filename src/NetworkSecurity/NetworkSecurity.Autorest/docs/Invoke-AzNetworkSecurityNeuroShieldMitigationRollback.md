---
external help file:
Module Name: Az.NetworkSecurity
online version: https://learn.microsoft.com/powershell/module/az.networksecurity/invoke-aznetworksecurityneuroshieldmitigationrollback
schema: 2.0.0
---

# Invoke-AzNetworkSecurityNeuroShieldMitigationRollback

## SYNOPSIS
Rolls back a mitigation when rollback is available.

## SYNTAX

### Rollback (Default)
```
Invoke-AzNetworkSecurityNeuroShieldMitigationRollback -MitigationId <String> -NeuroShieldName <String>
 -ProtectedResourceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RollbackViaIdentity
```
Invoke-AzNetworkSecurityNeuroShieldMitigationRollback -InputObject <INetworkSecurityIdentity>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RollbackViaIdentityNeuroShield
```
Invoke-AzNetworkSecurityNeuroShieldMitigationRollback -MitigationId <String>
 -NeuroShieldInputObject <INetworkSecurityIdentity> -ProtectedResourceName <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RollbackViaIdentityProtectedResource
```
Invoke-AzNetworkSecurityNeuroShieldMitigationRollback -MitigationId <String>
 -ProtectedResourceInputObject <INetworkSecurityIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Rolls back a mitigation when rollback is available.

## EXAMPLES

### Example 1: Roll back a mitigation
```powershell
Invoke-AzNetworkSecurityNeuroShieldMitigationRollback -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -MitigationId '<mitigation-id>'
```

Rolls back the specified mitigation.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: RollbackViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MitigationId
The system-generated identifier of the mitigation.

```yaml
Type: System.String
Parameter Sets: Rollback, RollbackViaIdentityNeuroShield, RollbackViaIdentityProtectedResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NeuroShieldInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: RollbackViaIdentityNeuroShield
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NeuroShieldName
The name of the NeuroShield resource.

```yaml
Type: System.String
Parameter Sets: Rollback
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectedResourceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: RollbackViaIdentityProtectedResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProtectedResourceName
The name of the protected resource.

```yaml
Type: System.String
Parameter Sets: Rollback, RollbackViaIdentityNeuroShield
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
Parameter Sets: Rollback
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Rollback
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldMitigation

## NOTES

## RELATED LINKS
