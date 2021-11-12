<#
.SYNOPSIS

Generate cmdlet design markdown for the specified azure module.

.DESCRIPTION

Adds a file name extension to a supplied name.
Takes any strings for the file name or extension.

.EXAMPLE

PS> GenerateCmdletDesignMarkdown.ps1 -Path 'azure-powershell\src\Databricks\docs' -OutPath 'azure-powershell\ModuleCmdletDesign' -OutputFileName 'Az.ApplicationInsights.Cmdlet.Design.md' -NounPriority 'AzDatabricksWorkspace','AzDatabricksVNetPeering'

Genereated azure-powershell\ModuleCmdletDesign\Az.ApplicationInsights.Cmdlet.Design.md completed.
#>
[CmdletBinding()]
param (
    [Parameter(Mandatory=$false,
    HelpMessage="The path is the docs folder path. Default current script path if not pass value."
    )]
    [string]
    $Path,

    [Parameter(Mandatory=$false,
    HelpMessage="The value the Path parameter and the OutPath parameter are the same if not passed OutPath parameter."
    )]
    [string]
    $OutPath,

    [Parameter(Mandatory=$false,
    HelpMessage="Automatic generate output file name  if not passed value.")]
    [string]
    $OutputFileName,

    [Parameter(Mandatory=$false,
    HelpMessage="Specify the order of cmdlets in the design document.")]
    [string[]]
    $NounPriority
)

try  {
# If the path parameter is null, let the current path as the value of the path parameter
if (!$PSBoundParameters.ContainsKey("Path")) {
    $Path = $PSScriptRoot
}

if (!$PSBoundParameters.ContainsKey("OutPath")) {
    $OutPath = $Path
}

# Get resource name
if (!$PSBoundParameters.ContainsKey("OutputFileName")) {
    $OutputFileName = 'Az.' + (Get-ChildItem -Path $Path -Filter 'Az.*.md' -ErrorAction Stop).Name.Split(".")[1] + 'Cmdlet.Design.md'
}

# Get all name and path of the cmdlets.
Write-Debug "Get all cmdlets md file under the $Path folder."
$cmdLets = Get-ChildItem -Path $Path -Filter '*-*.md' | Select-Object -Property FullName,Name

# Add Cmdlet, Verb, Noun property for sort object.
$cmdLets | Add-Member -NotePropertyName Cmdlet -NotePropertyValue $null
$cmdLets | Add-Member -NotePropertyName Verb -NotePropertyValue $null
$cmdLets | Add-Member -NotePropertyName Noun -NotePropertyValue $null

# set priority for the specified cmdlets.
if ($PSBoundParameters.ContainsKey("NounPriority")) {
    $priority = 0
    $NounPriorityHash = @{}
    foreach($cmdlet in $NounPriority) {
        $NounPriorityHash.Add($cmdlet, $priority++)
    }
}

for($index=0; $index -lt $cmdLets.Length; $index++) {
    # Join 0 prefix with New verb.
    $verb = $cmdLets[$index].Name.Split("-")[0] -eq 'New' ? '0New' : $cmdLets[$index].Name.Split("-")[0]
    # Join priority with Noun.
    $originNoun = $cmdLets[$index].Name.Split("-")[1].Split(".")[0];
    $Noun = $null -eq $NounPriorityHash ? $originNoun : ($null -eq $NounPriorityHash[$originNoun] ? $originNoun : $NounPriorityHash[$originNoun].ToString() + $originNoun)
    
    $cmdLets[$index].Cmdlet =  $cmdLets[$index].Name.Split(".")[0];
    $cmdLets[$index].Verb = $verb
    $cmdLets[$index].Noun = $Noun
}


$sortedCmdlets = $cmdLets | Sort-Object -Property @{Expression = "Noun"; Descending = $false},@{Expression = "Verb"; Descending = $false}

"The sorted cmdles list : " | Write-Debug
$sortedCmdlets | Out-String | Write-Debug


$outFilePath = Join-Path $OutPath $OutputFileName

# Try remove output file
Write-Debug "Delete the $OutputFileName file if it exists."
Remove-Item -Path $outFilePath -ErrorAction SilentlyContinue


# Get cmdlet design message from the Verb-Noun.md file.
foreach($cmdlet in $sortedCmdlets) {
    $content = Get-Content -Path $cmdlet.FullName -ErrorAction Stop
    $contentStr = ($content | Out-String)
    $designDoc = $contentStr.Substring($contentStr.IndexOf("# $($cmdlet.Cmdlet)"),  $contentStr.IndexOf('## PARAMETERS') - $contentStr.IndexOf("# $($cmdlet.Cmdlet)"))
    
    if ($designDoc.Contains("{{ Add title here }}")) {
        $designDoc = $designDoc.Remove($designDoc.IndexOf('## DESCRIPTION'))
    } else {
        $designDoc = $designDoc.Remove($designDoc.IndexOf('## DESCRIPTION'), $designDoc.IndexOf('## EXAMPLES') - $designDoc.IndexOf('## DESCRIPTION'))
    }

    $designDoc = $designDoc -replace '```(\r\n\w{1})', '```powershell$1'
    $designDoc = $designDoc -replace '###', '+'
    $designDoc = $designDoc -replace '#+', '####'

    $designDoc | Out-File -FilePath $outFilePath -Append -ErrorAction Stop
}

Write-Host "Genereated $outFilePath completed."
return
}
catch {
    throw
    return
}