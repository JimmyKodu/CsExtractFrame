# CsExtractFrame

A C# console application for extracting frames from video files using the FFMediaToolkit NuGet package.

## Features

- Extract frames from video files at specific timestamps
- Uses NuGet packages (FFMediaToolkit) instead of relying on external executable files
- Simple command-line interface
- Supports various video formats

## Requirements

- .NET 9.0 or later

## Building the Project

```bash
dotnet build CsExtractFrame/CsExtractFrame.csproj
```

## Usage

```bash
dotnet run --project CsExtractFrame/CsExtractFrame.csproj -- <video-file-path> <output-image-path> [timestamp-in-seconds]
```

### Examples

Extract the first frame (at 0 seconds):
```bash
dotnet run --project CsExtractFrame/CsExtractFrame.csproj -- input.mp4 frame.png
```

Extract a frame at 5 seconds:
```bash
dotnet run --project CsExtractFrame/CsExtractFrame.csproj -- input.mp4 frame.png 5
```

## Dependencies

This project uses:
- **FFMediaToolkit** (v4.8.1) - A NuGet package that provides video processing capabilities
- The package internally uses FFmpeg libraries but does not require separate executable files to be installed

## Implementation Details

The application demonstrates how to:
1. Reference NuGet packages for video processing functionality
2. Avoid dependency on standalone executable files
3. Extract video frames programmatically using .NET APIs

This approach ensures:
- Easier dependency management through NuGet
- Better cross-platform compatibility
- No need to bundle or manage external executable files