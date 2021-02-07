---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataFactoryV2.dll-Help.xml
Module Name: Az.DataFactory
online version: https://docs.microsoft.com/powershell/module/az.datafactory/get-azdatafactoryv2integrationruntime
schema: 2.0.0
---

# Get-AzDataFactoryV2IntegrationRuntime

## SYNOPSIS
Gets information about integration runtime resources.

## SYNTAX

### ByIntegrationRuntimeName (Default)
```
Get-AzDataFactoryV2IntegrationRuntime [[-Name] <String>] [-Status] [-ResourceGroupName] <String>
 [-DataFactoryName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzDataFactoryV2IntegrationRuntime [-Status] [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByIntegrationRuntimeObject
```
Get-AzDataFactoryV2IntegrationRuntime [-Status] [-InputObject] <PSIntegrationRuntime>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzDataFactoryV2IntegrationRuntime cmdlet gets information about integration runtimes in a data factory.
If you specify the name of an integration runtime, this cmdlet gets information about that integration runtime.
If you do not specify a name, this cmdlet gets information about all of the integration runtimes in a data factory.

## EXAMPLES

### Example 1: List all integration runtimes in a data factory
```
PS C:\> Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2

	ResourceGroupName DataFactoryName Name                   Description
	----------------- --------------- ----                   -----------
	rg-test-dfv2      test-df-eu2     test-reserved-ir       Reserved IR
	rg-test-dfv2      test-df-eu2     test-dedicated-ir      Reserved IR
	rg-test-dfv2      test-df-eu2     test-selfhost-ir       selfhost IR
```

List all integration runtimes in the data factory named 'test-df-eu2'.

### Example 2: Get managed dedicated integration runtime
```
PS C:\> Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2 -Name test-dedicated-ir

	Location                     : West US
	NodeSize                     : Standard_D1_v2
	NodeCount                    : 1
	MaxParallelExecutionsPerNode : 1
	CatalogServerEndpoint        : test.database.windows.net
	CatalogAdminUserName         : test
	CatalogAdminPassword         : **********
	CatalogPricingTier           : S1
	VNetId                       : 
	Subnet                       : 
	PublicIPs                    : 
	State                        : Starting
	ResourceGroupName            : rg-test-dfv2
	DataFactoryName              : test-df-eu2
	Name                         : test-dedicated-ir
	Description                  : Reserved IR
```

This command displays information about the integration runtime named 'test-dedicated-ir' in the subscription for the resource group named 'rg-test-dfv2' and data factory named 'test-df-eu2'.

### Example 3: Get managed dedicated integration runtime with detail status
```
PS C:\> Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2 -Name test-dedicated-ir -Status

	CreateTime                   : 
	Nodes                        : 
	OtherErrors                  : 
	LastOperation                : 
	State                        : Initial
	Location                     : West US
	NodeSize                     : Standard_D1_v2
	NodeCount                    : 1
	MaxParallelExecutionsPerNode : 1
	CatalogServerEndpoint        : test.database.windows.net
	CatalogAdminUserName         : test
	CatalogAdminPassword         : **********
	CatalogPricingTier           : S1
	VNetId                       : 
	Subnet                       : 
	PublicIPs                    : 
	ResourceGroupName            : rg-test-dfv2
	DataFactoryName              : test-df-eu2
	Name                         : test-dedicated-ir
	Description                  : Reserved IR
```

This command displays information about the integration runtime named 'test-dedicated-ir' in the subscription for the resource group named 'rg-test-dfv2' and data factory named 'test-df-eu2'.

### Example 4: Get self-hosted integration runtime
```
PS C:\> Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2 -Name test-selfhost-ir

	ResourceGroupName DataFactoryName Name                 Description
	----------------- --------------- ----                 -----------
	rg-test-dfv2      test-df-eu2     test-selfhost-ir     selfhost IR
```

This command displays information about the integration runtime named 'test-dedicated-ir' in the subscription for the resource group named 'rg-test-dfv2' and data factory named 'test-df-eu2'.

### Example 5: Get self-hosted integration runtime with detail status
```
PS C:\> Get-AzDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2 -Name test-selfhost-ir -Status

	State                     : Online
	Version                   : 4.2.7233.1
	CreateTime                : 9/26/2019 6:00:08 AM
	AutoUpdate                : Off
	ScheduledUpdateDate       :
	UpdateDelayOffset         : 03:00:00
	LocalTimeZoneOffset       : 08:00:00
	InternalChannelEncryption :
	Capabilities              : {[serviceBusConnected, True], [httpsPortEnabled, True], [credentialInSync, True], [connectedToResourceManager, True]...}
	ServiceUrls               : {}
	Nodes                     : {}
	Links                     : {}
	AutoUpdateETA             :
	LatestVersion             : 4.3.7265.1
	PushedVersion             : 4.3.7265.1
	TaskQueueId               : fe2d60b5-86f5-58bf-bdae-7ef698284088
	VersionStatus             : UpdateAvailable
	Name                      : test-selfhost-ir
	Type                      : SelfHosted
	ResourceGroupName         : rg-test-dfv2
	DataFactoryName           : test-df-eu2
	Description               :
	Id                        : /subscriptions/41fcbc45-c594-4152-a8f1-fcbcd6452aea/resourceGroups/rg-test-dfv2/providers/Microsoft.DataFactory/factories/test-df-eu2/integrationruntimes/test-selfhost-ir
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

### -Status
The integration runtime detail status.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSIntegrationRuntime

## OUTPUTS

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSIntegrationRuntime

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSManagedIntegrationRuntime

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSSelfHostedIntegrationRuntime

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSLinkedIntegrationRuntime

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories, copy, activities, integration runtime

## RELATED LINKS

[Set-AzDataFactoryV2IntegrationRuntime]()

[Remove-AzDataFactoryV2IntegrationRuntime]()
