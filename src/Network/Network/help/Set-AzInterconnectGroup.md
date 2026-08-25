---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azinterconnectgroup
schema: 2.0.0
---

# Set-AzInterconnectGroup

## SYNOPSIS
Updates an interconnect group.

## SYNTAX

```
Set-AzInterconnectGroup -InterconnectGroup <PSInterconnectGroup> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzInterconnectGroup** cmdlet updates an existing interconnect group. Retrieve the interconnect group with Get-AzInterconnectGroup, modify the object, and then pass it to this cmdlet to persist the changes.

## EXAMPLES

### Example 1: Update the tags of an interconnect group
```powershell
$interconnectGroup = Get-AzInterconnectGroup -ResourceGroupName "ResourceGroup01" -Name "InterconnectGroup01"
$interconnectGroup.Tag = @{ team = "hpc" }
Set-AzInterconnectGroup -InterconnectGroup $interconnectGroup
```

This command gets an interconnect group, sets its tags, and then persists the change.

### Example 2: Update an interconnect group by using the pipeline
```powershell
Get-AzInterconnectGroup -ResourceGroupName "ResourceGroup01" -Name "InterconnectGroup01" | Set-AzInterconnectGroup
```

This command pipes an interconnect group directly to Set-AzInterconnectGroup.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -InterconnectGroup
The interconnect group object to update.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSInterconnectGroup
Parameter Sets: (All)
Aliases: InputObject

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSInterconnectGroup

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSInterconnectGroup

## NOTES

## RELATED LINKS
