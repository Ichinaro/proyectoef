using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoef.Models;

public class Tarea {
  [Key]
  public Guid TareaId {get; set;}

  [ForeignKey("CategoriaId")]
  public Guid CategoriaId {get; set;}

  [Required]
  [MaxLength(200)]
  public string Titulo {get; set;}

  public string Descripcion {get; set;}
  public Prioridad PrioridadTarea {get; set;}
  public DateTime FechaCreacion {get; set;}
  public virtual Categoria Categoria {get; set;}

  [NotMapped]
  public string Resumen {get; set;}
  /* Se puede usar este atributo para crear dentro del codigo un `Resumen` 
    a partir del atributo `Descripcion`, por lo cual no necesitamos que
    se cree en la DB
  */
}

public enum Prioridad {
    Baja,
    Media,
    Alta
}
