export type toolParameterSchema = {
    name: string;
    description: string;
    type: string;
}

export type toolSchema = {
    name: string;
    description: string;
    parameters: toolParameterSchema[];
    callbackName: string;
}

export type yamlContent = {
    [key: string]: any;
}

export type directiveDefinition = {
    [key: string]: any
}