---
external help file: Az.Confluent-help.xml
Module Name: Az.confluent
online version: https://learn.microsoft.com/powershell/module/az.confluent/new-azconfluentconnector
schema: 2.0.0
---

# New-AzConfluentConnector

## SYNOPSIS
Create confluent connector by Name

## SYNTAX

### CreateExpanded (Default)
```
New-AzConfluentConnector -Name <String> -ClusterId <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ConnectorBasicInfoConnectorClassName <String>]
 [-ConnectorBasicInfoConnectorId <String>] [-ConnectorBasicInfoConnectorName <String>]
 [-ConnectorBasicInfoConnectorState <String>] [-ConnectorBasicInfoConnectorType <String>]
 [-ConnectorServiceTypeInfoConnectorServiceType <String>] [-PartnerConnectorInfoPartnerConnectorType <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzConfluentConnector -Name <String> -ClusterId <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzConfluentConnector -Name <String> -ClusterId <String> -EnvironmentId <String> -OrganizationName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityOrganizationExpanded
```
New-AzConfluentConnector -Name <String> -ClusterId <String> -EnvironmentId <String>
 -OrganizationInputObject <IConfluentIdentity> [-ConnectorBasicInfoConnectorClassName <String>]
 [-ConnectorBasicInfoConnectorId <String>] [-ConnectorBasicInfoConnectorName <String>]
 [-ConnectorBasicInfoConnectorState <String>] [-ConnectorBasicInfoConnectorType <String>]
 [-ConnectorServiceTypeInfoConnectorServiceType <String>] [-PartnerConnectorInfoPartnerConnectorType <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityEnvironmentExpanded
```
New-AzConfluentConnector -Name <String> -ClusterId <String> -EnvironmentInputObject <IConfluentIdentity>
 [-ConnectorBasicInfoConnectorClassName <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityClusterExpanded
```
New-AzConfluentConnector -Name <String> -ClusterInputObject <IConfluentIdentity>
 [-ConnectorBasicInfoConnectorClassName <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create confluent connector by Name

## EXAMPLES

### Example 1: Create confluent Connector
```powershell
New-AzConfluentConnector `
    -OrganizationName "sharedrp-scus-org" `
    -ResourceGroupName "sharedrp-confluent" `
    -EnvironmentId "env-exampleenv001" `
    -ClusterId "lkc-examplekafka1" `
    -Name "conn_3" `
    -JsonString '{
        "properties": {
            "connectorBasicInfo": {
                "connectorType": "SOURCE",
                "connectorClass": "AZUREBLOBSOURCE",
                "connectorName": "conn_3"
            },
            "connectorServiceTypeInfo": {
                "connectorServiceType": "AzureBlobStorageSourceConnector",
                "storageAccountName": "examplestorageacct",
                "storageAccountKey": "<base64-encoded-storage-account-key>",
                "storageContainerName": "testcontainer"
            },
            "partnerConnectorInfo": {
                "partnerConnectorType": "KafkaAzureBlobStorageSource",
                "maxTasks": "1",
                "authType": "KAFKA_API_KEY",
                "inputFormat": "AVRO",
                "outputFormat": "AVRO",
                "topicRegex": "topics:.*",
                "topicsDir": "topicsDir"
            }
        }
    }'
```

```output
ConnectorBasicInfoConnectorClassName             : AZUREBLOBSOURCE
ConnectorBasicInfoConnectorId                :
ConnectorBasicInfoConnectorName              : conn_3
ConnectorBasicInfoConnectorState             : PROVISIONING
ConnectorBasicInfoConnectorType              : SOURCE
ConnectorServiceTypeInfo                     : {
                                                 "connectorServiceType": "AzureBlobStorageSourceConnector",
                                                 "storageAccountName": "examplestorageacct",
                                                 "storageContainerName": "testcontainer"
                                               }
ConnectorServiceTypeInfoConnectorServiceType : AzureBlobStorageSourceConnector
Id                                           : /subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/sharedrp-confluent/providers/Microsoft.Confluent/organizations/sharedrp-scus-org/environ
                                               ments/env-exampleenv001/clusters/lkc-examplekafka1/connectors/conn_3
Name                                         : conn_3
PartnerConnectorInfo                         : {
                                                 "partnerConnectorType": "KafkaAzureBlobStorageSource",
                                                 "authType": "KAFKA_API_KEY",
                                                 "inputFormat": "AVRO",
                                                 "outputFormat": "AVRO",
                                                 "topicRegex": "topics:.*",
                                                 "topicsDir": "topicsDir",
                                                 "maxTasks": "1"
                                               }
PartnerConnectorInfoPartnerConnectorType     : KafkaAzureBlobStorageSource
ResourceGroupName                            : sharedrp-confluent
SystemDataCreatedAt                          : 3/7/2026 2:13:50 PM
SystemDataCreatedBy                          : user4@example.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 3/7/2026 2:16:41 PM
SystemDataLastModifiedBy                     : user4@example.com
SystemDataLastModifiedByType                 : User
Type                                         : microsoft.confluent/organizations/environments/clusters/connectors
```

This command create confluent connector

## PARAMETERS

### -ClusterId
Confluent kafka or schema registry cluster id

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded
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
Parameter Sets: CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateViaIdentityEnvironmentExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Confluent connector name

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateViaIdentityOrganizationExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityOrganizationExpanded, CreateViaIdentityEnvironmentExpanded, CreateViaIdentityClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
