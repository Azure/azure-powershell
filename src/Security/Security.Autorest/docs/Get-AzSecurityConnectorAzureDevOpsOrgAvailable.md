---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorazuredevopsorgavailable
schema: 2.0.0
---

# Get-AzSecurityConnectorAzureDevOpsOrgAvailable

## SYNOPSIS
Returns a list of all Azure DevOps organizations accessible by the user token consumed by the connector.

## SYNTAX

```
Get-AzSecurityConnectorAzureDevOpsOrgAvailable -ResourceGroupName <String> -SecurityConnectorName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Returns a list of all Azure DevOps organizations accessible by the user token consumed by the connector.

## EXAMPLES

### Example 1: List available AzureDevOps organizations for onboarding
```powershell
Get-AzSecurityConnectorAzureDevOpsOrgAvailable -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01
```

```output
ActionableRemediation           : {
                                    "state": "Enabled",
                                    "categoryConfigurations": [
                                      {
                                        "minimumSeverityLevel": "High",
                                        "category": "IaC"
                                      }
                                    ],
                                    "branchConfiguration": {
                                      "branchNames": [ ],
                                      "annotateDefaultBranch": "Enabled"
                                    },
                                    "inheritFromParentState": "Disabled"
                                  }
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default/azureDevOpsOrgs/dfdsdktests
Name                            : dfdsdktests
OnboardingState                 : Onboarded
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : OK
ProvisioningStatusUpdateTimeUtc : 2/23/2024 6:49:40 PM
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsOrgListResponse

## NOTES

## RELATED LINKS

