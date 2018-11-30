Write-Warning "AzureRM.Netcore has been deprecated.  Use the 'Az' module instead.  The 'Az' module is avalable from the PSGallery https://www.powershellgallery.com/packages/Az/. You can find information about getting started with 'Az' at https://docs.microsoft.com/en-us/powershell/azure/new-azureps-module-az. To uninstall AzureRM.Netcore you can use the provided 'Uninstall-AzureRMNetcore' cmdlet."

function Uninstall-AzureRMNetcore {
    [CmdletBinding(SupportsShouldProcess=$true)]
    param()
    begin {}
    process{ 
        $allModules = (Get-Module -ListAvailable)
        $clientModules = ($allModules | Where-Object {$_.Name -like "Azure*.*.NetCore"})
        $rollupModules = ($allModules | Where-Object {$_.Name -eq "AzureRM.Netcore"} | Sort-Object -Property Version)
        $totalCount = $clientModules.Count + $rollupModules.Count
        $count = 0
        foreach( $module in ($clientModules + $rollupModules)) {
           if ($PSCmdlet.ShouldProcess( $module.Name + " Version " + $module.Version, "Uninstall module")) {
               $count = $count + 1
               Write-Progress -Activity 'Removing AzureRM.Netcore modules' `
                 -Status ("Removing " + $module.Name + " version " + $module.Version) `
                 -PercentComplete ($count / $totalCount * 100)
               $module | Uninstall-Module -Force -ErrorAction Stop | Out-Null
               Write-Verbose ("Removed module " + $module.Name)
           }
        }
    }
    end {}
}