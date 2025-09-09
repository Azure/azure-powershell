# Dockerfile for Azure PowerShell devcontainer
# Use official .NET 8.0 image for amd64 architecture
FROM --platform=linux/amd64 mcr.microsoft.com/devcontainers/dotnet:1-8.0

# Install additional dependencies if needed
# Example: RUN apt-get update && apt-get install -y <package>

# Set working directory
WORKDIR /workspace

# Optionally install global npm packages
RUN npm install -g autorest

# Set default user to root for pwsh compatibility
USER root
