---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Get-AzureRmSqlDatabaseInstanceFailoverGroup

## SYNOPSIS
Gets or lists Azure SQL Database Instance Failover Groups.

## SYNTAX

```
Get-AzureRmSqlDatabaseInstanceFailoverGroup [[-ResourceGroupName] <String>] [-Location] <String>
 [[-Name] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets a specific Azure SQL Database Instance Failover Group or lists the Instance Failover Groups in a region under the user's subscription.

Either region in the Instance Failover Group may be used to execute the command. The returned values will reflect the state of the Managed Instances in that region with respect to the Instance Failover Group.

## EXAMPLES

### Example 1
```
PS C:\> $failoverGroups = Get-AzureRMSqlDatabaseInstanceFailoverGroup -ResourceGroupName rg -Location location
```

Lists all Failover Groups in the region

### Example 2
```
PS C:\> $failoverGroup = Get-AzureRMSqlDatabaseInstanceFailoverGroup -ResourceGroupName rg -Location location -Name fg
```

Get a specific Instance Failover Group.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The name of the Local Region from which to retrieve the Instance Failover Group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the Azure SQL Database Instance Failover Group to retrieve.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
