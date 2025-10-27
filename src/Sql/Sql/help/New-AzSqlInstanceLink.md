---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/new-azsqlinstancelink
schema: 2.0.0
---

# New-AzSqlInstanceLink

## SYNOPSIS
Creates a new instance link.

## SYNTAX

### CreateByNameParameterSet (Default)
```
New-AzSqlInstanceLink [-ResourceGroupName] <String> [-InstanceName] <String> [-Name] <String>
 -PartnerAvailabilityGroupName <String> -InstanceAvailabilityGroupName <String> -Database <String[]>
 -PartnerEndpoint <String> [-FailoverMode <String>] [-InstanceLinkRole <String>] [-SeedingMode <String>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateByParentObjectParameterSet
```
New-AzSqlInstanceLink [-Name] <String> -PartnerAvailabilityGroupName <String>
 -InstanceAvailabilityGroupName <String> -Database <String[]> -PartnerEndpoint <String>
 [-FailoverMode <String>] [-InstanceLinkRole <String>] [-SeedingMode <String>]
 [-InstanceObject] <AzureSqlManagedInstanceModel> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSqlInstanceLink** cmdlet creates an Managed Instance link by joining distributed availability group on SQL Server based on the parameters passed.

## EXAMPLES

### Example 1: Create a new instance link
```powershell
New-AzSqlInstanceLink -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Link01" -Database "Database01" -InstanceAvailabilityGroupName "AG_Database01_MI" -PartnerAvailabilityGroupName "AG_Database01" -InstanceLinkRole "Secondary" -PartnerEndpoint "TCP://SERVER01:5022" -FailoverMode "Manual" -SeedingMode "Automatic"
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
InstanceLinkRole                 : Secondary
PartnerLinkRole                  : Primary
ReplicationMode                  : Async
FailoverMode                     : Manual
SeedingMode                      : Automatic
```

This command creates a new instance link with name "Link01".

### Example 2: Create a new instance link using an instance object
```powershell
$instance = Get-AzSqlInstance -ResourceGroupName "ResourceGroup01" -Name "ManagedInstance01"
New-AzSqlInstanceLink -InstanceObject $instance -Name "Link01" -Database "Database01" -InstanceAvailabilityGroupName "AG_Database01_MI" -PartnerAvailabilityGroupName "AG_Database01" -InstanceLinkRole "Secondary" -PartnerEndpoint "TCP://SERVER01:5022" -FailoverMode "Manual" -SeedingMode "Automatic"
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
InstanceLinkRole                 : Secondary
PartnerLinkRole                  : Primary
ReplicationMode                  : Async
FailoverMode                     : Manual
SeedingMode                      : Automatic
```

This command creates a new instance link using a managed instance object as a parameter.

### Example 3: Create a new instance link by piping an instance object
```powershell
$instance = Get-AzSqlInstance -ResourceGroupName "ResourceGroup01" -Name "ManagedInstance01"
$instance | New-AzSqlInstanceLink -Name "Link01" -Database "Database01" -InstanceAvailabilityGroupName "AG_Database01_MI" -PartnerAvailabilityGroupName "AG_Database01" -InstanceLinkRole "Secondary" -PartnerEndpoint "TCP://SERVER01:5022" -FailoverMode "Manual" -SeedingMode "Automatic"
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
InstanceLinkRole                 : Secondary
PartnerLinkRole                  : Primary
ReplicationMode                  : Async
FailoverMode                     : Manual
SeedingMode                      : Automatic
```

This command creates a new instance link by piping an instance object.

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

### -Database
Database names in the distributed availability group.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
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

### -FailoverMode
The link failover mode - can be Manual if intended to be used for two-way failover with a supported SQL Server, or None for one-way failover to Azure.

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

### -InstanceAvailabilityGroupName
Managed instance side availability group name.

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

### -InstanceLinkRole
Managed instance side link role.

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

### -InstanceName
Name of the managed instance.

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

### -InstanceObject
Instance input object.

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

### -Name
Managed Instance link name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: LinkName

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartnerAvailabilityGroupName
SQL server side availability group name.

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

### -PartnerEndpoint
SQL server side endpoint - IP or DNS resolvable name.

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

### -ResourceGroupName
Name of the resource group.

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

### -SeedingMode
Database seeding mode – can be Automatic (default), or Manual for supported scenarios.

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

[Get-AzSqlInstanceLink](./Get-AzSqlInstanceLink.md)

[Update-AzSqlInstanceLink](./Update-AzSqlInstanceLink.md)

[Remove-AzSqlInstanceLink](./Remove-AzSqlInstanceLink.md)

[Start-AzSqlInstanceLinkFailover](./Start-AzSqlInstanceLinkFailover.md)
