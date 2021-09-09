using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace StorageAccount
{
    class Program
    {
        private static string _conncetionstring = "DefaultEndpointsProtocol=https;AccountName=az204storageaccount001;AccountKey=076Ylj6Wzf+kEvxHtTj15AafudVC4peVsM5DJZIyTluYE3/dbPVdWv3B7k4xizN9vXpokWh6XqkceyVLf8z01g==;EndpointSuffix=core.windows.net";
        private static string _containername = "data";
        static string _blobname = "Az204.txt";
        static string location = @"C:\Users\BISWBEHE\Documents\temp";
        static string mountlocation = @"\app\Az204.txt";
        static void Main(string[] args)
        {
          
            BlobServiceClient blobServiceClient = new BlobServiceClient(_conncetionstring);
            // blobServiceClient.CreateBlobContainer(_blob_name);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(_containername);
            BlobClient blobClient = blobContainerClient.GetBlobClient(_blobname);
            DownloadFile(blobClient);
            //blobClient.Upload(location);
            //BlobProperties blobProperties = blobClient.GetProperties();
            //Console.WriteLine(blobProperties.BlobType);
            //IDictionary<string, string> detail = blobProperties.Metadata;
            //foreach(var item in detail)
            //{
            //    Console.WriteLine("{0},{1}", item.Key,item.Value);
            //}
            //detail.Add("Tier2", "3");
            //blobClient.SetMetadata(detail);
            //Console.WriteLine(blobProperties);

            //foreach (BlobItem blobitem in blobContainerClient.GetBlobs())
            //{

            //    Console.WriteLine(blobitem.Name);
            //    var blobclient = blobContainerClient.GetBlobClient(blobitem.Name);
            //    var loc = Path.Combine(location, blobitem.Name);
            //    blobclient.DownloadTo(loc);
            //}
            //using (MemoryStream ms = new MemoryStream())
            //{

            //    blobClient.DownloadTo(ms);
            //    ms.Position = 0;
            //    StreamReader sr = new StreamReader(ms);
            //    Console.WriteLine(sr.ReadToEnd());
            //    StreamWriter sw = new StreamWriter(ms);
            //    sw.Write("this s a new entry");

            //}



            Console.WriteLine("Blob Upladed succesfully");
            //Console.ReadKey();
        }
        private static void DownloadFile(BlobClient client)
        {
            client.DownloadTo(mountlocation);
        }
    }
}
