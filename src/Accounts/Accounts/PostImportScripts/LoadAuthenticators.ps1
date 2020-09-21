if ($PSEdition -eq 'Desktop') {
  try {
	    [Microsoft.Azure.Commands.Profile.Utilities.CustomAssemblyResolver]::Initialize()
	} catch {}
}