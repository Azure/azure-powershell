---
external help file: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.dll-Help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/new-azfrontdoorwafcustomrulegroupbyvariableobject
schema: 2.0.0
---

# New-AzFrontDoorWafCustomRuleGroupByVariableObject

## SYNOPSIS
Create CustomRuleGroupByVariable object for custom rule object

## SYNTAX

```
New-AzFrontDoorWafCustomRuleGroupByVariableObject -VariableName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Create CustomRuleGroupByVariable object for custom rule object

Use cmdlet "New-AzFrontDoorWafCustomRuleGroupByVariableObject" to pass -CustomRule parameter

## EXAMPLES

### Example 1
```powershell
New-AzFrontDoorWafCustomRuleGroupByVariableObject -VariableName SocketAddr
```

## PARAMETERS

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

### -VariableName
Describes the supported variable for group by

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.FrontDoor.Models.PSFrontDoorWafCustomRuleGroupByVariable

## NOTES

## RELATED LINKS
