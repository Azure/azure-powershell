---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# Get-AzSqlInstanceDnsAlias

## SYNOPSIS
Gets one or more Azure SQL Managed Instance DNS aliases.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzSqlInstanceDnsAlias [[-Name] <String>] [-InstanceObject] <AzureSqlManagedInstanceModel>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSqlInstanceDnsAlias [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the specific Azure SQL Managed Instance DNS Alias or lists all Managed Instance DNS Aliases for the managed instance.

## EXAMPLES

### Example 1: Get a specific managed instance DNS alias
```powershell
PS C:\> Get-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command gets a specific managed instance DNS alias.

### Example 2: Lists managed instance DNS aliases for the specified managed instance
```powershell
PS C:\> Get-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command gets a list of managed instance DNS aliases.

### Example 3: Get a specific managed instance DNS alias for a previously fetched managed instance
```powershell
PS C:\> $managedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
PS C:\> Get-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name <dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       : <dnsAliasName>.xxxxxxxxxxxx.xxxxxxxx.xxxxxxx.xxx
PublicAzureDnsRecord :
```

This command gets a managed instance DNS alias by passing the instance object.

### Example 4: Get a managed instance DNS alias with the given resource ID
```powershell
PS C:\> Get-AzSqlInstanceDnsAlias -ResourceId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command gets a managed instance DNS alias by passing the resource ID of the alias.

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
Name of the managed instance.

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
Input object of the managed instance.

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

### -Name
Name of the managed instance DNS alias.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet, GetByParentObjectParameterSet
Aliases: DnsAliasName

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
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
Resource ID of the managed instance DNS alias.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel

## NOTES

## RELATED LINKS
