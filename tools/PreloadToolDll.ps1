Function Load-Dll {
    Param(
        [string]
        $DllPath
    )
    if (([System.AppDomain]::CurrentDomain.GetAssemblies() | Where-Object { $_.Location -eq $DllPath}).Count -eq 0)
    {
        $null = [System.Reflection.Assembly]::LoadFrom($DllPath)
    }
}

Load-Dll -DllPath ([System.IO.Path]::Combine($PSScriptRoot, '..', 'artifacts', 'StaticAnalysis', 'Tools.Common.dll'))
