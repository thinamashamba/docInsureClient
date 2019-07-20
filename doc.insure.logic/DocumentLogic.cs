using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace doc.insure.logic
{
    public class DocumentLogic
    {



        private CloudBlobContainer GetCloudBlobContainer()
        {
            // CloudConfigurationManager.GetSetting("<storageaccountname>_AzureStorageConnectionString"));

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("dagotechfantasystorage_AzureStorageConnectionString"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            //CloudBlobContainer container = blobClient.GetContainerReference("fantasy/quiz");
            CloudBlobContainer container = blobClient.GetContainerReference("docs/qa");
            return container;
        }

        public string AddNewFile(HttpPostedFileBase file)
        {


            var extension = System.IO.Path.GetExtension(file.FileName);


            var fileName = Guid.NewGuid().ToString() + extension; // png


            CloudBlobContainer container = GetCloudBlobContainer();

            CloudBlockBlob blob = container.GetBlockBlobReference(fileName);

            //blob.Properties.ContentType = "image/png";

            // https://dagotechfantasystorage.blob.core.windows.net/fantasy/quiz/imag4444es.jpg

            blob.UploadFromStream(file.InputStream);




            var uri = container.Uri + "/" + fileName;

            return uri;


        }
    }
}
