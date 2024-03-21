---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/remove-azdevcenteruserenvironment
schema: 2.0.0
---

# Remove-AzDevCenterUserEnvironment

## SYNOPSIS
Deletes an environment and all its associated resources

## SYNTAX

### Delete (Default)
```
Remove-AzDevCenterUserEnvironment -Endpoint <String> -Name <String> -ProjectName <String> [-UserId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzDevCenterUserEnvironment -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentityByDevCenter
```
Remove-AzDevCenterUserEnvironment -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### DeleteByDevCenter
```
Remove-AzDevCenterUserEnvironment -DevCenterName <String> -Name <String> -ProjectName <String>
 [-UserId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes an environment and all its associated resources

## EXAMPLES

### Example 1: Delete an environment by endpoint
```powershell
Remove-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -UserId "me"  -Name myEnv
```

This command deletes the environment "myEnv" under the project "DevProject" assigned to the currently signed-in user.

### Example 2: Delete an environment by dev center
```powershell
Remove-AzDevCenterUserEnvironment -DevCenterName Contoso -ProjectName DevProject -UserId "786a823c-8037-48ab-89b8-8599901e67d0" -Name myEnv
```

This command deletes the environment "myEnv" under the project "DevProject" assigned to the user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 3: Delete an environment by endpoint and InputObject
```powershell
$envInput = @{"UserId" = "786a823c-8037-48ab-89b8-8599901e67d0"; "ProjectName" = "DevProject"; "EnvironmentName" = "myEnv" }
Remove-AzDevCenterUserEnvironment -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput
```

This command deletes the environment "myEnv" under the project "DevProject" assigned to the user "786a823c-8037-48ab-89b8-8599901e67d0".

### Example 4: Delete an environment by dev center and InputObject
```powershell
$envInput = @{"UserId" = "me"; "ProjectName" = "DevProject"; "EnvironmentName" = "myEnv" }
Remove-AzDevCenterUserEnvironment -DevCenterName Contoso -InputObject $envInput
```

This command deletes the environment "myEnv" under the project "DevProject" assigned to the currently signed-in user.

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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: DeleteViaIdentityByDevCenter, DeleteByDevCenter
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
Parameter Sets: Delete, DeleteViaIdentity
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
Parameter Sets: DeleteViaIdentity, DeleteViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the environment.

```yaml
Type: System.String
Parameter Sets: Delete, DeleteByDevCenter
Aliases: EnvironmentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -PassThru
Returns true when the command succeeds

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

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: Delete, DeleteByDevCenter
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
Parameter Sets: Delete, DeleteByDevCenter
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

### System.Boolean

## NOTES

## RELATED LINKS
