---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-AzPurviewAzureSqlDatabaseManagedInstanceDataSourceObject
schema: 2.0.0
---

# New-AzPurviewAzureSqlDatabaseManagedInstanceDataSourceObject

## SYNOPSIS
Create an in-memory object for AzureSqlDatabaseManagedInstanceDataSource.

## SYNTAX

```
New-AzPurviewAzureSqlDatabaseManagedInstanceDataSourceObject -Kind <DataSourceType>
 [-CollectionReferenceName <String>] [-CollectionType <String>] [-Location <String>] [-ResourceGroup <String>]
 [-ResourceName <String>] [-ServerEndpoint <String>] [-SubscriptionId <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureSqlDatabaseManagedInstanceDataSource.

## EXAMPLES

### Example 1: Create Azure SQL database managed instance data source object
```powershell
New-AzPurviewAzureSqlDatabaseManagedInstanceDataSourceObject -Kind 'AzureSqlDatabaseManagedInstance' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ServerEndpoint 'tcp:sqlause.public.3b6a39.database.windows.net,3342'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AzureSqlDatabaseManagedInstance
LastModifiedAt           :
Location                 :
Name                     :
ResourceGroup            :
ResourceName             :
Scan                     :
ServerEndpoint           : tcp:sqlause.public.3b6a39.database.windows.net,3342
SubscriptionId           :
```

Create Azure SQL database managed instance data source object

## PARAMETERS

### -CollectionReferenceName

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

### -CollectionType

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

### -Kind

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.DataSourceType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup

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

### -ResourceName

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

### -ServerEndpoint

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

### -SubscriptionId

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AzureSqlDatabaseManagedInstanceDataSource

## NOTES

## RELATED LINKS
