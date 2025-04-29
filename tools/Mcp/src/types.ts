export type parameter = {
    name: string;
    type: string;
    description: string;
}

export type toolSchema = {
    name: string;
    description: string;
    parameters: parameter[];
    callbackName: string;
}