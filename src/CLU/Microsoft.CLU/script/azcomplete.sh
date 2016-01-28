_azcomp2()
{
	export params=$(printf "%s " "${COMP_WORDS[@]:1}")
    COMPREPLY=( $(${1} ${params} --complete) )
	return 0
}

complete -F _azcomp2 ./az