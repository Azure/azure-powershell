---
external help file:
Module Name: Az.TrustedSigning
online version: https://learn.microsoft.com/powershell/module/az.trustedsigning/test-aztrustedsigningaccountnameavailability
schema: 2.0.0
---

# Test-AzTrustedSigningAccountNameAvailability

## SYNOPSIS
Checks that the trusted signing account name is valid and is not already in use.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzTrustedSigningAccountNameAvailability -Name <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzTrustedSigningAccountNameAvailability -Body <ICheckNameAvailability> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzTrustedSigningAccountNameAvailability -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzTrustedSigningAccountNameAvailability -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Checks that the trusted signing account name is valid and is not already in use.

## EXAMPLES

### Example 1: Test The Availability Of An Used Trusted Signing Account Name
```powershell
Test-AzTrustedSigningAccountNameAvailability -Name unavaliable
```

```output
Message                      NameAvailable Reason
-------                      ------------- ------
Resource name already exists         False AlreadyExists
```

This commands tests the availability of trusted signing account name `unavaliable`.
The results shows `unavaliable` is occupied.

### Example 2: Test The Availability Of An Unused Trusted Signing Account Name
```powershell
Test-AzTrustedSigningAccountNameAvailability -Name available
```

```output
NameAvailable
-------------
         True
```

This commands tests the availability of trusted signing account name `available`.
The results shows `available` is not occupied.

## PARAMETERS

### -Body
The parameters used to check the availability of the trusted signing account name.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ICheckNameAvailability
Parameter Sets: Check
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
Trusted signing account name.

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

### Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ICheckNameAvailability

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ICheckNameAvailabilityResult

## NOTES

## RELATED LINKS

