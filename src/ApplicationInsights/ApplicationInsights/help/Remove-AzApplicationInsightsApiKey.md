---
external help file: Az.ApplicationInsights-help.xml
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/remove-azapplicationinsightsapikey
schema: 2.0.0
---

# Remove-AzApplicationInsightsApiKey

## SYNOPSIS
Delete an API Key of an Application Insights component.

## SYNTAX

### Delete (Default)
```
Remove-AzApplicationInsightsApiKey -ApiKeyId <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzApplicationInsightsApiKey -InputObject <IApplicationInsightsIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete an API Key of an Application Insights component.

## EXAMPLES

### Example 1: Remove an application insights api key for an application insights resource
```powershell
Remove-AzApplicationInsightsApiKey -ResourceGroupName "testGroup" -Name "test" -ApiKeyId 00001111-aaaa-2222-bbbb-3333cccc4444
```

Remove an application insights api key for an application insights resource

## PARAMETERS

### -ApiKeyId
The API Key ID.
This is unique within a Application Insights component.

```yaml
Type: System.String
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Application Insights component resource.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: ApplicationInsightsComponentName, ComponentName

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
Parameter Sets: Delete
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
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.IApplicationInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501.IApplicationInsightsComponentApiKey

## NOTES

## RELATED LINKS
