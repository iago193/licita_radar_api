using System.Net;
using System.Text.Json;
using LicitaRadarApi.DTO;

namespace LicitaRadarApi.Service;

public class PncpService
{
    private readonly HttpClient _httpClient;

    public PncpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://pncp.gov.br/api/consulta/v1/");
    }

    public async Task<PncpResponseDto> SearchHiringsAsync(
    DateTime dataInicial, DateTime dataFinal, int pagina = 1)
    {
        var query = $"contratacoes/publicacao" +
                     $"?dataInicial={dataInicial:yyyyMMdd}" +
                     $"&dataFinal={dataFinal:yyyyMMdd}" +
                     $"&codigoModalidadeContratacao=6" +
                     $"&pagina={pagina}";

        var response = await _httpClient.GetAsync(query);

        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return new PncpResponseDto(); // lista vazia, sem licitações no período
        }

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PncpResponseDto>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}