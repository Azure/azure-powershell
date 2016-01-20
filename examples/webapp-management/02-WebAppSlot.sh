#!/bin/env/bash
set -e
printf "\n=== Managing Web App Slot in Azure ===\n"

pingwebapp() {
	url=`echo "$1" | jq '."HostNames"[0]' --raw-output`
	curl -I `echo "$url"`
}

#setup
printf "\nSetup: Creating a new resource group: %s at location: %s.\n" "$groupName" "$location"

slotname1="staging"
slotname2="testing"
slotname3="staging"
tier1="Standard"
tier2="Premium"
apiversion="2015-08-01"
resourceType="Microsoft.Web/sites"

az resource group create --name "$groupName" --location "$location"

printf "\n1. Create a new app service plan %s " "$planName1"
az appservice plan create -n "$planName1" -g "$groupName" -l "$location" --tier "$tier1"

printf "\n2. Create a new web app %s " "$appName1"
webappInfo1=`az appservice create -g "$groupName" -n "$appName1" -l "$location" --plan "$planName1"`

printf "\nValidating web app name %s " "$appName1"
[ $(echo $webappInfo1 | jq '.Name' --raw-output) == "$appName1" ]

printf "\n3. Create a web app slot %s " "$slotname1"
slot1=`az appservice slot create -g "$groupName" --plan "$planName1" -n "$appName1" --slot "$slotname1"`
appWithSlotName1="$appName1/$slotname1"

printf "\nValidating web app slot %s " "$slotname1"
[ $(echo $slot1 | jq '.Name' --raw-output) == "$appWithSlotName1" ]

printf "\nValidating web app slot get for %s " "$slotname1"
slot1=`az appservice slot ls -g "$groupName" -n "$appName1" --slot "$slotname1"`
[ $(echo $slot1 | jq '.Name' --raw-output) == "$appWithSlotName1" ]

printf "\nValidating web app slot via pipline obj for %s " "$slotname1"
slot1=`echo "$webappInfo1" | az appservice slot ls --slot "$slotname1"`

printf "\n4. Create another web app slot %s " "$slotname2"
slot2=`az appservice slot create -g "$groupName" --plan "$planName1" -n "$appName1" --slot "$slotname2"`
appWithSlotName2="$appName1/$slotname2"

printf "\n5. Get the webapp slots:"
slots=`az appservice slot ls -g "$groupName" -n "$appName1"`
slotN1=`echo $slots | jq '.[0].Name'`
slotN2=`echo $slots | jq '.[1].Name'`
slotNames=`echo $slotN1 $slotN2`

printf "\nValidating web app slots %s " "$slotname1 and $slotname2" 
[[ $slotNames == *"$appWithSlotName1"* ]]
[[ $slotNames == *"$appWithSlotName2"* ]]

printf "\n6. Change web app slot %s service plan" "$slotname2"
servicePlanInfo2=`az appservice plan create -n "$planName2" -g "$groupName" -l "$location" --tier "$tier2"`
# slot3=`az appservice slot create -g "$groupName" --plan "$planName3" -n "$appName" --slot "$slotname2"`
slot1=`az appservice slot set -g "$groupName" -n "$appName1" --slot "$slotname1" --plan "$planName2"`

printf "\nValidating web app slots %s " "$slotname1"
[ $(echo $slot1 | jq '.Name' --raw-output) == "$appName1/$slotname1" ]
[[ $(echo $slot1 | jq '."ServerFarmId"') == *"$planName2"* ]]

printf "\n7. Set web app slot %s config properties"
# Unable to test pipline. verity property name and value instead. 

printf "\n8. Set web app slot settings and connection strings"
appsettings="{\"setting1\":\"valueA\",\"setting2\":\"valueB\"}"
connectionstrings="{ \"connstring1\": { \"Type\": \"MySql\", \"Value\": \"string value 1\" }, \"connstring2\": { \"Type\": \"SqlAzure\", \"Value\": \"string value 2\" } }"
slot1=`az appservice slot set -g "$groupName" --plan "$planName1" -n "$appName1" --slot "$slotname1" --connectionstrings "$connectionstrings" --appsettings "$appsettings"`

printf "\n9. Get web app slot %s publishing profile" "$slotname1"
outputFile1="webappslot-profile-1"
outputFile2="webappslot-profile-2"
az appservice slot profile ls -g "$groupName" -n "$appName1" --slot "$slotname1" --outputfile "$outputFile1"

printf "\n10. Get web app slot %s publishing profile via pipline obj" "$slotname1"
# Unable to test pipline. verity property name and value instead. 
# echo "$slot1" | az appservice slot profile ls --outputfile "$outputFile2"

