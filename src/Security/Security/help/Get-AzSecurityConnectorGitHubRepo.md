---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorgithubrepo
schema: 2.0.0
---

# Get-AzSecurityConnectorGitHubRepo

## SYNOPSIS
Returns a monitored GitHub repository.

## SYNTAX

### List (Default)
```
Get-AzSecurityConnectorGitHubRepo -OwnerName <String> -ResourceGroupName <String>
 -SecurityConnectorName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSecurityConnectorGitHubRepo -OwnerName <String> -RepoName <String> -ResourceGroupName <String>
 -SecurityConnectorName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSecurityConnectorGitHubRepo -InputObject <ISecurityIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns a monitored GitHub repository.

## EXAMPLES

### Example 1
```powershell
Get-AzSecurityConnectorGitHubRepo -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gh-01 -OwnerName dfdsdktests -RepoName TestApp0
```

### Example 2
```powershell
Get-AzSecurityConnectorGitHubRepo -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-gh-01 -OwnerName dfdsdktests
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
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
.

```yaml
Type: ISecurityIdentity
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
Type: String
Parameter Sets: List, Get
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
Type: String
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
Type: String
Parameter Sets: List, Get
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
Type: String
Parameter Sets: List, Get
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
Type: String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IGitHubRepository
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<ISecurityIdentity\>: Identity Parameter
  \[ApiId \<String\>\]: API revision identifier.
Must be unique in the API Management service instance.
Non-current revision has ;rev=n as a suffix where n is the revision number.
  \[GroupFqName \<String\>\]: The GitLab group fully-qualified name.
  \[Id \<String\>\]: Resource identity path
  \[OperationResultId \<String\>\]: The operation result Id.
  \[OrgName \<String\>\]: The Azure DevOps organization name.
  \[OwnerName \<String\>\]: The GitHub owner name.
  \[ProjectName \<String\>\]: The project name.
  \[RepoName \<String\>\]: The repository name.
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
The name is case insensitive.
  \[SecurityConnectorName \<String\>\]: The security connector name.
  \[ServiceName \<String\>\]: The name of the API Management service.
  \[SubscriptionId \<String\>\]: Azure subscription ID

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorgithubrepo](https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorgithubrepo)
