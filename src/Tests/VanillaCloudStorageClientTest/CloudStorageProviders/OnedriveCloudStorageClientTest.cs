﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using NUnit.Framework;
using VanillaCloudStorageClient;
using VanillaCloudStorageClient.CloudStorageProviders;

namespace VanillaCloudStorageClientTest.CloudStorageProviders
{
    [TestFixture]
    public class OnedriveCloudStorageClientTest
    {
        /// <summary>
        /// Setting <see cref="DoRealWebRequests"/> to true, causes the unit tests to act as
        /// integration tests, doing real web requests to the API. The constants
        /// • <see cref="ClientId"/>
        /// • <see cref="RedirectUrl"/>
        /// • <see cref="OnedriveAccessToken"/>
        /// must then be set to valid credentials.
        /// </summary>
        private const bool DoRealWebRequests = false;
        private const string ClientId = "cid";
        private const string RedirectUrl = "com.example.myapp://oauth2redirect/";
        private const string OnedriveAccessToken = "GetItWithTheReallyDoMethods";
        private const string State = "7ysv8L9s4LB9CZpA";
        private HttpTest _httpTest;

        [SetUp]
        public void CreateHttpTest()
        {
            if (!DoRealWebRequests)
                _httpTest = new HttpTest(); // Put flurl into test mode
        }

        [TearDown]
        public void DisposeHttpTest()
        {
            if (!DoRealWebRequests)
                _httpTest.Dispose();
        }

        [Test]
        [Ignore("Opens the authorization page in the system browse, to get a real authorization-code")]
        public void ReallyDoOpenAuthorizationPageInBrowser()
        {
            IOAuth2CloudStorageClient client = new OnedriveCloudStorageClient(ClientId, RedirectUrl);
            string requestUrl = client.BuildAuthorizationRequestUrl(State);

            Process browserProcess = new Process();
            browserProcess.StartInfo.UseShellExecute = true;
            browserProcess.StartInfo.FileName = requestUrl;
            browserProcess.Start();
        }

        [Test]
        [Ignore("Gets a real access-token")]
        public void ReallyDoFetchToken()
        {
            if (!DoRealWebRequests)
                return;

            const string redirectedUrl = "ch.martinstoeckli.silentnotes://oauth2redirect/?code=Mee5dffeb-fdaa-aca7-d7ba-f281c8b49903&state=7ysv8L9s4LB9CZpA";

            // Fetch token
            IOAuth2CloudStorageClient client = new OnedriveCloudStorageClient(ClientId, RedirectUrl);
            CloudStorageToken token = Task.Run(async () => await FetchTokenAsync(client, redirectedUrl)).Result;

            Assert.IsNotNull(token.AccessToken);
            Assert.IsNotNull(token.RefreshToken);
        }

        private async Task<CloudStorageToken> FetchTokenAsync(IOAuth2CloudStorageClient client, string redirectedUrl)
        {
            return await client.FetchTokenAsync(redirectedUrl, State);
        }

        [Test]
        [Ignore("Refreshes a real token")]
        public void ReallyDoRefreshToken()
        {
            if (!DoRealWebRequests)
                return;

            CloudStorageToken oldToken = new CloudStorageToken
            {
                RefreshToken = "MCW*!s3pagVCHVuUCmPqx88abRl9N!dzQOLCovpwhFof2ZUvt9I4rkiJ06GzPH0z14d2NtvN2zXksQgI4wuENAaB3znFQ*1ELcB5ApCA1LTs3Sv3JQPIV3NLj1bNgAFFN*lN*btcBcbsksofEnxNx3qULZ5BDdIWmNhxdWWPXGrzq!AaqQwCYSYcf5Lh1gkLYjwcGeXUkHbGloqE3K1TZmb40t0KrJgsAjKnkAp4*S94*Gl7YFR4rzo1MTUdubNhtJRB7PRo1wNkMIRoV1d8653owOeO6oRJzt9GVWc!GJG3t3F40a3R8VtYSsXIevRaNLRaz5LSygDOiRjEO2wekhu9tb7Hh6KDBVFg1dA**YOGc7NVyAxvBDEM7!8NRM35nIQ$$",
            };

            // Refresh token
            IOAuth2CloudStorageClient client = new OnedriveCloudStorageClient(ClientId, RedirectUrl);
            CloudStorageToken newToken = Task.Run(async () => await RefreshTokenAsync(client, oldToken)).Result;

            Assert.IsNotNull(newToken.AccessToken);
            Assert.AreNotEqual(oldToken.AccessToken, newToken.AccessToken);
            Assert.AreEqual(oldToken.RefreshToken, newToken.RefreshToken);
        }

        private async Task<CloudStorageToken> RefreshTokenAsync(IOAuth2CloudStorageClient client, CloudStorageToken token)
        {
            return await client.RefreshTokenAsync(token);
        }

