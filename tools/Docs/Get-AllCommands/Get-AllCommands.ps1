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

function Test-BuildMamlFolder {

	Param
		  (
			[CmdletBinding()]
			[parameter(Mandatory=$true)]
			[String]
			$MamlFolderPath,
			[parameter(Mandatory=$true)]
			[String]
			$ModuleName,
			[parameter(Mandatory=$false)]
			[string[]]
			$MissingCommands
		  )
	
	#$MamlFolderPath = "\\srvua\PSPush2x\Main\DXPowerShellBlue\AGPM_Cmdlets\PSMAML\"
	$MamlFileNames = (Get-ChildItem -Path $MamlFolderPath | WHERE { $_.Name -like "*.xml"}).Name

	$CmdletCount = 0
	$ParmCount = 0
	$ShortDescCount = 0
	$LongDescCount = 0
	$HelpExCount = 0
	$InputObjectDesccount = 0
	$OutputObjectDesccount = 0
	$MissingContent = 0

	$jsonObject = New-Object -TypeName psobject
	$jsonObject | Add-Member -MemberType NoteProperty -Name "ModuleHelpFound" -Value "true"

	$OutArray = @()
	if($MissingCommands)
	{
		$array = $MissingCommands.Split(',')
		$missingCommandsJsonObject = New-Object -TypeName psobject

		foreach($missingCommand in $array)
		{
			$missingCommandsJsonObject | Add-Member -MemberType NoteProperty -Name $missingCommand -Value 0 -Force     
		}

		$jsonObject | Add-Member -MemberType NoteProperty -Name "MissingCommands" -Value $missingCommandsJsonObject -Force
	}

	foreach ($MamlFile in $MamlFileNames)
	{    
	
		$internalJsonObject = New-Object -TypeName psobject

		$FullName = $MamlFolderPath + $MamlFile

		[xml]$MamlXml = Get-Content $FullName

		$CmdletCount += 1
		$WarnCount = 0

		$CmdletName = $MamlXml.command.details.name          
		$CmdletName = $CmdletName.Trim()
	 

			# Short Description
			# Updated for PS MAML Files

		$ShortDescription = $MamlXml.command.details.description.para

		if ($ShortDescription.Length -gt 10 -and $ShortDescription)
		{
			$ShortDescCount += 1
		}
		else    
		{ 
			if (!$NoWarnings) 
			{ 
				$OutArray += "No short description for $CmdletName."
				$WarnCount += 1
				$internalJsonObject | Add-Member -MemberType NoteProperty -Name 'ShortDescription' -value 1  -Force
				
			}    
		}
		
		# Long Description
		# Updated for PS MAML Files

		$LongDescription = $MamlXml.command.description.para
		if ($LongDescription.Length -gt 10 -and $LongDescription)
		{
			$LongDescCount += 1
		}
		else    
		{ 
			if (!$NoWarnings) 
			{ 
				$OutArray += "No long description for $CmdletName."
				$WarnCount += 1
				$internalJsonObject | Add-Member -MemberType NoteProperty -Name 'LongDescription' -value 1  -Force
			}  	
		}
		
		# PS MAML Examples Count Check
		#Updated for PS MAML Files

		$MamlExamples = $MamlXml.command.examples.example

		if($MamlExamples)
		{
			$ExNumber = 0
			ForEach($Example in $MamlExamples)
			{
				$ExCount += 1
				$ExNumber += 1
				$ExampleNumber = "Example" + $ExNumber 

				if(!$Example.title)
				{
					$OutArray += "No example title found for an example in $CmdletName."
					$internalJsonObject | Add-Member -MemberType NoteProperty -Name ($ExampleNumber + "_Title") -value 1  -Force
				}
				if(!$Example.introduction.para)
				{
					$OutArray += "No example introduction found for an example in $CmdletName."
					$internalJsonObject | Add-Member -MemberType NoteProperty -Name ($ExampleNumber + "_Introduction") -value 3  -Force
				}
				if(!$Example.code)
				{
					$OutArray += "No example code found for an example in $CmdletName."
					$internalJsonObject | Add-Member -MemberType NoteProperty -Name ($ExampleNumber + "_Code") -value 1  -Force
				}
			}
		}
		else
		{
			$OutArray += "No examples found for $CmdletName."
			$internalJsonObject | Add-Member -MemberType NoteProperty -Name "Examples" -value 0  -Force
		}               	
	
		#Cmdlet Input Object Description
		#Updated for PS MAML Files
		$InputObjects = $MamlXml.command.inputTypes.inputType

		if($InputObjects)
		{
			foreach($InputObj in $InputObjects)
			{
				$inputObjName = $InputObj.type.name
				if ($inputObj.description.para.innertext)
				{
					$InputObjectDesccount += 1
				}
				else    
				{ 
					if (!$NoWarnings) 
					{ 
						$OutArray += "No input object description for $inputObjName in $CmdletName"
						$internalJsonObject | Add-Member -MemberType NoteProperty -Name "InputObject" -value 1  -Force
						$WarnCount += 1 
					}             
				}
			}
		}
		

		#PS MAML Output Object Description
		#Updated for PS MAML Files

		$OutPutObjects = $MamlXml.command.returnValues.returnValue
		if($OutPutObjects)
		{
			foreach($outputObj in $OutPutObjects)
			{			
				$outputObjName = $outputObj.type.name
				if ($outputObj.description.para.innertext)
				{
					$OutputObjectDesccount += 1
				}
				else    
				{ 
					if (!$NoWarnings) 
					{ 
						$OutArray += "No output object description for $outputObjName in $CmdletName"
						$WarnCount += 1 
						$internalJsonObject | Add-Member -MemberType NoteProperty -Name "OutputObject" -value 1  -Force
					}             
				}
			} 
		}

		# Parameter Descriptions
		#Updated for PS MAML Files
		$Parameters = $MamlXml.command.parameters.parameter 

		foreach ($parm in $Parameters)
		{
			$ParmCount += 1
			$ParmName = $parm.Name
			if ($parm.Description)
			{
				$ParmDescCount += 1
			}
			else
			{
				if (!$NoWarnings) 
				{
					$OutArray += "No parameter description for $CmdletName -$ParmName." 
					$WarnCount += 1
					$internalJsonObject | Add-Member -MemberType NoteProperty -Name "Parameter_$ParmName" -value 1 -Force
				}                  
			}         
		} 

		#Evaluates Missing Elements
	
		if ($WarnCount -ne 0) 
		{
			$MissingContent +=1
			$jsonObject | Add-Member -MemberType NoteProperty -Value $internalJsonObject -Name $CmdletName  -Force
		}
	}

	if($MissingContent -gt 0)
	{
		$OutFileName = ($MamlFolderPath + " \..\..\..\" + $ModuleName + "_Report_MISSING_CONTENT.txt")
	}
	else
	{
		$OutFileName = ($MamlFolderPath + " \..\..\..\" + $ModuleName + "_Report.txt")
	}

	#Computation of Percentage Complete
	$fShortDescPercent = "{0:P1}" -f ($ShortDescCount/$CmdletCount)
	$fLongDescPercent = "{0:P1}" -f ($LongDescCount/$CmdletCount)
	$fExPercent = "{0:P1}" -f ($ExCount/$CmdletCount)
	$fParmDescPercent = "{0:P1}" -f ($ParmDescCount/$ParmCount)
	$fMissingContentPercent = "{0:P1}" -f ($MissingContent/$CmdletCount)
	$fInputObject = "{0:P1}" -f ($InputObjectDesccount/$CmdletCount)
	$fOutputObjectDesc = "{0:P1}" -f ($OutputObjectDesccount/$CmdletCount)

	###Report Output into PowerShell Host
	#Header Message
	$OutArray += "`nReport Summary"
	$OutArray += "--------------"
	$OutArray += "Folder Path: $MamlFolderPath"
	$OutArray += "Commands: $CmdletCount"
	$OutArray += "Parameters: $ParmCount"
	
	#Short Desc Message
	$ShortDescMessage = "Short Descriptions: $ShortDescCount ( $fShortDescPercent )"
	if($fShortDescPercent -eq '100.0 %')
	{ 
		$OutArray += $ShortDescMessage 
	}
	else
	{ 
		$OutArray += $ShortDescMessage
	}
	
	#Long Desc Message
	$LongDescMessage = "Long Descriptions: $LongDescCount ( $fLongDescPercent )"
	if($fLongDescPercent -eq '100.0 %')
	{
		$OutArray += "Long Descriptions: $LongDescCount ( $fLongDescPercent )" 
	}
	else
	{ 
		$OutArray += $LongDescMessage 
	}
	
	#Example Message
	$ExamplesMessage = "Examples: $ExCount ( $fExPercent )"
	if($fExPercent -eq '100.0 %')
	{
		$OutArray += $ExamplesMessage 
	}
	else
	{ 
		$OutArray += $ExamplesMessage  
	}
	$OutArray += "     Minimum Required: $CmdletCount"
	
	#Input Object Message
	$InputObjectMessage = "Input Objects: $InputObjectDesccount ( $fInputObject )"
	if($fInputObject -eq '100.0 %')
	{ 
		$OutArray += $InputObjectMessage 
	}
	else
	{ 
		$OutArray += $InputObjectMessage 
	}
	
	#Output Object Message
	$OutputObjectMessage = "Output Object: $OutputObjectDesccount ( $fOutputObjectDesc )"
	if($fOutputObjectDesc -eq '100.0 %')
	{ 
		$OutArray += $OutputObjectMessage 
	}
	else
	{ 
		$OutArray += $OutputObjectMessage 
	}
	
	#Parameter Messaage
	$ParameterMessage = "Parameter Descriptions: $ParmDescCount ( $fParmDescPercent )"
	if($fParmDescPercent -eq '100.0 %')
	{ 
		$OutArray += $ParameterMessage 
	}
	else
	{ 
		$OutArray += $ParameterMessage 
	}
	
	#Error & Closing Message
	$OutArray += "Number of cmdlets missing content: $MissingContent ( $fMissingContentPercent )"
	$OutArray += "--------------" 
	$OutArray | Out-File -FilePath $OutFileName

	if(($MissingCommands.Count -gt 0) -or ($MissingContent -gt 0))
	{
		$OutFileName = ($MamlFolderPath + " \..\..\..\" + $ModuleName + ".json")
		$jsonObject | ConvertTo-Json -Depth 10 | Out-file $OutFileName
	}
}

function Split-HelpFiles {
	[Cmdletbinding()]
	Param
		  (
			 [parameter(Mandatory=$true)]
			 [String]
			 $InputXML,
		 
			 [parameter(Mandatory=$true)]
			 [String]
			 $OutputPath
		  )
	  
	$namespace = @{command="http://schemas.microsoft.com/maml/dev/command/2004/10"; maml="http://schemas.microsoft.com/maml/2004/10"; dev="http://schemas.microsoft.com/maml/dev/2004/10"}     

	if (!(test-path $OutputPath)) 
	{ 
		mkdir $OutputPath 
	}
	if (dir $InputXML | select-string "<helpItems")
	{
		$a = dir $inputXml | select-xml -Namespace $namespace -XPath "//command:command"
		If ($a)
		{ 
			Foreach ($cmdlet in $a)
			{
			   $xml = $cmdlet.node.outerxml
			   $cmdletName = (($xml | select-xml -namespace $namespace -XPath "//command:name").node.innerxml).trim()   
			   Set-content –value $xml –path $OutputPath\$CmdletName.xml -Encoding ASCII           
			}
		}    
		else 
		{ 
			"Error 101: The input file does not contain cmdlet help topics. For help, send e-mail to PowerShellHelpPub@microsoft.com." 
		}
	}    
	else 
	{ 
		"Error 102: The input file is not a module-level PSMAML file. For help, send e-mail to PowerShellHelpPub@microsoft.com." 
	}
}

function Get-AllBuildServerCommands {

	param
	(
		[parameter(mandatory=$true)][string]$ManifestFullName,
		[parameter(mandatory=$true)][string]$OutputPath
	)

	#TestValues
	#$OutputPath = ".\Output";

	#Clean Output Path Trailing \ if exists
	if($OutputPath.Substring(($OutputPath.Length - 1),1) -eq '\') 
	{
		$OutputPath = $OutputPath.Substring(0,$OutputPath.Length - 1)
	}

	#Find the Template XML
	$GettAllCommandsDirectory = ".\Templates"

	$PSRawData = "PSRawData.xml"
	$CmdletNameFile = "CmdletNames.txt"
	$ProjectOutputFile = "PSProject_Writer.xml"
	$Template = "PSProject_Template.xml"

	#Write to screen entered values
	Write-Host "-----------------------------------------------" -ForegroundColor White
	Write-Host "[Get All Commands]`n"`
			   "Manifest Path and Name   : " $ManifestFullName "`n" `
			   "Output Directory   : " $OutputPath "" `
			   -ForegroundColor Cyan
	#Load the list of nested files
	$Manifest = Test-ModuleManifest -Path $ManifestFullName
	$ManifestNestedModules = $Manifest.NestedModules

	$OutputPath = $OutputPath + "\" + $Manifest.Name

	#loop through each Nested Dll
	Foreach($NestedFile in $ManifestNestedModules)
	{
		
		$ModuleOutputPath = $OutputPath + "\" + $NestedFile.Name
		$ModuleOutputPath = (Get-Location).Path + $ModuleOutputPath.Substring(1,$ModuleOutputPath.Length - 1)
		Write-Host "Module Output Path " $ModuleOutputPath   
		Write-Host "-----------------------------------------------" -ForegroundColor White

		New-Item -ItemType Directory -Path $ModuleOutputPath -ErrorAction SilentlyContinue | Out-Null

		Import-Module $NestedFile.Path -Force

		$FileFullName = $ModuleOutputPath + "\" + $NestedFile.Name + ".txt"

		#Get the MAML, Split and Place it in the PSMAML directory
		$MamlOutPutPath = $ModuleOutputPath + "\MAML"
		$NestedFile | Add-Member -MemberType NoteProperty -Name "HelpXmlPath" -Value ($NestedFile.Path + "-help.xml") -Force
		New-Item -ItemType Directory -Path $MamlOutPutPath | Out-Null
		if(Test-Path -Path $NestedFile.HelpXmlPath)
		{
			Split-HelpFiles -InputXML ($NestedFile.HelpXmlPath) -OutputPath ($MamlOutPutPath) 
			Copy-Item -Path $NestedFile.HelpXmlPath -Destination $ModuleOutputPath
			$CommandsMissing = $false
			$MissingCommandsList = ""
			Get-Command -Module $NestedFile.Name | ForEach-Object `
			{
				if(!(Test-Path -Path ($ModuleOutputPath + "\PSMAML\" + $_.name + ".xml")))
				{
					$CommandsMissing = $true
					$MissingCommandsList += $_.name + ","
				}
			}
			if($CommandsMissing)
			{
				$MissingCommandsList = $MissingCommandsList.Substring(0,$MissingCommandsList.Length - 1)
				Test-BuildMamlFolder -MamlFolderPath ($MamlOutPutPath + "\") -ModuleName $NestedFile.Name -MissingCommands $MissingCommandsList
			}
			else
			{
				Test-BuildMamlFolder -MamlFolderPath ($MamlOutPutPath + "\") -ModuleName $NestedFile.Name
			}
		}
		else
		{
			#Create Json File for no help found
			$OutFileName = ($MamlOutPutPath + " \..\..\" + $NestedFile.Name + ".json")
			$jsonObject = New-Object -TypeName psobject
			$jsonObject | Add-Member -MemberType NoteProperty -Name "HelpFound" -Value "false"
			$jsonObject | ConvertTo-Json -Depth 10 | Out-file $OutFileName
		}
	
		#Get Cmdlet Names from the Module
		Get-Command -module $NestedFile.Name -CommandType cmdlet, function | select name | Out-File $FileFullName

		#Get XML Template File Contents

		[xml] $TemplateXml = Get-Content -Path ".\Templates\PSProject_Template.xml"

		#add in cmdlet names found in the module
		get-content $FileFullName | `
		Foreach `
		{
			$Cmdlet = $_.Trim()
			if ($Cmdlet.Contains("-") -eq $true -and $Cmdlet.Contains("--") -eq $false) 
			{
				$cmdletChild = $TemplateXml.CreateElement("Cmdlet")
				$cmdletChild.SetAttribute("name",$Cmdlet)
				$TemplateXml.Project.Cmdlets.AppendChild($cmdletChild) | Out-Null
			}
		}

		#Saves the PSProject_Writer file
		Write-Host "Writing Project File" -ForegroundColor Cyan
		New-Item -ItemType File -Path $ModuleOutputPath -Name "PSProject_Writer.xml" | Out-Null
		$ProjectOutputFile = $ModuleOutputPath + "\PSProject_Writer.xml"
		$TemplateXml.Save($ProjectOutputFile)

		#Get cmdlet data for the raw data file

		Write-Host "Writing Raw Data File" -ForegroundColor Cyan

		$AllOutput = @()

		[xml] $xmlProjectWriter = get-content $ProjectOutputFile 

		#Creates a XML 'raw data' file (PS MAML structural) for each cmdlet. They are then combined into a single RawData.xml file

		Write-Host "Processing: " -ForegroundColor Cyan

		Foreach($cmdlet in $xmlProjectWriter.Project.Cmdlets.Cmdlet) 
		{
		   $CmdletValues = @()   
		   Write-Host "     " $cmdlet.name -ForegroundColor Cyan
		   #retrieves the cmdlet information, Name, Type, Syntax, HelpURI
		   $command = Get-Command $Cmdlet.name #-ea silentlycontinue
		   $CmdletValues += $command.Name
		   $CmdletValues += $command.CommandType
		   $CmdletValues += Get-Command $Cmdlet.name -syntax
		   $CmdletValues += $command.HelpUri

		   foreach ($paramset in $command.ParameterSets)
		   {
			   #Gets all of the parameters from the parameters sets for the cmdlet
			   foreach ($param in $paramset.Parameters) 
			   {
				   $process = "" | Select-Object Name, Type, Enums, ParameterSet, Aliases, Position, IsMandatory,Pipeline, PipelineByPropertyName
				   $process.Name = $param.Name
				
				   if ( $param.ParameterType.Name -eq "SwitchParameter" ) 
				   {
					   $process.Type = "Boolean"
				   }
				   else
				   {
					   $process.Type = $param.ParameterType.FullName
				   }

				   if ($param.ParameterType.BaseType.Name -eq "Enum") 
				   {
					   $process.Enums = [ENUM]::GetNames($process.Type)
				   }
				   else
				   {
					   $process.Enums = $param.Attributes.ValidValues
				   }

				   if ( $paramset.name -eq "__AllParameterSets" ) 
				   {
					   $process.ParameterSet = "Default" 
				   }
				   else
				   {
					   $process.ParameterSet = $paramset.Name 
				   }

				   $process.Aliases = $param.aliases
				
				   if ( $param.Position -lt 0 ) 
				   {
					   $process.Position = $null 
				   }
				   else
				   {
					   $process.Position = $param.Position
				   }
				
				   $process.IsMandatory = $param.IsMandatory
				   $process.Pipeline = $param.ValueFromPipeline
				   $process.PipelineByPropertyName = $param.ValueFromPipelineByPropertyName
				
				   $CmdletValues += $process
				} 
			} 
		
		   $FileName = $cmdlet.name

		   #Create the single raw data file for a cmdlet
		   Write-Output $CmdletValues | export-clixml (Join-Path -Path $ModuleOutputPath -ChildPath $FileName".xml")        
		}
		#Raw Data generation complete

		#Write out all cmdlet data into one xml file
		[XML] $RawDataXml = New-Object System.XML.XMLDocument

		#adds MAML schema namespace to PowerShell XML object
		[System.XML.XmlNamespaceManager] $mngr = $RawDataXml.NameTable
		$nsName = "http://schemas.microsoft.com/powershell/2004/04"
		$mngr.AddNamespace("", $nsName)

		#create root node
		[System.XML.XMLNode]$newChild = $RawDataXml.AppendChild($RawDataXml.CreateNode([System.Xml.XmlNodeType](1), "PSCmdletData", $nsName))
		[System.XML.XMLNode]$RawDataXmlRoot=$RawDataXml.DocumentElement

		#write out individual xml files into main file
		Get-ChildItem -Path $ModuleOutputPath -Name -Include "*.xml" -Exclude 'PSProject_Writer.xml','*help.xml'  |
		ForEach-Object `
		{
			[System.XML.XMLDocument] $docCmdlet = New-Object System.XML.XMLDocument
			$docCmdlet.Load((Join-Path -Path $ModuleOutputPath -ChildPath $_))
			[System.XML.XMLNode] $rootCmdlet = $docCmdlet.DocumentElement
			[System.XML.XMLNode] $cmdletNode = $RawDataXml.ImportNode($rootCmdlet, $true)
			[System.XML.XMLNode] $newChild2 = $RawDataXmlRoot.AppendChild($cmdletNode)
			Remove-Item -Path (Join-Path -Path $ModuleOutputPath -ChildPath $_) 
		}
		#save main file
		$RawDataXml.Save((Join-Path -Path $ModuleOutputPath -ChildPath $PSRawData))

		#Creating XML object of Project Writer file
		[xml] $xmlProjectWriter = get-content $ProjectOutputFile

		#Get the Module GUID
		#$GUID = (Get-Module $ModuleName).GUID

		#Adding Guid to XML Object
		#$ModuleGuidElement = $xmlProjectWriter.CreateElement("GUID")
		#$ModuleGuidElement.SetAttribute("Guid",$GUID)
		#$xmlProjectWriter.Project.AppendChild($ModuleGuidElement) | Out-File Null

		#Adding Module name to XML Object
		$ModuleNameElement = $xmlProjectWriter.CreateElement("Module")
		$ModuleNameElement.SetAttribute("Name",$ModuleName)
		$xmlProjectWriter.Project.AppendChild($ModuleNameElement) | Out-File Null

		#Obtain Root Files for the Module
		#if($SubModule -eq $false)
		if(1 -eq 2)
		{
			Write-Host "`nGetting All Root Modules"
			Import-Module $ModuleName
			$ModuleManifest = Get-Module -Name $ModuleName
			$ModuleElements = $xmlProjectWriter.CreateElement("RootFiles")

			if($ModuleManifest.NestedModules)
			{
				foreach($RootFile in $ModuleManifest.NestedModules)
				{
					$ModuleElement = $xmlProjectWriter.CreateElement("RootFile")
					switch($RootFile.ModuleType)
					{
						"Cim" { $NestedModuleExtension = ".cdxml"}
						"Binary" { $NestedModuleExtension = ".dll" }
						"Script" { $NestedModuleExtension = ".psm1" }
					}

					$FileName = $RootFile.Name -replace ".dll|.psm1|.cdxml"
					$FileName += $NestedModuleExtension
					$ModuleElement.SetAttribute("name",$FileName)
					$ModuleElement.SetAttribute("type","Nested")
					$ModuleElements.AppendChild($ModuleElement) | Out-Null
				}
		
				$xmlProjectWriter.Project.AppendChild($ModuleElements)
			}

			if($ModuleManifest.RootModule)
			{
				$ModuleElements = $xmlProjectWriter.CreateElement("RootFiles")
				$ModuleElement = $xmlProjectWriter.CreateElement("RootFile")
				switch($ModuleManifest.ModuleType)
				{
					"Cim" { $NestedModuleExtension = ".cdxml"}
					"Binary" { $NestedModuleExtension = ".dll"}
					"Script" { $NestedModuleExtension = ".psm1" }
				}
				$FileName = $ModuleManifest.RootModule -replace ".dll|.psm1|.cdxml"

				$FileName += $NestedModuleExtension

				$ModuleElement.SetAttribute("name",$FileName)
				$ModuleElement.SetAttribute("type","Root")
				$ModuleElements.AppendChild($ModuleElement) | Out-Null
			}
			 $xmlProjectWriter.Project.AppendChild($ModuleElements) | Out-Null
		} 

		$xmlProjectWriter.Save($ProjectOutputFile)
		$ContentPath = ".\Templates\ProjectList.xml"
		Copy-Item -Path $ContentPath -Destination $ModuleOutputPath

		Remove-Item -Path $ModuleOutputPath\*.txt

		Write-Host $NestedFile.Name -ForegroundColor Yellow

		Write-Host "All Commands Obtained at: " $ModuleOutputPath  -ForegroundColor Yellow

	}
	Write-Host "-----------------------------------------------" -ForegroundColor White

}

rm .\Output -Recurse -Force -ErrorAction SilentlyContinue

#Comment these lines to selectivly build the output for either Service Management or Resource Manager
Get-AllBuildServerCommands -OutputPath ".\Output" -ManifestFullName "..\..\..\src\Package\Release\ServiceManagement\Azure\Azure.psd1"
Get-AllBuildServerCommands -OutputPath ".\Output" -ManifestFullName "..\..\AzureRM\AzureRM.psd1"

$modules = (Get-ChildItem "..\..\..\src\Package\Release\ResourceManager" -Recurse -Include "*.psd1" -Exclude "*dll-help.psd1", "AzureResourceManager.psd1", "AzureRM.Tags.psd1") | sort -Unique -Property Name
$modules += (Get-Item "..\..\..\src\Package\Release\ResourceManager\AzureResourceManager\AzureRM.Tags\AzureRM.Tags.psd1")
$modules | Foreach { Get-AllBuildServerCommands -OutputPath ".\Output" -ManifestFullName $_.FullName }

