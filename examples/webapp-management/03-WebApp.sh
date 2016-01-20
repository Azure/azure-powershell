#!/bin/env/bash
printf "\n=== Managing Web Apps in Azure ===\n"

printf "\nSetup: Creating a new resource group: %s at location: %s.\n" "$groupName" "$location"
az resource group create --name "$groupName" --location "$location"

slotname1="staging"
slotname2="testing"
tier1="Shared"
tier2="Standard"
tier3="Premium"

printf "\nSetup: Creating a new app service plan: %s under resource group: %s.\n" "$planName1" "$groupName"
serverFarm=`az appservice plan create -n "$planName1" -g "$groupName" -l "$location" --tier "$tier1"`

printf "\n1: Creating a new webapp: %s under resource group: %s.\n" "$appName1" "$groupName"
actual1=`az appservice create -g "$groupName" -l "$location" -n "$appName1" --plan "$planName1"`

printf "\n2: Getting info about webapp: %s.\n" "$appName1"
result=`az appservice ls -g "$groupName" -n "$appName1"`
[ $(echo $result | jq '.Name' --raw-output) == "$appName1" ]
[ $(echo $result | jq '.serverFarmId' --raw-output) == $(echo $serverFarm | jq '.id' --raw-output) ]

printf "\n3: Creating a new webapp: %s under resource group: %s.\n" "$appName2" "$groupName"
actual2=`az appservice create -g "$groupName" -l "$location" -n "$appName2" --plan "$planName1"`
[ $(echo $actual2 | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $actual2 | jq '."serverFarmId"' --raw-output) == $(echo $serverFarm | jq '.id' --raw-output) ]

printf "\n4: Get WebApp by ResourceGroup: %s.\n" "$groupName"
count=`az appservice ls -g "$groupName"`
[ $(echo $count | jq -s '. | length') -eq 2 ]

printf "\n5: Get WebApp by App Plan :%s.\n" "$planName1"
count=`az appservice ls --plan "$serverFarm"`
[ $(echo $count | jq -s '. | length') -eq 2 ]

printf "\n6: Get WebApp by location :%s.\n" "$location"
count=`az appservice ls -l "$location"`
[ $(echo $count | jq -s '. | length') -ge 2 ]

printf "\n7: Get WebApp under the current subscription.\n"
count=`az appservice ls`
[ $(echo $count | jq -s '. | length') -ge 2 ]

printf "\n8: Get WebApp metrics ['CPU', 'Requests'] for webapp: %s" "$appName1"
start=`date +"%Y-%m-%dT%H:%M:%SZ"`
metricsInfo=`az appservice metrics ls -g "$groupName" -n "$appName1" --starttime "$start" --granularity PT1M --metrics "[\"CPU\", \"Requests\"]"`
[ $(echo $metricsInfo | jq -s '. | length') -eq 2 ]
[ $(echo $metricsInfo | jq -sr '. [0].name.value') == "Requests" ] || [ $(echo $metricsInfo | jq -sr '. [0].name.value') == "CPU" ]
[ $(echo $metricsInfo | jq -sr '. [1].name.value') == "CPU" ] || [ $(echo $metricsInfo | jq -sr '. [1].name.value') == "Requests" ]

printf "\n9: Creating a new app service plan: %s under resource group: %s.\n" "$planName2" "$groupName"
serverFarm2=`az appservice plan create -n "$planName2" -g "$groupName" -l "$location" --tier "$tier2"`

printf "\n10: Change webapp: %s to new service plan: %s\n" "$appName2" "$planName2"
changePlan=`az appservice set -g "$groupName" -n $appName2 --plan $planName2`
[ $(echo $changePlan | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $changePlan | jq '."serverFarmId"' --raw-output) == $(echo $serverFarm2 | jq '.id' --raw-output) ]

printf "\n11: Set config properties 'httpLoggingEnabled' & 'requestTracingEnabled' of the webapp: %s to true.\n" "$appName2"
changePlan=`echo $changePlan | jq '."siteConfig"."httpLoggingEnabled"'=true`
changePlan=`echo $changePlan | jq '."siteConfig"."requestTracingEnabled"'=true`
changePlan=`echo $changePlan | az appservice set`
[ $(echo $changePlan | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $changePlan | jq '."serverFarmId"' --raw-output) == $(echo $serverFarm2 | jq '.id' --raw-output) ]
[ $(echo $changePlan | jq '."siteConfig"."httpLoggingEnabled"' --raw-output) == true ]
[ $(echo $changePlan | jq '."siteConfig"."requestTracingEnabled"' --raw-output) == true ]

printf "\n12: Set appsettings and connectionstrings of the webapp: %s.\n" "$appName2"
appsettings="{\"setting1\":\"valueA\",\"setting2\":\"valueB\"}"
constr="{ \"connstring1\": { \"Type\": \"MySql\", \"Value\": \"string value 1\" }, \"connstring2\": { \"Type\": \"SqlAzure\", \"Value\": \"string value 2\" } }"

setconn=`az appservice set -g "$groupName" -n "$appName2" --appsettings "$appsettings" --connectionstrings "$constr"`
[ $(echo $setconn | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $setconn | jq '."siteConfig"."appSettings" | length') -eq 2 ]
[ $(echo $setconn | jq '."siteConfig"."connectionStrings" | length') -eq 2 ]

app=`echo $setconn | jq -r '."siteConfig"."appSettings"'`
[ $(echo $app | jq -r '.[0].name') == "setting2" ]
[ $(echo $app | jq -r '.[0].value') == "valueB" ]
[ $(echo $app | jq -r '.[0].name') == "setting1" ]
[ $(echo $app | jq -r '.[0].value') == "valueA" ]

