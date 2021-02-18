if ($PSEdition -eq 'Desktop') {
<<<<<<< HEAD
    try {
	    [Microsoft.Azure.PowerShell.Authenticators.DesktopAuthenticatorBuilder]::Apply([Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance)
=======
  try {
	    [Microsoft.Azure.Commands.Profile.Utilities.CustomAssemblyResolver]::Initialize()
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	} catch {}
}