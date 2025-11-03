---
external help file: Az.SqlVirtualMachine-help.xml
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/new-azavailabilitygrouplistener
schema: 2.0.0
---

# New-AzAvailabilityGroupListener

## SYNOPSIS
Create an availability group listener.

## SYNTAX

### CreateExpanded (Default)
```
New-AzAvailabilityGroupListener -Name <String> -ResourceGroupName <String> -SqlVMGroupName <String>
 [-SubscriptionId <String>] [-AvailabilityGroupConfigurationReplica <IAgReplica[]>]
 [-AvailabilityGroupName <String>] [-CreateDefaultAvailabilityGroupIfNotExist]
 [-MultiSubnetIPConfiguration <IMultiSubnetIPConfiguration[]>] [-Port <Int32>] [-IpAddress <String>]
 [-LoadBalancerResourceId <String>] [-ProbePort <Int32>] [-PublicIpAddressResourceId <String>]
 [-SqlVirtualMachineId <String[]>] [-SubnetId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentitySqlVirtualMachineGroupExpanded
```
New-AzAvailabilityGroupListener -Name <String> -SqlVirtualMachineGroupInputObject <ISqlVirtualMachineIdentity>
 [-AvailabilityGroupConfigurationReplica <IAgReplica[]>] [-AvailabilityGroupName <String>]
 [-CreateDefaultAvailabilityGroupIfNotExist] [-LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]
 [-MultiSubnetIPConfiguration <IMultiSubnetIPConfiguration[]>] [-Port <Int32>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzAvailabilityGroupListener -Name <String> -ResourceGroupName <String> -SqlVMGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzAvailabilityGroupListener -Name <String> -ResourceGroupName <String> -SqlVMGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create an availability group listener.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.IAgReplica[]
Parameter Sets: CreateExpanded, CreateViaIdentitySqlVirtualMachineGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentitySqlVirtualMachineGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentitySqlVirtualMachineGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancerConfiguration
List of load balancer configurations for an availability group listener.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ILoadBalancerConfiguration[]
Parameter Sets: CreateViaIdentitySqlVirtualMachineGroupExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MultiSubnetIPConfiguration
List of multi subnet IP configurations for an AG listener.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.IMultiSubnetIPConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentitySqlVirtualMachineGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentitySqlVirtualMachineGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbePort
Probe port.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlVirtualMachineGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity
Parameter Sets: CreateViaIdentitySqlVirtualMachineGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SqlVirtualMachineId
List of the SQL virtual machine instance resource id's that are enrolled into the availability group listener.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.IAvailabilityGroupListener

## NOTES

## RELATED LINKS
