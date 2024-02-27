---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityawsorganizationaldatamasterobject
schema: 2.0.0
---

# New-AzSecurityAwsOrganizationalDataMasterObject

## SYNOPSIS
Create an in-memory object for AwsOrganizationalDataMaster.

## SYNTAX

```
New-AzSecurityAwsOrganizationalDataMasterObject [-ExcludedAccountId <String[]>] [-StacksetName <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AwsOrganizationalDataMaster.

## EXAMPLES

### EXAMPLE 1
```
New-AzSecurityAwsOrganizationalDataMasterObject -StacksetName "myAwsStackSet" -ExcludedAccountId "123456789012"
```

## PARAMETERS

### -ExcludedAccountId
If the multi cloud account is of membership type organization, list of accounts excluded from offering.

```yaml
Type: String[]
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
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StacksetName
If the multi cloud account is of membership type organization, this will be the name of the onboarding stackset.

```yaml
Type: String
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.AwsOrganizationalDataMaster
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityawsorganizationaldatamasterobject](https://learn.microsoft.com/powershell/module/Az.Security/new-azsecurityawsorganizationaldatamasterobject)

