---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# Start-AzSqlInstanceLinkFailover

## SYNOPSIS
Failovers an instance link.

## SYNTAX

### FailoverByNameParameterSet (Default)
```
Start-AzSqlInstanceLinkFailover [-ResourceGroupName] <String> [-InstanceName] <String> [-Name] <String>
 -FailoverType <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### FailoverByParentObjectParameterSet
```
Start-AzSqlInstanceLinkFailover [-Name] <String> -FailoverType <String>
 [-InstanceObject] <AzureSqlManagedInstanceModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### FailoverByInputObjectParameterSet
```
Start-AzSqlInstanceLinkFailover [-Name] <String> -FailoverType <String>
 [-InputObject] <AzureSqlManagedInstanceLinkModel> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### FailoverByResourceIdParameterSet
```
Start-AzSqlInstanceLinkFailover [-Name] <String> -FailoverType <String> [-ResourceId] <String>
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
Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01
Name                             : Link01
DistributedAvailabilityGroupName : Link01
DistributedAvailabilityGroupId   :
ReplicationMode                  :
PartnerLinkRole                  :
PartnerAvailabilityGroupName     :
PartnerEndpoint                  :
InstanceLinkRole                 : Primary
InstanceAvailabilityGroupName    :
FailoverMode                     : None
SeedingMode                      : Automatic
Databases                        :
```

This command failovers an instance link with name "Link01".

### Example 2
```powershell
$instance = Get-AzSqlInstance -ResourceGroupName "ResourceGroup01" -Name "ManagedInstance01"
$instance | Start-AzSqlInstanceLinkFailover -Name "Link01" -FailoverType "ForcedAllowDataLoss"
```

```output
ResourceGroupName                : ResourceGroup01
InstanceName                     : ManagedInstance01
Type                             : Microsoft.Sql/managedInstances/distributedAvailabilityGroups
Id                               : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01
Name                             : Link01
DistributedAvailabilityGroupName : Link01
DistributedAvailabilityGroupId   :
ReplicationMode                  :
PartnerLinkRole                  :
PartnerAvailabilityGroupName     :
PartnerEndpoint                  :
InstanceLinkRole                 : Primary
InstanceAvailabilityGroupName    :
FailoverMode                     : None
SeedingMode                      : Automatic
Databases                        :
```

This command failovers an instance link by piping an instance object.

## PARAMETERS

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

### -FailoverType
Link failover mode.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Instance link input object.

```yaml
Type: AzureSqlManagedInstanceLinkModel
Parameter Sets: FailoverByInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
Name of Azure SQL Managed Instance.

```yaml
Type: String
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
Type: AzureSqlManagedInstanceModel
Parameter Sets: FailoverByParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the instance link.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
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
Type: String
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
Type: SwitchParameter
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
