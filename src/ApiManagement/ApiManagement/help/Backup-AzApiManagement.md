---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ApiManagement.dll-Help.xml
Module Name: Az.ApiManagement
ms.assetid: 5846BBB7-DA8E-41B5-A894-BA2B61C2212C
online version: https://docs.microsoft.com/powershell/module/az.apimanagement/backup-azapimanagement
schema: 2.0.0
---

# Backup-AzApiManagement

## SYNOPSIS

Backs up an API Management service.

## SYNTAX

```
Backup-AzApiManagement -ResourceGroupName <String> -Name <String> -StorageContext <IStorageContext>
 -TargetContainerName <String> [-TargetBlobName <String>] [-AccessType <String>] [-IdentityClientId <String>]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

The **Backup-AzApiManagement** cmdlet backs up an instance of an Azure API Management service.
This cmdlet stores the backup as an Azure Storage blob.

## EXAMPLES

### Example 1: Back up an API Management service

```powershell
New-AzStorageAccount -StorageAccountName "ContosoStorage" -Location $location -ResourceGroupName "ContosoGroup02" -Type Standard_LRS
$storageKey = (Get-AzStorageAccountKey -ResourceGroupName "ContosoGroup02" -StorageAccountName "ContosoStorage")[0].Value
$storageContext = New-AzStorageContext -StorageAccountName "ContosoStorage" -StorageAccountKey $storageKey
Backup-AzApiManagement -ResourceGroupName "ContosoGroup02" -Name "ContosoApi" -StorageContext $StorageContext -TargetContainerName "ContosoBackups" -TargetBlobName "ContosoBackup.apimbackup"
```

### Example 2: Back up using Managed Identity

```powershell
$storageContext=New-AzStorageContext -StorageAccountName apimbackupmsi
$resourceGroupName="contosogroup2";
$apiManagementName="contosoapi";
$containerName="apimbackupcontainer";
$backupName="test-sdk-backup-1";
$msiClientId="a6270d0c-7d86-478b-8cbe-dc9047ba54f7"
Backup-AzApiManagement -ResourceGroupName $resourceGroupName -Name $apiManagementName -StorageContext $storageContext -TargetContainerName $containerName -TargetBlobName $backupName -AccessType "UserAssignedManagedIdentity" -IdentityClientId $msiClientId -PassThru
```

```output
PublicIPAddresses                     : {52.143.79.150}
PrivateIPAddresses                    :
Id                                    : /subscriptions/4f5285a3-9fd7-40ad-91b1-d8fc3823983d/resourceGroups/contosogroup2/providers/Microsoft.ApiManagement/service/contosoapi
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
ResourceGroupName                     : contosogroup2
```

This command backs up an API Management service to a Storage blob using UserAssigned Managed Identity

## PARAMETERS

### -AccessType

The type of access to be used for the storage account.

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

The credentials, account, tenant, and subscription used for communication with azure.

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

Specifies the name of the API Management deployment that this cmdlet backs up.

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

Indicates that this cmdlet returns the backed up **PsApiManagement** object, if the operation succeeds.

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

Specifies the name of the of resource group under which the API Management deployment exists.

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

Specifies a storage connection context.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetBlobName

Specifies the name of the blob for the backup.
If the blob does not exist, this cmdlet creates it.
This cmdlet generates a default value based on the following pattern:
{Name}-{yyyy-MM-dd-HH-mm}.apimbackup

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

### -TargetContainerName

Specifies the name of the container of the blob for the backup.
If the container does not exist, this cmdlet creates it.

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

### CommonParameters

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.Azure.Commands.ApiManagement.Models.PsApiManagement

## NOTES

## RELATED LINKS

[Get-AzApiManagement](./Get-AzApiManagement.md)

[New-AzApiManagement](./New-AzApiManagement.md)

[Remove-AzApiManagement](./Remove-AzApiManagement.md)

[Restore-AzApiManagement](./Restore-AzApiManagement.md)
