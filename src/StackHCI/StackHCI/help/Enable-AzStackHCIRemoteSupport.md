---
external help file: Az.StackHCI-help.xml
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/enable-azstackhciremotesupport
schema: 2.0.0
---

# Enable-AzStackHCIRemoteSupport

## SYNOPSIS
Enables Remote Support.

## SYNTAX

```
Enable-AzStackHCIRemoteSupport [-AccessLevel] <String> [[-ExpireInMinutes] <Int32>] [[-SasCredential] <String>]
 [-AgreeToRemoteSupportConsent] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Enables Remote Support allows authorized Microsoft Support users to remotely access the device for diagnostics or repair depending on the access level granted.

## EXAMPLES

### Example 1:
```powershell
Enable-AzStackHCIRemoteSupport -AccessLevel Diagnostics -ExpireInMinutes 1440 -SasCredential "Sample SAS"
```

```output
Proceed with enabling remote support?
[Y] Yes  [N] No: Y

Enabling Remote Support for 'Diagnostics' expiring in '1440' minutes.
Using provided SAS credential to make remote support connection.
Remote Support successfully Enabled.


State         : Active
CreatedAt     : 3/29/2022 10:29:19 AM +00:00
UpdatedAt     : 3/29/2022 10:29:19 AM +00:00
TargetService : PowerShell
AccessLevel   : Diagnostics
ExpiresAt     : 3/30/2022 10:29:18 AM +00:00
SasCredential :
```

Enable Remote Support on machine

### Example 2:
```powershell
Enable-AzStackHCIRemoteSupport -AccessLevel DiagnosticsRepair -ExpireInMinutes 1440 -SasCredential "Sample SAS" -AgreeToRemoteSupportConsent
```

```output
Enabling Remote Support for 'Diagnostics' expiring in '1440' minutes.
Using provided SAS credential to make remote support connection.
Remote Support successfully Enabled.


State         : Active
CreatedAt     : 3/29/2022 10:29:19 AM +00:00
UpdatedAt     : 3/29/2022 10:29:53 AM +00:00
TargetService : PowerShell
AccessLevel   : Diagnostics
ExpiresAt     : 3/30/2022 10:29:53 AM +00:00
SasCredential :
```

Enable remort support by providing consent.
In this case, user is not prompted for consent

## PARAMETERS

### -AccessLevel
Controls the remote operations that can be performed.
This can be either Diagnostics or DiagnosticsAndRepair.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgreeToRemoteSupportConsent
Optional.
If set to true then records user consent as provided and proceeds without prompt.

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

### -ExpireInMinutes

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
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

### -SasCredential
Hybrid Connection SAS Credential.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
