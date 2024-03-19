---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://learn.microsoft.com/powershell/module/az.accounts/get-azenvironment
schema: 2.0.0
---

# Get-AzEnvironment

## SYNOPSIS
Get endpoints and metadata for an instance of Azure services.
`GalleryUrl` will be removed from ArmMetadata and so Azure PowerShell will no longer provide for its value in `PSAzureEnvironment`. Currently `GalleryUrl` is not used in Azure PowerShell products. Please do not reply on `GalleryUrl` anymore. 

## SYNTAX

```
Get-AzEnvironment [[-Name] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzEnvironment cmdlet gets endpoints and metadata for an instance of Azure services.

## EXAMPLES

### Example 1: Getting all Azure environments
```powershell
Get-AzEnvironment
```

```Output
Name              Resource Manager Url                  ActiveDirectory Authority          Type
----              --------------------                  -------------------------          ----
AzureUSGovernment https://management.usgovcloudapi.net/ https://login.microsoftonline.us/  Built-in
AzureCloud        https://management.azure.com/         https://login.microsoftonline.com/ Built-in
AzureChinaCloud   https://management.chinacloudapi.cn/  https://login.chinacloudapi.cn/    Built-in
```

This example shows how to get the endpoints and metadata for the AzureCloud (default) environment.

### Example 2: Getting the AzureCloud environment
```powershell
Get-AzEnvironment -Name AzureCloud
```

```Output
Name       Resource Manager Url          ActiveDirectory Authority          Type
----       --------------------          -------------------------          ----
AzureCloud https://management.azure.com/ https://login.microsoftonline.com/ Built-in
```

This example shows how to get the endpoints and metadata for the AzureCloud (default) environment.

### Example 3: Getting the AzureChinaCloud environment
```powershell
Get-AzEnvironment -Name AzureChinaCloud | Format-List
```

```Output
Name                                              : AzureChinaCloud
Type                                              : Built-in
EnableAdfsAuthentication                          : False
OnPremise                                         : False
ActiveDirectoryServiceEndpointResourceId          : https://management.core.chinacloudapi.cn/
AdTenant                                          : Common
GalleryUrl                                        : https://gallery.azure.com/
ManagementPortalUrl                               : https://go.microsoft.com/fwlink/?LinkId=301902
ServiceManagementUrl                              : https://management.core.chinacloudapi.cn/
PublishSettingsFileUrl                            : https://go.microsoft.com/fwlink/?LinkID=301776
ResourceManagerUrl                                : https://management.chinacloudapi.cn/
SqlDatabaseDnsSuffix                              : .database.chinacloudapi.cn
StorageEndpointSuffix                             : core.chinacloudapi.cn
ActiveDirectoryAuthority                          : https://login.chinacloudapi.cn/
GraphUrl                                          : https://graph.chinacloudapi.cn/
GraphEndpointResourceId                           : https://graph.chinacloudapi.cn/
TrafficManagerDnsSuffix                           : trafficmanager.cn
AzureKeyVaultDnsSuffix                            : vault.azure.cn
DataLakeEndpointResourceId                        : 
AzureDataLakeStoreFileSystemEndpointSuffix        : 
AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix : 
AzureKeyVaultServiceEndpointResourceId            : https://vault.azure.cn
ContainerRegistryEndpointSuffix                   : azurecr.cn
AzureOperationalInsightsEndpointResourceId        : 
AzureOperationalInsightsEndpoint                  : 
AzureAnalysisServicesEndpointSuffix               : asazure.chinacloudapi.cn
AnalysisServicesEndpointResourceId                : https://region.asazure.chinacloudapi.cn
AzureAttestationServiceEndpointSuffix             : 
AzureAttestationServiceEndpointResourceId         : 
AzureSynapseAnalyticsEndpointSuffix               : dev.azuresynapse.azure.cn
AzureSynapseAnalyticsEndpointResourceId           : https://dev.azuresynapse.azure.cn
```

This example shows how to get the endpoints and metadata for the AzureChinaCloud environment.

### Example 4: Getting the AzureUSGovernment environment
```powershell
Get-AzEnvironment -Name AzureUSGovernment
```

```Output
Name              Resource Manager Url                  ActiveDirectory Authority         Type
----              --------------------                  -------------------------         ----
AzureUSGovernment https://management.usgovcloudapi.net/ https://login.microsoftonline.us/ Built-in
```

This example shows how to get the endpoints and metadata for the AzureUSGovernment environment.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant and subscription used for communication with azure.

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

### -Name
Specifies the name of the Azure instance to get.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSAzureEnvironment

## NOTES

## RELATED LINKS

[Add-AzEnvironment](./Add-AzEnvironment.md)

[Remove-AzEnvironment](./Remove-AzEnvironment.md)

[Set-AzEnvironment](./Set-AzEnvironment.md)

