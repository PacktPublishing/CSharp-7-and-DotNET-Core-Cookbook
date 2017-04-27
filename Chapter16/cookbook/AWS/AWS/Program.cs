using Amazon.Runtime;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AWS
{
    class Program
    {

        //https://console.aws.amazon.com
        //https://forums.aws.amazon.com/forum.jspa?forumID=61&start=0
        //https://stackoverflow.com/questions/42290151/amazon-s3-unable-to-find-credentials-in-c-sharp#
        //https://docs.aws.amazon.com/sdk-for-net/v2/developer-guide/net-dg-config-creds.html

        //Using the .NET SDK you can instantiate AmazonLambdaClient and then call Invoke to invoke a particular Lambda.
        //If you are using API Gateway with Lambda as outlined in this guide 
        //http://docs.aws.amazon.com/apigateway/latest/developerguide/getting-started.html 
        //then you can simply issue an HTTP request to the Invoke URL, using HttpRequest or HttpClient.


        //C# Publish text message without creating topics
        //https://forums.aws.amazon.com/thread.jspa?threadID=250183&tstart=0
        static void Main(string[] args)
        {
            string uploadFile = @"C:\Users\dirk\Pictures\Saved Pictures\AnotherPic.png"; 
            string S3Bucket = "familyvaultdocs"; 
            string S3Folder = "MinecraftPictures";
            string uploadedFilename = $"{DateTime.Now.ToString("yyyymmdd")} - AnotherPic.png";
            StampysLovelyWorld.SaveStampy(uploadFile, S3Bucket, S3Folder, uploadedFilename);
            WriteLine("uploaded");
            ReadLine();
        }
    }

    internal static class StampysLovelyWorld
    {        
        public static void SaveStampy(string fileToSave, string bucket, string bucketDirectory, string bucketFilename)
        {
            IAmazonS3 client = AWSClientFactory.CreateAmazonS3Client(RegionEndpoint.EUCentral1);

            TransferUtility utility = new TransferUtility(client);            
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            request.BucketName = bucket + @"/" + bucketDirectory;
            request.Key = bucketFilename; 
            request.FilePath = fileToSave; 
            utility.Upload(request);             
        }
    }
}
