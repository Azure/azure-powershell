---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# Remove-AzSqlInstanceDnsAlias

## SYNOPSIS
Removes an Azure SQL Managed Instance DNS alias.

## SYNTAX

### DeleteByNameParameterSet (Default)
```
Remove-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String> [-Name] <String> [-Force]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteByParentObjectParameterSet
```
Remove-AzSqlInstanceDnsAlias [-Name] <String> [-InstanceObject] <AzureSqlManagedInstanceModel> [-Force]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteByInputObjectParameterSet
```
Remove-AzSqlInstanceDnsAlias [-InputObject] <AzureSqlManagedInstanceDnsAliasModel> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteByResourceIdParameterSet
```
Remove-AzSqlInstanceDnsAlias [-ResourceId] <String> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Removes a specific Azure SQL Managed Instance DNS Alias.

## EXAMPLES

### Example 1: Removes a managed instance DNS alias
```powershell
PS C:\> Remove-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName>
```

This command removes the specified managed instance DNS alias.

### Example 2: Removes a managed instance DNS alias and displays the removed DNS alias
```powershell
PS C:\> Remove-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName> -PassThru

ResourceGroupName    : <rgName>
ManagedInstanceName  : <managedInstanceName>
DnsAliasName         : <dnsAliasName>
Id                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
AzureDnsRecord       : <dnsAliasName>.xxxxxxxxxxxx.xxxxxxxx.xxxxxxx.xxx
PublicAzureDnsRecord :
```

This command removes the specified managed instance DNS alias.

### Example 3: Removes a managed instance DNS alias for a previously fetched managed instance
```powershell
PS C:\> $managedInstance = Get-AzSqlInstance -ResourceGroupName <resourceGroupName> -Name <managedInstanceName>
PS C:\> Remove-AzSqlInstanceDnsAlias -InstanceObject $managedInstance -Name <dnsAliasName>
```

This command removes a managed instance DNS alias from a previously fetched managed instance.

### Example 4: Removes a previously fetched managed instance DNS alias
```powershell
PS C:\> $managedInstanceAlias = Get-AzSqlInstanceDnsAlias -ResourceGroupName <resourceGroupName> -InstanceName <managedInstanceName> -Name <dnsAliasName>
PS C:\> Remove-AzSqlInstanceDnsAlias -InputObject $managedInstanceAlias
```

This command removes a previously fetched managed instance DNS alias.

### Example 5: Removes a managed instance DNS alias with the given resource ID
```powershell
PS C:\> Remove-AzSqlInstanceDnsAlias /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/<resourceGroupName>/providers/Microsoft.Sql/managedInstances/<managedInstanceName>/dnsAliases/<dnsAliasName>
```

This command removes a managed instance DNS alias by passing the resource ID of the alias.

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

### -Force
Skip confirmation message for performing the action.

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
Parameter Sets: DeleteByInputObjectParameterSet
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
Parameter Sets: DeleteByNameParameterSet
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
Parameter Sets: DeleteByParentObjectParameterSet
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
Parameter Sets: DeleteByNameParameterSet, DeleteByParentObjectParameterSet
Aliases: DnsAliasName

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Displays the removed DNS alias.

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

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: DeleteByNameParameterSet
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
Parameter Sets: DeleteByResourceIdParameterSet
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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel

### System.String

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
