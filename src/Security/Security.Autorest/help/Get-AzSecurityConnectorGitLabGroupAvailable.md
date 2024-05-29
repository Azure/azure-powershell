---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorgitlabgroupavailable
schema: 2.0.0
---

# Get-AzSecurityConnectorGitLabGroupAvailable

## SYNOPSIS
Returns a list of all GitLab groups accessible by the user token consumed by the connector.

## SYNTAX

```
Get-AzSecurityConnectorGitLabGroupAvailable -ResourceGroupName <String> -SecurityConnectorName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Returns a list of all GitLab groups accessible by the user token consumed by the connector.

## EXAMPLES

### Example 1: List available GitLab groups for onboarding
```powershell
Get-AzSecurityConnectorGitLabGroupAvailable -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gl-01
```

```output
FullyQualifiedFriendlyName      : Defender for DevOps SDK Tests
FullyQualifiedName              : dfdsdktests
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-gl-01/devops/default/gitLabGroups/dfdsdktests
Name                            : dfdsdktests
OnboardingState                 : Onboarded
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : Resource modification successful.
ProvisioningStatusUpdateTimeUtc : 2/23/2024 10:42:28 PM
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/gitLabGroups
Url                             : https://gitlab.com/groups/dfdsdktests
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SecurityConnectorName
The security connector name.

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

### -SubscriptionId
Azure subscription ID

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IGitLabGroupListResponse

## NOTES

## RELATED LINKS

