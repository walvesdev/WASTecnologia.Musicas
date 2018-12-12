using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASTecnologia.Musicas.Dominio
{
    public class Usuario
    {
        [Required(ErrorMessage = "O Email é obrigatorio")]
        [MaxLength(30, ErrorMessage ="o Email não pode ter mais de 30 caracteres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatoria")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
