//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoDS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Historia_clinica
    {
        public string idHistoria { get; set; }
        public string documentoPaciente { get; set; }
        public string codigoProcedimiento { get; set; }
    
        public virtual Paciente Paciente { get; set; }
        public virtual Procedimiento Procedimiento { get; set; }
    }
}
