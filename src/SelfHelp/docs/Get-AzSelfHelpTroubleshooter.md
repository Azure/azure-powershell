---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/get-azselfhelptroubleshooter
schema: 2.0.0
---

# Get-AzSelfHelpTroubleshooter

## SYNOPSIS
Gets troubleshooter instance result which includes the step status/result of the troubleshooter resource name that is being executed.\<br/\> Get API is used to retrieve the result of a Troubleshooter instance, which includes the status and result of each step in the Troubleshooter workflow.
This API requires the Troubleshooter resource name that was created using the Create API.

## SYNTAX

### Get (Default)
```
Get-AzSelfHelpTroubleshooter -Name <String> -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSelfHelpTroubleshooter -InputObject <ISelfHelpIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets troubleshooter instance result which includes the step status/result of the troubleshooter resource name that is being executed.\<br/\> Get API is used to retrieve the result of a Troubleshooter instance, which includes the status and result of each step in the Troubleshooter workflow.
This API requires the Troubleshooter resource name that was created using the Create API.

## EXAMPLES

### Example 1: Get Troubleshooter result
```powershell
Get-AzSelfHelpTroubleshooter -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba" -Name "02d59989-f8a9-4b69-9919-1ef51df4eff6" 
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName 

----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- ----------------- 

02d59989-f8a9-4b69-9919-1ef51df4eff6 
```

Use to get troubleshooter result. It is also used to determine the step status/result of the troubleshooter resource name that is being executed.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Troubleshooter resource Name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: TroubleshooterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
This is an extension resource provider and only resource level extension is supported at the moment.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20230901Preview.ITroubleshooterResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ISelfHelpIdentity>`: Identity Parameter
  - `[DiagnosticsResourceName <String>]`: Unique resource name for insight resources
  - `[Id <String>]`: Resource identity path
  - `[Scope <String>]`: This is an extension resource provider and only resource level extension is supported at the moment.
  - `[SolutionResourceName <String>]`: Solution resource Name.
  - `[TroubleshooterName <String>]`: Troubleshooter resource Name.

## RELATED LINKS

