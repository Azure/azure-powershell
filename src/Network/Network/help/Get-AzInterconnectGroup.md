---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azinterconnectgroup
schema: 2.0.0
---

# Get-AzInterconnectGroup

## SYNOPSIS
Gets an interconnect group.

## SYNTAX

### ListParameterSet (Default)
```
Get-AzInterconnectGroup [-ResourceGroupName <String>] [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzInterconnectGroup -ResourceGroupName <String> -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzInterconnectGroup -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzInterconnectGroup** cmdlet gets one or more interconnect groups. If no name is specified, all interconnect groups in the resource group are returned. If neither a resource group nor a name is specified, all interconnect groups in the subscription are returned.

## EXAMPLES

### Example 1: Get an interconnect group by name
```powershell
$interconnectGroup = Get-AzInterconnectGroup -ResourceGroupName "ResourceGroup01" -Name "InterconnectGroup01"
```

This command gets the interconnect group named InterconnectGroup01 in the resource group named ResourceGroup01.

### Example 2: List all interconnect groups in a resource group
```powershell
Get-AzInterconnectGroup -ResourceGroupName "ResourceGroup01"
```

This command lists all interconnect groups in the resource group named ResourceGroup01.

### Example 3: List all interconnect groups in the subscription
```powershell
Get-AzInterconnectGroup
```

This command lists all interconnect groups in the current subscription.

### Example 4: Get an interconnect group by resource ID
```powershell
Get-AzInterconnectGroup -ResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ResourceGroup01/providers/Microsoft.Network/interconnectGroups/InterconnectGroup01"
```

This command gets the interconnect group identified by the specified resource ID.

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

### -Name
The name of the interconnect group.

```yaml
Type: System.String
Parameter Sets: ListParameterSet
Aliases: ResourceName, InterconnectGroupName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases: ResourceName, InterconnectGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSInterconnectGroup

## NOTES

## RELATED LINKS
