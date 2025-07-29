---
external help file: Az.Batch-help.xml
Module Name: Az.Batch
online version: https://learn.microsoft.com/powershell/module/az.batch/initialize-azapplicationpackage
schema: 2.0.0
---

# Initialize-AzApplicationPackage

## SYNOPSIS
Activates the specified application package.
This should be done after the `ApplicationPackage` was created and uploaded.
This needs to be done before an `ApplicationPackage` can be used on Pools or Tasks.

## SYNTAX

### ActivateExpanded (Default)
```
Initialize-AzApplicationPackage -AccountName <String> -ApplicationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VersionName <String> -Format <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaJsonString
```
Initialize-AzApplicationPackage -AccountName <String> -ApplicationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VersionName <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaJsonFilePath
```
Initialize-AzApplicationPackage -AccountName <String> -ApplicationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VersionName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Activate
```
Initialize-AzApplicationPackage -AccountName <String> -ApplicationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VersionName <String> -Parameter <IActivateApplicationPackageParameters>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaIdentityBatchAccountExpanded
```
Initialize-AzApplicationPackage -ApplicationName <String> -VersionName <String>
 -BatchAccountInputObject <IBatchIdentity> -Format <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaIdentityBatchAccount
```
Initialize-AzApplicationPackage -ApplicationName <String> -VersionName <String>
 -BatchAccountInputObject <IBatchIdentity> -Parameter <IActivateApplicationPackageParameters>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaIdentityApplicationExpanded
```
Initialize-AzApplicationPackage -VersionName <String> -ApplicationInputObject <IBatchIdentity> -Format <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaIdentityApplication
```
Initialize-AzApplicationPackage -VersionName <String> -ApplicationInputObject <IBatchIdentity>
 -Parameter <IActivateApplicationPackageParameters> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaIdentityExpanded
```
Initialize-AzApplicationPackage -InputObject <IBatchIdentity> -Format <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ActivateViaIdentity
```
Initialize-AzApplicationPackage -InputObject <IBatchIdentity>
 -Parameter <IActivateApplicationPackageParameters> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Activates the specified application package.
This should be done after the `ApplicationPackage` was created and uploaded.
This needs to be done before an `ApplicationPackage` can be used on Pools or Tasks.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
The name of the Batch account.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded, ActivateViaJsonString, ActivateViaJsonFilePath, Activate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApplicationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: ActivateViaIdentityApplicationExpanded, ActivateViaIdentityApplication
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ApplicationName
The name of the application.
This must be unique within the account.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded, ActivateViaJsonString, ActivateViaJsonFilePath, Activate, ActivateViaIdentityBatchAccountExpanded, ActivateViaIdentityBatchAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BatchAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: ActivateViaIdentityBatchAccountExpanded, ActivateViaIdentityBatchAccount
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

### -Format
The format of the application package binary file.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded, ActivateViaIdentityBatchAccountExpanded, ActivateViaIdentityApplicationExpanded, ActivateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: ActivateViaIdentityExpanded, ActivateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Parameter
Parameters for an activating an application package.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IActivateApplicationPackageParameters
Parameter Sets: Activate, ActivateViaIdentityBatchAccount, ActivateViaIdentityApplication, ActivateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the Batch account.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded, ActivateViaJsonString, ActivateViaJsonFilePath, Activate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: ActivateExpanded, ActivateViaJsonString, ActivateViaJsonFilePath, Activate
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionName
The version of the application.

```yaml
Type: System.String
Parameter Sets: ActivateExpanded, ActivateViaJsonString, ActivateViaJsonFilePath, Activate, ActivateViaIdentityBatchAccountExpanded, ActivateViaIdentityBatchAccount, ActivateViaIdentityApplicationExpanded, ActivateViaIdentityApplication
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IActivateApplicationPackageParameters

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IApplicationPackage

## NOTES

## RELATED LINKS