printf "\nValidating web app slot profile output file" 
[ -s "$outputFile1" ]
# [ -s "$outputFile2" ]

printf "\n11. Get web app slot metrics %s " "$slotname1"
for i in {1..10}
do
	pingwebapp "$slot1"
done

endTime=`date +"%A, %B %d, %Y %X"`
startTime=`date +"%A, %B %d, %Y %X" --date "3 hour ago"`
metricsNames="[\"CPU\",\"Request\"]"
metrics=`az appservice slot metrics ls -g "$groupName" -n "$appName1" --slot "$slotname1" --granularity PT1M --starttime "$startTime" --endtime "$endTime" --metrics "$metricsNames"`

printf "\nValidating web app slot metrics via pipline obj %s " "$slotname1" 
# Unable to test pipline. verity property name and value instead. 
# echo "$slot1" | az appservice slot metrics ls --metrics "$metricsNames" --starttime "$startTime" --endtime "$endTime" --granularity PT1M

printf "\n12. Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az appservice slot stop`
printf "\nValidating web app slot %s stopped " "$slotname1" 
[ $(echo $slot1 | jq '."State"' --raw-output) == "Stopped" ]

printf "\n13 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az appservice slot start`
printf "\nValidating web app slot %s running " "$slotname1" 
[ $(echo $slot1 | jq '."State"' --raw-output) == "Running" ]

printf "\n14 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az appservice slot stop`
printf "\nValidating web app slot %s stopped " "$slotname1" 
[ $(echo $slot1 | jq '."State"' --raw-output) == "Stopped" ]

printf "\n15 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | az appservice slot start`
printf "\nValidating web app slot %s running " "$slotname1" 
[ $(echo $slot1 | jq '."State"' --raw-output) == "Running" ]

printf "\n16 Restart web app slot: %s." "$slotname1"
slot1=`az appservice slot restart -g "$groupName" -n "$appName1" --slot "$slotname1"`
printf "\nValidating web app slot %s Running " "$slotname1" 
[ $(echo $slot1 | jq '."State"' --raw-output) == "Running" ]

printf "\n17 Restart web app slot: %s with pipline object." "$slotname1"
slot1=`echo "$slot1" | az appservice slot restart`
printf "\nValidating web app slot %s Running " "$slotname1" 
[ $(echo $slot1 | jq '."State"' --raw-output) == "Running" ]

# Need to create a 'Premium' plan for clone test
printf "\n18. Create a new web app for clone testing"
location1="eastus"

az appservice plan set -n "$planName1" -g "$groupName" --tier "$tier2"
webappInfo2=`az appservice create -g "$groupName" -n "$appName3" -l "$location" --plan "$planName1"`

printf "\n19. Clone web app slot to a slot."
slotClone=`az appservice slot create -g "$groupName" -n "$appName3" --slot "$slotname3" --sourcewebapp "$webappInfo2"`
appWithSlotNameClone="$appName3/$slotname3"

printf "\nValidating cloned web app slot %s " "$slotname3"
[ $(echo $slotClone | jq '.Name' --raw-output) == "$appWithSlotNameClone" ]

printf "\nValidating web app slot get for %s " "$slotname3"
slotClone=`az appservice slot ls -g "$groupName" -n "$appName3" --slot "$slotname3"`
[ $(echo $slotClone | jq '.Name' --raw-output) == "$appWithSlotNameClone" ]

printf "\n20. Create a new web app for clone testing"
slot2=`az appservice slot create -g "$groupName" --plan "$planName1" -n "$appName3" --slot "$slotname3"`

printf "\n21. Create a new web app for clone testing"
servicePlan=`az appservice plan create -n "$planName3" -g "$groupName" -l "$location1" --tier "$tier2"`
webappInfo3=`az appservice create -g "$groupName" -n "$appName4" -l "$location1" --plan "$planName3"`
slot3=`az appservice slot create -g "$groupName" --plan "$planName3" -n "$appName4" --slot "$slotname3" --sourcewebapp "$slot2"`

printf "\nValidating web app slot ls for %s " "$slotname3" 
appWithSlotName3="$appName4/$slotname3"
[ $(echo $slot3 | jq '.Name' --raw-output) == "$appWithSlotName3" ]

# Cleanup
printf "\n22. Remove web app slot: %s." "$slotname1"
az appservice slot rm -g "$groupName" -n "$appName1" --slot "$slotname1" --force
az appservice slot rm -g "$groupName" -n "$appName1" --slot "$slotname2" --force

printf "\n23. Remove resource group: %s." "$groupName"
az resource group rm --name "$groupName" --force