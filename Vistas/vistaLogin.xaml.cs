namespace aaguirreTareaSemana2.Vistas;

public partial class vistaLogin : ContentPage
{
	public vistaLogin()
	{
		InitializeComponent();
	}

    private void btnIniciar_Clicked(object sender, EventArgs e)
    {
        /*Al mismo proyecto de la S2, agregar una nueva ventana Login y configurar los siguientes datos de conexión
        Crear 2 vectores
        user [Carlos, Ana, Jose]
        pass[carlos123,ana123,jose123]*/
        //Creación de los usuarios
        string[] usuarios = { "Carlos", "Ana", "Jose" };
        string[] contrasenas = { "carlos123", "ana123", "jose123" };

        string usuario = txtUsuario.Text;
        string contrasena = txtContrasena.Text;

        bool verificar = false;

        //Recorrer los usuarios 
        for (int i = 0; i < usuarios.Length; i++)
        {
            if(usuario == usuarios[i] && contrasena == contrasenas[i])
            {
                verificar = true;
                break; //Salimos del bucle si encontró coincidencias
            }
        }

        //Verificamos credenciales
        if (verificar==true)
        {
            Navigation.PushAsync(new vPrincipal(usuario));
        }
        else
        {
            DisplayAlert("Alerta", "Usuario/Contraseña incorrectos", "Cancelar");
        }
    }
}