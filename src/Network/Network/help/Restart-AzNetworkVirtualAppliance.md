---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/restart-aznetworkvirtualappliance
schema: 2.0.0
---

# Restart-AzNetworkVirtualAppliance

## SYNOPSIS
Restarts a virtual machine instance in the Network Virtual Appliance or all the instances in a Network Virtual Appliance.

## SYNTAX

### ResourceNameParameterSet (Default)
```
Restart-AzNetworkVirtualAppliance -ResourceGroupName <String> -Name <String> [-InstanceId <String[]>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Restart-AzNetworkVirtualAppliance [-InstanceId <String[]>] -ResourceId <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Restart-AzNetworkVirtualAppliance cmdlet restarts the virtual machine instances associated with a Network Virtual Appliance (NVA).This cmdlet can also be used to restart a specific virtual machine associates with the NVA by using the InstanceId parameter.

## EXAMPLES

### Example 1
```powershell
Restart-AzNetworkVirtualAppliance -Name testNvaName -ResourceGroupName testRgName -InstanceId "1","0"
```

This command restarts the instances with ID "1" and ID "0" of the network virtual appliance named "testNvaName" that belongs to the resource group named "testRgName".

### Example 2
```powershell
Restart-AzNetworkVirtualAppliance -Name testNvaName -ResourceGroupName testRgName
```

This command restarts all the instances of the network virtual appliance named "testNvaName" that belongs to the resource group named "testRgName".

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

### -InstanceId
Network Virtual Appliance instance ids to be restarted

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

### -Name
The Network Virtual Appliance name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases: VirtualApplianceName, NvaName, NetworkVirtualApplianceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
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
Type: System.String
Parameter Sets: ResourceIdParameterSet
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

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualApplianceRestartOperationStatusResponse

## NOTES

## RELATED LINKS
