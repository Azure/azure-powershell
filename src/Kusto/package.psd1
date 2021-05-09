@{
    Root = 'c:\Users\astauben\Desktop\PS\azure-powershell\src\Kusto\test\Get-AzKustoDataConnection.Tests.ps1'
    OutputPath = 'c:\Users\astauben\Desktop\PS\azure-powershell\src\Kusto\out'
    Package = @{
        Enabled = $true
        Obfuscate = $false
        HideConsoleWindow = $false
        DotNetVersion = 'v4.6.2'
        FileVersion = '1.0.0'
        FileDescription = ''
        ProductName = ''
        ProductVersion = ''
        Copyright = ''
        RequireElevation = $false
        ApplicationIconPath = ''
        PackageType = 'Console'
    }
    Bundle = @{
        Enabled = $true
        Modules = $true
        # IgnoredModules = @()
    }
}
        