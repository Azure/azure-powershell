---
external help file:
Module Name: Az.IoTOperationsService
online version: https://learn.microsoft.com/powershell/module/az.iotoperationsservice/set-aziotoperationsservicedataflowendpoint
schema: 2.0.0
---

# Set-AzIoTOperationsServiceDataflowEndpoint

## SYNOPSIS
update a DataflowEndpointResource

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzIoTOperationsServiceDataflowEndpoint -InstanceName <String> -Name <String> -ResourceGroupName <String>
 -ExtendedLocationName <String> [-SubscriptionId <String>] [-AccessTokenSettingSecretRef <String>]
 [-DataExplorerSettingDatabase <String>] [-DataExplorerSettingHost <String>]
 [-DataExplorerSettingsAuthenticationMethod <String>]
 [-DataExplorerSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience <String>]
 [-DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId <String>]
 [-DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsScope <String>]
 [-DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId <String>]
 [-DataExplorerSettingsBatchingLatencySecond <Int32>] [-DataExplorerSettingsBatchingMaxMessage <Int32>]
 [-DataLakeStorageSettingHost <String>] [-DataLakeStorageSettingsAuthenticationMethod <String>]
 [-DataLakeStorageSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience <String>]
 [-DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId <String>]
 [-DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsScope <String>]
 [-DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId <String>]
 [-DataLakeStorageSettingsBatchingLatencySecond <Int32>] [-DataLakeStorageSettingsBatchingMaxMessage <Int32>]
 [-EndpointType <String>] [-FabricOneLakeSettingHost <String>] [-FabricOneLakeSettingOneLakePathType <String>]
 [-FabricOneLakeSettingsAuthenticationMethod <String>]
 [-FabricOneLakeSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience <String>]
 [-FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId <String>]
 [-FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsScope <String>]
 [-FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId <String>]
 [-FabricOneLakeSettingsBatchingLatencySecond <Int32>] [-FabricOneLakeSettingsBatchingMaxMessage <Int32>]
 [-KafkaSetting <IDataflowEndpointKafka>] [-LocalStorageSettingPersistentVolumeClaimRef <String>]
 [-MqttSetting <IDataflowEndpointMqtt>] [-NameLakehouseName <String>] [-NameWorkspaceName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Set-AzIoTOperationsServiceDataflowEndpoint -InstanceName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Set-AzIoTOperationsServiceDataflowEndpoint -InstanceName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
update a DataflowEndpointResource

## EXAMPLES

### UpdateExpanded (Default)
```powershell

```

Set-AzIoTOperationsServiceDataflowEndpoint -InstanceName \<String\> -Name \<String\> -ResourceGroupName \<String\>
 -ExtendedLocationName \<String\> [-SubscriptionId \<String\>] [-AccessTokenSettingSecretRef \<String\>]
 [-DataExplorerSettingDatabase \<String\>] [-DataExplorerSettingHost \<String\>]
 [-DataExplorerSettingsAuthenticationMethod \<String\>]
 [-DataExplorerSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience \<String\>]
 [-DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId \<String\>]
 [-DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsScope \<String\>]
 [-DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId \<String\>]
 [-DataExplorerSettingsBatchingLatencySecond \<Int32\>] [-DataExplorerSettingsBatchingMaxMessage \<Int32\>]
 [-DataLakeStorageSettingHost \<String\>] [-DataLakeStorageSettingsAuthenticationMethod \<String\>]
 [-DataLakeStorageSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience \<String\>]
 [-DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId \<String\>]
 [-DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsScope \<String\>]
 [-DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId \<String\>]
 [-DataLakeStorageSettingsBatchingLatencySecond \<Int32\>] [-DataLakeStorageSettingsBatchingMaxMessage \<Int32\>]
 [-EndpointType \<String\>] [-FabricOneLakeSettingHost \<String\>] [-FabricOneLakeSettingOneLakePathType \<String\>]
 [-FabricOneLakeSettingsAuthenticationMethod \<String\>]
 [-FabricOneLakeSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience \<String\>]
 [-FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId \<String\>]
 [-FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsScope \<String\>]
 [-FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId \<String\>]
 [-FabricOneLakeSettingsBatchingLatencySecond \<Int32\>] [-FabricOneLakeSettingsBatchingMaxMessage \<Int32\>]
 [-KafkaSetting \<IDataflowEndpointKafka\>] [-LocalStorageSettingPersistentVolumeClaimRef \<String\>]
 [-MqttSetting \<IDataflowEndpointMqtt\>] [-NameLakehouseName \<String\>] [-NameWorkspaceName \<String\>]
 [-DefaultProfile \<PSObject\>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [\<CommonParameters\>]
```

### UpdateViaJsonFilePath
```powershell

```

Set-AzIoTOperationsServiceDataflowEndpoint -InstanceName \<String\> -Name \<String\> -ResourceGroupName \<String\>
 -JsonFilePath \<String\> [-SubscriptionId \<String\>] [-DefaultProfile \<PSObject\>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [\<CommonParameters\>]
```

### UpdateViaJsonString
```powershell

```

Set-AzIoTOperationsServiceDataflowEndpoint -InstanceName \<String\> -Name \<String\> -ResourceGroupName \<String\>
 -JsonString \<String\> [-SubscriptionId \<String\>] [-DefaultProfile \<PSObject\>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [\<CommonParameters\>]
```

## DESCRIPTION
update a DataflowEndpointResource

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AccessTokenSettingSecretRef
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
```powershell

```

Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingDatabase
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingHost
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationMethod
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsScope
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsBatchingLatencySecond
```powershell

```

Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsBatchingMaxMessage
```powershell

```

Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingHost
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationMethod
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsScope
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsBatchingLatencySecond
```powershell

```

Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsBatchingMaxMessage
```powershell

```

Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
```powershell

```

Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointType
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingHost
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingOneLakePathType
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationMethod
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsScope
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsBatchingLatencySecond
```powershell

```

Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsBatchingMaxMessage
```powershell

```

Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceName
```powershell

```

Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
```powershell

```

Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
```powershell

```

Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KafkaSetting
```powershell

```

Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowEndpointKafka
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalStorageSettingPersistentVolumeClaimRef
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MqttSetting
```powershell

```

Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowEndpointMqtt
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
```powershell

```

Type: System.String
Parameter Sets: (All)
Aliases: DataflowEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NameLakehouseName
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NameWorkspaceName
```powershell

```

Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
```powershell

```

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
```powershell

```

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
```powershell

```

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
```powershell

```

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
```powershell

```

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
```powershell

```

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowEndpointResource
```powershell

```

## NOTES

## RELATED LINKS

## PARAMETERS

### -AccessTokenSettingSecretRef
Token secret name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

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

### -DataExplorerSettingDatabase
Database name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingHost
Host of the Azure Data Explorer in the form of \<cluster\>.\<region\>.kusto.windows.net .

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationMethod
Mode of Authentication.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience
Audience of the service to authenticate against.
Optional; defaults to the audience for Service host configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId
Client ID for the user-assigned managed identity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsScope
Resource identifier (application ID URI) of the resource, affixed with the .default suffix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId
Tenant ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsBatchingLatencySecond
Batching latency in seconds.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExplorerSettingsBatchingMaxMessage
Maximum number of messages in a batch.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingHost
Host of the Azure Data Lake in the form of \<account\>.blob.core.windows.net .

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationMethod
Mode of Authentication.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience
Audience of the service to authenticate against.
Optional; defaults to the audience for Service host configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId
Client ID for the user-assigned managed identity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsScope
Resource identifier (application ID URI) of the resource, affixed with the .default suffix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId
Tenant ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsBatchingLatencySecond
Batching latency in seconds.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataLakeStorageSettingsBatchingMaxMessage
Maximum number of messages in a batch.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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

### -EndpointType
Endpoint Type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

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

### -FabricOneLakeSettingHost
Host of the Microsoft Fabric in the form of https://\<host\>.fabric.microsoft.com.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingOneLakePathType
Type of location of the data in the workspace.
Can be either tables or files.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationMethod
Mode of Authentication.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationSystemAssignedManagedIdentitySettingsAudience
Audience of the service to authenticate against.
Optional; defaults to the audience for Service host configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsClientId
Client ID for the user-assigned managed identity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsScope
Resource identifier (application ID URI) of the resource, affixed with the .default suffix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsAuthenticationUserAssignedManagedIdentitySettingsTenantId
Tenant ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsBatchingLatencySecond
Batching latency in seconds.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricOneLakeSettingsBatchingMaxMessage
Maximum number of messages in a batch.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceName
Name of instance.

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

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KafkaSetting
Kafka endpoint.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowEndpointKafka
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocalStorageSettingPersistentVolumeClaimRef
Persistent volume claim name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MqttSetting
Broker endpoint.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowEndpointMqtt
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Instance dataflowEndpoint resource

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DataflowEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NameLakehouseName
Lakehouse name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NameWorkspaceName
Workspace name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.IoTOperationsService.Models.IDataflowEndpointResource

## NOTES

## RELATED LINKS

