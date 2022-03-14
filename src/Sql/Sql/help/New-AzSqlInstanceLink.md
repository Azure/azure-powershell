---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# New-AzSqlInstanceLink

## SYNOPSIS
Creates a new Azure SQL Managed Instance Link.

## SYNTAX

### CreateByNameParameterSet (Default)
```
New-AzSqlInstanceLink [-ResourceGroupName] <String> [-InstanceName] <String> [-LinkName] <String>
 [-PrimaryAvailabilityGroupName] <String> [-SecondaryAvailabilityGroupName] <String> [-TargetDatabase] <String>
 [-SourceEndpoint] <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateByParentObjectParameterSet
```
New-AzSqlInstanceLink [-LinkName] <String> [-PrimaryAvailabilityGroupName] <String>
 [-SecondaryAvailabilityGroupName] <String> [-TargetDatabase] <String> [-SourceEndpoint] <String>
 [-Instance] <AzureSqlManagedInstanceModel> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSqlInstanceLink** cmdlet creates an Azure SQL Managed Instance Link by join Distributed Availability Group on SQL Server based on the parameters passed.

## EXAMPLES

### Example 1: Create a new Managed Instance Link
```powershell
PS C:\> New-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "Instance01" -LinkName "Link01" -PrimaryAvailabilityGroupName "Link01PrimaryAG" -SecondaryAvailabilityGroupName "Link01SecondaryAG" -TargetDatabase "Link01DB" -SourceEndpoint "TCP://SERVER01:7022"		
ResourceGroupName              : ResourceGroup01
InstanceName                   : Instance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/Instance01/distributedAvailabilityGroups/Link01
LinkName                       : Link01
TargetDatabase                 : Link01DB
SourceEndpoint                 : TCP://SERVER01:7022
PrimaryAvailabilityGroupName   : Link01PrimaryAG
SecondaryAvailabilityGroupName : Link01SecondaryAG
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command creates a new managed instance link with name Link01.

### Example 2: Create a new Managed Instance Link in an instance using an instance object
```powershell
PS C:\> $instance = Get-AzSqlInstance -ResourceGroupName "ResourceGroup01" -Name "Instance01"
PS C:\> New-AzSqlInstanceLink -Instance $instance -LinkName "Link01" -PrimaryAvailabilityGroupName "Link01PrimaryAG" -SecondaryAvailabilityGroupName "Link01SecondaryAG" -TargetDatabase "Link01DB" -SourceEndpoint "TCP://SERVER01:7022"		
ResourceGroupName              : ResourceGroup01
InstanceName                   : Instance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/Instance01/distributedAvailabilityGroups/Link01
LinkName                       : Link01
TargetDatabase                 : Link01DB
SourceEndpoint                 : TCP://SERVER01:7022
PrimaryAvailabilityGroupName   : Link01PrimaryAG
SecondaryAvailabilityGroupName : Link01SecondaryAG
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command creates a new managed instance link using an instance object.

### Example 3: Create a new Managed Instance Link by piping an instance object
```powershell
PS C:\> $instance = Get-AzSqlInstance -ResourceGroupName "ResourceGroup01" -Name "Instance01"
PS C:\> $instance | New-AzSqlInstanceLink -LinkName "Link01" -PrimaryAvailabilityGroupName "Link01PrimaryAG" -SecondaryAvailabilityGroupName "Link01SecondaryAG" -TargetDatabase "Link01DB" -SourceEndpoint "TCP://SERVER01:7022"		
ResourceGroupName              : ResourceGroup01
InstanceName                   : Instance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/Instance01/distributedAvailabilityGroups/Link01
LinkName                       : Link01
TargetDatabase                 : Link01DB
SourceEndpoint                 : TCP://SERVER01:7022
PrimaryAvailabilityGroupName   : Link01PrimaryAG
SecondaryAvailabilityGroupName : Link01SecondaryAG
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command creates a new managed instance link using an instance object.


## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -Instance
The instance input object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: CreateByParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
The name of the Azure SQL Managed Instance.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinkName
The name of the Managed Instance link.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryAvailabilityGroupName
The name of the primary availability group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryAvailabilityGroupName
The name of the secondary availability group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceEndpoint
The adress of the source endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDatabase
The name of the target database.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 5
Default value: None
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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel

## NOTES

## RELATED LINKS
