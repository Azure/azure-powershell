---
external help file:
Module Name: Az.MachineLearningServices
online version: https://docs.microsoft.com/powershell/module/az.MLWorkspace/new-AzMLWorkspaceDatastoreDataLakeGen1Object
schema: 2.0.0
---

# New-AzMLWorkspaceDatastoreDataLakeGen1Object

## SYNOPSIS
Create an in-memory object for AzureDataLakeGen1Datastore.

## SYNTAX

```
New-AzMLWorkspaceDatastoreDataLakeGen1Object -Credentials <IDatastoreCredentials> -StoreName <String>
 [-Description <String>] [-Property <IResourceBaseProperties>]
 [-ServiceDataAccessAuthIdentity <ServiceDataAccessAuthIdentity>] [-Tag <IResourceBaseTags>]
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
To construct, see NOTES section for CREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IDatastoreCredentials
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
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IResourceBaseProperties
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

### -Tag
Tag dictionary.
Tags can be added, removed, and updated.
To construct, see NOTES section for TAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IResourceBaseTags
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.AzureDataLakeGen1Datastore

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CREDENTIALS `<IDatastoreCredentials>`: [Required] Account credentials.
  - `CredentialsType <CredentialsType>`: [Required] Credential type used to authentication with storage.

PROPERTY `<IResourceBaseProperties>`: The asset property dictionary.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

TAG `<IResourceBaseTags>`: Tag dictionary. Tags can be added, removed, and updated.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

