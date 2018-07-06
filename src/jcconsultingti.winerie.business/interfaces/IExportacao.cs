using System;
using System.Collections.Generic;

namespace jcconsultingti.winerie.business
{
	public interface IExportacao<T> 
	{
		string Exportar(long id);
	}
}
