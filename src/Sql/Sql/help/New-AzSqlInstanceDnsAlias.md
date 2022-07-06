---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# New-AzSqlInstanceDnsAlias

## SYNOPSIS
Creates an Azure SQL Managed Instance DNS alias.

## SYNTAX

### CreateByNameParameterSet (Default)
```
New-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String> [-Name] <String>
 [-CreateDnsRecord] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateByParentObjectParameterSet
```
New-AzSqlInstanceDnsAlias [-Name] <String> [-InstanceObject] <AzureSqlManagedInstanceModel> [-CreateDnsRecord]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates new Azure SQL Managed Instance DNS Alias that is pointing to specified managed instance.

## EXAMPLES

### Example 1: Create a new managed instance DNS alias
```powershell
PS C:\> New-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command creates a new managed instance DNS alias.

### Example 2: Create a new managed instance DNS alias on previously fetched managed instance
```powershell
PS C:\> $managedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
PS C:\> New-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name <dnsAliasName>

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       :
PublicAzureDnsRecord :
```

This command creates a new managed instance DNS alias by passing the instance object.

### Example 3: Create a new managed instance DNS alias
```powershell
PS C:\> New-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName> -CreateDnsRecord

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       : <dnsAliasName>.xxxxxxxxxxxx.xxxxxxxx.xxxxxxx.xxx
PublicAzureDnsRecord :
```

This command creates a new managed instance DNS alias and creates the AzureDnsRecord.

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

### -CreateDnsRecord
Create DNS record.

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
Name of Azure SQL Managed Instance.

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
Name of the DNS alias.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: 0
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

### Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel

## NOTES

## RELATED LINKS
