using jcordovat5.Models;

namespace jcordovat5.Views;

public partial class vPersona : ContentPage
{
    

    public vPersona()
    {
        InitializeComponent();
    }

    private void btnInsertar_Clicked_1(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        App.personRepo.AddNewPerson(txtNombre.Text);
        lblMessage.Text = App.personRepo.StatusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        List<Persona> people = App.personRepo.getAllPeople();
        listaPersona.ItemsSource = App.personRepo.StatusMessage;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (int.TryParse(txtNombre.Text.Trim(), out int idActualizar))
        {
            string nuevoNombre = txtNombre.Text.Trim();
            App.personRepo.UpdatePerson(idActualizar, nuevoNombre);
            lblMessage.Text = App.personRepo.StatusMessage;
        }
        else
        {
            lblMessage.Text = "Ingrese un ID válido para actualizar";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (int.TryParse(txtNombre.Text.Trim(), out int idEliminar))
        {
            App.personRepo.DeletePerson(idEliminar);
            lblMessage.Text = App.personRepo.StatusMessage;
        }
        else
        {
            lblMessage.Text = "Ingrese un ID válido para eliminar";
        }
    }
}