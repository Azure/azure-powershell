---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://learn.microsoft.com/powershell/module/az.accounts/invoke-azrestmethod
schema: 2.0.0
---

# Invoke-AzRestMethod

## SYNOPSIS
Construct and perform HTTP request to Azure resource management endpoint only

## SYNTAX

### ByPath (Default)
```
Invoke-AzRestMethod -Path <String> [-Method <String>] [-Payload <String>] [-AsJob] [-WaitForCompletion]
 [-PollFrom <String>] [-FinalResultFrom <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>] [-FollowNextLink]
 [-NextLinkName <String>] [-PageableItemName <String>] [-MaxPageSize <Int32>]]
```

### ByParameters
```
Invoke-AzRestMethod [-SubscriptionId <String>] [-ResourceGroupName <String>] [-ResourceProviderName <String>]
 [-ResourceType <String[]>] [-Name <String[]>] -ApiVersion <String> [-Method <String>] [-Payload <String>]
 [-AsJob] [-WaitForCompletion] [-PollFrom <String>] [-FinalResultFrom <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-FollowNextLink]
 [-NextLinkName <String>] [-PageableItemName <String>] [-MaxPageSize <Int32>]]
 [<CommonParameters>]
```

### ByURI
```
Invoke-AzRestMethod [-Uri] <Uri> [-ResourceId <Uri>] [-Method <String>] [-Payload <String>] [-AsJob]
 [-WaitForCompletion] [-PollFrom <String>] [-FinalResultFrom <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-FollowNextLink]
 [-NextLinkName <String>] [-PageableItemName <String>] [-MaxPageSize <Int32>]]
 [<CommonParameters>]
```

## DESCRIPTION
Construct and perform HTTP request to Azure resource management endpoint only

## EXAMPLES

### Example 1
```powershell
Invoke-AzRestMethod -Path "/subscriptions/{subscription}/resourcegroups/{resourcegroup}/providers/microsoft.operationalinsights/workspaces/{workspace}?api-version={API}" -Method GET
```

```Output
Headers    : {[Cache-Control, System.String[]], [Pragma, System.String[]], [x-ms-request-id, System.String[]], [Strict-Transport-Security, System.String[]]…}
Version    : 1.1
StatusCode : 200
Method     : GET
Content    : {
               "properties": {
                 "source": "Azure",
                 "customerId": "{customerId}",
                 "provisioningState": "Succeeded",
                 "sku": {
                   "name": "pergb2018",
                   "maxCapacityReservationLevel": 3000,
                   "lastSkuUpdate": "Mon, 25 May 2020 11:10:01 GMT"
                 },
                 "retentionInDays": 30,
                 "features": {
                   "legacy": 0,
                   "searchVersion": 1,
                   "enableLogAccessUsingOnlyResourcePermissions": true
                 },
                 "workspaceCapping": {
                   "dailyQuotaGb": -1.0,
                   "quotaNextResetTime": "Thu, 18 Jun 2020 05:00:00 GMT",
                   "dataIngestionStatus": "RespectQuota"
                 },
                 "enableFailover": false,
                 "publicNetworkAccessForIngestion": "Enabled",
                 "publicNetworkAccessForQuery": "Enabled",
                 "createdDate": "Mon, 25 May 2020 11:10:01 GMT",
                 "modifiedDate": "Mon, 25 May 2020 11:10:02 GMT"
               },
               "id": "/subscriptions/{subscription}/resourcegroups/{resourcegroup}/providers/microsoft.operationalinsights/workspaces/{workspace}",
               "name": "{workspace}",
               "type": "Microsoft.OperationalInsights/workspaces",
               "location": "eastasia",
               "tags": {}
             }
```

Get log analytics workspace by path. It only supports management plane API and Hostname of Azure Resource Manager is added according to Azure environment setting.  

### Example 2
```powershell
Invoke-AzRestMethod https://graph.microsoft.com/v1.0/me
```

