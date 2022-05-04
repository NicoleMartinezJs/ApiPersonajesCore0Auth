using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPersonajesCore0Auth.Models
{
        [Table("PERSONAJES")]
        public class PERSONAJES
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Column("IDPERSONAJE")]
            public int IdPersonaje { get; set; }
            [Column("PERSONAJE")]
            public string NombrePersonaje { get; set; }
            [Column("IMAGEN")]
            public string Imagen { get; set; }
            [Column("IDSERIE")]
            public int IdSerie { get; set; }
        }
}
