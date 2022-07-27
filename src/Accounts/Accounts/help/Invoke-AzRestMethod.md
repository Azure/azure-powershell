---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://docs.microsoft.com/powershell/module/az.accounts/invoke-azrestmethod
schema: 2.0.0
---

# Invoke-AzRestMethod

## SYNOPSIS
Construct and perform HTTP request to Azure resource management endpoint only

## SYNTAX

### ByPath (Default)
```
Invoke-AzRestMethod -Path <String> [-Method <String>] [-Payload <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByParameters
```
Invoke-AzRestMethod [-SubscriptionId <String>] [-ResourceGroupName <String>] [-ResourceProviderName <String>]
 [-ResourceType <String[]>] [-Name <String[]>] -ApiVersion <String> [-Method <String>] [-Payload <String>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByURI
```
Invoke-AzRestMethod [-Uri] <Uri> [-ResourceId <Uri>] [-Method <String>] [-Payload <String>] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
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

### System.string

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSHttpResponse

## NOTES

## RELATED LINKS
