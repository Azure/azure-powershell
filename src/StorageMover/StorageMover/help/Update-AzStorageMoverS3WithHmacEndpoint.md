---
external help file: Az.StorageMover-help.xml
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/update-azstoragemovers3withhmacendpoint
schema: 2.0.0
---

# Update-AzStorageMoverS3WithHmacEndpoint

## SYNOPSIS
Updates properties for an S3 with HMAC endpoint resource.
Properties not specified in the request body will be unchanged.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorageMoverS3WithHmacEndpoint -Name <String> -ResourceGroupName <String>
 -StorageMoverName <String> [-SubscriptionId <String>] [-CredentialsAccessKeyUri <String>]
 [-CredentialsSecretKeyUri <String>] [-Description <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorageMoverS3WithHmacEndpoint -InputObject <IStorageMoverIdentity>
 [-CredentialsAccessKeyUri <String>] [-CredentialsSecretKeyUri <String>] [-Description <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates properties for an S3 with HMAC endpoint resource.
Properties not specified in the request body will be unchanged.

## EXAMPLES

### Example 1: Update an S3 with HMAC endpoint
```powershell
Update-AzStorageMoverS3WithHmacEndpoint -Name "myendpoint" -ResourceGroupName "myresourcegroup" -StorageMoverName "mystoragemover" -CredentialsAccessKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/accesskey2" -CredentialsSecretKeyUri "https://examples-azureKeyVault.vault.azure.net/secrets/secretkey2" -Description "Updated S3 endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.StorageMover/storageMovers/mystoragemover/endpoints/myendpoint
Name                         : myendpoint
Property                     : {
                                 "endpointType": "S3WithHMAC",
                                 "description": "Updated S3 endpoint",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultS3WithHMAC",
                                   "accessKeyUri": "https://examples-azureKeyVault.vault.azure.net/secrets/accesskey2",
                                   "secretKeyUri": "https://examples-azureKeyVault.vault.azure.net/secrets/secretkey2"
                                 },
                                 "sourceUri": "https://s3.example.com/bucket",
                                 "sourceType": "MINIO"
                               }
SystemDataCreatedAt          : 7/18/2024 4:30:50 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/18/2024 8:19:34 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command updates the credentials and description of an S3-compatible endpoint with HMAC credentials.

## PARAMETERS

### -CredentialsAccessKeyUri
The Azure Key Vault secret URI which stores the access key.

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

### -CredentialsSecretKeyUri
The Azure Key Vault secret URI which stores the secret key.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Description
A description for the endpoint.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the endpoint resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: EndpointName

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMoverName
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IEndpoint

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT `<IStorageMoverIdentity>`: Identity Parameter
  - `[AgentName <String>]`: The name of the agent resource.
  - `[EndpointName <String>]`: The name of the endpoint resource.
  - `[Id <String>]`: Resource identity path
  - `[JobDefinitionName <String>]`: The name of the job definition resource.
  - `[JobRunName <String>]`: The name of the job run.
  - `[ProjectName <String>]`: The name of the project resource.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[StorageMoverName <String>]`: The name of the Storage Mover resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS
