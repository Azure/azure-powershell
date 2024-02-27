---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/invoke-azsecurityapicollectionapimoffboard
schema: 2.0.0
---

# Invoke-AzSecurityApiCollectionApimOffboard

## SYNOPSIS
Offboard an Azure API Management API from Microsoft Defender for APIs.
The system will stop monitoring the operations within the Azure API Management API for intrusive behaviors.

## SYNTAX

### Delete (Default)
```
Invoke-AzSecurityApiCollectionApimOffboard -ApiId <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Invoke-AzSecurityApiCollectionApimOffboard -InputObject <ISecurityIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Offboard an Azure API Management API from Microsoft Defender for APIs.
The system will stop monitoring the operations within the Azure API Management API for intrusive behaviors.

## EXAMPLES

### EXAMPLE 1
```
Invoke-AzSecurityApiCollectionApimOffboard -ResourceGroupName "apicollectionstests" -ServiceName "demoapimservice2" -ApiId "echo-api-2"
```

## PARAMETERS

### -ApiId
API revision identifier.
Must be unique in the API Management service instance.
Non-current revision has ;rev=n as a suffix where n is the revision number.

```yaml
Type: String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the API Management service.

```yaml
Type: String
Parameter Sets: Delete
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
Type: String
Parameter Sets: Delete
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityIdentity
## OUTPUTS

### System.Boolean
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

[https://learn.microsoft.com/powershell/module/az.security/invoke-azsecurityapicollectionapimoffboard](https://learn.microsoft.com/powershell/module/az.security/invoke-azsecurityapicollectionapimoffboard)

