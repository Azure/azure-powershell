---
external help file: Az.Communication-help.xml
Module Name: Az.Communication
online version: https://learn.microsoft.com/powershell/module/az.communication/test-azcommunicationservicenameavailability
schema: 2.0.0
---

# Test-AzCommunicationServiceNameAvailability

## SYNOPSIS
Checks that the CommunicationService name is valid and is not already in use.

## SYNTAX

```
Test-AzCommunicationServiceNameAvailability [-SubscriptionId <String>] -Name <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks that the CommunicationService name is valid and is not already in use.

## EXAMPLES

### Example 1: Checks if already in use resource name ContosoAcsResource1 is available
```powershell
Test-AzCommunicationServiceNameAvailability -Name ContosoAcsResource1
```

```output
Message                      NameAvailable Reason
-------                      ------------- ------
Resource name already exists False         AlreadyExists
```

Verified that the CommunicationService name is valid and is not already in use.

### Example 2: Checks if new resource name ContosoAcsResource2 is available
```powershell
Test-AzCommunicationServiceNameAvailability -Name ContosoAcsResource2
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Verified that the requested CommunicationService name already in use.

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

### -Name
The name of the resource for which availability needs to be checked.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api40.ICheckNameAvailabilityResponse

## NOTES

## RELATED LINKS
