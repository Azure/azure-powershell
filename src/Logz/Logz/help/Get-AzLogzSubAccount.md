---
external help file: Az.Logz-help.xml
Module Name: Az.Logz
online version: https://learn.microsoft.com/powershell/module/az.logz/get-azlogzsubaccount
schema: 2.0.0
---

# Get-AzLogzSubAccount

## SYNOPSIS
Get a sub account under a given monitor resource.

## SYNTAX

### List (Default)
```
Get-AzLogzSubAccount -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzLogzSubAccount -MonitorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzLogzSubAccount -InputObject <ILogzIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a sub account under a given monitor resource.

## EXAMPLES

### Example 1: List all sub accounts under a given monitor resource
```powershell
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01
```

```output
Name                MonitoringStatus Location ResourceGroupName
----                ---------------- -------- -----------------
logz01-subaccount01 Enabled          westus2  logz-rg-test
logz01-subaccount02 Enabled          westus2  logz-rg-test
```

This command lists all sub accounts under a given monitor resource.

### Example 2: Get a sub account under a given monitor resource
```powershell
Get-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName logz-portal01 -Name logz01-subaccount01
```

```output
Name                MonitoringStatus Location ResourceGroupName
----                ---------------- -------- -----------------
logz01-subaccount01 Enabled          westus2  logz-rg-test
```

This command gets a sub account under a given monitor resource.

### Example 3: Get a sub account under a given monitor resource by pipeline
```powershell
New-AzLogzSubAccount -ResourceGroupName logz-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 -Location 'westus2' -PlanBillingCycle 'Monthly' -PlanUsageType 'PAYG' -PlanDetail '100gb14days' -PlanEffectiveDate (Get-Date -AsUTC) -UserInfoEmailAddress 'xxxxx@microsoft.com' -UserInfoPhoneNumber 'xxxxxx' -UserInfoFirstName 'xxx' -UserInfoLastName 'xxx' | Get-AzLogzSubAccount
```

```output
Name           MonitoringStatus Location ResourceGroupName
----           ---------------- -------- -----------------
logz-pwshsub01 Enabled          westus2  logz-rg-test
```

This command gets a sub account under a given monitor resource by pipeline.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.ILogzIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

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
Sub Account resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: SubAccountName

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

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.ILogzIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.ILogzMonitorResource

## NOTES

## RELATED LINKS
