using System.Net.Http.Headers;

internal class HttpClientUpload
{
    private readonly HttpClient httpClient;

    public HttpClientUpload(IHttpClientFactory factory) => httpClient = factory.CreateClient();

    public async Task UploadFileAsync()
    {
        var file = @"C:\Users\ryanpeters\Downloads\STScI-01G7ETPF7DVBJAC42JR5N6EQRH.png";

        using (var fileStream = File.OpenRead(file))
        {
            var streamContent = new StreamContent(fileStream);

            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");

            //var memoryStream = new MemoryStream();
            //fileStream.CopyTo(memoryStream);
            //var streamContent = new ByteArrayContent(memoryStream.ToArray());

            fileStream.Position = 0;

            var multipartRequest = new MultipartFormDataContent();

            multipartRequest.Add(new StringContent("hello world!"), "Text");
            multipartRequest.Add(streamContent, "File", "myfile");

            var result = await httpClient.PostAsync("http://localhost:5216/upload/file", multipartRequest);

            var response = await result.Content.ReadAsStringAsync();
        }
    }
}