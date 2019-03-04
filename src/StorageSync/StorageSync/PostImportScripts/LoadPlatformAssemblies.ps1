$platformDirectory = Join-Path (Join-Path $PSScriptRoot "..") "PlatformAssemblies"
if ($PSEdition -eq 'Desktop' -or $IsWindows) {
    $platformDirectory = Join-Path $platformDirectory "win" 
}
elseif ($IsLinux -or $IsMacOs) {
	$platformDirectory = Join-Path $platformDirectory "unix"
}

try {
	 $loadedAssemblies = ([System.AppDomain]::CurrentDomain.GetAssemblies() | ForEach-Object {New-Object -TypeName System.Reflection.AssemblyName -ArgumentList $_.FullName} )
    if (Test-Path $platformDirectory -ErrorAction Ignore) {
	    Get-ChildItem -Path $platformDirectory -Filter *.dll -ErrorAction Stop | ForEach-Object {
            $assemblyName = ([System.Reflection.AssemblyName]::GetAssemblyName($_.FullName))
            $matches = ($loadedAssemblies | Where-Object {$_.Name -eq $assemblyName.Name})
            if (-not $matches)
            {
                Add-Type -Path $_.FullName -ErrorAction Ignore | Out-Null
            }
		}
    }
}
catch {}