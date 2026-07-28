---
external help file: Az.Napster-help.xml
Module Name: Az.Napster
online version: https://learn.microsoft.com/powershell/module/az.napster/invoke-aznapsterlinkorganizationsaas
schema: 2.0.0
---

# Invoke-AzNapsterLinkOrganizationSaaS

## SYNOPSIS
Links a new SaaS to the Napster organization of the underlying monitor.

## SYNTAX

### LinkExpanded (Default)
```
Invoke-AzNapsterLinkOrganizationSaaS -Organizationname <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-SaaSResourceId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaJsonString
```
Invoke-AzNapsterLinkOrganizationSaaS -Organizationname <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaJsonFilePath
```
Invoke-AzNapsterLinkOrganizationSaaS -Organizationname <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Link
```
Invoke-AzNapsterLinkOrganizationSaaS -Organizationname <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Body <ISaaSData> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### LinkViaIdentityExpanded
```
Invoke-AzNapsterLinkOrganizationSaaS -InputObject <INapsterIdentity> [-SaaSResourceId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### LinkViaIdentity
```
Invoke-AzNapsterLinkOrganizationSaaS -InputObject <INapsterIdentity> -Body <ISaaSData>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Links a new SaaS to the Napster organization of the underlying monitor.

## EXAMPLES

### Example 1: Link a new SaaS to a Napster Organization
```powershell
Invoke-AzNapsterLinkOrganizationSaaS -Organizationname napster-test1 -ResourceGroupName acctest0001 -SubscriptionId 61641157-140c-4b97-b365-30ff76d9f82e -SaaSResourceId "/subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa"
```

```output
Id                            : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/napster.companionapi/organizations/napster-test1
MarketplaceSubscriptionId     : 09fffd7d-d000-4467-cc23-d82b97e9431d
MarketplaceSubscriptionStatus : Subscribed
Name                          : napster-test1
ProvisioningState             : Succeeded
ResourceGroupName             : acctest0001
SaaSResourceId                : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/acctest0001/providers/Microsoft.SaaS/resources/a4fa84fc_dsafsa
Type                          : napster.companionapi/organizations
```

This command links a new SaaS resource to the specified Napster organization.

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
SaaS-related data properties

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.ISaaSData
Parameter Sets: Link, LinkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.INapsterIdentity
Parameter Sets: LinkViaIdentityExpanded, LinkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Link operation

```yaml
Type: System.String
Parameter Sets: LinkViaJsonString
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

### -Organizationname
Name of the Organization resource

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
Aliases:

Required: True
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
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SaaSResourceId
SaaS resource id

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: LinkExpanded, LinkViaJsonString, LinkViaJsonFilePath, Link
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

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.INapsterIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.ISaaSData

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.IOrganizationResource

## NOTES

## RELATED LINKS
