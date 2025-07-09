---
external help file: Az.ProviderHub-help.xml
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubdefaultrollout
schema: 2.0.0
---

# New-AzProviderHubDefaultRollout

## SYNOPSIS
Create the rollout details.

## SYNTAX

### CreateExpanded (Default)
```
New-AzProviderHubDefaultRollout -RolloutName <String> -ProviderNamespace <String> [-SubscriptionId <String>]
 [-ProvisioningState <String>] [-SpecificationCanaryRegion <String[]>]
 [-SpecificationCanarySkipRegion <String[]>] [-SpecificationHighTrafficRegion <String[]>]
 [-SpecificationHighTrafficWaitDuration <TimeSpan>] [-SpecificationLowTrafficRegion <String[]>]
 [-SpecificationLowTrafficWaitDuration <TimeSpan>] [-SpecificationMediumTrafficRegion <String[]>]
 [-SpecificationMediumTrafficWaitDuration <TimeSpan>]
 [-SpecificationProviderRegistration <IDefaultRolloutSpecificationProviderRegistration>]
 [-SpecificationResourceTypeRegistration <IResourceTypeRegistration[]>]
 [-SpecificationRestOfTheWorldGroupOneRegion <String[]>]
 [-SpecificationRestOfTheWorldGroupOneWaitDuration <TimeSpan>]
 [-SpecificationRestOfTheWorldGroupTwoRegion <String[]>]
 [-SpecificationRestOfTheWorldGroupTwoWaitDuration <TimeSpan>] [-StatusCompletedRegion <String[]>]
 [-StatusFailedOrSkippedRegion <Hashtable>] [-StatusNextTrafficRegion <String>]
 [-StatusNextTrafficRegionScheduledTime <DateTime>] [-StatusSubscriptionReregistrationResult <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzProviderHubDefaultRollout -RolloutName <String> -ProviderNamespace <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzProviderHubDefaultRollout -RolloutName <String> -ProviderNamespace <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityProviderRegistrationExpanded
```
New-AzProviderHubDefaultRollout -RolloutName <String> -ProviderRegistrationInputObject <IProviderHubIdentity>
 [-ProvisioningState <String>] [-SpecificationCanaryRegion <String[]>]
 [-SpecificationCanarySkipRegion <String[]>] [-SpecificationHighTrafficRegion <String[]>]
 [-SpecificationHighTrafficWaitDuration <TimeSpan>] [-SpecificationLowTrafficRegion <String[]>]
 [-SpecificationLowTrafficWaitDuration <TimeSpan>] [-SpecificationMediumTrafficRegion <String[]>]
 [-SpecificationMediumTrafficWaitDuration <TimeSpan>]
 [-SpecificationProviderRegistration <IDefaultRolloutSpecificationProviderRegistration>]
 [-SpecificationResourceTypeRegistration <IResourceTypeRegistration[]>]
 [-SpecificationRestOfTheWorldGroupOneRegion <String[]>]
 [-SpecificationRestOfTheWorldGroupOneWaitDuration <TimeSpan>]
 [-SpecificationRestOfTheWorldGroupTwoRegion <String[]>]
 [-SpecificationRestOfTheWorldGroupTwoWaitDuration <TimeSpan>] [-StatusCompletedRegion <String[]>]
 [-StatusFailedOrSkippedRegion <Hashtable>] [-StatusNextTrafficRegion <String>]
 [-StatusNextTrafficRegionScheduledTime <DateTime>] [-StatusSubscriptionReregistrationResult <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create the rollout details.

## EXAMPLES

### Example 1: Create a resource provider default rollout.
```powershell
New-AzProviderHubDefaultRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "defaultRollout2021w10" -SpecificationCanarySkipRegion "brazilus" -NoWait
```

```output
Name                      Type
----                      ----
defaultRollout2021w10     Microsoft.ProviderHub/providerRegistrations/defaultRollouts
```

Create a resource provider default rollout.

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

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderRegistrationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity
Parameter Sets: CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProvisioningState
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RolloutName
The rollout name.

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

### -SpecificationCanaryRegion
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationCanarySkipRegion
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationHighTrafficRegion
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationHighTrafficWaitDuration
.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationLowTrafficRegion
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationLowTrafficWaitDuration
.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationMediumTrafficRegion
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationMediumTrafficWaitDuration
.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationProviderRegistration
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IDefaultRolloutSpecificationProviderRegistration
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationResourceTypeRegistration
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IResourceTypeRegistration[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationRestOfTheWorldGroupOneRegion
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationRestOfTheWorldGroupOneWaitDuration
.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationRestOfTheWorldGroupTwoRegion
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpecificationRestOfTheWorldGroupTwoWaitDuration
.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusCompletedRegion
.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusFailedOrSkippedRegion
Dictionary of \<ExtendedErrorInfo\>

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusNextTrafficRegion
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusNextTrafficRegionScheduledTime
.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatusSubscriptionReregistrationResult
.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProviderRegistrationExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IProviderHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.IDefaultRollout

## NOTES

## RELATED LINKS
