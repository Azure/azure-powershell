---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# Update-AzVirtualNetworkAppliance

## SYNOPSIS
Updates a Virtual Network Appliance (VNA) resource.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Update-AzVirtualNetworkAppliance -Name <String> -ResourceGroupName <String> [-Tag <Hashtable>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzVirtualNetworkAppliance -ResourceId <String> [-Tag <Hashtable>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Update-AzVirtualNetworkAppliance -InputObject <PSVirtualNetworkAppliance> [-Tag <Hashtable>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Update-AzVirtualNetworkAppliance cmdlet updates a Virtual Network Appliance resource in Azure.
Currently supports updating tags on the VNA resource.

## EXAMPLES

### Example 1: Update VNA tags by name
```powershell
Update-AzVirtualNetworkAppliance -Name "myVNA" -ResourceGroupName "myResourceGroup" -Tag @{"Environment" = "Production"; "Team" = "Network"}
```

Updates the tags on a Virtual Network Appliance named "myVNA".

### Example 2: Update VNA tags by resource ID
```powershell
Update-AzVirtualNetworkAppliance -ResourceId "/subscriptions/xxx/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworkAppliances/myVNA" -Tag @{"Environment" = "Staging"}
```

Updates the tags on a Virtual Network Appliance using its resource ID.

### Example 3: Update VNA using pipeline
```powershell
Get-AzVirtualNetworkAppliance -Name "myVNA" -ResourceGroupName "myResourceGroup" | Update-AzVirtualNetworkAppliance -Tag @{"Updated" = "true"}
```

Gets a Virtual Network Appliance and updates its tags using the pipeline.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Virtual Network Appliance object.

```yaml
Type: PSVirtualNetworkAppliance
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: ResourceNameParameterSet
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource Id.

```yaml
Type: String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkAppliance

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetworkAppliance

## NOTES

## RELATED LINKS
