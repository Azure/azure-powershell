---
external help file: Az.RedHatOpenShiftHcp-help.xml
Module Name: Az.RedHatOpenShiftHcp
online version: https://learn.microsoft.com/powershell/module/az.redhatopenshifthcp/request-azredhatopenshifthcpclusteradmincredential
schema: 2.0.0
---

# Request-AzRedHatOpenShiftHcpClusterAdminCredential

## SYNOPSIS
Request a temporary admin kubeconfig for the cluster and write it ready-to-use.

## SYNTAX

### RequestExpanded (Default)
```
Request-AzRedHatOpenShiftHcpClusterAdminCredential -HcpOpenShiftClusterName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-OutFile <String>] [-Context <String>] [-Merge]
 [-Force] [-PassThru] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RequestViaIdentityExpanded
```
Request-AzRedHatOpenShiftHcpClusterAdminCredential -InputObject <IRedHatOpenShiftHcpIdentity>
 [-OutFile <String>] [-Context <String>] [-Merge] [-Force] [-PassThru] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
One-shot admin credential: generates an RSA-4096 key + CSR locally, sends only the CSR (the private key
never leaves this machine), splices the signed key back into the returned kubeconfig, and names the context
'\<cluster\>-admin'.
By default it writes a standalone kubeconfig; pass -Merge to add the context into an
existing kubeconfig (AKS-style) instead of overwriting it.
Replaces the generated cmdlet of the
same name (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\Request-AzRedHatOpenShiftHcpClusterAdminCredential).

## EXAMPLES

### Example 1: Request an admin kubeconfig as a standalone file
```powershell
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster -OutFile ./myCluster.kubeconfig
```

Requests a temporary admin credential and writes a ready-to-use, standalone kubeconfig.
The cmdlet generates an RSA-4096 key and CSR locally, sends only the CSR (the private key never leaves the machine), splices the signed key back into the returned kubeconfig, and adds a context named `myCluster-admin`, written with `0600` permissions.
After this, `kubectl --kubeconfig ./myCluster.kubeconfig get nodes` works in one shot.
Writing is the default; an existing non-empty target is left untouched unless you pass `-Merge` or `-Force`.

### Example 2: Merge the credential into your existing kubeconfig
```powershell
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster -Merge
```

Passing `-Merge` adds the `myCluster-admin` cluster/user/context into your existing kubeconfig (`$env:KUBECONFIG` or `~/.kube/config`) AKS-style, preserving every other entry, and switches the current context to it.
Without `-Merge`, the cmdlet writes a standalone file and refuses to overwrite an existing one.

### Example 3: Print the kubeconfig to stdout instead of writing a file
```powershell
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myResourceGroup -HcpOpenShiftClusterName myCluster -OutFile -
```

```output
apiVersion: v1
kind: Config
clusters:
- cluster:
    server: https://api.myCluster.abcd1234.westeurope.aroapp.io:443
  name: myCluster
contexts:
- context:
    cluster: myCluster
    user: myCluster-admin
  name: myCluster-admin
current-context: myCluster-admin
users:
- name: myCluster-admin
  user:
    client-certificate-data: LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0t...
    client-key-data: LS0tLS1CRUdJTiBQUklWQVRFIEtFWS0tLS0t...
```

Passing `-OutFile -` prints the prepared kubeconfig (private key already embedded, context `myCluster-admin`) to stdout instead of writing or merging a file, handy for piping into another tool.

## PARAMETERS

### -Context
Context name to assign.
Defaults to '\<cluster\>-admin'.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use SubscriptionId instead.

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

### -Force
Overwrite the target kubeconfig file with the standalone credential, replacing any existing content.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: OverwriteExisting

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HcpOpenShiftClusterName
The name of the HcpOpenShiftCluster.

```yaml
Type: System.String
Parameter Sets: RequestExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity
Parameter Sets: RequestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Merge
Merge the credential into the existing target kubeconfig (AKS-style) instead of writing a standalone
file.
Without this, an existing non-empty target is left untouched unless -Force is also given.

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

### -OutFile
Path to write the kubeconfig to.
Defaults to $env:KUBECONFIG (first entry) or ~/.kube/config.
Use '-' to print the kubeconfig to stdout instead of writing a file.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: f

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Also emit the raw credential object (includes ExpirationTimestamp).

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: RequestExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
Defaults to the current Az context subscription.

```yaml
Type: System.String
Parameter Sets: RequestExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
