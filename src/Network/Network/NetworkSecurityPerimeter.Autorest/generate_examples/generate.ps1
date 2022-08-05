$envData = @{}


function getDescription($methodType, $resourceType){
    
    $description = ""

    if ($methodType -eq "List"){
        return "List " + $resourceType
    }
        
    if ($methodType -eq "Get"){
        return "Gets a " + $resourceType + " by Name"
    }
        
    if($methodType -eq "GetViaIdentity"){
        return "Gets a " + $resourceType + " by identity (using pipe)"
    }
       
    if($methodType -eq "Create"){
        return "Creates a " + $resourceType
    }

    if($methodType -eq "CreateViaIdentity"){
        return "Creates a " + $resourceType + " by identity (using pipe)"
    }
        
    if($methodType -eq "Delete"){
        return "Deletes a " + $resourceType + " by Name"
    }
    
    if($methodType -eq "DeleteViaIdentity"){
        return "Deletes a " + $resourceType + " by identity (using pipe)"
    }
        
    if($methodType -eq "Update"){
        return "Updates a " + $resourceType
    }
         
    if($methodType -eq "UpdateViaIdentity"){
        return "Updates a " + $resourceType + " by identity (using pipe)"
    }

    return $description

}


function getConvertedString($command){
    
    $command = $command.replace('$env.' , '')

    foreach ($h in $envData.GetEnumerator()) {
        $command = $command.replace($h.Key , $h.Value)
    }


    return $command
}


function main(){
    
    $previousEnv = Get-Content (Join-Path $PSScriptRoot '../test/env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $envData[$_.Name] = $_.Value }

        
    $json = Get-Content './commands_example.json' | Out-String | ConvertFrom-Json
        
    $resources = $json.resources

    Foreach($resource in $resources){

        $type = $resource.type

        echo "##################### $type starts ########################"

        $commandObjs = $resource.commands

        Foreach($commandObj in $commandObjs){
            $methodType = $commandObj.methodType
            $command = $commandObj.command
            $description = getDescription $methodType $type
            $commandConverted = getConvertedString $command            
            $commandArray = $commandConverted.Split("BREAKLINE")

            "" > ./temp_command.ps1

            Foreach($line in $commandArray){
                $line >> .\temp_command.ps1
            }

            $output = ./temp_command.ps1

            $outputString = $output | Format-Table | Out-String

            $outputCommand = Get-Content -Path .\temp_command.ps1
            
            $mdFileContent = "``````powershell

$outputCommand

``````

``````output
$outputString
``````
$description
"

            echo $mdFileContent

#>
        }

        echo "##################### $type ends \n\n\n"
    }
}

main
