---
external help file:
Module Name: Az.Datadog
online version: https://learn.microsoft.com/powershell/module/az.datadog/get-azdatadogcreationsupported
schema: 2.0.0
---

# Get-AzDatadogCreationSupported

## SYNOPSIS
Informs if the current subscription is being already monitored for selected Datadog organization.

## SYNTAX

### Get (Default)
```
Get-AzDatadogCreationSupported -DatadogOrganizationId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDatadogCreationSupported -DatadogOrganizationId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Informs if the current subscription is being already monitored for selected Datadog organization.

## EXAMPLES

### Example 1: Check if Datadog creation is supported
```powershell
Get-AzDatadogCreationSupported -DatadogOrganizationId 11111111-2222-3333-aaaa-3e9a21a119f9
```

```output
CreationSupported Name
----------------- ----
True abc111cd-efhg-1111-bbbb-0e3eb56bef5c
```

Informs if the current subscription is being already monitored for selected Datadog organization.

## PARAMETERS

### -DatadogOrganizationId
Datadog Organization Id

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

### -SubscriptionId
The ID of the target subscription.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.ICreateResourceSupportedResponse

## NOTES

## RELATED LINKS

