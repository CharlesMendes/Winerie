using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.data
{
    /// <summary>
    /// TBD_PERFILUSUARIO
    /// TBD = Tabela de dominio
    /// </summary>
    public static class PerfilUsuarioSQL
    {
        public static string Listar
        {
            get
            {
                return @"SELECT * FROM TBD_PERFILUSUARIO";
            }
        }

        public static string ListarPorId
        {
            get
            {
                return @"SELECT * FROM TBD_PERFILUSUARIO WHERE id = @id";
            }
        }

        public static string Inserir
        {
            get
            {
                return @"INSERT INTO TBD_PERFILUSUARIO (nomePerfil, descricao) VALUES (@nomePerfil, @descricao)";
            }
        }

        public static string Alterar
        {
            get
            {
                return @"UPDATE TBD_PERFILUSUARIO SET nomePerfil = @nomePerfil, descricao = @descricao WHERE id = @id";
            }
        }

        public static string Excluir
        {
            get
            {
                return @"DELETE FROM TBD_PERFILUSUARIO WHERE id = @id";
            }
        }
    }
}
