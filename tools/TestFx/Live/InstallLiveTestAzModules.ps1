param (
    [Parameter(Mandatory)]
    [ValidateSet("PSGallery", "DailyBuild", IgnoreCase = $false)]
    [string] $Source,

    [Parameter()]
    [string] $AzPackagesLocation
)

switch ($Source) {
    "PSGallery" {
        Set-PSRepository -Name $Source -InstallationPolicy Trusted
    }
    "DailyBuild" {
        Register-PSRepository -Name $Source -SourceLocation $AzPackagesLocation -PackageManagementProvider NuGet -InstallationPolicy Trusted
    }
}

Install-Module -Name Az -Repository $Source -Scope CurrentUser -AllowClobber -Force
