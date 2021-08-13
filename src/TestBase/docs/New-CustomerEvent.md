---
external help file:
Module Name: TestBase
online version: https://docs.microsoft.com/en-us/powershell/module/testbase/new-customerevent
schema: 2.0.0
---

# New-CustomerEvent

## SYNOPSIS
Create or replace a Test Base Customer Event.

## SYNTAX

### CreateExpanded (Default)
```
New-CustomerEvent -CustomerEventName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -TestBaseAccountName <String> [-EventName <String>] [-Receivers <INotificationEventReceiver[]>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-CustomerEvent -CustomerEventName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -TestBaseAccountName <String> -Parameters <ICustomerEventResource> [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-CustomerEvent -InputObject <ITestBaseIdentity> -Parameters <ICustomerEventResource> [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-CustomerEvent -InputObject <ITestBaseIdentity> [-EventName <String>]
 [-Receivers <INotificationEventReceiver[]>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or replace a Test Base Customer Event.

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

### -CustomerEventName
The resource name of the Test Base Customer event.

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

### -EventName
The name of the event subscribed to.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Sample.API.Models.ITestBaseIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Parameters
The Customer Notification Event resource.
To construct, see NOTES section for PARAMETERS properties and create a hash table.

```yaml
Type: Sample.API.Models.ICustomerEventResource
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Receivers
The notification event receivers.
To construct, see NOTES section for RECEIVERS properties and create a hash table.

```yaml
Type: Sample.API.Models.INotificationEventReceiver[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.

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

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string.

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

### -TestBaseAccountName
The resource name of the Test Base Account.

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

### Sample.API.Models.ICustomerEventResource

### Sample.API.Models.ITestBaseIdentity

## OUTPUTS

### Sample.API.Models.ICustomerEventResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ITestBaseIdentity>: Identity Parameter
  - `[AnalysisResultName <AnalysisResultName?>]`: The name of the Analysis Result of a Test Result.
  - `[AvailableOSResourceName <String>]`: The resource name of an Available OS.
  - `[CustomerEventName <String>]`: The resource name of the Test Base Customer event.
  - `[EmailEventResourceName <String>]`: The resource name of an email event.
  - `[FavoriteProcessResourceName <String>]`: The resource name of a favorite process in a package. If the process name contains characters that are not allowed in Azure Resource Name, we use 'actualProcessName' in request body to submit the name.
  - `[FlightingRingResourceName <String>]`: The resource name of a flighting ring.
  - `[OSUpdateResourceName <String>]`: The resource name of an OS Update.
  - `[PackageName <String>]`: The resource name of the Test Base Package.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource.
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string.
  - `[TestBaseAccountName <String>]`: The resource name of the Test Base Account.
  - `[TestResultName <String>]`: The Test Result Name. It equals to {osName}-{TestResultId} string.
  - `[TestSummaryName <String>]`: The name of the Test Summary.
  - `[TestTypeResourceName <String>]`: The resource name of a test type.

PARAMETERS <ICustomerEventResource>: The Customer Notification Event resource.
  - `[AzureAsyncOperation <String>]`: 
  - `[EventName <String>]`: The name of the event subscribed to.
  - `[Receivers <INotificationEventReceiver[]>]`: The notification event receivers.
    - `[DistributionGroupListReceiverValueDistributionGroups <String[]>]`: The list of distribution groups.
    - `[ReceiverType <String>]`: The type of the notification event receiver.
    - `[SubscriptionReceiverValueRole <String>]`: The role of the notification receiver.
    - `[SubscriptionReceiverValueSubscriptionId <String>]`: The subscription id of the notification receiver.
    - `[SubscriptionReceiverValueSubscriptionName <String>]`: The subscription name of the notification receiver.
    - `[UserObjectReceiverValueUserObjectIds <String[]>]`: user object ids.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The type of identity that last modified the resource.
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

RECEIVERS <INotificationEventReceiver[]>: The notification event receivers.
  - `[DistributionGroupListReceiverValueDistributionGroups <String[]>]`: The list of distribution groups.
  - `[ReceiverType <String>]`: The type of the notification event receiver.
  - `[SubscriptionReceiverValueRole <String>]`: The role of the notification receiver.
  - `[SubscriptionReceiverValueSubscriptionId <String>]`: The subscription id of the notification receiver.
  - `[SubscriptionReceiverValueSubscriptionName <String>]`: The subscription name of the notification receiver.
  - `[UserObjectReceiverValueUserObjectIds <String[]>]`: user object ids.

## RELATED LINKS

