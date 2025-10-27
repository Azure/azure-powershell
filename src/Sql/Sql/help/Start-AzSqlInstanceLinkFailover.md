---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/start-azsqlinstancelinkfailover
schema: 2.0.0
---

# Start-AzSqlInstanceLinkFailover

## SYNOPSIS
Failovers an instance link.

## SYNTAX

### FailoverByNameParameterSet (Default)
```
Start-AzSqlInstanceLinkFailover [-ResourceGroupName] <String> [-InstanceName] <String> [-Name] <String>
 -FailoverType <String> [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### FailoverByParentObjectParameterSet
```
Start-AzSqlInstanceLinkFailover [-Name] <String> -FailoverType <String>
 [-InstanceObject] <AzureSqlManagedInstanceModel> [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### FailoverByInputObjectParameterSet
```
Start-AzSqlInstanceLinkFailover [-Name] <String> -FailoverType <String>
 [-InputObject] <AzureSqlManagedInstanceLinkModel> [-Force] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FailoverByResourceIdParameterSet
```
Start-AzSqlInstanceLinkFailover -FailoverType <String> [-ResourceId] <String> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
**Start-AzSqlInstanceLinkFailover** cmdlet failovers an instance link.

## EXAMPLES

### Example 1
```powershell
Start-AzSqlInstanceLinkFailover -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Link01" -FailoverType "ForcedAllowDataLoss"
```

```output
ResourceGroupName                : ResourceGroup01
InstanceName                     : ManagedInstance01
Type                             : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                             : Link01
DistributedAvailabilityGroupName : Link01
DistributedAvailabilityGroupId   : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Databases                        : {Database01}
InstanceAvailabilityGroupName    : AG_Database01_MI
PartnerAvailabilityGroupName     : AG_Database01
PartnerEndpoint                  : TCP://SERVER01:5022
InstanceLinkRole                 : Primary
PartnerLinkRole                  : Secondary
ReplicationMode                  : Async
FailoverMode                     : Manual
SeedingMode                      : Automatic
```

This command does forced failover of the instance link with name "Link01".

### Example 2
```powershell
$instance = Get-AzSqlInstance -ResourceGroupName "ResourceGroup01" -Name "ManagedInstance01"
$instance | Start-AzSqlInstanceLinkFailover -Name "Link01" -FailoverType "Planned"
```

```output
ResourceGroupName                : ResourceGroup01
InstanceName                     : ManagedInstance01
Type                             : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/distributedAvailabilityGroups/Link01
Name                             : Link01
DistributedAvailabilityGroupName : Link01
DistributedAvailabilityGroupId   : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Databases                        : {Database01}
InstanceAvailabilityGroupName    : AG_Database01_MI
PartnerAvailabilityGroupName     : AG_Database01
PartnerEndpoint                  : TCP://SERVER01:5022
InstanceLinkRole                 : Primary
PartnerLinkRole                  : Secondary
ReplicationMode                  : Async
FailoverMode                     : Manual
SeedingMode                      : Automatic
```

This command does planned failover of the instance link by piping an instance object.

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

### -FailoverType
The failover type, can be ForcedAllowDataLoss or Planned.

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

### -Force
Skip confirmation message for performing the action

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

### -InputObject
Instance link input object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel
Parameter Sets: FailoverByInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
Name of the managed instance.

```yaml
Type: System.String
Parameter Sets: FailoverByNameParameterSet
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
Parameter Sets: FailoverByParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Managed Instance link name.

```yaml
Type: System.String
Parameter Sets: FailoverByNameParameterSet, FailoverByParentObjectParameterSet, FailoverByInputObjectParameterSet
Aliases: LinkName

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: FailoverByNameParameterSet
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
Parameter Sets: FailoverByResourceIdParameterSet
Aliases:

Required: True
Position: 0
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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceHybridLink.Model.AzureSqlManagedInstanceLinkModel

## NOTES

## RELATED LINKS

[New-AzSqlInstanceLink](./New-AzSqlInstanceLink.md)

[Get-AzSqlInstanceLink](./Get-AzSqlInstanceLink.md)

[Update-AzSqlInstanceLink](./Update-AzSqlInstanceLink.md)

[Remove-AzSqlInstanceLink](./Remove-AzSqlInstanceLink.md)