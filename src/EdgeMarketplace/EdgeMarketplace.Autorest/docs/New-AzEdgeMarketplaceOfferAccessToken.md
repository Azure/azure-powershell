---
external help file:
Module Name: Az.EdgeMarketplace
online version: https://learn.microsoft.com/powershell/module/az.edgemarketplace/new-azedgemarketplaceofferaccesstoken
schema: 2.0.0
---

# New-AzEdgeMarketplaceOfferAccessToken

## SYNOPSIS
A long-running resource action.

## SYNTAX

### GenerateExpanded (Default)
```
New-AzEdgeMarketplaceOfferAccessToken -OfferId <String> -ResourceUri <String> -EdgeMarketplaceRegion <String>
 [-DeviceSku <String>] [-DeviceVersion <String>] [-EdgeMarketplaceResourceId <String>]
 [-HypervGeneration <String>] [-MarketplaceSku <String>] [-MarketplaceSkuVersion <String>]
 [-PublisherName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Generate
```
New-AzEdgeMarketplaceOfferAccessToken -OfferId <String> -ResourceUri <String> -Body <IAccessTokenRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentity
```
New-AzEdgeMarketplaceOfferAccessToken -InputObject <IEdgeMarketplaceIdentity> -Body <IAccessTokenRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentityExpanded
```
New-AzEdgeMarketplaceOfferAccessToken -InputObject <IEdgeMarketplaceIdentity> -EdgeMarketplaceRegion <String>
 [-DeviceSku <String>] [-DeviceVersion <String>] [-EdgeMarketplaceResourceId <String>]
 [-HypervGeneration <String>] [-MarketplaceSku <String>] [-MarketplaceSkuVersion <String>]
 [-PublisherName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GenerateViaJsonFilePath
```
New-AzEdgeMarketplaceOfferAccessToken -OfferId <String> -ResourceUri <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaJsonString
```
New-AzEdgeMarketplaceOfferAccessToken -OfferId <String> -ResourceUri <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
A long-running resource action.

## EXAMPLES

### Example 1: Generating new requestId or access token using GenerateExpanded (Default)
```powershell
New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion 17763.7314.250509
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```

This command used for generating new access token using expanded parameters.

### Example 2: (Generate) Generate access token with request body as parameter.
```powershell
$requestBody = @{
    "EdgeMarketplaceRegion" = "eastus";
    "HypervGeneration" = "1";
    "MarketplaceSku" = "2019-datacenter";
    "MarketplaceSkuVersion" = "17763.7314.250509";
}

New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -Body $requestBody

```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```

This command used for generating new access token with request body parameter.

### Example 3: (GenerateViaIdentity) Generate access token with Identity and Body parameter
```powershell
$requestBody = @{
    "EdgeMarketplaceRegion" = "eastus";
    "HypervGeneration" = "1";
    "MarketplaceSku" = "2019-datacenter";
    "MarketplaceSkuVersion" = "17763.7314.250509";
}

$offerIdentity = @{
    "ResourceUri" = "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation"
    "OfferId" = "microsoftwindowsserver:windowsserver"
}

New-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -Body $requestBody
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```
This command used for generating access token with input object and body parameter

### Example 4: (GenerateViaIdentityExpanded) Generate access token with Identity and expanded parameters
```powershell
$offerIdentity = @{
    "ResourceUri" = "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation"
    "OfferId" = "microsoftwindowsserver:windowsserver"
}

New-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -EdgeMarketplaceRegion eastus -HypervGeneration 1 -MarketplaceSku 2019-datacenter -MarketplaceSkuVersion 17763.7314.250509
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```
This command used for generating access token with input object and expanded parameters

### Example 5: (GenerateViaJsonFilePath) Generate access token using Json file path
```powershell
New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -JsonFilePath "path/to/file/new-offerAccessToken.json"
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```
This command used for generating access token using json file path

### Example 6: (GenerateViaJsonString) Generate Access Token using Json string
```powershell
New-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -JsonString '{"edgeMarketPlaceRegion": "eastus","hypervGeneration": "1","marketPlaceSku": "2019-datacenter","marketPlaceSkuVersion": "17763.7314.250509"}'
```

```output
AccessToken DiskId Status
----------- ------ ------
                   Succeeded
```
This command used for generating access token using json string 

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Body
Access token request object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenRequest
Parameter Sets: Generate, GenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DeviceSku
The device sku.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceVersion
The device sku version.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EdgeMarketplaceRegion
The region where the disk will be created.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EdgeMarketplaceResourceId
The region where the disk will be created.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HypervGeneration
The hyperv version.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IEdgeMarketplaceIdentity
Parameter Sets: GenerateViaIdentity, GenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Generate operation

```yaml
Type: System.String
Parameter Sets: GenerateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Generate operation

```yaml
Type: System.String
Parameter Sets: GenerateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceSku
The marketplace sku.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceSkuVersion
The marketplace sku version.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -OfferId
Id of the offer

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded, GenerateViaJsonFilePath, GenerateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublisherName
The name of the publisher.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded, GenerateViaJsonFilePath, GenerateViaJsonString
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenRequest

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IEdgeMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IDiskAccessToken

## NOTES

## RELATED LINKS

