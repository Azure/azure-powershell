---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataFactoryV2.dll-Help.xml
Module Name: Az.DataFactory
online version: https://docs.microsoft.com/powershell/module/az.datafactory/get-azdatafactoryv2integrationruntime
schema: 2.0.0
---

# Get-AzIntegrationRuntimeOutboundNetworkDependenciesEndpoints

## SYNOPSIS
Gets outbound network dependency endpoints of the integration runtime.

## SYNTAX

### ByIntegrationRuntimeName (Default)
```
Get-AzIntegrationRuntimeOutboundNetworkDependenciesEndpoints [[-Name] <String>] [-ResourceGroupName] <String>
 [-DataFactoryName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzIntegrationRuntimeOutboundNetworkDependenciesEndpoints [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByIntegrationRuntimeObject
```
Get-AzIntegrationRuntimeOutboundNetworkDependenciesEndpoints [-InputObject] <PSIntegrationRuntime>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzDataFactoryV2IntegrationRuntimeOutboundNetwworkDependenciesEndpoints cmdlet lists outbound network dependency endpoints of a integration runtime in a data factory.

## EXAMPLES

### Example 1: List outbound network dependency
```
PS C:\> Get-AzDataFactoryV2IntegrationRuntimeOutboundNetwworkDependenciesEndpoints -ResourceId /subscriptions/522737f3-63cf-431d-807d-e126cf8ad10e/resourceGroups/wamao_test_int/providers/Microsoft.DataFactory/factories/WamaoWestUSIntDF/integrationruntimes/SSISIR

Category                                 EndPoint
--------                                 --------
Azure Data Factory (Management)          [{"DomainName":"wu.frontend.clouddatahub.net","EndpointDetails":[{"Port":443}]}]
Azure Storage (Management)               [{"DomainName":"*.blob.core.windows.net","EndpointDetails":[{"Port":443}]},{"DomainName":"*.table.core.windows.net","EndpointDetails":[{"Port":443}]}]
Event Hub (Logging)                      [{"DomainName":"*.servicebus.windows.net","EndpointDetails":[{"Port":443}]}]
```

## PARAMETERS

### -DataFactoryName
The data factory name.

```yaml
Type: System.String
Parameter Sets: ByIntegrationRuntimeName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -InputObject
The integration runtime object.

```yaml
Type: Microsoft.Azure.Commands.DataFactoryV2.Models.PSIntegrationRuntime
Parameter Sets: ByIntegrationRuntimeObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The integration runtime name.

```yaml
Type: System.String
Parameter Sets: ByIntegrationRuntimeName
Aliases: IntegrationRuntimeName

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByIntegrationRuntimeName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The Azure resource ID.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: Id

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSIntegrationRuntime

## OUTPUTS

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSIntegrationRuntimeOutboundNetworkDependenciesEndpoints

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories, copy, activities, integration runtime
