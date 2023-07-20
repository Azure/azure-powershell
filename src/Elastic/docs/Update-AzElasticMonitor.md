---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/update-azelasticmonitor
schema: 2.0.0
---

# Update-AzElasticMonitor

## SYNOPSIS
Update a monitor resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzElasticMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzElasticMonitor -InputObject <IElasticIdentity> [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzElasticMonitor -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzElasticMonitor -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a monitor resource.

## EXAMPLES

### Example 1: Update a monitor resource
```powershell
Update-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01 -Tag @{ "Tag11Name" = "Tag11Val"; "Tag12Name" = "Tag12Val" }
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
SystemDataLastModifiedAt                      : 07/20/2023 08:30:44
SystemDataLastModifiedBy                      : user@contoso.com
SystemDataLastModifiedByType                  : User
Tag                                           : {
                                                  "Tag11Name": "Tag11Val",
                                                  "Tag12Name": "Tag12Val"
                                                }
Type                                          : microsoft.elastic/monitors
UserInfoCompanyName                           :
UserInfoEmailAddress                          :
UserInfoFirstName                             :
UserInfoLastName                              :
Version                                       :
```

Update a monitor resource.

### Example 2: Update a monitor resource via JSON string
```powershell
$monitorTags = @{
	tags = @{
        "Tag21Name" = "Tag21Val"
        "Tag22Name" = "Tag22Val"
    }
}
$monitorTagsJson = ConvertTo-Json -InputObject $monitorTags
Update-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 -JsonString $monitorTagsJson
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
SystemDataLastModifiedAt                      : 07/20/2023 09:53:25
SystemDataLastModifiedBy                      : user@contoso.com
SystemDataLastModifiedByType                  : User
Tag                                           : {
                                                  "Tag21Name": "Tag21Val",
                                                  "Tag22Name": "Tag22Val"
                                                }
Type                                          : microsoft.elastic/monitors
UserInfoCompanyName                           :
UserInfoEmailAddress                          :
UserInfoFirstName                             :
UserInfoLastName                              :
Version                                       :
```

Update a monitor resource via JSON string.

### Example 3: Update a monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor03 | Update-AzElasticMonitor -Tag @{ "Tag31Name" = "Tag31Val"; "Tag32Name" = "Tag32Val" }
```

```output
CompanyInfoBusiness                           :
CompanyInfoCountry                            :
CompanyInfoDomain                             :
CompanyInfoEmployeesNumber                    :
CompanyInfoState                              :
ElasticCloudDeploymentAzureSubscriptionId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ElasticCloudDeploymentElasticsearchRegion     : azure-eastus
ElasticCloudDeploymentElasticsearchServiceUrl : https://65b3174c3d46418d99e59f5c410dd195.eastus.azure.elastic-cloud
                                                .com
ElasticCloudDeploymentId                      : 1549df676f0d81ca9770522c886eac42
ElasticCloudDeploymentKibanaServiceUrl        : https://7cd05812725a47c78f22dda4904a25f6.eastus.azure.elastic-cloud
                                                .com:9243
ElasticCloudDeploymentKibanaSsoUrl            : /sso/v1/go/ec:1836023263:kibana-monitor03?acs=https://monitor03.kb.
                                                eastus.azure.elastic-cloud.com:9243/api/security/saml/callback&sp_l
                                                ogin_url=https://monitor03.kb.eastus.azure.elastic-cloud.com:9243
ElasticCloudDeploymentName                    : Monitor03
ElasticCloudUserElasticCloudSsoDefaultUrl     : https://cloud.elastic.co
ElasticCloudUserEmailAddress                  : user@contoso.com
ElasticCloudUserId                            : xxxxxxxx
GenerateApiKey                                : False
Id                                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/
                                                ElasticResourceGroup01/providers/Microsoft.Elastic/monitors/Monitor
                                                03
IdentityPrincipalId                           :
IdentityTenantId                              :
IdentityType                                  :
LiftrResourceCategory                         : MonitorLogs
LiftrResourcePreference                       : 0
Location                                      : eastus
MonitoringStatus                              : Enabled
Name                                          : Monitor03
ProvisioningState                             : Succeeded
ResourceGroupName                             : ElasticResourceGroup01
SkuName                                       : ess-monthly-consumption_Monthly
SystemDataCreatedAt                           : 07/20/2023 08:34:00
SystemDataCreatedBy                           : user@contoso.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 07/20/2023 09:56:00
SystemDataLastModifiedBy                      : user@contoso.com
SystemDataLastModifiedByType                  : User
Tag                                           : {
                                                  "Tag31Name": "Tag31Val",
                                                  "Tag32Name": "Tag32Val"
                                                }
Type                                          : microsoft.elastic/monitors
UserInfoCompanyName                           :
UserInfoEmailAddress                          :
UserInfoFirstName                             :
UserInfoLastName                              :
Version                                       :
```

Update a monitor resource via pipeline.

## PARAMETERS

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Monitor resource name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: MonitorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the Elastic resource belongs.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
elastic monitor resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticMonitorResource

## NOTES

## RELATED LINKS

