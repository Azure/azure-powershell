---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
ms.assetid: 4FCC7D8B-A46E-4E5B-8BE2-F62B3D3E715D
online version: 
schema: 2.0.0
---

# Set-AzureRmSqlServerAuditingPolicy

## SYNOPSIS
Changes the auditing policy of a SQL Database server.

## SYNTAX

```
Set-AzureRmSqlServerAuditingPolicy [-AuditType <AuditType>] [-AuditActionGroup <AuditActionGroups[]>]
 [-AuditAction <String[]>] [-PassThru] [-EventType <String[]>] [-StorageAccountName <String>]
 [-StorageKeyType <String>] [-RetentionInDays <UInt32>] [-TableIdentifier <String>] -ServerName <String>
 [-ResourceGroupName] <String> [-InformationAction <ActionPreference>] [-InformationVariable <String>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmSqlServerAuditingPolicy** cmdlet changes the auditing policy of an Azure SQL Database server.
Specify the *ResourceGroupName* and *ServerName* parameters to identify the server, the *StorageAccountName* parameter to specify the storage account for the audit logs, and the *StorageKeyType* parameter to define the storage keys to use.

You can also define retention for the audit logs table by setting the value of the *RetentionInDays* and *TableIdentifier* parameters to define the period and the seed for the audit log table names.
Specify the *EventType* parameter to define which event types to audit.
After you run this cmdlet, auditing of the databases that use the policy of this server is enabled.
If the cmdlet succeeds and you specify the *PassThru* parameter, the cmdlet returns an object that describes the current auditing policy, and the server identifiers.
Server identifiers include **ResourceGroupName** and **ServerName**.

## EXAMPLES

### Example 1: Set the auditing policy of an Azure SQL server
```
PS C:\>Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -StorageAccountName "Storage22"
```

This command sets the auditing policy of the server named Server01 to use a storage account named Storage22.

### Example 2: Set the storage account key of an existing auditing policy of an Azure SQL server
```
PS C:\>Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -StorageAccountKey Secondary
```

This command sets the auditing policy of the server named Server01 to use the secondary key.
The command does not modify the storage account name.

### Example 3: Set the auditing policy of an Azure SQL server to use a specific event type
```
PS C:\>Set-AzureRmSqlServerAuditingPolicy -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -EventType Login_Failure
```

This command sets the auditing policy of the server named Server01 to use the Login_Failure event type.
This command does not modify any other setting.

## PARAMETERS

### -AuditType
You can specify several event types.
You can specify All to audit all of the event types or None to specify that no events will be audited.
If you specify All or None at the same time, the command fails.

```yaml
Type: AuditType
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AuditActionGroup
You can specify several event types.
You can specify All to audit all of the event types or None to specify that no events will be audited.
If you specify All or None at the same time, the command fails.

```yaml
Type: AuditActionGroups[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AuditAction
You can specify several event types.
You can specify All to audit all of the event types or None to specify that no events will be audited.
If you specify All or None at the same time, the command fails.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventType
Specifies the event types to audit.
The acceptable values for this parameter are:

- PlainSQL_Success
- PlainSQL_Failure
- ParameterizedSQL_Success
- ParameterizedSQL_Failure
- StoredProcedure_Success
- StoredProcedure_Failure
- Login_Success
- Login_Failure 
- TransactionManagement_Success
- TransactionManagement_Failure
- All
- None

You can specify several event types.
You can specify All to audit all of the event types or None to specify that no events will be audited.
If you specify All or None at the same time, the command fails.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageAccountName
Specifies the name of the storage account for auditing the database.
Wildcard characters are not permitted.
If you do not specify this parameter, the cmdlet uses the storage account that was defined previously as part of the auditing policy of the database.
If this is the first time a database auditing policy is defined and you do not specify this parameter, the command fails.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageKeyType
Specifies which of the storage access keys to use.
The acceptable values for this parameter are:

- Primary
- Secondary

The default value is Primary.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RetentionInDays
Specifies the number of retention days for the audit logs table.
A value of zero (0) means that the table is not retained.
this is the default.
If you specify a value greater than zero, you must also specify a value for the *TableIdentifer* parameter.

```yaml
Type: UInt32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TableIdentifier
Specifies the name of the audit logs table.
Specify this value if you specify a value greater than zero for the *RetentionInDays* parameter.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
Specifies the name of the server that contains the database.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that contains the database.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Sql.Security.Model.ServerAuditingPolicyModel

## NOTES

## RELATED LINKS

[Get-AzureRmSqlServerAuditingPolicy](./Get-AzureRmSqlServerAuditingPolicy.md)

[Use-AzureRmSqlServerAuditingPolicy](./Use-AzureRmSqlServerAuditingPolicy.md)

[Azure SQL Database Cmdlets](./AzureRM.Sql.md)


