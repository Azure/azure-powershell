---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/update-azsecurityconnector
schema: 2.0.0
---

# Update-AzSecurityConnector

## SYNOPSIS
Updates a security connector

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSecurityConnector -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-EnvironmentData <ISecurityConnectorEnvironment>] [-EnvironmentName <String>] [-Etag <String>]
 [-HierarchyIdentifier <String>] [-Kind <String>] [-Location <String>] [-Offering <ICloudOffering[]>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSecurityConnector -InputObject <ISecurityIdentity> [-EnvironmentData <ISecurityConnectorEnvironment>]
 [-EnvironmentName <String>] [-Etag <String>] [-HierarchyIdentifier <String>] [-Kind <String>]
 [-Location <String>] [-Offering <ICloudOffering[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a security connector

## EXAMPLES

### Example 1
```powershell
Update-AzSecurityConnector -ResourceGroupName "securityConnectors-pwsh-tmp" -Name "ado-sdk-pwsh-test03" -Tag @{myTag="v1"}
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

### -EnvironmentData
The security connector environment data.
.

```yaml
Type: ISecurityConnectorEnvironment
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentName
The multi cloud resource's cloud name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
Entity tag is used for comparing two or more entities from the same requested resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HierarchyIdentifier
The multi cloud resource identifier (account id in case of AWS connector, project number in case of GCP connector).

```yaml
Type: String
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Kind of the resource

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location where the resource is stored

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The security connector name.

```yaml
Type: String
Parameter Sets: UpdateExpanded
Aliases: SecurityConnectorName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Offering
A collection of offerings for the security connector.
.

```yaml
Type: ICloudOffering[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A list of key value pairs that describe the resource.

```yaml
Type: Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.ISecurityConnector
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

ENVIRONMENTDATA \<ISecurityConnectorEnvironment\>: The security connector environment data.
  EnvironmentType \<String\>: The type of the environment data.

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

OFFERING \<ICloudOffering\[\]\>: A collection of offerings for the security connector.
  OfferingType \<String\>: The type of the security offering.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.security/update-azsecurityconnector](https://learn.microsoft.com/powershell/module/az.security/update-azsecurityconnector)

