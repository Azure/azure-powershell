param (
    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $EmailServiceConnectionString,

    [Parameter(Mandatory)]
    [ValidateNotNullOrEmpty()]
    [string] $EmailFrom
)

function InitializeEmailServicePackages {
    [CmdletBinding()]
    param ()

    $svcPackagesDirName = "EmailServicePackages"
    $svcPackagesDir = Join-Path -Path . -ChildPath $svcPackagesDirName
    if (Test-Path -LiteralPath $svcPackagesDir) {
        Remove-Item -Path $svcPackagesDir -Recurse -Force
    }

    New-Item -Path . -Name $svcPackagesDirName -ItemType Directory -Force

    $svcPackages = @(
        @{ PackageName = "Azure.Communication.Email"; PackageVersion = "1.0.0"; DllName = "Azure.Communication.Email.dll" },
        @{ PackageName = "Azure.Core"; PackageVersion = "1.30.0"; DllName = "Azure.Core.dll" },
        @{ PackageName = "System.Memory.Data"; PackageVersion = "1.0.2"; DllName = "System.Memory.Data.dll" }
    )

    $svcPackages | ForEach-Object {
        $packageName = $_["PackageName"]
        $packageVersion = $_["PackageVersion"]
        $packageDll = $_["DllName"]
        Install-Package -Name $packageName -RequiredVersion $packageVersion -Source "https://www.nuget.org/api/v2" -Destination $svcPackagesDir -SkipDependencies -ExcludeVersion -Force
        Add-Type -LiteralPath (Join-Path -Path $svcPackagesDir -ChildPath $packageName | Join-Path -ChildPath "lib" | Join-Path -ChildPath "netstandard2.0" | Join-Path -ChildPath $packageDll) -ErrorAction SilentlyContinue
    }
}

function Send-EmailServiceMail {
    param (
        [Parameter(Mandatory)]
        [string] $To,

        [Parameter(Mandatory)]
        [string] $Subject,

        [Parameter(Mandatory)]
        $Body
    )

    $emailClient = [Azure.Communication.Email.EmailClient]::new($EmailServiceConnectionString)

    Write-Host "Sending email..."
    $emailClient.SendAsync([Azure.WaitUntil]::Completed, $EmailFrom, $To, $Subject, $Body).GetAwaiter().GetResult()
    Write-Host "Finished sending email."
}

InitializeEmailServicePackages
