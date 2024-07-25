---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/new-azmlworkspacedatastore
schema: 2.0.0
---

# New-AzMLWorkspaceDatastore

## SYNOPSIS
Create or update datastore.

## SYNTAX

```
New-AzMLWorkspaceDatastore -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Datastore <IDatastoreProperties> [-SubscriptionId <String>] [-SkipValidation] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update datastore.

## EXAMPLES

### Example 1: Create or update datastore
```powershell
# The datastore type includes AzureBlob, AzureDataLakeGen1, AzureDataLakeGen2, AzureFile.
# You can use following command to create it then pass it as value to Datastore parameter of the New-AzMLWorkspaceDatastore cmdlet.
# New-AzMLWorkspaceDatastoreBlobObject
# New-AzMLWorkspaceDatastoreDataLakeGen1Object
# New-AzMLWorkspaceDatastoreDataLakeGen2Object
# New-AzMLWorkspaceDatastoreFileObject
# You can specify credentials when creating a datastore type. The following commands can be used to create credentials.
# New-AzMLWorkspaceDatastoreKeyCredentialObject
# New-AzMLWorkspaceDatastoreCredentialsObject
# New-AzMLWorkspaceDatastoreNoneCredentialsObject
# New-AzMLWorkspaceDatastoreSasCredentialsObject
# New-AzMLWorkspaceDatastoreServicePrincipalCredentialsObject

$accountKey = New-AzMLWorkspaceDatastoreKeyCredentialObject -Key "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
$datastoreBlob = New-AzMLWorkspaceDatastoreBlobObject -AccountName 'mmstorageeastus' -ContainerName "globaldatasets" -Endpoint "core.windows.net" -Protocol "https" -ServiceDataAccessAuthIdentity 'None' -Credentials $accountKey
New-AzMLWorkspaceDatastore -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-demo -Name blobdatastore -Datastore $datastoreBlob
```

```output
Name          SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----          -------------------  ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
blobdatastore 5/27/2022 7:15:04 AM UserName (Example)  User                    5/27/2022 7:15:05 AM     UserName (Example)       User                         ml-rg-test
```

These commands create a datastore for specified workspace.

## PARAMETERS

### -Datastore
[Required] Additional attributes of the entity.
To construct, see NOTES section for DATASTORE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDatastoreProperties
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -Name
Datastore name.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SkipValidation
Flag to skip validation.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IDatastore

## NOTES

## RELATED LINKS

