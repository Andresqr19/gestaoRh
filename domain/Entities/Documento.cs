public class Documento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string? OrgaoEmissor { get; set; }
        public string? Serie { get; set; }
        public string? ZonaEleitoral { get; set; }
        public DateTime? DataEmissao { get; set; }
        public string? NumeroFolha { get; set; }
        public string? NumeroTermo { get; set; }
    }
