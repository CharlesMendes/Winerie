using System;
using System.Collections.Generic;

namespace jcconsultingti.winerie.business
{
	public interface ICrud<T> 
	{
		long Salvar(T obj);
		T Detalhe(long id);
		List<T> ListarTodos();
		void Excluir(int id);
	}
}
