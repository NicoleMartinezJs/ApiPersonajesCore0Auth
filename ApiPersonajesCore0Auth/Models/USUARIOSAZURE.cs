using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonajesCore0Auth.Models
{
    [Table("USUARIOSAZURE")]
    public class USUARIOSAZURE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }
        [Column("NOMBRE")]
        public string NombreUsuario { get; set; }
        [Column("APELLIDOS")]
        public string ApellidoUsuario { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
        [Column("PASS")]
        public string Password { get; set; }
    
    }
}
