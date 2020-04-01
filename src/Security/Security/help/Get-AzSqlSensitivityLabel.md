---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://docs.microsoft.com/en-us/powershell/module/az.security/Get-AzSqlSensitivityLabel
schema: 2.0.0
---

# Get-AzSqlSensitivityLabel

## SYNOPSIS
Retrieves details of a sensitivity label in the SQL information protection policy.

## SYNTAX

```
Get-AzSqlSensitivityLabel -DisplayName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves details of a sensitivity label in the SQL information protection policy.

## EXAMPLES

### Example
```powershell
Get-AzSqlSensitivityLabel -DisplayName Confidential
DisplayName      : Confidential
Description      : Sensitive business data that could cause damage to the business if shared with unauthorized people
State            : Enabled
Rank             : None
Order            : 300
InformationTypes : {Networking, Contact Info, Credentials, Credit Card...}
```

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -DisplayName
The name of the sensitivity label

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.SecurityCenter.Models.PSSqlInformationProtectionPolicy.PSSqlSensitivityLabel

## NOTES

## RELATED LINKS
