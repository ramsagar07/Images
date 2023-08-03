/*using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Images
{
    public  class Compare
    {
        static int width1,width2,height1,height2,count=0,count2=0;
        
       
        static void Main()
        {
            string image1Path = @"C:\Users\iray\Comparison\Child\ChildSub\Attune - 1.33.0\Android\en-US\Attune_Android_Pixel4XL_en-US_More_Legal_Information_Manufacturer_1.png";
            string image2Path = @"C:\Users\iray\Comparison\Child\ChildSub\Attune - 1.33.0\Android\en-US\Attune_Android_Pixel4XL_en-US_More_Menu_Support.png";

            // Load the two images
            using (Image<Rgba32> image1 = Image.Load<Rgba32>(image1Path))
            using (Image<Rgba32> image2 = Image.Load<Rgba32>(image2Path))
            {
                width1 = image1.Width;
                height1 = image1.Height;
                width2 = image2.Width;
                height2 = image2.Height;
                if(height1 != height2 && width1 != width2) 
                {
                    Console.WriteLine("Images are Different as they have different dimensions");
                    return;
                }

                 count = 0;
                for (int i = 0; i < width1; i++)
                {
                    for (int j = 0; j < height1; j++)
                    {
                        count2 += 1;
                        Rgba32 pixelColor1 = image1[i, j];
                        Rgba32 pixelColor2 = image2[i, j];
                        if (pixelColor1 != pixelColor2)
                        {
                            count += 1;
                        }
                    }
                }
            }
            if(count > 100000 )
            {
                Console.WriteLine("Images are different");
                Console.WriteLine(count);
                Console.WriteLine(count2);
                Console.WriteLine("{0},{1}",height1, height2);
                
            }
            else
            {
               Console.WriteLine("Images are same");
               
            }
        }
    }
}*/