conexn=`echo $setconn | jq -r '."siteConfig"."connectionStrings"'`
[ $(echo $conexn | jq -r '.[0].name') == "connstring1" ]
[[ $(echo $conexn | jq -r '.[0].connectionString') == "string value 1" ]]
[ $(echo $conexn | jq -r '.[0].type') == "MySql" ]
[ $(echo $conexn | jq -r '.[1].name') == "connstring2" ]
[[ $(echo $conexn | jq -r '.[1].connectionString') == "string value 2" ]]
[ $(echo $conexn | jq -r '.[1].type') == "SQLAzure" ]

printf "\n13: Stop the webapp: %s.\n" "$appName2"
stop=`az appservice stop -g "$groupName" -n "$appName2"`
[ $(echo $stop | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $stop | jq '."state"' --raw-output) == "Stopped" ]

printf "\n14: Start the webapp: %s.\n" "$appName2"
start=`az appservice start -g "$groupName" -n "$appName2"`
[ $(echo $start | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $start | jq '."state"' --raw-output) == "Running" ]

printf "\n15: Stop the webapp: %s again.\n" "$appName2"
stop=`az appservice stop -g "$groupName" -n "$appName2"`
[ $(echo $stop | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $stop | jq '."state"' --raw-output) == "Stopped" ]

printf "\n16: Start the webapp: %s again.\n" "$appName2"
start=`az appservice start -g "$groupName" -n "$appName2"`
[ $(echo $start | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $start | jq '."state"' --raw-output) == "Running" ]

printf "\n17: Restart the webapp: %s.\n" "$appName2"
start=`az appservice restart -g "$groupName" -n "$appName2"`
[ $(echo $start | jq '.name' --raw-output) == "$appName2" ]
[ $(echo $start | jq '."state"' --raw-output) == "Running" ]

printf "\n18: Creating a new app service plan: %s under resource group: %s with Premium tier.\n" "$planName3" "$groupName"
serverFarm3=`az appservice plan create -n "$planName3" -g "$groupName" -l "$location" --tier "$tier3"`
[ $(echo $serverFarm3 | jq '.name' --raw-output) == "$planName3" ]

printf "\n19: Changing plan: %s to Premium tier.\n" "$planName1"
plan1set=`az appservice plan set -n "$planName1" -g "$groupName" --tier "$tier3"`
[ $(echo $plan1set | jq '.sku.tier' --raw-output) == "$tier3" ]

printf "\n20: Cloning a new webapp: %s from an existing webapp: %s.\n" "$appName3" "$appName1"
clone=`az appservice create -g "$groupName" -l "$location" -n "$appName3" --plan "$planName3" --sourcewebapp "$actual1"`
[ $(echo $clone | jq '.name' --raw-output) == "$appName3" ]

printf "\n21: Get the newly created webapp: %s.\n" "$appName3"
result3=`az appservice ls -g "$groupName" -n "$appName3"`
[ $(echo $result3 | jq '.name' --raw-output) == "$appName3" ]

#Need to ask the webapp team about the creation of traffic manager profile
#printf "\n22: Creating a new app service plan: %s under resource group: %s with Premium tier.\n" "$planName4" "$groupName"
#serverFarm4=`az appservice plan create -n "$planName4" -g "$groupName" -l "$location" --tier "$tier3"`
#[ $(echo $serverFarm4 | jq '.name' --raw-output) == "$planName4" ]

#profileName=`randomName profile`
#printf "\n23: Cloning a new webapp: %s from an existing webapp: %s with traffic manager profile: %s.\n" "$appName4" "$appName3" "$profileName"
#cloneTraffic=`az appservice create -g "$groupName" -l "$location" -n "$appName4" --plan "$planName4" --sourcewebapp "$clone" --trafficmanagerprofilename "$profileName"`
#[ $(echo $cloneTraffic | jq '.name' --raw-output) == "$appName4" ]

#printf "\n24: Get the newly created webapp: %s.\n" "$appName4"
#result4=`az appservice ls -g "$groupName" -n "$appName4"`
#[ $(echo $result4 | jq '.name' --raw-output) == "$appName4" ]

filename=`randomName pf`
filename+=".xml"
printf "\n25: Get the publish profile for webapp: %s and save it to %s file\n." "$appName3" "$filename"
pubprof=`az appservice profile ls -g "$groupName" -n "$appName3" --outputfile "$filename"`
[ -e "$filename" ]
[ -s "$filename" ]

printf "\n26: Reset the publish profile for webapp: %s.\n" "$appName3"
az appservice profile reset -g "$groupName" -n "$appName3"

filename2=`randomName pf`
filename2+=".xml"
printf "\n27: Get the publish profile for webapp: %s after resetting and save it to %s file\n." "$appName3" "$filename2"
pubprof2=`az appservice profile ls -g "$groupName" -n "$appName3" --outputfile "$filename2"`
[ -e "$filename2" ]
[ -s "$filename2" ]

filename3=`randomName pf`
filename3+=".xml"
printf "\n28: Get the publish profile for webapp: %s in format FileZilla3 and save it to %s file\n." "$appName3" "$filename3"
az appservice profile ls -g "$groupName" -n "$appName3" --outputfile "$filename3" --format "FileZilla3"
[ -e "$filename3" ]
[ -s "$filename3" ]

printf "\n29:Remove created webapps: %s, %s, %s, %s.\n" "$appName1" "$appName2" "$appName3" "$appName4"
az appservice rm -g "$groupName" -n "$appName1" -f
az appservice rm -g "$groupName" -n "$appName2" -f
az appservice rm -g "$groupName" -n "$appName3" -f
#az appservice rm -g "$groupName" -n "$appName4" -f

printf "\n30:Remove the resource group: %s.\n" "$groupName"
deleterg=`az resource group rm -n "$groupName" --force`
