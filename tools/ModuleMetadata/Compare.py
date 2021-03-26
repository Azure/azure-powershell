import json
import sys

newJsonPath = sys.argv[1]
oldJsonPath = sys.argv[2]


def getJsonObj(path):
    with open(path) as f:
        return json.load(f)

newJsonObj = getJsonObj(newJsonPath)
oldJsonObj = getJsonObj(oldJsonPath)

def compareMetadata(newMetadata, oldMetadata, ignoreKeyList=[]):
    result = {}
    for key in newMetadata:
        if key in ignoreKeyList:
            continue
        if newMetadata[key] != oldMetadata.get(key, None):
            result[key] = {
                'new': newMetadata[key],
                'old': oldMetadata.get(key, None)
            }

    for key in oldMetadata:
        if key in ignoreKeyList or key in result:
            continue
        if oldMetadata[key] != newMetadata.get(key, None):
            result[key] = {
                'old': oldMetadata[key],
                'new': newMetadata.get(key, None)
            }
    return result


def compareDict(newDict, oldDict, func):
    result = {}
    for key in newDict:
        if key not in oldDict:
            result[key] = {
                'new': newDict[key],
                'old': None
            }
            continue
        subResult = func(newDict[key], oldDict[key])
        if len(subResult) != 0:
            result[key] = subResult
    for key in oldDict:
        if key in newDict:
            continue
        result[key] = {
            'new': None,
            'old': oldDict[key]
        }
    return result


def compareParameterMetadata(newParameterMetadata, oldParameterMethdata):
    result = compareMetadata(newParameterMetadata, oldParameterMethdata, ['AliasList', 'Type', 'ValidateSet'])

    newAliasList = {item: item for item in newParameterMetadata.get('AliasList', [])}
    oldAliasList = {item: item for item in oldParameterMethdata.get('AliasList', [])}
    aliasListResult = compareMetadata(newAliasList, oldAliasList)
    if len(aliasListResult) != 0:
        result['AliasList'] = aliasListResult

    typeResult = compareTypeMetadata(newParameterMetadata.get('Type', {}), oldParameterMethdata.get('Type', {}))
    if len(typeResult) != 0:
        result['Type'] = typeResult

    newValidateSet = {item: item for item in newParameterMetadata.get('ValidateSet', [])}
    oldValidateSet = {item: item for item in oldParameterMethdata.get('ValidateSet', [])}
    validateSetResult = compareMetadata(newValidateSet, oldValidateSet)
    if len(validateSetResult) != 0:
        result['ValidateSet'] = validateSetResult

    return result


def compareMethodMetadata(newMethodMetadata, oldMethodMetadata):
    result = compareMetadata(newMethodMetadata, oldMethodMetadata, ['Parameters'])

    newParameters = {item['Name']: item for item in newMethodMetadata.get('Parameters', [])}
    oldParameters = {item['Name']: item for item in oldMethodMetadata.get('Parameters', [])}
    paramerterResult = compareDict(newParameters, oldParameters, compareMetadata)
    if len(paramerterResult) != 0:
        result['Parameters'] = paramerterResult
    return result


def compareTypeMetadata(newTypeMetadata, oldTypeMetadata):
    ignoreKeyList = ['AssemblyQualifiedName', 'Methods', 'Constructors', 'Properties']
    result = compareMetadata(newTypeMetadata, oldTypeMetadata, ignoreKeyList)

    newMethodMetadataList = {item['Name']: item for item in newTypeMetadata.get('Methods', [])}
    oldMethodMetadataList = {item['Name']: item for item in oldTypeMetadata.get('Methods', [])}
    methodsResult = compareDict(newMethodMetadataList, oldMethodMetadataList, compareMethodMetadata)
    if len(methodsResult) != 0:
        result['Methods'] = methodsResult

    newConstructorsMetadataList = {item['Name']: item for item in newTypeMetadata.get('Constructors', [])}
    oldConstructorsMetadataList = {item['Name']: item for item in oldTypeMetadata.get('Constructors', [])}
    constructorsResult = compareDict(newConstructorsMetadataList, oldConstructorsMetadataList, compareMethodMetadata)
    if len(constructorsResult) != 0:
        result['Constructors'] = constructorsResult

    newPropertiesMetadataList = newTypeMetadata.get('Properties', {})
    oldPropertiesMetadataList = oldTypeMetadata.get('Properties', {})
    propertiesResult = compareMetadata(newPropertiesMetadataList, oldPropertiesMetadataList)
    if len(propertiesResult) != 0:
        result['Properties'] = propertiesResult

    return result


