---
external help file: Az.Confluent-help.xml
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/update-azconfluentconnector
schema: 2.0.0
---

# Update-AzConfluentConnector

## SYNOPSIS
Update confluent connector by Name

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConfluentConnector -ClusterId <String> -EnvironmentId <String> -Name <String>
 -OrganizationName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ConnectorBasicInfoConnectorClassName <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityOrganizationExpanded
```
Update-AzConfluentConnector -ClusterId <String> -EnvironmentId <String> -Name <String>
 -OrganizationInputObject <IConfluentIdentity> [-ConnectorBasicInfoConnectorClassName <String>]
 [-ConnectorBasicInfoConnectorId <String>] [-ConnectorBasicInfoConnectorName <String>]
 [-ConnectorBasicInfoConnectorState <String>] [-ConnectorBasicInfoConnectorType <String>]
 [-ConnectorServiceTypeInfoConnectorServiceType <String>] [-PartnerConnectorInfoPartnerConnectorType <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityEnvironmentExpanded
```
Update-AzConfluentConnector -ClusterId <String> -Name <String> -EnvironmentInputObject <IConfluentIdentity>
 [-ConnectorBasicInfoConnectorClassName <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityClusterExpanded
```
Update-AzConfluentConnector -Name <String> -ClusterInputObject <IConfluentIdentity>
 [-ConnectorBasicInfoConnectorClassName <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConfluentConnector -InputObject <IConfluentIdentity> [-ConnectorBasicInfoConnectorClassName <String>]
 [-ConnectorBasicInfoConnectorId <String>] [-ConnectorBasicInfoConnectorName <String>]
 [-ConnectorBasicInfoConnectorState <String>] [-ConnectorBasicInfoConnectorType <String>]
 [-ConnectorServiceTypeInfoConnectorServiceType <String>] [-PartnerConnectorInfoPartnerConnectorType <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update confluent connector by Name

## EXAMPLES

### Example 1: Update confluent connector
```powershell
Update-AzConfluentConnector `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "conn_2" `
    -ConnectorBasicInfoConnectorClassName "AZUREBLOBSOURCE" `
    -ConnectorBasicInfoConnectorName "conn_2" `
    -ConnectorBasicInfoConnectorType "SOURCE" `
    -ConnectorServiceTypeInfoConnectorServiceType "AzureBlobStorageSourceConnector" `
    -PartnerConnectorInfoPartnerConnectorType "KafkaAzureBlobStorageSource"
```

```output
ConnectorBasicInfoConnectorClassName             : AZUREBLOBSOURCE
ConnectorBasicInfoConnectorId                : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environ
                                               ments/env-exampleenv001/clusters/lkc-examplekafka1/connectors/conn_2
ConnectorBasicInfoConnectorName              : conn_2
ConnectorBasicInfoConnectorState             : PROVISIONING
ConnectorBasicInfoConnectorType              : SOURCE
ConnectorServiceTypeInfo                     : {
                                                 "connectorServiceType": "AzureBlobStorageSinkConnector",
                                                 "storageAccountName": "examplestorageacct",
                                                 "storageAccountKey": "<base64-encoded-storage-account-key>",
                                                 "storageContainerName": "testcontainer"
                                               }
ConnectorServiceTypeInfoConnectorServiceType : AzureBlobStorageSinkConnector
Id                                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environ
                                               ments/env-exampleenv001/clusters/lkc-examplekafka1/connectors/conn_2
Name                                         : conn_2
PartnerConnectorInfo                         : {
                                                 "partnerConnectorType": "KafkaAzureBlobStorageSink",
                                                 "authType": "KAFKA_API_KEY",
                                                 "inputFormat": "AVRO",
                                                 "outputFormat": "AVRO",
                                                 "apiKey": "PL7EV4FPZK44HPG7",
                                                 "apiSecret": "<ApiSecret>",
                                                 "topics": [ "topic_1" ],
                                                 "topicsDir": "topicsDir",
                                                 "flushSize": "1000",
                                                 "maxTasks": "1",
                                                 "timeInterval": "DAILY"
                                               }
PartnerConnectorInfoPartnerConnectorType     : KafkaAzureBlobStorageSink
ResourceGroupName                            : sharedrp-confluent
SystemDataCreatedAt                          : 3/7/2026 11:57:53 AM
SystemDataCreatedBy                          : user4@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 3/7/2026 3:35:10 PM
SystemDataLastModifiedBy                     : user4@example.com
SystemDataLastModifiedByType                 : User
Type                                         : microsoft.confluent/organizations/environments/clusters/connectors
```

This command updated confluent connector

## PARAMETERS

### -ClusterId
Confluent kafka or schema registry cluster id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityOrganizationExpanded, UpdateViaIdentityEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: UpdateViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectorBasicInfoConnectorClassName
Connector Class

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

### -ConnectorBasicInfoConnectorId
Connector Id

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

### -ConnectorBasicInfoConnectorName
Connector Name

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

### -ConnectorBasicInfoConnectorState
Connector Status

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

### -ConnectorBasicInfoConnectorType
Connector Type

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

### -ConnectorServiceTypeInfoConnectorServiceType
The connector service type.

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

### -EnvironmentId
Confluent environment id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityOrganizationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: UpdateViaIdentityEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Confluent connector name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityOrganizationExpanded, UpdateViaIdentityEnvironmentExpanded, UpdateViaIdentityClusterExpanded
Aliases: ConnectorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity
Parameter Sets: UpdateViaIdentityOrganizationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Organization resource name

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

### -PartnerConnectorInfoPartnerConnectorType
The partner connector type.

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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.confluent.Models.IConnectorResource

## NOTES

## RELATED LINKS
