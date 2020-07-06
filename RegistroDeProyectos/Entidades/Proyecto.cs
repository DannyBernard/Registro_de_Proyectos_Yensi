using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace RegistroDeProyectos.Entidades
{
public	class Proyecto
	{
		[Key]
		public int ProyectoId { get; set; }
		public string Descripcion  { get; set; }
		public DateTime Fecha { get; set; }


		[ForeignKey("ProyectoId")]
		public List<ProyectoDetalle> Detalle { get; set; } = new List<ProyectoDetalle>();
       
	}
}
