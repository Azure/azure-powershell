---
external help file:
Module Name: Az.EdgeMarketplace
online version: https://learn.microsoft.com/powershell/module/az.edgemarketplace/get-azedgemarketplaceofferaccesstoken
schema: 2.0.0
---

# Get-AzEdgeMarketplaceOfferAccessToken

## SYNOPSIS
Get access token.

## SYNTAX

### GetExpanded (Default)
```
Get-AzEdgeMarketplaceOfferAccessToken -OfferId <String> -ResourceUri <String> -RequestId <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Get
```
Get-AzEdgeMarketplaceOfferAccessToken -OfferId <String> -ResourceUri <String> -Body <IAccessTokenReadRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEdgeMarketplaceOfferAccessToken -InputObject <IEdgeMarketplaceIdentity> -Body <IAccessTokenReadRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzEdgeMarketplaceOfferAccessToken -InputObject <IEdgeMarketplaceIdentity> -RequestId <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzEdgeMarketplaceOfferAccessToken -OfferId <String> -ResourceUri <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzEdgeMarketplaceOfferAccessToken -OfferId <String> -ResourceUri <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get access token.

## EXAMPLES

### Example 1: Get access token
```powershell
Get-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -RequestId 72128075e3d54e58aa39321cb8e85f
```

```output
AccessToken
-----------
https://accesstokenlink
```

This command used to get access token using expanded parameters.

### Example 2: (Get) Get access token with request body as parameter.
```powershell
$requestBody = @{
    "RequestId" = "72128075e3d54e58aa39321cb8e85f";
}

Get-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -Body $requestBody

```

```output
AccessToken
-----------
https://accesstokenlink
```

This command used to get access token with request body parameter.

### Example 3: (GetViaIdentity) Get access token with Identity and Body parameter
```powershell
$requestBody = @{
    "RequestId" = "72128075e3d54e58aa39321cb8e85f";
}

$offerIdentity = @{
    "ResourceUri" = "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation"
    "OfferId" = "microsoftwindowsserver:windowsserver"
}

Get-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -Body $requestBody
```

```output
AccessToken
-----------
https://accesstokenlink
```
This command used to get access token with input object and body parameter

### Example 4: (GetViaIdentityExpanded) Get access token with Identity and expanded parameters
```powershell
$offerIdentity = @{
    "ResourceUri" = "/subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation"
    "OfferId" = "microsoftwindowsserver:windowsserver"
}

Get-AzEdgeMarketplaceOfferAccessToken -InputObject $offerIdentity -RequestId 72128075e3d54e58aa39321cb8e85f
```

```output
AccessToken
-----------
https://accesstokenlink
```
This command used to get access token with input object and expanded parameters

### Example 5: (GetViaJsonFilePath) Get access token using Json file path
```powershell
Get-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -JsonFilePath "path/to/file/get-offerAccessToken.json"
```

```output
AccessToken
-----------
https://accesstokenlink
```
This command used to get access token using json file path

### Example 6: (GetViaJsonString) Get Access Token using Json string
```powershell
Get-AzEdgeMarketplaceOfferAccessToken -OfferId microsoftwindowsserver:windowsserver -ResourceUri /subscriptions/82c4f715-0d39-4b14-bc1a-8d28a289472c/resourceGroups/bvt-test-automation/providers/Microsoft.Edge/disconnectedOperations/test-automation -JsonString '{"requestId": "72128075e3d54e58aa39321cb8e85f"}'
```

```output
AccessToken
-----------
https://accesstokenlink
```
This command used to get access token using json string 

## PARAMETERS

### -Body
Access token request object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenReadRequest
Parameter Sets: Get, GetViaIdentity
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IEdgeMarketplaceIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OfferId
Id of the offer

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestId
The name of the publisher.

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource.

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IAccessTokenReadRequest

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IEdgeMarketplaceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.IDiskAccessToken

## NOTES

## RELATED LINKS

