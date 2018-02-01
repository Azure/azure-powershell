---
external help file: Microsoft.Azure.Commands.Resources.dll-Help.xml
Module Name: AzureRM.Resources
online version: http://go.microsoft.com/fwlink/?LinkID=393054
schema: 2.0.0
---

# Update-AzureRmManagementPartner

## SYNOPSIS
Update the management partner

## SYNTAX

```
Update-AzureRmManagementPartner [-PartnerId] <String> [-Force] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update the management partner to a new one for this user in this tenant

## EXAMPLES

### Example 1
```powershell
PS C:\> Update-AzureRmManagementPartner -PartnerId 123457
```

Update the management partner to a new one for this user in this tenant

## PARAMETERS

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerId
The management partner id, it is a 6 digits number

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
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

### Microsoft.Azure.Commands.Resources.PSManagementPartner


## NOTES

## RELATED LINKS
[Remove-AzureRmManagementPartner](./Remove-AzureRmManagementPartner.md)

[New-AzureRmManagementPartner](./New-AzureRmManagementPartner.md)

[Get-AzureRmManagementPartner](./Get-AzureRmManagementPartner.md)