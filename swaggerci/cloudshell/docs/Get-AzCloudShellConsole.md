---
external help file:
Module Name: Az.CloudShell
online version: https://docs.microsoft.com/en-us/powershell/module/az.cloudshell/get-azcloudshellconsole
schema: 2.0.0
---

# Get-AzCloudShellConsole

## SYNOPSIS
Gets the console for the user.

## SYNTAX

### Get1 (Default)
```
Get-AzCloudShellConsole -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzCloudShellConsole -Location <String> -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzCloudShellConsole -InputObject <ICloudShellIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzCloudShellConsole -InputObject <ICloudShellIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the console for the user.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Models.ICloudShellIdentity
Parameter Sets: GetViaIdentity, GetViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The provider location

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

### -Name
The name of the console

```yaml
Type: System.String
Parameter Sets: Get, Get1
Aliases: ConsoleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Models.ICloudShellIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Models.Api20181001.IConsoleProperties

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICloudShellIdentity>: Identity Parameter
  - `[ConsoleName <String>]`: The name of the console
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The provider location
  - `[UserSettingsName <String>]`: The name of the user settings

## RELATED LINKS

