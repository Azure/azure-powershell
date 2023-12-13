---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmentlog
schema: 2.0.0
---

# Get-AzDevCenterUserEnvironmentLog

## SYNOPSIS
Gets the logs for an operation on an environment.

## SYNTAX

### Get (Default)
```
Get-AzDevCenterUserEnvironmentLog -Endpoint <String> -EnvironmentName <String> -OperationId <String>
 -ProjectName <String> [-UserId <String>] -OutFile <String> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserEnvironmentLog -DevCenterName <String> -EnvironmentName <String> -OperationId <String>
 -ProjectName <String> [-UserId <String>] -OutFile <String> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the logs for an operation on an environment.

## EXAMPLES

### EXAMPLE 1
```
Get-AzDevCenterUserEnvironmentLog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -EnvironmentName myEnvironment -ProjectName DevProject -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd" -Outfile "../output_logs.txt"
```

### EXAMPLE 2
```
Get-AzDevCenterUserEnvironmentLog -DevCenterName Contoso -EnvironmentName myEnvironment -ProjectName DevProject -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd" -Outfile "../output_logs.txt"
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
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
Type: String
Parameter Sets: GetByDevCenter
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
Type: String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentName
The name of the environment.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OperationId
The id of the operation on an environment.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutFile
Path to write output file to

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
Aliases:

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

[https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmentlog](https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmentlog)

