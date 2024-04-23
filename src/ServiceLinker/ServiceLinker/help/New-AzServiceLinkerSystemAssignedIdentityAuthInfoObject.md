---
external help file: Az.ServiceLinker-help.xml
Module Name: Az.ServiceLinker
online version: https://learn.microsoft.com/powershell/module/az.ServiceLinker/new-azservicelinkersystemassignedidentityauthinfoobject
schema: 2.0.0
---

# New-AzServiceLinkerSystemAssignedIdentityAuthInfoObject

## SYNOPSIS
Create an in-memory object for SystemAssignedIdentityAuthInfo.

## SYNTAX

```
New-AzServiceLinkerSystemAssignedIdentityAuthInfoObject [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SystemAssignedIdentityAuthInfo.

## EXAMPLES

### Example 1: Create linker's auth info with system assigned identity
```powershell
New-AzServiceLinkerSystemAssignedIdentityAuthInfoObject
```

```output
AuthType
--------
systemAssignedIdentity
```

Create linker's auth info with system assigned identity

## PARAMETERS

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.SystemAssignedIdentityAuthInfo

## NOTES

## RELATED LINKS
