using System.Globalization;
using BiciGestion.BLL;
using BiciGestion.Entity;

namespace Parcial1_LUG
{
    public partial class FormAlquileres : Form
    {
        private AlquilerBLL alquilerBLL = new AlquilerBLL();
        private TipoBicicletaBLL tipoBLL = new TipoBicicletaBLL();

        public FormAlquileres()
        {
            InitializeComponent();
        }

        private void FormAlquileres_Load(object sender, EventArgs e)
        {
            // No dejo elegir una fecha anterior a hoy
            dtpFechaAlquiler.MinDate = DateTime.Now.Date;

            CargarTiposBicicleta();
            CargarAlquileres();
            LimpiarCampos();
        }

        private void CargarTiposBicicleta()
        {
            try
            {
                cmbTipoBicicleta.DataSource = tipoBLL.Listar();
                cmbTipoBicicleta.DisplayMember = "Descripcion";
                cmbTipoBicicleta.ValueMember = "IdTipoBicicleta";
                cmbTipoBicicleta.SelectedIndex = -1;
            }
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los tipos de bicicleta.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarAlquileres()
        {
            try
            {
                List<Alquiler> lista = alquilerBLL.Listar();

                dgvAlquileres.DataSource = null;
                dgvAlquileres.DataSource = lista;

                if (dgvAlquileres.Columns.Count > 0)
                {
                    

                    dgvAlquileres.Columns["NumeroAlquiler"].HeaderText = "N° Alquiler";
                    dgvAlquileres.Columns["TipoBicicleta"].HeaderText = "Tipo de Bicicleta";
                    dgvAlquileres.Columns["DniCliente"].HeaderText = "DNI cliente";
                    dgvAlquileres.Columns["ImporteTotal"].HeaderText = "Importe total";
                    dgvAlquileres.Columns["FechaRegistro"].HeaderText = "Fecha registro";
                    dgvAlquileres.Columns["FechaAlquiler"].HeaderText = "Fecha alquiler";

                    dgvAlquileres.ClearSelection();
                }
            }
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los alquileres.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoBicicleta.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de bicicleta.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Alquiler alquiler = new Alquiler();
                alquiler.TipoBicicleta.IdTipoBicicleta = (int)cmbTipoBicicleta.SelectedValue;
                alquiler.DniCliente = txtDni.Text.Trim();
                alquiler.ImporteTotal = ParseImporte(txtImporte.Text);
                alquiler.FechaAlquiler = dtpFechaAlquiler.Value.Date;

                int numero = alquilerBLL.Registrar(alquiler);

                // Completo los datos que devolvio/uso la carga para mostrar la descripcion
                alquiler.NumeroAlquiler = numero;
                alquiler.TipoBicicleta.Descripcion = cmbTipoBicicleta.Text;

                MessageBox.Show("Alquiler registrado:\n" + alquiler.ObtenerDescripcion(), "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarAlquileres();
            }
            catch (FormatException)
            {
                MessageBox.Show("El importe total tiene que ser un numero valido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al registrar.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtNumeroAlquiler.Text.Trim());
                Alquiler alquiler = alquilerBLL.GetById(id);

                if (alquiler == null)
                {
                    MessageBox.Show("No existe un alquiler con el ID " + id + ".", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MostrarEnFormulario(alquiler);
            }
            catch (FormatException)
            {
                MessageBox.Show("El N° de alquiler tiene que ser un numero entero.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al buscar.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtNumeroAlquiler.Text.Trim());
                decimal importe = ParseImporte(txtImporte.Text);
                DateTime fecha = dtpFechaAlquiler.Value.Date;

                alquilerBLL.Modificar(id, importe, fecha);

                MessageBox.Show("Alquiler N° " + id + " modificado.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarAlquileres();
            }
            catch (FormatException)
            {
                MessageBox.Show("Revisa que el N° de alquiler y el importe sean numeros validos.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al modificar.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtNumeroAlquiler.Text.Trim());

                DialogResult r = MessageBox.Show("¿Seguro que queres eliminar el alquiler N° " + id + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r != DialogResult.Yes)
                    return;

                alquilerBLL.Eliminar(id);

                MessageBox.Show("Alquiler N° " + id + " eliminado.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarAlquileres();
            }
            catch (FormatException)
            {
                MessageBox.Show("El N° de alquiler tiene que ser un numero entero.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            CargarAlquileres();
        }

        private void btnAgregarBorrador_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTipoBicicleta.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de bicicleta.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Alquiler alquiler = new Alquiler();
                alquiler.TipoBicicleta.IdTipoBicicleta = (int)cmbTipoBicicleta.SelectedValue;
                alquiler.TipoBicicleta.Descripcion = cmbTipoBicicleta.Text;
                alquiler.DniCliente = txtDni.Text.Trim();
                alquiler.ImporteTotal = ParseImporte(txtImporte.Text);
                alquiler.FechaAlquiler = dtpFechaAlquiler.Value.Date;

                alquilerBLL.AgregarAlBorrador(alquiler);

                RefrescarBorrador();
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("El importe total tiene que ser un numero valido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al agregar al borrador.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmarBorrador_Click(object sender, EventArgs e)
        {
            try
            {
                alquilerBLL.ConfirmarBorrador();

                MessageBox.Show("Borrador confirmado. Todos los alquileres se guardaron en una sola transaccion.", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarBorrador();
                CargarAlquileres();
            }
            catch (BusinessException bex)
            {
                MessageBox.Show(bex.Message, "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al confirmar el borrador.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarBorrador()
        {
            lstBorrador.Items.Clear();
            foreach (Alquiler a in alquilerBLL.VerBorrador())
                lstBorrador.Items.Add($"{a.TipoBicicleta.Descripcion} - DNI {a.DniCliente} - ${a.ImporteTotal:N2} - {a.FechaAlquiler:dd/MM/yyyy}");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void MostrarEnFormulario(Alquiler alquiler)
        {
            txtNumeroAlquiler.Text = alquiler.NumeroAlquiler.ToString();
            cmbTipoBicicleta.SelectedValue = alquiler.TipoBicicleta.IdTipoBicicleta;
            txtDni.Text = alquiler.DniCliente;
            txtImporte.Text = alquiler.ImporteTotal.ToString("0.##", CultureInfo.CurrentCulture);

            DateTime fecha = alquiler.FechaAlquiler.Date;
            if (fecha < dtpFechaAlquiler.MinDate)
                fecha = dtpFechaAlquiler.MinDate;
            dtpFechaAlquiler.Value = fecha;
        }

        private decimal ParseImporte(string texto)
        {
            texto = texto.Trim();
            decimal valor;

            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out valor))
                return valor;

            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out valor))
                return valor;

            throw new FormatException("Importe invalido: " + texto);
        }

        private void LimpiarCampos()
        {
            txtNumeroAlquiler.Clear();
            txtDni.Clear();
            txtImporte.Clear();
            cmbTipoBicicleta.SelectedIndex = -1;
            dtpFechaAlquiler.Value = DateTime.Now.Date;
            dgvAlquileres.ClearSelection();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }
    }
}
