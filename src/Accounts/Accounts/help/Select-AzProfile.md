---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version:  https://docs.microsoft.com/en-us/powershell/module/az.accounts/select-azprofile
schema: 2.0.0
---

# Select-AzProfile

## SYNOPSIS
For modules that support multiple service profiles - load the cmdlets corresponding with the given service profile.

## SYNTAX

```
Select-AzProfile -Name <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
For modules that support multiple service profiles - load the cmdlets corresponding with the given service profile.

## EXAMPLES

### Example 1
```powershell
PS C:\> Select-AzProfile hybrid-2019-03
```

Load cmdlets for the AzureStack profile from March 2019

## PARAMETERS

### -Name
The name of the profile to select

```yaml
Type: String
Parameter Sets: (All)
Aliases: ProfileName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
