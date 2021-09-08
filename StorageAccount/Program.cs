using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

namespace StorageAccount
{
    class Program
    {
        private static string _conncetionstring = "DefaultEndpointsProtocol=https;AccountName=az204storageaccount001;AccountKey=076Ylj6Wzf+kEvxHtTj15AafudVC4peVsM5DJZIyTluYE3/dbPVdWv3B7k4xizN9vXpokWh6XqkceyVLf8z01g==;EndpointSuffix=core.windows.net";
        private static string _containername = "data";
        static string _blobname = "sample.txt";
        static string location = @"C:\Users\BISWBEHE\Documents\temp";
        static void Main(string[] args)
        {
          
            BlobServiceClient blobServiceClient = new BlobServiceClient(_conncetionstring);
            // blobServiceClient.CreateBlobContainer(_blob_name);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(_containername);
           // BlobClient blobClient = blobContainerClient.GetBlobClient(_blobname);
            //blobClient.Upload(location);
            foreach (BlobItem blobitem in blobContainerClient.GetBlobs())
            {

                Console.WriteLine(blobitem.Name);
                var blobclient = blobContainerClient.GetBlobClient(blobitem.Name);
                var loc = Path.Combine(location, blobitem.Name);
                blobclient.DownloadTo(loc);
            }
                


            Console.WriteLine("Blob Upladed succesfully");
            Console.ReadKey();
        }
    }
}
