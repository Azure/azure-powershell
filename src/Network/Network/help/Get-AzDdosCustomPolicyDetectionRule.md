---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azddoscustompolicydetectionrule
schema: 2.0.0
---

# Get-AzDdosCustomPolicyDetectionRule

## SYNOPSIS
Gets one or all detection rules from an in-memory DDoS custom policy.

## SYNTAX

```
Get-AzDdosCustomPolicyDetectionRule -DdosCustomPolicy <PSDdosCustomPolicy> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDdosCustomPolicyDetectionRule** cmdlet gets detection rules from a DDoS custom policy object. Specify **Name** to retrieve one rule by its case-insensitive name, or omit **Name** to return all detection rules.

This cmdlet reads the local policy object and does not send a request to Azure. Use **Get-AzDdosCustomPolicy** first when you need the latest persisted policy.

## EXAMPLES

### Example 1: Get all detection rules
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Get-AzDdosCustomPolicyDetectionRule
```

This example retrieves all detection rules from the policy.

### Example 2: Get one detection rule
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$rule = $policy | Get-AzDdosCustomPolicyDetectionRule -Name "tcpRule1"
```

This example retrieves the detection rule named `tcpRule1`. Name matching is case-insensitive.

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
Specifies the DDoS custom policy object whose detection rules are returned. The object can be retrieved with **Get-AzDdosCustomPolicy**.

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

### -Name
Specifies the name of the detection rule to retrieve. If omitted, the cmdlet returns every detection rule in the policy.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyDetectionRule

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](Get-AzDdosCustomPolicy.md)

[Add-AzDdosCustomPolicyDetectionRule](Add-AzDdosCustomPolicyDetectionRule.md)

[Remove-AzDdosCustomPolicyDetectionRule](Remove-AzDdosCustomPolicyDetectionRule.md)
