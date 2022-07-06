---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# Move-AzSqlInstanceDnsAlias

## SYNOPSIS
Modifies the managed instance to which Azure SQL Managed Instance DNS Alias is pointing.

## SYNTAX

### MoveByNameAndSourceResourceIdParameterSet (Default)
```
Move-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String> [-SourceResourceId] <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByNamesParameterSet
```
Move-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String>
 [-SourceResourceGroupName] <String> [-SourceInstanceName] <String> [-SourceName] <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByNameAndSourceParentObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String> [-SourceName] <String>
 [-SourceInstanceObject] <AzureSqlManagedInstanceModel> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByNameAndSourceInputObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String>
 [-SourceInputObject] <AzureSqlManagedInstanceDnsAliasModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByParentObjectAndSourceNameParameterSet
```
Move-AzSqlInstanceDnsAlias [-InstanceObject] <AzureSqlManagedInstanceModel> [-SourceResourceGroupName] <String>
 [-SourceInstanceName] <String> [-SourceName] <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByParentObjectsParameterSet
```
Move-AzSqlInstanceDnsAlias [-InstanceObject] <AzureSqlManagedInstanceModel> [-SourceName] <String>
 [-SourceInstanceObject] <AzureSqlManagedInstanceModel> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByParentObjectAndSourceInputObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-InstanceObject] <AzureSqlManagedInstanceModel>
 [-SourceInputObject] <AzureSqlManagedInstanceDnsAliasModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveByParentObjectAndSourceResourceIdParameterSet
```
Move-AzSqlInstanceDnsAlias [-InstanceObject] <AzureSqlManagedInstanceModel> [-SourceResourceId] <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Moves an Azure SQL Managed Instance DNS Alias from a source managed instance to the target managed instance. After the operation is complete, the DNS alias will point to the target instance.

## EXAMPLES

### Example 1: Moves a managed instance DNS alias to the target managed instance
```powershell
PS C:\> Move-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <targetManagedInstanceName> -SourceResourceId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<sourceResourceGroupName>/providers/Microsoft.Sql/managedInstances/<sourceManagedInstanceName>/dnsAliases/<dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a DNS alias designated with -SourceResourceId to the target managed instance named <targetManagedInstanceName> in resource group <resourceGroupName>.

### Example 2: Moves a managed instance DNS alias with the given name, source managed instance and source resource group to the target managed instance
```powershell
PS C:\> Move-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <targetManagedInstanceName> -SourceResourceGroupName <sourceResourceGroupName> -SourceInstanceName <sourceManagedInstanceName> -SourceName <dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a managed instance DNS alias <dnsAliasName> from the source managed instance <sourceManagedInstanceName> located in resource group <sourceResourceGroupName> to the target managed instance.

### Example 3: Moves a managed instance DNS alias from a previously fetched managed instance to the target managed instance.
```powershell
PS C:\> $managedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
PS C:\> Move-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -SourceInstanceObject $managedInstance -SourceName <dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a managed instance DNS alias <dnsAliasName> from the previously source managed instance $managedInstance to the target managed instance.

### Example 4: Moves a previously fetched managed instance DNS alias to the target managed instance
```powershell
PS C:\> $managedInstanceAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName <sourceResourceGroupName> -InstanceName <sourceManagedInstanceName> -Name <dnsAliasName>
PS C:\> Move-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -SourceInputObject $managedInstanceAlias

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a previously fetched managed instance DNS alias to the target instance.

### Example 5: Moves a managed instance DNS alias with the given name, source managed instance and source resource group to a previously fetched target managed instance
```powershell
PS C:\> $targetmanagedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
PS C:\> Move-AzSqlInstanceDnsAlias -InstanceObject $targetmanagedInstance -SourceResourceGroupName <sourceResourceGroupName> -SourceInstanceName <sourceManagedInstanceName> -SourceName <dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a managed instance DNS alias <dnsAliasName> from the source managed instance <sourceManagedInstanceName> located in resource group <sourceResourceGroupName> to the previously fetched target managed instance.

### Example 6: Moves a managed instance DNS alias from a previously fetched source managed instance to a previously fetched target managed instance
```powershell
PS C:\> $targetmanagedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
PS C:\> $sourcemanagedInstance = Get-AzSqlInstance -ResourceGroupName <sourceResourceGroupName> -Name <sourceManagedInstanceName>
PS C:\> Move-AzSqlInstanceDnsAlias -InstanceObject $targetmanagedInstance -SourceInstanceObject $managedInstance -SourceName <dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a managed instance DNS alias from a previously fetched source managed instance to the previously fetched target managed instance.

### Example 7: Moves a previously fetched managed instance DNS alias to a previously fetched target managed instance
```powershell
PS C:\> $targetmanagedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
PS C:\> $managedInstanceAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName <sourceResourceGroupName> -InstanceName <sourceManagedInstanceName> -Name <dnsAliasName>
PS C:\> Move-AzSqlInstanceDnsAlias -InstanceObject $targetmanagedInstance -SourceInputObject $managedInstanceAlias

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command moves a previously fetched managed instance DNS alias to the previously fetched target managed instance.

### Example 8: Moves a managed instance DNS alias to a previously fetched target managed instance
```powershell
PS C:\> $targetmanagedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
PS C:\> Move-AzSqlInstanceDnsAlias -InstanceObject $targetmanagedInstance -SourceResourceId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<sourceResourceGroupName>/providers/Microsoft.Sql/managedInstances/<sourceManagedInstanceName>/dnsAliases/<dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
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

### -InstanceName
Name of the target managed instance.

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

### -InstanceObject
Input object of the target managed instance.

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

### -ResourceGroupName
Name of the target resource group.

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
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel
Parameter Sets: MoveByParentObjectAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 3
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
Position: 4
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
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: MoveByParentObjectsParameterSet
Aliases:

Required: True
Position: 3
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
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -SourceResourceGroupName
Name of the source resource group.

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

### -SourceResourceId
Resource ID of the source managed instance DNS alias.

```yaml
Type: System.String
Parameter Sets: MoveByNameAndSourceResourceIdParameterSet, MoveByParentObjectAndSourceResourceIdParameterSet
Aliases: Id

Required: True
Position: 3
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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel

### System.String

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
