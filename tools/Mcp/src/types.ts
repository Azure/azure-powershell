export interface toolParameterSchema {
    name: string;
    description: string;
    type: string;
}

export interface toolSchema {
    name: string;
    description: string;
    parameters: toolParameterSchema[];
    callbackName: string;
}

export interface responseSchema {
    name: string;
    type: string;
    text: string;
}

export interface yamlContent {
    [key: string]: any;
}

export interface directiveDefinition {
    [key: string]: any
}