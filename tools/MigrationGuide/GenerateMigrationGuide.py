import openpyxl
from pathlib import Path
import argparse

ap = argparse.ArgumentParser()
ap.add_argument("-i", "--input", required=True, help="Input Excel File Path")
ap.add_argument("-o", "--output", required=True, help="Output Markdown File Path")
args = vars(ap.parse_args())


xlsx_file = Path(args['input'])
wb_obj = openpyxl.load_workbook(xlsx_file)
sheet = wb_obj.active


with open(args['output'], 'w') as f:
    f.write('# Migration Guide\n')
    current_module_name = ""
    row_num = 0
    for row in sheet.iter_rows(max_col=5):
        if row_num == 0:
            row_num += 1
            continue
        module_name, cmdlet_name, desc, before_example, after_example = map(lambda x: x.value, row)
        if module_name != current_module_name:
            current_module_name = module_name
            f.write('\n\n## %s\n' % module_name)
        f.write('\n### `%s`\n' % cmdlet_name)
        f.write('%s\n' % '\n'.join(map(lambda x: '- ' + x, desc.split('\n'))))
        if before_example is not None:
            f.write('#### Before\n%s\n' % before_example)
        if after_example is not None:
            f.write('#### After\n%s\n' % after_example)
        row_num += 1