```output
Headers    : {[Date, System.String[]], [Cache-Control, System.String[]], [Transfer-Encoding, System.String[]], [Strict-Transport-Security, System.String[]]…}
Version    : 1.1
StatusCode : 200
Method     : GET
Content    : {"@odata.context":"https://graph.microsoft.com/v1.0/$metadata#users/$entity","businessPhones":["......}
```

Get current signed in user via MicrosoftGraph API. This example is equivalent to `Get-AzADUser -SignedIn`.

### Example 3
```powershell
$subscriptionId = (Get-AzContext).Subscription.ID
Invoke-AzRestMethod -SubscriptionId $subscriptionId -ResourceGroupName "test-group" -ResourceProviderName Microsoft.AppPlatform -ResourceType Spring,apps -Name "test-spring-service" -ApiVersion 2020-07-01 -Method GET
```

```output
Headers    : {[Cache-Control, System.String[]], [Pragma, System.String[]], [Vary, System.String[]], [x-ms-request-id,
             System.String[]]…}
Version    : 1.1
StatusCode : 200
Method     : GET
Content    : {"value":[{"properties":{"public":true,"url":"https://test-spring-service-demo.azuremicroservices.io","provisioni
             ngState":"Succeeded","activeDeploymentName":"default","fqdn":"test-spring-service.azuremicroservices.io","httpsOn
             ly":false,"createdTime":"2022-06-22T02:57:13.272Z","temporaryDisk":{"sizeInGB":5,"mountPath":"/tmp"},"pers
             istentDisk":{"sizeInGB":0,"mountPath":"/persistent"}},"type":"Microsoft.AppPlatform/Spring/apps","identity
             ":null,"location":"eastus","id":"/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.AppPlatform/Spring/test-spring-service/apps/demo","name":"demo"},{"properties":{"publ
             ic":false,"provisioningState":"Succeeded","activeDeploymentName":"deploy01","fqdn":"test-spring-service.azuremicr
             oservices.io","httpsOnly":false,"createdTime":"2022-06-22T07:46:54.9Z","temporaryDisk":{"sizeInGB":5,"moun
             tPath":"/tmp"},"persistentDisk":{"sizeInGB":0,"mountPath":"/persistent"}},"type":"Microsoft.AppPlatform/Sp
             ring/apps","identity":null,"location":"eastus","id":"/subscriptions/$subscriptionId/r
             esourceGroups/test-group/providers/Microsoft.AppPlatform/Spring/test-spring-service/apps/pwsh01","name":"pwsh0
             1"}]}
```

List apps under spring service "test-spring-service"

### Example 4
```powershell
$subscriptionId = (Get-AzContext).Subscription.ID
Invoke-AzRestMethod -SubscriptionId $subscriptionId -ResourceGroupName "test-group" -ResourceProviderName Microsoft.AppPlatform -ResourceType Spring -Name "test-spring-service","demo" -ApiVersion 2020-07-01 -Method GET
```

```output
Headers    : {[Cache-Control, System.String[]], [Pragma, System.String[]], [Vary, System.String[]], [x-ms-request-id,
             System.String[]]…}
Version    : 1.1
StatusCode : 200
Method     : GET
Content    : {"properties":{"public":true,"url":"https://test-spring-service-demo.azuremicroservices.io","provisioningState":"
             Succeeded","activeDeploymentName":"default","fqdn":"test-spring-service.azuremicroservices.io","httpsOnly":false,
             "createdTime":"2022-06-22T02:57:13.272Z","temporaryDisk":{"sizeInGB":5,"mountPath":"/tmp"},"persistentDisk
             ":{"sizeInGB":0,"mountPath":"/persistent"}},"type":"Microsoft.AppPlatform/Spring/apps","identity":null,"lo
             cation":"eastus","id":"/subscriptions/$subscriptionId/resourceGroups/test-group/pr
             oviders/Microsoft.AppPlatform/Spring/test-spring-service/apps/demo","name":"demo"}
```

Get app "demo" under Spring cloud service "test-spring-service"

