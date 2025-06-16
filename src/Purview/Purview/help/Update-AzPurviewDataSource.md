---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/update-azpurviewdatasource
schema: 2.0.0
---

# Update-AzPurviewDataSource

## SYNOPSIS
Update a data source

## SYNTAX

```
Update-AzPurviewDataSource -Endpoint <String> -Name <String> [-Kind <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a data source

## EXAMPLES

### Example 1: Update a data source
```powershell
Update-AzPurviewDataSource -Endpoint 'https://parv-brs-2.purview.azure.com/' -Name 'NewDataSource' -Kind SqlServerDatabase
```

```output
CollectionLastModifiedAt : 2/15/2022 10:36:25 AM
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                : 2/15/2022 10:36:25 AM
Endpoint                 : https://datascantest.blob.core.windows.net/
Id                       : datasources/NewDataSource
Kind                     : SqlServerDatabase
LastModifiedAt           : 2/15/2022 10:36:25 AM
Location                 :
Name                     : NewDataSource
ResourceGroup            :
ResourceName             :
Scan                     :
SubscriptionId           :
```

Update a data source

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The scanning endpoint of your purview account.
Example: https://{accountName}.purview.azure.com

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
.

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

### -Name
.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DataSourceName

Required: True
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IDataSource

## NOTES

## RELATED LINKS
