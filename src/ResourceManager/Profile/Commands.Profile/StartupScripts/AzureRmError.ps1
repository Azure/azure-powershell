function Write-InstallationCheckToFile
{
    Param($installationchecks)
    if (Get-Module Az.Profile -ListAvailable)
    {
        Write-Warning "Both Az and AzureRM modules were detected on your machine. Az and AzureRM module cannot be run side-by-side, please run 'Uninstall-AzureRm' to remove all AzureRm modules from your machine. More information can be found here: https://aka.ms/azps-migration-guide"
    }

    $installationchecks.Add("AzureRmSideBySideCheck","true")
    try
    {
        if (Test-Path $pathToInstallationChecks)
        {
            Remove-Item -Path $pathToInstallationChecks
        }
        
        New-Item -Path $pathToInstallationChecks -ItemType File -Value ($installationchecks | ConvertTo-Json)
    }
    catch
    {
        Write-Verbose "Installation checks failed to write to file."
    }
}

if (!($env:SkipAzInstallationChecks -eq "true"))
{
    $pathToInstallationChecks = Join-Path (Join-Path $HOME ".Azure") "AzInstallationChecks.json"
    $installationchecks = @{}
    if (!(Test-Path $pathToInstallationChecks))
    {
        Write-InstallationCheckToFile $installationchecks
    }
    else
    {
        try
        {
            ((Get-Content $pathToInstallationChecks) | ConvertFrom-Json).PSObject.Properties | Foreach { $installationchecks[$_.Name] = $_.Value }
        }
        catch
        {
            Write-InstallationCheckToFile $installationchecks
        }
        
        if (!$installationchecks.ContainsKey("AzureRmSideBySideCheck"))
        {
            Write-InstallationCheckToFile $installationchecks
        }
    }
}

if (Get-Module Az.profile)
{
    Write-Warning "Az.Profile already loaded. Az and AzureRM module cannot be run side-by-side, please run 'Uninstall-AzureRm' to remove all AzureRm modules from your machine. More information can be found here: https://aka.ms/azps-migration-guide"
    throw "Az.Profile already loaded. Az and AzureRM module cannot be run side-by-side, please run 'Uninstall-AzureRm' to remove all AzureRm modules from your machine. More information can be found here: https://aka.ms/azps-migration-guide"
}