---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-azfirstpartyservicetag
schema: 2.0.0
---

# Remove-AzFirstPartyServiceTag

## SYNOPSIS
Removes a first party service tag.

## SYNTAX

### FirstPartyServiceTagNameParameterSet (Default)
```
Remove-AzFirstPartyServiceTag -Name <String> -ResourceGroupName <String> [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### FirstPartyServiceTagInputObjectParameterSet
```
Remove-AzFirstPartyServiceTag -FirstPartyServiceTag <PSFirstPartyServiceTag> [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### FirstPartyServiceTagResourceIdParameterSet
```
Remove-AzFirstPartyServiceTag -ResourceId <String> [-Force] [-PassThru] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzFirstPartyServiceTag** cmdlet deletes a first party service tag.
Identify the resource by name and resource group, resource ID, or pipeline input object.

## EXAMPLES

### Example 1
```powershell
Remove-AzFirstPartyServiceTag -ResourceGroupName "ContosoResourceGroup" -Name "ContosoServiceTag" -Force
```

This command removes `ContosoServiceTag` without prompting for confirmation.

### Example 2: Remove a first party service tag from the pipeline
```powershell
Get-AzFirstPartyServiceTag -ResourceGroupName "ContosoResourceGroup" -Name "ContosoServiceTag" | Remove-AzFirstPartyServiceTag -Force
```

This command gets a first party service tag and passes it to the remove cmdlet.

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
Parameter Sets: FirstPartyServiceTagInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Name
The first party service tag name.

```yaml
Type: String
Parameter Sets: FirstPartyServiceTagNameParameterSet
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns `True` when the command succeeds.
By default, this cmdlet does not return output.

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

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: FirstPartyServiceTagNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The first party service tag resource ID.

```yaml
Type: String
Parameter Sets: FirstPartyServiceTagResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### Microsoft.Azure.Commands.Network.Models.PSFirstPartyServiceTag

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[New-AzFirstPartyServiceTag](New-AzFirstPartyServiceTag.md)

[Get-AzFirstPartyServiceTag](Get-AzFirstPartyServiceTag.md)

[Set-AzFirstPartyServiceTag](Set-AzFirstPartyServiceTag.md)
