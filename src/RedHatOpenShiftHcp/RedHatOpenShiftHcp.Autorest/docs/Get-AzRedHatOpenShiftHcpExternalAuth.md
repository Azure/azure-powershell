---
external help file:
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/get-azredhatopenshifthcpexternalauth
schema: 2.0.0
---

# Get-AzRedHatOpenShiftHcpExternalAuth

## SYNOPSIS
Get a ExternalAuth

## SYNTAX

### List (Default)
```
Get-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzRedHatOpenShiftHcpExternalAuth -InputObject <IRedHatOpenShiftHcpIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityHcpOpenShiftCluster
```
Get-AzRedHatOpenShiftHcpExternalAuth -HcpOpenShiftClusterInputObject <IRedHatOpenShiftHcpIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a ExternalAuth

## EXAMPLES

### Example 1: List the external auths on a cluster
```powershell
Get-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… Succeeded
```

Lists every `ExternalAuth` configured on the cluster.
A cluster typically has a single external auth that configures the external OIDC identity provider.

### Example 2: Get a single external auth by name
```powershell
Get-AzRedHatOpenShiftHcpExternalAuth -ResourceGroupName myResourceGroup `
  -HcpOpenShiftClusterName myCluster -Name myExternalAuth
```

```output
Name            Issuer                                                                   ProvisioningState
----            ------                                                                   -----------------
myExternalAuth  https://login.microsoftonline.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/… Succeeded
```

Reads a single external auth by name.
The returned object also exposes `.IssuerAudience`, `.ClientProfile`, and the claim-mapping fields (`.ClaimMappingUsernameClaim`, `.ClaimMappingGroupClaim`) for inspecting the full OIDC configuration.

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

### -HcpOpenShiftClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: GetViaIdentityHcpOpenShiftCluster
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
Parameter Sets: Get, List
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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ExternalAuth

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityHcpOpenShiftCluster
Aliases: ExternalAuthName

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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IExternalAuth

## NOTES

## RELATED LINKS

