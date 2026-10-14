---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataMigration.dll-Help.xml
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/New-AzDataMigrationConnectionInfo
schema: 2.0.0
---

# New-AzDataMigrationConnectionInfo

## SYNOPSIS
Creates a new Connection Info object specifying the server type and name for connection.

## SYNTAX

```
New-AzDataMigrationConnectionInfo -ServerType <ServerTypeEnum> [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzDataMigrationConnectionInfo cmdlet creates new a Connection Info object specifying the server type for connection. 

## EXAMPLES

### Example 1
```powershell
New-AzDataMigrationConnectionInfo -ServerType SQL
```

The preceding example creates a new Connection Info object providing SQL as ServerType parameter.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

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
The credentials, account, tenant, and subscription used for communication with azure.

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

### -ServerType
Enum that describes server type to connect to. Currently supported values are SQL for SQL Server, Azure SQL Managed Instance, MongoDb, CosmosDb and Azure SQL Database. 

```yaml
Type: Microsoft.Azure.Commands.DataMigration.Models.ServerTypeEnum
Parameter Sets: (All)
Aliases:
Accepted values: SQL, MongoDb, SQLMI

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.DataMigration.Models.ConnectionInfo

## NOTES

## RELATED LINKS
