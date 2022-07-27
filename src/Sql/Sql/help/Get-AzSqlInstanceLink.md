---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/get-azsqlinstancelink
schema: 2.0.0
---

# Get-AzSqlInstanceLink

## SYNOPSIS
Returns information about link feature for Azure SQL Managed Instance.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzSqlInstanceLink [-ResourceGroupName] <String> [-InstanceName] <String> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzSqlInstanceLink [[-Name] <String>] [-InstanceObject] <AzureSqlManagedInstanceModel>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByInstanceResourceIdParameterSet
```
Get-AzSqlInstanceLink [[-Name] <String>] [-InstanceResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSqlInstanceLink [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlInstanceLink** cmdlet returns information about one or more instance of Azure SQL Managed Instance links. Specify the name of a link to see information for that link only.

## EXAMPLES

### Example 1: Get information about an active link on Azure SQL Managed Instance
```powershell
Get-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Link01"
```

```Output
ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                           : Link01
TargetDatabase                 : Database01
SourceEndpoint                 : TCP://SERVER01:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command gets information about the instance link named "Link01" on instance "Instance01" and resource group "ResourceGroup01".

### Example 2: Get information about all active links on Azure SQL Managed Instance
```powershell
Get-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01"
```

```Output
ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                           : Link01
TargetDatabase                 : Database01
SourceEndpoint                 : TCP://SERVER01:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :

ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link02
Name                           : Link02
TargetDatabase                 : Database02
SourceEndpoint                 : TCP://SERVER02:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command gets information about all active instance links on instance "ManagedInstance01" and resource group "ResourceGroup01".

### Example 3: Get all instance links on Azure SQL Managed Instance using Instance object
```powershell
$instance = Get-AzSqlInstance -Name "ManagedInstance01" -ResourceGroupName "ResourceGroup01"
Get-AzSqlInstanceLink -InstanceObject $instance
```

```Output
ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                           : Link01
TargetDatabase                 : Database01
SourceEndpoint                 : TCP://SERVER01:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :

ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link02
Name                           : Link02
TargetDatabase                 : Database02
SourceEndpoint                 : TCP://SERVER02:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command gets information on all active instance links on the instance "ManagedInstance01".

### Example 4: Get all instance links on Azure SQL Managed Instance using resource identifier
```powershell
Get-AzSqlInstanceLink -InstanceResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01"
```

```Output
ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                           : Link01
TargetDatabase                 : Database01
SourceEndpoint                 : TCP://SERVER01:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :

ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link02
Name                           : Link02
TargetDatabase                 : Database02
SourceEndpoint                 : TCP://SERVER02:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command gets information about all instance links for the instance "ManagedInstance01".

### Example 5: Get an instance link using its resource identifier
```powershell
Get-AzSqlInstanceLink -ResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/resourcegroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01"
```

```Output
ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                           : Link01
TargetDatabase                 : Database01
SourceEndpoint                 : TCP://SERVER01:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command gets information about the instance link named "Link01".

### Example 6: Get all instance links for a Managed Instance by piping an instance object
```powershell
Get-AzSqlInstance -Name "ManagedInstance01" -ResourceGroupName "ResourceGroup01" | Get-AzSqlInstanceLink
```

```Output
ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                           : Link01
TargetDatabase                 : Database01
SourceEndpoint                 : TCP://SERVER01:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :

ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link02
Name                           : Link02
TargetDatabase                 : Database02
SourceEndpoint                 : TCP://SERVER02:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command gets information about all instance links within the instance "ManagedInstance01".

### Example 7: Get a specific instance link for an instance by piping an instance object and specifying the link name
```powershell
Get-AzSqlInstance -Name "ManagedInstance01" -ResourceGroupName "ResourceGroup01" | Get-AzSqlInstanceLink -Name "Link01"
```

```Output
ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                           : Link01
TargetDatabase                 : Database01
SourceEndpoint                 : TCP://SERVER01:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command gets information about the instance link named "Link01: within the instance "Instance01".

### Example 8: Get information about instance link using positional parameters
```powershell
Get-AzSqlInstanceLink "ResourceGroup01" "ManagedInstance01" "Link01"
```

```Output
ResourceGroupName              : ResourceGroup01
InstanceName                   : ManagedInstance01
Type                           : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                           : Link01
TargetDatabase                 : Database01
SourceEndpoint                 : TCP://SERVER01:5022
PrimaryAvailabilityGroupName   :
SecondaryAvailabilityGroupName :
ReplicationMode                : Async
DistributedAvailabilityGroupId : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SourceReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
TargetReplicaId                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
LinkState                      : Copying
LastHardenedLsn                :
```

This command gets information about the instance link named "Link01" on instance "Instance01" and resource group "ResourceGroup01".

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

### -InstanceName
Name of Azure SQL Managed Instance.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceObject
Instance input object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: GetByParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceResourceId
Managed instance resource ID.

```yaml
Type: System.String
Parameter Sets: GetByInstanceResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Name of the instance link.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet, GetByParentObjectParameterSet, GetByInstanceResourceIdParameterSet
Aliases: LinkName

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The instance link resource ID.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel

## NOTES

## RELATED LINKS

[New-AzSqlInstanceLink](./New-AzSqlInstanceLink.md)

[Update-AzSqlInstanceLink](./Update-AzSqlInstanceLink.md)

[Remove-AzSqlInstanceLink](./Remove-AzSqlInstanceLink.md)
