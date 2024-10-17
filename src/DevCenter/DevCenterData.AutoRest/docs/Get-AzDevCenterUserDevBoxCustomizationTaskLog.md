---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserdevboxcustomizationtasklog
schema: 2.0.0
---

# Get-AzDevCenterUserDevBoxCustomizationTaskLog

## SYNOPSIS
Gets the log for a customization task.

## SYNTAX

### Get (Default)
```
Get-AzDevCenterUserDevBoxCustomizationTaskLog -Endpoint <String> -CustomizationGroupName <String>
 -CustomizationTaskId <String> -DevBoxName <String> -ProjectName <String> [-UserId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserDevBoxCustomizationTaskLog -DevCenterName <String> -CustomizationGroupName <String>
 -CustomizationTaskId <String> -DevBoxName <String> -ProjectName <String> [-UserId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBoxCustomizationTaskLog -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserDevBoxCustomizationTaskLog -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the log for a customization task.

## EXAMPLES

### Example 1: Get a customization task by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskLog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -DevBoxName MyDevBox -CustomizationGroupName Provisioning -CustomizationTaskId "91835dc0-ef5a-4f58-9e3a-099aea8481f4"
```

This command gets the logs of the customization task "91835dc0-ef5a-4f58-9e3a-099aea8481f4" for the customization group "Provsioning" in the dev box "MyDevBox".

### Example 2: Get a customization task by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskLog -DevCenterName Contoso -ProjectName DevProject -DevBoxName MyDevBox -CustomizationGroupName Provisioning -CustomizationTaskId "91835dc0-ef5a-4f58-9e3a-099aea8481f4"
```

This command gets the logs of the customization task "91835dc0-ef5a-4f58-9e3a-099aea8481f4" for the customization group "Provsioning" in the dev box "MyDevBox".

### Example 3: Get a customization task by endpoint and InputObject
```powershell
$customizationTaskLogInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" ="DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "me"; "CustomizationTaskId" = "91835dc0-ef5a-4f58-9e3a-099aea8481f4" }
Get-AzDevCenterUserDevBoxCustomizationTaskLog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationTaskInput
```

This command gets the logs of the customization task "91835dc0-ef5a-4f58-9e3a-099aea8481f4" for the customization group "Provsioning" in the dev box "MyDevBox".

### Example 4: Get a customization task by dev center and InputObject
```powershell
$customizationTaskLogInput = @{"CustomizationGroupName" = "Provisioning"; "ProjectName" = "DevProject"; "DevBoxName" = "MyDevBox"; "UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "CustomizationTaskId" = "91835dc0-ef5a-4f58-9e3a-099aea8481f4" }
Get-AzDevCenterUserDevBoxCustomizationTaskLog -DevCenterName Contoso -InputObject $customizationTaskInput 
```

This command gets the logs of the customization task "91835dc0-ef5a-4f58-9e3a-099aea8481f4" for the customization group "Provsioning" in the dev box "MyDevBox".

## PARAMETERS

### -CustomizationGroupName
A customization group name.

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

### -CustomizationTaskId
A customization task ID.

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
The name of a Dev Box.

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

### -UserId
The AAD object id of the user.
If value is 'me', the identity is taken from the 
 authentication context.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
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

### System.String

## NOTES

## RELATED LINKS

