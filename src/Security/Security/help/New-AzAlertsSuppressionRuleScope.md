---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/new-azalertssuppressionrulescope
schema: 2.0.0
---

# New-AzAlertsSuppressionRuleScope

## SYNOPSIS
Helper cmdlet to create PSIScopeElement.

## SYNTAX

```
New-AzAlertsSuppressionRuleScope -Field <String> [-ContainsSubstring <String>] [-AnyOf <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Helper cmdlet to create PSIScopeElement.
Usable in Set-AzAlertsSuppressionRule as part of the -AllOf parameter.

## EXAMPLES

### Example 1
```powershell
$scope1 = New-AzAlertsSuppressionRuleScope -Field "entities.account.name" -ContainsSubstring "Example"
```

Creates a PSScopeElementContains.

### Example 2
```powershell
$scope2 = New-AzAlertsSuppressionRuleScope -Field "entities.file.name" -AnyOf "FileName1","FileName2","FileName3"
```

Creates a PSScopeElementIn.

## PARAMETERS

### -AnyOf
Suppress only when field equals one of those values.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainsSubstring
Suppress only when field contains this specific value.

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

### -Field
Entity field to scope by.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSIScopeElement

## NOTES

## RELATED LINKS
