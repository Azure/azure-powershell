---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ApiManagement.dll-Help.xml
Module Name: Az.ApiManagement
ms.assetid: 022BBF5F-AFF1-45D5-9153-872779FFBAF4
online version: https://learn.microsoft.com/powershell/module/az.apimanagement/restore-azapimanagement
schema: 2.0.0
---

# Restore-AzApiManagement

## SYNOPSIS

Restores an API Management Service from the specified Azure Storage blob.

## SYNTAX

```
Restore-AzApiManagement -ResourceGroupName <String> -Name <String> [-StorageContext] <IStorageContext>
 -SourceContainerName <String> -SourceBlobName <String> [-AccessType <String>] [-IdentityClientId <String>]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

The **Restore-AzApiManagement** cmdlet restores an API Management Service from the specified backup residing in an Azure Storage blob.

## EXAMPLES

### Example 1: Restore an API Management service

```powershell
New-AzStorageAccount -StorageAccountName "ContosoStorage" -Location $location -ResourceGroupName "ContosoGroup02" -Type Standard_LRS
$storageKey = (Get-AzStorageAccountKey -ResourceGroupName "ContosoGroup02" -StorageAccountName "ContosoStorage")[0].Value
$storageContext = New-AzStorageContext -StorageAccountName "ContosoStorage" -StorageAccountKey $storageKey
Restore-AzApiManagement -ResourceGroupName "ContosoGroup" -Name "RestoredContosoApi" -StorageContext $StorageContext -SourceContainerName "ContosoBackups" -SourceBlobName "ContosoBackup.apimbackup"
```

This command restores an API Management service from Azure storage blob.

### Example 2: Restore an API Management service using Managed Identity Credentials
```powershell
$storageContext=New-AzStorageContext -StorageAccountName apimbackupmsi
$resourceGroupName="ContosoGroup02";
$apiManagementName="contosoapi";
$containerName="apimbackupcontainer";
$backupName="test-sdk-backup-1";
$msiClientId="00001111-aaaa-2222-bbbb-3333cccc4444"
Restore-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext -SourceContainerName $containerName -SourceBlobName $backupName -AccessType "UserAssignedManagedIdentity" -IdentityClientId $msiClientId -PassThru
```

```output
PublicIPAddresses                     : {52.143.79.150}
PrivateIPAddresses                    :
Id                                    : /subscriptions/4f5285a3-9fd7-40ad-91b1-d8fc3823983d/resourceGroups/ContosoGroup02/providers/Microsoft.ApiManagement/service/contosoapi
Name                                  : contosoapi
Location                              : West US 2
Sku                                   : Premium
Capacity                              : 1
CreatedTimeUtc                        : 10/13/2021 5:49:32 PM
ProvisioningState                     : Succeeded
RuntimeUrl                            : https://contosoapi.azure-api.net
RuntimeRegionalUrl                    : https://contosoapi-westus2-01.regional.azure-api.net
PortalUrl                             : https://contosoapi.portal.azure-api.net
DeveloperPortalUrl                    : https://contosoapi.developer.azure-api.net
ManagementApiUrl                      : https://contosoapi.management.azure-api.net
ScmUrl                                : https://contosoapi.scm.azure-api.net
PublisherEmail                        : foobar@microsoft.com
OrganizationName                      : fsdfsdfs
NotificationSenderEmail               : apimgmt-noreply@mail.windowsazure.com
VirtualNetwork                        :
VpnType                               : None
PortalCustomHostnameConfiguration     :
ProxyCustomHostnameConfiguration      : {contosoapi.azure-api.net}
ManagementCustomHostnameConfiguration :
ScmCustomHostnameConfiguration        :
DeveloperPortalHostnameConfiguration  :
SystemCertificates                    :
Tags                                  : {}
AdditionalRegions                     : {}
SslSetting                            : Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementSslSetting
Identity                              : Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagementServiceIdentity
EnableClientCertificate               :
Zone                                  :
DisableGateway                        : False
MinimalControlPlaneApiVersion         :
PublicIpAddressId                     :
PlatformVersion                       : stv2
PublicNetworkAccess                   : Enabled
PrivateEndpointConnections            :
ResourceGroupName                     : ContosoGroup02
```

This command restores the API Management service using the Managed Identity credentials of APIM which are allowlisted as StorageBlobContributor on the Azure Storage Account `apimbackupmsi`

## PARAMETERS

### -AccessType

The type of access to be used for the storage account. The default value is AccessKey.

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityClientId

The Client ID of user assigned managed identity. Required only if accessType is set to UserAssignedManagedIdentity.

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

Specifies the name of the API Management instance that will be restored with the backup.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru

Returns an object representing the item with which you are working.
By default, this cmdlet does not generate any output.

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

### -ResourceGroupName

Specifies the name of resource group under which API Management exists.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourceBlobName

Specifies the name of the Azure storage backup source blob.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourceContainerName

Specifies the name of the Azure storage backup source container.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageContext

Specifies the storage connection context.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement

## NOTES

## RELATED LINKS

[Backup-AzApiManagement](./Backup-AzApiManagement.md)

[Get-AzApiManagement](./Get-AzApiManagement.md)

[New-AzApiManagement](./New-AzApiManagement.md)

[Remove-AzApiManagement](./Remove-AzApiManagement.md)
