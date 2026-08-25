---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azinterconnectgroup
schema: 2.0.0
---

# New-AzInterconnectGroup

## SYNOPSIS
Creates an interconnect group.

## SYNTAX

```
New-AzInterconnectGroup -ResourceGroupName <String> -Name <String> -Location <String> -VMSize <String>
 [-Scope <String>] [-SubgroupScope <String>] [-SubgroupSize <Int32>] [-Tag <Hashtable>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzInterconnectGroup** cmdlet creates an interconnect group. An interconnect group describes a set of virtual machines that are placed together on high-bandwidth interconnect hardware. The virtual machine size of the subgroups is required at creation time.

## EXAMPLES

### Example 1: Create an interconnect group
```powershell
New-AzInterconnectGroup -ResourceGroupName "ResourceGroup01" -Name "InterconnectGroup01" -Location "westus2" -VMSize "Standard_ND128isr_GB300_v6"
```

This command creates an interconnect group named InterconnectGroup01 in the resource group named ResourceGroup01, with subgroups made up of Standard_ND128isr_GB300_v6 virtual machines.

### Example 2: Create an interconnect group with a scope and subgroup profile
```powershell
New-AzInterconnectGroup -ResourceGroupName "ResourceGroup01" -Name "InterconnectGroup01" -Location "westus2" -VMSize "Standard_ND128isr_GB300_v6" -Scope "InfiniBand" -SubgroupScope "VerticalConnect" -SubgroupSize 4
```

This command creates an interconnect group whose interconnect scope is InfiniBand, and whose subgroups have a VerticalConnect scope and contain four nodes each.

### Example 3: Create an interconnect group with tags
```powershell
New-AzInterconnectGroup -ResourceGroupName "ResourceGroup01" -Name "InterconnectGroup01" -Location "westus2" -VMSize "Standard_ND128isr_GB300_v6" -Tag @{ team = "hpc"; env = "prod" }
```

This command creates an interconnect group and assigns the team and env tags to it.

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

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -Location
The location of the interconnect group.

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
The name of the interconnect group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, InterconnectGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name of the interconnect group.

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

### -Scope
The scope of the interconnect group.

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

### -SubgroupScope
The scope of the subgroups within the interconnect group.

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

### -SubgroupSize
The number of nodes in each subgroup within the interconnect group.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

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

### -VMSize
The virtual machine size of the subgroups within the interconnect group.

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

### System.Int32

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSInterconnectGroup

## NOTES

## RELATED LINKS
