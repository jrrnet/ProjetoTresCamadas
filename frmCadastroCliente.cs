using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projeto3Camadas.BLL;
using Projeto3Camadas.DTO;

namespace Projeto3Camadas
{
    public partial class frmCadastroCliente : Form
    {
        ClienteBLL bll = new ClienteBLL();
        ClienteDTO dto = new ClienteDTO();

        public frmCadastroCliente()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {            
            dto.Nome = txtNome.Text;
            dto.Email = txtEmail.Text;

            if (txtID.Text == "")
            {
                bll.Inserir(dto);
                MessageBox.Show("Cadastro realizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dto.Id = int.Parse(txtID.Text);
                bll.Atualizar(dto);
                MessageBox.Show("Registro atualizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LimparTela();
            // Atualiza o GRID quando aplicação inicia
            CarregarGrid();
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            // Faz o carregamento do GRID com as informações do Banco de dados
            gridClientes.DataSource = bll.SelecionaTodosClientes();
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = gridClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNome.Text = gridClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEmail.Text = gridClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        private void LimparTela()
        {
            txtID.Clear();
            txtNome.Clear();
            txtEmail.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {

                var result = MessageBox.Show("Deseja realmente excluir o registro?", "Excluir registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    bll.Excluir(txtID.Text);

                    MessageBox.Show("O registro foi excluido com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparTela();
                    CarregarGrid();
                }
            }
        }
    }
}
