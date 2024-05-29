---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorazuredevopsrepo
schema: 2.0.0
---

# Get-AzSecurityConnectorAzureDevOpsRepo

## SYNOPSIS
Returns a monitored Azure DevOps repository resource.

## SYNTAX

### List (Default)
```
Get-AzSecurityConnectorAzureDevOpsRepo -OrgName <String> -ProjectName <String> -ResourceGroupName <String>
 -SecurityConnectorName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSecurityConnectorAzureDevOpsRepo -OrgName <String> -ProjectName <String> -RepoName <String>
 -ResourceGroupName <String> -SecurityConnectorName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSecurityConnectorAzureDevOpsRepo -InputObject <ISecurityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns a monitored Azure DevOps repository resource.

## EXAMPLES

### Example 1: Get discovered AzureDevOps repository by organization, project and repo name
```powershell
Get-AzSecurityConnectorAzureDevOpsRepo -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01 -OrgName dfdsdktests -ProjectName ContosoSDKDfd -RepoName TestApp0
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
                                    "inheritFromParentState": "Enabled"
                                  }
Id                              : /subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/dfdtest-sdk/providers/Microsoft.Security/securityConnectors/dfdsdktests-azdo-01/devops/default/azureDevOpsOrgs/dfdsdktests/projects/Co 
                                  ntosoSDKDfd/repos/TestApp0
Name                            : TestApp0
OnboardingState                 : Onboarded
ParentOrgName                   : dfdsdktests
ParentProjectName               : ContosoSDKDfd
ProvisioningState               : Succeeded
ProvisioningStatusMessage       : OK
ProvisioningStatusUpdateTimeUtc : 2/23/2024 6:52:44 PM
RepoId                          : 35cd4811-63c7-4043-8587-f0a9cf37709e
RepoUrl                         : https://dev.azure.com/dfdsdktests/ContosoSDKDfd/_git/TestApp0
ResourceGroupName               : dfdtest-sdk
SystemDataCreatedAt             : 
SystemDataCreatedBy             : 
SystemDataCreatedByType         : 
SystemDataLastModifiedAt        : 
SystemDataLastModifiedBy        : 
SystemDataLastModifiedByType    : 
Type                            : Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs/projects/repos
Visibility                      : 
```



### Example 2: List discovered AzureDevOps repositories
```powershell
Get-AzSecurityConnectorAzureDevOpsRepo -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01 -OrgName dfdsdktests -ProjectName ContosoSDKDfd
```

```output
Name          ResourceGroupName
----          -----------------
ContosoSDKDfd dfdtest-sdk
TestApp0      dfdtest-sdk
TestApp2      dfdtest-sdk
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

### -OrgName
The Azure DevOps organization name.

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

### -ProjectName
The project name.

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

### -RepoName
The repository name.

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsRepository

## NOTES

## RELATED LINKS

