try {
    $assemblyLoadContextFolder = [System.IO.Path]::Combine($PSScriptRoot, "..", "ModuleAclAssemblies")
    [Microsoft.Azure.PowerShell.AuthenticationAssemblyLoadContext.AzAssemblyLoadContextInitializer]::RegisterModuleAssemblyLoadContext("Microsoft.Azure.Commands.Compute.AlcWrapper", $assemblyLoadContextFolder)

  } catch {
        Write-Warning $_
  }