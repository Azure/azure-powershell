---
external help file: Az.NetworkSecurity-help.xml
Module Name: Az.NetworkSecurity
online version: https://learn.microsoft.com/powershell/module/az.networksecurity/invoke-aznetworksecurityneuroshieldfindingmitigation
schema: 2.0.0
---

# Invoke-AzNetworkSecurityNeuroShieldFindingMitigation

## SYNOPSIS
Triggers mitigation for all awaiting-approval mitigations under a finding.

## SYNTAX

### Mitigate (Default)
```
Invoke-AzNetworkSecurityNeuroShieldFindingMitigation -FindingId <String> -NeuroShieldName <String>
 -ProtectedResourceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MitigateViaIdentityProtectedResource
```
Invoke-AzNetworkSecurityNeuroShieldFindingMitigation -FindingId <String>
 -ProtectedResourceInputObject <INetworkSecurityIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MitigateViaIdentityNeuroShield
```
Invoke-AzNetworkSecurityNeuroShieldFindingMitigation -FindingId <String> -ProtectedResourceName <String>
 -NeuroShieldInputObject <INetworkSecurityIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MitigateViaIdentity
```
Invoke-AzNetworkSecurityNeuroShieldFindingMitigation -InputObject <INetworkSecurityIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Triggers mitigation for all awaiting-approval mitigations under a finding.

## EXAMPLES

### Example 1: Mitigate a finding
```powershell
Invoke-AzNetworkSecurityNeuroShieldFindingMitigation -ResourceGroupName 'myResourceGroup' -NeuroShieldName 'myNeuroShield' -ProtectedResourceName 'myProtectedResource' -FindingId '<finding-id>'
```

Requests mitigation of the specified finding.

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

### -FindingId
The system-generated identifier of the finding.

```yaml
Type: System.String
Parameter Sets: Mitigate, MitigateViaIdentityProtectedResource, MitigateViaIdentityNeuroShield
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: MitigateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NeuroShieldInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INetworkSecurityIdentity
Parameter Sets: MitigateViaIdentityNeuroShield
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
Parameter Sets: Mitigate
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
Parameter Sets: MitigateViaIdentityProtectedResource
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
Parameter Sets: Mitigate, MitigateViaIdentityNeuroShield
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
Parameter Sets: Mitigate
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
Parameter Sets: Mitigate
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurity.Models.INeuroShieldMitigationActionResult

## NOTES

## RELATED LINKS
