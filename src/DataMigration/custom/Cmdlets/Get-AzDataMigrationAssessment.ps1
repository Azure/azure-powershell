function Get-AzDataMigrationAssessment 
{
    [OutputType()]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Runs assessment on given Sql Servers')]

    param(
        [Parameter(ParameterSetName='CommandLine', Mandatory, HelpMessage='Sql Server Connection Strings')]
        [System.String[]]
        ${ConnectionStrings},


        [Parameter(ParameterSetName='CommandLine', HelpMessage='Output folder to store assessment report')]
        [System.String]
        ${OutputFolder},


        [Parameter(ParameterSetName='CommandLine', HelpMessage='Enable this parameter to overwrite the existing assessment report')]
        [System.Management.Automation.SwitchParameter]
        ${Overwrite},

        [Parameter(ParameterSetName='ConfigFile', Mandatory, HelpMessage='Path of the ConfigFile')]
        [System.String]
        ${ConfigFilePath}
    )

    process 
    {
        try 
        {
            #Defining Base and Exe paths
            $BaseFolder = $PSScriptRoot;
            $ExePath = Join-Path -Path $BaseFolder -ChildPath SqlAssessment.Console.csproj\SqlAssessment.exe;

            #Testing Whether Console App is downloaded or not
            $TestExePath =  Test-Path -Path $ExePath;

            #Downloading and extracting SqlAssessment Zip file
            if(-Not $TestExePath)
            {
                $ZipSource = "https://sqlassess.blob.core.windows.net/app/SqlAssessment.zip";
                $ZipDestination = Join-Path -Path $BaseFolder -ChildPath "SqlAssessment.zip";
                Invoke-RestMethod -Uri $ZipSource -OutFile $ZipDestination;

                Expand-Archive -Path $ZipDestination -DestinationPath $BaseFolder -Force;
            }

            #Running Assessment
            if(('CommandLine') -contains $PSCmdlet.ParameterSetName)
            {
                if(($PSBoundParameters.ContainsKey("OutputFolder")))
                {
                    if($PSBoundParameters.ContainsKey("Overwrite"))
                    {
                        & $ExePath Assess --sqlConnectionStrings $PSBoundParameters.ConnectionStrings --outputFolder $PSBoundParameters.OutputFolder; 
                    }
                    else
                    {
                        & $ExePath Assess --sqlConnectionStrings $PSBoundParameters.ConnectionStrings --outputFolder $PSBoundParameters.OutputFolder --overwrite False;
                        
                    }
                }
                else
                {
                    if(($PSBoundParameters.ContainsKey("Overwrite")))
                    {
                        & $ExePath Assess --sqlConnectionStrings $PSBoundParameters.ConnectionStrings;
                    }
                    else 
                    {
                        & $ExePath Assess --sqlConnectionStrings $PSBoundParameters.ConnectionStrings --overwrite False;
                    }
                } 
            }
            else
            {   
                Test-ConfigFile $PSBoundParameters.ConfigFilePath
                & $ExePath --configFile $PSBoundParameters.ConfigFilePath
            }

            Write-Host "Error and Event Logs Folder Path: C:\Users\$env:UserName\AppData\Local\Microsoft\SqlAssessment\Logs";
        }
        catch 
        {
            throw $_
        }

    }
}
