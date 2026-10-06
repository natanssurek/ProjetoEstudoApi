class Disciplina {


    private static int _proximoId = 1;

    public int Id {get;} = _proximoId++;
    public string NomeDisciplina {get; set;}
    public int CargaHoraria {get; set;}
}