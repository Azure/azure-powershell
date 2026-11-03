---
external help file:
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/new-azredhatopenshifthcpexternalauth
schema: 2.0.0
---

# New-AzRedHatOpenShiftHcpExternalAuth

## SYNOPSIS
Create a ExternalAuth

## SYNTAX

### CreateExpanded (Default)
```
New-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ClaimValidationRule <ITokenClaimValidationRule[]>]
 [-ClientProfile <IExternalAuthClientProfile[]>] [-GroupClaim <String>] [-GroupPrefix <String>]
 [-IssuerAudience <String[]>] [-IssuerCa <String>] [-IssuerUrl <String>] [-UsernameClaim <String>]
 [-UsernamePrefix <String>] [-UsernamePrefixPolicy <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> -Resource <IExternalAuth> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityHcpOpenShiftCluster
```
New-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity>
 -Name <String> -Resource <IExternalAuth> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityHcpOpenShiftClusterExpanded
```
New-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity>
 -Name <String> [-ClaimValidationRule <ITokenClaimValidationRule[]>]
 [-ClientProfile <IExternalAuthClientProfile[]>] [-GroupClaim <String>] [-GroupPrefix <String>]
 [-IssuerAudience <String[]>] [-IssuerCa <String>] [-IssuerUrl <String>] [-UsernameClaim <String>]
 [-UsernamePrefix <String>] [-UsernamePrefixPolicy <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a ExternalAuth

## EXAMPLES

### Example 1: Create an external auth trusting Microsoft Entra ID
```powershell
$clientProfile = @(
    @{
        ComponentName                = 'console'
        ComponentAuthClientNamespace = 'openshift-console'
        ClientId                     = 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
        Type                         = 'Confidential'
    }
)

New-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth `
  -IssuerUrl 'https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/v2.0' `
  -IssuerAudience @('xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx') `
  -ClientProfile $clientProfile -UsernameClaim 'email' -GroupClaim 'groups'
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… AwaitingSecret
```

Creates an `ExternalAuth` that points the cluster's kube-apiserver at the given Entra OIDC issuer and maps the `email`/`groups` token claims to users and groups.
The OpenShift web console (`console`/`openshift-console`) must be a `Confidential` client, so the resource provisions to `AwaitingSecret` until its client secret is supplied in-cluster.

### Example 2: Create an external auth with both a console and a CLI client
```powershell
$clientProfile = @(
    @{
        ComponentName                = 'console'
        ComponentAuthClientNamespace = 'openshift-console'
        ClientId                     = 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
        Type                         = 'Confidential'
    },
    @{
        ComponentName                = 'cli'
        ComponentAuthClientNamespace = 'openshift-console'
        ClientId                     = 'yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy'
        Type                         = 'Public'
    }
)

New-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth `
  -IssuerUrl 'https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/v2.0' `
  -IssuerAudience @('xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx','yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy') `
  -ClientProfile $clientProfile -UsernameClaim 'email' -GroupClaim 'groups'
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… AwaitingSecret
```

Registers two OIDC clients on the same external auth: the web console as a `Confidential` client and the `oc` CLI as a `Public` (PKCE) client.
Each `ClientId` must also appear in `-IssuerAudience`.
The Confidential console client leaves the resource in `AwaitingSecret` until its secret is provided in-cluster.

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
The claim validation rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.ITokenClaimValidationRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupPrefix
Prefix for the claim external profile.If this is specified, prefixPolicy will be set to "Prefix" by default.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateViaIdentityHcpOpenShiftCluster, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IssuerAudience
This configures the acceptable audiences for JWT tokens issued by the identity provider.At least one of the entries must match the 'aud' claim in the JWT token.Audiences must contain at least one entry and must not exceed ten entries.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IssuerCa
The issuer of the token.Certificate bundle to use to validate server certificates for the configured URL.It must be PEM encoded and when not specified, the system trust is used.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
The name of the ExternalAuth

```yaml
Type: System.String
Parameter Sets: (All)
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

### -Resource
ExternalAuth resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IExternalAuth
Parameter Sets: Create, CreateViaIdentityHcpOpenShiftCluster
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UsernamePrefix
Prefix for the claim external profile.Must be set when the prefixPolicy field is set to 'Prefix' and must be unsetotherwise.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityHcpOpenShiftClusterExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IExternalAuth

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IExternalAuth

## NOTES

## RELATED LINKS

