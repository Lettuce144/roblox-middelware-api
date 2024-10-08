using System.Text;
using System.Text.RegularExpressions;
using MarkdownRemove;
using Newtonsoft.Json.Linq;

namespace CartRideApi
{
    public class PromptSender
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<dynamic> SendPromptAsync(string prompt)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api-inference.huggingface.co/models/mistralai/Mistral-Nemo-Instruct-2407/v1/chat/completions");
            request.Headers.TryAddWithoutValidation("Authorization", "Bearer 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");
            request.Content = new StringContent($@"
        {{
            ""model"": ""meta-llama/Meta-Llama-3-8B"",
            ""messages"": [
                {{ ""role"": ""user"", ""content"": ""{ "Generate a roblox script " + prompt + " Also respond with only the script no explanation and NO LOCALSCRIPT ALSO DO NOT INCLUDE script="}"" }}
            ],
            ""temperature"": 0.5,
            ""max_tokens"": 1024,
            ""top_p"": 0.7
        }}", Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            // Parse the JSON response
            JObject jsonResponse = JObject.Parse(responseContent);

            // Access specific values from the JSON response
            string? content = jsonResponse["choices"]?[0]?["message"]?["content"]?.ToString();

            // Example: Print the accessed values
            // Console.WriteLine($"Model: {model}");
            // Console.WriteLine($"Content: {content}");
            // Console.WriteLine($"Title: {title}");

            MarkdownRemover remover = new MarkdownRemover();
            content = remover.RemoveMarkdown(content);
            
            var promptObject = new PromptObject(content);

            return promptObject;
        }
    }
}