namespace wb_backend.Tools.Response;

public class PaginacionResponse<T> where T : class {
    public int PaignaActual { get; set; }
    public string? PaginaSiguiente { get; set; }
    public string? PaginaAnterior { get; set; }
    public int RegistrosPorPagina { get; set; }
    public int TotalRegistros { get; set; }
    public int TotalPaginas { get; set; }
    public IEnumerable<T> Data { get; set; } = null!;
}