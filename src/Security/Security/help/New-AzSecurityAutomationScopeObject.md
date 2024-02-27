---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/new-azsecurityautomationscopeobject
schema: 2.0.0
---

# New-AzSecurityAutomationScopeObject

## SYNOPSIS
Creates security automation scope object

## SYNTAX

```
New-AzSecurityAutomationScopeObject -Description <String> -ScopePath <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Creates security automation scope object

## EXAMPLES

### Example 1
```powershell
New-AzSecurityAutomationScopeObject -Description 'Security assessments that relate to the resource group myResourceGroup within the subscription a5caac9c-5c04-49af-b3d0-e204f40345d5'  -ScopePath '/subscriptions/a5caac9c-5c04-49af-b3d0-e204f40345d5/resourceGroups/myResourceGroup'
```

Creates security automation scope object

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

### -Description
The resources scope description

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

### -ScopePath
The resources scope path.
Can be the subscription on which the automation is defined on or a resource group under that subscription (fully qualified Azure resource IDs)

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

### Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomationScope

## NOTES

## RELATED LINKS
