# Copyright (c) Microsoft. All rights reserved.
# Licensed under the MIT license.

import os
import glob
import mlflow
import pandas as pd
import logging
from pathlib import Path


def init():
    global model
    global model_input_types
    global model_output_names
    global output_path

    # AZUREML_MODEL_DIR is an environment variable created during deployment
    # It is the path to the model folder
    # Please provide your model's folder name if there's one:
    model_path = glob.glob(os.environ["AZUREML_MODEL_DIR"] + "/*/")[0]
    output_path = os.environ["AZUREML_BI_OUTPUT_PATH"]

    # Load the model, it's input types and output names
    model = mlflow.pyfunc.load(model_path)
    if model.metadata and model.metadata.signature:
        if model.metadata.signature.inputs:
            model_input_types = dict(
                zip(
                    model.metadata.signature.inputs.input_names(),
                    model.metadata.signature.inputs.pandas_types(),
                )
            )
        if model.metadata.signature.outputs:
            if model.metadata.signature.outputs.has_input_names():
                model_output_names = model.metadata.signature.outputs.input_names()
            elif len(model.metadata.signature.outputs.input_names()) == 1:
                model_output_names = ["prediction"]
    else:
        logging.warning(
            "Model doesn't contain a signature. Input data types won't be enforced."
        )


def run(mini_batch):
    for file_path in mini_batch:
        data = pd.read_csv(file_path)

        if model_input_types:
            data = data.astype(model_input_types)

        pred = model.predict(data)

        if pred is not pd.DataFrame:
            if not model_output_names:
                model_output_names = ["pred_col" + str(i) for i in range(pred.shape[1])]
            pred = pd.DataFrame(pred, columns=model_output_names)

        output_file_name = Path(file_path).stem
        output_file_path = os.path.join(output_path, output_file_name + ".parquet")
        data = pd.concat([data, pred], axis=1)
        data.to_parquet(output_file_path)

        yield True
