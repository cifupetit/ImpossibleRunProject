
public class Jugador {

    private string nombre;
    private int nivel;

    public Jugador (string nombre, int nivel)
    {
        this.nombre = nombre;
        this.nivel = nivel;
    }

    public void setNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string getNombre()
    {
        return this.nombre;
    }

    public void setNivel(int nivel)
    {
        this.nivel = nivel;
    }

    public int getNivel()
    {
        return this.nivel;
    }
}
