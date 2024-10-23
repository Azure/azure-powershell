---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/remove-azprivateendpointconnection
schema: 2.0.0
---

# Remove-AzPrivateEndpointConnection

## SYNOPSIS
Removes a private endpoint connection.

## SYNTAX

### ByResourceId (Default)
```
Remove-AzPrivateEndpointConnection [-Description <String>] [-Force] [-AsJob] [-PassThru] -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResource
```
Remove-AzPrivateEndpointConnection -Name <String> [-Description <String>] [-Force] [-AsJob] [-PassThru]
 -ResourceGroupName <String> -ServiceName <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] -PrivateLinkResourceType <String> [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzPrivateEndpointConnection** cmdlet removes a private endpoint connection.

## EXAMPLES

### Example 1
```powershell
Remove-AzPrivateEndpointConnection -Name MyPrivateEndpointConnection1 -ResourceGroupName TestResourceGroup -ServiceName MyPrivateLinkServiceName -PrivateLinkResourceType Microsoft.Network/privateLinkServices
```

This example remove a private endpoint connection named MyPrivateEndpointConnection1

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -Description
The reason of action.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to delete resource

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

### -Name
The name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases: ResourceName

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

### -PrivateLinkResourceType
The private link resource type.

```yaml
Type: System.String
Parameter Sets: ByResource
Aliases:
Accepted values: Microsoft.AgFoodPlatform/farmBeats, Microsoft.ApiManagement/service, Microsoft.AppConfiguration/configurationStores, Microsoft.Attestation/attestationProviders, Microsoft.Authorization/resourceManagementPrivateLinks, Microsoft.Automation/automationAccounts, Microsoft.Batch/batchAccounts, Microsoft.Cache/Redis, Microsoft.Cache/redisEnterprise, Microsoft.CognitiveServices/accounts, Microsoft.Compute/diskAccesses, Microsoft.ContainerRegistry/registries, Microsoft.ContainerService/managedClusters, Microsoft.Databricks/workspaces, Microsoft.DataFactory/factories, Microsoft.DBforMariaDB/servers, Microsoft.DBforMySQL/servers, Microsoft.DBforPostgreSQL/servers, Microsoft.DesktopVirtualization/hostpools, Microsoft.DesktopVirtualization/workspaces, Microsoft.Devices/IotHubs, Microsoft.Devices/ProvisioningServices, Microsoft.DeviceUpdate/accounts, Microsoft.DigitalTwins/digitalTwinsInstances, Microsoft.DocumentDB/databaseAccounts, Microsoft.ElasticSan/elasticSans, Microsoft.EventGrid/topics, Microsoft.EventGrid/domains, Microsoft.EventGrid/partnerNamespaces, Microsoft.EventGrid/namespaces, Microsoft.EventHub/namespaces, Microsoft.HardwareSecurityModules/cloudHsmClusters, Microsoft.HealthcareApis/services, Microsoft.HDInsight/clusters, Microsoft.HybridCompute/privateLinkScopes, Microsoft.Insights/privateLinkScopes, Microsoft.KeyVault/vaults, Microsoft.Keyvault/managedHSMs, Microsoft.MachineLearningServices/workspaces, Microsoft.MachineLearningServices/registries, Microsoft.Media/mediaservices, Microsoft.Media/videoanalyzers, Microsoft.Migrate/assessmentProjects, Microsoft.Migrate/migrateProjects, Microsoft.Monitor/accounts, Microsoft.Network/applicationgateways, Microsoft.Network/privateLinkServices, Microsoft.OffAzure/masterSites, Microsoft.PowerBI/privateLinkServicesForPowerBI, Microsoft.Purview/accounts, Microsoft.RecoveryServices/vaults, Microsoft.Relay/namespaces, Microsoft.Search/searchServices, Microsoft.ServiceBus/namespaces, Microsoft.SignalRService/signalr, Microsoft.SignalRService/webPubSub, Microsoft.Sql/servers, Microsoft.Storage/storageAccounts, Microsoft.StorageSync/storageSyncServices, Microsoft.Synapse/privateLinkHubs, Microsoft.Synapse/workspaces, Microsoft.Web/sites, Microsoft.Web/staticSites, Microsoft.Web/hostingEnvironments, Microsoft.BotService/botServices, Microsoft.OpenEnergyPlatform/energyServices, Microsoft.DBforMySQL/flexibleServers, Microsoft.DBforPostgreSQL/flexibleServers, Microsoft.App/managedEnvironments, Microsoft.VideoIndexer/accounts

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name of the private endpoint connection.

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

### -ResourceId
The Azure resource manager id of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServiceName
The name of service that the private endpoint connection belong to.

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

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Approve-AzPrivateEndpointConnection](./Approve-AzPrivateEndpointConnection.md)

[Deny-AzPrivateEndpointConnection](./Deny-AzPrivateEndpointConnection.md)

[Get-AzPrivateEndpointConnection](./Get-AzPrivateEndpointConnection.md)

[Set-AzPrivateEndpointConnection](./Set-AzPrivateEndpointConnection.md)
