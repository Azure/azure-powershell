_azcomp2()
{
	export params=$(printf "%s " "${COMP_WORDS[@]:1}")
    COMPREPLY=( $(./az ${params} --complete 2>&1 ) )
	return 0
}

complete -F _azcomp2 ./az