---
external help file: Az.Advisor-help.xml
Module Name: Az.Advisor
online version: https://learn.microsoft.com/powershell/module/az.advisor/Get-AzAdvisorRecommendation
schema: 2.0.0
---

# Get-AzAdvisorRecommendation

## SYNOPSIS
Obtains details of a cached recommendation.

## SYNTAX

### ListByFilter (Default)
```
Get-AzAdvisorRecommendation [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ListById
```
Get-AzAdvisorRecommendation [-SubscriptionId <String[]>] [-Category <String>] -ResourceId <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ListByName
```
Get-AzAdvisorRecommendation [-SubscriptionId <String[]>] -ResourceGroupName <String> [-Category <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetById
```
Get-AzAdvisorRecommendation -Id <String> -ResourceUri <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzAdvisorRecommendation -InputObject <IAdvisorIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Obtains details of a cached recommendation.

## EXAMPLES

### Example 1: List Recommendation by subscriptionId and resource group name
```powershell
Get-AzAdvisorRecommendation -ResourceGroupName lnxtest -Category HighAvailability
```

```output
Name                                 Category         Resource Group Impact ImpactedValue ImpactedField
----                                 --------         -------------- ------ ------------- -------------
71411b72-e7de-9dc2-308b-5c60252e1456 HighAvailability lnxtest        Medium lnxtest-vnet  MICROSOFT.NETWORK/VIRTUALNETWORKS
bf8ebdfd-6caa-9f55-53ae-ffafefbf3a7c HighAvailability lnxtest        Medium advisortest   MICROSOFT.NETWORK/VIRTUALNETWORKS
339071fa-d66a-be4f-9cf8-22b67552b287 HighAvailability lnxtest        Medium advisor-test  MICROSOFT.NETWORK/VIRTUALNETWORKS
```

List Recommendation by subscriptionId

### Example 2: List Recommendation by subscriptionId and filter
```powershell
Get-AzAdvisorRecommendation -filter "Category eq 'HighAvailability' and ResourceGroup eq 'lnxtest'"
```

```output
Name                                 Category         Resource Group Impact ImpactedValue ImpactedField
----                                 --------         -------------- ------ ------------- -------------
71411b72-e7de-9dc2-308b-5c60252e1456 HighAvailability lnxtest        Medium lnxtest-vnet  MICROSOFT.NETWORK/VIRTUALNETWORKS
bf8ebdfd-6caa-9f55-53ae-ffafefbf3a7c HighAvailability lnxtest        Medium advisortest   MICROSOFT.NETWORK/VIRTUALNETWORKS
339071fa-d66a-be4f-9cf8-22b67552b287 HighAvailability lnxtest        Medium advisor-test  MICROSOFT.NETWORK/VIRTUALNETWORKS
```

List Recommendation by subscriptionId and filter

### Example 3: Get Recommendation by Id and resource Id
```powershell
Get-AzAdvisorRecommendation -Id 42963553-61de-5334-2d2e-47f3a0099d41 -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f
```

```output
Name                                 Category Resource Group   Impact ImpactedValue    ImpactedField
----                                 -------- --------------   ------ -------------    -------------
42963553-61de-5334-2d2e-47f3a0099d41 Security automanagehcrprg High   arcbox-capi-mgmt Microsoft.Compute/virtualMachines
```

Get Recommendation by Id and resource Id

## PARAMETERS

### -Category
The category of recommendation.

```yaml
Type: System.String
Parameter Sets: ListById, ListByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Filter
The filter to apply to the recommendations.
Filter can be applied to properties ['ResourceId', 'ResourceGroup', 'RecommendationTypeGuid', '[Category](#category)'] with operators ['eq', 'and', 'or'].
Example:
- $filter=Category eq 'Cost' and ResourceGroup eq 'MyResourceGroup'

```yaml
Type: System.String
Parameter Sets: ListByFilter
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The recommendation ID.

```yaml
Type: System.String
Parameter Sets: GetById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity
Parameter Sets: GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ListByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource Id.

```yaml
Type: System.String
Parameter Sets: ListById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource Manager identifier of the resource to which the recommendation applies.

```yaml
Type: System.String
Parameter Sets: GetById
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: ListByFilter, ListById, ListByName
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

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IResourceRecommendationBase

## NOTES

## RELATED LINKS
