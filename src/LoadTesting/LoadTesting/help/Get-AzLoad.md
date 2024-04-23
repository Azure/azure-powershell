---
external help file: Az.LoadTesting-help.xml
Module Name: Az.LoadTesting
online version: https://learn.microsoft.com/powershell/module/az.loadtesting/get-azload
schema: 2.0.0
---

# Get-AzLoad

## SYNOPSIS
Get the details of an Azure Load Testing resource.

## SYNTAX

### List (Default)
```
Get-AzLoad [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzLoad [-SubscriptionId <String[]>] -Name <String> -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzLoad [-SubscriptionId <String[]>] -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the details of an Azure Load Testing resource.

## EXAMPLES

### Example 1: Get all Azure Load Testing resources in a subscription
```powershell
Get-AzLoad
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
sampleres1 sample-rg      eastus   00000000-0000-0000-0000-000000000001.eastus.cnt-prod.loadtesting.azure.com
```

This command lists all Azure Load Testing resources in the subscription.

### Example 2: Get all Azure Load Testing resources in a resource group
```powershell
Get-AzLoad -ResourceGroupName sample-rg
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
sampleres1 sample-rg      eastus   00000000-0000-0000-0000-000000000001.eastus.cnt-prod.loadtesting.azure.com
```

This command lists all Azure Load Testing resources in resource group named sample-rg.

### Example 3: Get the details of an Azure Load Testing resource
```powershell
Get-AzLoad -Name sampleres -ResourceGroupName sample-rg
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command gets the details of the Azure Load Testing resource named sampleres in resource group named sample-rg.

## PARAMETERS

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

### -Name
Name of the Azure Load Testing resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: LoadTestName

Required: True
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
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.LoadTesting.Models.Api20221201.ILoadTestResource

## NOTES

## RELATED LINKS
