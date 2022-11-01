using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2doParcial_Nicol.Entidades
{
   

public class Verduras{
 
  [Key]
  public int VerduraId{ get; set; }
  public String? Nombre { get; set; }
  public DateTime Fecha { get; set; } 
  public String? Observaciones { get; set; }

  [ForeignKey("VerduraId")]

  public virtual List<VerdurasDetalles> Detalle { get; set; } = new List<VerdurasDetalles> ();
  
}



public class VerdurasDetalles{
 
  [Key]
  public int VerduraId{ get; set; }
  public int  VitaminaId{ get; set; }
  public int Cantidad { get; set; }

  public int Total{ get; set; }
  public string Descripcion { get; set; }
  
}
}


