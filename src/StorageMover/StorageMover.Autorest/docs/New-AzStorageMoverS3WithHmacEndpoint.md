---
external help file:
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/new-azstoragemovers3withhmacendpoint
schema: 2.0.0
---

# New-AzStorageMoverS3WithHmacEndpoint

## SYNOPSIS
Creates an S3WithHMAC endpoint resource, which represents a data transfer source.

## SYNTAX

```
New-AzStorageMoverS3WithHmacEndpoint -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 -SourceUri <String> -SourceType <String> [-SubscriptionId <String>] [-CredentialsAccessKeyUri <String>]
 [-CredentialsSecretKeyUri <String>] [-OtherSourceTypeDescription <String>] [-Description <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates an S3WithHMAC endpoint resource, which represents a data transfer source.
This endpoint type supports S3-compatible storage services such as MinIO, IBM Cloud Object Storage, Google Cloud Storage, Alibaba Cloud OSS, Dell EMC ECS, and other S3-compatible services.

## EXAMPLES

### Example 1: Create an S3WithHMAC endpoint
```powershell
New-AzStorageMoverS3WithHmacEndpoint -Name "myS3Endpoint" -ResourceGroupName "myResourceGroup" -StorageMoverName "myStorageMover" -SourceUri "https://s3.example.com/bucket" -SourceType "MINIO" -CredentialsAccessKeyUri "https://myKeyVault.vault.azure.net/secrets/accessKey" -CredentialsSecretKeyUri "https://myKeyVault.vault.azure.net/secrets/secretKey" -Description "My S3 endpoint"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myS3Endpoint
Name                         : myS3Endpoint
Property                     : {
                                 "endpointType": "S3WithHMAC",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultS3WithHMAC",
                                   "accessKeyUri": "https://myKeyVault.vault.azure.net/secrets/accessKey",
                                   "secretKeyUri": "https://myKeyVault.vault.azure.net/secrets/secretKey"
                                 },
                                 "sourceUri": "https://s3.example.com/bucket",
                                 "sourceType": "MINIO"
                               }
SystemDataCreatedAt          : 7/1/2023 4:30:50 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/1/2023 4:30:50 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates an S3WithHMAC endpoint with MinIO as the source type.

### Example 2: Create an S3WithHMAC endpoint with OTHER source type
```powershell
New-AzStorageMoverS3WithHmacEndpoint -Name "myOtherS3Endpoint" -ResourceGroupName "myResourceGroup" -StorageMoverName "myStorageMover" -SourceUri "https://s3.custom.com/bucket" -SourceType "OTHER" -OtherSourceTypeDescription "Custom S3-compatible storage" -CredentialsAccessKeyUri "https://myKeyVault.vault.azure.net/secrets/accessKey" -CredentialsSecretKeyUri "https://myKeyVault.vault.azure.net/secrets/secretKey"
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.StorageMover/storageMovers/myStorageMover/endpoints/myOtherS3Endpoint
Name                         : myOtherS3Endpoint
Property                     : {
                                 "endpointType": "S3WithHMAC",
                                 "provisioningState": "Succeeded",
                                 "credentials": {
                                   "type": "AzureKeyVaultS3WithHMAC",
                                   "accessKeyUri": "https://myKeyVault.vault.azure.net/secrets/accessKey",
                                   "secretKeyUri": "https://myKeyVault.vault.azure.net/secrets/secretKey"
                                 },
                                 "sourceUri": "https://s3.custom.com/bucket",
                                 "sourceType": "OTHER",
                                 "otherSourceTypeDescription": "Custom S3-compatible storage"
                               }
SystemDataCreatedAt          : 7/1/2023 4:30:50 AM
SystemDataCreatedBy          : 00000000-0000-0000-0000-000000000000
SystemDataCreatedByType      : Application
SystemDataLastModifiedAt     : 7/1/2023 4:30:50 AM
SystemDataLastModifiedBy     : 00000000-0000-0000-0000-000000000000
SystemDataLastModifiedByType : Application
Type                         : microsoft.storagemover/storagemovers/endpoints
```

This command creates an S3WithHMAC endpoint with a custom S3-compatible source type.

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

### -Name
The name of the endpoint resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OtherSourceTypeDescription
The description for other source type.
Required when SourceType is OTHER.

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

### -SourceType
The source type of the S3 compatible endpoint.
Valid values: MINIO, IBM, GCS, ALIBABA, DELL_EMC, OTHER.

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

### -SourceUri
The URI which points to the S3 compatible source.

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

### -StorageMoverName
The name of the Storage Mover resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IEndpoint

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IEndpoint

## NOTES

## RELATED LINKS
