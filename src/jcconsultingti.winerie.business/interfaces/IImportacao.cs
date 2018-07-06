using System;
using System.Collections.Generic;

namespace jcconsultingti.winerie.business
{
	public interface IImportacao<T> 
	{
		bool Importar(T importacao);
	}
}
