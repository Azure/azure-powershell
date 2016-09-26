---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
online version: 
schema: 2.0.0
---

# Add-AzureRmEnvironment

## SYNOPSIS
Adds endpoints and metadata for an instance of Azure Resource Manager.

## SYNTAX

```
Add-AzureRmEnvironment [-Name] <String> [[-PublishSettingsFileUrl] <String>] [[-ServiceEndpoint] <String>]
 [[-ManagementPortalUrl] <String>] [[-StorageEndpoint] <String>] [[-ActiveDirectoryEndpoint] <String>]
 [[-ResourceManagerEndpoint] <String>] [[-GalleryEndpoint] <String>]
 [[-ActiveDirectoryServiceEndpointResourceId] <String>] [[-GraphEndpoint] <String>]
 [[-AzureKeyVaultDnsSuffix] <String>] [[-AzureKeyVaultServiceEndpointResourceId] <String>]
 [[-TrafficManagerDnsSuffix] <String>] [[-SqlDatabaseDnsSuffix] <String>]
 [-AzureDataLakeStoreFileSystemEndpointSuffix <String>]
 [-AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix <String>] [-EnableAdfsAuthentication]
 [[-AdTenant] <String>] [-GraphAudience <String>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Add-AzureRmEnvironment cmdlet adds endpoints and metadata to enable Azure Resource Manager cmdlets to connect with a new instance of Azure Resource Manager.
The built-in environments AzureCloud and AzureChinaCloud target existing public instances of Azure Resource Manager.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -ActiveDirectoryEndpoint
Specifies the base authority for Azure Active Directory authentication.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AdEndpointUrl, ActiveDirectory, ActiveDirectoryAuthority

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ActiveDirectoryServiceEndpointResourceId
Specifies the audience for tokens that authenticate requests to Azure Resource Manager or Service Management (RDFE) endpoints.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 9
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AdTenant
Specifies the default Active Directory tenant.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 16
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix
Dns Suffix of Azure Data Lake Analytics job and catalog services

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AzureDataLakeStoreFileSystemEndpointSuffix
Dns Suffix of Azure Data Lake Store FileSystem.
Example: azuredatalake.net

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AzureKeyVaultDnsSuffix
Specifies the domain name suffix for Key Vault services.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 11
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AzureKeyVaultServiceEndpointResourceId
Specifies the audience for access tokens that authorize requests for Key Vault services.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 12
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableAdfsAuthentication
Indicates that Active Directory Federation Services (ADFS) on-premise authentication is allowed.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: OnPremise

Required: False
Position: 15
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GalleryEndpoint
Specifies the endpoint for the Azure Resource Manager gallery of deployment templates.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Gallery, GalleryUrl

Required: False
Position: 8
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GraphAudience
The audience for tokens authenticating with the AD Graph Endpoint.

```yaml
Type: String
Parameter Sets: (All)
Aliases: GraphEndpointResourceId, GraphResourceId

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GraphEndpoint
Specifies the URL for Graph (Active Directory metadata) requests.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Graph, GraphUrl

Required: False
Position: 10
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ManagementPortalUrl
Specifies the URL for the Management Portal.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the environment to add.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublishSettingsFileUrl
Specifies the URL from which .publishsettings files can be downloaded.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceManagerEndpoint
Specifies the URL for Azure Resource Manager requests.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceManager, ResourceManagerUrl

Required: False
Position: 7
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceEndpoint
Specifies the endpoint for Service Management (RDFE) requests.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ServiceManagement, ServiceManagementUrl

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SqlDatabaseDnsSuffix
Specifies the domain-name suffix for Azure SQL Database servers.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 14
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -StorageEndpoint
Specifies the endpoint for storage (blob, table, queue, and file) access.

```yaml
Type: String
Parameter Sets: (All)
Aliases: StorageEndpointSuffix

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficManagerDnsSuffix
Specifies the domain-name suffix for Azure Traffic Manager services.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 13
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

###  
This cmdlet returns the set of endpoints and metadata needed to communicate with an instance of Azure.

## NOTES

## RELATED LINKS

[Get-AzureRMEnvironment]()

[Remove-AzureRMEnvironment]()

[Set-AzureRMEnvironment]()

