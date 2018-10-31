
$pathToInstallationChecks = Join-Path (Join-Path $HOME ".Azure") "AzInstallationChecks.json"
if (!(Test-Path $pathToInstallationChecks))
{
    if (Get-Module Az.Profile -ListAvailable)
    {
        Write-Warning "Both Az and AzureRM modules were detected on your machine. Az and AzureRM module cannot be run side-by-side, please follow migration guide to ensure Az modules work as expected: <LINK HERE>."
    }

    $hashtable = @{"AzureRmSideBySideCheck"="true"}
    New-Item -Path $pathToInstallationChecks -ItemType File -Value ($hashtable | ConvertTo-Json)
}

else
{
    $installationchecks = @{}
    ((Get-Content $pathToInstallationChecks) | ConvertFrom-Json).PSObject.Properties | Foreach { $installationchecks[$_.Name] = $_.Value }
    if (!$installationchecks.ContainsKey("AzureRmSideBySideCheck"))
    {
        if (Get-Module Az.Profile -ListAvailable)
        {
            Write-Warning "Both Az and AzureRM modules were detected on your machine. Az and AzureRM module cannot be run side-by-side, please follow migration guide to ensure Az modules work as expected: <LINK HERE>."
        }

        $installationchecks.Add("AzureRmSideBySideCheck","true")
        Remove-Item -Path $pathToInstallationChecks
        New-Item -Path $pathToInstallationChecks -ItemType File -Value ($installationchecks | ConvertTo-Json)
    }
}

if (Get-Module AzureRM.profile)
{
    Write-Warning "Both Az and AzureRM modules were detected on your machine. Az and AzureRM module cannot be run side-by-side, please follow migration guide to ensure Az modules work as expected: <LINK HERE>."
    throw "Both Az and AzureRM modules were detected on your machine. Az and AzureRM module cannot be run side-by-side, please follow migration guide to ensure Az modules work as expected: <LINK HERE>."
}