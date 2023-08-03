namespace Images
{
    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Reporter.Configuration;
    using AventStack.ExtentReports.Reporter;
    using System;
    using System.IO;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;

    public class Class1 : ExtentReporting
    {
        public void CompareImages(string image1path, string image2path)//Function to compare images
        {
            int width1, width2, height1, height2, count;
            Console.WriteLine(image1path);
            Console.WriteLine(image2path);
            string stepname = image2path.Replace(@"C:\Users\iray\Demo2\BaseM\BaseSub", "").TrimStart(Path.DirectorySeparatorChar);
            using (Image<Rgba32> image1 = Image.Load<Rgba32>(@image1path))//Reading image as a RGBA image
            using (Image<Rgba32> image2 = Image.Load<Rgba32>(@image2path))
            {
                width1 = image1.Width;//Getting Heights and Widths of loaded image
                height1 = image1.Height;
                width2 = image2.Width;
                height2 = image2.Height;
                step = _scenario.CreateNode(stepname);
                if (height1 != height2 && width1 != width2)//Comparing Dimensions of both images
                {
                   Console.WriteLine("Images are Different as they have different dimensions");
                   step.Log(Status.Fail, "Images Have Different Dimensions");
                   return;
                }
                count = 0;
                for (int i = 0; i < width1; i++)//comparing pixel of both images
                {
                    for (int j = 0; j < height1; j++)
                    {
                        Rgba32 pixelColor1 = image1[i, j];
                        Rgba32 pixelColor2 = image2[i, j];
                        if (pixelColor1 != pixelColor2)
                        {
                            count += 1;
                        }
                    }
                }
                if (count > 100)
                {
                    Console.WriteLine("Images are different");
                    step.Log(Status.Fail, "Images are Different");
                }
                else
                {
                    Console.WriteLine("Images are same");
                    step.Log(Status.Pass, "Images are Same");
                } 
            } 
        }
        static void Main()
        {
            Class1 class1 = new ();
            ExtentReportInit();
            _feature = _extentReports.CreateTest("Comparison");
            _scenario = _feature.CreateNode("Results of Comparison");     
            string root = @"C:\Users\iray\Demo1\BaseM\BaseSub";
            string base_ = @"C:\Users\iray\Demo2\BaseM\BaseSub";
            string[] root_direc = Directory.GetDirectories(root, "*", SearchOption.AllDirectories);//Getting Diretories 
            string[] base_direc = Directory.GetDirectories(base_, "*", SearchOption.AllDirectories);
            for (int i = 0; i < root_direc.Length; i++)//Getting Files in Directories
            {
                string[] root_files = Directory.GetFiles(root_direc[i]);
                string[] base_files = Directory.GetFiles(base_direc[i]);
                int length = root_files.Length;
                if (root_files.Length != base_files.Length)
                {
                    if (root_files.Length > base_files.Length)
                    {
                        Console.WriteLine("Only" + base_files.Length + "can be compared");
                        length = base_files.Length;
                    }
                    else
                    {
                        Console.WriteLine("Only " + root_files.Length + " can be compared");
                        length = root_files.Length;
                    }
                }
                for (int j = 0; j < length; j++)
                {
                    string path1 = root_files[j];
                    string path2 = base_files[j];
                    class1.CompareImages(path1, path2);
                }
            }
            
            ExtentReportTeardown();
        }
    }
    public class ExtentReporting//Generating Extent Report
    {
        public static ExtentReports _extentReports ;
        public static ExtentTest _feature ;
        public static ExtentTest _scenario;
        public static ExtentTest step;
        public static string dir = AppDomain.CurrentDomain.BaseDirectory;

        public static string testResultPath = "C:\\Users\\iray\\source\\repos\\Images\\Images\\TestReports\\Failure\\ind.html";
        public static void ExtentReportInit() //creates extent report
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Image Comparison Report";
            htmlReporter.Config.DocumentTitle = "Comparison Results";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Start();
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Smart3d");
            _extentReports.AddSystemInfo("OS", "Android And IOS");
        }
        public static void ExtentReportTeardown()
        {
            _extentReports.Flush();

        }
    }
}