        [Test]
        public void FileLifecycleWorks()
        {
            string fileName = "unittest.dat";
            byte[] fileContent = new byte[16];
            new Random().NextBytes(fileContent);

            // 1) Test upload
            if (!DoRealWebRequests)
            {
                _httpTest.RespondWith(GetOneDriveUploadSession());
            }
            Assert.DoesNotThrowAsync(() => UploadFileWorksAsync(fileName, fileContent));

            // 2) Test listing
            if (!DoRealWebRequests)
            {
                _httpTest.RespondWith(GetOnedriveFileListResponse());
            }
            List<string> res = Task.Run(async () => await ListFileNamesWorksAsync()).Result;
            Assert.IsTrue(res.Count >= 1);
            Assert.IsTrue(res.Contains("unittest.dat"));

            // 3) Test exists
            bool exists = Task.Run(async () => await FileExistsWorksAsync(fileName)).Result;
            Assert.IsTrue(exists);

            // 4) Test download
            if (!DoRealWebRequests)
            {
                HttpContent httpContent = new ByteArrayContent(fileContent);
                _httpTest.RespondWith(httpContent);
            }
            Byte[] downloadedContent = Task.Run(async () => await DownloadFileWorksAsync(fileName)).Result;
            Assert.AreEqual(fileContent, downloadedContent);

            // 5) Test delete
            Assert.DoesNotThrowAsync(() => DeleteFileWorksAsync(fileName));

            // 6) Was really deleted?
            if (!DoRealWebRequests)
            {
                HttpContent content = null;
                _httpTest.RespondWith(content, 404);
            }
            exists = Task.Run(async () => await FileExistsWorksAsync(fileName)).Result;
            Assert.IsFalse(exists);
        }

        private async Task UploadFileWorksAsync(string fileName, byte[] fileContent)
        {
            ICloudStorageClient client = new OnedriveCloudStorageClient(ClientId, RedirectUrl);
            var credentials = new CloudStorageCredentials { Token = new CloudStorageToken { AccessToken = OnedriveAccessToken } };
            await client.UploadFileAsync(fileName, fileContent, credentials);
        }

        private async Task<byte[]> DownloadFileWorksAsync(string fileName)
        {
            ICloudStorageClient client = new OnedriveCloudStorageClient(ClientId, RedirectUrl);
            var credentials = new CloudStorageCredentials { Token = new CloudStorageToken { AccessToken = OnedriveAccessToken } };
            return await client.DownloadFileAsync(fileName, credentials);
        }

        private async Task DeleteFileWorksAsync(string fileName)
        {
            ICloudStorageClient client = new OnedriveCloudStorageClient(ClientId, RedirectUrl);
            var credentials = new CloudStorageCredentials { Token = new CloudStorageToken { AccessToken = OnedriveAccessToken } };
            await client.DeleteFileAsync(fileName, credentials);
        }

        private async Task<List<string>> ListFileNamesWorksAsync()
        {
            ICloudStorageClient client = new OnedriveCloudStorageClient(ClientId, string.Empty);
            var credentials = new CloudStorageCredentials { Token = new CloudStorageToken { AccessToken = OnedriveAccessToken } };
            List<string> result = await client.ListFileNamesAsync(credentials);
            return result;
        }

        private async Task<bool> FileExistsWorksAsync(string filename)
        {
            ICloudStorageClient client = new OnedriveCloudStorageClient(ClientId, string.Empty);
            var credentials = new CloudStorageCredentials { Token = new CloudStorageToken { AccessToken = OnedriveAccessToken } };
            return await client.ExistsFileAsync(filename, credentials);
        }

        private string GetOneDriveUploadSession()
        {
            return @"{""@odata.context"":""https://graph.microsoft.com/v1.0/$metadata#microsoft.graph.uploadSession"",""uploadUrl"":""https://api.onedrive.com/rup/FAKEID"",""expirationDateTime"":""2019-07-28T18:15:14.475Z"",""nextExpectedRanges"":[""0-""]}";
        }

        private string GetOnedriveFileListResponse()
        {
            return
@"{
""@odata.context"": ""https://graph.microsoft.com/v1.0/$metadata#users('FAKEUSER')/drive/special('approot')/children(name,file)"",
""@odata.count"": 3,
""value"": [{
        ""name"": ""subdir""
    }, {
        ""name"": ""a.txt"",
        ""file"": {
            ""mimeType"": ""text/plain"",
            ""hashes"": {
                ""quickXorHash"": ""FAKEHASH"",
                ""sha1Hash"": ""FAKEHASH""
            }
        }
    }, {
        ""name"": ""unittest.dat"",
        ""file"": {
            ""mimeType"": ""application/octet-stream"",
            ""hashes"": {
                ""quickXorHash"": ""/FAKEHASH="",
                ""sha1Hash"": ""FAKEHASH""
            }
        }
    }
]}";
        }
    }
}
