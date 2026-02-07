---
external help file: Az.Confluent-help.xml
Module Name: Az.Confluent
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
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ConnectorBasicInfoConnectorClass <String>]
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
 -OrganizationInputObject <IConfluentIdentity> [-ConnectorBasicInfoConnectorClass <String>]
 [-ConnectorBasicInfoConnectorId <String>] [-ConnectorBasicInfoConnectorName <String>]
 [-ConnectorBasicInfoConnectorState <String>] [-ConnectorBasicInfoConnectorType <String>]
 [-ConnectorServiceTypeInfoConnectorServiceType <String>] [-PartnerConnectorInfoPartnerConnectorType <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityEnvironmentExpanded
```
New-AzConfluentConnector -Name <String> -ClusterId <String> -EnvironmentInputObject <IConfluentIdentity>
 [-ConnectorBasicInfoConnectorClass <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityClusterExpanded
```
New-AzConfluentConnector -Name <String> -ClusterInputObject <IConfluentIdentity>
 [-ConnectorBasicInfoConnectorClass <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create confluent connector by Name

## EXAMPLES

### Example 1: Create a new Confluent Connector
```powershell
New-AzConfluentConnector -Name 'testConnSrc_1' -ResourceGroupName 'LiftrConfluent_IT' -OrganizationName 'australiaeast-resource-name' -EnvironmentId 'env-n5zmkv' -ClusterId 'lkc-1126wj' -SubscriptionId '209ad589-cefc-4b2b-8eca-a12d726494a4' -ConnectorBasicInfoConnectorClass 'AZUREBLOBSINK' -ConnectorBasicInfoConnectorName 'testConnSrc_1' -ConnectorBasicInfoConnectorType 'SOURCE' -ConnectorServiceTypeInfoConnectorServiceType 'AzureBlobStorageSourceConnector' -PartnerConnectorInfoPartnerConnectorType 'KafkaAzureBlobStorageSource'
```

```output
ConnectorBasicInfoConnectorClass             : AZUREBLOBSINK
ConnectorBasicInfoConnectorId                : 
ConnectorBasicInfoConnectorName              : testConnSrc_1
ConnectorBasicInfoConnectorState             : PROVISIONING
ConnectorBasicInfoConnectorType              : SOURCE
ConnectorServiceTypeInfo                     : {
                                                 "connectorServiceType":
                                               "AzureBlobStorageSourceConnector"
                                               }
ConnectorServiceTypeInfoConnectorServiceType : AzureBlobStorageSourceConnector
Id                                           : /subscriptions/209ad589-cefc-4b2b-8eca-a12d726494a4/ 
                                               resourceGroups/LiftrConfluent_IT/providers/Microsoft 
                                               .Confluent/organizations/australiaeast-resource-name 
                                               /environments/env-n5zmkv/clusters/lkc-1126wj/connect 
                                               ors/testConnSrc_1
Name                                         : testConnSrc_1
PartnerConnectorInfo                         : {
                                                 "partnerConnectorType":
                                               "KafkaAzureBlobStorageSource",
                                                 "authType": "SERVICE_ACCOUNT",
                                                 "inputFormat": "AVRO",
                                                 "outputFormat": "AVRO"
                                               }
PartnerConnectorInfoPartnerConnectorType     : KafkaAzureBlobStorageSource
ResourceGroupName                            : LiftrConfluent_IT
SystemDataCreatedAt                          : 2/7/2026 6:54:18 AM
SystemDataCreatedBy                          : pgnanashekar@microsoft.com
SystemDataCreatedByType                      : User
SystemDataLastModifiedAt                     : 2/7/2026 6:54:18 AM
SystemDataLastModifiedBy                     : pgnanashekar@microsoft.com
SystemDataLastModifiedByType                 : User
Type                                         : microsoft.confluent/organizations/environments/clust 
                                               ers/connectors
```

This command creates a new Azure Blob Storage Source connector for a Confluent cluster.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
Parameter Sets: CreateViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ConnectorBasicInfoConnectorClass
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConnectorResource

## NOTES

## RELATED LINKS
