using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cliente.Entities
{
    public class TelefoneDto
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public TipoTelefone Tipo { get; set; }
        [JsonIgnore]
        public ClienteDto? Cliente { get; set; }
        [JsonIgnore]
        public int? ClienteId { get; set; }
    }
    public enum TipoTelefone
    {
        Fixo,
        Celular
    }
}
