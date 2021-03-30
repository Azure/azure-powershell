---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://docs.microsoft.com/en-us/powershell/module/az.providerhub/new-azproviderhubsku
schema: 2.0.0
---

# New-AzProviderHubSku

## SYNOPSIS
Creates or updates the resource type skus in the given resource type.

## SYNTAX

```
New-AzProviderHubSku -ProviderNamespace <String> -ResourceType <String> -Sku <String>
 [-SubscriptionId <String>] -SkuSetting <ISkuSetting[]> [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the resource type skus in the given resource type.

## EXAMPLES

### Example 1: Create/Update a resource SKU definition.
```powershell
PS C:\> New-AzProviderHubSku -ProviderNamespace "Microsoft.Contoso" -ResourceType "testResourceType" -Sku "default" -SkuSetting @{Name = "freeSku"; Tier = "Tier1", Kind = "Standard"}
```

## PARAMETERS

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

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

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The resource type.

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

### -Sku
The SKU.

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

### -SkuSetting
.
To construct, see NOTES section for SKUSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuSetting[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ISkuResource
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

SKUSETTING \<ISkuSetting\[\]\>: .
  Name \<String\>:
  \[Capability \<ISkuCapability\[\]\>\]:
    Name \<String\>:
    Value \<String\>:
  \[CapacityDefault \<Int32?\>\]:
  \[CapacityMaximum \<Int32?\>\]:
  \[CapacityMinimum \<Int32?\>\]:
  \[CapacityScaleType \<String\>\]:
  \[Cost \<ISkuCost\[\]\>\]:
    MeterId \<String\>:
    \[ExtendedUnit \<String\>\]:
    \[Quantity \<Int32?\>\]:
  \[Family \<String\>\]:
  \[Kind \<String\>\]:
  \[Location \<String\[\]\>\]:
  \[LocationInfo \<ISkuLocationInfo\[\]\>\]:
    Location \<String\>:
    \[ExtendedLocation \<String\[\]\>\]:
    \[Type \<String\>\]:
    \[Zone \<String\[\]\>\]:
    \[ZoneDetail \<ISkuZoneDetail\[\]\>\]:
      \[Capability \<ISkuCapability\[\]\>\]:
      \[Name \<String\[\]\>\]:
  \[RequiredFeature \<String\[\]\>\]:
  \[RequiredQuotaId \<String\[\]\>\]:
  \[Size \<String\>\]:
  \[Tier \<String\>\]:

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.providerhub/new-azproviderhubsku](https://docs.microsoft.com/en-us/powershell/module/az.providerhub/new-azproviderhubsku)

