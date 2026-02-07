---
external help file: Az.Confluent-help.xml
Module Name: Az.Confluent
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
 [-ConnectorBasicInfoConnectorClass <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityOrganizationExpanded
```
Update-AzConfluentConnector -ClusterId <String> -EnvironmentId <String> -Name <String>
 -OrganizationInputObject <IConfluentIdentity> [-ConnectorBasicInfoConnectorClass <String>]
 [-ConnectorBasicInfoConnectorId <String>] [-ConnectorBasicInfoConnectorName <String>]
 [-ConnectorBasicInfoConnectorState <String>] [-ConnectorBasicInfoConnectorType <String>]
 [-ConnectorServiceTypeInfoConnectorServiceType <String>] [-PartnerConnectorInfoPartnerConnectorType <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityEnvironmentExpanded
```
Update-AzConfluentConnector -ClusterId <String> -Name <String> -EnvironmentInputObject <IConfluentIdentity>
 [-ConnectorBasicInfoConnectorClass <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityClusterExpanded
```
Update-AzConfluentConnector -Name <String> -ClusterInputObject <IConfluentIdentity>
 [-ConnectorBasicInfoConnectorClass <String>] [-ConnectorBasicInfoConnectorId <String>]
 [-ConnectorBasicInfoConnectorName <String>] [-ConnectorBasicInfoConnectorState <String>]
 [-ConnectorBasicInfoConnectorType <String>] [-ConnectorServiceTypeInfoConnectorServiceType <String>]
 [-PartnerConnectorInfoPartnerConnectorType <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConfluentConnector -InputObject <IConfluentIdentity> [-ConnectorBasicInfoConnectorClass <String>]
 [-ConnectorBasicInfoConnectorId <String>] [-ConnectorBasicInfoConnectorName <String>]
 [-ConnectorBasicInfoConnectorState <String>] [-ConnectorBasicInfoConnectorType <String>]
 [-ConnectorServiceTypeInfoConnectorServiceType <String>] [-PartnerConnectorInfoPartnerConnectorType <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update confluent connector by Name

## EXAMPLES

### Example 1: Update a Confluent Connector
```powershell
Update-AzConfluentConnector -Name 'testConnSrc_1' -ResourceGroupName 'LiftrConfluent_IT' -OrganizationName 'australiaeast-resource-name' -EnvironmentId 'env-n5zmkv' -ClusterId 'lkc-1126wj' -SubscriptionId '209ad589-cefc-4b2b-8eca-a12d726494a4' -ConnectorBasicInfoConnectorState 'RUNNING'
```

This command updates a Confluent connector configuration.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
Parameter Sets: UpdateViaIdentityClusterExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConfluentIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Confluent.Models.IConnectorResource

## NOTES

## RELATED LINKS
