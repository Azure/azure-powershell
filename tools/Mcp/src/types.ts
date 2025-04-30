export type toolParameterSchema = {
    name: string;
    type: string;
    description: string;
}

export type toolSchema = {
    name: string;
    description: string;
    parameters: toolParameterSchema[];
    callbackName: string;
}