import re
import os
import sys
# Usage: Pass the records file folder as command line argument
folderPath = sys.argv[1]
for fileName in os.listdir(folderPath):
    if not fileName.endswith('.json'):
        continue
    filePath = os.path.join(folderPath,fileName)
    print(filePath)
    f = open(filePath, "r")
    fileContent = f.read()
    f.close()
    uniqueKeys = set(re.findall(r'\\\"primaryKey\\\": \\\"([a-zA-Z0-9=]+)\\\"', fileContent))
    for key in re.findall(r'\\\"secondaryKey\\\": \\\"([a-zA-Z0-9=]+)\\\"', fileContent):
        uniqueKeys.add(key)
    repeat =3
    for key in uniqueKeys:
        fileContent = fileContent.replace(key, '*'*repeat)
        repeat = repeat+1
    f = open(filePath, "w")
    f.write(fileContent)
    f.close()