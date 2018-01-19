---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version:
schema: 2.0.0
---

# Get-AzureRmEventHubOperation

## SYNOPSIS
List of Event Hubs supported Operations

## SYNTAX

```
Get-AzureRmEventHubOperation [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmEventHubOperation** cmdlet Lists the ServiceBus supported Operations.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmEventHubOperation
```

List of Event Hubs supported Operations

Name                                                                                Display
----                                                                                -------
Microsoft.EventHub/checkNamespaceAvailability/action                                Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/checkNameAvailability/action                                     Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/register/action                                                  Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/unregister/action                                                Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/write                                                 Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/read                                                  Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/operationresults/read                                 Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/Delete                                                Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/authorizationRules/read                               Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/authorizationRules/write                              Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/authorizationRules/delete                             Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/authorizationRules/listkeys/action                    Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/authorizationRules/regenerateKeys/action              Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventhubs/write                                       Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventhubs/read                                        Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventhubs/Delete                                      Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventhubs/authorizationRules/read                     Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventhubs/authorizationRules/write                    Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventhubs/authorizationRules/delete                   Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventhubs/authorizationRules/listkeys/action          Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventhubs/authorizationRules/regenerateKeys/action    Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventHubs/consumergroups/write                        Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventHubs/consumergroups/read                         Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/eventHubs/consumergroups/Delete                       Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/sku/read                                                         Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/sku/regions/read                                                 Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/operations/read                                                  Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/providers/Microsoft.Insights/metricDefinitions/read   Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/providers/Microsoft.Insights/diagnosticSettings/read  Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/providers/Microsoft.Insights/diagnosticSettings/write Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/providers/Microsoft.Insights/logDefinitions/read      Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/disasterRecoveryConfigs/write                         Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/disasterRecoveryConfigs/read                          Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/disasterRecoveryConfigs/delete                        Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/disasterRecoveryConfigs/breakPairing/action           Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/disasterRecoveryConfigs/failover/action               Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/messages/send                                         Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes
Microsoft.EventHub/namespaces/messages/receive                                      Microsoft.Azure.Commands.EventHub.Models.PSOperationDisplayAttributes

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.EventHub.Models.PSOperationAttributes, Microsoft.Azure.Commands.EventHub, Version=0.5.0.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS
