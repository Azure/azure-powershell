---
external help file: Az.NewRelic-help.xml
Module Name: Az.NewRelic
online version: https://learn.microsoft.com/powershell/module/az.newrelic/initialize-aznewrelicsaasresource
schema: 2.0.0
---

# Initialize-AzNewRelicSaaSResource

## SYNOPSIS
Resolve the token to get the SaaS resource ID and activate the SaaS resource

## SYNTAX

### ActivateExpanded (Default)
```
Initialize-AzNewRelicSaaSResource [-SubscriptionId <String>] -PublisherId <String> -SaasGuid <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Activate
```
Initialize-AzNewRelicSaaSResource [-SubscriptionId <String>] -Request <IActivateSaaSParameterRequest>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaJsonFilePath
```
Initialize-AzNewRelicSaaSResource [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaJsonString
```
Initialize-AzNewRelicSaaSResource [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Resolve the token to get the SaaS resource ID and activate the SaaS resource

## EXAMPLES

### Example 1: Initialize SaaS resource with publisher ID and SaaS GUID
```powershell
Initialize-AzNewRelicSaaSResource -PublisherId "newrelicinc1234567891234" -SaasGuid "12345678-1234-1234-1234-123456789abc"
```

```output
SaasResourceId           : /subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/rg-newrelic/providers/NewRelic.Observability/monitors/newrelic-monitor-01/saasResources/12345678-1234-1234-1234-123456789abc
SaasResourceName         : newrelic-monitor-01
SaasResourceState        : Active
MarketplaceSubscriptionId: 12345678-1234-1234-1234-123456789abc
PlanId                   : newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234
```

Initialize a NewRelic SaaS resource using the publisher ID and SaaS GUID to activate the marketplace subscription

### Example 2: Initialize SaaS resource using a request object
```powershell
$saasRequest = [Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.ActivateSaaSParameterRequest]@{
    PublisherId = "newrelicinc1234567891234"
    SaasGuid = "12345678-1234-1234-1234-123456789abc"
}
Initialize-AzNewRelicSaaSResource -Request $saasRequest
```

```output
SaasResourceId           : /subscriptions/11111111-2222-3333-4444-555555555555/resourceGroups/rg-newrelic/providers/NewRelic.Observability/monitors/newrelic-monitor-01/saasResources/12345678-1234-1234-1234-123456789abc
SaasResourceName         : newrelic-monitor-01
SaasResourceState        : Active
MarketplaceSubscriptionId: 12345678-1234-1234-1234-123456789abc
PlanId                   : newrelicpaygtestplan2@123456789123456@PUBIDnewrelicinc1234567891234
```

Initialize a NewRelic SaaS resource by providing a request object containing the publisher ID and SaaS GUID

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

### -JsonFilePath
Path of Json file supplied to the Activate operation

```yaml
Type: System.String
Parameter Sets: ActivateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Activate operation

```yaml
Type: System.String
Parameter Sets: ActivateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublisherId
Publisher Id for NewRelic resource

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
SaaS guid & PublishedId for Activate and Validate SaaS Resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IActivateSaaSParameterRequest
Parameter Sets: Activate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SaasGuid
SaaS guid for Activate and Validate SaaS Resource

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.IActivateSaaSParameterRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NewRelic.Models.ISaaSResourceDetailsResponse

## NOTES

## RELATED LINKS
