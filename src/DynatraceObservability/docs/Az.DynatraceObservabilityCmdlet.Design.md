#### New-AzDynatraceMonitor

#### SYNOPSIS
Create a MonitorResource

#### SYNTAX

```powershell
New-AzDynatraceMonitor -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AccountId <String>] [-AccountRegionId <String>] [-EnvironmentId <String>]
 [-EnvironmentIngestionKey <String>] [-EnvironmentLandingUrl <String>]
 [-EnvironmentLogsIngestionEndpoint <String>] [-EnvironmentUserId <String>]
 [-IdentityType <ManagedIdentityType>] [-IdentityUserAssigned <Hashtable>]
 [-MarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>] [-MonitoringStatus <MonitoringStatus>]
 [-PlanBillingCycle <String>] [-PlanDetail <String>] [-PlanEffectiveDate <DateTime>] [-PlanUsageType <String>]
 [-SingleSignOnAadDomain <String[]>] [-SingleSignOnEnterpriseAppId <String>]
 [-SingleSignOnState <SingleSignOnStates>] [-SingleSignOnUrl <String>] [-Tag <Hashtable>]
 [-UserCountry <String>] [-UserEmailAddress <String>] [-UserFirstName <String>] [-UserLastName <String>]
 [-UserPhoneNumber <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```


#### Get-AzDynatraceMonitor

#### SYNOPSIS
Get a MonitorResource

#### SYNTAX

+ List (Default)
```powershell
Get-AzDynatraceMonitor [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzDynatraceMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzDynatraceMonitor -InputObject <IDynatraceObservabilityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ List1
```powershell
Get-AzDynatraceMonitor -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```


#### Remove-AzDynatraceMonitor

#### SYNOPSIS
Delete a MonitorResource

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzDynatraceMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzDynatraceMonitor -InputObject <IDynatraceObservabilityIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzDynatraceMonitor

#### SYNOPSIS
Update a MonitorResource

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzDynatraceMonitor -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AccountId <String>] [-AccountRegionId <String>] [-EnvironmentId <String>]
 [-EnvironmentIngestionKey <String>] [-EnvironmentLandingUrl <String>]
 [-EnvironmentLogsIngestionEndpoint <String>] [-EnvironmentUserId <String>]
 [-MarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>] [-MonitoringStatus <MonitoringStatus>]
 [-PlanBillingCycle <String>] [-PlanDetail <String>] [-PlanEffectiveDate <DateTime>] [-PlanUsageType <String>]
 [-SingleSignOnAadDomain <String[]>] [-SingleSignOnEnterpriseAppId <String>]
 [-SingleSignOnState <SingleSignOnStates>] [-SingleSignOnUrl <String>] [-Tag <Hashtable>]
 [-UserCountry <String>] [-UserEmailAddress <String>] [-UserFirstName <String>] [-UserLastName <String>]
 [-UserPhoneNumber <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzDynatraceMonitor -InputObject <IDynatraceObservabilityIdentity> [-AccountId <String>]
 [-AccountRegionId <String>] [-EnvironmentId <String>] [-EnvironmentIngestionKey <String>]
 [-EnvironmentLandingUrl <String>] [-EnvironmentLogsIngestionEndpoint <String>] [-EnvironmentUserId <String>]
 [-MarketplaceSubscriptionStatus <MarketplaceSubscriptionStatus>] [-MonitoringStatus <MonitoringStatus>]
 [-PlanBillingCycle <String>] [-PlanDetail <String>] [-PlanEffectiveDate <DateTime>] [-PlanUsageType <String>]
 [-SingleSignOnAadDomain <String[]>] [-SingleSignOnEnterpriseAppId <String>]
 [-SingleSignOnState <SingleSignOnStates>] [-SingleSignOnUrl <String>] [-Tag <Hashtable>]
 [-UserCountry <String>] [-UserEmailAddress <String>] [-UserFirstName <String>] [-UserLastName <String>]
 [-UserPhoneNumber <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzDynatraceMonitorAccountCredential

#### SYNOPSIS
Gets the user account credentials for a Monitor

#### SYNTAX

```powershell
Get-AzDynatraceMonitorAccountCredential -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzDynatraceMonitorAppService

