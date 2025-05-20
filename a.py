import os
import json
from datetime import datetime, timezone, timedelta

from openai import AzureOpenAI
from azure.identity import DefaultAzureCredential, get_bearer_token_provider
from process_help_file import process_content

credential = DefaultAzureCredential()

import glob
import yaml
import requests
import re

files = glob.glob("src/**/help/*-*.md", recursive=True)

azure_endpoint = 'https://azclitools-copilot-test.openai.azure.com/'
api_version = '2024-12-01-preview'

token_provider = get_bearer_token_provider(
    credential, "https://cognitiveservices.azure.com/.default"
)

openai_chat_client = AzureOpenAI(
    azure_ad_token_provider=token_provider,
    azure_endpoint=azure_endpoint,
    api_version=api_version,
    azure_deployment="o3-mini",
)

bad_description_files = []

def process_file(file_path):
    print(f"Processing file: {file_path}")
    try:
        with open(file_path, 'r', encoding='utf8') as f:
            md = f.read()
        chapter_titles = ['SYNOPSIS', 'SYNTAX', 'PARAMETERS', 'DESCRIPTION', 'EXAMPLES', 'INPUTS', 'OUTPUTS', 'NOTES', 'RELATED LINKS']
        for chapter_title in chapter_titles:
            md = md.replace(f"\n## {chapter_title}\n", f"\n@## {chapter_title}\n")
        result = process_content(md, '\n@## ')
        if type(result) == str:
            return
        for key in result.keys():
            result[key] = process_content('\n' + result[key], '\n### ')
        
        description = result.get('DESCRIPTION', '')
        if description and len(description.split(' ')) < 10:
            print(f"Description too long in file: {file_path}: {description}")
            bad_description_files.append(file_path)
        synopsis = result.get('SYNOPSIS', '')
        if synopsis and len(synopsis.split(' ')) < 10:
            print(f"synopsis too long in file: {file_path}: {synopsis}")
            bad_description_files.append(file_path)
            
    except Exception as e:
        print(f"Error processing file {file_path}: {e}")
        return None
    
for file_path in files:
    process_file(file_path)
    
with open('bad_description_files.txt', 'w', encoding='utf8') as f:
    for file_path in bad_description_files:
        f.write(file_path + '\n')