### Example 5
```powershell
# Replace *** with real values
$payload = @{principalId="***"; resourceId="***"; appRoleId="***"} | ConvertTo-Json -Depth 3
Invoke-AzRestMethod -Method POST -Uri https://graph.microsoft.com/v1.0/servicePrincipals/***/appRoleAssignedTo -Payload $payload
```

Call Microsoft Graph API to assign App Role by constructing a hashtable, converting to a JSON string, and passing the payload to `Invoke-AzRestMethod`.

### Example 6
```powershell
# This example demonstrates creating or updating a resource with a long-running PUT request.
Invoke-AzRestMethod -Method PUT -Uri "https://management.azure.com/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.KeyVault/managedHSMs/{hsm-name}?api-version=2023-07-01" `
  -Payload (@{
    location = "eastus"; 
    properties = @{
      softDeleteRetentionDays = 7;
      tenantId = "{tenant-id}";
      initialAdminObjectIds = @("{admin-object-id}")
    }; 
    sku = @{
      name = "Standard_B1";
      family = "B"
    } 
  } | ConvertTo-Json -Depth 10) `
  -WaitForCompletion
```

```output
StatusCode : 200
Content    : {
               "sku": {
                 "family": "B",
                 "name": "Standard_B1"
               },
               "id": "/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.KeyVault/managedHSMs/{hsm-name}",
               "name": "{hsm-name}",
               "type": "Microsoft.KeyVault/managedHSMs",
               "location": "{region}",
               "tags": {},
               "systemData": {
                 "createdBy": "{user-email}",
                 "createdByType": "User",
                 "createdAt": "2024-10-29T05:05:49.229Z",
                 "lastModifiedBy": "{user-email}",
                 "lastModifiedByType": "User",
                 "lastModifiedAt": "2024-10-29T05:05:49.229Z"
               },
               "properties": {
                 "tenantId": "{tenant-id}",
                 "hsmUri": "https://{hsm-name}.managedhsm.azure.net/",
                 "initialAdminObjectIds": [
                   "{admin-object-id}"
                 ],
                 "enableSoftDelete": true,
                 "softDeleteRetentionInDays": 90,
                 "enablePurgeProtection": false,
                 "provisioningState": "Succeeded",
                 "statusMessage": "The Managed HSM is provisioned and ready to use.",
                 "networkAcls": {
                   "bypass": "AzureServices",
                   "defaultAction": "Allow",
                   "ipRules": [],
                   "virtualNetworkRules": []
                 },
                 "publicNetworkAccess": "Enabled",
                 "regions": [],
                 "securityDomainProperties": {
                   "activationStatus": "NotActivated",
                   "activationStatusMessage": "Your HSM has been provisioned, but cannot be used for cryptographic operations until it is activated. To activate the HSM, download the security domain."
                 }
               }
             }
Headers    : {
               "Cache-Control": "no-cache",
               "Pragma": "no-cache",
               "x-ms-client-request-id": "{client-request-id}",
               "x-ms-keyvault-service-version": "1.5.1361.0",
               "x-ms-request-id": "{request-id}",
               "x-ms-ratelimit-remaining-subscription-reads": "249",
               "x-ms-ratelimit-remaining-subscription-global-reads": "3749",
               "x-ms-correlation-request-id": "{correlation-request-id}",
               "x-ms-routing-request-id": "{routing-request-id}",
               "Strict-Transport-Security": "max-age=31536000; includeSubDomains",
               "Date": "Tue, 29 Oct 2024 05:18:44 GMT"
             }
Method     : GET
RequestUri : https://management.azure.com/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.KeyVault/managedHSMs/{hsm-name}?api-version=2023-07-01
Version    : 1.1
```

Sends a long-running PUT request to create or update a Managed HSM resource in Azure, polling until completion if the operation requires it.
This example uses placeholders ({subscription-id}, {resource-group}, {hsm-name}, {tenant-id}, and {admin-object-id}) that the user should replace with their specific values.


