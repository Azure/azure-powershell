---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://docs.microsoft.com/en-us/powershell/module/az.security/Update-AzSqlSensitivityLabel
schema: 2.0.0
---

# Update-AzSqlSensitivityLabel

## SYNOPSIS
Updates properties of a sensitivity label in the SQL information protection policy.

## SYNTAX

```
Update-AzSqlSensitivityLabel [-NewDisplayName <String>] [-Description <String>]
 [-State <PSSqlSensitivityObjectState>] [-Rank <PSSensitivityRank>] [-Order <Int32>]
 [-AssociatedInformationTypes <String[]>] -DisplayName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates properties of a sensitivity label in the SQL information protection policy.

## EXAMPLES

### Example 1
```powershell
Update-AzSqlSensitivityLabel -DisplayName Restricted -State Disabled
```

Disable a sensitivity label.

### Example 2
```powershell
Update-AzSqlSensitivityLabel -DisplayName Restricted -NewDisplayName "Private Information"
```

Rename a sensitivity label.

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

### -AssociatedInformationTypes
If any of these information types are identified, this label is applied

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Description
The description of the sensitivity label

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -NewDisplayName
The new name of the sensitivity label

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Order
The order of the sensitivity label.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Rank
An identifier based on a predefinied set of values which define sensitivity rank.Used by other services like Advanced Threat Protection to detect anomalies based on their rank

```yaml
Type: Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy.PSSensitivityRank
Parameter Sets: (All)
Aliases:
Accepted values: None, Low, Medium, High, Critical

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -State
Indicates whether the sensitivity label is enabled or not

```yaml
Type: Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy.PSSqlSensitivityObjectState
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, Enabled

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
