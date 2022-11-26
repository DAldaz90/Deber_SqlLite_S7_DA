using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SQLite;
namespace SqlLite.Models
{
    public class Postulante
    {
        [PrimaryKey ,AutoIncrement]
        public int id { get; set; }
        [MaxLength(55)]
        public string nombre { get; set; }
        [MaxLength(100)]
        public string apellido { get; set; }
        [MaxLength(100)]
        public string identificacion { get; set; }
        [MaxLength(100)]
        public int edad { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(100)]
        public string telefono { get; set; }
        [MaxLength(100)]
        public string direccion { get; set; }
        [MaxLength(100)]
        public string estadoCivil { get; set; }
        [MaxLength(100)]
        public string instruccion { get; set; }
        [MaxLength(100)]
        public string tituloAcademico { get; set; }
        [MaxLength(100)]
        
        public string descripcion { get; set; }
        [MaxLength(100)]
        public String experiencia { get; set; }

    }
}
