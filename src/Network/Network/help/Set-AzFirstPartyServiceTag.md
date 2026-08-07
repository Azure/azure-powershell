---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azfirstpartyservicetag
schema: 2.0.0
---

# Set-AzFirstPartyServiceTag

## SYNOPSIS
Updates a first party service tag.

## SYNTAX

```
Set-AzFirstPartyServiceTag -FirstPartyServiceTag <PSFirstPartyServiceTag> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzFirstPartyServiceTag** cmdlet updates a first party service tag from a pipeline input object.
Modify the object's value or resource tags before passing it to this cmdlet.

## EXAMPLES

### Example 1
```powershell
$serviceTag = Get-AzFirstPartyServiceTag -ResourceGroupName "ContosoResourceGroup" -Name "ContosoServiceTag"
$serviceTag.Value = "UpdatedServiceTagValue"
$serviceTag | Set-AzFirstPartyServiceTag
```

These commands get a first party service tag, change its value, and update the resource.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -AsJob
Run the cmdlet in the background.

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

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirstPartyServiceTag
The first party service tag input object.

```yaml
Type: PSFirstPartyServiceTag
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSFirstPartyServiceTag

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSFirstPartyServiceTag

## NOTES

## RELATED LINKS

[New-AzFirstPartyServiceTag](New-AzFirstPartyServiceTag.md)

[Get-AzFirstPartyServiceTag](Get-AzFirstPartyServiceTag.md)

[Remove-AzFirstPartyServiceTag](Remove-AzFirstPartyServiceTag.md)
