using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AwsSSLClient.AuditTrailService;
using Microsoft.Adcenter.AuditTrail.Entities;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using Microsoft.Bond;
using System.IO;
using System.Globalization;
using System.Configuration;


namespace AwsSSLClient
{
    class Program
    {
        /// <summary>
        /// Use BasicHttpBinding, send to AuditTrailService2 endpoint. (Same with java client) 
        /// </summary>
        static void callSSLServiceWithBasicHttp()
        {

            // Create the binding.
            var myBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            AuditTrailBatch at = new AuditTrailBatch();
            String actionTimeStamp = DateTime.UtcNow.AddSeconds(20).ToString("yyyy-MM-dd HH:mm:ss.fff");
            string FileCreationTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:00.000");
            string FileNamePart = DateTime.UtcNow.ToString("yyyyMMdd_HHmmHHmm");
            at.ActionName = "PRODUCED";
            at.ActionTimeStamp = actionTimeStamp;
            at.AgentName = "callSSLServiceWithBasicHttp";
            at.EnvironmentName = "env";
            at.MachineName = "m1";
            at.LogType = "SIPHONAZURETEST";
            at.FileName = "SIPHONAZURETEST_" + FileNamePart + "_m1.log";
            at.FileCreateTimeStamp = FileCreationTimeStamp;
            at.BatchID = at.FileName;
            at.NumBytes = 2000;
            at.NumRecords = 100;

            //to use BasicHttpBinding, must call AuditTrailService2...
            var client = new AuditTrailServiceClient(myBinding, new EndpointAddress("https://proxy.cosmos.office.net/AuditTrailService.svc/AuditTrailService2"));

            // The client must specify a certificate trusted by the server.
            client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;
            client.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindByThumbprint,
                ConfigurationManager.AppSettings["Thumbprint"].Trim());
            using (var memoryStream = new MemoryStream())
            {
                var writer = new CompactBinaryProtocolWriter(memoryStream);
                Marshaler.Marshal(at, writer);
                byte[] payload = memoryStream.GetBuffer();
                byte[][] payloads = new byte[1][];
                payloads[0] = payload;
                //Call AuditTrail service
                try
                {
                    var resp = client.InsertDataBulk("Microsoft.Adcenter.AuditTrail.Entities.AuditTrailBatch", payloads);
                    Console.Write("AWS server response: ");
                    if(resp.Count() > 0)
                        Console.WriteLine(resp[0].Code);
                }catch(Exception e){
                    Console.WriteLine("EXCEPPTION!: \r\n" + e);
                }
            }
        }

        /// <summary>
        /// Use wsHttpBinding, send to AuditTrailService endpoint. For C# client. 
        /// </summary>
        static void callSSLServiceWithWSHttp()
        {

            // Create the binding.
            var myBinding = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
            myBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            myBinding.Security.Message.EstablishSecurityContext = false;
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

            AuditTrailBatch at = new AuditTrailBatch();
            String actionTimeStamp = DateTime.UtcNow.AddSeconds(20).ToString("yyyy-MM-dd HH:mm:ss.fff");
            string FileCreationTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:00.000");
            string FileNamePart = DateTime.UtcNow.ToString("yyyyMMdd_HHmmHHmm");
            at.ActionName = "PRODUCED";
            at.ActionTimeStamp = actionTimeStamp;
            at.AgentName = "callSSLServiceWithWSHttp";
            at.EnvironmentName = "env";
            at.MachineName = "m1";
            at.LogType = "SIPHONAZURETEST";
            at.FileName = "SIPHONAZURETEST_" + FileNamePart + "_m1.log";
            at.FileCreateTimeStamp = FileCreationTimeStamp;
            at.BatchID = at.FileName;
            at.NumBytes = 2000;
            at.NumRecords = 100;

            //to use BasicHttpBinding, must call AuditTrailService2...
            var client = new AuditTrailServiceClient(myBinding, new EndpointAddress("https://proxy.cosmos.office.net/AuditTrailService.svc/AuditTrailService"));

            //client.ClientCredentials.ClientCertificate.Certificate = certificate;

            // The client must specify a certificate trusted by the server.
            client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;
            client.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindByThumbprint,
                ConfigurationManager.AppSettings["Thumbprint"].Trim());
            using (var memoryStream = new MemoryStream())
            {
                var writer = new CompactBinaryProtocolWriter(memoryStream);
                Marshaler.Marshal(at, writer);
                byte[] payload = memoryStream.GetBuffer();
                byte[][] payloads = new byte[1][];
                payloads[0] = payload;
                //Call AuditTrail service
                try
                {
                    var resp = client.InsertDataBulk("Microsoft.Adcenter.AuditTrail.Entities.AuditTrailBatch", payloads);
                    Console.Write("AWS server response: ");
                    if (resp.Count() > 0)
                        Console.WriteLine(resp[0].Code);
                }
                catch (Exception e)
                {
                    Console.WriteLine("EXCEPPTION!: \r\n" + e);
                }
            }
        }

        /// <summary>
        /// Use BasicHttpBinding HTTP(No SSL).
        /// </summary>
        static void callHttpService()
        {
            AuditTrailBatch at = new AuditTrailBatch();
            String actionTimeStamp = DateTime.UtcNow.AddSeconds(20).ToString("yyyy-MM-dd HH:mm:ss.fff");
            string FileCreationTimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:00.000");
            string FileNamePart = DateTime.UtcNow.ToString("yyyyMMdd_HHmmHHmm");
            at.ActionName = "PRODUCED";
            at.ActionTimeStamp = actionTimeStamp;
            at.AgentName = "callHttpService";
            at.EnvironmentName = "env";
            at.MachineName = "m1";
            at.LogType = "SIPHONAZURETEST";
            at.FileName = "SIPHONAZURETEST_" + FileNamePart + "_m1.log";
            at.FileCreateTimeStamp = FileCreationTimeStamp;
            at.BatchID = at.FileName;
            at.NumBytes = 2000;
            at.NumRecords = 100;
            at.FilePath = "";

            var client = new AuditTrailServiceClient();
            using (var memoryStream = new MemoryStream())
            {
                var writer = new CompactBinaryProtocolWriter(memoryStream);
                Marshaler.Marshal(at, writer);
                byte[] payload = memoryStream.GetBuffer();
                byte[][] payloads = new byte[1][];
                payloads[0] = payload;
                //Call AuditTrail service
                var resp = client.InsertDataBulk("Microsoft.Adcenter.AuditTrail.Entities.AuditTrailBatch", payloads);
                Console.WriteLine("DONE: " + resp);
            }
        }

        static void Main(string[] args)
        {
            callSSLServiceWithBasicHttp();
            callSSLServiceWithWSHttp();
            Console.WriteLine("\r\n\r\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
