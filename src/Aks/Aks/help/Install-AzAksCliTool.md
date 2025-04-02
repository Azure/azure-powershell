---
external help file: Az.Aks-help.xml
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/install-azaksclitool
schema: 2.0.0
---

# Install-AzAksCliTool

## SYNOPSIS
Download and install kubectl and kubelogin.

## SYNTAX

```
Install-AzAksCliTool [-Destination <String>] [-Version <String>] [-DownloadFromMirror]
 [-KubeloginInstallDestination <String>] [-KubeloginInstallVersion <String>] [-KubeloginDownloadFromMirror]
 [-PassThru] [-AsJob] [-Force] [-WhatIf] [-Confirm] [<CommonParameters>]
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
Run cmdlet in the background

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
Path at which to install kubectl.
Default to install into ~/.azure-kubectl/

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
Download from mirror site : https://mirror.azure.cn/kubernetes/kubectl/

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
Overwrite existing kubectl and kubelogin without prompt

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
Download from mirror site : https://mirror.azure.cn/kubernetes/kubelogin

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
Path at which to install kubectl.
Default to install into ~/.azure-kubelogin/

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
Version of kubectl to install, e.g.
'v0.0.20'.
Default value: Latest

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
Wait for .NET debugger to attach

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
Version of kubectl to install, e.g.
'v1.17.2'.
Default value: Latest.

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
