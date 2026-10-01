---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azddoscustompolicymitigationrule
schema: 2.0.0
---

# Get-AzDdosCustomPolicyMitigationRule

## SYNOPSIS
Gets mitigation rules from an in-memory DDoS custom policy.

## SYNTAX

```
Get-AzDdosCustomPolicyMitigationRule [-DdosCustomPolicy] <PSDdosCustomPolicy> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns all mitigation rules from a DDoS custom policy object or selects one rule by its case-insensitive name. This cmdlet does not send an update to Azure.

## EXAMPLES

### Example 1: Get one mitigation rule
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$rule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name "tcpRule"
```

## PARAMETERS

### -DdosCustomPolicy
Specifies the DDoS custom policy whose in-memory mitigation rule collection is read.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy
Parameter Sets: (All)
Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the mitigation rule name. Omit this parameter to return every mitigation rule.

```yaml
Type: System.String
Parameter Sets: (All)
Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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
Required: False
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
This cmdlet supports the common parameters. For more information, see [about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyMitigationRule

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](./Get-AzDdosCustomPolicy.md)

[Set-AzDdosCustomPolicyMitigationRule](./Set-AzDdosCustomPolicyMitigationRule.md)
