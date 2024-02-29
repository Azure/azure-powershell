---
external help file:
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/install-azaksclitool
schema: 2.0.0
---

# Install-AzAksCliTool

## SYNOPSIS
Download and install kubectl and kubelogin.

## SYNTAX

```
Install-AzAksCliTool [-AsJob] [-Destination <String>] [-DownloadFromMirror] [-Force]
 [-KubeloginDownloadFromMirror] [-KubeloginInstallDestination <String>] [-KubeloginInstallVersion <String>]
 [-PassThru] [-Version <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Download and install kubectl and kubelogin.

## EXAMPLES

### Example 1: Install the lateset version of kubectl and kubelogin
```powershell
Install-AzAksCliTool
```



### Example 2: Install the special version of kubectl and kubelogin into custom folder
```powershell
Install-AzAksCliTool -KubectlInstallVersion "v1.25.0" -KubectlInstallDestination "~/bin/" -KubeloginInstallVersion "v0.0.20" -KubeloginInstallDestination "~/bin"
```



## PARAMETERS

### -AsJob
Runcmdletinthebackground

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

### -Destination
Pathatwhichtoinstallkubectl.Defaulttoinstallinto~/.azure-kubectl/

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: KubectlInstallDestination

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DownloadFromMirror
Downloadfrommirrorsite:https://mirror.azure.cn/kubernetes/kubectl/

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: KubectlDownloadFromMirror

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Overwriteexistingkubectlandkubeloginwithoutprompt

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

### -KubeloginDownloadFromMirror
Downloadfrommirrorsite:https://mirror.azure.cn/kubernetes/kubelogin

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

### -KubeloginInstallDestination
Pathatwhichtoinstallkubectl.Defaulttoinstallinto~/.azure-kubelogin/

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

### -KubeloginInstallVersion
Versionofkubectltoinstall,e.g.'v0.0.20'.Defaultvalue:Latest

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

### -PassThru
Waitfor.NETdebuggertoattach

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

### -Version
Versionofkubectltoinstall,e.g.'v1.17.2'.Defaultvalue:Latest.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: KubectlInstallVersion

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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

