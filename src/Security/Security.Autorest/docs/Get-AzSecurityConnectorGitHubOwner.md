---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorgithubowner
schema: 2.0.0
---

# Get-AzSecurityConnectorGitHubOwner

## SYNOPSIS
Returns a monitored GitHub owner.

## SYNTAX

### List (Default)
```
Get-AzSecurityConnectorGitHubOwner -ResourceGroupName <String> -SecurityConnectorName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSecurityConnectorGitHubOwner -OwnerName <String> -ResourceGroupName <String>
 -SecurityConnectorName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSecurityConnectorGitHubOwner -InputObject <ISecurityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns a monitored GitHub owner.

## EXAMPLES

### Example 1: Get discovered GitHub owner by name
```powershell
Get-AzSecurityConnectorGitHubOwner -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gh-01 -OwnerName dfdsdktests
```

```output
GitHubInternalId                : 45003365
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-gh-01/devops/default/gitHubOwners/dfdsdktests
Name                            : dfdsdktests
OnboardingState                 : Onboarded
OwnerUrl                        : https://github.com/dfdsdktests
ProvisioningState               : Pending
ProvisioningStatusMessage       : Beginning provisioning of GitHub connector.
ProvisioningStatusUpdateTimeUtc : 2/23/2024 8:46:22 PM
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/gitHubOwners
```



### Example 2: List discovered GitHub owners
```powershell
Get-AzSecurityConnectorGitHubOwner -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gh-01
```

```output
Name              ResourceGroupName
----              -----------------
dfdsdktests       dfdtest-sdk
dfdsdktests2      dfdtest-sdk
```



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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OwnerName
The GitHub owner name.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityConnectorName
The security connector name.

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
Azure subscription ID

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IGitHubOwner

## NOTES

## RELATED LINKS

