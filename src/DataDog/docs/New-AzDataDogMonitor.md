---
external help file:
Module Name: Az.DataDog
online version: https://docs.microsoft.com/en-us/powershell/module/az.datadog/new-azdatadogmonitor
schema: 2.0.0
---

# New-AzDataDogMonitor

## SYNOPSIS
Create a monitor resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDataDogMonitor -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-DatadogOrganizationPropertyEnterpriseAppId <String>] [-DatadogOrganizationPropertyLinkingAuthCode <String>]
 [-DatadogOrganizationPropertyLinkingClientId <String>] [-IdentityType <ManagedIdentityTypes>]
 [-MarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>] [-MonitoringStatus <MonitoringStatus>]
 [-ProvisioningState <ProvisioningState>] [-SkuName <String>] [-Tag <Hashtable>]
 [-UserInfoEmailAddress <String>] [-UserInfoName <String>] [-UserInfoPhoneNumber <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzDataDogMonitor -Name <String> -ResourceGroupName <String> -Body <IDatadogMonitorResource>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzDataDogMonitor -InputObject <IDataDogIdentity> -Body <IDatadogMonitorResource>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDataDogMonitor -InputObject <IDataDogIdentity> -Location <String>
 [-DatadogOrganizationPropertyEnterpriseAppId <String>] [-DatadogOrganizationPropertyLinkingAuthCode <String>]
 [-DatadogOrganizationPropertyLinkingClientId <String>] [-IdentityType <ManagedIdentityTypes>]
 [-MarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>] [-MonitoringStatus <MonitoringStatus>]
 [-ProvisioningState <ProvisioningState>] [-SkuName <String>] [-Tag <Hashtable>]
 [-UserInfoEmailAddress <String>] [-UserInfoName <String>] [-UserInfoPhoneNumber <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a monitor resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

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

### -Body
.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20200201Preview.IDatadogMonitorResource
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyEnterpriseAppId
The Id of the Enterprise App used for Single sign on.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyLinkingAuthCode
The auth code used to linking to an existing datadog organization.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatadogOrganizationPropertyLinkingClientId
The client_id from an existing in exchange for an auth token to link organization.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.ManagedIdentityTypes
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.IDataDogIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MarketplaceSubscriptionStatus
Flag specifying the Marketplace Subscription Status of the resource.
If payment is not made in time, the resource will go in Suspended state.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.MarketplaceSubscriptionStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.MonitoringStatus
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
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

### -ProvisioningState
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataDog.Support.ProvisioningState
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the Datadog resource belongs.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the SKU.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Microsoft Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoEmailAddress
Email of the user used by Datadog for contacting them if needed

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoName
Name of the user

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserInfoPhoneNumber
Phone number of the user used by Datadog for contacting them if needed

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20200201Preview.IDatadogMonitorResource

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.IDataDogIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataDog.Models.Api20200201Preview.IDatadogMonitorResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IDatadogMonitorResource>: .
  - `Location <String>`: 
  - `SkuName <String>`: Name of the SKU.
  - `[DatadogOrganizationPropertyEnterpriseAppId <String>]`: The Id of the Enterprise App used for Single sign on.
  - `[DatadogOrganizationPropertyLinkingAuthCode <String>]`: The auth code used to linking to an existing datadog organization.
  - `[DatadogOrganizationPropertyLinkingClientId <String>]`: The client_id from an existing in exchange for an auth token to link organization.
  - `[IdentityType <ManagedIdentityTypes?>]`: 
  - `[MarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus?>]`: Flag specifying the Marketplace Subscription Status of the resource. If payment is not made in time, the resource will go in Suspended state.
  - `[MonitoringStatus <MonitoringStatus?>]`: Flag specifying if the resource monitoring is enabled or disabled.
  - `[ProvisioningState <ProvisioningState?>]`: 
  - `[Tag <IDatadogMonitorResourceTags>]`: Dictionary of <string>
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[UserInfoEmailAddress <String>]`: Email of the user used by Datadog for contacting them if needed
  - `[UserInfoName <String>]`: Name of the user
  - `[UserInfoPhoneNumber <String>]`: Phone number of the user used by Datadog for contacting them if needed

INPUTOBJECT <IDataDogIdentity>: Identity Parameter
  - `[ConfigurationName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Monitor resource name
  - `[ResourceGroupName <String>]`: The name of the resource group to which the Datadog resource belongs.
  - `[RuleSetName <String>]`: 
  - `[SubscriptionId <String>]`: The Microsoft Azure subscription ID.

## RELATED LINKS

