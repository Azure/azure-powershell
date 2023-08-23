---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azprivatelinkresource
schema: 2.0.0
---

# Get-AzPrivateLinkResource

## SYNOPSIS
Gets a private link resource.

## SYNTAX

### ByPrivateLinkResourceId (Default)
```
Get-AzPrivateLinkResource -PrivateLinkResourceId <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResource
```
Get-AzPrivateLinkResource -ResourceGroupName <String> -ServiceName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [-PrivateLinkResourceType <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPrivateLinkResource** cmdlet retrieves all link resources belongs PrivateLinkResource.

## EXAMPLES

### Example 1
```powershell
Get-AzPrivateLinkResource -PrivateLinkResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/TestResourceGroup/providers/Microsoft.Sql/servers/mySql'
```

This example list all private link resources nbelong to sql server named mySql.

## PARAMETERS

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

### -Name
The private link resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: GroupName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrivateLinkResourceId
The Azure resource manager id of the private link resource.

```yaml
Type: System.String
Parameter Sets: ByPrivateLinkResourceId
Aliases: PrivateLinkServiceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrivateLinkResourceType
The private link resource type.

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases:
Accepted values: Microsoft.AgFoodPlatform/farmBeats, Microsoft.ApiManagement/service, Microsoft.AppConfiguration/configurationStores, Microsoft.Attestation/attestationProviders, Microsoft.Authorization/resourceManagementPrivateLinks, Microsoft.Automation/automationAccounts, Microsoft.Batch/batchAccounts, Microsoft.Cache/Redis, Microsoft.Cache/redisEnterprise, Microsoft.CognitiveServices/accounts, Microsoft.Compute/diskAccesses, Microsoft.ContainerRegistry/registries, Microsoft.ContainerService/managedClusters, Microsoft.Databricks/workspaces, Microsoft.DataFactory/factories, Microsoft.DBforMariaDB/servers, Microsoft.DBforMySQL/servers, Microsoft.DBforPostgreSQL/servers, Microsoft.DesktopVirtualization/hostpools, Microsoft.DesktopVirtualization/workspaces, Microsoft.Devices/IotHubs, Microsoft.Devices/ProvisioningServices, Microsoft.DeviceUpdate/accounts, Microsoft.DigitalTwins/digitalTwinsInstances, Microsoft.DocumentDB/databaseAccounts, Microsoft.EventGrid/topics, Microsoft.EventGrid/domains, Microsoft.EventHub/namespaces, Microsoft.HardwareSecurityModules/cloudHsmClusters, Microsoft.HealthcareApis/services, Microsoft.HDInsight/clusters, Microsoft.HybridCompute/privateLinkScopes, Microsoft.Insights/privateLinkScopes, Microsoft.KeyVault/vaults, Microsoft.Keyvault/managedHSMs, Microsoft.MachineLearningServices/workspaces, Microsoft.MachineLearningServices/registries, Microsoft.Media/mediaservices, Microsoft.Media/videoanalyzers, Microsoft.Migrate/assessmentProjects, Microsoft.Migrate/migrateProjects, Microsoft.Monitor/accounts, Microsoft.Network/applicationgateways, Microsoft.OffAzure/masterSites, Microsoft.PowerBI/privateLinkServicesForPowerBI, Microsoft.Purview/accounts, Microsoft.RecoveryServices/vaults, Microsoft.Relay/namespaces, Microsoft.Search/searchServices, Microsoft.ServiceBus/namespaces, Microsoft.SignalRService/signalr, Microsoft.SignalRService/webPubSub, Microsoft.Sql/servers, Microsoft.Storage/storageAccounts, Microsoft.StorageSync/storageSyncServices, Microsoft.Synapse/privateLinkHubs, Microsoft.Synapse/workspaces, Microsoft.Web/sites, Microsoft.Web/staticSites, Microsoft.Web/hostingEnvironments, Microsoft.BotService/botServices, Microsoft.OpenEnergyPlatform/energyServices, Microsoft.DBforMySQL/flexibleServers

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceName
The private link service name.

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
