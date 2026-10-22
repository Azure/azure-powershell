
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License"); see LICENSE for details.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Request a temporary admin kubeconfig for the cluster and write it ready-to-use.
.Description
One-shot admin credential: generates an RSA-4096 key + CSR locally, sends only the CSR (the private key
never leaves this machine), splices the signed key back into the returned kubeconfig, and names the context
'<cluster>-admin'. By default it writes a standalone kubeconfig; pass -Merge to add the context into an
existing kubeconfig (AKS-style) instead of overwriting it. Replaces the generated cmdlet of the
same name (hidden via the README directive; still callable as
Az.RedHatOpenShiftHcp.internal\Request-AzRedHatOpenShiftHcpClusterAdminCredential).
.Example
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myRg -HcpOpenShiftClusterName myCluster -OutFile ./admin.kubeconfig
.Example
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myRg -HcpOpenShiftClusterName myCluster -Merge
.Example
Request-AzRedHatOpenShiftHcpClusterAdminCredential -ResourceGroupName myRg -HcpOpenShiftClusterName myCluster -OutFile -
.Outputs
System.String
#>
function Request-AzRedHatOpenShiftHcpClusterAdminCredential {
    [OutputType([System.String])]
    [CmdletBinding(DefaultParameterSetName = 'RequestExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'RequestExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [System.String]
        # The name of the HcpOpenShiftCluster.
        ${HcpOpenShiftClusterName},

        [Parameter(ParameterSetName = 'RequestExpanded', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [System.String]
        # The name of the resource group. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'RequestExpanded')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription. Defaults to the current Az context subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'RequestViaIdentityExpanded', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Models.IRedHatOpenShiftHcpIdentity]
        # Identity Parameter.
        ${InputObject},

        [Parameter()]
        [Alias('f')]
        [System.String]
        # Path to write the kubeconfig to. Defaults to $env:KUBECONFIG (first entry) or ~/.kube/config.
        # Use '-' to print the kubeconfig to stdout instead of writing a file.
        ${OutFile},

        [Parameter()]
        [System.String]
        # Context name to assign. Defaults to '<cluster>-admin'.
        ${Context},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Merge the credential into the existing target kubeconfig (AKS-style) instead of writing a standalone
        # file. Without this, an existing non-empty target is left untouched unless -Force is also given.
        ${Merge},

        [Parameter()]
        [Alias('OverwriteExisting')]
        [System.Management.Automation.SwitchParameter]
        # Overwrite the target kubeconfig file with the standalone credential, replacing any existing content.
        ${Force},

        [Parameter()]
        [System.Management.Automation.SwitchParameter]
        # Also emit the raw credential object (includes ExpirationTimestamp).
        ${PassThru},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional. Use SubscriptionId instead.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach.
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline.
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline.
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use.
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call.
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy.
        ${ProxyUseDefaultCredentials}
    )

    process {
        # PEM-wrap DER bytes at 64-char lines. local: so it is not exported.
        function local:ConvertTo-Pem([string]$Label, [byte[]]$Der) {
            $wrapped = ([System.Convert]::ToBase64String($Der) -replace '(.{1,64})', "`$1`n").TrimEnd()
            return "-----BEGIN $Label-----`n$wrapped`n-----END $Label-----`n"
        }

        $rsa = $null
        $privateKeyPem = $null
        try {
            if ($Merge -and $Force) {
                throw '-Merge and -Force cannot be combined: -Merge adds the context into the existing kubeconfig; -Force overwrites the file. Pick one.'
            }

            $clusterName = $HcpOpenShiftClusterName
            if (-not $clusterName -and $InputObject) { $clusterName = $InputObject.HcpOpenShiftClusterName }
            if (-not $PSCmdlet.ShouldProcess($clusterName, 'Request admin credential')) { return }

            # 1. Generate the keypair + CSR locally. O=system:masters maps to cluster-admin in OpenShift RBAC.
            $rsa = [System.Security.Cryptography.RSA]::Create(4096)
            $dn = [System.Security.Cryptography.X509Certificates.X500DistinguishedName]::new('CN=system:customer-break-glass:system-admin, O=system:masters')
            $req = [System.Security.Cryptography.X509Certificates.CertificateRequest]::new(
                $dn, $rsa,
                [System.Security.Cryptography.HashAlgorithmName]::SHA256,
                [System.Security.Cryptography.RSASignaturePadding]::Pkcs1)
            $csrPem = ConvertTo-Pem -Label 'CERTIFICATE REQUEST' -Der ($req.CreateSigningRequest())
            $privateKeyPem = ConvertTo-Pem -Label 'PRIVATE KEY' -Der ($rsa.ExportPkcs8PrivateKey())

            # 2. Call the hidden generated cmdlet with the CSR injected.
            $invoke = @{ CertificateSigningRequest = $csrPem; Confirm = $false; ErrorAction = 'Stop' }
            foreach ($p in 'HcpOpenShiftClusterName', 'ResourceGroupName', 'SubscriptionId', 'InputObject',
                'DefaultProfile', 'HttpPipelineAppend', 'HttpPipelinePrepend', 'Proxy', 'ProxyCredential',
                'ProxyUseDefaultCredentials', 'Break') {
                if ($PSBoundParameters.ContainsKey($p)) { $invoke[$p] = $PSBoundParameters[$p] }
            }
            if (-not $invoke.ContainsKey('SubscriptionId') -and $PSCmdlet.ParameterSetName -eq 'RequestExpanded') {
                $ctx = Get-AzContext
                if ($ctx) { $invoke['SubscriptionId'] = $ctx.Subscription.Id }
            }
            $cred = Az.RedHatOpenShiftHcp.internal\Request-AzRedHatOpenShiftHcpClusterAdminCredential @invoke
            if (-not $cred) { return }

            # 3. .Kubeconfig is a SecureString (x-ms-secret) — decode it.
            $kubeYaml = ConvertFrom-SecureString -AsPlainText $cred.Kubeconfig
            if ($kubeYaml -notmatch "`n") { $kubeYaml = $kubeYaml -replace '\\n', "`n" }

            # 4. Embed the private key + give the context a stable name.
            $contextName = if ($Context) { $Context } else { "$clusterName-admin" }
            $prepared = [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom.KubeConfigHelper]::PrepareKubeconfig(
                $kubeYaml, $privateKeyPem, $contextName)

            # 5. Emit to stdout or merge/write to a file.
            if ($OutFile -eq '-') {
                if ($Merge -or $Force) { Write-Warning '-Merge/-Force are ignored when -OutFile is ''-'' (writing to stdout).' }
                Write-Output $prepared
            }
            else {
                $target = $OutFile
                if (-not $PSBoundParameters.ContainsKey('OutFile')) {
                    if ($env:KUBECONFIG) { $target = ($env:KUBECONFIG -split [System.IO.Path]::PathSeparator)[0] }
                    else { $target = Join-Path $HOME '.kube/config' }
                }
                if ($target.StartsWith('~')) { $target = Join-Path $HOME $target.Substring(1).TrimStart('/', '\') }
                # Resolve relative paths against the PowerShell current location (NOT the .NET process
                # working directory, which [IO.Path]::GetFullPath uses and can differ from $PWD).
                $target = $PSCmdlet.GetUnresolvedProviderPathFromPSPath($target)

                $dir = [System.IO.Path]::GetDirectoryName($target)
                if ($dir -and -not (Test-Path -LiteralPath $dir)) { $null = New-Item -ItemType Directory -Path $dir -Force }

                $existingItem = Get-Item -LiteralPath $target -ErrorAction SilentlyContinue
                if ($existingItem -and $existingItem.LinkType -eq 'SymbolicLink') {
                    throw "Refusing to write through a symbolic link: $target"
                }

                # Default: write a standalone kubeconfig. Merging into an existing file is opt-in (-Merge);
                # overwriting one is opt-in (-Force). Refuse to clobber an existing non-empty file otherwise.
                $final = $prepared
                if ($existingItem) {
                    $existing = Get-Content -LiteralPath $target -Raw
                    $hasContent = $existing -and $existing.Trim()
                    if ($Merge) {
                        if ($hasContent) {
                            $final = [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom.KubeConfigHelper]::MergeKubeConfig($existing, $prepared)
                        }
                    }
                    elseif (-not $Force -and $hasContent) {
                        throw "A kubeconfig already exists at '$target'. Re-run with -Merge to add this cluster's context to it, -Force to overwrite it, or -OutFile <path> to write elsewhere."
                    }
                }

                # Unpredictable temp name next to the target (same filesystem -> atomic Move), so a pre-planted
                # symlink at the temp path cannot redirect the private-key-bearing write elsewhere.
                $tmp = "$target.$([System.IO.Path]::GetRandomFileName()).tmp"
                if (Test-Path -LiteralPath $tmp) { Remove-Item -LiteralPath $tmp -Force }
                Set-Content -LiteralPath $tmp -Value $final -NoNewline
                try { if (-not $IsWindows) { [System.IO.File]::SetUnixFileMode($tmp, [System.IO.UnixFileMode]'UserRead, UserWrite') } } catch { }
                Move-Item -LiteralPath $tmp -Destination $target -Force
                try { if (-not $IsWindows) { [System.IO.File]::SetUnixFileMode($target, [System.IO.UnixFileMode]'UserRead, UserWrite') } } catch { }

                Write-Verbose "Admin kubeconfig written to '$target' (context '$contextName'); expires $($cred.ExpirationTimestamp)."
            }

            if ($PassThru) { $cred }
        }
        finally {
            if ($rsa) { $rsa.Dispose() }
            $privateKeyPem = $null
        }
    }
}
