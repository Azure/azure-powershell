---
external help file: Az.StreamAnalytics-help.xml
Module Name: Az.StreamAnalytics
online version: https://learn.microsoft.com/powershell/module/az.streamanalytics/get-azstreamanalyticsoutput
schema: 2.0.0
---

# Get-AzStreamAnalyticsOutput

## SYNOPSIS
Gets details about the specified output.

## SYNTAX

### List (Default)
```
Get-AzStreamAnalyticsOutput -JobName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Select <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStreamAnalyticsOutput -JobName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStreamAnalyticsOutput -InputObject <IStreamAnalyticsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets details about the specified output.

## EXAMPLES

### Example 1: Get information about job outputs
```powershell
Get-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh
```

```output
Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs
```

This command returns information about the outputs defined on the job.

### Example 2: Get information about a specific job output
```powershell
Get-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name output-01
```

```output
Name      Type                                            ETag
----      ----                                            ----
output-01 Microsoft.StreamAnalytics/streamingjobs/outputs 3819fb65-07f5-4dc3-83e1-d3149596f8d0
```

This command returns information about the output defined on the job.

### Example 3: Get information about a specific job output by pipeline
```powershell
New-AzStreamAnalyticsOutput -ResourceGroupName azure-rg-test -JobName sajob-01-portal -Name output-05 -File .\test\template-json\StroageAccount.json | Get-AzStreamAnalyticsOutput
```

```output
Name      Type                                            ETag
----      ----                                            ----
output-05 Microsoft.StreamAnalytics/streamingjobs/outputs 3a11e210-2a7f-4856-8d5a-25d4ecabee06
```

This command returns information about the output defined on the job.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobName
The name of the streaming job.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the output.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: OutputName

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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Select
The $select OData query parameter.
This is a comma-separated list of structural properties to include in the response, or "*" to include all properties.
By default, all properties are returned except diagnostics.
Currently only accepts '*' as a valid value.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IOutput

## NOTES

## RELATED LINKS
