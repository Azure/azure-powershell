#!/bin/bash
set -e
printf "\n=== Managing Web App Slot in Azure ===\n"

pingwebapp() {
	# a helper function to ping a webapp
	url=`echo $slot1 | jq '."properties.hostNames"[0]' --raw-output`
	curl -I `echo $url`
}

#setup
printf "\nSetup: Creating a new resource group: %s at location: %s.\n" "$groupName" "$location"

appName=`randomName testweb`
slotname1="staging"
slotname2="testing"
planName=`randomName testplan`
tier="Standard"
apiversion="2015-08-01"
resourceType="Microsoft.Web/sites"

azure group create --name "$groupName" --location "$location"

printf "\n1. Create a new app service plan %s " "$planName"
azure app service plan create -n "$planName" -g "$groupName" -l "$location" --tier "$tier"

printf "\n2. Create a new web app %s " "$appName"
webappInfo=`azure webapp create -g "$groupName" -n "$appName" -l "$location" --plan "$planName"`

printf "\nValidating web app name %s " "$appName"
[ $(echo $webappInfo | jq '.name' --raw-output) == "$appName" ]

printf "\n3. Create a web app slot %s " "$slotname1"
slot1=`azure webapp slot create -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname1"`
appWithSlotName1="$appName/$slotname1"

printf "\nValidating web app slot %s " "$slotname1"
[ $(echo $slot1 | jq '.name' --raw-output) == "$appWithSlotName1" ]

printf "\nValidating web app slot get for %s " "$slotname1"
slot1=`azure webapp slot get -g "$groupName" -n "$appName" --slot "$slotname1"`
[ $(echo $slot1 | jq '.name' --raw-output) == "$appWithSlotName1" ]

printf "\nValidating web app slot via pipline obj for %s " "$slotname1"
slot1=`echo "$webappInfo" | azure webapp slot get --slot "$slotname1"`

printf "\n4. Create another web app slot %s " "$slotname2"
slot2=`azure webapp slot create -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname2"`
appWithSlotName2="$appName/$slotname2"

printf "\n5. Get the webapp slots:"
slots=`azure webapp slot get -g "$groupName" -n "$appName"`
slotN1=`echo $slots | jq '.[0].name'`
slotN2=`echo $slots | jq '.[1].name'`
slotNames=`echo $slotN1 $slotN2`

printf "\nValidating web app slots %s " "$slotname1 and $slotname2" 
[[ $slotNames == *"$appWithSlotName1"* ]]
[[ $slotNames == *"$appWithSlotName2"* ]]

printf "\n6. Change web app slot %s service plan" "$slotname2"
appName2=`randomName testweb`
planName2=`randomName testplan`
servicePlanInfo3=`azure app service plan create -n "$planName3" -g "$groupName" -l "$location" --tier "$tier"`
# slot3=`azure webapp slot create -g "$groupName" --plan "$planName3" -n "$appName" --slot "$slotname2"`
slot1=`azure webapp slot set -g "$groupName" -n "$appName" --slot "$slotname1" --plan "$planName2"`


printf "\n7. Set web app slot %s config properties"
# Unable to test pipline. verity property name and value instead. 

printf "\n8. Set web app slot settings and connection strings"
appsettings="{\"setting1\":\"valueA\",\"setting2\":\"valueB\"}"
connectionstrings="{ \"connstring1\": { \"Type\": \"MySql\", \"Value\": \"string value 1\" }, \"connstring2\": { \"Type\": \"SqlAzure\", \"Value\": \"string value 2\" } }"
slot1=`azure webapp slot set -g "$groupName" --plan "$planName" -n "$appName" --slot "$slotname1" --connectionstrings "$connectionstrings" --appsettings "$appsettings"`


printf "\n9. Get web app slot %s publishing profile" "$slotname1"
outputFile1="webappslot-profile-1"
outputFile2="webappslot-profile-2"
azure webapp slot profile get -g "$groupName" -n "$appName" --slot "$slotname1" --outputfile "$outputFile1"

printf "\n10. Get web app slot %s publishing profile via pipline obj" "$slotname1"
# Unable to test pipline. verity property name and value instead. 
# echo "$slot1" | azure webapp slot profile get --outputfile "$outputFile2"

printf "\nValidating web app slot profile output file" 
[ -s "$outputFile1" ]
# [ -s "$outputFile2" ]


