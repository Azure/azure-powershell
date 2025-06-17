---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserdevboximagingtasklog
schema: 2.0.0
---

# Get-AzDevCenterUserDevBoxImagingTaskLog

## SYNOPSIS
Gets the log for an imaging build task.

## SYNTAX

### Get (Default)
```
Get-AzDevCenterUserDevBoxImagingTaskLog -Endpoint <String> -ImageBuildLogId <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserDevBoxImagingTaskLog -DevCenterName <String> -ImageBuildLogId <String>
 -ProjectName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBoxImagingTaskLog -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserDevBoxImagingTaskLog -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the log for an imaging build task.

## EXAMPLES

### Example 1: Get the log for an imaging build task by endpoint
```powershell
Get-AzDevCenterUserDevBoxImagingTaskLog `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -ImageBuildLogId "12345678-aaaa-bbbb-cccc-1234567890ab"
```

This command gets the log for the imaging build task with ID "12345678-aaaa-bbbb-cccc-1234567890ab" in the project "DevProject" using the endpoint.

### Example 2: Get the log for an imaging build task by dev center name
```powershell
Get-AzDevCenterUserDevBoxImagingTaskLog `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -ImageBuildLogId "12345678-aaaa-bbbb-cccc-1234567890ab"
```

This command gets the log for the imaging build task with ID "12345678-aaaa-bbbb-cccc-1234567890ab" in the project "DevProject" using the dev center name.

### Example 3: Get the log for an imaging build task using InputObject and endpoint
```powershell
$logInput = @{
    ProjectName = "DevProject"
    ImageBuildLogId = "12345678-aaaa-bbbb-cccc-1234567890ab"
}
Get-AzDevCenterUserDevBoxImagingTaskLog `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $logInput
```

This command gets the log for the imaging build task using the endpoint and an identity object.

### Example 4: Get the log for an imaging build task using InputObject and dev center name
```powershell
$logInput = @{
    ProjectName = "DevProject"
    ImageBuildLogId = "12345678-aaaa-bbbb-cccc-1234567890ab"
}
Get-AzDevCenterUserDevBoxImagingTaskLog `
  -DevCenterName "ContosoDevCenter" `
  -InputObject $logInput
```

This command gets the log for the imaging build task using the dev center name and an identity object.

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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: GetByDevCenter, GetViaIdentityByDevCenter
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
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageBuildLogId
An imaging build log id.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
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
Parameter Sets: GetViaIdentity, GetViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS

