# Roblox Cartride API

## Overview

Middleware API for a Roblox Cartride game. It enables a chat function that generates and executes scripts via a Large Language Model (LLM) on Hugging Face.

## Structure

- **Controllers**: API endpoints.
  - `EventController.cs`
- **Requests**: Models and senders.
  - `PromptRecord.cs`
  - `Promptsender.cs`
- **Config**: `appsettings.json`, `launchSettings.json`
- **Project Files**: `roblox-cartride-api.csproj`, `roblox-cartride-api.sln`

## Setup

1. Clone the repo:
    ```sh
    git clone https://github.com/yourusername/roblox-cartride-api.git
    cd roblox-cartride-api
    ```
2. Restore and build:
    ```sh
    dotnet restore
    dotnet build
    ```
3. Run:
    ```sh
    dotnet run
    ```

## License

MIT License. See `LICENSE` file.