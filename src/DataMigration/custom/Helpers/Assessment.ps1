function Test-ConfigFile{
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

        $ConfigJson = Get-Content -Raw -Path $path | ConvertFrom-Json
        if(-Not (($ConfigJson.action -eq "Assess") -Or ($ConfigJson.action -eq "assess")))
        {
            throw "The desired action was invalid.";
        }

    }
}

function  Get-DefaultOutputFolder {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
    )

    process {
        $OSPlatform = $env:OS

        if($OSPlatform.Contains("Linux"))
        {
            $DefualtPath = Join-Path -Path $env:USERPROFILE -ChildPath ".config\Microsoft\SqlAssessment";

        }
        elseif ($OSPlatform.Contains("OSX"))
        {
            $DefualtPath = Join-Path -Path $env:USERPROFILE -ChildPath "Library\Application Support\Microsoft\SqlAssessment";
        }
        else
        {
            $DefualtPath = Join-Path -Path $env:LOCALAPPDATA -ChildPath "Microsoft\SqlAssessment";
        }

        return $DefualtPath

    }
    
}
