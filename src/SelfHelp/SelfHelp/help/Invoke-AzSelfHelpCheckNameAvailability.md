---
external help file: Az.SelfHelp-help.xml
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/invoke-azselfhelpchecknameavailability
schema: 2.0.0
---

# Invoke-AzSelfHelpCheckNameAvailability

## SYNOPSIS
This API is used to check the uniqueness of a resource name used for a diagnostic, troubleshooter or solutions

## SYNTAX

### PostExpanded (Default)
```
Invoke-AzSelfHelpCheckNameAvailability -Scope <String> [-Name <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Post
```
Invoke-AzSelfHelpCheckNameAvailability -Scope <String>
 -CheckNameAvailabilityRequest <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PostViaJsonFilePath
```
Invoke-AzSelfHelpCheckNameAvailability -Scope <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### PostViaJsonString
```
Invoke-AzSelfHelpCheckNameAvailability -Scope <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This API is used to check the uniqueness of a resource name used for a diagnostic, troubleshooter or solutions

## EXAMPLES

### Example 1: Invoke-AzSelfHelpCheckNameAvailability
```powershell
$CHECKNAMEAVAILABILITYREQUEST = [ordered]@{ 
    "name" ="helloworld" 
    "type" = "solutions" 

} 
 Invoke-AzSelfHelpCheckNameAvailability -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba" -CheckNameAvailabilityRequest $CHECKNAMEAVAILABILITYREQUEST
```

```output
Message NameAvailable Reason 

------- ------------- ------ 

        True
```

Checks if resource name is available/unique for the scope or not

## PARAMETERS

### -CheckNameAvailabilityRequest
The check availability request body.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ICheckNameAvailabilityRequest
Parameter Sets: Post
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
Path of Json file supplied to the Post operation

```yaml
Type: System.String
Parameter Sets: PostViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Post operation

```yaml
Type: System.String
Parameter Sets: PostViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource for which availability needs to be checked.

```yaml
Type: System.String
Parameter Sets: PostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
scope = resourceUri of affected resource.\<br/\> For example: /subscriptions/0d0fcd2e-c4fd-4349-8497-200edb3923c6/resourcegroups/myresourceGroup/providers/Microsoft.KeyVault/vaults/test-keyvault-non-read

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

### -Type
The resource type.

```yaml
Type: System.String
Parameter Sets: PostExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ICheckNameAvailabilityRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ICheckNameAvailabilityResponse

## NOTES

## RELATED LINKS
