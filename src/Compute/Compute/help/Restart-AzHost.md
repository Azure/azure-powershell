---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version:
schema: 2.0.0
---

# Restart-AzHost

## SYNOPSIS
Restart the dedicated host.

## SYNTAX

### DefaultParameterSet (Default)
```
Restart-AzHost [-ResourceGroupName] <String> [-HostGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Restart-AzHost -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ObjectParameterSet
```
Restart-AzHost -InputObject <PSHost> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Restart the dedicated host. The operation will complete successfully once the dedicated host has restarted and is running. To determine the health of VMs deployed on the dedicated host after the restart check the Resource Health Center in the Azure Portal. Please refer to https://docs.microsoft.com/en-us/azure/service-health/resource-health-overview for more details.

## EXAMPLES

### Example 1
```powershell
$Location = 'Location';
$ResourceGroupName = New-AzResourceGroup -Name $rgname -Location $Location -Force;

$hostGroupName = $ResourceGroupName + 'hostgroup'
New-AzHostGroup -ResourceGroupName $ResourceGroupName -Name $hostGroupName -Location $Location -PlatformFaultDomain 1  -Zone "2" -Tag @{key1 = "val1"};

$hostGroup = Get-AzHostGroup -ResourceGroupName $ResourceGroupName -Name $hostGroupName;
$hostName = $ResourceGroupName + 'host';
New-AzHost -ResourceGroupName $ResourceGroupName -HostGroupName $hostGroupName -Name $hostName -Location $Location -Sku "ESv3-Type1" -Tag @{key1 = "val2"};

$dedicatedHost = Get-AzHost -ResourceGroupName $ResourceGroupName -HostGroupName $hostGroupName -Name $hostName;
Restart-AzHost -ResourceGroupName $ResourceGroupName -HostGroupName $hostGroupName -Name $hostName;

# Check the status of the restart operation
$hostRestart = Get-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -InstanceView;
$hostRestart.InstanceView.Statuses[1].DisplayStatus;
```

This example creates a dedicated host group and a dedicated host. Then it begins restarting the dedicated host, and checks the status of this restart operation.
You can query the status of the restart operation with the `Get-AzHost` cmdlet using the `-InstanceView` parameter.

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

### -HostGroupName
The name of the dedicated host group.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The dedicated host object.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSHost
Parameter Sets: ObjectParameterSet
Aliases: Host

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the dedicated host.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases: HostName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The ARM resource id of the dedicated host.

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

### Microsoft.Azure.Commands.Compute.Automation.Models.PSHost

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSOperationStatusResponse

## NOTES

## RELATED LINKS
