---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azinterconnectgroupnodeavailability
schema: 2.0.0
---

# Get-AzInterconnectGroupNodeAvailability

## SYNOPSIS
Gets the node availability of an interconnect group.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzInterconnectGroupNodeAvailability -ResourceGroupName <String> -Name <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByInputObjectParameterSet
```
Get-AzInterconnectGroupNodeAvailability -InputObject <PSInterconnectGroup> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzInterconnectGroupNodeAvailability -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzInterconnectGroupNodeAvailability** cmdlet gets the node availability of an interconnect group. The result reports, for each subgroup, how many nodes are in service, how many are in use, and the total node count.

## EXAMPLES

### Example 1: Get the node availability of an interconnect group
```powershell
Get-AzInterconnectGroupNodeAvailability -ResourceGroupName "ResourceGroup01" -Name "InterconnectGroup01"
```

This command gets the node availability of the interconnect group named InterconnectGroup01.

### Example 2: Get the node availability by using the pipeline
```powershell
Get-AzInterconnectGroup -ResourceGroupName "ResourceGroup01" -Name "InterconnectGroup01" | Get-AzInterconnectGroupNodeAvailability
```

This command pipes an interconnect group to Get-AzInterconnectGroupNodeAvailability.

### Example 3: Get the node availability by resource ID
```powershell
Get-AzInterconnectGroupNodeAvailability -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Network/interconnectGroups/InterconnectGroup01"
```

This command gets the node availability of the interconnect group identified by the specified resource ID.

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

### -InputObject
The interconnect group object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSInterconnectGroup
Parameter Sets: GetByInputObjectParameterSet
Aliases: InterconnectGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the interconnect group.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases: ResourceName, InterconnectGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -ResourceGroupName
The resource group name of the interconnect group.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource id of the interconnect group.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases: InterconnectGroupId

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

### Microsoft.Azure.Commands.Network.Models.PSInterconnectGroup

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSInterconnectGroupNodeAvailability

## NOTES

## RELATED LINKS
