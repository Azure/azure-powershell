import json
import subprocess
import sys
  
def get_converted_string(string, env_data):

    for key in env_data:
        string = string.replace(key, env_data[key])

    return string

def get_description(method_type, resource_type):
    description = ""

    if method_type == "List":
        return "List " + resource_type
    if method_type == "Get":
        return "Gets a " + resource_type + " by Name"
    if method_type == "GetViaIdentity":
        return "Gets a " + resource_type + "by identity (using pipe)"
    if method_type == "Create":
        return "Creates a " + resource_type 
    if method_type == "CreateViaIdentity":
        return "Creates a " + resource_type + "by identity (using pipe)"
    if method_type == "Delete":
        return "Deletes a " + resource_type + " by Name" 
    if method_type == "DeleteViaIdentity":
        return "Deletes a " + resource_type + "by identity (using pipe)"
    if method_type == "Update":
        return "Updates a " + resource_type 
    if method_type == "UpdateViaIdentity":
        return "Updates a " + resource_type + "by identity (using pipe)"

    return description
    
def print_to_file(command, description, output):
    return """```powershell
{command}
```

```output
{output}
```

{description}
""".format(command=command, description=description, output=output)


def get_output(command):

    output = ""


# open both files
    with open('../run-module.ps1','r') as firstfile, open('temp_command.ps1','w') as secondfile:     
        # read content from first file
        for line in firstfile:
                 # write content to second file
                 secondfile.write(line)

    
    with open("temp_command.ps1", "a") as command_file:
        add_text = "This text will be added to the file"
        print(command, file=command_file)
        command_file.close()
    try:
        output = subprocess.Popen(['powershell.exe', './temp_command.ps1'], stdout=sys.stdout)
        pass
    except Exception as e:
        print("error in command" + command)
    return output


def main():
    env_f = open('env.json')
    env_data = json.load(env_f)

    examples_f = open('commands_example.json')
    examples = json.load(examples_f)

    resources = examples["resources"]

    for resource in resources:
        resource_type = resource["type"]
        command_objs = resource["commands"]

        for command_obj in command_objs:
            method_type = command_obj["methodType"]
            command = command_obj["command"]
            description = command_obj.get("description", get_description(method_type, resource_type))

            command_converted = get_converted_string(command, env_data)
            
            output = get_output(command_converted)


            print(print_to_file(command_converted, description, output))
            break
        break

    env_f.close()
    examples_f.close()

if __name__ == '__main__':
    main()