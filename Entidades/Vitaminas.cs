

using System.ComponentModel.DataAnnotations;

namespace _2doParcial_Nicol.Entidades
{
    public class Vitaminas
    {


        [Key]
        public int VitaminaId { get; set; }
        public String? Nombre { get; set; }
    }
}