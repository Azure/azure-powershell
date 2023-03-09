---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/set-azsqlinstancedtc
schema: 2.0.0
---

# Set-AzSqlInstanceDtc

## SYNOPSIS
Sets properties for an Azure SQL Managed Instance DTC

## SYNTAX

### SetByNameParameterSet (Default)
```
Set-AzSqlInstanceDtc [-ResourceGroupName] <String> [-InstanceName] <String> [[-DtcEnabled] <Boolean>]
 [[-ExternalDnsSuffixSearchList] <System.Collections.Generic.List`1[System.String]>]
 [-XaTransactionsEnabled <Boolean>] [-SnaLu6point2TransactionsEnabled <Boolean>]
 [-XaTransactionsDefaultTimeout <Int32>] [-XaTransactionsMaximumTimeout <Int32>]
 [-AllowInboundEnabled <Boolean>] [-AllowOutboundEnabled <Boolean>] [-Authentication <String>] [-AsJob]
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByParentObjectParameterSet
```
Set-AzSqlInstanceDtc [-InstanceObject] <AzureSqlManagedInstanceModel> [[-DtcEnabled] <Boolean>]
 [[-ExternalDnsSuffixSearchList] <System.Collections.Generic.List`1[System.String]>]
 [-XaTransactionsEnabled <Boolean>] [-SnaLu6point2TransactionsEnabled <Boolean>]
 [-XaTransactionsDefaultTimeout <Int32>] [-XaTransactionsMaximumTimeout <Int32>]
 [-AllowInboundEnabled <Boolean>] [-AllowOutboundEnabled <Boolean>] [-Authentication <String>] [-AsJob]
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Set-AzSqlInstanceDtc [-InputObject] <AzureSqlManagedInstanceDtcModel> [[-DtcEnabled] <Boolean>]
 [[-ExternalDnsSuffixSearchList] <System.Collections.Generic.List`1[System.String]>]
 [-XaTransactionsEnabled <Boolean>] [-SnaLu6point2TransactionsEnabled <Boolean>]
 [-XaTransactionsDefaultTimeout <Int32>] [-XaTransactionsMaximumTimeout <Int32>]
 [-AllowInboundEnabled <Boolean>] [-AllowOutboundEnabled <Boolean>] [-Authentication <String>] [-AsJob]
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdParameterSet
```
Set-AzSqlInstanceDtc [-ResourceId] <String> [[-DtcEnabled] <Boolean>]
 [[-ExternalDnsSuffixSearchList] <System.Collections.Generic.List`1[System.String]>]
 [-XaTransactionsEnabled <Boolean>] [-SnaLu6point2TransactionsEnabled <Boolean>]
 [-XaTransactionsDefaultTimeout <Int32>] [-XaTransactionsMaximumTimeout <Int32>]
 [-AllowInboundEnabled <Boolean>] [-AllowOutboundEnabled <Boolean>] [-Authentication <String>] [-AsJob]
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzSqlInstanceDtc** cmdlet modifies properties of an Azure SQL Managed instance DTC.

## EXAMPLES

### Example 1 Enable DTC for a managed instance
```powershell
Set-AzSqlInstanceDtc -ResourceGroupName ResourceGroup1 -InstanceName ManagedInstance1 -DtcEnabled $true
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

This command enables managed instance DTC for the managed instance ManagedInstance1.

### Example 2 Enable XA transactions for DTC
```powershell
$dtc = Set-AzSqlInstanceDtc -ResourceGroupName ResourceGroup1 -InstanceName ManagedInstance1 -XaTransactionsEnabled $true
Write-Output $dtc.SecuritySettings
```

```output
TransactionManagerCommunicationSettings : Microsoft.Azure.Management.Sql.Models.ManagedInstanceDtcTransactionManagerCommunicationSettings
XaTransactionsEnabled                   : True
SnaLu6point2TransactionsEnabled         : True
XaTransactionsDefaultTimeout            : 0
XaTransactionsMaximumTimeout            : 0
```

This command enables XA transactions for managed instance DTC

### Example 3 Enable DTC for a previously fetched managed instance
```powershell
$managedInstance = Get-AzSqlInstance -ResourceGroupName ResourceGroup1 -InstanceName ManagedInstance1
Set-AzSqlInstanceDtc -InstanceObject $managedInstance
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

This command enables managed instance DTC by passing managed instance object.

### Example 4 Enable XA transactions for a previously fetched DTC object
```powershell
$dtc = Get-AzSqlInstanceDtc -ResourceGroupName ResourceGroup1 -InstanceName ManagedInstance1
$dtc = Set-AzSqlInstanceDtc -InputObject $dtc -DtcEnabled $true
Write-Output $dtc.SecuritySettings
```

```output
TransactionManagerCommunicationSettings : Microsoft.Azure.Management.Sql.Models.ManagedInstanceDtcTransactionManagerCommunicationSettings
XaTransactionsEnabled                   : True
SnaLu6point2TransactionsEnabled         : True
XaTransactionsDefaultTimeout            : 0
XaTransactionsMaximumTimeout            : 0
```

This command enables XA transactions for DTC by passing DTC object.

### Example 5 Enable DTC with a specific resource ID
```powershell
Set-AzSqlInstanceDtc -ResourceId /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup1/providers/Microsoft.Sql/managedInstances/ManagedInstance1/dtc/current -DtcEnabled $true
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

This command enables managed instance DTC by passing the resource ID of the DTC.

## PARAMETERS

### -AllowInboundEnabled
Enable inbound traffic.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowOutboundEnabled
Enable outbound traffic.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Authentication
Authentication type.

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

### -DtcEnabled
DTC enabled status.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExternalDnsSuffixSearchList
External DNS suffix search list.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
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
Input object of the managed instance DTC.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Model.AzureSqlManagedInstanceDtcModel
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
Resource ID of the managed instance DTC.

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

### -SnaLu6point2TransactionsEnabled
SNA LU 6.2 transactions enabled status.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -XaTransactionsDefaultTimeout
XA transactions default timeout.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -XaTransactionsEnabled
XA transactions enabled status.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -XaTransactionsMaximumTimeout
XA transactions maximum timeout.

```yaml
Type: System.Nullable`1[System.Int32]
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

### Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Model.AzureSqlManagedInstanceDtcModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Model.AzureSqlManagedInstanceDtcModel

## NOTES

## RELATED LINKS

[Get-AzSqlInstanceDtc](./Get-AzSqlInstanceDtc.md)

[SQL Managed Instance DTC Documentation](https://learn.microsoft.com/en-us/azure/azure-sql/managed-instance/distributed-transaction-coordinator-dtc?view=azuresql)