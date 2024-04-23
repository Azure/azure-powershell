---
external help file: Az.Websites-help.xml
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/get-azwebapptriggeredwebjob
schema: 2.0.0
---

# Get-AzWebAppTriggeredWebJob

## SYNOPSIS
Get or list triggered web for an app.

## SYNTAX

### List (Default)
```
Get-AzWebAppTriggeredWebJob -AppName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzWebAppTriggeredWebJob -AppName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWebAppTriggeredWebJob -InputObject <IWebsitesIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get or list triggered web for an app.

## EXAMPLES

### Example 1: List triggered webs for an app
```powershell
Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01
```

```output
Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test   
appService-test01/triggeredjob-02                 webjob-rg-test
```

This command lists triggered webs for an app.

### Example 2: Get triggered web for an app
```powershell
Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01
```

```output
Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test
```

This command gets triggered web for an app.

### Example 3: Get triggered web for an app by pipeline
```powershell
$webjob = Get-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01
Start-AzWebAppTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -Name triggeredjob-01 
$webjob.Id | Get-AzWebAppTriggeredWebJob
```

```output
Name                              Kind WebJobType ResourceGroupName
----                              ---- ---------- -----------------
appService-test01/triggeredjob-01                 webjob-rg-test
```

This command gets triggered web for an app by pipeline.

## PARAMETERS

### -AppName
Site name.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Web Job.

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Get, GetViaIdentity
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
Name of the resource group to which the resource belongs.

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

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

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

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.IWebsitesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20210201.ITriggeredWebJob

## NOTES

## RELATED LINKS
