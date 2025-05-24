using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class IAservice
{
    private readonly HttpClient cliente;

    public IAservice()
    {
        cliente = new HttpClient();
        cliente.DefaultRequestHeaders.Add("Authorization", "api key");
    }

    public async Task<string> ConsultarIA(string prompt)
    {
        var body = new
{
    model = "mistralai/mistral-7b-instruct", 
    messages = new[] {
        new { role = "user", content = prompt }
    }
};


        var json = JsonConvert.SerializeObject(body);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await cliente.PostAsync("https://openrouter.ai/api/v1/chat/completions", content);
        string result = await response.Content.ReadAsStringAsync();
       

        // Evitar error de null
        dynamic jsonResult = JsonConvert.DeserializeObject(result);
        if (jsonResult == null || jsonResult.choices == null || jsonResult.choices.Count == 0)
        {
            return "La respuesta fue vacía o incorrecta.";
        }

        return jsonResult.choices[0].message.content.ToString();
    }
}
