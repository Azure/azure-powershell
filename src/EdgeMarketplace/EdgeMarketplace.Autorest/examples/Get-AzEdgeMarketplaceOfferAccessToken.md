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