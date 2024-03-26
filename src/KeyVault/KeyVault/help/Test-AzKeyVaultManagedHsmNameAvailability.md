---
external help file: Az.KeyVault-help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/test-azkeyvaultmanagedhsmnameavailability
schema: 2.0.0
---

# Test-AzKeyVaultManagedHsmNameAvailability

## SYNOPSIS
Checks that the managed hsm name is valid and is not already in use.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzKeyVaultManagedHsmNameAvailability [-SubscriptionId <String>] -Name <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzKeyVaultManagedHsmNameAvailability [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzKeyVaultManagedHsmNameAvailability [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks that the managed hsm name is valid and is not already in use.

## EXAMPLES

### Example 1: Test the availability of an unused HSM name
```powershell
Test-AzKeyVaultManagedHsmNameAvailability -Name testmhsm0818
```

```output
Message NameAvailable Reason
------- ------------- ------
                 True
```

This commands tests the availability of vault name `testmhsm0818`.
The results shows `testmhsm0818` is not occupied.

### Example 2: Test the availability of an used HSM name
```powershell
Test-AzKeyVaultNameAvailability -Name testmhsm
```

```output
Message                               NameAvailable Reason
-------                               ------------- ------
The name 'testmhsm' is already in use.         False AlreadyExists
```

This commands tests the availability of HSM name `testmhsm`.
The results shows `testmhsm` is already in use.

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
Path of Json file supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The managed hsm name.

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

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

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.ICheckMhsmNameAvailabilityResult

## NOTES

## RELATED LINKS
