---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://docs.microsoft.com/en-us/powershell/module/az.security/Get-AzSqlInformationType
schema: 2.0.0
---

# Get-AzSqlInformationType

## SYNOPSIS
Retrieves details of an information type in the SQL information protection policy.

## SYNTAX

```
Get-AzSqlInformationType -DisplayName <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves details of an information type in the SQL information protection policy.

## EXAMPLES

### Example
```powershell
Get-AzSqlInformationType -DisplayName Networking
DisplayName     : Networking
Description     : Data related to the network domain. Example: IP, port, etc.
State           : Enabled
AssociatedLabel : Confidential
Order           : 100
Type            : BuiltIn
Keywords        : {{
                        Pattern: ip,
                        State: Enabled,
                        Type: BuiltIn,
                        AllowNumeric: False,
                  }, {
                        Pattern: %[^h]ip%address%,
                        State: Enabled,
                        Type: BuiltIn,
                        AllowNumeric: False,
                  }, {
                        Pattern: ip%address%,
                        State: Enabled,
                        Type: BuiltIn,
                        AllowNumeric: False,
                  }, {
                        Pattern: %mac%address%,
                        State: Enabled,
                        Type: BuiltIn,
                        AllowNumeric: False,
                  }}
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
The name of the information type

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

### Microsoft.Azure.Commands.SecurityCenter.Models.PSSqlInformationProtectionPolicy.PSSqlInformationType

## NOTES

## RELATED LINKS
