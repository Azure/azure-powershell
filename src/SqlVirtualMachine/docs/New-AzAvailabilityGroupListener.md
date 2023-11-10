---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/new-azavailabilitygrouplistener
schema: 2.0.0
---

# New-AzAvailabilityGroupListener

## SYNOPSIS
Creates or updates an availability group listener.

## SYNTAX

```
New-AzAvailabilityGroupListener -Name <String> -ResourceGroupName <String> -SqlVMGroupName <String>
 [-SubscriptionId <String>] [-AvailabilityGroupConfigurationReplica <IAgReplica[]>]
 [-AvailabilityGroupName <String>] [-CreateDefaultAvailabilityGroupIfNotExist] [-IpAddress <String>]
 [-LoadBalancerResourceId <String>] [-MultiSubnetIPConfiguration <IMultiSubnetIPConfiguration[]>]
 [-Port <Int32>] [-ProbePort <Int32>] [-PublicIpAddressResourceId <String>] [-SqlVirtualMachineId <String[]>]
 [-SubnetId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an availability group listener.

## EXAMPLES

### Example 1
```powershell
New-AzAvailabilityGroupListener -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'sqlvmgroup01' -Name 'AgListener01' -AvailabilityGroupName 'AG01' -IpAddress '192.168.16.7' -LoadBalancerResourceId $LoadBalancerResourceId -SubnetId $SubnetResourceId -ProbePort 9999 -SqlVirtualMachineId $sqlvmResourceId1,$sqlvmResourceId2
```

```output
Name         ResourceGroupName
----         -----------------
AgListener01 ResourceGroup01
```

Create a new Availability Group Listener "AgListener01" with Load Balancer Configuration for the Availability Group "AG01" in SQL Virtual Machine Group "sqlvmgroup01".

### Example 2
```powershell
$msconfig1 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $SubnetResourceId1 -PrivateIPAddressIpaddress '192.168.16.9' -SqlVirtualMachineInstance $sqlvmResourceId1
$msconfig2 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $SubnetResourceId2 -PrivateIPAddressIpaddress '192.168.17.9' -SqlVirtualMachineInstance $sqlvmResourceId2

New-AzAvailabilityGroupListener -Name 'AgListener02' -ResourceGroupName 'ResourceGroup01' -SqlVMGroupName 'sqlvmgroup01' -AvailabilityGroupName 'AG02' -MultiSubnetIPConfiguration $msconfig1,$msconfig2
```

```output
Name         ResourceGroupName
----         -----------------
AgListener02 ResourceGroup01
```

Create a new Availability Group Listener "AgListener02" with Multi Subnets Configuration for the Availability Group "AG02" in SQL Virtual Machine Group "sqlvmgroup01".

## PARAMETERS

### -AsJob
Run the command as a job

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

### -AvailabilityGroupConfigurationReplica
Replica configurations.
To construct, see NOTES section for AVAILABILITYGROUPCONFIGURATIONREPLICA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.IAgReplica[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AvailabilityGroupName
Name of the availability group.

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

### -CreateDefaultAvailabilityGroupIfNotExist
Create a default availability group if it does not exist.

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
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpAddress
Private IP address bound to the availability group listener.

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

### -LoadBalancerResourceId
Resource id of the load balancer.

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

### -MultiSubnetIPConfiguration
List of multi subnet IP configurations for an AG listener.
To construct, see NOTES section for MULTISUBNETIPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.IMultiSubnetIPConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the availability group listener.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AvailabilityGroupListenerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -Port
Listener port.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 1433
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbePort
Probe port.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIpAddressResourceId
Resource id of the public IP.

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

### -ResourceGroupName
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlVirtualMachineId
List of the SQL virtual machine instance resource id's that are enrolled into the availability group listener.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlVMGroupName
Name of the SQL virtual machine group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Subnet used to include private IP.

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

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.Api20220801Preview.IAvailabilityGroupListener

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`AVAILABILITYGROUPCONFIGURATIONREPLICA <IAgReplica[]>`: Replica configurations.
  - `[Commit <Commit?>]`: Replica commit mode in availability group.
  - `[Failover <Failover?>]`: Replica failover mode in availability group.
  - `[ReadableSecondary <ReadableSecondary?>]`: Replica readable secondary mode in availability group.
  - `[Role <Role?>]`: Replica Role in availability group.
  - `[SqlVirtualMachineInstanceId <String>]`: Sql VirtualMachine Instance Id.

`MULTISUBNETIPCONFIGURATION <IMultiSubnetIPConfiguration[]>`: List of multi subnet IP configurations for an AG listener.
  - `SqlVirtualMachineInstance <String>`: SQL virtual machine instance resource id that are enrolled into the availability group listener.
  - `[PrivateIPAddressIpaddress <String>]`: Private IP address bound to the availability group listener.
  - `[PrivateIPAddressSubnetResourceId <String>]`: Subnet used to include private IP.

## RELATED LINKS

