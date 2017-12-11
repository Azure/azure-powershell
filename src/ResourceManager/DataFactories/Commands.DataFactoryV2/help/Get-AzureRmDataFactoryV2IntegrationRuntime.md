---
external help file: Microsoft.Azure.Commands.DataFactoryV2.dll-Help.xml
Module Name: AzureRM.DataFactoryV2
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datafactories/get-azurermdatafactoryv2integrationruntime
schema: 2.0.0
---

# Get-AzureRmDataFactoryV2IntegrationRuntime

## SYNOPSIS
Gets information about integration runtime resources.

## SYNTAX

### ByIntegrationRuntimeName (Default)
```
Get-AzureRmDataFactoryV2IntegrationRuntime [[-Name] <String>] [-Status] [-ResourceGroupName] <String>
 [-DataFactoryName] <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzureRmDataFactoryV2IntegrationRuntime [-Status] [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByIntegrationRuntimeObject
```
Get-AzureRmDataFactoryV2IntegrationRuntime [-Status] [-InputObject] <PSIntegrationRuntime>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmDataFactoryV2IntegrationRuntime cmdlet gets information about integration runtimes in a data factory.
If you specify the name of an integration runtime, this cmdlet gets information about that integration runtime.
If you do not specify a name, this cmdlet gets information about all of the integration runtimes in a data factory.

## EXAMPLES

### Example 1: List all integration runtimes in a data factory
```
PS C:\> Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2

	ResourceGroupName DataFactoryName Name                   Description
	----------------- --------------- ----                   -----------
	rg-test-dfv2      test-df-eu2     test-reserved-ir       Reserved IR
	rg-test-dfv2      test-df-eu2     test-dedicated-ir      Reserved IR
	rg-test-dfv2      test-df-eu2     test-selfhost-ir       selfhost IR
```

List all integration runtimes in the data factory named 'test-df-eu2'.

### Example 2: Get managed dedicated integration runtime
```
PS C:\> Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2 -Name test-dedicated-ir

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
	State                        : Starting
	ResourceGroupName            : rg-test-dfv2
	DataFactoryName              : test-df-eu2
	Name                         : test-dedicated-ir
	Description                  : Reserved IR
```

This command displays information about the integration runtime named 'test-dedicated-ir' in the subscription for the resource group named 'rg-test-dfv2' and data factory named 'test-df-eu2'.

### Example 3: Get managed dedicated integration runtime with detail status
```
PS C:\> Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2 -Name test-dedicated-ir -Status

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
	ResourceGroupName            : rg-test-dfv2
	DataFactoryName              : test-df-eu2
	Name                         : test-dedicated-ir
	Description                  : Reserved IR
```

This command displays information about the integration runtime named 'test-dedicated-ir' in the subscription for the resource group named 'rg-test-dfv2' and data factory named 'test-df-eu2'.

### Example 4: Get self-hosted integration runtime
```
PS C:\> Get-AzureRmDataFactoryV2IntegrationRuntime -ResourceGroupName rg-test-dfv2 -DataFactoryName test-df-eu2 -Name test-selfhost-ir

	ResourceGroupName DataFactoryName Name                 Description
	----------------- --------------- ----                 -----------
	rg-test-dfv2      test-df-eu2     test-selfhost-ir     selfhost IR
```

This command displays information about the integration runtime named 'test-dedicated-ir' in the subscription for the resource group named 'rg-test-dfv2' and data factory named 'test-df-eu2'.

## PARAMETERS

### -DataFactoryName
The data factory name.

```yaml
Type: String
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The integration runtime object.

```yaml
Type: PSIntegrationRuntime
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
Type: String
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
Type: String
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
Type: String
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
Type: SwitchParameter
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
Microsoft.Azure.Commands.DataFactoryV2.Models.PSIntegrationRuntime

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.DataFactoryV2.Models.PSIntegrationRuntime, Microsoft.Azure.Commands.DataFactoryV2, Version=0.1.9.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.DataFactoryV2.Models.PSManagedIntegrationRuntime
Microsoft.Azure.Commands.DataFactoryV2.Models.PSSelfHostedIntegrationRuntime

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories, copy, activities, integration runtime

## RELATED LINKS

[Set-AzureRmDataFactoryV2IntegrationRuntime]()

[Remove-AzureRmDataFactoryV2IntegrationRuntime]()
