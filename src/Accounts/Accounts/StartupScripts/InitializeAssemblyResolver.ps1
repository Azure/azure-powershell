if ($PSEdition -eq 'Desktop') {
  try {
      [Microsoft.Azure.Commands.Profile.Utilities.CustomAssemblyResolver]::Initialize()
  } catch {
        Write-Warning $_
    }
}
else
{
  try {
       $assemblyLoadContextFolder = [System.IO.Path]::Combine($PSScriptRoot, "..", "AzSharedAlcAssemblies")
       [Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext.AzAssemblyLoadContextInitializer]::RegisterAzSharedAssemblyLoadContext($assemblyLoadContextFolder)
  } catch {
        Write-Warning $_
  }
}