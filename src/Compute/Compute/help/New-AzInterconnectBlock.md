---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azinterconnectblock
schema: 2.0.0
---

# New-AzInterconnectBlock

## SYNOPSIS
Creates an Interconnect Block resource.

## SYNTAX

```
New-AzInterconnectBlock -ResourceGroupName <String> -Name <String> -Location <String>
 -InterconnectGroupId <String> -SkuName <String> -SkuCapacity <Int64> [-Zone <String[]>] [-SkuTier <String>]
 [-PlacementExcludeZone <String[]>] [-PlacementIncludeZone <String[]>]
 [-PlacementZonePlacementPolicy <String>] [-Tag <Hashtable>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzInterconnectBlock** cmdlet creates a Microsoft.Compute/interconnectBlocks resource, which pre-allocates a specified number of VMs within a network boundary tied to an InterconnectGroup.

## EXAMPLES

### Example 1: Create an Interconnect Block
```powershell
$igId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG/providers/Microsoft.Network/interconnectGroups/myIG"
New-AzInterconnectBlock -ResourceGroupName "myRG" -Name "myICB" -Location "eastus" -InterconnectGroupId $igId `
    -SkuName "Standard_ND128isr_GB300_v6" -SkuCapacity 18 -Zone @("1")
```

This command creates an Interconnect Block with a capacity of 18 VM instances in availability zone 1.

### Example 2: Create an Interconnect Block with placement constraints and tags
```powershell
$igId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG/providers/Microsoft.Network/interconnectGroups/myIG"
New-AzInterconnectBlock -ResourceGroupName "myRG" -Name "myICB" -Location "eastus" -InterconnectGroupId $igId `
    -SkuName "Standard_ND128isr_GB300_v6" -SkuCapacity 36 -Zone @("1") `
    -PlacementZonePlacementPolicy "Any" -PlacementIncludeZone @("1","2") `
    -Tag @{ Environment = "Production"; Workload = "AI-Training" }
```

This command creates an Interconnect Block with placement constraints and tags.

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

### -InterconnectGroupId
The ARM resource ID of the Microsoft.Network/interconnectGroups resource. Required at create and immutable thereafter.

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

### -Location
Specifies the location for the Interconnect Block. Immutable after create.

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

### -Name
Specifies the name of the Interconnect Block resource.

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

### -PlacementExcludeZone
List of availability zones to exclude from placement consideration.

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

### -PlacementIncludeZone
List of availability zones to include for placement consideration.

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

### -PlacementZonePlacementPolicy
Controls the zone placement policy. Accepted value: Any.

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

### -ResourceGroupName
Specifies the name of a resource group.

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

### -SkuCapacity
The number of VM instances to reserve. Must be a multiple of 18.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuName
The VM SKU name for the Interconnect Block (e.g. Standard_ND128isr_GB300_v6). Immutable after create.

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

### -SkuTier
The SKU tier.

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

### -Tag
Specifies that resources and resource groups can be tagged with a set of name-value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
The availability zones for the Interconnect Block. Immutable after create.

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

### System.String

### System.Int64

### System.String[]

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSInterconnectBlock

## NOTES

## RELATED LINKS
