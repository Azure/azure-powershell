export interface toolParameterSchema {
    name: string;
    description: string;
    type: string; // string | number | boolean | array (of string)
    optional?: boolean; // if true, parameter is optional
}

export interface toolSchema {
    name: string;
    description: string;
    parameters: toolParameterSchema[];
    callbackName: string;
}

export interface promptSchema {
    name: string;
    description: string;
    parameters: toolParameterSchema[]; // reuse parameter schema
    callbackName: string; // maps to PromptService internal function
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