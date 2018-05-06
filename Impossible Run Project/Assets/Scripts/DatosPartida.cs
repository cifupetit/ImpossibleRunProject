
[System.Serializable]
public static class DatosPartida {
    
    private static Jugador datosJugador;

    public static void CargaDatos(Jugador datos)
    {
        datosJugador = datos;
    }

    public static Jugador GetJugador()
    {
        return datosJugador;
    }

    public static void SetJugador(Jugador jugador)
    {
        datosJugador = jugador;
    }
}
