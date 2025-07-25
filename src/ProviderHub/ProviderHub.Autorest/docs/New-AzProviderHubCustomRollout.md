---
external help file:
Module Name: Az.ProviderHub
online version: https://learn.microsoft.com/powershell/module/az.providerhub/new-azproviderhubcustomrollout
schema: 2.0.0
---

# New-AzProviderHubCustomRollout

## SYNOPSIS
Create the rollout details.

## SYNTAX

### CreateExpanded (Default)
```
New-AzProviderHubCustomRollout -ProviderNamespace <String> -RolloutName <String> [-SubscriptionId <String>]
 [-ProvisioningState <String>] [-SpecificationCanaryRegion <String[]>]
 [-SpecificationProviderRegistration <ICustomRolloutSpecificationProviderRegistration>]
 [-SpecificationResourceTypeRegistration <IResourceTypeRegistration[]>] [-StatusCompletedRegion <String[]>]
 [-StatusFailedOrSkippedRegion <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityProviderRegistrationExpanded
```
New-AzProviderHubCustomRollout -ProviderRegistrationInputObject <IProviderHubIdentity> -RolloutName <String>
 [-ProvisioningState <String>] [-SpecificationCanaryRegion <String[]>]
 [-SpecificationProviderRegistration <ICustomRolloutSpecificationProviderRegistration>]
 [-SpecificationResourceTypeRegistration <IResourceTypeRegistration[]>] [-StatusCompletedRegion <String[]>]
 [-StatusFailedOrSkippedRegion <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzProviderHubCustomRollout -ProviderNamespace <String> -RolloutName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzProviderHubCustomRollout -ProviderNamespace <String> -RolloutName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the rollout details.

## EXAMPLES

### Example 1: Create a resource provider custom rollout.
```powershell
New-AzProviderHubCustomRollout -ProviderNamespace "Microsoft.Contoso" -RolloutName "customRollout1" -SpecificationCanaryRegion "Eastus2EUAP"
```

```output
Name                Type
----                ----
customRollout1      Microsoft.ProviderHub/providerRegistrations/customRollouts
```

Create a resource provider custom rollout.

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

### -ProviderNamespace
The name of the resource provider hosted within ProviderHub.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### -SpecificationProviderRegistration
.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ICustomRolloutSpecificationProviderRegistration
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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.ICustomRollout

## NOTES

## RELATED LINKS

