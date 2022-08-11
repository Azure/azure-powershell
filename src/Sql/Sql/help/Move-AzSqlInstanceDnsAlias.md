---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/move-azsqlinstancednsalias
schema: 2.0.0
---

# Move-AzSqlInstanceDnsAlias

## SYNOPSIS
Modifies the managed instance to which Azure SQL Managed Instance DNS Alias is pointing.

## SYNTAX

### MoveByNameAndSourceResourceIdParameterSet (Default)
```
Move-AzSqlInstanceDnsAlias [-DestResourceGroupName] <String> [-DestInstanceName] <String>
 [-SourceResourceId] <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### MoveByNamesParameterSet
```
Move-AzSqlInstanceDnsAlias [-DestResourceGroupName] <String> [-DestInstanceName] <String>
 [-SourceResourceGroupName] <String> [-SourceInstanceName] <String> -SourceName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByNameAndSourceParentObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-DestResourceGroupName] <String> [-DestInstanceName] <String> -SourceName <String>
 [-SourceInstanceObject] <AzureSqlManagedInstanceModel> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByNameAndSourceInputObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-DestResourceGroupName] <String> [-DestInstanceName] <String>
 [-SourceInputObject] <AzureSqlManagedInstanceDnsAliasModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByParentObjectAndSourceNameParameterSet
```
Move-AzSqlInstanceDnsAlias [-DestInstanceObject] <AzureSqlManagedInstanceModel>
 [-SourceResourceGroupName] <String> [-SourceInstanceName] <String> -SourceName <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByParentObjectsParameterSet
```
Move-AzSqlInstanceDnsAlias [-DestInstanceObject] <AzureSqlManagedInstanceModel> -SourceName <String>
 [-SourceInstanceObject] <AzureSqlManagedInstanceModel> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByParentObjectAndSourceInputObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-DestInstanceObject] <AzureSqlManagedInstanceModel>
 [-SourceInputObject] <AzureSqlManagedInstanceDnsAliasModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByParentObjectAndSourceResourceIdParameterSet
```
Move-AzSqlInstanceDnsAlias [-DestInstanceObject] <AzureSqlManagedInstanceModel> [-SourceResourceId] <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Moves an Azure SQL Managed Instance DNS Alias from a source managed instance to the target managed instance. After the operation is complete, the DNS alias will point to the target instance.

## EXAMPLES

### Example 1: Moves a managed instance DNS alias to the target managed instance
```powershell
Move-AzSqlInstanceDnsAlias -DestResourceGroupName ResourceGroup2 -DestInstanceName ManagedInstance2 -SourceResourceId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup1/providers/Microsoft.Sql/managedInstances/ManagedInstance1/dnsAliases/DnsAlias1
```

```output
ResourceGroupName    : ResourceGroup2
ManagedInstanceName  : ManagedInstance2
DnsAliasName         : DnsAlias1
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup2/providers/Microsoft.Sql/managedInstances/ManagedInstance2/dnsAliases/DnsAlias1
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a DNS alias designated with -SourceResourceId to the target managed instance named ManagedInstance2 in resource group ResourceGroup2.

### Example 2: Moves a managed instance DNS alias with the given name, source managed instance and source resource group to the target managed instance
```powershell
Move-AzSqlInstanceDnsAlias -DestResourceGroupName ResourceGroup2 -DestInstanceName ManagedInstance2 -SourceResourceGroupName ResourceGroup1 -SourceInstanceName ManagedInstance1 -SourceName DnsAlias1
```

```output
ResourceGroupName    : ResourceGroup2
ManagedInstanceName  : ManagedInstance2
DnsAliasName         : DnsAlias1
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup2/providers/Microsoft.Sql/managedInstances/ManagedInstance2/dnsAliases/DnsAlias1
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a managed instance DNS alias DnsAlias1 from the source managed instance ManagedInstance1 located in resource group ResourceGroup1 to the target managed instance.

### Example 3: Moves a managed instance DNS alias from a previously fetched managed instance to the target managed instance.
```powershell
$managedInstance = Get-AzSqlInstance -ResourceGroupName ResourceGroup2 -Name ManagedInstance2
Move-AzSqlInstanceDnsAlias -DestResourceGroupName ResourceGroup2 -DestInstanceName ManagedInstance2 -SourceInstanceObject $managedInstance -SourceName DnsAlias1
```

```output
ResourceGroupName    : ResourceGroup2
ManagedInstanceName  : ManagedInstance2
DnsAliasName         : DnsAlias1
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup2/providers/Microsoft.Sql/managedInstances/ManagedInstance2/dnsAliases/DnsAlias1
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a managed instance DNS alias DnsAlias1 from the previously source managed instance $managedInstance to the target managed instance.

### Example 4: Moves a previously fetched managed instance DNS alias to the target managed instance
```powershell
$managedInstanceAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName ResourceGroup1 -InstanceName ManagedInstance1 -Name DnsAlias1
Move-AzSqlInstanceDnsAlias -DestResourceGroupName ResourceGroup2 -DestInstanceName ManagedInstance2 -SourceInputObject $managedInstanceAlias
```

```output
ResourceGroupName    : ResourceGroup2
ManagedInstanceName  : ManagedInstance2
DnsAliasName         : DnsAlias1
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup2/providers/Microsoft.Sql/managedInstances/ManagedInstance2/dnsAliases/DnsAlias1
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a previously fetched managed instance DNS alias to the target instance.

### Example 5: Moves a managed instance DNS alias with the given name, source managed instance and source resource group to a previously fetched target managed instance
```powershell
$targetmanagedInstance = Get-AzSqlInstance -ResourceGroupName ResourceGroup2 -Name ManagedInstance2
Move-AzSqlInstanceDnsAlias -DestInstanceObject $targetmanagedInstance -SourceResourceGroupName ResourceGroup1 -SourceInstanceName ManagedInstance1 -SourceName DnsAlias1
```

```output
ResourceGroupName    : ResourceGroup2
ManagedInstanceName  : ManagedInstance2
DnsAliasName         : DnsAlias1
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup2/providers/Microsoft.Sql/managedInstances/ManagedInstance2/dnsAliases/DnsAlias1
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a managed instance DNS alias DnsAlias1 from the source managed instance ManagedInstance1 located in resource group ResourceGroup1 to the previously fetched target managed instance.

