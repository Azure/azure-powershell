---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/new-azelasticmonitor
schema: 2.0.0
---

# New-AzElasticMonitor

## SYNOPSIS
Create a monitor resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzElasticMonitor -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-CompanyInfoBusiness <String>] [-CompanyInfoCountry <String>] [-CompanyInfoDomain <String>]
 [-CompanyInfoEmployeesNumber <String>] [-CompanyInfoState <String>] [-GenerateApiKey]
 [-IdentityType <String>] [-MonitoringStatus <String>] [-Sku <String>] [-Tag <Hashtable>]
 [-UserInfoCompanyName <String>] [-UserInfoEmailAddress <String>] [-UserInfoFirstName <String>]
 [-UserInfoLastName <String>] [-Version <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzElasticMonitor -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzElasticMonitor -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a monitor resource.

## EXAMPLES

### Example 1: Create a monitor resource
```powershell
New-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Location eastus -Name Monitor01 -Sku ess-monthly-consumption_Monthly -UserInfoEmailAddress user@contoso.com
```

```output
CompanyInfoBusiness                           :
CompanyInfoCountry                            :
CompanyInfoDomain                             :
CompanyInfoEmployeesNumber                    :
CompanyInfoState                              :
ElasticCloudDeploymentAzureSubscriptionId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ElasticCloudDeploymentElasticsearchRegion     : azure-eastus
ElasticCloudDeploymentElasticsearchServiceUrl : https://283b270586b74450a4b05150d74e2e90.eastus.azure.elastic-cloud
                                                .com
ElasticCloudDeploymentId                      : 34eb2e206a8a7049c8d14729fb4d82cc
ElasticCloudDeploymentKibanaServiceUrl        : https://38edd7f06aba44ff874418f5df521ed0.eastus.azure.elastic-cloud
                                                .com:9243
ElasticCloudDeploymentKibanaSsoUrl            : /sso/v1/go/ec:1836023263:kibana-monitor01?acs=https://monitor01.kb.
                                                eastus.azure.elastic-cloud.com:9243/api/security/saml/callback&sp_l
                                                ogin_url=https://monitor01.kb.eastus.azure.elastic-cloud.com:9243
ElasticCloudDeploymentName                    : Monitor01
ElasticCloudUserElasticCloudSsoDefaultUrl     : https://cloud.elastic.co
ElasticCloudUserEmailAddress                  : user@contoso.com
ElasticCloudUserId                            : xxxxxxxx
GenerateApiKey                                : False
Id                                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/
                                                ElasticResourceGroup01/providers/Microsoft.Elastic/monitors/Monitor
                                                01
IdentityPrincipalId                           :
IdentityTenantId                              :
IdentityType                                  :
LiftrResourceCategory                         : MonitorLogs
LiftrResourcePreference                       : 0
Location                                      : eastus
MonitoringStatus                              : Enabled
Name                                          : Monitor01
ProvisioningState                             : Succeeded
ResourceGroupName                             : ElasticResourceGroup01
SkuName                                       : ess-monthly-consumption_Monthly
SystemDataCreatedAt                           : 07/20/2023 08:16:19
SystemDataCreatedBy                           : user@contoso.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 07/20/2023 08:16:19
SystemDataLastModifiedBy                      : user@contoso.com
SystemDataLastModifiedByType                  : User
Tag                                           : {}
Type                                          : microsoft.elastic/monitors
UserInfoCompanyName                           :
UserInfoEmailAddress                          :
UserInfoFirstName                             :
UserInfoLastName                              :
Version                                       :
```

Create a monitor resource.

### Example 2: Create a monitor resource via JSON string
```powershell
$monitorProps = @{
	location = "eastus"
	sku = @{
		name = "ess-monthly-consumption_Monthly"
	}
	properties = @{
		userInfo = @{
			emailAddress = "user@contoso.com"
		}
	}
}
$monitorPropsJson = ConvertTo-Json -InputObject $monitorProps -Depth 5
New-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 -JsonString $monitorPropsJson
```

```output
CompanyInfoBusiness                           :
CompanyInfoCountry                            :
CompanyInfoDomain                             :
CompanyInfoEmployeesNumber                    :
CompanyInfoState                              :
ElasticCloudDeploymentAzureSubscriptionId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ElasticCloudDeploymentElasticsearchRegion     : azure-eastus
ElasticCloudDeploymentElasticsearchServiceUrl : https://0708d96e6a6e465e9bc08beae8545d46.eastus.azure.elastic-cloud
                                                .com
ElasticCloudDeploymentId                      : 0a75470005346b8dc57e0cb1d596764c
ElasticCloudDeploymentKibanaServiceUrl        : https://2be9491ce2104fdaa251c84a587455da.eastus.azure.elastic-cloud
                                                .com:9243
ElasticCloudDeploymentKibanaSsoUrl            : /sso/v1/go/ec:1836023263:kibana-monitor02?acs=https://monitor02.kb.
                                                eastus.azure.elastic-cloud.com:9243/api/security/saml/callback&sp_l
                                                ogin_url=https://monitor02.kb.eastus.azure.elastic-cloud.com:9243
ElasticCloudDeploymentName                    : Monitor02
ElasticCloudUserElasticCloudSsoDefaultUrl     : https://cloud.elastic.co
ElasticCloudUserEmailAddress                  : user@contoso.com
ElasticCloudUserId                            : xxxxxxxx
GenerateApiKey                                : False
Id                                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/
                                                ElasticResourceGroup01/providers/Microsoft.Elastic/monitors/Monitor
                                                02
IdentityPrincipalId                           :
IdentityTenantId                              :
IdentityType                                  :
LiftrResourceCategory                         : MonitorLogs
LiftrResourcePreference                       : 0
Location                                      : eastus
MonitoringStatus                              : Enabled
Name                                          : Monitor02
ProvisioningState                             : Succeeded
ResourceGroupName                             : ElasticResourceGroup01
SkuName                                       : ess-monthly-consumption_Monthly
SystemDataCreatedAt                           : 07/20/2023 08:24:13
SystemDataCreatedBy                           : user@contoso.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 07/20/2023 08:24:13
SystemDataLastModifiedBy                      : user@contoso.com
SystemDataLastModifiedByType                  : User
Tag                                           : {}
Type                                          : microsoft.elastic/monitors
UserInfoCompanyName                           :
UserInfoEmailAddress                          :
UserInfoFirstName                             :
UserInfoLastName                              :
Version                                       :
```

Create a monitor resource via JSON string.

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

### -CompanyInfoBusiness
Business of the company

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyInfoCountry
Country of the company location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyInfoDomain
Domain of the company

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyInfoEmployeesNumber
Number of employees in the company

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompanyInfoState
State of the company location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -GenerateApiKey
Flag to determine if User API Key has to be generated and shared.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Managed identity type.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the monitor resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoringStatus
Flag specifying if the resource monitoring is enabled or disabled.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Monitor resource name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MonitorName

Required: True
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

### -ResourceGroupName
The name of the resource group to which the Elastic resource belongs.

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
Name of the SKU.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags of the monitor resource.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoCompanyName
Company name of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoEmailAddress
Email of the user used by Elastic for contacting them if needed

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoFirstName
First name of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoLastName
Last name of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version of elastic of the monitor resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticMonitorResource

## NOTES

## RELATED LINKS

