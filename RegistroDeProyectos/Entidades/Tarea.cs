using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDeProyectos.Entidades
{
	public class Tarea
	{
		public int TareaId { get; set; }
		public string TipoTarea { get; set; }

		public Tarea(int tareaId, string tipoTarea)
		{
			TareaId = tareaId;
			TipoTarea = tipoTarea;
		}
		public Tarea()
		{
			TareaId = 0;
			TipoTarea = string.Empty;
		}

	}
}
