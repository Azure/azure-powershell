---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqlinstancedtc
schema: 2.0.0
---

# Get-AzSqlInstanceDtc

## SYNOPSIS
Gets an Azure SQL Managed Instance DTC.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzSqlInstanceDtc [-ResourceGroupName] <String> [-InstanceName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzSqlInstanceDtc [-InstanceObject] <AzureSqlManagedInstanceModel>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSqlInstanceDtc [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlInstanceDtc** cmdlet returns information about an Azure SQL Managed Instance DTC.

## EXAMPLES

### Example 1 Get the managed instance DTC
```powershell
Get-AzSqlInstanceDtc -ResourceGroupName ResourceGroup1 -InstanceName ManagedInstance1
```

```output
ResourceGroupName           : ResourceGroup1
ManagedInstanceName         : ManagedInstance1
Id                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup1/providers/Microsoft.Sql/managedInstances/ManagedInstance1/dtc/current
DtcEnabled                  : True
DtcHostNameDnsSuffix        : suffix1.net
DtcHostName                 : name1.suffix1.net
ExternalDnsSuffixSearchList : {suffix1.net}
SecuritySettings            : Microsoft.Azure.Management.Sql.Models.ManagedInstanceDtcSecuritySettings
```

This command gets the managed instance DTC of the managed instance.

### Example 2 Get the managed instance DTC of the previously fetched managed instance
```powershell
$managedInstance = Get-AzSqlInstance -ResourceGroupName ResourceGroup1 -InstanceName ManagedInstance1
Get-AzSqlInstanceDtc -InstanceObject $managedInstance
```

```output
ResourceGroupName           : ResourceGroup1
ManagedInstanceName         : ManagedInstance1
Id                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup1/providers/Microsoft.Sql/managedInstances/ManagedInstance1/dtc/current
DtcEnabled                  : True
DtcHostNameDnsSuffix        : suffix1.net
DtcHostName                 : name1.suffix1.net
ExternalDnsSuffixSearchList : {suffix1.net}
SecuritySettings            : Microsoft.Azure.Management.Sql.Models.ManagedInstanceDtcSecuritySettings
```

This command gets the managed instance DTC by passing the managed instance object.

### Example 3 Get the managed instance DTC with the specified resource ID
```powershell
Get-AzSqlInstanceDtc -ResourceId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup1/providers/Microsoft.Sql/managedInstances/ManagedInstance1/dtc/current
```

```output
ResourceGroupName           : ResourceGroup1
ManagedInstanceName         : ManagedInstance1
Id                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup1/providers/Microsoft.Sql/managedInstances/ManagedInstance1/dtc/current
DtcEnabled                  : True
DtcHostNameDnsSuffix        : suffix1.net
DtcHostName                 : name1.suffix1.net
ExternalDnsSuffixSearchList : {suffix1.net}
SecuritySettings            : Microsoft.Azure.Management.Sql.Models.ManagedInstanceDtcSecuritySettings
```

This command gets the managed instance DTC by passing the resource ID of the DTC.

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
Resource ID of the managed instance DTC.

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

### Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Model.AzureSqlManagedInstanceDtcModel

## NOTES

## RELATED LINKS

[Set-AzSqlInstanceDtc](./Set-AzSqlInstanceDtc.md)

[SQL Managed Instance DTC Documentation](https://learn.microsoft.com/en-us/azure/azure-sql/managed-instance/distributed-transaction-coordinator-dtc?view=azuresql)