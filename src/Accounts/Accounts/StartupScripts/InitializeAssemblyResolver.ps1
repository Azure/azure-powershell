$assemblyRootPath = [System.IO.Path]::Combine($PSScriptRoot, "..", "lib")
Write-Debug "Initializing ConditionalAssemblyContext. PSEdition is [$($PSVersionTable.PSEdition)]. PSVersion is [$($PSVersionTable.PSVersion)]."
$conditionalAssemblyContext = [Microsoft.Azure.PowerShell.AssemblyLoading.ConditionalAssemblyContext]::new($PSVersionTable.PSEdition, $PSVersionTable.PSVersion)
Write-Debug "Initializing ConditionalAssemblyProvider. AssemblyRootPath is [$assemblyRootPath]."
[Microsoft.Azure.PowerShell.AssemblyLoading.ConditionalAssemblyProvider]::Initialize($assemblyRootPath, $conditionalAssemblyContext)

if ($PSEdition -eq 'Desktop') {
  try {
    [Microsoft.Azure.Commands.Profile.Utilities.CustomAssemblyResolver]::Initialize()
  }
  catch {
    Write-Warning $_
  }
}
else {
  try {
    Add-Type -Path ([System.IO.Path]::Combine($PSScriptRoot, "..", "Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext.dll")) | Out-Null
    Write-Debug "Registering Az shared AssemblyLoadContext."
    [Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext.AzAssemblyLoadContextInitializer]::RegisterAzSharedAssemblyLoadContext()
    Write-Debug "AssemblyLoadContext registered."
  }
  catch {
    Write-Warning $_
  }
}