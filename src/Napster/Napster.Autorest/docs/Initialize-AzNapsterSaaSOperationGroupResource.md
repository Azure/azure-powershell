---
external help file:
Module Name: Az.Napster
online version: https://learn.microsoft.com/powershell/module/az.napster/initialize-aznapstersaasoperationgroupresource
schema: 2.0.0
---

# Initialize-AzNapsterSaaSOperationGroupResource

## SYNOPSIS
Resolve the token to get the SaaS resource ID and activate the SaaS resource

## SYNTAX

### ActivateExpanded (Default)
```
Initialize-AzNapsterSaaSOperationGroupResource -SaasGuid <String> [-SubscriptionId <String>]
 [-PublisherId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Activate
```
Initialize-AzNapsterSaaSOperationGroupResource -Body <IActivateSaaSParameterRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ActivateViaJsonFilePath
```
Initialize-AzNapsterSaaSOperationGroupResource -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActivateViaJsonString
```
Initialize-AzNapsterSaaSOperationGroupResource -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Resolve the token to get the SaaS resource ID and activate the SaaS resource

## EXAMPLES

### Example 1: Activate a Napster SaaS resource
```powershell
Initialize-AzNapsterSaaSOperationGroupResource -SubscriptionId "61641157-140c-4b97-b365-30ff76d9f82e" -SaasGuid "00000000-0000-0000-0000-000000000000" -PublisherId "touchcastinc1655995956899"
```

This command resolves the marketplace SaaS token and activates the underlying Napster SaaS resource for the given publisher in the specified subscription.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
SaaS guid & PublishedId for Activate and Validate SaaS Resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.IActivateSaaSParameterRequest
Parameter Sets: Activate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublisherId
Publisher Id for Napster resource

```yaml
Type: System.String
Parameter Sets: ActivateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.IActivateSaaSParameterRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Napster.Models.ISaaSResourceDetailsResponse

## NOTES

## RELATED LINKS

