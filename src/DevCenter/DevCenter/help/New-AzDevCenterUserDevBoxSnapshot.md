---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenteruserdevboxsnapshot
schema: 2.0.0
---

# New-AzDevCenterUserDevBoxSnapshot

## SYNOPSIS
Captures a manual snapshot of the Dev Box.\nUpon completion, a snapshotId will be generated.\nTo retrieve all snapshots and their corresponding IDs, use the list snapshots endpoint.

## SYNTAX

### Capture (Default)
```
New-AzDevCenterUserDevBoxSnapshot -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CaptureViaIdentity
```
New-AzDevCenterUserDevBoxSnapshot -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CaptureByDevCenter
```
New-AzDevCenterUserDevBoxSnapshot -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CaptureViaIdentityByDevCenter
```
New-AzDevCenterUserDevBoxSnapshot -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Captures a manual snapshot of the Dev Box.\nUpon completion, a snapshotId will be generated.\nTo retrieve all snapshots and their corresponding IDs, use the list snapshots endpoint.

## EXAMPLES

### Example 1: Create a Dev Box snapshot by endpoint
```powershell
New-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -DevBoxName "myDevBox"
```

This command creates a snapshot for the dev box "myDevBox" assigned to the specified user using the endpoint.

### Example 2: Create a Dev Box snapshot by dev center
```powershell
New-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -UserId "me" `
  -DevBoxName "myDevBox"
```

This command creates a snapshot for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 3: Create a Dev Box snapshot by endpoint and InputObject
```powershell
$snapshotInput = @{
    DevBoxName = "myDevBox"
    UserId = "me"
    ProjectName = "DevProject"
}
New-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $snapshotInput
```

This command creates a snapshot for the dev box "myDevBox" using the endpoint and an identity object.

### Example 4: Create a Dev Box snapshot by dev center and InputObject
```powershell
$snapshotInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
}
New-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $snapshotInput
```

This command creates a snapshot for the dev box "myDevBox" using the dev center name and an identity object.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
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

### -DevBoxName
Display name for the Dev Box.

```yaml
Type: System.String
Parameter Sets: Capture, CaptureByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: CaptureByDevCenter, CaptureViaIdentityByDevCenter
Aliases: DevCenter

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: Capture, CaptureViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: CaptureViaIdentity, CaptureViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
Name of the project.

```yaml
Type: System.String
Parameter Sets: Capture, CaptureByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

```yaml
Type: System.String
Parameter Sets: Capture, CaptureByDevCenter
Aliases:

Required: False
Position: Named
Default value: "me"
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IOperationStatus

## NOTES

## RELATED LINKS
