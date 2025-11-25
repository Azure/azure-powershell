---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Search.dll-Help.xml
Module Name: Az.Search
online version: https://learn.microsoft.com/powershell/module/az.search/new-azsearchservice
schema: 2.0.0
---

# New-AzSearchService

## SYNOPSIS
Creates an Azure AI Search service.

## SYNTAX

```
New-AzSearchService [-ResourceGroupName] <String> [-Name] <String> [-Sku] <PSSkuName> [-Location] <String>
 [-PartitionCount <Int32>] [-ReplicaCount <Int32>] [-HostingMode <PSHostingMode>]
 [-PublicNetworkAccess <PSPublicNetworkAccess>] [-IdentityType <PSIdentityType>] [-IPRuleList <PSIpRule[]>]
 [-DisableLocalAuth <Boolean>] [-AuthOption <PSAuthOptionName>] [-AadAuthFailureMode <PSAadAuthFailureMode>]
 [-SemanticSearchMode <PSSemanticSearchMode>] [-ComputeType <PSComputeType>]
 [-DataExfiltrationProtectionList <PSDataExfiltrationProtection[]>] [-Bypass <PSSearchBypass>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSearchService** cmdlet creates an Azure AI Search service with specified parameters.

## EXAMPLES

### Example 1
```powershell
New-AzSearchService -ResourceGroupName "TestAzureSearchPsGroup" -Name "pstestazuresearch01" -Sku "Standard" -Location "West US" -PartitionCount 1 -ReplicaCount 1 -HostingMode Default
```

```output
ResourceGroupName : TestAzureSearchPsGroup
Name              : pstestazuresearch01
Id                : /subscriptions/f9b96b36-1f5e-4021-8959-51527e26e6d3/resourceGroups/TestAzureSearchPsGroup/providers/Microsoft.Search/searchServices/pstestazuresearch01
Location          : West US
Sku               : Standard
ReplicaCount      : 1
PartitionCount    : 1
HostingMode       : Default
Tags              :
```

The command creates an Azure AI Search service.

## PARAMETERS

### -AadAuthFailureMode
(Optional) What status code to return when failing AAD authentication, if both api key and AAD authentication are allowed for the Azure AI Search service

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.Management.Search.Models.PSAadAuthFailureMode]
Parameter Sets: (All)
Aliases:
Accepted values: Http403, Http401WithBearerChallenge

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthOption
(Optional) Whether to only allow API key authentication or both API key authentication and AAD authentication for the Azure AI Search service

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.Management.Search.Models.PSAuthOptionName]
Parameter Sets: (All)
Aliases:
Accepted values: ApiKeyOnly, AadOrApiKey

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Bypass
(Optional) Possible origins of inbound traffic that can bypass the rules defined in the 'ipRules' section

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.Management.Search.Models.PSSearchBypass]
Parameter Sets: (All)
Aliases:
Accepted values: None, AzureServices

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeType
(Optional) Option to support the search service using either the Default Compute or Azure Confidential Compute

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.Management.Search.Models.PSComputeType]
Parameter Sets: (All)
Aliases:
Accepted values: Default, Confidential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataExfiltrationProtectionList
(Optional) A list of data exfiltration scenarios that are explicitly disallowed for the search service

```yaml
Type: Microsoft.Azure.Commands.Management.Search.Models.PSDataExfiltrationProtection[]
Parameter Sets: (All)
Aliases:
Accepted values: BlockAll

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

### -DisableLocalAuth
(Optional) Disable API key authentication for the Azure AI Search service (true/false/null)

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostingMode
Azure AI Search Service hosting mode.

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.Management.Search.Models.PSHostingMode]
Parameter Sets: (All)
Aliases:
Accepted values: Default, HighDensity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
(Optional) Azure AI Search Service Identity (None/SystemAssigned)

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.Management.Search.Models.PSIdentityType]
Parameter Sets: (All)
Aliases:
Accepted values: None, SystemAssigned, UserAssigned, SystemAssignedUserAssigned

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPRuleList
(Optional) Azure AI Search Service IP rules

```yaml
Type: Microsoft.Azure.Commands.Management.Search.Models.PSIpRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Azure AI Search Service location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Azure AI Search Service name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PartitionCount
Azure AI Search Service partition count.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicNetworkAccess
(Optional) Azure AI Search Service public network access (Enabled/Disabled)

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.Management.Search.Models.PSPublicNetworkAccess]
Parameter Sets: (All)
Aliases:
Accepted values: Enabled, Disabled, SecuredByPerimeter

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicaCount
Azure AI Search Service replica count.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SemanticSearchMode
(Optional) Option to control the availability of semantic search. This configuration is only possible for certain Azure AI Search SKUs in certain locations

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.Management.Search.Models.PSSemanticSearchMode]
Parameter Sets: (All)
Aliases:
Accepted values: Disabled, Free, Standard

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
Azure AI Search Service Sku.

```yaml
Type: Microsoft.Azure.Commands.Management.Search.Models.PSSkuName
Parameter Sets: (All)
Aliases:
Accepted values: Free, Basic, Standard, Standard2, Standard3, Storage_Optimized_L1, Storage_Optimized_L2

Required: True
Position: 2
Default value: None
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.Search.Models.PSSearchService

## NOTES

## RELATED LINKS

[Get-AzSearchService](./Get-AzSearchService.md)

[Set-AzSearchService](./Set-AzSearchService.md)

[Remove-AzSearchService](./Remove-AzSearchService.md)
