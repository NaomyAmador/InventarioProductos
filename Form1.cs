namespace InventarioProductos_Práctica_Entity_Framework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Crear_Click(object sender, EventArgs e)
        {
            using (var BasedeDatos = new Data.InventarioProductosContext())
            {
                var Producto = new Models.Productos
                {
                    Producto = TxtBox_Producto.Text,
                    Precio = decimal.Parse(TxtBox_Precio.Text),
                    Stop = int.Parse(TxtBox_Stop.Text)
                };
                BasedeDatos.Productos.Add(Producto);
                BasedeDatos.SaveChanges();
                DataGridView_TablaBDD.DataSource = BasedeDatos.Productos.ToList();
                MessageBox.Show("¡Producto creado correctamente!");
            }

            TxtBox_Producto.Text = "";
            TxtBox_Precio.Text = "";
            TxtBox_Stop.Text = "";
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            using (var BasedeDatos = new Data.InventarioProductosContext())
            {
                int Id = int.Parse(TxtBox_Id.Text);
                var Producto = BasedeDatos.Productos.Find(Id);

                if (Producto != null)
                {
                    TxtBox_Producto.Text = Producto.Producto;
                    TxtBox_Precio.Text = Producto.Precio.ToString();
                    TxtBox_Stop.Text = Producto.Stop.ToString();
                }
                else
                {
                    MessageBox.Show("Producto no encontrado en la tabla, ¡asegúrate de buscar con el Id ya existente!");
                }
            }
        }

        private void Btn_MostrarTodo_Click(object sender, EventArgs e)
        {
            using (var BasedeDatos = new Data.InventarioProductosContext())
            {
                DataGridView_TablaBDD.DataSource = BasedeDatos.Productos.ToList();
            }
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            using (var BasedeDatos = new Data.InventarioProductosContext())
            {
                int Id = int.Parse(TxtBox_Id.Text);
                var Producto = BasedeDatos.Productos.Find(Id);

                if (Producto != null)
                {
                    Producto.Precio = decimal.Parse(TxtBox_Precio.Text);
                    Producto.Stop = int.Parse(TxtBox_Stop.Text);
                    BasedeDatos.SaveChanges();
                    DataGridView_TablaBDD.DataSource = BasedeDatos.Productos.ToList();
                    MessageBox.Show("¡Producto Actualizado exitosamente!");
                }

                else
                {
                    MessageBox.Show("Producto no encontrado en la tabla, ¡asegúrate de usar el Id correcto!");
                }

                TxtBox_Id.Text = "";
                TxtBox_Precio.Text = "";
                TxtBox_Stop.Text = "";
            }
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            using (var BasedeDatos = new Data.InventarioProductosContext())
            {
                int Id = int.Parse(TxtBox_Id.Text);
                var Producto = BasedeDatos.Productos.Find(Id);

                if (Producto != null)
                {
                    BasedeDatos.Productos.Remove(Producto);
                    BasedeDatos.SaveChanges();
                    DataGridView_TablaBDD.DataSource = BasedeDatos.Productos.ToList();
                    MessageBox.Show("¡Producto Eliminado correctamente!");
                }

                else
                {
                    MessageBox.Show("Producto no encontrado en la tabla, ¡asegúrate de usar el Id correcto!");
                }

                TxtBox_Id.Text = "";
            }
        }
    }
}
