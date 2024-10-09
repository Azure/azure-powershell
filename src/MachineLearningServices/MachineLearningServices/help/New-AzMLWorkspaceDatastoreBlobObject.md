---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceDatastoreBlobObject
schema: 2.0.0
---

# New-AzMLWorkspaceDatastoreBlobObject

## SYNOPSIS
Create an in-memory object for AzureBlobDatastore.

## SYNTAX

```
New-AzMLWorkspaceDatastoreBlobObject -Credentials <IDatastoreCredentials> [-AccountName <String>]
 [-ContainerName <String>] [-Endpoint <String>] [-Protocol <String>]
 [-ServiceDataAccessAuthIdentity <ServiceDataAccessAuthIdentity>] [-Description <String>]
 [-Property <IResourceBaseProperties>] [-Tag <IResourceBaseTags>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureBlobDatastore.

## EXAMPLES

### Example 1: Create an in-memory object for AzureBlobDatastore
```powershell
New-AzMLWorkspaceDatastoreBlobObject -AccountName mlworkspace1 -ContainerName "dataset001" -Endpoint "core.windows.net" -Protocol "https" -ServiceDataAccessAuthIdentity 'None'
```

```output
DatastoreType Description IsDefault ResourceGroup SubscriptionId AccountName  ContainerName    Endpoint         Protocol ServiceDataAccessAuthIdentity
------------- ----------- --------- ------------- -------------- -----------  -------------    --------         -------- -----------------------------
AzureBlob                                                        mlworkspace1 dataset001-work2 core.windows.net https    None
```

This command creates an in-memory object for AzureBlobDatastore.

## PARAMETERS

### -AccountName
Storage account name.

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

### -ContainerName
Storage account container name.

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

### -Credentials
[Required] Account credentials.
To construct, see NOTES section for CREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDatastoreCredentials
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

### -Endpoint
Azure cloud endpoint for the storage account.

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
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
Protocol used to communicate with the storage account.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.ServiceDataAccessAuthIdentity
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
To construct, see NOTES section for TAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IResourceBaseTags
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.AzureBlobDatastore

## NOTES

## RELATED LINKS
