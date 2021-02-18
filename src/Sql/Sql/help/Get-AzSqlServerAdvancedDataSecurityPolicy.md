---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.sql/get-azsqlserveradvanceddatasecuritypolicy
=======
online version: https://docs.microsoft.com/powershell/module/az.sql/get-azsqlserveradvanceddatasecuritypolicy
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Get-AzSqlServerAdvancedDataSecurityPolicy

## SYNOPSIS
Gets Advanced Data Security policy of a server.

## SYNTAX

```
Get-AzSqlServerAdvancedDataSecurityPolicy [-InputObject <AzureSqlServerModel>] -ServerName <String>
 [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
<<<<<<< HEAD
The **Get-AzSqlServerAdvancedDataSecurityPolicy** cmdlet retrives the Advanced Data Security policy of a server.

## EXAMPLES

### Example 1 - Gets server Advanced Data Security
```powershell
PS C:\>  Get-AzSqlServerAdvancedDataSecuritynPolicy `
=======
The **Get-AzSqlServerAdvancedDataSecurityPolicy** cmdlet retrieves the Advanced Data Security policy of a server.

## EXAMPLES

### Example 1: Gets server Advanced Data Security
```powershell
PS C:\>  Get-AzSqlServerAdvancedDataSecurityPolicy `
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            -ResourceGroupName "ResourceGroup01" `
            -ServerName "Server01" 

ResourceGroupName	         : ResourceGroup01
ServerName		             : Server01
IsEnabled		             : True
```

<<<<<<< HEAD
### Example 2 - Gets server Advanced Data Security from server resource
=======
### Example 2: Gets server Advanced Data Security from server resource
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
```powershell
PS C:\>  Get-AzSqlServer `
           -ResourceGroupName "ResourceGroup01" `
           -ServerName "Server01" `
           | Get-AzSqlServerAdvancedDataSecurityPolicy

ResourceGroupName	         : ResourceGroup01
ServerName		             : Server01
IsEnabled		             : True
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
<<<<<<< HEAD
Type: IAzureContextContainer
=======
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The server object to use with Advanced Data Security policy operation

```yaml
<<<<<<< HEAD
Type: AzureSqlServerModel
=======
Type: Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
<<<<<<< HEAD
Type: String
=======
Type: System.String
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
SQL Database server name.

```yaml
<<<<<<< HEAD
Type: String
=======
Type: System.String
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### Microsoft.Azure.Commands.Sql.Server.Model.AzureSqlServerModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model.ServerAdvancedDataSecurityPolicyModel

## NOTES

## RELATED LINKS
