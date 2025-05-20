import re
import json

def process_content(content, splitor):
    chapters = []
    start_index = content.find(splitor)
    while start_index != -1:
        end_index = content.find(splitor, start_index + 1)
        if end_index == -1:
            chapters.append(content[start_index:])
        else:
            chapters.append(content[start_index:end_index])
        start_index = end_index
    if len(chapters) == 0:
        return content.strip()
    chapters = list(map(lambda x: x.strip(splitor).strip('\n'), chapters))
    result = {}
    for chapter in chapters:
        key = chapter.split('\n')[0]
        value = '\n'.join(chapter.split('\n')[1:])
        result[key] = value.strip()
    return result

def process_parameter_set_content(content):
    syntax = []
    if type(content) is str:
        syntax.append({
            'name': 'Default',
            'syntax': content.replace('\n', ' ').strip("```").strip()
        })
    else:
        for key in content.keys():
            syntax.append({
                'name': key,
                'syntax': content[key].replace('\n', ' ').strip("```").strip()
            })
    return syntax

def process_parameter_content(content):
    if type(content) is str:
        return []
    parameters = []
    for key in content.keys():
        if not key.startswith("-") or type(content[key]) is not str:
            continue
        text = content[key]
        parameter = {
            'name': key.strip('-').strip(),
        }
        description_group = re.search(r'^(.*?)(?=```)', text, re.MULTILINE | re.DOTALL)
        if description_group is not None and len(description_group.groups()) > 0:
            parameter['description'] = description_group.group(1).strip().replace('\n', '')
        type_value_group = re.search(r'Type:\s*(.*?)\n', text)
        if type_value_group is not None and len(type_value_group.groups()) > 0:
            parameter['type'] = type_value_group.group(1).strip().replace('System.Management.Automation.SwitchParameter', 'SwitchParameter').replace('System.', '')
        aliases_group = re.search(r'Aliases:\s+\n', text)
        if aliases_group is not None and len(aliases_group.groups()) > 0:
            parameter['alias'] = aliases_group.group(1).strip()
        accepted_values = re.search(r'Accepted values:\s*(.*?)\n', text)
        if accepted_values is not None and len(accepted_values.groups()) > 0:
            parameter['accepted_values'] = accepted_values.group(1).strip().split(',')
        parameters.append(parameter)
    return parameters

def process_example_content(content):
    examples = []
    if type(content) is str:
        if content.strip() == '':
            pass
        else:
            examples.append({
                "title": 'Example 1',
                "code": content.replace("PS C:\\>", "").strip()
            })
    else:
        for key in content.keys():
            example_content = content[key]
            
            powershell_blocks = []
            output_blocks = []
            
            lines = example_content.split('\n')
            powershell_blocks = []
            output_blocks = []
            start_index = 0
            index = 0
            while index < len(lines):
                if lines[index].lower().find('```powershell') != -1:
                    start_index = index
                    index += 1
                    while index < len(lines):
                        if lines[index].lower().find('```') != -1:
                            powershell_blocks.append('\n'.join(lines[start_index:index + 1]))
                            break
                        index += 1
                    index += 1
                elif lines[index].lower().find('```output') != -1:
                    start_index = index
                    index += 1
                    while index < len(lines):
                        if lines[index].lower().find('```') != -1:
                            output_blocks.append('\n'.join(lines[start_index:index + 1]))
                            break
                        index += 1
                    index += 1
                elif lines[index] == '```':
                    start_index = index
                    index += 1
                    while index < len(lines):
                        if lines[index].lower().find('```') != -1:
                            powershell_blocks.append('\n'.join(lines[start_index:index + 1]))
                            break
                        index += 1
                    index += 1
                else:
                    index += 1
            
            for code_block in powershell_blocks + output_blocks:
                example_content = example_content.replace(code_block, "")
            description = example_content.strip()
            example = {
                "title": key,
                "desc": description,
            }
            if len(powershell_blocks) > 0:
                code = ""
                for block in powershell_blocks:
                    code += '\n'.join(block.replace("PS C:\\>", "").strip().split('\n')[1:-1]) + "\n"
                example['code'] = code.strip()
            if len(output_blocks) > 0:
                code = ""
                for block in output_blocks:
                    code += '\n'.join(block.replace("PS C:\\>", "").strip().split('\n')[1:-1])
                example['output'] = code.strip()
            examples.append(example)
    return examples

def post_process_json(data):
    if 'SYNTAX' in data.keys():
        data['PARAMETER_SETS'] = process_parameter_set_content(data['SYNTAX'])
        data.pop('SYNTAX')
    if 'PARAMETERS' in data.keys():
        data['PARAMETERS'] = process_parameter_content(data['PARAMETERS'])
    if "EXAMPLES" in data.keys():
        data['EXAMPLES'] = process_example_content(data['EXAMPLES'])

def process_md_file(md_path):
    with open(md_path, 'r', encoding='utf8') as f:
        md = f.read()
    chapter_titles = ['SYNOPSIS', 'SYNTAX', 'PARAMETERS', 'DESCRIPTION', 'EXAMPLES', 'INPUTS', 'OUTPUTS', 'NOTES', 'RELATED LINKS']
    for chapter_title in chapter_titles:
        md = md.replace(f"\n## {chapter_title}\n", f"\n@## {chapter_title}\n")
    result = process_content(md, '\n@## ')
    if type(result) == str:
        return
    for key in result.keys():
        result[key] = process_content('\n' + result[key], '\n### ')
    post_process_json(result)

    with open(md_path.replace('.md', '.json'), 'w') as f:
        json.dump(result, f, indent=4)
