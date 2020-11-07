if ($PSEdition -eq 'Desktop') {
    try {
	    [Microsoft.Azure.PowerShell.Authenticators.DesktopAuthenticatorBuilder]::Apply([Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance)
	} catch {}
}