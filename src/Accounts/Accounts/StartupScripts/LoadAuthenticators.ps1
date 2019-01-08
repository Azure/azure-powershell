if ($PSEdition -eq 'Desktop') {
    try {
	    [Microsoft.Azure.PowerShell.Authenticators.NetFramework.DesktopAuthenticatorBuilder]::Apply([Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance)
	} catch {}
}