### Example 6: Moves a managed instance DNS alias from a previously fetched source managed instance to a previously fetched target managed instance
```powershell
$targetmanagedInstance = Get-AzSqlInstance -ResourceGroupName ResourceGroup2 -Name ManagedInstance2
$sourcemanagedInstance = Get-AzSqlInstance -ResourceGroupName ResourceGroup1 -Name ManagedInstance1
Move-AzSqlInstanceDnsAlias -DestInstanceObject $targetmanagedInstance -SourceInstanceObject $sourcemanagedInstance -SourceName DnsAlias1
```

```output
ResourceGroupName    : ResourceGroup2
ManagedInstanceName  : ManagedInstance2
DnsAliasName         : DnsAlias1
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup2/providers/Microsoft.Sql/managedInstances/ManagedInstance2/dnsAliases/DnsAlias1
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a managed instance DNS alias from a previously fetched source managed instance to the previously fetched target managed instance.

### Example 7: Moves a previously fetched managed instance DNS alias to a previously fetched target managed instance
```powershell
$targetmanagedInstance = Get-AzSqlInstance -ResourceGroupName ResourceGroup2 -Name ManagedInstance2
$managedInstanceAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName ResourceGroup1 -InstanceName ManagedInstance1 -Name DnsAlias1
Move-AzSqlInstanceDnsAlias -DestInstanceObject $targetmanagedInstance -SourceInputObject $managedInstanceAlias
```

```output
ResourceGroupName    : ResourceGroup2
ManagedInstanceName  : ManagedInstance2
DnsAliasName         : DnsAlias1
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup2/providers/Microsoft.Sql/managedInstances/ManagedInstance2/dnsAliases/DnsAlias1
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a previously fetched managed instance DNS alias to the previously fetched target managed instance.

### Example 8: Moves a managed instance DNS alias to a previously fetched target managed instance
```powershell
$targetmanagedInstance = Get-AzSqlInstance -ResourceGroupName ResourceGroup2 -Name ManagedInstance2
Move-AzSqlInstanceDnsAlias -DestInstanceObject $targetmanagedInstance -SourceResourceId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup1/providers/Microsoft.Sql/managedInstances/ManagedInstance1/dnsAliases/DnsAlias1
```

```output
ResourceGroupName    : ResourceGroup2
ManagedInstanceName  : ManagedInstance2
DnsAliasName         : DnsAlias1
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup2/providers/Microsoft.Sql/managedInstances/ManagedInstance2/dnsAliases/DnsAlias1
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a DNS alias designated with -SourceResourceId to the previously fetched target managed instance.

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

### -DestInstanceName
Name of the destination managed instance.

```yaml
Type: System.String
Parameter Sets: MoveByNameAndSourceResourceIdParameterSet, MoveByNamesParameterSet, MoveByNameAndSourceParentObjectParameterSet, MoveByNameAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestInstanceObject
Input object of the destination managed instance.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: MoveByParentObjectAndSourceNameParameterSet, MoveByParentObjectsParameterSet, MoveByParentObjectAndSourceInputObjectParameterSet, MoveByParentObjectAndSourceResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DestResourceGroupName
Name of the destination resource group.

```yaml
Type: System.String
Parameter Sets: MoveByNameAndSourceResourceIdParameterSet, MoveByNamesParameterSet, MoveByNameAndSourceParentObjectParameterSet, MoveByNameAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceInputObject
Input object of the source managed instance DNS alias.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel
Parameter Sets: MoveByNameAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel
Parameter Sets: MoveByParentObjectAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SourceInstanceName
Name of the source managed instance.

```yaml
Type: System.String
Parameter Sets: MoveByNamesParameterSet, MoveByParentObjectAndSourceNameParameterSet
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceInstanceObject
Input object of the source managed instance.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: MoveByNameAndSourceParentObjectParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: MoveByParentObjectsParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SourceName
Name of the source DNS alias.

```yaml
Type: System.String
Parameter Sets: MoveByNamesParameterSet, MoveByNameAndSourceParentObjectParameterSet, MoveByParentObjectAndSourceNameParameterSet, MoveByParentObjectsParameterSet
Aliases: SourceDnsAliasName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceGroupName
Name of the source resource group.

```yaml
Type: System.String
Parameter Sets: MoveByNamesParameterSet, MoveByParentObjectAndSourceNameParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceId
Resource ID of the source managed instance DNS alias.

```yaml
Type: System.String
Parameter Sets: MoveByNameAndSourceResourceIdParameterSet
Aliases: Id

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: MoveByParentObjectAndSourceResourceIdParameterSet
Aliases: Id

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel

### System.String

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS

[New-AzSqlInstanceDnsAlias](./New-AzSqlInstanceDnsAlias.md)

[Get-AzSqlInstanceDnsAlias](./Move-AzSqlInstanceDnsAlias.md)

[Set-AzSqlInstanceDnsAlias](./Set-AzSqlInstanceDnsAlias.md)

[Remove-AzSqlInstanceDnsAlias](./Remove-AzSqlInstanceDnsAlias.md)

[SQL Managed Instance DNS alias Documentation](https://aka.ms/sqlmi-dnsalias-docs)