---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azinterconnectgroupsubgroup
schema: 2.0.0
---

# Get-AzInterconnectGroupSubgroup

## SYNOPSIS
Gets a subgroup of an interconnect group.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzInterconnectGroupSubgroup -ResourceGroupName <String> -InterconnectGroupName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzInterconnectGroupSubgroup -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzInterconnectGroupSubgroup** cmdlet gets one or more subgroups of an interconnect group. Subgroups are read-only child resources that are created and managed by the platform. If no name is specified, all subgroups of the interconnect group are returned.

## EXAMPLES

### Example 1: List all subgroups of an interconnect group
```powershell
Get-AzInterconnectGroupSubgroup -ResourceGroupName "ResourceGroup01" -InterconnectGroupName "InterconnectGroup01"
```

This command lists all subgroups of the interconnect group named InterconnectGroup01.

### Example 2: Get a subgroup by name
```powershell
Get-AzInterconnectGroupSubgroup -ResourceGroupName "ResourceGroup01" -InterconnectGroupName "InterconnectGroup01" -Name "Subgroup01"
```

This command gets the subgroup named Subgroup01 of the interconnect group named InterconnectGroup01.

### Example 3: Get a subgroup by resource ID
```powershell
Get-AzInterconnectGroupSubgroup -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Network/interconnectGroups/InterconnectGroup01/subgroups/Subgroup01"
```

This command gets the subgroup identified by the specified resource ID.

## PARAMETERS

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

### -InterconnectGroupName
The name of the interconnect group.

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

### -Name
The name of the subgroup.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases: ResourceName, SubgroupName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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
The resource id of the subgroup.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases: SubgroupId

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

### Microsoft.Azure.Commands.Network.Models.PSSubgroup

## NOTES

## RELATED LINKS
