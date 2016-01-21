
# Jan-15 AzLinux Feedback Session
These scripts were shared with the team following the feedback session.  Please file any bugs/issues through [GitHub Issues](https://github.com/Azure/azure-powershell/issues).

## Chatty output [Link to script](https://github.com/Azure/azure-docker-extension/blob/7889a401ade48adf10c8290875c167cd68ffe25c/integration-test/test.sh#L144)

> note the 1>/dev/null, I can’t —quiet therefore I ended up doing this.

```
parallel -j$CONCURRENCY --xapply $cmd 1>/dev/null ::: ${vm_names[@]} ::: ${DISTROS[@]}
```

## Parallelization [script link](https://github.com/Azure/azure-docker-extension/blob/7889a401ade48adf10c8290875c167cd68ffe25c/integration-test/test.sh#L163-L172)

> "azure vm delete" does not accept multiple arguments. I ended up using GNU parallel.

```
local cmd="azure vm delete -b -q {}"
local vms=$(get_vms)

if [[ -z "$vms" ]]; then
  return
fi

# Print commands to be executed, then execute them
parallel --dry-run -j$CONCURRENCY "$cmd" ::: "${vms[@]}"
parallel -j$CONCURRENCY "$cmd" 1>/dev/null ::: "${vms[@]}"
```


## Filtering and JQ: [script link](https://github.com/Azure/azure-docker-extension/blob/7889a401ade48adf10c8290875c167cd68ffe25c/integration-test/test.sh#L155-L158)

> This one finds VM names starting with a specific prefix.

```
get_vms() {
	local list_json=$(azure vm list --json)
	echo $list_json | jq -r '.[].VMName' | grep "^$VM_PREFIX" | sort -n
}
```

## Env and context [script link](https://github.com/Azure/azure-docker-extension/blob/7889a401ade48adf10c8290875c167cd68ffe25c/integration-test/test.sh#L155-L158)

> This script does “azure config mode asm” && “azure account set” to a predefined test subscription (therefore messes up my env everytime I run it). So this new concept of context should help here too.

```
check_asm() {
	# capture "Current Mode: arm" from azure cmd output
	if [[ "$(azure)" != *"Current Mode: asm"* ]]; then
		cat <<- EOF
		azure CLI not in ASM mode (required for testing). Run:

		  azure config mode asm

		NOTE: internal versions in PIR don't propogate to ARM stack until they're
		published to PROD globally, hence 'asm')
		EOF
		exit 1
	fi
}
```
