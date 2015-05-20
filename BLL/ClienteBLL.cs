using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto3Camadas.DTO;
using Projeto3Camadas.DAL;
using System.Data;

namespace Projeto3Camadas.BLL
{
    class ClienteBLL
    {
        AcessoBancoDados bd;

        public void Inserir(ClienteDTO dto)
        {
            // Inicia bloco de Tratamento de excessão
            try                
            {
                // Trata o erro quando o nome vem com apóstrofo
                string nome = dto.Nome.Replace("'", "''");
                bd = new AcessoBancoDados();

                bd.Conectar();
                string comando = "INSERT INTO cliente(nome, email) VALUES('" + nome + "','" + dto.Email + "')";
                bd.ExecutarComandoSQL(comando);            
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar cadastrar o cliente: " + ex.Message);
            }
            finally
            {
                bd = null;
            }            
        }

        public void Atualizar(ClienteDTO dto)
        {
            // Inicia bloco de Tratamento de excessão
            try
            {
                // Trata o erro quando o nome vem com apóstrofo
                string nome = dto.Nome.Replace("'", "''");
                bd = new AcessoBancoDados();

                bd.Conectar();
                string comando = "UPDATE cliente set nome = '" + dto.Nome + "', email = '" + dto.Email + "' WHERE id = " + dto.Id;
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar atualizar o registro: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
        }

        public void Excluir(string idCliente)
        {
            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();
                string comando = "DELETE FROM cliente WHERE id = " + idCliente;
                bd.ExecutarComandoSQL(comando);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar excluir o registro: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
        }

        public DataTable SelecionaTodosClientes()
        {
            DataTable dt = new DataTable();

            try
            {
                bd = new AcessoBancoDados();
                bd.Conectar();

                dt = bd.RetDataTable("SELECT id, nome, email from cliente");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar selecionar os registros: " + ex.Message);
            }
            finally
            {
                bd = null;
            }
            return dt;
        }
    }
}
