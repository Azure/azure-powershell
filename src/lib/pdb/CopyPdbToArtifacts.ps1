# BinSkim, one step in static analysis, requires PDB to analyze assemblies.
# In most cases it can find them without extra configuration.
# However for special cases, we need to copy the PDB to the same folder as the assemblies so that BinSkim can find them,,
# and that is the purpose of this script.

Param(
    [string]$Configuration = "Debug"
)

$PathMappings = @{
    'msalruntime.pdb' = 'Az.Accounts/lib/netstandard2.0'
    'msalruntime_x86.pdb' = 'Az.Accounts/lib/netstandard2.0'
    'msalruntime_arm64.pdb' = 'Az.Accounts/lib/netstandard2.0'
}

$ArtifactsPath = [System.IO.Path]::Combine($PSScriptRoot, "../../../artifacts", $Configuration)
$PathMappings.Keys | ForEach-Object {
    $Source = [System.IO.Path]::GetFullPath("$PSScriptRoot/$_")
    $Destination = [System.IO.Path]::Combine($ArtifactsPath, $PathMappings[$_])
    Copy-Item -Path $Source -Destination $Destination
}
