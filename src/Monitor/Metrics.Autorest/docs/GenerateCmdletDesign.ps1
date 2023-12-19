# The cmdlet format is define as verb-subject in this script. 
[CmdletBinding()]
param (
    [Parameter(Mandatory=$false,
    HelpMessage="The current path as the value of the path parameter if not passed Path parameter."
    )]
    [string]
    $Path,

    [Parameter(Mandatory=$false,
    HelpMessage="The Path parameter and the OutPath parameter are the same if not passed OutPath parameter."
    )]
    [string]
    $OutPath,

    [Parameter(Mandatory=$false,
    HelpMessage="Automatic intercept resource name(Accounts) from Az.Accounts.md if not passed ResourceName parameter.")]
    [string]
    $ResourceName,

    [Parameter(Mandatory=$false,
    HelpMessage="Specify the order of cmdlets in the design document.")]
    [string[]]
    $SubjectPriority
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
if (!$PSBoundParameters.ContainsKey("ResourceName")) {
    $ResourceName = (Get-ChildItem -Path $Path -Filter 'Az.*.md' -ErrorAction Stop).Name.Split(".")[1]
}

# Get all name and path of the cmdlets.
Write-Debug "Get all cmdlets md file under the $Path folder."
$cmdLets = Get-ChildItem -Path $Path -Filter '*-*.md' | Select-Object -Property FullName,Name

# Add Cmdlet, Verb, Subject property for sort object.
$cmdLets | Add-Member -NotePropertyName Cmdlet -NotePropertyValue $null
$cmdLets | Add-Member -NotePropertyName Verb -NotePropertyValue $null
$cmdLets | Add-Member -NotePropertyName Subject -NotePropertyValue $null

# set priority for the specified cmdlets.
if ($PSBoundParameters.ContainsKey("SubjectPriority")) {
    $priority = 0
    $SubjectPriorityHash = @{}
    foreach($cmdlet in $SubjectPriority) {
        $SubjectPriorityHash.Add($cmdlet, $priority++)
    }
}

for($index=0; $index -lt $cmdLets.Length; $index++) {
    # Join 0 prefix with New verb.
    $verb = $cmdLets[$index].Name.Split("-")[0] -eq 'New' ? '0New' : $cmdLets[$index].Name.Split("-")[0]
    # Join priority with Subject.
    $originSubject = $cmdLets[$index].Name.Split("-")[1].Split(".")[0];
    $subject = $null -eq $SubjectPriorityHash ? $originSubject : ($null -eq $SubjectPriorityHash[$originSubject] ? $originSubject : $SubjectPriorityHash[$originSubject].ToString() + $originSubject)
    
    $cmdLets[$index].Cmdlet =  $cmdLets[$index].Name.Split(".")[0];
    $cmdLets[$index].Verb = $verb
    $cmdLets[$index].Subject = $subject
}


$sortedCmdlets = $cmdLets | Sort-Object -Property @{Expression = "Subject"; Descending = $false},@{Expression = "Verb"; Descending = $false}

"The sorted cmdles list : " | Write-Debug
$sortedCmdlets | Out-String | Write-Debug

$designFile = 'Az.' + $ResourceName + '.design.md'

$outFilePath = Join-Path $OutPath $designFile

# Try remove out file
Write-Host -ForegroundColor Green "Delete the $designFile file if it exists."
Remove-Item -Path $outFilePath -ErrorAction SilentlyContinue


# Get cmdlet design message from the Verb-Subject.md file.
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

Write-Host -ForegroundColor Green "Genereated $designFile completed in $outFilePath. path."
return
}
catch {
    throw
    return
}