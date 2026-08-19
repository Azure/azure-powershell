---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/Az.CloudHealth/new-azmonitorhealthmodelmanagedidentityauthenticationsettingpropertiesobject
schema: 2.0.0
---

# New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject

## SYNOPSIS
Create an in-memory object for ManagedIdentityAuthenticationSettingProperties.

## SYNTAX

```
New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName <String>
 [-DisplayName <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ManagedIdentityAuthenticationSettingProperties.

## EXAMPLES

### Example 1: Build a managed identity authentication setting
```powershell
# Build an authentication setting property object for a managed identity
New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName SystemAssigned -DisplayName 'Default managed identity'
```

Creates the property object to pass to New-AzMonitorHealthModelAuthenticationSetting.
Use SystemAssigned, or the resource ID of a user-assigned identity.

## PARAMETERS

### -DisplayName
Display name.

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

### -ManagedIdentityName
Name of the managed identity to use.
Either 'SystemAssigned' or the resourceId of a user-assigned identity.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ManagedIdentityAuthenticationSettingProperties

## NOTES

## RELATED LINKS
