---
external help file: Az.Elastic-help.xml
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/new-azelasticmonitor
schema: 2.0.0
---

# New-AzElasticMonitor

## SYNOPSIS
Create a monitor resource.

## SYNTAX

```
New-AzElasticMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-CompanyInfoBusiness <String>] [-CompanyInfoCountry <String>] [-CompanyInfoDomain <String>]
 [-CompanyInfoEmployeesNumber <String>] [-CompanyInfoState <String>] [-IdentityType <ManagedIdentityTypes>]
 [-MonitoringStatus <MonitoringStatus>] [-Sku <String>] [-Tag <Hashtable>] [-UserInfoCompanyName <String>]
 [-UserInfoEmailAddress <String>] [-UserInfoFirstName <String>] [-UserInfoLastName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a monitor resource.

## EXAMPLES

### Example 1: Create a monitor resource
```powershell
New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -Sku "ess-consumption-2024_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com'
```

```output
Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-consumption-2024_Monthly Enabled          westus2  azure-elastic-test
```

This command creates a monitor resource.

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### -IdentityType
Managed identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Support.ManagedIdentityTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the monitor resource

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

### -MonitoringStatus
Flag specifying if the resource monitoring is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Support.MonitoringStatus
Parameter Sets: (All)
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
The SKU depends on the Elasticsearch Plans available for your account and is a combination of PlanID_Term.
\
For instance, if the plan ID is "planXYZ" and term is "Yearly", the SKU will be "planXYZ_Yearly".
\
You may find your eligible plans [here](https://portal.azure.com/#view/Microsoft_Azure_Marketplace/GalleryItemDetailsBladeNopdl/id/elastic.ec-azure-pp/selectionMode~/false/resourceGroupId//resourceGroupLocation//dontDiscardJourney~/false/selectedMenuId/home/launchingContext~/%7B%22galleryItemId%22%3A%22elastic.ec-azure-ppess-consumption-2024%22%2C%22source%22%3A%5B%22GalleryFeaturedMenuItemPart%22%2C%22VirtualizedTileDetails%22%5D%2C%22menuItemId%22%3A%22home%22%2C%22subMenuItemId%22%3A%22Search%20results%22%2C%22telemetryId%22%3A%2262f8ce76-e5e4-4983-9d3e-5c608a0b2bff%22%7D/searchTelemetryId/cca0a8d3-f232-4156-948f-701a5d74a729) or in the online documentation [here](https://azuremarketplace.microsoft.com/en-us/marketplace/apps/elastic.ec-azure-pp) for more details or in case of any issues with the SKU.

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.IElasticMonitorResource

## NOTES

## RELATED LINKS
