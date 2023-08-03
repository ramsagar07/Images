/*using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

class Program
{
    static void Main()
    {
        string image1Path = @"C:\Users\iray\Downloads\png-ga5d0e4bdd_1280.png";
        string image2Path = @"C:\Users\iray\Downloads\water-g111fd29a6_1280.png";

        // Load the two images
        using (Image<Rgba32> image1 = Image.Load<Rgba32>(image1Path))
        using (Image<Rgba32> image2 = Image.Load<Rgba32>(image2Path))
        {
            // Compare the images
            bool areIdentical = AreImagesIdentical(image1, image2);

            // Check the result
            if (areIdentical)
            {
                Console.WriteLine("The images are identical.");
            }
            else
            {
                Console.WriteLine("The images are different.");
            }
        }
    }

    static bool AreImagesIdentical(Image<Rgba32> image1, Image<Rgba32> image2)
    {
        if (image1.Width != image2.Width || image1.Height != image2.Height)
        {
            return false; // Images have different dimensions, they are not identical.
        }

        for (int x = 0; x < image1.Width; x++)
        {
            for (int y = 0; y < image1.Height; y++)
            {
                Rgba32 pixel1 = image1[x, y];
                Rgba32 pixel2 = image2[x, y];

                if (pixel1 != pixel2)
                {
                    return false; // Found a difference, the images are not identical.
                }
            }
        }

        return true; // If no differences were found, the images are identical.
    }
}*/
