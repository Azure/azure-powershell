---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzNetworkWatcherConnectionMonitorOutputObject

## SYNOPSIS
Create an output object for connection monitor V2.
## SYNTAX

```
New-AzNetworkWatcherConnectionMonitorOutputObject [-OutputType <String>] [-ResourcWorkspaceResourceId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzNetworkWatcherConnectionMonitorOutputObject cmdlet creates an output object for connection monitor V2.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzNetworkWatcherConnectionMonitorOutputObject -OutputType MyWorkspaceOutput -ResourcWorkspaceResourceId MyWSResourceId
```

Type              : MyWorkspaceOutput
WorkspaceSettings : {
                      "WorkspaceResourceId": "MyWSResourceId"
                    }

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputType
The tyope of output.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Output

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourcWorkspaceResourceId
The resource ID of workspace.

```yaml
Type: System.String
Parameter Sets: (All)
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkWatcherConnectionMonitorOutputObject

## NOTES

## RELATED LINKS
