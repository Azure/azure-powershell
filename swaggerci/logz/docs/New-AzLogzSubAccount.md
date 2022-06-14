---
external help file:
Module Name: Az.Logz
online version: https://docs.microsoft.com/en-us/powershell/module/az.logz/new-azlogzsubaccount
schema: 2.0.0
---

# New-AzLogzSubAccount

## SYNOPSIS
Create sub account under a given monitor resource.
This create operation can take upto 10 minutes to complete.

## SYNTAX

```
New-AzLogzSubAccount -MonitorName <String> -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-IdentityType <ManagedIdentityTypes>]
 [-LogzOrganizationPropertyCompanyName <String>] [-LogzOrganizationPropertyEnterpriseAppId <String>]
 [-LogzOrganizationPropertySingleSignOnUrl <String>]
 [-MarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>] [-MonitoringStatus <MonitoringStatus>]
 [-PlanDataBillingCycle <String>] [-PlanDataEffectiveDate <DateTime>] [-PlanDataPlanDetail <String>]
 [-PlanDataUsageType <String>] [-Tag <Hashtable>] [-UserInfoEmailAddress <String>]
 [-UserInfoFirstName <String>] [-UserInfoLastName <String>] [-UserInfoPhoneNumber <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create sub account under a given monitor resource.
This create operation can take upto 10 minutes to complete.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -IdentityType
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Support.ManagedIdentityTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
.

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

### -LogzOrganizationPropertyCompanyName
Name of the Logz organization.

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

### -LogzOrganizationPropertyEnterpriseAppId
The Id of the Enterprise App used for Single sign on.

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

### -LogzOrganizationPropertySingleSignOnUrl
The login URL specific to this Logz Organization.

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

### -MarketplaceSubscriptionStatus
Flag specifying the Marketplace Subscription Status of the resource.
If payment is not made in time, the resource will go in Suspended state.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Support.MarketplaceSubscriptionStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoringStatus
Flag specifying if the resource monitoring is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Support.MonitoringStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

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

### -Name
Sub Account resource name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SubAccountName

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

### -PlanDataBillingCycle
different billing cycles like MONTHLY/WEEKLY.
this could be enum

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

### -PlanDataEffectiveDate
date when plan was applied

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanDataPlanDetail
plan id as published by Logz

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

### -PlanDataUsageType
different usage type like PAYG/COMMITTED.
this could be enum

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
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

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
Dictionary of \<string\>

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

### -UserInfoEmailAddress
Email of the user used by Logz for contacting them if needed

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
First Name of the user

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
Last Name of the user

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

### -UserInfoPhoneNumber
Phone number of the user used by Logz for contacting them if needed

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

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001.ILogzMonitorResource

## NOTES

ALIASES

## RELATED LINKS

