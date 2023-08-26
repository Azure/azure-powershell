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
        $Content, # The type of this parameter is dynamic. Omitting the type here to avoid exception.

        [Parameter()]
        [switch] $IsHtml
    )

    $emailClient = [Azure.Communication.Email.EmailClient]::new($EmailServiceConnectionString)

    $emailContent = [Azure.Communication.Email.EmailContent]::new($Subject)
    if ($IsHtml.IsPresent) {
        $emailContent.Html = $Content
    }
    else {
        $emailContent.PlainText = $Content
    }

    $emailTo = $To.Split(";", [StringSplitOptions]::RemoveEmptyEntries) | ForEach-Object {
        [Azure.Communication.Email.EmailAddress]::new($_)
    }
    $emailRecipients = [Azure.Communication.Email.EmailRecipients]::new([System.Collections.Generic.List[Azure.Communication.Email.EmailAddress]]$emailTo)

    $emailMessage = [Azure.Communication.Email.EmailMessage]::new($EmailFrom, $emailRecipients, $emailContent)

    Write-Host "##[section]Start sending email notification."

    try {
        $emailClient.Send([Azure.WaitUntil]::Completed, $emailMessage)
    }
    catch {
        Write-Error "Failed to send email notification with error message: $($_.Exception.Message)."
    }

    Write-Host "##[section]Finished sending email notification."
}

InitializeEmailServicePackages
