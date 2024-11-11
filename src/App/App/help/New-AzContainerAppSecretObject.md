---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappsecretobject
schema: 2.0.0
---

# New-AzContainerAppSecretObject

## SYNOPSIS
Create an in-memory object for Secret.

## SYNTAX

```
New-AzContainerAppSecretObject [-Identity <String>] [-KeyVaultUrl <String>] [-Name <String>] [-Value <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Secret.

## EXAMPLES

### Example 1: Create an in-memory object for Secret.
```powershell
New-AzContainerAppSecretObject -Name "redis-secret" -Value "redis-password"
```

```output
Identity KeyVaultUrl Name         Value
-------- ----------- ----         -----
                     redis-secret redis-password
```

Create an in-memory object for Secret.

## PARAMETERS

### -Identity
Resource ID of a managed identity to authenticate with Azure Key Vault, or System to use a system-assigned identity.

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

### -KeyVaultUrl
Azure Key Vault URL pointing to the secret referenced by the container app.

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

### -Name
Secret Name.

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

### -Value
Secret Value.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Secret

## NOTES

## RELATED LINKS
