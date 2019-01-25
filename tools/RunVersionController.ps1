if (!(Test-Path "C:/Program Files/PowerShell/Modules/PowerShellGet"))
{
    try
    {
        Save-Module -Name PowerShellGet -Repository PSGallery -Path "C:/Program Files/PowerShell/Modules" -ErrorAction Stop
    }
    catch
    {
        throw "Please rerun in Administrator mode."
    }
}

dotnet $PSScriptRoot/../artifacts/VersionController.Netcore.dll