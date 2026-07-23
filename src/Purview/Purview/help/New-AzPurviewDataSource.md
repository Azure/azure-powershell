---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/az.purview/new-azpurviewdatasource
schema: 2.0.0
---

# New-AzPurviewDataSource

## SYNOPSIS
Create a data source

## SYNTAX

### Create (Default)
```
New-AzPurviewDataSource -Endpoint <String> -Name <String> -Body <IDataSource> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPurviewDataSource -Endpoint <String> -Name <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPurviewDataSource -Endpoint <String> -Name <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a data source

## EXAMPLES

### Example 1: Create a data source
```powershell
$obj = New-AzPurviewAzureStorageDataSourceObject -CollectionReferenceName parv-brs-2 -CollectionType 'CollectionReference' -Endpoint https://datascantest.blob.core.windows.net/
New-AzPurviewDataSource -Endpoint 'https://parv-brs-2.purview.azure.com/' -Name 'NewDataSource' -Body $obj
```

```output
CollectionLastModifiedAt : 2/15/2022 10:36:25 AM
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                : 2/15/2022 10:36:25 AM
Endpoint                 : https://datascantest.blob.core.windows.net/
Id                       : datasources/NewDataSource
Kind                     : AzureStorage
LastModifiedAt           : 2/15/2022 10:36:25 AM
Location                 :
Name                     : NewDataSource
ResourceGroup            :
ResourceName             :
Scan                     :
SubscriptionId           :
```

Create a data source named 'NewDataSource'

## PARAMETERS

### -Body
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IDataSource
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IDataSource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.IDataSource

## NOTES

## RELATED LINKS
