---
external help file:
Module Name: Az.DynatraceObservability
online version: https://docs.microsoft.com/en-us/powershell/module/az.dynatraceobservability/new-azdynatraceobservabilitymonitor
schema: 2.0.0
---

# New-AzDynatraceObservabilityMonitor

## SYNOPSIS
Create a MonitorResource

## SYNTAX

```
New-AzDynatraceObservabilityMonitor -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AccountInfoAccountId <String>] [-AccountInfoRegionId <String>]
 [-DynatraceEnvironmentPropertyUserId <String>] [-EnvironmentInfoEnvironmentId <String>]
 [-EnvironmentInfoIngestionKey <String>] [-EnvironmentInfoLandingUrl <String>]
 [-EnvironmentInfoLogsIngestionEndpoint <String>] [-IdentityType <ManagedIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-MarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>]
 [-MonitoringStatus <MonitoringStatus>] [-PlanDataBillingCycle <String>] [-PlanDataEffectiveDate <DateTime>]
 [-PlanDataPlanDetail <String>] [-PlanDataUsageType <String>] [-SingleSignOnPropertyAadDomain <String[]>]
 [-SingleSignOnPropertyEnterpriseAppId <String>] [-SingleSignOnPropertySingleSignOnState <SingleSignOnStates>]
 [-SingleSignOnPropertySingleSignOnUrl <String>] [-Tag <Hashtable>] [-UserInfoCountry <String>]
 [-UserInfoEmailAddress <String>] [-UserInfoFirstName <String>] [-UserInfoLastName <String>]
 [-UserInfoPhoneNumber <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a MonitorResource

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

### -AccountInfoAccountId
Account Id of the account this environment is linked to

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

### -AccountInfoRegionId
Region in which the account is created

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

### -DynatraceEnvironmentPropertyUserId
User id

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

### -EnvironmentInfoEnvironmentId
Id of the environment created

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

### -EnvironmentInfoIngestionKey
Ingestion key of the environment

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

### -EnvironmentInfoLandingUrl
Landing URL for Dynatrace environment

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

### -EnvironmentInfoLogsIngestionEndpoint
Ingestion endpoint used for sending logs

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

### -IdentityType
The type of managed identity assigned to this resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Support.ManagedIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The identities assigned to this resource by the user.

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

### -Location
The geo-location where the resource lives

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

### -MarketplaceSubscriptionStatus
Marketplace subscription status.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Support.MarketplaceSubscriptionStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoringStatus
Status of the monitor.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Support.MonitoringStatus
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
plan id as published by Dynatrace

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

### -SingleSignOnPropertyAadDomain
array of Aad(azure active directory) domains

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertyEnterpriseAppId
Version of the Dynatrace agent installed on the VM.

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

### -SingleSignOnPropertySingleSignOnState
State of Single Sign On

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Support.SingleSignOnStates
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SingleSignOnPropertySingleSignOnUrl
The login URL specific to this Dynatrace Environment

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
Resource tags.

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

### -UserInfoCountry
Country of the user

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
Email of the user used by Dynatrace for contacting them if needed

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
Phone number of the user used by Dynatrace for contacting them if needed

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

### Microsoft.Azure.PowerShell.Cmdlets.DynatraceObservability.Models.Api20210901Preview.IMonitorResource

## NOTES

ALIASES

## RELATED LINKS

