---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserdevboxsnapshot
schema: 2.0.0
---

# Get-AzDevCenterUserDevBoxSnapshot

## SYNOPSIS
Gets a snapshot by snapshot id.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserDevBoxSnapshot -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserDevBoxSnapshot -Endpoint <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -SnapshotId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBoxSnapshot -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserDevBoxSnapshot -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] -SnapshotId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserDevBoxSnapshot -DevCenterName <String> -DevBoxName <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserDevBoxSnapshot -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a snapshot by snapshot id.

## EXAMPLES

### Example 1: Get all snapshots for a Dev Box by endpoint and user ID
```powershell
Get-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0"
```

This command gets all snapshots for the dev box "myDevBox" assigned to user "786a823c-8037-48ab-89b8-8599901e67d0" using the endpoint.

### Example 2: Get a specific snapshot for a Dev Box by endpoint and snapshot ID
```powershell
Get-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "786a823c-8037-48ab-89b8-8599901e67d0" `
  -SnapshotId "snapshot-1234"
```

This command gets the snapshot with ID "snapshot-1234" for the dev box "myDevBox" assigned to the specified user using the endpoint.

### Example 3: Get all snapshots for a Dev Box by dev center and current user
```powershell
Get-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me"
```

This command gets all snapshots for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 4: Get a specific snapshot for a Dev Box by dev center and snapshot ID
```powershell
Get-AzDevCenterUserDevBoxSnapshot `
  -DevCenterName "ContosoDevCenter" `
  -ProjectName "DevProject" `
  -DevBoxName "myDevBox" `
  -UserId "me" `
  -SnapshotId "snapshot-1234"
```

This command gets the snapshot with ID "snapshot-1234" for the dev box "myDevBox" assigned to the current signed-in user using the dev center name.

### Example 5: Get a snapshot using InputObject and endpoint
```powershell
$snapshotInput = @{
    DevBoxName = "myDevBox"
    UserId = "786a823c-8037-48ab-89b8-8599901e67d0"
    ProjectName = "DevProject"
    SnapshotId = "snapshot-1234"
}
Get-AzDevCenterUserDevBoxSnapshot `
  -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" `
  -InputObject $snapshotInput
```

This command gets the snapshot with ID "snapshot-1234" for the dev box "myDevBox" using the endpoint and an identity object.

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

### -DevBoxName
Display name for the Dev Box.

```yaml
Type: System.String
Parameter Sets: List, Get, GetByDevCenter, ListByDevCenter
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
Parameter Sets: GetByDevCenter, ListByDevCenter, GetViaIdentityByDevCenter
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
Parameter Sets: List, Get, GetViaIdentity
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
Name of the project.

```yaml
Type: System.String
Parameter Sets: List, Get, GetByDevCenter, ListByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SnapshotId
The id of the snapshot.
Should be treated as opaque string.

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

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the authentication context.

```yaml
Type: System.String
Parameter Sets: List, Get, GetByDevCenter, ListByDevCenter
Aliases:

Required: False
Position: Named
Default value: "me"
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20250401Preview.IDevBoxSnapshot

## NOTES

## RELATED LINKS
