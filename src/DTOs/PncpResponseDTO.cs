namespace LicitaRadarApi.DTO;

public class PncpResponseDto
{
    public List<PncpContratacaoDto> Data { get; set; } = [];
    public int TotalRegistros { get; set; }
    public int TotalPaginas { get; set; }
    public int NumeroPagina { get; set; }
}

public class PncpContratacaoDto
{
    public string NumeroControlePNCP { get; set; } = string.Empty;
    public string ObjetoCompra { get; set; } = string.Empty;
    public decimal? ValorTotalEstimado { get; set; }
    public DateTime DataPublicacaoPncp { get; set; }
    public DateTime? DataEncerramentoProposta { get; set; }
    public OrgaoEntidadeDto OrgaoEntidade { get; set; } = new();
}

public class OrgaoEntidadeDto
{
    public string RazaoSocial { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
}