---
external help file: Az.RedHatOpenShiftHcp-help.xml
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/update-azredhatopenshifthcpexternalauth
schema: 2.0.0
---

# Update-AzRedHatOpenShiftHcpExternalAuth

## SYNOPSIS
Update a ExternalAuth

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ClaimValidationRule <ITokenClaimValidationRule[]>]
 [-ClientProfile <IExternalAuthClientProfile[]>] [-GroupClaim <String>] [-GroupPrefix <String>]
 [-IssuerAudience <String[]>] [-IssuerCa <String>] [-IssuerUrl <String>] [-UsernameClaim <String>]
 [-UsernamePrefix <String>] [-UsernamePrefixPolicy <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Property <IExternalAuthUpdate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityHcpOpenShiftClusterExpanded
```
Update-AzRedHatOpenShiftHcpExternalAuth -Name <String>
 -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity>
 [-ClaimValidationRule <ITokenClaimValidationRule[]>] [-ClientProfile <IExternalAuthClientProfile[]>]
 [-GroupClaim <String>] [-GroupPrefix <String>] [-IssuerAudience <String[]>] [-IssuerCa <String>]
 [-IssuerUrl <String>] [-UsernameClaim <String>] [-UsernamePrefix <String>] [-UsernamePrefixPolicy <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityHcpOpenShiftCluster
```
Update-AzRedHatOpenShiftHcpExternalAuth -Name <String>
 -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity> -Property <IExternalAuthUpdate>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzRedHatOpenShiftHcpExternalAuth -InputObject <IRedHatOpenShiftHcpIdentity>
 [-ClaimValidationRule <ITokenClaimValidationRule[]>] [-ClientProfile <IExternalAuthClientProfile[]>]
 [-GroupClaim <String>] [-GroupPrefix <String>] [-IssuerAudience <String[]>] [-IssuerCa <String>]
 [-IssuerUrl <String>] [-UsernameClaim <String>] [-UsernamePrefix <String>] [-UsernamePrefixPolicy <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzRedHatOpenShiftHcpExternalAuth -InputObject <IRedHatOpenShiftHcpIdentity>
 -Property <IExternalAuthUpdate> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a ExternalAuth

## EXAMPLES

### Example 1: Change the username claim mapping
```powershell
Update-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth `
  -UsernameClaim 'preferred_username'
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… AwaitingSecret
```

Patches the existing external auth so the cluster maps the `preferred_username` token claim (instead of `email`) to the Kubernetes username.
The Confidential console client keeps the resource in `AwaitingSecret` until its in-cluster secret is supplied.

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

### -ClaimValidationRule
The claim validation rules

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.ITokenClaimValidationRule[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientProfile
External Auth OIDC clientsThere must not be more than 20 entries and entries must have unique namespace/name pairs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IExternalAuthClientProfile[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
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

### -GroupClaim
Claim name of the external profile

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupPrefix
Prefix for the claim external profileIf this is specified prefixPolicy will be set to "Prefix" by default

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HcpOpenShiftClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityHcpOpenShiftCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HcpOpenShiftClusterName
The name of the HcpOpenShiftCluster

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IssuerAudience
This configures the acceptable audiences the JWT token, issued by the identityprovider, must be issued to.
At least one of the entries must match the'aud' claim in the JWT token.audiences must contain at least one entry and must not exceed ten entries.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IssuerCa
The issuer of the tokenCertificate bundle to use to validate server certificates for the configured URL.It must be PEM encoded and when not specified, the system trust is used.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IssuerUrl
This configures the URL used to issue tokens by the identity provider.The Kubernetes API server determines how authentication tokens should be handledby matching the 'iss' claim in the JWT to the issuerURL of configured identity providers.issuerURL must use the 'https' scheme.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ExternalAuth

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityHcpOpenShiftCluster
Aliases: ExternalAuthName

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

### -Property
ExternalAuth resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IExternalAuthUpdate
Parameter Sets: Update, UpdateViaIdentityHcpOpenShiftCluster, UpdateViaIdentity
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsernameClaim
Claim name of the external profile

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsernamePrefix
Prefix for the claim external profileMust be set when the prefixPolicy field is set to 'Prefix' and must be unsetotherwise.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsernamePrefixPolicy
Prefix policy is an optional field that configures how a prefix should beapplied to the value of the JWT claim specified in the 'claim' field.Allowed values are 'Prefix', 'NoPrefix', and 'None'.
If not specified, thedefault policy is 'None'.When set to 'Prefix', the value specified in the prefix field will beprepended to the value of the JWT claim.The prefix field must be set when prefixPolicy is 'Prefix'.When set to 'NoPrefix', no prefix will be prepended to the valueof the JWT claim.When set to 'None', this means no opinion and the platform is left to chooseany prefixes that are applied which is subject to change over time.Currently, the platform prepends `{issuerURL}#` to the value of the JWT claimwhen the claim is not 'email'.As an example, consider the following scenario:`prefix` is unset, `issuerURL` is set to `https://myoidc.tld`,the JWT claims include "username":"userA" and "email":"userA

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityHcpOpenShiftClusterExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IExternalAuthUpdate

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IExternalAuth

## NOTES

## RELATED LINKS
