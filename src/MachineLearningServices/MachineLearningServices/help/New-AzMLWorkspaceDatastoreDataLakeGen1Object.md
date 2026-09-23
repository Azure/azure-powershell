---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-azmlworkspacedatastoredatalakegen1object
schema: 2.0.0
---

# New-AzMLWorkspaceDatastoreDataLakeGen1Object

## SYNOPSIS
Create an in-memory object for AzureDataLakeGen1Datastore.

## SYNTAX

```
New-AzMLWorkspaceDatastoreDataLakeGen1Object -StoreName <String> -Credentials <IDatastoreCredentials>
 [-ServiceDataAccessAuthIdentity <String>] [-ResourceGroup <String>] [-SubscriptionId <String>]
 [-Description <String>] [-Property <IResourceBaseProperties>] [-Tag <IResourceBaseTags>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureDataLakeGen1Datastore.

## EXAMPLES

### Example 1: Create an in-memory object for AzureDataLakeGen1Datastore
```powershell
New-AzMLWorkspaceDatastoreDataLakeGen1Object
```

Create an in-memory object for AzureDataLakeGen1Datastore

## PARAMETERS

### -Credentials
[Required] Account credentials.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IDatastoreCredentials
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
The asset description text.

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

### -Property
The asset property dictionary.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IResourceBaseProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
Azure Resource Group name.

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

### -ServiceDataAccessAuthIdentity
Indicates which identity to use to authenticate service data access to customer's storage.

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

### -StoreName
[Required] Azure Data Lake store name.

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

### -SubscriptionId
Azure Subscription Id.

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

### -Tag
Tag dictionary.
Tags can be added, removed, and updated.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IResourceBaseTags
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.AzureDataLakeGen1Datastore

## NOTES

## RELATED LINKS
