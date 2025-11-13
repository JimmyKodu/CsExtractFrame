using FFMediaToolkit;
using FFMediaToolkit.Decoding;
using FFMediaToolkit.Graphics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace CsExtractFrame;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: CsExtractFrame <video-file-path> <output-image-path> [timestamp-in-seconds]");
            Console.WriteLine("Example: CsExtractFrame input.mp4 frame.png 5");
            return;
        }

        string videoPath = args[0];
        string outputPath = args[1];
        double timestamp = args.Length >= 3 && double.TryParse(args[2], out var ts) ? ts : 0;

        try
        {
            ExtractFrame(videoPath, outputPath, timestamp);
            Console.WriteLine($"Frame extracted successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error extracting frame: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static void ExtractFrame(string videoPath, string outputPath, double timestampSeconds)
    {
        // Open the video file using FFMediaToolkit (NuGet package)
        // This uses the FFmpeg libraries but does not require external executables
        var settings = new MediaOptions
        {
            StreamsToLoad = MediaMode.Video
        };
        
        using var mediaFile = MediaFile.Open(videoPath, settings);
        
        // Get the frame at the specified timestamp
        var frameData = mediaFile.Video.GetFrame(TimeSpan.FromSeconds(timestampSeconds));
        
        // Convert ImageData to ImageSharp Image and save
        using var image = Image.LoadPixelData<Bgr24>(
            frameData.Data,
            frameData.ImageSize.Width,
            frameData.ImageSize.Height);
        
        image.Save(outputPath);
    }
}