#### SYNOPSIS
Gets list of App Services with Dynatrace PaaS OneAgent enabled

#### SYNTAX

```powershell
Get-AzDynatraceMonitorAppService -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzDynatraceMonitorFilteringTagObject

#### SYNOPSIS
Create an in-memory object for FilteringTag.

#### SYNTAX

```powershell
New-AzDynatraceMonitorFilteringTagObject [-Action <TagAction>] [-Name <String>] [-Value <String>]
 [<CommonParameters>]
```


#### Get-AzDynatraceMonitorHost

#### SYNOPSIS
List the compute resources currently being monitored by the Dynatrace resource.

#### SYNTAX

```powershell
Get-AzDynatraceMonitorHost -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzDynatraceMonitorLinkableEnv

#### SYNOPSIS
Gets all the Dynatrace environments that a user can link a azure resource to

#### SYNTAX

```powershell
Get-AzDynatraceMonitorLinkableEnv -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Region <String>] [-TenantId <String>] [-UserPrincipal <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```


#### Get-AzDynatraceMonitorResource

#### SYNOPSIS
List the resources currently being monitored by the Dynatrace monitor resource.

#### SYNTAX

```powershell
Get-AzDynatraceMonitorResource -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzDynatraceMonitorSSOConfig

#### SYNOPSIS
Create a DynatraceSingleSignOnResource

#### SYNTAX

```powershell
New-AzDynatraceMonitorSSOConfig -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AadDomain <String[]>] [-EnterpriseAppId <String>]
 [-SingleSignOnState <SingleSignOnStates>] [-SingleSignOnUrl <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Get-AzDynatraceMonitorSSOConfig

#### SYNOPSIS
Get a DynatraceSingleSignOnResource

#### SYNTAX

+ List (Default)
```powershell
Get-AzDynatraceMonitorSSOConfig -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzDynatraceMonitorSSOConfig -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzDynatraceMonitorSSOConfig -InputObject <IDynatraceObservabilityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```


#### Get-AzDynatraceMonitorSSODetail

#### SYNOPSIS
Gets the SSO configuration details from the partner.

#### SYNTAX

```powershell
Get-AzDynatraceMonitorSSODetail -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-UserPrincipal <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### New-AzDynatraceMonitorTagRule

#### SYNOPSIS
Create a TagRule

#### SYNTAX

```powershell
New-AzDynatraceMonitorTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog <SendAadLogsStatus>]
 [-LogRuleSendActivityLog <SendActivityLogsStatus>] [-LogRuleSendSubscriptionLog <SendSubscriptionLogsStatus>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```


#### Get-AzDynatraceMonitorTagRule

#### SYNOPSIS
Get a TagRule

#### SYNTAX

+ List (Default)
```powershell
Get-AzDynatraceMonitorTagRule -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzDynatraceMonitorTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzDynatraceMonitorTagRule -InputObject <IDynatraceObservabilityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```


#### Remove-AzDynatraceMonitorTagRule

#### SYNOPSIS
Delete a TagRule

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzDynatraceMonitorTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzDynatraceMonitorTagRule -InputObject <IDynatraceObservabilityIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```


#### Update-AzDynatraceMonitorTagRule

#### SYNOPSIS
Update a TagRule

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzDynatraceMonitorTagRule -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog <SendAadLogsStatus>]
 [-LogRuleSendActivityLog <SendActivityLogsStatus>] [-LogRuleSendSubscriptionLog <SendSubscriptionLogsStatus>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzDynatraceMonitorTagRule -InputObject <IDynatraceObservabilityIdentity>
 [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog <SendAadLogsStatus>]
 [-LogRuleSendActivityLog <SendActivityLogsStatus>] [-LogRuleSendSubscriptionLog <SendSubscriptionLogsStatus>]
 [-MetricRuleFilteringTag <IFilteringTag[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```


#### Get-AzDynatraceMonitorVMHostPayload

#### SYNOPSIS
Returns the payload that needs to be passed in the request body for installing Dynatrace agent on a VM.

#### SYNTAX

```powershell
Get-AzDynatraceMonitorVMHostPayload -MonitorName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```