printf "\n11. Get web app slot metrics %s " "$slotname1"
for i in {1..10}
do
	pingwebapp $slot1
done

endTime=`date +"%A, %B %d, %Y %X"`
startTime=`date +"%A, %B %d, %Y %X" --date "3 hour ago"`
metricsNames="[\"CPU\",\"Request\"]"

metrics=`azure webapp slot metrics get -g "$groupName" -n "$appName" --slot "$slotname1" --granularity PT1M --starttime "$startTime" --endtime "$endTime" --metrics "$metricsNames"`

printf "\nValidating web app slot metrics via pipline obj %s " "$slotname1"
# Unable to test pipline. verity property name and value instead. 
# echo "$slot1" | azure webapp slot metrics get --metrics "$metricsNames" --starttime "$startTime" --endtime "$endTime" --granularity PT1M
 
printf "\n12. Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure webapp slot stop`
printf "\nValidating web app slot %s stopped " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Stopped" ]

printf "\n13 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure webapp slot start`
printf "\nValidating web app slot %s running " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n14 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure webapp slot stop`
printf "\nValidating web app slot %s stopped " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Stopped" ]

printf "\n15 Stop web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure webapp slot start`
printf "\nValidating web app slot %s running " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n16 Restart web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure webapp slot restart`
printf "\nValidating web app slot %s Running " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Running" ]

printf "\n17 Restart web app slot: %s." "$slotname1"
slot1=`echo "$slot1" | azure webapp slot restart`
printf "\nValidating web app slot %s Running " "$slotname1" 
[ $(echo $slot1 | jq '."properties.state"' --raw-output) == "Running" ]

# Clone ------
# Need to create a 'Premium' plan for clone test
printf "\n2. Create a new web app for clone testing"
groupName1=`randomName testrg`
appName1=`randomName testweb`
destAppName=`randomName testweb`
planName1=`randomName testplan`
destPlanName=`randomName testplan`
slotnameClone="staging"
tier1="Premium"
location1="eastus"

azure group create --name "$groupName1" --location "$location"
azure app service plan create -n "$planName1" -g "$groupName1" -l "$location" --tier "$tier1"
webappInfo=`azure webapp create -g "$groupName1" -n "$appName1" -l "$location" --plan "$planName1"`
printf "\n18. Clone web app slot to a slot."
slotClone=`azure webapp slot create -g "$groupName1" -n "$appName1" --slot "$slotnameClone" --sourcewebapp "$webappInfo"`
appWithSlotNameClone="$appName1/slotnameClone"

printf "\nValidating cloned web app slot %s " "$slotnameClone"
[ $(echo $slotClone | jq '.name' --raw-output) == "$appWithSlotNameClone" ]

printf "\nValidating web app slot get for %s " "$slotnameClone"
slotClone=`azure webapp slot get -g "$groupName" -n "$appName1" --slot "$slotnameClone"`
[ $(echo $slotClone | jq '.name' --raw-output) == "$appWithSlotNameClone" ]

printf "\n2. Create a new web app for clone testing"
slot1=`azure webapp slot create -g "$groupName1" --plan "$planName1" -n "$appName1" --slot "$slotnameClone"`
slotN1="$appname1$slotnameClone"

printf "\n2. Create a new web app for clone testing"
servicePlan=`azure app service plan create -n "$destAppName" -g "$groupName1" -l "$location1" --tier "$tier1"`
webappInfo2=`azure webapp create -g "$groupName1" -n "$destAppName" -l "$location1" --plan "$destPlanName"`
slot2=`azure webapp slot create -g "$groupName1" -n "$destAppName" --slot "$slotnameClone" --sourcewebapp "$webappInfo2"`

printf "\nValidating web app slot get for %s " "$slotnameClone" 


#------- 

# Cleanup
printf "\n20. Remove web app slot: %s." "$slotname1"
azure webapp slot remove -g "$groupName" -n "$appName" --slot "$slotname1" --force

printf "\n20. Remove web app: %s." "$appName"
azure webapp remove -g "$groupName" -n "$appName" --force

printf "\n20. Remove app service plan: %s." "$planName"
azure app service plan remove -g "$groupName" -n "$planName" --force

printf "\n20. Remove resource group: %s." "$groupName"
azure group remove --name "$groupName" --force