### Example 7
```powershell
# This example shows how to use server-side pagination to get results from a paginated GET endpoint by following nextLink references in the response.

Invoke-AzRest -SubscriptionId $subscriptionId -ResourceProviderName "Microsoft.Compute" -ResourceType "virtualMachines" -ApiVersion "2024-11-01" -Method "GET" -FollowNextLink

```

```output
StatusCode : 200
Content    : {
               "value": [
                 {
                   "name": "VM000",
                   "id": "/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.Compute/virtualMachines/VM000",
                   "type": "Microsoft.Compute/virtualMachines",
                   "location": "{region}",
                   "tags": {},
                   "identity": {},
                   "properties": {},
                   "resources": []
                 },
                 {
                   "name": "VM001",
                   "id": "/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.Compute/virtualMachines/VM001",
                   "type": "Microsoft.Compute/virtualMachines",
                   "location": "{region}",
                   "tags": {},
                   "identity": {},
                   "properties": {},
                   "resources": []
                 }
              ]
             }
Headers    : {
               "Pragma": "no-cache",
               "x-ms-request-id": "{request-id}",
               "x-ms-correlation-request-id": "{correlation-request-id}",
               "x-ms-routing-request-id": "{routing-request-id}",
               "Strict-Transport-Security": "max-age=31536000; includeSubDomains",
               "X-Content-Type-Options": "nosniff",
               "Date": "Wed, 23 Jul 2025 07:49:56 GMT"
             }
Method     : GET
RequestUri : https://management.azure.com/subscriptions/{subscription-id}/providers/Microsoft.Compute/virtualMachines?api-version=2024-11-01
Version    : 1.1

```


## PARAMETERS

### -ApiVersion
Api Version

```yaml
Type: System.String
Parameter Sets: ByParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

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

### -FinalResultFrom
Specifies the header for final GET result after the long-running operation completes.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: FinalStateVia, Location, OriginalUri, Operation-Location

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Method
Http Method

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: GET, POST, PUT, PATCH, DELETE

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
list of Target Resource Name

```yaml
Type: System.String[]
Parameter Sets: ByParameters
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Path of target resource URL. Hostname of Resource Manager should not be added.

```yaml
Type: System.String
Parameter Sets: ByPath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Payload
JSON format payload

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

### -PollFrom
Specifies the polling header (to fetch from) for long-running operation status.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: AzureAsyncLocation, Location, OriginalUri, Operation-Location

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Target Resource Group Name

```yaml
Type: System.String
Parameter Sets: ByParameters
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Identifier URI specified by the REST API you are calling. It shouldn't be the resource id of Azure Resource Manager.

```yaml
Type: System.Uri
Parameter Sets: ByURI
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceProviderName
Target Resource Provider Name

```yaml
Type: System.String
Parameter Sets: ByParameters
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
List of Target Resource Type

```yaml
Type: System.String[]
Parameter Sets: ByParameters
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Target Subscription Id

```yaml
Type: System.String
Parameter Sets: ByParameters
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Uri
Uniform Resource Identifier of the Azure resources. The target resource needs to support Azure AD authentication and the access token is derived according to resource id. If resource id is not set, its value is derived according to built-in service suffixes in current Azure Environment.

```yaml
Type: System.Uri
Parameter Sets: ByURI
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WaitForCompletion
Waits for the long-running operation to complete before returning the result.

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

### -FollowNextLink
Enables server-driven pagination from paginated GET endpoints.

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

### -NextLinkName
Specifies the name of the next link JSON property to follow for pagination.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: nextLink
Accept pipeline input: False
Accept wildcard characters: False
```

### -PageableItemName
Specifies the name of the JSON property that contains the items in a paginated response.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: value
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxPageSize
Specifies the maximum number of pages to retrieve when following next links in a paginated response.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value:
Accept pipeline input: False
Accept wildcard characters: False
```


### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.string

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSHttpResponse

## NOTES

## RELATED LINKS
