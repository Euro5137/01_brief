using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class GenerateRequest
{
    public string prompt;
    public string system;
}

[Serializable]
public class Usage
{
    public int input_tokens;
    public int output_tokens;
}

[Serializable]
public class GenerateResponse
{
    public string model;
    public string output_text;
    public string stop_reason;
    public Usage usage;
}

public class ClaudeBackendClient : MonoBehaviour
{
    [SerializeField] private string backendBaseUrl = "http://127.0.0.1:8000";

    public async Task<GenerateResponse> GenerateAsync(string prompt, string system = null)
    {
        var requestBody = new GenerateRequest { prompt = prompt, system = system };
        var url = $"{backendBaseUrl}/generate";
        var json = JsonUtility.ToJson(requestBody);

        using var request = new UnityWebRequest(url, "POST");
        var bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();
        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (request.result != UnityWebRequest.Result.Success)
        {
            throw new Exception($"Backend request failed: {request.error}, body: {request.downloadHandler.text}");
        }

        return JsonUtility.FromJson<GenerateResponse>(request.downloadHandler.text);
    }
}
