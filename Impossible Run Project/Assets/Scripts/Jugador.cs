
[System.Serializable]
public class Jugador {

    private string nombre;
    private int nivel;

    public Jugador (string nombre, int nivel)
    {
        this.nombre = nombre;
        this.nivel = nivel;
    }

    public void SetNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string GetNombre()
    {
        return this.nombre;
    }

    public void SetNivel(int nivel)
    {
        this.nivel = nivel;
    }

    public int GetNivel()
    {
        return this.nivel;
    }
}
