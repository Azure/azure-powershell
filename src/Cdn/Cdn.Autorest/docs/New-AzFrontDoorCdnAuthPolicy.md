---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnauthpolicy
schema: 2.0.0
---

# New-AzFrontDoorCdnAuthPolicy

## SYNOPSIS
Create an authorization policy within the specified profile.

## SYNTAX

### CreateExpanded (Default)
```
New-AzFrontDoorCdnAuthPolicy -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Action <String>] [-Association <IAuthPolicyAssociation>]
 [-AuthConfig <IAuthPolicyConfig[]>] [-ForwardTokenToOrigin] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityProfile
```
New-AzFrontDoorCdnAuthPolicy -Name <String> -ProfileInputObject <ICdnIdentity> -Resource <IAuthPolicy>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityProfileExpanded
```
New-AzFrontDoorCdnAuthPolicy -Name <String> -ProfileInputObject <ICdnIdentity> [-Action <String>]
 [-Association <IAuthPolicyAssociation>] [-AuthConfig <IAuthPolicyConfig[]>] [-ForwardTokenToOrigin]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFrontDoorCdnAuthPolicy -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFrontDoorCdnAuthPolicy -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create an authorization policy within the specified profile.

## EXAMPLES

### Example 1: Create a profile-level Microsoft Entra ID authentication policy
```powershell
$authConfig = New-AzFrontDoorCdnAuthPolicyEntraIdConfigObject -Issuer "https://login.microsoftonline.com/00000000-0000-0000-0000-000000000001/v2.0" -Audience "api://myApplication" -AuthLocation Header -AuthLocationSelector "Authorization"
$association = New-AzFrontDoorCdnAuthPolicyAssociationObject -IsProfileLevel $true
New-AzFrontDoorCdnAuthPolicy -ResourceGroupName "myResourceGroup" -ProfileName "myProfile" -Name "myAuthPolicy" -AuthConfig $authConfig -Association $association -Action Block -ForwardTokenToOrigin:$false
```

Creates an authentication policy that validates Microsoft Entra ID tokens for the profile and blocks requests that fail authentication.
Replace the example issuer and audience with your identity provider values.
Token forwarding defaults to true; this example explicitly disables it.

## PARAMETERS

### -Action
Action to apply when authorization fails.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
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

### -Association
Resource associations for the authorization policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAuthPolicyAssociation
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthConfig
Authorization configurations for the policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAuthPolicyConfig[]
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
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

### -ForwardTokenToOrigin
Whether to forward the authentication token to the origin.
Defaults to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityProfileExpanded
Aliases:

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

### -Name
Name of the authorization policy under the profile.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AuthPolicyName

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

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: CreateViaIdentityProfile, CreateViaIdentityProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium or CDN profile which is unique within the resource group.

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

### -Resource
An authorization policy that maps authorization configurations to profile, domain, or route associations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAuthPolicy
Parameter Sets: CreateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAuthPolicy

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IAuthPolicy

## NOTES

## RELATED LINKS
