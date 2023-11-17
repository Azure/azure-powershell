---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceDatastoreFileObject
schema: 2.0.0
---

# New-AzMLWorkspaceDatastoreFileObject

## SYNOPSIS
Create an in-memory object for AzureFileDatastore.

## SYNTAX

```
New-AzMLWorkspaceDatastoreFileObject -AccountName <String> -FileShareName <String> [-Description <String>]
 [-Endpoint <String>] [-Property <IResourceBaseProperties>] [-Protocol <String>]
 [-ServiceDataAccessAuthIdentity <ServiceDataAccessAuthIdentity>] [-Tag <IResourceBaseTags>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureFileDatastore.

## EXAMPLES

### Example 1: Create an in-memory object for AzureFileDatastore
```powershell
New-AzMLWorkspaceDatastoreFileObject
```

Create an in-memory object for AzureFileDatastore

## PARAMETERS

### -AccountName
[Required] Storage account name.

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

### -FileShareName
[Required] The name of the Azure file share that the datastore points to.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.AzureFileDatastore

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PROPERTY <IResourceBaseProperties>`: The asset property dictionary.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

`TAG <IResourceBaseTags>`: Tag dictionary. Tags can be added, removed, and updated.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

