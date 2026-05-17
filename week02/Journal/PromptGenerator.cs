public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    //help with random : https://learn.microsoft.com/es-es/dotnet/api/system.random?view=netframework-4.8.1&viewFallbackFrom=net-10.0

}