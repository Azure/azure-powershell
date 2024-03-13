# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------


# Function Definitions

function Test-LoginMigrationsConfigFile{
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $path
    )

    process {
        if (!(Test-Path -Path $path))
        {
            throw "Invalid Config File path: $path"
        } 
    }
}

function  Get-DefaultLoginMigrationsOutputFolder {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
    )

    process {
        $OSPlatform = Get-OSName

        if($OSPlatform.Contains("Linux"))
        {
            $DefualtPath = Join-Path -Path $env:USERPROFILE -ChildPath ".config\Microsoft\SqlLoginMigrations";

        }
        elseif ($OSPlatform.Contains("Darwin"))
        {
            $DefualtPath = Join-Path -Path $env:USERPROFILE -ChildPath "Library\Application Support\Microsoft\SqlLoginMigrations";
        }
        else
        {
            $DefualtPath = Join-Path -Path $env:LOCALAPPDATA -ChildPath "Microsoft\SqlLoginMigrations";
        }

        return $DefualtPath

    }
}

function Delete-OldLoginConsoleApp {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true, Position=0)]
        [System.String]
        $DownloadsFolder
    )

    process {
        #Remove old Login console app files
        #Old console app download address
        $ZipDestination = Join-Path -Path $DownloadsFolder -ChildPath "LoginsMigration.zip";

        # Remove old zip file
        if(Test-Path $ZipDestination)
        {
            Remove-Item -Path $ZipDestination;
        }

        # Remove existing folder and contents
        $ConsoleAppDestination = Join-Path -Path $DownloadsFolder -ChildPath "Logins.Console.csproj";
        if(Test-Path $ConsoleAppDestination)
        {
            Remove-Item -Path $ConsoleAppDestination -Recurse;
        }

        # Remove version file
        $VersionFileDestination = Join-Path -Path $DownloadsFolder -ChildPath "loginconsoleappversion.json";
        if(Test-Path $VersionFileDestination)
        {
            Remove-Item -Path $VersionFileDestination;
        }
    }
}


function Get-LatestConsoleAppVersionFromNugetOrg {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true, Position=0)]
        [System.String]
        $PackageId
    )

    process {
        $AvailablePackagesOnNugetOrg = ""

        try {
            $AvailablePackagesOnNugetOrg = Find-Package -Source "https://api.nuget.org/v3/index.json" -Name $PackageId -AllowPrereleaseVersions -AllVersions
            $AvailablePackagesOnNugetOrg = $AvailablePackagesOnNugetOrg | Sort-Object -Property Version -Descending
        } catch {
            Write-Host "Unable to connect to NuGet.org to check for updates."
        }

        $LatestNugetOrgName  = $AvailablePackagesOnNugetOrg[0].Name
        $LatestNugetOrgVersion = $AvailablePackagesOnNugetOrg[0].Version
        $LatestNugetOrgNameAndVersion = "$LatestNugetOrgName.$LatestNugetOrgVersion";

        return @{Name=$LatestNugetOrgName; Version=$LatestNugetOrgVersion; NameAndVersion=$LatestNugetOrgNameAndVersion}
    }
}

function CheckAndDownloadConsoleAppFromNugetOrg {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true, Position=0)]
        [AllowEmptyString()]
        [System.String]
        $LatestLocalNameAndVersion,

        [Parameter(Mandatory=$true, Position=1)]
        [HashTable]
        $LatestNugetOrgDetails,

        [Parameter(Mandatory=$true, Position=2)]
        [System.String]
        $ExePath,

        [Parameter(Mandatory=$true, Position=3)]
        [ref]
        [System.String]
        $LatestNugetFolder
    )

    process {
        #User consent for Login migration console app update. By default it is set to yes.
        $userUpdateConsent = "yes";

        # Prompt for user consent on Login migration console app update
        if($LatestLocalNameAndVersion -ne "" -and $LatestNugetOrgDetails.NameAndVersion -gt $LatestLocalNameAndVersion)
        {
            Write-Host "Newer Login migration console app nupkg version is available in Nuget.org...";
            while($true) {
                $userUpdateConsent = Read-Host -Prompt "Do you want to upgrade to the latest version? (yes/no)"

                if ($userUpdateConsent -eq "yes")
                {
                    Write-Host "You chose to upgrade. Proceeding..."
                    break;
                }
                elseif ($userUpdateConsent -eq "no")
                {
                    Write-Host "You chose not to upgrade."
                    $LatestNugetFolder.Value = Join-Path -Path $DownloadsFolder -ChildPath $LatestLocalNameAndVersion;
                    break;
                }
                else
                {
                    Write-Host "Invalid input. Please enter 'yes' or 'no'."
                }
            }
        }

        if ($LatestNugetOrgDetails.NameAndVersion -gt $LatestLocalNameAndVersion -and $userUpdateConsent -eq "yes")
        {
            #Update is available
            $DownloadUrl = "https://www.nuget.org/api/v2/package/$PackageId/$($LatestNugetOrgDetails.Version)"

            #Checking if LatestNugetFolder Path is valid or not
            if(-Not (Test-Path $LatestNugetFolder.Value))
            {
                $null = New-Item -Path $LatestNugetFolder.Value -ItemType "directory";
            }

            Write-Host "Downloading the latest Login migration console app nupkg: $($LatestNugetOrgDetails.NameAndVersion) ..."
            Invoke-WebRequest $DownloadUrl -OutFile "$($LatestNugetFolder.Value)\\$($LatestNugetOrgDetails.NameAndVersion).nupkg"

            $ToolsPathExists = Test-Path -Path (Join-Path -Path $LatestNugetFolder.Value -ChildPath "tools");

            if ($ToolsPathExists -eq $False)
            {
                $Nugets = Get-ChildItem -Path $LatestNugetFolder.Value -Filter "$PackageId.*.nupkg";

                if ($Nugets.Length -gt 0)
                {
                    Write-Host "Extracting the latest Login migration console app nupkg: $($LatestNugetOrgDetails.NameAndVersion) ..."
                    $Nugets = $Nugets | Sort-Object -Property Name -Descending;
                    $LatestNugetPath = $Nugets[0].FullName;
                    Expand-Archive -Path $LatestNugetPath -DestinationPath $LatestNugetFolder.Value;
                }
            }

            #Check if update was successful
            $TestPathResult = Test-Path -Path "$($LatestNugetFolder.Value)\$ExePath"

            $NugetVersions = Get-ChildItem -Path $DownloadsFolder -Filter "$PackageId.*";
            $NugetVersions = $NugetVersions | Sort-Object -Property Name -Descending

            if($TestPathResult)
            {
                Write-Host "Removing all older Login migration console apps..."
                #Remove all other NuGet versions except for the version just downloaded
                for ($NugetIndex = 0; $NugetIndex -lt $NugetVersions.Length; $NugetIndex = $NugetIndex + 1)
                {
                    if($NugetVersions[$NugetIndex].Name -ne $LatestNugetOrgDetails.NameAndVersion)
                    {
                        Remove-Item -Path $NugetVersions[$NugetIndex].FullName -Recurse -Force
                    }
                }
            }
            else
            {
                if($NugetVersions.Length -gt 0)
                {
                    $LatestNugetFolder.Value = $NugetVersions[0].Name;
                }
            }
        }
    }
}