def compareOutputTypeMetadata(newOutputMetadata, oldOutputMetadata):
    result = compareMetadata(newOutputMetadata, oldOutputMetadata, ['Type', 'ParameterSets'])
    typeResult = compareTypeMetadata(newOutputMetadata.get('Type', {}), oldOutputMetadata.get('Type', {}))
    if len(typeResult) != 0:
        result['Type'] = typeResult

    newParameterSet = {item: item for item in newOutputMetadata.get('ParameterSets', [])}
    oldParameterSet = {item: item for item in oldOutputMetadata.get('ParameterSets', [])}
    parameterSetResult = compareMetadata(newParameterSet, oldParameterSet)
    if len(parameterSetResult) != 0:
        result['ParameterSets'] = parameterSetResult

    return result

def compareParameterSetMetadata(newParameterSetMetadata, oldParameterSetMetadata):
    result = {}

    newParameters = {item['Name']: item for item in newParameterSetMetadata.get('Parameters', [])}
    oldParameters = {item['Name']: item for item in oldParameterSetMetadata.get('Parameters', [])}
    paramerterResult = compareDict(newParameters, oldParameters, compareParameterMetadata)
    if len(paramerterResult) != 0:
        result['Parameters'] = paramerterResult

    return result

def compareCmdletMetadata(newCmdletMetadata, oldCmdletMetadata):
    ignoreKeyList = ['OutputTypes', 'Parameters', 'ParameterSets', 'AliasList']
    result = compareMetadata(newCmdletMetadata, oldCmdletMetadata, ignoreKeyList)

    newOutputTypesMetadataList = {item['Type']['Name']: item for item in newCmdletMetadata.get('OutputTypes', [])}
    oldOutputTypesMetadataList = {item['Type']['Name']: item for item in oldCmdletMetadata.get('OutputTypes', [])}
    outputTypeResult = compareDict(newOutputTypesMetadataList, oldOutputTypesMetadataList, compareOutputTypeMetadata)
    if len(outputTypeResult) != 0:
        result['OutputTypes'] = outputTypeResult

    newParameters = {item['Name']: item for item in newCmdletMetadata.get('Parameters', [])}
    oldParameters = {item['Name']: item for item in oldCmdletMetadata.get('Parameters', [])}
    paramerterResult = compareDict(newParameters, oldParameters, compareParameterMetadata)
    if len(paramerterResult) != 0:
        result['Parameters'] = paramerterResult

    newParameterSets = {item['Name']: item for item in newCmdletMetadata.get('ParameterSets', [])}
    oldParameterSets = {item['Name']: item for item in oldCmdletMetadata.get('ParameterSets', [])}
    parameterSetsResult = compareParameterSetMetadata(newParameterSets, oldParameterSets)
    if len(parameterSetsResult) != 0:
        result['ParameterSets'] = parameterSetsResult

    newAliasList = {item: item for item in newCmdletMetadata.get('AliasList', [])}
    oldAliasList = {item: item for item in oldCmdletMetadata.get('AliasList', [])}
    aliasListResult = compareMetadata(newAliasList, oldAliasList)
    if len(aliasListResult) != 0:
        result['AliasList'] = aliasListResult

    return result

diffTypeDictionary = compareDict(newJsonObj['TypeDictionary'], oldJsonObj['TypeDictionary'], compareTypeMetadata)

newCmdletsMetadata = {item['Name']: item for item in newJsonObj['Cmdlets']}
oldCmdletsMetadata = {item['Name']: item for item in oldJsonObj['Cmdlets']}
diffCmdlet = compareDict(newCmdletsMetadata, oldCmdletsMetadata, compareCmdletMetadata)
diff = {
    'Cmdlets': diffCmdlet,
    'TypeDictionary': diffTypeDictionary
}

dllName = newJsonPath.replace('\\', '/').split('/')[-1]
diffPath = 'C:\\Users\\yunwang\\source\\repos\\azure-powershell\\artifacts\\diff\\' + dllName

with open(diffPath, 'w') as f:
    json.dump(diff, f, indent=2)
