using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Packaging;
using System.Text;

namespace RegistroDeProyectos.Entidades
{
	public class ProyectoDetalle
	{
		[Key]
		public int ProyectoDetalleId { get; set; }
		public string Requerimento { get; set; }
		public int Tiempo { get; set; }
		public int TareaID { get; set; }
	

		public ProyectoDetalle(int tipoID,string requerimento, int tiempo)
		{
			ProyectoDetalleId = 0;
			TareaID = tipoID;
			Requerimento = requerimento;
			Tiempo = tiempo;
			
			
		}
		public ProyectoDetalle()
		{
			ProyectoDetalleId = 0;
			TareaID = 0;
			Requerimento = string.Empty;
			Tiempo = 0;


		}
	}
}
