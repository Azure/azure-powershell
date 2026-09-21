---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azddoscustompolicy
schema: 2.0.0
---

# Set-AzDdosCustomPolicy

## SYNOPSIS
Updates and persists a DDoS custom policy to Azure.

## SYNTAX

```
Set-AzDdosCustomPolicy -DdosCustomPolicy <PSDdosCustomPolicy> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzDdosCustomPolicy** cmdlet persists changes made to a DDoS custom policy object back to Azure. After modifying a policy object (such as removing or adding detection rules), use this cmdlet to save the changes to Azure.

This cmdlet is typically used in a pipeline after modifying a policy object retrieved with **Get-AzDdosCustomPolicy** or created with **New-AzDdosCustomPolicy**.

## EXAMPLES

### Example 1: Update a DDoS custom policy by removing a detection rule
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy = $policy | Remove-AzDdosCustomPolicyDetectionRule -Name "udpRule1"
$policy | Set-AzDdosCustomPolicy
```

This example retrieves a DDoS custom policy, removes a detection rule by name, and persists the changes to Azure.

### Example 2: Add a detection rule and persist the updated policy
```powershell
Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" |
  Add-AzDdosCustomPolicyDetectionRule -Name "tcpSynRule1" -TrafficType TcpSyn -PacketsPerSecond 50000 |
  Set-AzDdosCustomPolicy
```

This example demonstrates the full pipeline for retrieving a policy, adding a detection rule to the in-memory object, and persisting the updated policy.

### Example 3: Update a DDoS custom policy using WhatIf
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Remove-AzDdosCustomPolicyDetectionRule -Name "tcpRule1" | Set-AzDdosCustomPolicy -WhatIf
```

This example shows how to preview the changes without actually updating the policy in Azure.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DdosCustomPolicy
Specifies the DDoS custom policy object to update. The object can be created with **New-AzDdosCustomPolicy** or retrieved with **Get-AzDdosCustomPolicy**.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](Get-AzDdosCustomPolicy.md)

[New-AzDdosCustomPolicy](New-AzDdosCustomPolicy.md)

[Add-AzDdosCustomPolicyDetectionRule](Add-AzDdosCustomPolicyDetectionRule.md)

[Remove-AzDdosCustomPolicy](Remove-AzDdosCustomPolicy.md)

[Remove-AzDdosCustomPolicyDetectionRule](Remove-AzDdosCustomPolicyDetectionRule.md)
