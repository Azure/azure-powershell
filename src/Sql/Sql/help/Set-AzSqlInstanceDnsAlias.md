---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/set-azsqlinstancednsalias
schema: 2.0.0
---

# Set-AzSqlInstanceDnsAlias

## SYNOPSIS
Sets properties for an Azure SQL Managed Instance DNS alias.

## SYNTAX

### SetByNameParameterSet (Default)
```
Set-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String> [-Name] <String>
 [-HasDnsRecord] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByParentObjectParameterSet
```
Set-AzSqlInstanceDnsAlias [-Name] <String> [-InstanceObject] <AzureSqlManagedInstanceModel> [-HasDnsRecord]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Set-AzSqlInstanceDnsAlias [-InputObject] <AzureSqlManagedInstanceDnsAliasModel> [-HasDnsRecord] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdParameterSet
```
Set-AzSqlInstanceDnsAlias [-ResourceId] <String> [-HasDnsRecord] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of Azure SQL Managed Instance DNS alias by adding or removing the DNS record.

## EXAMPLES

### Example 1: Sets a managed instance DNS alias to have DNS record
```powershell
Set-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName> -HasDnsRecord
```

```output
ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       : <dnsAliasName>.xxxxxxxxxxxx.xxxxxxxx.xxxxxxx.xxx
PublicAzureDnsRecord :
```

This command sets a managed instance DNS alias to have DNS record.

### Example 2: Sets a managed instance DNS alias with the name <dnsAliasName> on the previously fetched managed instance to have DNS record
```powershell
$managedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
Set-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name <dnsAliasName> -HasDnsRecord
```

```output
ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       : <dnsAliasName>.xxxxxxxxxxxx.xxxxxxxx.xxxxxxx.xxx
PublicAzureDnsRecord :
```

This command sets a managed instance DNS alias to have DNS record. The managed instance object is first fetched and then passed to the command.

### Example 3: Remove the DNS record from the previously created managed instance DNS alias
```powershell
#First, create a managed instance DNS alias with DNS record
$managedInstanceAlias = New-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName> -HasDnsRecord
# Remove the DNS record from the alias by not specifying the -HasDnsRecord parameter
Set-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName>
```

```output
ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command removes the DNS record from the alias which was previously created with the New-AzSqlInstanceDnsAlias command.

### Example 4: Sets a previously fetched managed instance DNS alias to have DNS record
```powershell
$managedInstanceAlias = New-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName>
Set-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName> -HasDnsRecord
```

```output
ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       : <dnsAliasName>.xxxxxxxxxxxx.xxxxxxxx.xxxxxxx.xxx
PublicAzureDnsRecord :
```

This command sets a managed instance DNS alias, which was fetched with Get-AzSqlInstanceDnsAlias, to have DNS record.

### Example 5: Sets a managed instance DNS alias, specified by a resource ID, to have DNS record
```powershell
Set-AzSqlInstanceDnsAlias -ResourceId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName> -HasDnsRecord
```

```output
ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       : <dnsAliasName>.xxxxxxxxxxxx.xxxxxxxx.xxxxxxx.xxx
PublicAzureDnsRecord :
```

This command sets a managed instance DNS alias, which is specified by a resource ID, to have DNS record.

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

### -HasDnsRecord
Parameter which indicates whether the DNS alias should have a DNS record.

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
Input object of the managed instance DNS alias.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel
Parameter Sets: SetByInputObjectParameterSet
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
Parameter Sets: SetByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceObject
Input object of the managed instance.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: SetByParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the managed instance DNS alias.

```yaml
Type: System.String
Parameter Sets: SetByNameParameterSet, SetByParentObjectParameterSet
Aliases: DnsAliasName

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
Parameter Sets: SetByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource ID of the managed instance DNS alias.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParameterSet
Aliases:

Required: True
Position: 0
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

### Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel

## NOTES

## RELATED LINKS
