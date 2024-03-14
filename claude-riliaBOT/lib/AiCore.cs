using System.Text;
using Claudia;

namespace claude_riliaBOT.lib;

public class AiCore
{
    public async void LoadAi(string message)
    {
        try
        {
            Console.WriteLine("AI is Loading...");
            var clientApi = new Anthropic
            {
                ApiKey = Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY", EnvironmentVariableTarget.User)
            };

            var stream = await clientApi.Messages.CreateAsync(new()
            {
                Model = "claude-3-haiku-20240307",
                MaxTokens = 4096,
                Messages = [new() { Role = "user", Content = message }]
            });
            
                    Console.WriteLine(stream);
                
           
        }
        catch (ClaudiaException e)
        {
            Console.WriteLine((int)e.Status); // 400(ErrorCode.InvalidRequestError)
            Console.WriteLine(e.Name);        // invalid_request_error
            Console.WriteLine(e.Message);     // Field required. Input:...
            throw;
        }
    }
}