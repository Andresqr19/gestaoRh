using System.ComponentModel.DataAnnotations;

public class Endereco
    {
        public int Id { get; set; }

        [Required]
        public string Rua { get; set; } = string.Empty;

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; } = string.Empty;

        public string? Complemento { get; set; } = string.Empty;

        [Required]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "UF deve ter 2 caracteres")]
        public string UF { get; set; } = string.Empty;

        [Required]
        public string CEP { get; set; } = string.Empty;
    }